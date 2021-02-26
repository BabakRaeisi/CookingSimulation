using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepPlate : MonoBehaviour
{
    public static KeepPlate instance = null; 
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }
}
