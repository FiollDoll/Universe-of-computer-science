using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GamesManager : MonoBehaviour
{
    public static GamesManager Instance {get; private set;}
    private Level selectedLvl;

    // Сцена игры
    [Header("Main")]
    [SerializeField] private TextMeshProUGUI textLvlName;
    [SerializeField] private Button buttonNext, buttonBack;

    // LevelType - TextLevel
    [Header("TextLevel")]
    [SerializeField] private GameObject lvlInfoMenu;
    [SerializeField] private TextMeshProUGUI lvlInfo;
    [SerializeField] private Image lvlImage;

    private void Awake() => Instance = this;

    private void Start()
    {
        selectedLvl = LevelManager.Instance.GetSelectedLevel();
        textLvlName.text = selectedLvl.nameOfLevel;
        LevelManager.Instance.ActivateStep();
        UpdateButtonNextAndBack();
    }

    public void ActivateLvlInfoMenu(TextStep textStep)
    {
        lvlInfoMenu.gameObject.SetActive(true);
        lvlInfo.text = textStep.textDescription;
        lvlImage.sprite = textStep.image;
    }

    public void UpdateButtonNextAndBack()
    {
        buttonNext.interactable = true;
        buttonBack.interactable = true;
        if (LevelManager.Instance.stepIdx == (selectedLvl.levelSteps.Length - 1))
        {
            buttonNext.interactable = false;
        }
        if (LevelManager.Instance.stepIdx == 0)
            buttonBack.interactable = false;
    }

    public void MoveOnSteps(int modif)
    {
        LevelManager.Instance.stepIdx += modif;
        LevelManager.Instance.ActivateStep();
        UpdateButtonNextAndBack();
    }

    public void ExitFromLvl() => SceneManager.LoadScene(0);
}
