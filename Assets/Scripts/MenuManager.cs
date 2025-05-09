using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{
    [Header("UI")] [SerializeField] private GameObject[] allMenu = new GameObject[0];
    [SerializeField] private GameObject pageWithThemes, levelInfoMenu;
    [SerializeField] private AdaptiveScrollView scrollViewThemes;
    [SerializeField] private Transform blocksThemeParent;
    [SerializeField] private TextMeshProUGUI textLvlName, textThemeName, textDescription;
    [SerializeField] private Image lvlIconInfo; 
    [SerializeField] private Button buttonStartLvl;

    [Header("Prefabs")] [SerializeField] private GameObject blockThemePrefab;
    [SerializeField] private GameObject buttonLevelPrefab;

    private GameObject _selectedMenuOfThemes;

    private void Start()
    {
        if (LevelManager.Instance.GetSelectedTheme() != null)
        {
            OpenPageWithGames(LevelManager.Instance.GetSelectedTheme().themeCategory ==
                              Enums.Category.FirstToFourthClass ? 0 : 1);
        }
    }
    
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
        float startY = 665f;
        foreach (Theme theme in LevelManager.Instance.themes)
        {
            if ((Enums.Category)mode != theme.themeCategory) continue;

            Vector3 newPos = new Vector3(0, startY, 0);
            var block = Instantiate(blockThemePrefab, Vector3.zero, Quaternion.identity, blocksThemeParent);
            block.GetComponent<RectTransform>().anchoredPosition = newPos;
            block.transform.Find("buttonsGrid").transform.Find("TextTheme").GetComponent<TextMeshProUGUI>().text = theme.nameOfTheme;
            block.transform.Find("buttonsGrid").GetComponent<Image>().color = theme.color;
            foreach (Level lvl in theme.levelsInTheme)
            {
                var lvlBlock = Instantiate(buttonLevelPrefab, Vector3.zero, Quaternion.identity,
                    block.transform.Find("buttonsGrid").transform);
                lvlBlock.transform.Find("TextName").GetComponent<TextMeshProUGUI>().text = lvl.nameOfLevel;
                // Для кнопки
                Theme selectedTheme = theme;
                Level selectedLvl = lvl;
                lvlBlock.GetComponent<Button>().onClick
                    .AddListener(() => ChoiceLevelToInfo(selectedTheme, selectedLvl));
            }

            block.GetComponent<AdaptiveBlock>().UpdateContentSize();
            startY -= 200f + (20 * theme.levelsInTheme.Count);
        }
        scrollViewThemes.UpdateContentSize();
    }

    public void OpenMenu(GameObject menuObj) => ChangePage(menuObj);

    public void CloseThemesAndOpenMenu(GameObject menuObj)
    {
        foreach (Transform child in blocksThemeParent)
            Destroy(child.gameObject);
        
        ChangePage(menuObj);
    }
    
    public void OpenLvlMenu(int mode) => OpenPageWithGames(mode);

    public void ChoiceLevelToInfo(Theme theme, Level lvl)
    {
        _selectedMenuOfThemes.SetActive(false);
        levelInfoMenu.SetActive(true);
        textLvlName.text = lvl.nameOfLevel;
        textThemeName.text = theme.nameOfTheme;
        lvlIconInfo.sprite = lvl.preiconOfLevel;
        lvlIconInfo.SetNativeSize();
        textDescription.text = lvl.descriptionOfLevel;
        buttonStartLvl.onClick.AddListener(() => StartLevel(theme, lvl));
    }

    public void CloseLevelInfo()
    {
        levelInfoMenu.SetActive(false);
        _selectedMenuOfThemes.SetActive(true);
    }

    public void StartLevel(Theme theme, Level lvl) => LevelManager.Instance.ActivateLevel(theme, lvl);
}