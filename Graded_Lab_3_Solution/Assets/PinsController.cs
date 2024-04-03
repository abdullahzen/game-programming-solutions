using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PinsController : MonoBehaviour
{
    public int PinsTumbledCount { get { return _pinsTumbledCount; } set { _pinsTumbledCount = value; } }
    int _pinsTumbledCount = 0;
    public TMP_Text scoreText;
    public GameObject VictoryPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Count is " + _pinsTumbledCount);
        scoreText.text = "Score: " + _pinsTumbledCount;
        if (_pinsTumbledCount == 10)
        {
            VictoryPanel.SetActive(true);
            Invoke("DisablePanel", 3.0f);
            ChildPinController[] pins = gameObject.GetComponentsInChildren<ChildPinController>();
            foreach (ChildPinController pin in pins)
            {
                pin.Reset();
            }
            _pinsTumbledCount = 0;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale > 0)
            {
                Time.timeScale = 0;
                SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);
            }
        }
    }

    void DisablePanel()
    {
        VictoryPanel?.SetActive(false);
    }
}
