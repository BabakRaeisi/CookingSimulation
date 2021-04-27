using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycasthit : MonoBehaviour
{
    public GameObject tomato_prefab,ani; 
    // Start is called before the first frame update
   
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) { ins_food();  }
        if (Input.GetMouseButtonDown(1)) {
            tomato_prefab.GetComponent<Animation>().Play(); 
        }
    }

    void ins_food()
    {


        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;


        if (Physics.Raycast(ray, out hit))
        {
            Instantiate(tomato_prefab , hit.point , Quaternion.identity); 

        }
    }

}

