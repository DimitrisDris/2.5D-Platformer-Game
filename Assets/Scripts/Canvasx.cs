using UnityEngine;

public class Canvasx : MonoBehaviour
{
    public Transform playerTransform; // Reference to the player's Transform

    void Update()
    {
        // Check if playerTransform is assigned
        if (playerTransform != null)
        {
            // Set the position of the canvas to match the player's position
            transform.position = playerTransform.position;
        }
    }
}
