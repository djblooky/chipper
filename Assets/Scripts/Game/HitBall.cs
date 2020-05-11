using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ScoreManager))]
[RequireComponent(typeof(AudioSource))]
public class HitBall : MonoBehaviour
{
    private Rigidbody ballRB;
    private Collider clubCollider;
    private ScoreManager scoreManager;
    private MeshRenderer clubMeshRenderer;

    [SerializeField] GameObject ball;

    [SerializeField] private float baseForce = 100f;
    [SerializeField] private float hitForce;
    public Vector3 hitDirection;

    private AudioSource audioSource;
    [SerializeField] AudioClip puttSound;

    [HideInInspector] public bool wasHit = false;

    public float HitForce { 
        get { return hitForce; }
        set { hitForce = value; }
    }

    private void Start()
    {   
        SetUpComponents();
        SetClubTransparency(0.5f);
        clubCollider.enabled = false;
        hitForce = baseForce;
    }

    void SetUpComponents()
    {
        scoreManager = GetComponent<ScoreManager>();
        ballRB = ball.GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        clubCollider = GetComponent<Collider>();
        clubMeshRenderer = GetComponentInChildren<MeshRenderer>();
    }

    private void Update()
    {
        CheckForMouseUpOrDown();
    }

    void CheckForMouseUpOrDown()
    {
        if (Input.GetMouseButton(0))
        {
            clubCollider.enabled = true;
            SetClubTransparency(1f);
        }
        else 
        {
            hitForce = baseForce;
            wasHit = false;
            clubCollider.enabled = false;
            SetClubTransparency(0.5f);
        }
    }

    void SetClubTransparency(float value)
    {
        foreach(Material material in clubMeshRenderer.materials)
        {
            material.color = new Color(material.color.r, material.color.g, material.color.b, value);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball") && !wasHit) //if ball wasnt already hit this swing
        {
            PlayPuttSound();
            ballRB.AddForce(hitDirection * hitForce, ForceMode.Impulse); 
            scoreManager.IncrementStrokes();
            wasHit = true;
        }
    }

    void PlayPuttSound()
    {
        audioSource.PlayOneShot(puttSound, 0.7F);
    }
}
