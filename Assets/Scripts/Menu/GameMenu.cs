using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject inGameUI;
    [SerializeField] GameObject endStageMenu;

    public void PauseGame()
    {
        GameManager.paused = true;
        pauseMenu.SetActive(true);
        inGameUI.SetActive(false);
        Cursor.visible = true;
    }

    public void UnpauseGame()
    {
        pauseMenu.SetActive(false);
        inGameUI.SetActive(true);

        Cursor.visible = false;
        GameManager.paused = false;
    }

    public void ShowEndStageMenu()
    {
        inGameUI.SetActive(false);
        pauseMenu.SetActive(false);
        endStageMenu.SetActive(true);

        Cursor.visible = true;
        GameManager.paused = true;
    }

    public void PlayNextLevel(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
        GameManager.paused = false;
    }

    public void ToTitle()
    {
        SceneManager.LoadScene("MainMenu"); //load main menu
        Cursor.visible = true;
        GameManager.paused = false;
    }

    public void ReplayLevel()
    {
        pauseMenu.SetActive(false);
        inGameUI.SetActive(true);
        endStageMenu.SetActive(false);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //reload current scene
        GameManager.paused = false;
    }

}
