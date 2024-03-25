using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ChildPinController : MonoBehaviour
{
    bool tumbled;
    public Vector3 initialPosition;
    public Quaternion initialRotation;
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        initialRotation = transform.rotation;
        transform.localScale = Vector3.one;
        tumbled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 0 && !tumbled)
        {
            tumbled = true;
            transform.parent.GetComponent<PinsController>().PinsTumbledCount++;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "WoodFloor" && !tumbled)
        {
            tumbled = true;
            transform.parent.gameObject.GetComponent<PinsController>().PinsTumbledCount++;
        }
    }

    public void Reset()
    {
        Destroy(gameObject);
        GameObject newObject = Instantiate(gameObject, initialPosition, initialRotation, transform.parent);
        newObject.GetComponent<ChildPinController>().enabled = true;
        newObject.GetComponent<ChildPinController>().tumbled = false;
    }
}
