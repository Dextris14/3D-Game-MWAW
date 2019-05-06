using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic : MonoBehaviour
{
    Camera Camera;
    public GameObject[] Prefab = new GameObject[6];
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
        else if (Input.GetButtonDown("Fire1") && Time.timeScale == 1 && GameObject.Find("RigidBodyFPSController").GetComponent<HealthAndMana>().Mana >= 20f && !Input.GetKey(KeyCode.Mouse1) && SelectedMagic == 3)
        {
            GameObject.Find("RigidBodyFPSController").GetComponent<HealthAndMana>().Mana -= 20f;
            if (Physics.Raycast(Camera.transform.position, Camera.transform.forward, out Hit, 50f))
            {
                if(Hit.transform.gameObject.tag == "Lightning Monster")
                {
                    Hit.transform.gameObject.GetComponent<LightningMonsterScript>().Health -= 20f;
                    if(Hit.transform.gameObject.GetComponent<LightningMonsterScript>().Health <= 0)
                    {
                        Destroy(Hit.transform.gameObject);
                    }
                }
                else if(Hit.transform.gameObject.tag == "Slime")
                {
                    Hit.transform.gameObject.GetComponent<SwarmLeaderScript>().Health -= 20f;
                    if (Hit.transform.gameObject.GetComponent<SwarmLeaderScript>().Health <= 0)
                    {
                        Destroy(Hit.transform.gameObject);
                    }
                }
                else if(Hit.transform.gameObject.tag == "Minion")
                {
                    Hit.transform.gameObject.GetComponent<MinionScript>().Health -= 20f;
                    if (Hit.transform.gameObject.GetComponent<MinionScript>().Health <= 0)
                    {
                        Destroy(Hit.transform.gameObject);
                    }
                }
                else if (Hit.transform.gameObject.tag == "Imp")
                {
                    Hit.transform.gameObject.GetComponent<FireMonster>().Health -= 20f;
                    if (Hit.transform.gameObject.GetComponent<FireMonster>().Health <= 0)
                    {
                        Destroy(Hit.transform.gameObject);
                    }
                }
                GameObject Zap = Instantiate(Prefab[5], transform.position - (Camera.transform.forward * ((Hit.point - transform.position).magnitude * .11f)), Quaternion.identity);
                Zap.GetComponent<ZapScript>().Destination = Hit.point;
            }
            else
            {
                GameObject Zap = Instantiate(Prefab[5], transform.position, Quaternion.identity);
                Zap.GetComponent<ZapScript>().Destination = transform.position + (Camera.transform.forward * 50f);
            }
        }
        else if (Input.GetButtonDown("Fire1") && Time.timeScale == 1 && GameObject.Find("RigidBodyFPSController").GetComponent<HealthAndMana>().Mana >= 20f && !Input.GetKey(KeyCode.Mouse1) && SelectedMagic == 4)
        {
            GameObject.Find("RigidBodyFPSController").GetComponent<HealthAndMana>().Mana -= 20f;
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
            GameObject Projectile = Instantiate(Prefab[2], transform.position, Quaternion.identity);
            Projectile.GetComponent<Rigidbody>().velocity = Velocity * 20;
        }
        else if (Input.GetButtonDown("Fire1") && Time.timeScale == 1 && GameObject.Find("RigidBodyFPSController").GetComponent<HealthAndMana>().Mana >= 20f && !Input.GetKey(KeyCode.Mouse1) && SelectedMagic == 5)
        {
            GameObject.Find("RigidBodyFPSController").GetComponent<HealthAndMana>().Mana -= 20f;
            Vector3 Destination;
            Destination = Camera.transform.position + Camera.transform.forward * 50;
            for(int i = 0; i < 5; i++)
            {
                Vector3 Velocity = (Destination - transform.position) + new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), Random.Range(-5f, 5f));
                Velocity.Normalize();
                GameObject Projectile = Instantiate(Prefab[3], transform.position, Quaternion.identity);
                Projectile.transform.rotation = GameObject.Find("SpikeEmpty").transform.rotation;
                Projectile.GetComponent<Rigidbody>().velocity = Velocity * 30f;
            }
        }
    }
}
