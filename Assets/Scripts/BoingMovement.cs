using System;
using System.Collections;
using System.Text.RegularExpressions;
using UnityEngine;

public class BoingMovement : MonoBehaviour
{
    public float movementSpeed = 5f;
    public Animator animator;

    public bool needRot = false;

    private string dir = "right";

    private Rigidbody rb;

    void Start()
    {
        animator = GetComponent<Animator>();
        transform.rotation = Quaternion.identity;
    }

    void Update()
    {
        // Check if Boing is moving right
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (dir == "left")
            {
                dir = "right";
                animator.SetTrigger("Ori");
                WaitAnimation();
                animator.SetTrigger("Rotation");
            }
            else
            {
                dir = "right";
                MoveBoingForward();
            }

        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (dir == "right")
            {
                dir = "left";
                animator.SetTrigger("Ori");
                WaitAnimation();
                animator.SetTrigger("Rotation");
            }
            else
            {
                dir = "left";
                MoveBoingBackward();
            }

        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            Jump();
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            Fall();
        }
    }

    void MoveBoingForward()
    {
        animator.SetTrigger("ForwardMovement");
        Vector3 currentPosition = transform.position;
        currentPosition.x -= movementSpeed * Time.deltaTime;
        transform.position = currentPosition;
    }

    void MoveBoingBackward()
    {
        Vector3 currentPosition = transform.position;
        currentPosition.x += movementSpeed * Time.deltaTime;
        transform.position = currentPosition;
    }

    void Jump()
    {
        animator.SetTrigger("Jump");
        Vector3 currentPosition = transform.position;
        currentPosition.y += movementSpeed * Time.deltaTime;
        transform.position = currentPosition;
    }

    void Fall()
    {
        animator.SetTrigger("Landed");
        Vector3 currentPosition = transform.position;
        currentPosition.y -= movementSpeed * Time.deltaTime;
        transform.position = currentPosition;
    }


    IEnumerator WaitAnimation()
    {
        yield return new WaitForSeconds(animator.GetCurrentAnimatorClipInfo(0).Length);
    }
}