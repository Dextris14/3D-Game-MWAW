using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPulse : MonoBehaviour
{
    int ResetTime;
    float BaseIntensity;
    // Start is called before the first frame update
    void Start()
    {
        BaseIntensity = GetComponent<Light>().intensity;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale == 1)
        {
            GetComponent<Light>().intensity += Random.Range(-.1f, .1f);
            ResetTime += 1;
            if (ResetTime >= 30)
            {
                GetComponent<Light>().intensity = BaseIntensity;
                ResetTime = 0;
            }
        }
    }
}
