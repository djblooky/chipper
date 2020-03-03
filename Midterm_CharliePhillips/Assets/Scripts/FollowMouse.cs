using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    Rigidbody ballRB;
    [SerializeField] GameObject ball;

    void Start()
    {
        ballRB = GetComponent<Rigidbody>();
        UpdateObjectPosition();
    }

    void Update()
    {
        UpdateObjectPosition();
    }

    private void UpdateObjectPosition()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //raycast from mouse position

        Physics.Raycast(ray, out hit);

        transform.position = new Vector3(hit.point.x, hit.point.y + .75f, hit.point.z); 
    }

    private void OnDrawGizmos()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //raycast from mouse position

        Physics.Raycast(ray, out hit);
        Debug.DrawRay(ray.origin, ray.direction, Color.red);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            ballRB.AddForce(Vector3.forward * 10, ForceMode.Impulse);
        }
    }
}
