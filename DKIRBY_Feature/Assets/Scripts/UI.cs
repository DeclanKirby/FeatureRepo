using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
/// <summary>
/// [Kirby, Declan]
/// Last updated [05/08/2024]
/// Displays UI
/// </summary>
public class UI : MonoBehaviour
{
    public GameObject controlDisplay;
    public GameObject stratPanel;
    public GameObject ctrlText;
  
    // set active false, all that should be hidded when starting
    void Start()
    {
       
        controlDisplay.SetActive(false);
        stratPanel.SetActive(false);
        ctrlText.SetActive(true);
        
    }
    // Update is called once per frame
    void Update()
    {
        ToggleControls();
    }

    //Toggles Controls UI
    private void ToggleControls()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {                        
            controlDisplay.SetActive(!controlDisplay.activeSelf);
            stratPanel.SetActive(!stratPanel.activeSelf);
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            controlDisplay.SetActive(!controlDisplay.activeSelf);
            stratPanel.SetActive(!stratPanel.activeSelf);
        }

    }

    
}
