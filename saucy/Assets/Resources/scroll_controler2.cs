using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEditor.UIElements;

public class scroll_controler2 : MonoBehaviour
{
    public int a, i, j, ii;
    public float scrol_pos = 0.0f;
    public GameObject my_scrol,light2;
    public float[] pos;

    public void Awake()
    {
  //     GameObject.Find("light_2_for_selected_key_btn_type_food_0").GetComponent<Light>().enabled = false;

        
       // GameObject.Find("light_2_for_selected_key_btn_type_food_0").GetComponent<Light>().enabled = false;



        GameObject.Find("btn_food_version_0").GetComponent<Light>().enabled = false;
        GameObject.Find("btn_food_version_1").GetComponent<Light>().enabled = false;
        GameObject.Find("btn_food_version_2").GetComponent<Light>().enabled = false;

        GameObject.Find("btn_food_version_3").GetComponent<Light>().enabled = false;
        GameObject.Find("btn_food_version_4").GetComponent<Light>().enabled = false;

        GameObject.Find("btn_food_version_5").GetComponent<Light>().enabled = false;
        GameObject.Find("btn_food_version_6").GetComponent<Light>().enabled = false;
        GameObject.Find("btn_food_version_7").GetComponent<Light>().enabled = false;

        GameObject.Find("btn_food_version_8").GetComponent<Light>().enabled = false;
        GameObject.Find("btn_food_version_9").GetComponent<Light>().enabled = false;
        GameObject.Find("btn_food_version_10").GetComponent<Light>().enabled = false;
       




        b_is_key = new bool[12] ;
        my_scrol = GameObject.Find("Scrollbar Vertical");
      
        light2 = GameObject.Find("Viewport"); 
        // light2.GetComponent<UnityEngine.UI.Image >().color = UnityEngine.Color.blue;

        // scrol_pos = my_scrol.GetComponent<Scrollbar>().size = 0.4f;

     
  
    }
    // Start is called before the first frame update
    #region my_key_fun
    void Start()
    {

    }
    #region key_value

    #endregion
    public bool[] b_is_key;
    public void fun_key_food_type0()
    {
        b_is_key[0] = false;
        b_is_key[1] = false;
        b_is_key[2] = false;
        b_is_key[3] = false;
        b_is_key[4] = false;
        b_is_key[5] = false;
        b_is_key[6] = false;
        b_is_key[7] = false;
        b_is_key[8] = false;
        b_is_key[9] = false;
        b_is_key[10] = false;
        is_key_on();

    }
    public void fun_key_food_type1()
    {
        b_is_key[0] = false;
        b_is_key[1] = true;
        b_is_key[2] = false;
        b_is_key[3] = false;
        b_is_key[4] = false;
        b_is_key[5] = false;
        b_is_key[6] = false;
        b_is_key[7] = false;
        b_is_key[8] = false;
        b_is_key[9] = false;
        b_is_key[10] = false;
        is_key_on();

    }


    public void fun_key_food_type2()
    {
        b_is_key[0] = false;
        b_is_key[1] = false;
        b_is_key[2] = true;
        b_is_key[3] = false;
        b_is_key[4] = false;
        b_is_key[5] = false;
        b_is_key[6] = false;
        b_is_key[7] = false;
        b_is_key[8] = false;
        b_is_key[9] = false;
        b_is_key[10] = false;

        is_key_on();
    }

    public void fun_key_food_type3()
    {
        b_is_key[0] = false;
        b_is_key[1] = false;
        b_is_key[2] = false;
        b_is_key[3] = true;
        b_is_key[4] = false;
        b_is_key[5] = false;
        b_is_key[6] = false;
        b_is_key[7] = false;
        b_is_key[8] = false;
        b_is_key[9] = false;
        b_is_key[10] = false;
        is_key_on();

    }
    public void fun_key_food_type4()
    {
        b_is_key[0] = false;
        b_is_key[1] = false;
        b_is_key[2] = false;
        b_is_key[3] = false;
        b_is_key[4] = true;
        b_is_key[5] = false;
        b_is_key[6] = false;
        b_is_key[7] = false;
        b_is_key[8] = false;
        b_is_key[9] = false;
        b_is_key[10] = false;
        is_key_on();
    }


