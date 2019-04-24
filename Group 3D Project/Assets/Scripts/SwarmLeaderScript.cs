using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmLeaderScript : MonoBehaviour
{
    public GameObject Minion;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpawnMinion");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnMinion()
    {
        while(true)
        {
            if(GameObject.FindGameObjectsWithTag("Minion").Length < 10)
            {
                Instantiate(Minion, transform.position, Quaternion.identity);
            }
            yield return new WaitForSeconds(5f);
        }
    }
}
