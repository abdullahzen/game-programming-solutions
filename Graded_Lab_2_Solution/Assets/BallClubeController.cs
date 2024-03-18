using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallClubeController : MonoBehaviour
{
    public Vector3 initialPosition;
    public Vector3 relativeDistance;
    public bool released;
    private GameObject poolstick;
    private GameObject ballClube;
    // Start is called before the first frame update
    void Start()
    {
        poolstick = GameObject.Find("PoolStick");
        ballClube = GameObject.Find("Ball Clube");
        initialPosition = transform.position;
        released = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (released && GetComponent<Rigidbody>().velocity.magnitude <= 0.1f){
            poolstick.GetComponent<Animator>().enabled = false;
            poolstick.transform.position = ballClube.transform.position + relativeDistance;
            poolstick.transform.localPosition = ballClube.transform.localPosition + relativeDistance;
            poolstick.GetComponent<StickController>().disabled = false;
            released = false;
        }
    }
}
