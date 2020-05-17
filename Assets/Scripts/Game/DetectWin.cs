using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectWin : MonoBehaviour
{
    private GameObject confetti;
    private GameMenu menu;
    private GameObject canvas;

    [SerializeField] float winDelay = 3f;

    private void Start()
    {
        confetti = GameObject.FindGameObjectWithTag("Confetti");
        confetti.SetActive(false);

        canvas = GameObject.FindGameObjectWithTag("Canvas");
        menu = canvas.GetComponent<GameMenu>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            confetti.SetActive(true);
            Invoke("EndStage", winDelay);
        }
    }

    void EndStage()
    {
        menu.ShowEndStageMenu();   
    }

}
