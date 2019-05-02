using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZapScript : MonoBehaviour
{
    public Vector3 Destination;
    float Timer = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        if (Timer >= .1f)
        {
            transform.position = Destination;
        }
    }
}