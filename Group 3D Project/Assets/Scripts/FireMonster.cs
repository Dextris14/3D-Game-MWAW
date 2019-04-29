using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMonster : MonoBehaviour
{
    float FireCD = 5f;
    public GameObject Firebolt;
    public float Health = 100f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        FireCD -= Time.deltaTime;
        if((GameObject.Find("RigidBodyFPSController").transform.position - transform.position).magnitude < 100f && (GameObject.Find("RigidBodyFPSController").transform.position - transform.position).magnitude >= 50f)
        {
            GetComponent<Rigidbody>().velocity = ((GameObject.Find("RigidBodyFPSController").transform.position + new Vector3(Random.Range(0f, 5f), 27, Random.Range(0f, 5f)) - transform.position)).normalized * 3f;
        }
        else if ((GameObject.Find("RigidBodyFPSController").transform.position - transform.position).magnitude < 50f)
        {
            GetComponent<Rigidbody>().velocity = ((GameObject.Find("RigidBodyFPSController").transform.position + new Vector3(Random.Range(0f, 5f), 7, Random.Range(0f, 5f)) - transform.position)).normalized * 3f;
            if (FireCD <= 0)
            {
                Instantiate(Firebolt, transform.position, Quaternion.identity);
                FireCD = 5f;
            }
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
