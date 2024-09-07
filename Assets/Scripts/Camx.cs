using UnityEngine;

public class Camx : MonoBehaviour
{
    public Transform target; // The player's transform

    public float smoothSpeed = 0.05f; // The speed at which the camera follows the player
    public Vector3 offset; // The offset between the player and the camera

    void FixedUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = new Vector3(target.position.x + offset.x, target.position.y + offset.y, transform.position.z);
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
