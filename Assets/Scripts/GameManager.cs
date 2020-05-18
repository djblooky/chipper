using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public static bool paused = false;
    private string currentLevel;

    //Club
    [HideInInspector] public static GameObject club;
    [HideInInspector] public static FollowMouse followMouseComponent;
    [HideInInspector] public static RotateTowardsBall rotateTowardsComponent;
    [HideInInspector] public static SwingForceMeter swingMeterComponent;
    [HideInInspector] public static HitBall hitBallComponent;

    //Stage
    [HideInInspector] public static GameObject stage;
    [HideInInspector] public static NavigateStage navigateStageComponent;

    //Ball
    [HideInInspector] public static GameObject ball;
    [HideInInspector] public static Rigidbody ballRB;

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
        hitBallComponent = club.GetComponentInChildren<HitBall>();

        //stage components
        navigateStageComponent = stage.GetComponent<NavigateStage>();

        //ball
        ballRB = ball.GetComponent<Rigidbody>();
    }

    void Update()
    {
        ShowCursorToggle();
        UpdateCurrentLevel();
        CheckForPause();
    }

    void ShowCursorToggle()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Cursor.visible)
        {
            Cursor.visible = true;
        }
        else
        {
            Cursor.visible = false;
        }
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