    public void fun_key_food_type5()
    {
        b_is_key[0] = false;
        b_is_key[1] = false;
        b_is_key[2] = false;
        b_is_key[3] = false;
        b_is_key[4] = false;
        b_is_key[5] = true;
        b_is_key[6] = false;
        b_is_key[7] = false;
        b_is_key[8] = false;
        b_is_key[9] = false;
        b_is_key[10] = false;
        is_key_on();

    }




    #endregion
    public void is_key_on() {
        if (b_is_key[3]==true)
        {


          //  GameObject.Find("btn_food_version_7").GetComponent<Light>().enabled = false;
         GameObject.Find("btn_food_version_8").GetComponent<Light>().enabled = false;
        }
        else if (b_is_key[2])
        {
            GameObject.Find("btn_food_version_2").GetComponent<UnityEngine.UI.Image>().color = UnityEngine.Color.yellow;
            //GameObject.Find("btn_food_version_3").GetComponent<Transform>().localScale = Vector2.Lerp(transform.GetChild(ii).localScale, new Vector2(1.5f, 1.5f), 0.1f);


            GameObject.Find("btn_food_version_0").GetComponent<Light>().enabled = false;
            GameObject.Find("btn_food_version_1").GetComponent<Light>().enabled = false;
            GameObject.Find("btn_food_version_2").GetComponent<Light>().enabled = true;
            GameObject.Find("btn_food_version_3").GetComponent<Light>().enabled = false ;

            GameObject.Find("btn_food_version_4").GetComponent<Light>().enabled = false;
            GameObject.Find("btn_food_version_5").GetComponent<Light>().enabled = false;

            GameObject.Find("btn_food_version_6").GetComponent<Light>().enabled = false;
            GameObject.Find("btn_food_version_7").GetComponent<Light>().enabled = false;
            GameObject.Find("btn_food_version_8").GetComponent<Light>().enabled = false;
        }
        else if (b_is_key[3])
        {
            GameObject.Find("light_2_for_selected_key_btn_type_food_").GetComponent<Light>().enabled = false;
            GameObject.Find("light_2_for_selected_key_btn_type_food_0").GetComponent<UnityEngine.UI.Image>().color = UnityEngine.Color.yellow;
            GameObject.Find("btn_food_version_3").GetComponent<UnityEngine.UI.Image>().color = UnityEngine.Color.yellow;
           //GameObject.Find("btn_food_version_3").GetComponent<Transform>().localScale = Vector2.Lerp(transform.GetChild(ii).localScale, new Vector2(1.5f, 1.5f), 0.1f);


            GameObject.Find("btn_food_version_0").GetComponent<Light>().enabled = false;
            GameObject.Find("btn_food_version_1").GetComponent<Light>().enabled = false;
            GameObject.Find("btn_food_version_2").GetComponent<Light>().enabled = false;
            GameObject.Find("btn_food_version_3").GetComponent<Light>().enabled = true;

            GameObject.Find("btn_food_version_4").GetComponent<Light>().enabled = false;
            GameObject.Find("btn_food_version_5").GetComponent<Light>().enabled = false;

            GameObject.Find("btn_food_version_6").GetComponent<Light>().enabled = false;
            GameObject.Find("btn_food_version_7").GetComponent<Light>().enabled = false;
            GameObject.Find("btn_food_version_8").GetComponent<Light>().enabled = false;
        }
        else if (b_is_key[4])
        {
           GameObject.Find("btn_food_version_4").GetComponent<Light>().enabled = true;
            GameObject.Find("btn_food_version_4").GetComponent<UnityEngine.UI.Image>().color = UnityEngine.Color.yellow;
            //GameObject.Find("btn_food_version_4").GetComponent<Transform>().localScale = Vector2.Lerp(transform.GetChild(ii).localScale, new Vector2(1.5f, 1.5f), 0.1f);


            
            GameObject.Find("btn_food_version_0").GetComponent<Light>().enabled = false;
            GameObject.Find("btn_food_version_1").GetComponent<Light>().enabled = false;
            GameObject.Find("btn_food_version_2").GetComponent<Light>().enabled = false;

            GameObject.Find("btn_food_version_3").GetComponent<Light>().enabled = false;
            GameObject.Find("btn_food_version_8").GetComponent<Light>().enabled = false;

            GameObject.Find("btn_food_version_5").GetComponent<Light>().enabled = false;
            GameObject.Find("btn_food_version_6").GetComponent<Light>().enabled = false;
            GameObject.Find("btn_food_version_7").GetComponent<Light>().enabled = false;
        }
        else if (b_is_key[5])
        {
            GameObject.Find("btn_food_version_5").GetComponent<UnityEngine.UI.Image>().color = UnityEngine.Color.yellow;
            //GameObject.Find("btn_food_version_3").GetComponent<Transform>().localScale = Vector2.Lerp(transform.GetChild(ii).localScale, new Vector2(1.5f, 1.5f), 0.1f);


            GameObject.Find("btn_food_version_0").GetComponent<Light>().enabled = false;
            GameObject.Find("btn_food_version_1").GetComponent<Light>().enabled = false;
            GameObject.Find("btn_food_version_2").GetComponent<Light>().enabled = false;
            GameObject.Find("btn_food_version_3").GetComponent<Light>().enabled = false ;

            GameObject.Find("btn_food_version_4").GetComponent<Light>().enabled = false;
            GameObject.Find("btn_food_version_5").GetComponent<Light>().enabled = true;

            GameObject.Find("btn_food_version_6").GetComponent<Light>().enabled = false;
            GameObject.Find("btn_food_version_7").GetComponent<Light>().enabled = false;
            GameObject.Find("btn_food_version_8").GetComponent<Light>().enabled = false;
        }
    }
 public void scroll_movement()
    {
        pos = new float[transform.childCount];
        float distance = 1f / (pos.Length -1f);
        for ( i = 0; i <pos.Length; i++)
        {
            pos[i] = distance * i;
        }
        if (Input.GetMouseButton(0))
        {
            scrol_pos = my_scrol.GetComponent<Scrollbar>().value;

           
        }
        else
        {
            for ( j = 0; j <pos.Length ; j++)
            {
                if (scrol_pos<pos[j]+( distance /2) && scrol_pos> pos[j] - (distance/2))
                {
                    scrol_pos = my_scrol.GetComponent<Scrollbar>().value=Mathf.Lerp(my_scrol.GetComponent<Scrollbar>().value,pos[j],0.1f);

                    transform.GetChild(j).GetComponent<UnityEngine.UI.Image>().color = UnityEngine.Color.clear;
                    transform.GetChild(j).GetComponent<Light>().enabled = true;
                }
            }
        }
        for ( ii = 0; ii <pos.Length; ii++)
        {

            if (scrol_pos < pos[ii] + (distance / 2) && scrol_pos > pos[ii] - (distance / 2)  )
            {
                transform.GetChild(ii).localScale = Vector2.Lerp(transform.GetChild(ii).localScale,new Vector2 (1.5f,1.5f),0.1f);
                transform.GetChild(ii).GetComponent<UnityEngine.UI.Image>().color = UnityEngine.Color.yellow ;
                transform.GetChild(ii).GetComponent<Light>().enabled = true;
              
                for (a = 0; a < pos.Length; a++)
                {
                    if (a != ii  )
                    {
                        transform.GetChild(a).localScale = Vector2.Lerp(transform.GetChild(a).localScale, new Vector2(1.3f, 1.3f), 0.1f);
                       transform.GetChild(a).GetComponent<UnityEngine.UI.Image>().color = UnityEngine.Color.gray;
                        transform.GetChild(a).GetComponent<Light>().enabled = false;

                    }
                }
            }

        }
    }
  
    // Update is called once per frame
    void Update()
    {
        scroll_movement();
        is_key_on();
       
    }
  
}

