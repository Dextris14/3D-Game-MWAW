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
        while(true)
        {
            Vector3 Direction = Player.transform.position - transform.position;
            if (Direction.magnitude <= ChaseDistance)
            {
                Agent.destination = Player.transform.position + new Vector3(Random.Range(-5f, 5f), 0, Random.Range(-5f, 5f));
            }
            else
            {
                Agent.destination = Home + new Vector3(Random.Range(-10f, 10f), 0, Random.Range(-10f, 10f));
            }
            yield return new WaitForSeconds(5f);
        }
    }
}
