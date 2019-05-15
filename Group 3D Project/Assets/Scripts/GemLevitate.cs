using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemLevitate : MonoBehaviour
{
    bool Rising = true;
    Vector3 Top;
    Vector3 Bottom;
    // Start is called before the first frame update
    void Start()
    {
        Top = new Vector3(transform.position.x, transform.position.y + .25f, transform.position.z);
        Bottom = new Vector3(transform.position.x, transform.position.y - .25f, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if(Rising)
        {
            GetComponent<Rigidbody>().velocity = Top - transform.position;
            if((Top - transform.position).magnitude < .1f)
            {
                Rising = false;
            }
        }
        else
        {
            GetComponent<Rigidbody>().velocity = Bottom - transform.position;
            if ((Bottom - transform.position).magnitude < .1f)
            {
                Rising = true;
            }
        }
        GetComponent<Transform>().Rotate(new Vector3(0, 1, 0));
    }
}
