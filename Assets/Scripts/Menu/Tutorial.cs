using TMPro;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] TMP_Text tutorialText;
    int tutorialStep = 0;
    float timeLeft = 3.0f;

    private void Start()
    {
        SetUp();
        PlayTutorial();
    }

    void SetUp()
    {
        GameManager.ball.SetActive(false);
        GameManager.swingMeterComponent.enabled = false;
    }

    void PlayTutorial()
    {
        switch (tutorialStep) {
            case 0:
                tutorialText.text = "Use the W and S keys to zoom";
                break;  
            case 1:
                tutorialText.text = "Use the A and D keys to rotate the stage";
                break;
            case 2:
                GameManager.ball.SetActive(true);
                tutorialText.text = "Your club will rotate towards the ball";
                break;
            case 3:
                GameManager.swingMeterComponent.enabled = true;
                tutorialText.text = "Hold down the mouse to begin your swing. The meter will determine your swing strength.";
                break;
            case 4:
                tutorialText.text = "Hit the ball while holding the mouse to swing.";
                break;
            case 5:
                tutorialText.text = "Try getting the ball into the hole!";
                break;   
        }

    }

    private void Update()
    {
        CheckForTutorialProgress();
        PlayTutorial();
    }

    /// <summary>
    /// Checks to see what step of the tutorial the player has completed
    /// </summary>
    void CheckForTutorialProgress()
    {
        switch (tutorialStep)
        {
            case 0: if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S))
                    tutorialStep = 1;
                break;
            case 1:
                if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.D))           
                    tutorialStep = 2; 
                break;
            case 2:
                timeLeft -= Time.deltaTime;
                if (timeLeft < 0)
                    tutorialStep = 3;
                break;
            case 3:
                if (Input.GetMouseButton(0))
                    tutorialStep = 4;
                break;
            case 4:
                if (GameManager.hitBallComponent.wasHit)
                    tutorialStep = 5;
                break;
        }
    }
}
