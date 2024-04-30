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
    

    private void Awake()
    {
        stratBall.SetActive(false);
        
    }

    //if left mouse is clicked, move this game Object forward
    //gravity should be on
    private void Update()
    {
        //if the combination is done set the ball to active
        if(airstrike == true)
        {
            stratBall.SetActive(true);
        }
        //if player clicks while ball is active throw strat ball
        if (Input.GetKeyDown(KeyCode.Mouse0) && airstrike == true)
        {

            //throw ball

            //this.transform.position += Vector3.forward;

        }
    }
}
