using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public static bool paused = false;
    private string currentLevel;

    //Club
    GameObject club;
    private FollowMouse followMouseComponent;
    private RotateTowardsBall rotateTowardsComponent;
    private SwingForceMeter swingMeterComponent;

    //Stage
    GameObject stage;
    private NavigateStage navigateStageComponent;

    //Ball
    GameObject ball;
    Rigidbody ballRB;

    void Start()
    {
        Cursor.visible = false;
        GetObjectsFromScene();
        SetUpComponents();
    }

    void GetObjectsFromScene()
    {
        ball = GameObject.FindGameObjectWithTag("Ball");
        club = GameObject.FindGameObjectWithTag("Club");
        stage = GameObject.FindGameObjectWithTag("Stage");
    }

    void SetUpComponents()
    {
        //club components
        followMouseComponent = club.GetComponent<FollowMouse>();
        rotateTowardsComponent = club.GetComponent<RotateTowardsBall>();
        swingMeterComponent = club.GetComponentInChildren<SwingForceMeter>();

        //stage components
        navigateStageComponent = stage.GetComponent<NavigateStage>();

        //ball
        ballRB = ball.GetComponent<Rigidbody>();
    }

    void Update()
    {
        UpdateCurrentLevel();
        CheckForPause();
    }

    void UpdateCurrentLevel()
    {
        string newLevel = SceneManager.GetActiveScene().name;

        if (currentLevel != newLevel)
            currentLevel = newLevel;
    }

    void CheckForPause()
    {
        if (paused)
        {
            navigateStageComponent.enabled = false;
            rotateTowardsComponent.enabled = false;
            followMouseComponent.enabled = false;
            swingMeterComponent.enabled = false;
            ballRB.freezeRotation = true;
        }
        else
        {
            navigateStageComponent.enabled = true;
            rotateTowardsComponent.enabled = true;
            followMouseComponent.enabled = true;
            swingMeterComponent.enabled = true;
            ballRB.freezeRotation = false;
        }
    }

}
