using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

using UnityEngine.EventSystems;
using System;
public class add_ingredients : MonoBehaviour
{

    private scr_restoran n_scr_Restoran;

    [SerializeField]
    GameObject foodv2,pizza_non;
    public bool b_desrtroy = false;
    public void Awake()
    {
        n_scr_Restoran = GameObject.Find("content").GetComponent<scr_restoran>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0)&& b_desrtroy==false)
        {
            ScreenMouseRay(n_scr_Restoran.str_obj_v2_name);
        }
        if (Input.GetMouseButtonDown(0) && b_desrtroy == true) { remove_me();  }
    }
    decimal tottal_cost = 0;
   

    public void ScreenMouseRay(string v2)
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10;

        Vector3 screenPos = Camera.main.ScreenToWorldPoint(mousePos);

        RaycastHit2D hit = Physics2D.Raycast(screenPos, Vector2.zero);



        if (hit && v2 == "102131")
        {
            //  { "102030" toast, "102131 bugget", "152632", "112333",#"152434","102835 burger",#"152435", "152435", #"152435" };

            pizza_non.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("sprite/sprite_v2/spr_v2_" + v2);
            pizza_non.GetComponent<SpriteRenderer>().sortingOrder = 1;


            Instantiate(pizza_non, screenPos + new Vector3(0, 0, -0.2f), Quaternion.identity);

            tottal_cost += n_scr_Restoran.dec_cost;

            Debug.Log(tottal_cost);
        }
        else if (hit && v2.Substring(0, 2) != "10")
        {
            //  { "102030" toast, "102131 bugget", "152632", "112333",#"152434","102835 burger",#"152435", "152435", #"152435" };

            foodv2.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("sprite/sprite_v2/spr_v2_" + v2);
            foodv2.GetComponent<SpriteRenderer>().sortingOrder = 1;


            Instantiate(foodv2, screenPos + new Vector3(0, 0, -0.2f), Quaternion.identity);
        }
        else  {

            Debug.Log("nothing is picked");

        }
            
        
    }

    public void Activate_delete()
    {
        if (b_desrtroy == false)
        {
            b_desrtroy = true;
        }
        else { b_desrtroy = false;  }

    }

 public  void remove_me()
   {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10;

        Vector3 screenPos = Camera.main.ScreenToWorldPoint(mousePos);

        RaycastHit2D hit = Physics2D.Raycast(screenPos, Vector2.zero);


        try
        {
            if (hit.collider.tag == "food_tag" && b_desrtroy == true)
            {

                Destroy(hit.transform.gameObject);

            }
        }
        catch {

            Debug.Log("nin khalooo!!!!"); 
        }

    }




}






