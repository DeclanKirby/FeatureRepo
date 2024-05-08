using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitalAnimation : MonoBehaviour
{
    public Vector3 targetLocation;

    private Vector3 startingPos;

    private Vector3 minScale = new Vector3(1f, 1f, 1f);
    private Vector3 maxScale = new Vector3(15f, 15f, 15f);
    private float duration = 0.5f;

    private float startTime;

    // Start is called before the first frame update
    void Start()
    {
        startingPos = this.transform.position;
        startTime = Time.time;

    }

    public float timeDuration = 1f;
    public Vector3 p01;

    public bool spawned = true;
    public bool moving = false;
    public float timeStart;

    public bool explosion = false;
    /// <summary>
    /// Move the thing, allow the user to check the checkToCalculate box in the inspector
    /// to start our movement
    /// </summary>


    private void Update()
    {
        if (spawned)
        {
            spawned = false;

            //set the moving bool to true, and that will start the movement
            moving = true;
            timeStart = Time.time;
        }
        //now check to see if we need to move
        if (moving)
        {
            float u = (Time.time - timeStart) / timeDuration;

            if (u >= 1)
            {
                u = 1;

                moving = false;
            }

            //use the standard linear interpolation formula
            p01 = (1 - u) * startingPos + u * targetLocation;

            this.transform.position = p01;
        }
        if (explosion)
        {
            ChangeSize();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Terrain")
        {
            Debug.Log("KABOOOM");
            Collider thisCollider = GetComponent<Collider>();
            thisCollider.enabled = false;
            StartCoroutine(Called());

        }
    }

    private void ChangeSize()
    {
        float t = Mathf.PingPong(Time.time - startTime, duration) / duration;

        Vector3 growScale = Vector3.Lerp(minScale, maxScale, t);

        transform.localScale = growScale;



    }
    IEnumerator Called()
    {
        this.GetComponent<Rigidbody>().isKinematic = false;
        //stop the balls velocity
        GetComponent<Rigidbody>().velocity = Vector3.zero;

        //stop the balls angular velocity and drag
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        GetComponent<Rigidbody>().angularDrag = 0;

        explosion = true;


        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }
}
