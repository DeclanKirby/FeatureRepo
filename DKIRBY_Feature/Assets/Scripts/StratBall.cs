using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// after combination is input, instantiate this ball and set a certain property
/// </summary>
public class StratBall : MonoBehaviour
{
    //different bools
    public bool locationSet = false;

    public GameObject stratBall;

    private GameObject ballContainer;

    public bool activated = true;

    public Vector3 stratagemLocation;
    private void Awake()
    {
        
        //stratBall.SetActive(false);
        this.GetComponent<Rigidbody>().isKinematic = true;
        ballContainer = GameObject.Find("StratBallContainer");
        this.gameObject.transform.parent = ballContainer.transform;
    }

    //if left mouse is clicked, move this game Object forward
    //gravity should be on
    private void Update()
    {
        if (locationSet)
        {
            this.transform.position = stratagemLocation;
            //ADD COROUTINE FOR COOLDOWN ON STRAT BALL
            
        }
       
        //if the combination is done set the ball to active
        
        
            
        
        //if player clicks while ball is active throw strat ball
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            //throw ball


        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Terrain")
        {

            
            //stop the balls velocity
            GetComponent<Rigidbody>().velocity = Vector3.zero;

            //stop the balls angular velocity and drag
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            GetComponent<Rigidbody>().angularDrag = 0;

            //get a reference to the strat balls location
            stratagemLocation = this.GetComponent<Rigidbody>().transform.position;

            //set location to stratagemLocation
            locationSet = true;
            //print(stratagemLocation);
        }
    }
}
