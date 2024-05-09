using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// [Kirby, Declan]
/// Last updated [05/08/2024]
/// Handles orbital stratagem interpolation and interactions with ground collision
/// </summary>
public class OrbitalAnimation : MonoBehaviour
{
    public Vector3 targetLocation;

    private Vector3 startingPos;

    private Vector3 minScale = new Vector3(1f, 1f, 1f);

    private Vector3 maxScale = new Vector3(15f, 15f, 15f);

    public Vector3 p01;

    private float duration = 0.5f;

    private float startTime;

    private float timeDuration = 1;

    private bool spawned = true;

    private bool moving = false;

    private float timeStart;

    public bool explosion = false;

    // Start is called before the first frame update
    void Start()
    {
        startingPos = this.transform.position;
        startTime = Time.time;

    }


    /// <summary>
    /// when this is spawned, move this using standard linear interpolation
    /// </summary>


    private void Update()
    {
        if (spawned)
        {
            spawned = false;

            moving = true;

            timeStart = Time.time;
        }

        if (moving)
        {
            float u = (Time.time - timeStart) / timeDuration;

            if (u >= 1)
            {
                u = 1;

                moving = false;
            }

            //using the standard linear interpolation formula
            p01 = (1 - u) * startingPos + u * targetLocation;

            this.transform.position = p01;
        }
        if (explosion)
        {
            ChangeSize();
        }
    }
    /// <summary>
    /// This happens when this objects collider collides with the ground
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Terrain")
        {
            Collider thisCollider = GetComponent<Collider>();

            //set the collider to false
            thisCollider.enabled = false;
            StartCoroutine(Called());

        }
    }

    /// <summary>
    /// Set all velocity to zero then do the explosion using ChangeSize' interpolation
    /// </summary>
    /// <returns></returns>
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
    /// <summary>
    /// using the PingPong, grow and shrink this game object by the parameters given
    /// </summary>
    private void ChangeSize()
    {
        float t = Mathf.PingPong(Time.time - startTime, duration) / duration;

        Vector3 growScale = Vector3.Lerp(minScale, maxScale, t);

        transform.localScale = growScale;



    }
}
