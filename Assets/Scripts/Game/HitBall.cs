using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ScoreManager))]
[RequireComponent(typeof(AudioSource))]
public class HitBall : MonoBehaviour
{
    private Rigidbody ballRB;
    private ScoreManager scoreManager;

    [SerializeField] GameObject ball;

    [SerializeField] float hitForce = 10f;
    public Vector3 hitDirection;

    private AudioSource audioSource;
    [SerializeField] AudioClip puttSound;

    private void Start()
    {
        scoreManager = GetComponent<ScoreManager>();
        ballRB = ball.GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            PlayPuttSound();
            ballRB.AddForce(hitDirection * hitForce, ForceMode.Impulse); //TODO: change force based on hit strength
            scoreManager.IncrementStrokes();
        }
    }

    void PlayPuttSound()
    {
        audioSource.PlayOneShot(puttSound, 0.7F);
    }
}
