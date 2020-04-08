using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject creditsMenu;
    [SerializeField] GameObject stageSelectMenu;

    public void StartGame()
    {
        //the scene needs to be registered in build settings
        SceneManager.LoadScene("Level1");
    }

    public void ShowCredits()
    {
        mainMenu.SetActive(false);
        creditsMenu.SetActive(true);
        stageSelectMenu.SetActive(false);
    }

    public void ShowMainMenu()
    {
        mainMenu.SetActive(true);
        creditsMenu.SetActive(false);
        stageSelectMenu.SetActive(false);
    }

    public void ShowStageSelectMenu()
    {
        mainMenu.SetActive(false);
        creditsMenu.SetActive(false);
        stageSelectMenu.SetActive(true);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
