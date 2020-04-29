using UnityEngine;

public class GameMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject inGameUI;

    public void PauseGame()
    {
        GameManager.paused = true;
        pauseMenu.SetActive(true);
        inGameUI.SetActive(false);
    }

    public void UnpauseGame()
    {
        GameManager.paused = false;
        pauseMenu.SetActive(false);
        inGameUI.SetActive(true);
    }

}
