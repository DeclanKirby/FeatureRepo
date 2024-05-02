using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//Base class for stratagems

public class Stratagem : MonoBehaviour
{
    //protected KeyCode key1, key2, key3, key4;
    public KeyCode[] keyCombination;

    private PlayerInput myPlayerInput;

    public GameObject stratBall;

    public Transform ballParent;

    

    //variable for calldown time
    protected float calldownTime;
    //variable for speed
    protected float speed;

    protected bool keyPressedCtrl = false;
    private bool isElligible = true;


    private int keyIndex = 0;

    public bool isPrimed = false;
    
    private void Awake()
    {
        myPlayerInput = new PlayerInput();
        myPlayerInput.Enable();
    }
    protected  void Primed()
    {
        Debug.Log("Primed");
        isPrimed = true;
        
        GameObject ballContainer = GameObject.Find("StratBallContainer");
        Vector3 ballSpawnpoint = ballContainer.GetComponent<Rigidbody>().transform.position;
       
        Instantiate(stratBall, ballSpawnpoint, transform.rotation);

        stratBall.GetComponent<StratBall>().setStrat(this);
        GameObject pc = GameObject.Find("PlayerContainer");
        pc.GetComponent<PlayerController>().ball = stratBall;
        
        


    }

    protected Vector3 getPlayerLocation()
    {
        GameObject player = GameObject.Find("PlayerContainer");
        return player.transform.position;
    }

    public virtual void Activate(Vector3 stratBallLocation)
    {
        Debug.Log("Subclass should override this method");
    }

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.LeftControl) && isElligible == true)
        {
            
            keyPressedCtrl = true;
            
            
            
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            
            keyPressedCtrl = false;
            isElligible = true;
            keyIndex = 0;
        }
        bool keyPressedW = Input.GetKeyDown(KeyCode.W);
        bool keyPressedA = Input.GetKeyDown(KeyCode.A);
        bool keyPressedS = Input.GetKeyDown(KeyCode.S);
        bool keyPressedD = Input.GetKeyDown(KeyCode.D);

        //XOR goes down the line and checks if only one is true
        if (keyPressedCtrl && (keyPressedW || keyPressedA || keyPressedS || keyPressedD)&& isElligible)
        {
            
            if (Input.GetKeyDown(keyCombination[keyIndex]))
            {
                
                keyIndex++;
                
                if (keyIndex >= keyCombination.Length)
                {
                    
                    this.Primed();
                    isElligible = false;
                    keyIndex = 0;

                }
            }
            else
            {
                isElligible = false;
                keyIndex = 0;
                
            }
        }

    }

    private void FixedUpdate()
    {
        
    }

}
