using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using UnityEngine.UI;

public class scr_create_V : MonoBehaviour
{
    #region var
    public string[] str_num_input;
    public int[] int_input_array_v, int_array_distance_v;
    public GameObject[] btn_v;
    public int int_lenghth_qq, iii2 = 0, int_ctrl_run_fun_ins = 0;
    public bool b_ctrl_run_fun_ins = false;



    #endregion
    #region fun
    public void fun_split_v(string[] str_c)
    {
        Debug.Log("asasasasas");
        for (int i = str_c.GetLowerBound(0); i <= str_c.GetUpperBound(0); i++)
        {


            int_input_array_v[i] = Convert.ToInt32(str_c[i].Substring(2, 2));

            Debug.Log(int_input_array_v);

            Array.Sort(str_c);


            int_array_distance_v = int_input_array_v.Distinct().ToArray();


            // btn_v = new GameObject[(int_array_distance_v.Length)];



        }



        // fun_ins_food_v();


    }

    #endregion
   
    // Start is called before the first frame update
    void Awake()
    {
        str_num_input = new string[4] { "101319", "131518", "121214", "131518" };

        int_lenghth_qq = str_num_input.Length;
        
         btn_v = new GameObject[iii2 + 1];
         int_array_distance_v = new int[int_lenghth_qq];
        
        


        fun_split_v(str_num_input);


    }

    // Update is called once per frame
    void Update()
    {

    }
}
