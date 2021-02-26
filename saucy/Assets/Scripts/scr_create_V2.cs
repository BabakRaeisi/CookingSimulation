using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using UnityEngine.UI;

public class scr_create_V2 : MonoBehaviour
{
    #region var
    public string[] str_num_input, int_array_sorted;
    public int[] int_input_array, int_array_distance, qq;
    public int int_lenghth_qq, iii2 = 0, int_ctrl_run_fun_ins = 0;
    public bool b_ctrl_run_fun_ins = false;

    public Transform scroll_food_type; public GameObject scroll_food_type_in;
    public GameObject[] obj_ins_plate;
    #endregion
    #region fun
    public void fun_split_C(string[] str_c)
    {

        for (int i = str_c.GetLowerBound(0); i <= str_c.GetUpperBound(0); i++)
        {
         
            int_input_array[i] = Convert.ToInt32(str_c[i].Substring(4,2));
        
            Debug.Log(int_input_array[i]);
            // arr_fun(C_array);
           
           
          
            // int_lenghth_qq = int_input_array.Length;
            //Debug.Log(int_lenghth_qq);
            // Debug.Log(int_array_distance[i]);
         
           
            obj_ins_plate = new GameObject[(int_input_array.Length)];
           

        }
        Array.Sort(int_input_array);
        fun_ins_food_type();
    }
    public void fun_ins_food_type()
    {
      
        for (int ii = 0; ii < int_input_array.Length; ii++)
        {
            //iii2 = int_lenghth_q;

            obj_ins_plate[ii] = Instantiate(scroll_food_type_in, new Vector3(0, 0, 0), scroll_food_type_in.transform.rotation) as GameObject;

            obj_ins_plate[ii].transform.parent = gameObject.transform;
           

        }

    }
    #endregion
    // Start is called before the first frame update
    void Awake()
    {

        str_num_input = new string[5] { "101319", "131518", "121214", "131518","161217" };
        int_lenghth_qq = str_num_input.Length;
        int_input_array = new int[int_lenghth_qq];
        obj_ins_plate = new GameObject[iii2 + 1];
        int_array_distance = new int[int_lenghth_qq];
        qq = new int[int_lenghth_qq];
        int_array_sorted = new string[str_num_input.Length];
        fun_split_C(str_num_input);


    }

    // Update is called once per frame
    void Update()
    {

    }
}

