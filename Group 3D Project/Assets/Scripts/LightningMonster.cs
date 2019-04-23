using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class LightningMonster : MonoBehaviour
{
    NavMeshAgent Agent;
    GameObject Player;
    public float ChaseDistance = 10;
    private Vector3 Home;

    void Start()
    {
        Home = transform.position;
        Agent = GetComponent<NavMeshAgent>();
        Player = GameObject.Find("RigidBodyFPSController");
        StartCoroutine("Relocate");
    }

    void Update()
    {

    }

    IEnumerator Relocate()
    {
        Vector3 Distance = Player.transform.position - transform.position;
        if (Distance.magnitude <= ChaseDistance)
        {
            Agent.destination = Player.transform.position + new Vector3(Random.Range(-10f, 10f), 0, Random.Range(-10f, 10f));
        }
        else
        {
            Agent.destination = Home + new Vector3(Random.Range(-10f, 10f), 0, Random.Range(-10f, 10f));
        }
        yield return new WaitForSeconds(5f);
    }
}