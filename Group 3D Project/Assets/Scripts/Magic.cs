using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic : MonoBehaviour
{
    Camera Camera;
    public GameObject[] Prefab = new GameObject[5];
    public int SelectedMagic = 1;

    void Start()
    {
        Camera = Camera.main;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectedMagic = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SelectedMagic = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SelectedMagic = 3;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SelectedMagic = 4;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            SelectedMagic = 5;
        }
        RaycastHit Hit;
        if (Input.GetButtonDown("Fire1") && Time.timeScale == 1 && GameObject.Find("RigidBodyFPSController").GetComponent<HealthAndMana>().Mana >= 10f && !Input.GetKey(KeyCode.Mouse1) && SelectedMagic == 1)
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
            GameObject Projectile = Instantiate(Prefab[0], transform.position, Quaternion.identity);
            Projectile.GetComponent<Rigidbody>().velocity = Velocity * 20;
        }
        else if (Input.GetButtonDown("Fire1") && Time.timeScale == 1 && GameObject.Find("RigidBodyFPSController").GetComponent<HealthAndMana>().Mana >= 15f && !Input.GetKey(KeyCode.Mouse1) && SelectedMagic == 2)
        {
            GameObject.Find("RigidBodyFPSController").GetComponent<HealthAndMana>().Mana -= 15f;
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
            GameObject Projectile = Instantiate(Prefab[1], transform.position, Quaternion.identity);
            Projectile.GetComponent<Rigidbody>().velocity = Velocity * 20;
        }
    }
}
