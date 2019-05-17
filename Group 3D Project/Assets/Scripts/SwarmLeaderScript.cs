using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SwarmLeaderScript : MonoBehaviour
{
    public GameObject Minion;
    public float Health = 100f;
    public Vector3 SpawnPoint;
    bool Alive = true;
    float RespawnTime;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpawnMinion");
        SpawnPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Health <= 0 && Alive)
        {
            GetComponent<NavMeshAgent>().enabled = false;
            GetComponent<NavScript>().enabled = false;
            GetComponent<BoxCollider>().enabled = false;
            transform.position = new Vector3(500, -500, 500);
            Alive = false;
            RespawnTime = 15f;
        }
        RespawnTime -= Time.deltaTime;
        if(RespawnTime <= 0 && !Alive)
        {
            transform.position = SpawnPoint;
            GetComponent<NavMeshAgent>().enabled = true;
            GetComponent<NavScript>().enabled = true;
            GetComponent<BoxCollider>().enabled = true;
            Health = 100f;
            Alive = true;
        }
    }

    IEnumerator SpawnMinion()
    {
        while(true)
        {
            if(GameObject.FindGameObjectsWithTag("Minion").Length < 10 && Alive)
            {
                Instantiate(Minion, transform.position, Quaternion.identity);
            }
            yield return new WaitForSeconds(5f);
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
        if(other.gameObject.tag == "SlimePool")
        {
            GetComponent<NavMeshAgent>().speed = .875f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "SlimePool")
        {
            GetComponent<NavMeshAgent>().speed = 1.75f;
        }
    }
}
