using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StickController : MonoBehaviour
{
    public bool disabled = false;
    private float force;
    private Animator animator;
    private Rigidbody rigidbody;
    private float maxForce = 400;
    private GameObject ballClubeObject;
    private BallClubeController ballClubeController;
    // Start is called before the first frame update
    void Start()
    {
        force = 0f;
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        ballClubeObject = GameObject.Find("Ball Clube");
        ballClubeController = ballClubeObject.GetComponent<BallClubeController>();
        ballClubeController.relativeDistance = transform.position - ballClubeController.initialPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (!disabled){
            if (Input.GetKeyDown(KeyCode.Space)){
            animator.enabled = true;
            animator.Play("poolstick_pull_back");
            }
            if (Input.GetKey(KeyCode.Space)){
                if (force < maxForce){
                    Debug.Log("Force is now at " + force);
                    force++;
                }
            }
            if (Input.GetKeyUp(KeyCode.Space)){
                animator.Play("poolstick_push_forward");
            } 
        }
        if (Input.GetKeyDown(KeyCode.Escape)){
            Restart(); 
        }
    }

    void ReleaseStick(){
        ballClubeObject.GetComponent<Rigidbody>().AddForce(new Vector3(-1f, 0f, 0f) * force * 3, ForceMode.Impulse);
        ballClubeController.released = true;
        disabled = true;
    }

    void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
