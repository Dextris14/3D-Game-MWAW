using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firebolt : MonoBehaviour
{
    public GameObject Prefab;
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
        if(collision.gameObject.tag == "Player")
        {
            GameObject.Find("RigidBodyFPSController").GetComponent<HealthAndMana>().Health -= 15f;
            Destroy(gameObject);
        }
        if(collision.gameObject.layer == 10)
        {
            GameObject Splash = Instantiate(Prefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
