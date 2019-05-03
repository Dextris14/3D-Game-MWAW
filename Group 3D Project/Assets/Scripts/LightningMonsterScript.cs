using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class LightningMonsterScript : MonoBehaviour
{
    NavMeshAgent Agent;
    GameObject Player;
    public float ChaseDistance = 10;
    private Vector3 Home;
    public float Health = 100f;

    void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
        Player = GameObject.Find("RigidBodyFPSController");
        StartCoroutine("Relocate");
    }

    void Update()
    {

    }

    IEnumerator Relocate()
    {
        while(true)
        {
            Vector3 Direction = Player.transform.position - transform.position;
            if (Direction.magnitude <= ChaseDistance)
            {
                Agent.destination = Player.transform.position + new Vector3(Random.Range(-2.5f, 2.5f), 0, Random.Range(-2.5f, 2.5f));
            }
            else
            {
                Agent.destination = transform.position + new Vector3(Random.Range(-30f, 30f), 0, Random.Range(-30f, 30f));
            }
            yield return new WaitForSeconds(.75f);
        }
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

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Magic")
        {
            Health -= other.gameObject.GetComponent<ProjectileScript>().Damage;
            if (Health <= 0)
            {
                Destroy(gameObject);
            }
        }
        if (other.gameObject.tag == "SlimePool")
        {
            GetComponent<NavMeshAgent>().speed = 2.5f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "SlimePool")
        {
            GetComponent<NavMeshAgent>().speed = 25f;
        }
    }
}
