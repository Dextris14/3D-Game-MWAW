using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public GameObject ExplodeEffect;
    float Countdown = 5;
    public float Damage;

    void Start()
    {

    }

    void Update()
    {
        Countdown -= Time.deltaTime;
        if (Countdown <= 0)
        {
            Explode();
        }
    }

    void Explode()
    {
        GameObject Effect = Instantiate(ExplodeEffect, transform.position, Quaternion.identity);
        Destroy(Effect, 4.9f);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Explode();
    }
}