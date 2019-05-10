using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMonster : MonoBehaviour
{
    float FireCD = 5f;
    public GameObject Firebolt;
    public float Health = 100f;
    GameObject Player;
    public Vector3 SpawnPoint;
    bool Alive = true;
    float RespawnTime;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("RigidBodyFPSController");
    }

    // Update is called once per frame
    void Update()
    {
        if (Health <= 0 && Alive)
        {
            GetComponent<CapsuleCollider>().enabled = false;
            transform.position = new Vector3(500, -500, 500);
            Alive = false;
            RespawnTime = 15f;
        }
        RespawnTime -= Time.deltaTime;
        if (RespawnTime <= 0 && !Alive)
        {
            transform.position = SpawnPoint;
            GameObject.FindGameObjectWithTag("Leader").transform.position = SpawnPoint;
            GetComponent<CapsuleCollider>().enabled = true;
            Health = 100f;
            Alive = true;
        }
        FireCD -= Time.deltaTime;
        if ((Player.transform.position - transform.position).magnitude < 100f && (Player.transform.position - transform.position).magnitude >= 50f)
        {
            GetComponent<Rigidbody>().velocity = (GameObject.FindGameObjectWithTag("Leader").transform.position - transform.position).normalized * 3f;
        }
        else if ((Player.transform.position - transform.position).magnitude < 50f && (Player.transform.position - transform.position).magnitude >= 10f)
        {
            GetComponent<Rigidbody>().velocity = (GameObject.FindGameObjectWithTag("Leader").transform.position - transform.position).normalized * 3f;
            if (FireCD <= 0)
            {
                GameObject Projectile = Instantiate(Firebolt, transform.position, Quaternion.identity);
                Projectile.GetComponent<Rigidbody>().velocity = (Player.transform.position - transform.position).normalized * 30;
                FireCD = 5f;
            }
        }
        else if((Player.transform.position - transform.position).magnitude < 10f)
        {

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Magic")
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
