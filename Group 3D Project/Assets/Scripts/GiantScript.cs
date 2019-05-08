using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantScript : MonoBehaviour
{
    public float Health = 200f;
    public GameObject StepDust;
    bool Ready = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Step");
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Step()
    {
        while(Ready)
        {
            GameObject Dust = Instantiate(StepDust, transform.position + (transform.forward * 10), Quaternion.Euler(-90, 0, 0));
            yield return new WaitForSeconds(2.95f);
        }
        Ready = true;
        yield return new WaitForSeconds(.2f);
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
