using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool paused = false;
    private string currentLevel;

    //Club
    [SerializeField] GameObject clubObject;
    private FollowMouse followMouseComponent;
    private RotateTowardsBall rotateTowardsComponent;

    //Stage
    [SerializeField] GameObject stageObject;
    private NavigateStage navigateStageComponent;

    void Start()
    {
        SetUpComponents();
    }

    void SetUpComponents()
    {
        //club components
        followMouseComponent = clubObject.GetComponent<FollowMouse>();
        rotateTowardsComponent = clubObject.GetComponent<RotateTowardsBall>();

        //stage components
        navigateStageComponent = stageObject.GetComponent<NavigateStage>();

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
        }
        else
        {
            navigateStageComponent.enabled = true;
            rotateTowardsComponent.enabled = true;
            followMouseComponent.enabled = true;
        }
    }

}
