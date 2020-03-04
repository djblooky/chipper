using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectWin : MonoBehaviour
{
    GameObject goalFlag;

    private void Start()
    {
        goalFlag = GameObject.FindGameObjectWithTag("GoalFlag");
        goalFlag.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            Destroy(other.gameObject);
            goalFlag.SetActive(true);
            UpdateWinText();
        }
    }

    void UpdateWinText()
    {
        Debug.Log("You win!");
    }

}
