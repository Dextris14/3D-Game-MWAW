using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NavScript : MonoBehaviour
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
    }

    void Update()
    {
        Vector3 Direction = Player.transform.position - transform.position;
        if (Direction.magnitude <= ChaseDistance)
        {
            Agent.destination = Player.transform.position;
        }
        else
        {
            Agent.destination = Home;
        }
    }
}
