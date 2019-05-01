using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthAndMana : MonoBehaviour
{
    public float Health;
    public float Mana;
    public Slider HealthBar;
    public Slider ManaBar;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Regen");
    }

    // Update is called once per frame
    void Update()
    {
        HealthBar.value = Health;
        ManaBar.value = Mana;
        if(Health <= 0)
        {
            SceneManager.LoadScene("DeathScene");
        }
        if(Input.GetKey(KeyCode.Mouse1) && Time.timeScale == 1)
        {
            Mana += .2f;
            GetComponent<Rigidbody>().isKinematic = true;
            if(GameObject.Find("ChargeEffect").GetComponent<ParticleSystem>().isPlaying == false)
            {
                GameObject.Find("ChargeEffect").GetComponent<ParticleSystem>().Play();
            }
        }
        else
        {
            GetComponent<Rigidbody>().isKinematic = false;
            GameObject.Find("ChargeEffect").GetComponent<ParticleSystem>().Stop();
        }
    }

    IEnumerator Regen()
    {
        while(true)
        {
            Health += 1;
            Mana += 2.5f;
            if(Health > 100)
            {
                Health = 100;
            }
            if (Mana > 100)
            {
                Mana = 100;
            }
            yield return new WaitForSeconds(1f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 8)
        {
            Health -= collision.gameObject.GetComponent<DamageScript>().Damage;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.layer == 8)
        {
            Health -= collision.gameObject.GetComponent<DamageScript>().Damage;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 8)
        {
            Health -= other.gameObject.GetComponent<DamageScript>().Damage;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            Health -= other.gameObject.GetComponent<DamageScript>().Damage;
        }
    }
}
