using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class MenuManager : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject[] allMenu = new GameObject[0];
    [SerializeField] private GameObject blockThemePrefab, buttonLevelPrefab;
    [SerializeField] private Transform blocksThemeParent;

    private void Start()
    {
        // + Делаем чтобы темы сразу спавнились(ну хранить на сцене ну нее)
        foreach (Theme theme in LevelManager.Instance.themes)
        {
            var block = Instantiate(blockThemePrefab, Vector3.zero, Quaternion.identity, blocksThemeParent);
            block.transform.Find("TextTheme").GetComponent<TextMeshProUGUI>().text = theme.nameOfTheme;
            foreach (Level lvl in theme.levelsInTheme)
            {
                var lvlBlock = Instantiate(buttonLevelPrefab, Vector3.zero, Quaternion.identity, block.transform.Find("buttonsGrid").transform);
                lvlBlock.transform.Find("TextName").GetComponent<TextMeshProUGUI>().text = lvl.nameOfLevel;
            }
        }
    }

    private void ChangePage(GameObject page)
    {
        foreach (GameObject menu in allMenu)
            menu.SetActive(false);
        page.SetActive(true);
    }

    public void OpenMenu(GameObject menuObj) => ChangePage(menuObj);

    public void ChoiceLevel(string levelInfo)
    {

    }
}
