using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CueController : MonoBehaviour
{
    public GameObject cueBall;
    public int speed = 25;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HitBall()
    {
        cueBall.GetComponent<Rigidbody>().AddForce(Vector3.forward * Time.deltaTime * 70 * speed, ForceMode.Impulse);

    }
}
