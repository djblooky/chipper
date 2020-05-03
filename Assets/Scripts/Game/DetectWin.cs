using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectWin : MonoBehaviour
{
    private GameObject goalFlag;
    private GameMenu menu;
    private GameObject canvas;

    [SerializeField] float winDelay = 3f;

    private void Start()
    {
        goalFlag = GameObject.FindGameObjectWithTag("GoalFlag");
        goalFlag.SetActive(false);

        canvas = GameObject.FindGameObjectWithTag("Canvas");
        menu = canvas.GetComponent<GameMenu>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            goalFlag.SetActive(true);
            Invoke("EndStage", winDelay);
        }
    }

    void EndStage()
    {
        menu.ShowEndStageMenu();   
    }

}
