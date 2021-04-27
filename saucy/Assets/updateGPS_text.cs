using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class updateGPS_text : MonoBehaviour
{
    public Text coordinates;
    public Button getloc_btn;
    private cart_script cart;

    private void Start()
    {
        cart = GameObject.Find("Canvas").GetComponent<cart_script>(); 

    }

    
    private void Update()
    {
        coordinates.text =  gps_babak.Instance.lat.ToString() + "," + gps_babak.Instance.lon.ToString();
        if (gps_babak.Instance.lat == 0f)
        {
            getloc_btn.interactable = false;
        }
        else { getloc_btn.interactable = true;  }
      //  message.text = gps_babak.Instance.error; 
    }

    public void get_loco()
    {

        cart.location = coordinates.text; 

    }
}
