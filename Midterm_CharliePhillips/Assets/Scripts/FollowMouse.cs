using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    private float fixedYPosition;
    Vector3 startpos;

    void Start()
    {
        fixedYPosition = transform.position.y;
        UpdateObjectPosition();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateObjectPosition();
    }

    private void UpdateObjectPosition()
    {
        Debug.Log($"mouse X: {Input.mousePosition.x} mouse Y: {Input.mousePosition.y} mouse Z: {Input.mousePosition.z}");
        Vector3 position = new Vector3(Input.mousePosition.x, fixedYPosition, Input.mousePosition.y);

        transform.position = Camera.main.ScreenToWorldPoint(position) + new Vector3(10,10,12);
    }
}
