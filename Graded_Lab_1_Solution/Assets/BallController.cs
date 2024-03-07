using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    Rigidbody rigidbody;
    int expectedFrameRatePerSecond = 90;
    Renderer currentRenderer;
    Vector3 initialPosition;
    Quaternion initialRotation;
    public float speed;
    public GameObject bowlingBallPrefab;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        currentRenderer = rigidbody.GetComponent<Renderer>();
        initialPosition = transform.position;
        initialRotation = transform.rotation;
        speed = 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            speed++;
        }
        if (Input.GetKeyUp(KeyCode.Space)) {
            rigidbody.AddForce(Vector3.forward * speed * Time.deltaTime * expectedFrameRatePerSecond, ForceMode.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            rigidbody.mass++;
            currentRenderer.material.SetColor("_Color", GetColorBasedOnMass(Mathf.FloorToInt(rigidbody.mass)));

        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            rigidbody.mass--;
            currentRenderer.material.SetColor("_Color", GetColorBasedOnMass(Mathf.FloorToInt(rigidbody.mass)));
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * 50 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * 50 * Time.deltaTime);
        }
    }

    private void OnCollisionExit(Collision otherCollision)
    {
        if (otherCollision.gameObject.name == "WoodFloor")
        {
            Destroy(gameObject, 1);
            Instantiate(bowlingBallPrefab, initialPosition, initialRotation, transform.parent);
        }
    }

    private Color GetColorBasedOnMass(int mass)
    {
        Color selectedColor = Color.blue;
        if (mass >= 1 && mass <= 15)
        {
            selectedColor = Color.yellow;
        }
        else if (mass >= 16 && mass <= 25)
        {
            selectedColor = Color.red;
        }
        else if (mass > 25)
        {
            selectedColor = Color.black;
        }
        return selectedColor;
    }
}
