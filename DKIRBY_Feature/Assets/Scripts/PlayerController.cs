using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public GameObject playerReference;

    public GameObject ball;

    public GameObject storagePoint;

    public float velocityMult = 10f;

    public float sensitivity = 2.0f;

    public float speed = 4f;

    private CharacterController characterController;

    private Vector3 direction;

    private Vector2 _input;

    private Vector3 mouseDelta;

    public Vector3 stratLocation;

    Vector3 storagePos;
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        //playerReference = GameObject.Find("PlayerContainer");

        storagePoint = GameObject.Find("StratBallContainer");
        storagePos = storagePoint.transform.position;

        ball.GetComponent<Rigidbody>().isKinematic = true;
    }
    private void Update()
    {

        characterController.Move(direction * speed * Time.deltaTime);

        Vector3 mousePos2D = Input.mousePosition;

        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        Vector3 mouseDelta = mousePos3D - storagePos;

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            
            GameObject.Find("StratBall(Clone)").GetComponent<StratBall>().activated = true;

            ball.GetComponent<Rigidbody>().isKinematic = false;

            ball.GetComponent<Rigidbody>().velocity = -mouseDelta * velocityMult;
        }
        ball = GameObject.Find("StratBall(Clone)");
        //------------------
        //Below is where i ended, null reference exception because once ball is setactive to false, it no longer has any input for it's location
        //fix in StratBall when setting active to false

        //stratLocation = ball.GetComponent<StratBall>().stratagemLocation;
    }

    
    

    public void Move(InputAction.CallbackContext context)
    {
        
        _input = context.ReadValue<Vector2>();
        direction = new Vector3(_input.x, 0f, _input.y);
    }
}
