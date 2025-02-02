using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 5.0f;
    public float runSpeed = 10.0f;
    public float jumpForce = 10.0f;
    public float gravity = 20.0f;
    public float sensitivity = 2.0f;

    private CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;
    public Transform mainCameraTransform;

    private bool isRunning;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        mainCameraTransform = Camera.main.transform;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up * mouseX * sensitivity);
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 forward = mainCameraTransform.forward;
        forward.y = 0; 
        forward.Normalize();

        Vector3 right = mainCameraTransform.right;
        right.y = 0;
        right.Normalize();

        Vector3 move = horizontal * right + vertical * forward;
        moveDirection.x = move.x * walkSpeed;
        moveDirection.z = move.z * walkSpeed;


        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isRunning = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isRunning = false;
        }

        ChangeSpeed();

        if (controller.isGrounded && Input.GetButton("Jump"))
        {
            moveDirection.y = jumpForce;
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }


    private void ChangeSpeed()
    {
        if (isRunning)
        {
            walkSpeed = runSpeed;
        }
        else
        {
            walkSpeed = 5f;
        }
    }
}
