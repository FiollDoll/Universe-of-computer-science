using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject[] allMenu = new GameObject[0];

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
