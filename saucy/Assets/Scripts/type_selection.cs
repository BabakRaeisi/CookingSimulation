using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class type_selection : MonoBehaviour
{
    [SerializeField]
   private  scr_restoran scr;


   private  Button pizza, burger, drinks, appetizer;


    private void Awake()
    {
        pizza = GameObject.Find("btn_pizza").GetComponent<Button>();
        drinks = GameObject.Find("btn_drinks").GetComponent<Button>();
        burger = GameObject.Find("btn_burger").GetComponent<Button>();
        appetizer = GameObject.Find("btn_apptizer").GetComponent<Button>();


        pizza.GetComponent<Button>().onClick.AddListener((() => setter("10")));
        burger.GetComponent<Button>().onClick.AddListener((() => setter("11")));
        drinks.GetComponent<Button>().onClick.AddListener((() => setter("12")));
        appetizer.GetComponent<Button>().onClick.AddListener((() => setter("16")));


    }

    public void setter(string num)
    {
        PlayerPrefs.SetString("type", num); 
    }

  
}
