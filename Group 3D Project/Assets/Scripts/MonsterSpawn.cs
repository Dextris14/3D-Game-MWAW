using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawn : MonoBehaviour
{
    public bool Lightning = false;
    public bool Slime = false;
    public bool Giant = false;
    public bool Imp = false;
    public GameObject[] Prefabs = new GameObject[4];
    float[] RespawnTimes = new float[4];

    // Start is called before the first frame update
    void Start()
    {
        RespawnTimes[0] = 15f;
        RespawnTimes[1] = 15f;
        RespawnTimes[2] = 15f;
        RespawnTimes[3] = 15f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Lightning && GameObject.FindGameObjectWithTag("LightningMonster") == null)
        {
            RespawnTimes[0] -= Time.deltaTime;
            if(RespawnTimes[0] <= 0)
            {
                Instantiate(Prefabs[0], transform.position, Quaternion.identity);
                RespawnTimes[0] = 15f;
            }
        }

        if (Slime && GameObject.FindGameObjectWithTag("Slime") == null)
        {
            RespawnTimes[1] -= Time.deltaTime;
            if (RespawnTimes[1] <= 0)
            {
                Instantiate(Prefabs[1], transform.position, Quaternion.identity);
                RespawnTimes[1] = 15f;
            }
        }

        if (Giant && GameObject.Find("Giant") == null)
        {
            RespawnTimes[2] -= Time.deltaTime;
            if (RespawnTimes[2] <= 0)
            {
                Instantiate(Prefabs[2], transform.position, Quaternion.identity);
                RespawnTimes[2] = 15f;
            }
        }

        if (Imp && GameObject.FindGameObjectWithTag("Imp") == null)
        {
            RespawnTimes[3] -= Time.deltaTime;
            if (RespawnTimes[3] <= 0)
            {
                Instantiate(Prefabs[3], transform.position, Quaternion.identity);
                Instantiate(Prefabs[4], transform.position + new Vector3(0, 18, 0), Quaternion.identity);
                RespawnTimes[3] = 15f;
            }
        }
    }
}
