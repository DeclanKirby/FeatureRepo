using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// [Kirby, Declan]
/// Last updated [05/08/2024]
/// Controller for player, used new input system to move the player
/// </summary>
public class PlayerController : MonoBehaviour
{
    private CharacterController characterController;

    public GameObject ball;

    public GameObject storagePoint;

    public Transform playerBody;

    public float velocityMult = 10f;    

    private float speed = 4f;    

    private Vector3 direction;

    private Vector2 _input;

    public Vector3 stratLocation;

    private Vector3 _mouseInput;
           
    public Vector3 storagePos;
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
        
        if (!Input.GetKey(KeyCode.LeftControl))
        {
            characterController.Move(direction * speed * Time.deltaTime);
        }
        
        
        
    }

    
    

    public void Move(InputAction.CallbackContext context)
    {
        
        _input = context.ReadValue<Vector2>();
        direction = new Vector3(_input.x, 0f, _input.y);
        direction = direction.normalized;
        direction = playerBody.transform.rotation * direction; 
        
        
    }
    public void View(InputAction.CallbackContext context)
    {
        _mouseInput = context.ReadValue<Vector3>();
        Vector3 viewing = new Vector3(_mouseInput.x,0f, _mouseInput.y);
        viewing = viewing.normalized;
        viewing = playerBody.transform.rotation * viewing;
    }
    
}
