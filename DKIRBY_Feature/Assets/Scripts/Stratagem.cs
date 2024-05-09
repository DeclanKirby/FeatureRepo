using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//Base class for stratagems

/// <summary>
/// [Kirby, Declan]
/// Last updated [05/08/2024]
/// Base class for all stratagems
/// </summary>
public class Stratagem : MonoBehaviour
{
    //keycode array for stratagem combinations
    public KeyCode[] keyCombination;

    private PlayerInput myPlayerInput;

    public GameObject stratBall;

    public Transform ballParent;
       
    protected float calldownTime;
    
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
    /// <summary>
    /// Instantiates the strat ball prefab when correct combination is input
    /// as well as setting the stratagem type
    /// </summary>
    protected  void Primed()
    {
        Debug.Log("Primed");
        isPrimed = true;
        
        GameObject ballContainer = GameObject.Find("StratBallContainer");
        Vector3 ballSpawnpoint = ballContainer.GetComponent<Rigidbody>().transform.position;
        stratBall.GetComponent<StratBall>().setStrat(this);
        Instantiate(stratBall, ballSpawnpoint, transform.rotation);

        
        GameObject pc = GameObject.Find("PlayerContainer");
        pc.GetComponent<PlayerController>().ball = stratBall;
                
    }

    /// <summary>
    /// this function gets the players location
    /// </summary>
    /// <returns>player location</returns>
    protected Vector3 getPlayerLocation()
    {
        GameObject player = GameObject.Find("PlayerContainer");
        return player.transform.position;
    }

    /// <summary>
    /// Subclass overrides this depending on the stratagem type
    /// </summary>
    /// <param name="stratBallLocation"></param>
    public virtual void Activate(Vector3 stratBallLocation)
    {
        Debug.Log("Subclass should override this method");
    }

    private void Update()
    {
        // this set finds if ctrl is pressed and you do not already have a stratagem in your hand
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

        //the method to figure out if the keys pressed are part of a combination
        if (keyPressedCtrl && (keyPressedW || keyPressedA || keyPressedS || keyPressedD)&& isElligible)
        {
            //if the keypress is correct for ANY stratagems, increase the index position
            if (Input.GetKeyDown(keyCombination[keyIndex]))
            {
                
                keyIndex++;
                
                //if the combination is complete, prime the stratball
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

}
