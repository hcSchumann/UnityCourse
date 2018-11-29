using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public Rigidbody playerRigidbody;
    public Animator playerAnimator;
    public int health = 5;
    float speed = 0.5f;
    float angularSpeed = 120;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        float rotationAngle = h * angularSpeed * Time.deltaTime;
        transform.Rotate(0, rotationAngle, 0);

        playerAnimator.SetFloat("rotation", h);


        var currentSpeed = v * speed;
        Vector3 movementDistance = transform.forward * currentSpeed * Time.deltaTime;
        playerRigidbody.MovePosition(playerRigidbody.position + movementDistance);

        playerAnimator.SetFloat("speed", v);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerAnimator.SetTrigger("attack");
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            playerAnimator.SetTrigger("dodgeLeft");
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            playerAnimator.SetTrigger("dodgeRight");
        }
    }
}
