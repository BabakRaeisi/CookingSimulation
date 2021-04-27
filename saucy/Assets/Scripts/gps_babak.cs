using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gps_babak : MonoBehaviour
{
    public static gps_babak Instance { get; set;  }
    public float lat;
    public float lon;
    public string error; 

    private void Start()
    {
        Instance = this;
       // DontDestroyOnLoad(gameObject); 
        StartCoroutine(getlocationservices());
    }

    private IEnumerator getlocationservices()
    {
        if (!Input.location.isEnabledByUser)
        {
            error = "GPS is not enabled";
            yield break;
        }


        Input.location.Start();
        int maxWait = 20;

        while (Input.location.status == LocationServiceStatus.Initializing && maxWait >0 )
        {
            yield return new WaitForSeconds(1);
            maxWait--; 

        }


        if (maxWait <=0)
        {
            error = "timed out";
            yield break; 
        }

        if (Input.location.status ==LocationServiceStatus.Failed )
        {
            error = "unable to get location";
            yield break; 
        }
        lat= Input.location.lastData.latitude; 
        lon = Input.location.lastData.longitude;
    }
}
