using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{

    [SerializeField]
    float minViewDistance = 1f;

    public float mouseSensitivity = 100f;

    [SerializeField]
    Transform playerBody;

    float xRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
         
    }

    private void look()
    {

    }
}
