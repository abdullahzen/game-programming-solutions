using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    private ParticleSystem ps;
    List<ParticleSystem.Particle> enter;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        enter = new List<ParticleSystem.Particle>();
        player = GameObject.Find("Player");
        ps.trigger.AddCollider(player.GetComponent<CapsuleCollider>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnParticleTrigger()
    {
        int numEnter = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);

        for (int i = 0; i < numEnter; i++)
        {
            player.GetComponent<PlayerController>().health--;
        }
    }
}
