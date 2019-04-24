using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningSpawn : MonoBehaviour
{
    public int Piece;
    public GameObject Piece1;
    public GameObject Piece2;
    float SpawnDelay = 1.6f;
    // Start is called before the first frame update
    void Start()
    {
        if(Piece == 0)
        {
            Instantiate(Piece1, transform.position + new Vector3(0, 300, 0), Quaternion.identity);
            Instantiate(Piece1, transform.position + new Vector3(0, 300, 0), Quaternion.identity);
            Instantiate(Piece1, transform.position + new Vector3(0, 300, 0), Quaternion.identity);
        }
        if(Piece == 1)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, -200, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Piece == 0)
        {
            SpawnDelay -= Time.deltaTime;
            if (SpawnDelay <= 0)
            {
                Instantiate(Piece2, transform.position, Quaternion.identity);
            }
        }
        Destroy(gameObject, 2f);
    }
}
