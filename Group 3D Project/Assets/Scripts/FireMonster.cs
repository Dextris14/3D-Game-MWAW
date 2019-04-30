using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMonster : MonoBehaviour
{
    float FireCD = 5f;
    public GameObject Firebolt;
    public float Health = 100f;
    public GameObject Prefab;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        FireCD -= Time.deltaTime;
        if ((GameObject.Find("RigidBodyFPSController").transform.position - transform.position).magnitude < 100f && (GameObject.Find("RigidBodyFPSController").transform.position - transform.position).magnitude >= 50f)
        {
            GetComponent<Rigidbody>().velocity = (GameObject.Find("FireLeader").transform.position - transform.position).normalized * 3f;
        }
        else if ((GameObject.Find("RigidBodyFPSController").transform.position - transform.position).magnitude < 50f && (GameObject.Find("RigidBodyFPSController").transform.position - transform.position).magnitude >= 10f)
        {
            GetComponent<Rigidbody>().velocity = (GameObject.Find("FireLeader").transform.position - transform.position).normalized * 3f;
            if (FireCD <= 0)
            {
                GameObject Projectile = Instantiate(Firebolt, transform.position, Quaternion.identity);
                Projectile.GetComponent<Rigidbody>().velocity = (GameObject.Find("RigidBodyFPSController").transform.position - transform.position).normalized * 30;
                FireCD = 5f;
            }
        }
        else if((GameObject.Find("RigidBodyFPSController").transform.position - transform.position).magnitude < 10f)
        {

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Magic")
        {
            Health -= collision.gameObject.GetComponent<ProjectileScript>().Damage;
            if(Health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
