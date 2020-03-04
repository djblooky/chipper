using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBall : MonoBehaviour
{
    private Rigidbody ballRB;
    private ScoreManager scoreManager;

    [SerializeField] GameObject ball;

    [SerializeField] float hitForce = 5f;
    public Vector3 hitDirection;

    private void Start()
    {
        scoreManager = GetComponent<ScoreManager>();
        ballRB = ball.GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            ballRB.AddForce(hitDirection * hitForce, ForceMode.Impulse); //TODO: change force based on hit strength
            scoreManager.IncrementStrokes();
        }
    }
}
