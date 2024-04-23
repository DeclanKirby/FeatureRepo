using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject playerReference;
    private void Awake()
    {
        playerReference = GameObject.Find("PlayerContainer");
    }
}
