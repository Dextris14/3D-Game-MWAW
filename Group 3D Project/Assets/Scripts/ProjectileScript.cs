using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public GameObject[] ExplodeEffect = new GameObject[5];
    float Countdown = 5;
    public float Damage;
    public int Type = 1;

    void Start()
    {

    }

    void Update()
    {
        Countdown -= Time.deltaTime;
        if (Countdown <= 0 && Type != 3)
        {
            Explode();
        }
    }

    void Explode()
    {
        if(Type == 1)
        {
            GameObject Effect = Instantiate(ExplodeEffect[0], transform.position, Quaternion.identity);
            Destroy(Effect, 4.9f);
            Destroy(gameObject);
        }
        if (Type == 2)
        {
            GameObject Effect = Instantiate(ExplodeEffect[1], transform.position, Quaternion.identity);
            Destroy(Effect, 1f);
            GetComponent<SphereCollider>().isTrigger = true;
            GetComponent<Rigidbody>().isKinematic = true;
            Damage = .3f;
            transform.localScale *= 5;
            Destroy(gameObject, 1f);
        }
        if (Type == 3)
        {
            GameObject Effect = Instantiate(ExplodeEffect[2], transform.position, Quaternion.identity);
            Destroy(Effect, 4.9f);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Explode();
    }
}