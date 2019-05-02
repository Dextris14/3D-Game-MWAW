using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmLeaderScript : MonoBehaviour
{
    public GameObject Minion;
    public float Health = 100f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpawnMinion");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnMinion()
    {
        while(true)
        {
            if(GameObject.FindGameObjectsWithTag("Minion").Length < 10)
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
