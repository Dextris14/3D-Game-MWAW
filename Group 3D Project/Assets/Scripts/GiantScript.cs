using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GiantScript : MonoBehaviour
{
    public float Health = 200f;
    public GameObject StepDust;
    bool Ready = false;
    public Vector3 SpawnPoint;
    bool Alive = true;
    float RespawnTime;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Step");
    }

    // Update is called once per frame
    void Update()
    {
        if (Health <= 0 && Alive)
        {
            GetComponent<NavMeshAgent>().enabled = false;
            GetComponent<NavScript>().enabled = false;
            GetComponent<CapsuleCollider>().enabled = false;
            transform.position = new Vector3(500, -500, 500);
            Alive = false;
            RespawnTime = 15f;
        }
        RespawnTime -= Time.deltaTime;
        if (RespawnTime <= 0 && !Alive)
        {
            transform.position = SpawnPoint;
            GetComponent<NavMeshAgent>().enabled = true;
            GetComponent<NavScript>().enabled = true;
            GetComponent<CapsuleCollider>().enabled = true;
            Health = 500f;
            Alive = true;
        }
    }

    IEnumerator Step()
    {
        while(Ready)
        {
            GameObject Dust = Instantiate(StepDust, transform.position + (transform.forward * 10), Quaternion.Euler(-90, 0, 0));
            yield return new WaitForSeconds(2.95f);
        }
        Ready = true;
        yield return new WaitForSeconds(.2f);
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
    }
}
