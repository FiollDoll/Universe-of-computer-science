using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class MenuManager : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject[] allMenu = new GameObject[0];
    [SerializeField] private GameObject pageWithThemes, levelInfoMenu;
    [SerializeField] private GameObject blockThemePrefab, buttonLevelPrefab;
    [SerializeField] private Transform blocksThemeParent;
    [SerializeField] private TextMeshProUGUI textLvlName, textThemeName, textDescription;
    
    private GameObject _selectedMenuOfThemes;

    private void ChangePage(GameObject page)
    {
        foreach (GameObject menu in allMenu)
            menu.SetActive(false);
        page.SetActive(true);
        _selectedMenuOfThemes = page;
    }

    private void OpenPageWithGames(int mode)
    {
        ChangePage(pageWithThemes);
        OpenListOfThemes(mode);
    }

    private void OpenListOfThemes(int mode)
    {
        foreach (Transform child in blocksThemeParent)
            Destroy(child.gameObject);

        foreach (Theme theme in LevelManager.Instance.themes)
        {
            if ((Enums.Category)mode == theme.themeCategory)
            {
                var block = Instantiate(blockThemePrefab, Vector3.zero, Quaternion.identity, blocksThemeParent);
                block.transform.Find("TextTheme").GetComponent<TextMeshProUGUI>().text = theme.nameOfTheme;
                foreach (Level lvl in theme.levelsInTheme)
                {
                    var lvlBlock = Instantiate(buttonLevelPrefab, Vector3.zero, Quaternion.identity, block.transform.Find("buttonsGrid").transform);
                    lvlBlock.transform.Find("TextName").GetComponent<TextMeshProUGUI>().text = lvl.nameOfLevel;
                    // Для кнопки
                    Theme selectedTheme = theme;
                    Level selectedLvl = lvl;
                    lvlBlock.GetComponent<Button>().onClick.AddListener(() => ChoiceLevelToInfo(selectedTheme, selectedLvl));
                }
            }
        }
        GameObject.Find("ScrollViewThemes").GetComponent<AdaptiveScrollView>().UpdateContentSize();
    }

    public void OpenMenu(GameObject menuObj) => ChangePage(menuObj);

    public void OpenLvlMenu(int mode) =>  OpenPageWithGames(mode);

    public void ChoiceLevelToInfo(Theme theme, Level lvl)
    {
        _selectedMenuOfThemes.SetActive(false);
        levelInfoMenu.SetActive(true);
        textLvlName.text = lvl.nameOfLevel;
        textThemeName.text = theme.nameOfTheme;
        textDescription.text = lvl.descriptionOfLevel;
    }

    public void CloseLevelInfo()
    {
        levelInfoMenu.SetActive(false);
        _selectedMenuOfThemes.SetActive(true);
    }
}
