using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

/// <summary>
/// [Kirby, Declan]
/// Last updated [05/08/2024]
/// Strat balls effects, it should be able to be thrown, and you cannot have more than one (singleton) at one time
/// </summary>
public class StratBall : MonoBehaviour
{
    private static StratBall _instance;

    //Set singleton
    public static StratBall Instance
    {
        get { return _instance; }
    }

    public Stratagem stratagem;

    public GameObject stratBall;

    private GameObject ballContainer;

    public bool activated = true;

    public Vector3 stratagemLocation;

    public Vector3 velocityMult = new Vector3(0f, 0f, 10f);

    public bool stratagemActive = false;    
   
    private void Awake()
    {
        //singleton, if there is already a stratagem ball, destroy this current one that has just been instantiated
        if(_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        
        this.GetComponent<Rigidbody>().isKinematic = true;
        ballContainer = GameObject.Find("StratBallContainer");

        //sets the transform parent of this strat ball
        this.gameObject.transform.parent = ballContainer.transform;
    }

    /// <summary>
    /// Sets the stratagem this ball contains based on the input combination
    /// </summary>
    /// <param name="strat"></param>
    public void setStrat(Stratagem strat)
    {        
        stratagem = strat;       
    }

    private void Update()
    {
        //if pressed, this ball get gets thrown
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            
            //detach from transform parent
            transform.parent = null;

            this.GetComponent<Rigidbody>().isKinematic = false;

            //finds player
            GameObject playerContainer = GameObject.Find("PlayerContainer");
           
            //set rotation to forward
            transform.rotation = playerContainer.transform.rotation;
            this.GetComponent<Rigidbody>().velocity = transform.forward * 20f;
        }
    }

    /// <summary>
    /// Sets behavior after colliding with the ground
    /// </summary>
    /// <param name="collision"></param>
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

            //activate the stratagem and pass in this vector3
            stratagem.Activate(stratagemLocation);

            //destroy this object
            Destroy(this.gameObject);
        }
    }
}
