using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// after combination is input, instantiate this ball and set a certain property
/// </summary>
public class StratBall : MonoBehaviour
{
    //different bools
    public bool airstrike = false;
    public bool orbital = false;

    public GameObject stratBall;

    

    public bool activated = true;

    public Vector3 stratagemLocation;
    private void Awake()
    {
        
        //stratBall.SetActive(false);
        this.GetComponent<Rigidbody>().isKinematic = true;
    }

    //if left mouse is clicked, move this game Object forward
    //gravity should be on
    private void Update()
    {

        if(airstrike == false)
        {
            //transform.parent = null;
        }
        //if the combination is done set the ball to active
        if(airstrike == true)
        {
            stratBall.SetActive(true);
        }
        //if player clicks while ball is active throw strat ball
        if (Input.GetKeyDown(KeyCode.Mouse0) && airstrike == true)
        {

            //throw ball


        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Terrain")
        {

            this.GetComponent<Rigidbody>().isKinematic = false;
            //stop the balls velocity
            GetComponent<Rigidbody>().velocity = Vector3.zero;

            //stop the balls angular velocity and drag
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            GetComponent<Rigidbody>().angularDrag = 0;

            //get a reference to the strat balls location
            stratagemLocation = this.GetComponent<Rigidbody>().transform.position;
            //print(stratagemLocation);
        }
    }
}
