﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public GameObject[] ExplodeEffect = new GameObject[5];
    float Countdown = 7.5f;
    public float Damage;
    public int Type = 1;
    bool BurningOut = false;
    float BurnOutTime = 5f;

    void Start()
    {

    }

    void Update()
    {
        if(BurningOut)
        {
            BurnOutTime -= Time.deltaTime;
            if(BurnOutTime <= 3)
            {
                GetComponent<SphereCollider>().enabled = false;
                GetComponent<MeshRenderer>().enabled = false;
            }
            if(BurnOutTime <= 0)
            {
                Destroy(gameObject);
            }
        }
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
            GetComponent<SphereCollider>().enabled = false;
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;
            Destroy(gameObject, 4f);
        }
        if (Type == 2)
        {
            GetComponent<SphereCollider>().isTrigger = true;
            GetComponent<Rigidbody>().isKinematic = true;
            Damage = .3f;
            BurningOut = true;
        }
        if (Type == 3)
        {
            if(transform.position.y <= 1)
            {
                Instantiate(ExplodeEffect[1], new Vector3(transform.position.x, 0, transform.position.z), Quaternion.identity);
            }
            Destroy(gameObject);
        }
        if (Type == 4)
        {
            GameObject Effect = Instantiate(ExplodeEffect[3], transform.position, Quaternion.identity);
            GetComponent<BoxCollider>().enabled = false;
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;
            Destroy(gameObject, 5f);
        }
    }

    void BurnOut()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        Explode();
        if(Type == 1)
        {
            GameObject Effect = Instantiate(ExplodeEffect[0], transform.position, Quaternion.identity);
            Destroy(Effect, 4.9f);
        }
        if (Type == 2)
        {
            GameObject Effect = Instantiate(ExplodeEffect[1], transform.position, Quaternion.identity);
            Destroy(Effect, 1f);
            transform.localScale *= 5;
        }
        if (Type == 3)
        {
            GameObject Effect = Instantiate(ExplodeEffect[2], transform.position, Quaternion.identity);
            Destroy(Effect, 4.9f);
        }
    }
}