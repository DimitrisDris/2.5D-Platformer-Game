using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 2f; // Movement speed
    public float distance = 3f; // Distance to move in each direction
    private Vector3 initialPosition;
    private bool movingRight = true;

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        if (movingRight)
        {

            if (transform.position.x >= initialPosition.x + distance)
            {
                transform.Rotate(Vector3.up, 180);
                transform.Rotate(Vector3.right, 180);
                movingRight = false;
            }
        }
        else
        {
            if (transform.position.x <= initialPosition.x)
            {
                transform.Rotate(Vector3.up, 180);
                transform.Rotate(Vector3.right, 180);
                movingRight = true;
            }
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Playerr"))
        {
            //Debug.Log("YPOFERO");
        }
    }


}
