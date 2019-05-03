using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MinionScript : MonoBehaviour
{
    public float Health = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Magic")
        {
            Health -= collision.gameObject.GetComponent<ProjectileScript>().Damage;
            if (Health <= 0)
            {
                Destroy(gameObject);
            }
        }
        if (collision.gameObject.tag == "Explosion")
        {
            Health -= 10;
            if (Health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Magic")
        {
            Health -= other.gameObject.GetComponent<ProjectileScript>().Damage;
            if (Health <= 0)
            {
                Destroy(gameObject);
            }
        }
        if(other.gameObject.tag == "SlimePool")
        {
            GetComponent<NavMeshAgent>().speed = 1.75f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "SlimePool")
        {
            GetComponent<NavMeshAgent>().speed = 3.5f;
        }
    }
}
