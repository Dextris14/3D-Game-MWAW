using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic : MonoBehaviour
{
    Camera Camera;
    public GameObject Prefab;

    void Start()
    {
        Camera = Camera.main;
    }

    void Update()
    {
        RaycastHit Hit;
        if (Input.GetButtonDown("Fire1") && Time.timeScale == 1 && GameObject.Find("RigidBodyFPSController").GetComponent<HealthAndMana>().Mana >= 10f)
        {
            GameObject.Find("RigidBodyFPSController").GetComponent<HealthAndMana>().Mana -= 10f;
            Vector3 Destination;
            if (Physics.Raycast(Camera.transform.position, Camera.transform.forward, out Hit))
            {
                Destination = Hit.point;
            }
            else
            {
                Destination = Camera.transform.position + Camera.transform.forward * 50;
            }
            Vector3 Velocity = Destination - transform.position;
            Velocity.Normalize();
            GameObject Projectile = Instantiate(Prefab, transform.position, Quaternion.identity);
            Projectile.GetComponent<Rigidbody>().velocity = Velocity * 20;
        }
    }
}
