using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GamesManager : MonoBehaviour
{
    public static GamesManager Instance {get; private set;}
    // Сцена игры
    [SerializeField] private TextMeshProUGUI textLvlName;

    // LevelType - TextLevel
    [SerializeField] private GameObject lvlInfoMenu;
    [SerializeField] private TextMeshProUGUI lvlInfo;
    [SerializeField] private Image lvlImage;

    private void Awake() => Instance = this;

    private void Start()
    {
        textLvlName.text = LevelManager.Instance.GetSelectedLevel().nameOfLevel;
        LevelManager.Instance.ActivateStep(0);
    }

    public void ActivateLvlInfoMenu(TextStep textStep)
    {
        lvlInfoMenu.gameObject.SetActive(true);
        lvlInfo.text = textStep.textDescription;
    }
}
