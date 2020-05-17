using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class RaiseFlag : MonoBehaviour
{
    GameObject ball;

    [Tooltip("Radius from ball where flag will begin to raise")]
    [SerializeField] float raiseRadius = 1f;

    float startHeight;
    float currentHeight;

    float lastDistance;

    void Start()
    {
        ball = GameObject.FindGameObjectWithTag("Ball");
        startHeight = transform.position.y;
    }

    void Update()
    {
        CheckForRaiseFlag();
    }

    void CheckForRaiseFlag()
    {
        if(GetDistanceFromBall() < raiseRadius)
        {
            DecideRaiseHeight();
            Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, currentHeight, transform.position.z), 20f * Time.deltaTime);
            lastDistance = GetDistanceFromBall();
        }

    }

    void DecideRaiseHeight()
    {
        if (lastDistance > GetDistanceFromBall()) //raise flag if ball is getting closer
        {
            currentHeight = startHeight + GetDistanceFromBall(); //flag raises based on distance from ball
        }
        else //lower flag if ball is getter farther
        {
            currentHeight = currentHeight - GetDistanceFromBall(); //flag raises based on distance from ball
        }
        
    }

    float GetDistanceFromBall()
    {
        return Vector3.Distance(transform.position, ball.transform.position);
    }
}
