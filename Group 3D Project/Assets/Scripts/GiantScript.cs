using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantScript : MonoBehaviour
{
    public float Health = 200f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
        if (collision.gameObject.tag == "Explosion")
        {
            Health -= 10;
            if (Health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Magic")
        {
            Health -= other.gameObject.GetComponent<ProjectileScript>().Damage;
            if (Health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
