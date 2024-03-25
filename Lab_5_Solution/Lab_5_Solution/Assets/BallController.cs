using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallController : MonoBehaviour
{
    Rigidbody rigidbody;
    int expectedFrameRatePerSecond = 90;
    Renderer currentRenderer;
    Vector3 initialPosition;
    Quaternion initialRotation;
    AudioSource audioSource;
    public float speed;
    public GameObject bowlingBallPrefab;
    public AudioClip bowlingStrike;
    public AudioClip rollingClip;
    public AudioClip hitBallClip;
    private Animator parentAnimator;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.isKinematic = true;
        currentRenderer = rigidbody.GetComponent<Renderer>();
        initialPosition = transform.position;
        initialRotation = transform.rotation;
        speed = 2.0f;
        parentAnimator = transform.parent.gameObject.GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            parentAnimator.Play("pull_back");
        }
        if (Input.GetKey(KeyCode.Space))
        {
            speed++;
        }
        if (Input.GetKeyUp(KeyCode.Space)) {
            parentAnimator.Play("throw");
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
            audioSource.Stop();
            Destroy(gameObject, 1);
            Instantiate(bowlingBallPrefab, initialPosition, initialRotation, transform.parent);
        }
    }

    private void OnCollisionStay(Collision otherCollision)
    {
        if (otherCollision.gameObject.name == "WoodFloor")
        {
            if (!audioSource.isPlaying)
            {
                audioSource.clip = rollingClip;
                audioSource.Play(); // plays the rolling sound
            }
        }
    }

    private void OnCollisionEnter(Collision otherCollision)
    {
        if (otherCollision.gameObject.name.StartsWith("Pin")){
            audioSource.clip = bowlingStrike;
            audioSource.Play(); // plays the bowlingstrike
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

    public void ThrowBall()
    {
        rigidbody.isKinematic = false;
        rigidbody.AddForce(new Vector3(0.0f, -0.3f, 1.0f) * speed * Time.deltaTime * expectedFrameRatePerSecond, ForceMode.Impulse);
    }
}
