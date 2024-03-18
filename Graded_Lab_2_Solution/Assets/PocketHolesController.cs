using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PocketHolesController : MonoBehaviour
{
    public static int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other){
        if (other.name == "Ball Clube"){
            other.gameObject.transform.position = other.gameObject.GetComponent<BallClubeController>().initialPosition;
        }
        else if (other.name == "Ball8") {
            Debug.Log("Game Over! Ball 8");
            Restart();
        }
        else if (other.name.StartsWith("Ball")){
            score++;
            Debug.Log("Score is now: " + score);
            other.gameObject.SetActive(false);
        }
    }

    void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
