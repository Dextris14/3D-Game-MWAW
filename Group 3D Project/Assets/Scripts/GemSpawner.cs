using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemSpawner : MonoBehaviour
{
    public GameObject Gem1;
    public GameObject Gem2;
    public GameObject Gem3;
    public GameObject Gem4;
    public GameObject WinPortal;

    float WaitToSpawn = 0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        WaitToSpawn += Time.deltaTime;
        if(WaitToSpawn >= .3f && GameObject.Find("RigidBodyFPSController").GetComponent<SavingScript>().Gems[0] == true)
        {
            Gem1.SetActive(true);
        }
        if (WaitToSpawn >= .6f && GameObject.Find("RigidBodyFPSController").GetComponent<SavingScript>().Gems[1] == true)
        {
            Gem2.SetActive(true);
        }
        if (WaitToSpawn >= .9f && GameObject.Find("RigidBodyFPSController").GetComponent<SavingScript>().Gems[2] == true)
        {
            Gem3.SetActive(true);
        }
        if (WaitToSpawn >= 1.2f && GameObject.Find("RigidBodyFPSController").GetComponent<SavingScript>().Gems[3] == true)
        {
            Gem4.SetActive(true);
        }

        if(WaitToSpawn >= .1f && GameObject.Find("RigidBodyFPSController").GetComponent<SavingScript>().Gems[0] == true && GameObject.Find("RigidBodyFPSController").GetComponent<SavingScript>().Gems[1] == true && GameObject.Find("RigidBodyFPSController").GetComponent<SavingScript>().Gems[2] == true && GameObject.Find("RigidBodyFPSController").GetComponent<SavingScript>().Gems[3] == true)
        {
            WinPortal.SetActive(true);
        }
    }
}
