using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinsController : MonoBehaviour
{
    public int PinsTumbledCount { get { return _pinsTumbledCount; } set { _pinsTumbledCount = value; } }
    int _pinsTumbledCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Count is " + _pinsTumbledCount);
        if (_pinsTumbledCount == 10)
        {
            ChildPinController[] pins = gameObject.GetComponentsInChildren<ChildPinController>();
            foreach (ChildPinController pin in pins)
            {
                pin.Reset();
            }
            _pinsTumbledCount = 0;
        }
    }
}
