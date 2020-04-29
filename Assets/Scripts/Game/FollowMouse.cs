using UnityEngine;

public class FollowMouse : MonoBehaviour
{
   [SerializeField] float groundOffset = .75f;

    [SerializeField] float rayLength = 100f;

    void Start()
    {
        UpdateObjectPosition();
    }

    void Update()
    {
        //if not paused
        UpdateObjectPosition();
    }

    private void UpdateObjectPosition()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //raycast from mouse position

        Physics.Raycast(ray, out hit);

        transform.position = new Vector3(hit.point.x, hit.point.y + groundOffset, hit.point.z);   
    }

    /*
    private void OnDrawGizmos()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //raycast from mouse position

        Physics.Raycast(ray, out hit, rayLength);
        Debug.DrawRay(ray.origin, ray.direction * rayLength, Color.blue);
    }
    */

   
}
