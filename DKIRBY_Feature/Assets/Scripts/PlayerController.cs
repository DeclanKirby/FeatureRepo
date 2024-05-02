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

    Vector3 storagePos;
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        
        storagePoint = GameObject.Find("StratBallContainer");
        storagePos = storagePoint.transform.position;

        
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
        
        
    }
}
