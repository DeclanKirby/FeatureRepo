using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

/// <summary>
/// after combination is input, instantiate this ball and set a certain property
/// </summary>
public class StratBall : MonoBehaviour
{
    private static StratBall _instance;

    public static StratBall Instance
    {
        get { return _instance; }
    }


    

    public GameObject stratBall;

    private GameObject ballContainer;

    public bool activated = true;

    public Vector3 stratagemLocation;

    public bool stratagemActive = false;

    

    public Vector3 velocityMult = new Vector3(0f,0f,10f);

    

    public Stratagem stratagem;
    private void Awake()
    {
        
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
        this.gameObject.transform.parent = ballContainer.transform;
    }

    public void setStrat(Stratagem strat)
    {
        Debug.Log("SettingStrat");
        stratagem = strat;
        Debug.Log(stratagem);
    }

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            

            transform.parent = null;

            this.GetComponent<Rigidbody>().isKinematic = false;

            GameObject playerContainer = GameObject.Find("PlayerContainer");
           
            //set rotation to forward
            transform.rotation = playerContainer.transform.rotation;
            this.GetComponent<Rigidbody>().velocity = transform.forward * 20f;
        }
    }

    public void Shoot(InputAction.CallbackContext context)
    {
        

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

            
            

            //start stratagem activation
            //Debug.Log(stratagem);
            stratagem.Activate(stratagemLocation);
            Destroy(this.gameObject);
        }
    }
}
