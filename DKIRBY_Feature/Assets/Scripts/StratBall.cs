using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// after combination is input, instantiate this ball and set a certain property
/// </summary>
public class StratBall : MonoBehaviour
{
    //different bools
    

    public GameObject stratBall;

    private GameObject ballContainer;

    public bool activated = true;

    public Vector3 stratagemLocation;

    public bool stratagemActive = false;

    public float velocityMult = 10f;

    public Stratagem stratagem;
    private void Awake()
    {
        
        //stratBall.SetActive(false);
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
            Vector3 mousePos2D = Input.mousePosition;

            mousePos2D.z = -Camera.main.transform.position.z;
            Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

            Vector3 mouseDelta = mousePos3D - this.transform.position;

            transform.parent = null;
            this.GetComponent<Rigidbody>().isKinematic = false;
            this.GetComponent<Rigidbody>().velocity = -mouseDelta * velocityMult;
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

            
            

            //start stratagem activation
            Debug.Log(stratagem);
            stratagem.Activate(stratagemLocation);
            Destroy(this.gameObject);
        }
    }
}
