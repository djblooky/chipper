using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject creditsMenu;
    [SerializeField] GameObject stageSelectMenu;

    private AudioSource audioSource;
    [SerializeField] AudioClip buttonPressSound;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        ShowMainMenu();
    }

    public void StartGame()
    {
        //the scene needs to be registered in build settings
        SceneManager.LoadScene("Level1");
    }

    public void ShowCredits()
    {
       // mainMenu.SetActive(false);
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

    public void PlayButtonPressSound()
    {
        audioSource.PlayOneShot(buttonPressSound, 0.7F);
    }

    public void FullCredits()
    {
        Application.OpenURL("https://github.com/djblooky/ges-midterm/wiki/Credits");
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
