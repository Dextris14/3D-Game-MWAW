using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMonster : MonoBehaviour
{
    float SwoopCD = 10f;
    bool Swooped = false;
    float SwoopRecover = 3f;
    public float Health = 100f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        SwoopCD -= Time.deltaTime;
        if((GameObject.Find("RigidBodyFPSController").transform.position - transform.position).magnitude < 9001f)
        {
            if(SwoopCD <= 0 && (GameObject.Find("RigidBodyFPSController").transform.position - transform.position).magnitude < 25f)
            {
                if(!Swooped)
                {
                    GetComponent<Rigidbody>().AddForce((GameObject.Find("RigidBodyFPSController").transform.position - transform.position).normalized * 30, ForceMode.VelocityChange);
                    Swooped = true;
                }
                else
                {
                    GetComponent<Rigidbody>().AddForce(new Vector3(0, SwoopRecover, 0));
                    SwoopRecover -= Time.deltaTime;
                    if(SwoopRecover <= 0)
                    {
                        SwoopCD = 10f;
                        Swooped = false;
                        SwoopRecover = 3f;
                    }
                }
            }
            else
            {

                GetComponent<Rigidbody>().velocity = ((GameObject.Find("RigidBodyFPSController").transform.position + new Vector3(Random.Range(0f, 5f), 7, Random.Range(0f, 5f)) - transform.position)).normalized * 3f;
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
