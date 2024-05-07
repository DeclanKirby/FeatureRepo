using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
   

    public GameObject ball;

    public GameObject storagePoint;

    public float velocityMult = 10f;

    public float sensitivity = 2.0f;

    public float speed = 4f;

    private CharacterController characterController;

    private Vector3 direction;

    private Vector2 _input;

    public Vector3 stratLocation;

    public float mouseSensitivity = 500f;

    public float rotationSpeed = 5f;

    public Transform playerBody;

    float xRotation = 0f;

    Vector3 storagePos;
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        
        storagePoint = GameObject.Find("StratBallContainer");
        storagePos = storagePoint.transform.position;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;


    }
    private void Update()
    {
        Look();
        if (!Input.GetKey(KeyCode.LeftControl))
        {
            characterController.Move(direction * speed * Time.deltaTime);
        }
        
        
        
    }

    
    

    public void Move(InputAction.CallbackContext context)
    {
        
            _input = context.ReadValue<Vector2>();
            direction = new Vector3(_input.x, 0f, _input.y);
        
        
    }

    public void Look()
    {
        // Get input for rotation
        float rotateHorizontal = Input.GetAxis("Mouse X");
        float rotateVertical = Input.GetAxis("Mouse Y");

        // Calculate rotation angles
        float rotationX = rotateVertical * rotationSpeed;
        float rotationY = rotateHorizontal * rotationSpeed;

        rotationX = Mathf.Clamp(xRotation, -90f, 90f);
        // Apply rotation to player controller
        transform.Rotate(Vector3.up, rotationY, Space.World); // Rotate around the world up axis
        transform.Rotate(Vector3.left, rotationX); // Rotate around the local left axis

        // Apply rotation to camera

        playerBody.Rotate(Vector3.up, rotationY, Space.World); // Rotate around the world up axis
        playerBody.Rotate(Vector3.left, rotationX); // Rotate around the local left axis
    }
}
