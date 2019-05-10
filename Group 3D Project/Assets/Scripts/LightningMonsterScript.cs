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
    public Vector3 SpawnPoint;
    bool Alive = true;
    float RespawnTime;

    void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
        Player = GameObject.Find("RigidBodyFPSController");
        StartCoroutine("Relocate");
    }

    void Update()
    {
        if (Health <= 0 && Alive)
        {
            GetComponent<NavMeshAgent>().enabled = false;
            GetComponent<CapsuleCollider>().enabled = false;
            GetComponent<NavMeshAgent>().speed = 25f;
            transform.position = new Vector3(500, -500, 500);
            Alive = false;
            RespawnTime = 15f;
        }
        RespawnTime -= Time.deltaTime;
        if (RespawnTime <= 0 && !Alive)
        {
            transform.position = SpawnPoint;
            GetComponent<NavMeshAgent>().enabled = true;
            GetComponent<CapsuleCollider>().enabled = true;
            Health = 50f;
            Alive = true;
        }
    }

    IEnumerator Relocate()
    {
        while(true)
        {
            Vector3 Direction = Player.transform.position - transform.position;
            if(Alive)
            {
                if (Direction.magnitude <= ChaseDistance)
                {
                    Agent.destination = Player.transform.position + new Vector3(Random.Range(-2.5f, 2.5f), 0, Random.Range(-2.5f, 2.5f));
                }
                else
                {
                    Agent.destination = transform.position + new Vector3(Random.Range(-30f, 30f), 0, Random.Range(-30f, 30f));
                }
            }
            yield return new WaitForSeconds(.75f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Magic")
        {
            Health -= collision.gameObject.GetComponent<ProjectileScript>().Damage;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Magic")
        {
            Health -= other.gameObject.GetComponent<ProjectileScript>().Damage;
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
