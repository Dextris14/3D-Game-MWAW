using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagingParticles : MonoBehaviour
{
    public List<ParticleCollisionEvent> Smacks = new List<ParticleCollisionEvent>();
    private void OnParticleCollision(GameObject other)
    {
        if (other.tag == "Player")
        {
            GameObject.Find("RigidBodyFPSController").GetComponent<HealthAndMana>().Health -= 1;
        }
    }
}
