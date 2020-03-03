using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowardsBall : MonoBehaviour
{
    private GameObject ball;
    private Rigidbody clubRB;

    private float speed = 10f;

    void Start()
    {
        clubRB = GetComponent<Rigidbody>();
        GetBallFromScene();
        UpdateRotation();
    }

    void GetBallFromScene()
    {
        ball = GameObject.FindGameObjectWithTag("Ball");
    }

    void Update()
    {
        UpdateRotation();
    }

    void UpdateRotation()
    {
        // Determine which direction to rotate towards
        Vector3 targetDirection = ball.transform.position - transform.position;

        // The step size is equal to speed times frame time.
        float singleStep = speed * Time.deltaTime;

        // Rotate the forward vector towards the target direction by one step
        Vector3 newDirection = Vector3.RotateTowards(Vector3.forward, targetDirection, singleStep, 0.0f);

        // Draw a ray pointing at our target in
        Debug.DrawRay(transform.position, newDirection, Color.red);

       // newDirection.y = 0; // keep only the horizontal direction

        // Calculate a rotation a step closer to the target and applies rotation to this object
        transform.rotation = Quaternion.LookRotation(newDirection);

        
    }
}
