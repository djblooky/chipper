using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigateStage : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 1f;
    [SerializeField] float zoomFactor = 0.1f;

    void Update()
    {
        CheckForRotation();
        CheckForCameraZoom();
    }

    void CheckForRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(0, rotationSpeed, 0), Space.Self);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0,-rotationSpeed, 0), Space.Self);
        }
    }

    void CheckForCameraZoom()
    {
        if (Input.GetKey(KeyCode.W)) //zoom camera in
        {
            if (Camera.main.orthographicSize > 1)    
                Camera.main.orthographicSize -= zoomFactor; 
        }

        if (Input.GetKey(KeyCode.S)) //zoom camera in
        {
            if (Camera.main.orthographicSize < 5)
                Camera.main.orthographicSize += zoomFactor;
        }
    }
}
