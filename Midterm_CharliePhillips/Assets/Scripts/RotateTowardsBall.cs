using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowardsBall : MonoBehaviour
{
    private GameObject ball;
    private HitBall clubHit;

    [SerializeField] float speed = 10f;
    [SerializeField] float hitRadius = 0f;

    void Start()
    {
        clubHit = GetComponent<HitBall>();
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
        //Debug.Log(Vector3.Distance(transform.position, ball.transform.position));
        if (!InHitRadius() && !Input.GetMouseButton(0)) //user is holding left click and ball is in radius
        {
            // Determine which direction to rotate towards
            Vector3 targetDirection = ball.transform.position - transform.position;

            // Draw a ray pointing at our target in
            Debug.DrawRay(transform.position, targetDirection, Color.red);

            targetDirection.y = 0; // keep only the horizontal direction

            Quaternion offset = Quaternion.Euler(0, 90, 0);
            Quaternion lookRotation = Quaternion.LookRotation(targetDirection);

            // Calculate a rotation a step closer to the target and applies rotation to this object 
            transform.rotation = lookRotation * offset;

            //set club hit direction
            clubHit.hitDirection = targetDirection;
        }       
    }

    /// <summary>
    /// Returns true if ball and club are within a certain hitRadius
    /// </summary>
    /// <returns>True or False</returns>
    bool InHitRadius()
    {
        if (Vector3.Distance(transform.position, ball.transform.position) < hitRadius)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
}
