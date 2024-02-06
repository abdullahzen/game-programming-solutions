using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    // Adding public here makes the variable available to edit in the component section of the script in the Unity editor GUI 
    public float speed = 20f;
    Rigidbody rigidbody;
    public GameObject soccerBallObject;
    Vector3 initialPosition;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Uncommenting the Force here would make the ball start moving right when the game runs and it will keep executing this line over and over without any triggered events
        // rigidbody.AddForce(new Vector3(-1f, 0, 0) * speed, ForceMode.Force);

        if (Input.GetKey(KeyCode.UpArrow))
        {
            // Move using the Translate() method -- without using force or physics
            // transform.Translate(Vector3.left * Time.deltaTime * 20);

            // Move using the AddForce() method applied on the rigidbody of the model (soccer ball) to move it using physics
            rigidbody.AddForce(new Vector3(-1f, 0, 0) * speed, ForceMode.Force);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            // Move using the Translate() method -- without using force or physics
            // transform.Translate(Vector3.right * Time.deltaTime * 20);

            // Move using the AddForce() method applied on the rigidbody of the model (soccer ball) to move it using physics
            rigidbody.AddForce(new Vector3(1f, 0, 0) * speed, ForceMode.Force);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // Move using the Translate() method -- without using force or physics
            // transform.Translate(Vector3.back * Time.deltaTime * 20);

            // Move using the AddForce() method applied on the rigidbody of the model (soccer ball) to move it using physics
            rigidbody.AddForce(new Vector3(0, 0, -1f) * speed, ForceMode.Force);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            // Move using the Translate() method -- without using force or physics
            // transform.Translate(Vector3.forward * Time.deltaTime * 20);

            // Move using the AddForce() method applied on the rigidbody of the model (soccer ball) to move it using physics
            rigidbody.AddForce(new Vector3(0, 0, 1f) * speed, ForceMode.Force);
        }
    }

    void OnTriggerStay(Collider otherCollision){
        Debug.Log("I'm triggering");
    }

    void OnCollisionExit(Collision otherCollision)
    {
        if (otherCollision.gameObject.name == "WoodFloor"){
            Destroy(this.gameObject, 2);
            Instantiate(soccerBallObject, initialPosition, Quaternion.identity);
        }
    }
}
