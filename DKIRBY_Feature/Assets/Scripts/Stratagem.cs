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
    //variable for calldown time
    protected float calldownTime;
    //variable for speed
    protected float speed;

    protected bool keyPressedCtrl = false;
    private bool isElligible = true;


    private int keyIndex = 0;

    public bool airstrike = false;
    public bool orbital = false;
    private void Awake()
    {
        myPlayerInput = new PlayerInput();
        myPlayerInput.Enable();
    }
    protected virtual void Activate()
    {
        Debug.Log("Subclass should override this method");

        
    }

    private void Update()
    {
        //KeyCode thisKey = myPlayerInput.StratControls.WASD.ReadValue<KeyCode>();
        //Debug.Log(thisKey);
        if (Input.GetKeyDown(KeyCode.LeftControl) && isElligible == true)
        {
            //Debug.Log("Ctrl is down");
            keyPressedCtrl = true;
            
            
            
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            //Debug.Log("Ctrl is up");
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
            //Debug.Log("Key is pressed");
            if (Input.GetKeyDown(keyCombination[keyIndex]))
            {
                keyIndex++;
                //Debug.Log("Index advanced");
                if (keyIndex >= keyCombination.Length)
                {
                    this.Activate();
                    isElligible = false;
                    keyIndex = 0;

                }
            }
            else
            {
                isElligible = false;
                keyIndex = 0;
                //Debug.Log("Inelligible");
            }
        }

    }

    private void FixedUpdate()
    {
        
    }

}
