using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public GameObject playerReference;

    

    public float sensitivity = 2.0f;

    public float speed = 4f;

    private CharacterController characterController;

    private Vector3 direction;

    private Vector2 _input;
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        //playerReference = GameObject.Find("PlayerContainer");
    }
    private void Update()
    {

        characterController.Move(direction * speed * Time.deltaTime);
        
    }

    

    public void Move(InputAction.CallbackContext context)
    {
        
        _input = context.ReadValue<Vector2>();
        direction = new Vector3(_input.x, 0f, _input.y);
    }
}
