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
                Agent.destination = Player.transform.position + new Vector3(Random.Range(-5f, 5f), 0, Random.Range(-5f, 5f));
            }
            else
            {
                Agent.destination = transform.position + new Vector3(Random.Range(-20f, 20f), 0, Random.Range(-20f, 20f));
            }
            yield return new WaitForSeconds(3.5f);
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
    }
}
