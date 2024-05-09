using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{

    

    public float mouseSensitivity = 500f;

    public float rotationSpeed = 5f;
     public Transform playerBody;

    float xRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
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
