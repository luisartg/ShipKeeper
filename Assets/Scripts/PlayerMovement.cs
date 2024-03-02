using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float walkSpeed = 1; //Units per second
    private Vector2 currentDirection = Vector2.zero;
    private Rigidbody2D playerRb;



    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        GetDirection();
        Walk();
        SetAimType();
    }

    private void GetDirection()
    {
        currentDirection.y = Input.GetAxis("Vertical");
        currentDirection.x = Input.GetAxis("Horizontal");
    }

    private void Walk()
    {
        Vector2 walkDir = currentDirection;
        if (walkDir.magnitude > 1)
        {
            walkDir = walkDir.normalized;
        }
        playerRb.velocity = walkDir * walkSpeed;
    }

    private void SetAimType()
    {
        if (Input.GetMouseButton(1))
        {
            AimLookAt();
        }
        else
        {
            WalkLookAt();
        }
    }

    private void AimLookAt()
    {
        float zAngle;
        Vector2 mouseDir = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseDir -= playerRb.position;
        zAngle = Mathf.Atan2(mouseDir.y, mouseDir.x) * Mathf.Rad2Deg;
        playerRb.rotation = zAngle - 90;
    }

    private void WalkLookAt()
    {
        float zAngle;
        if (currentDirection.magnitude > 0.4)
        {
            zAngle = Mathf.Atan2(currentDirection.y, currentDirection.x) * Mathf.Rad2Deg;
            zAngle -= 90; //Offset due to Z anlge at 0
            playerRb.rotation = zAngle;
        }
    }
}
