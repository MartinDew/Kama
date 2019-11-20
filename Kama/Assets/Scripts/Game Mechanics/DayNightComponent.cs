using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class DayNightComponent : MonoBehaviour
{
    const float AMOUNT = 0.00005f;
    const float MIN = 0;
    const float MAX = 1;

    bool toNight = true;
    
    void Update()
    {
        if (toNight)
        {
            if (!(GetComponent<Light>().intensity - AMOUNT < MIN))
                GetComponent<Light>().intensity -= AMOUNT;
            else
                toNight = false;
        }
        else
        {
            if (!(GetComponent<Light>().intensity + AMOUNT > MAX))
                GetComponent<Light>().intensity += AMOUNT;
            else
                toNight = true;
        }
    }
}
