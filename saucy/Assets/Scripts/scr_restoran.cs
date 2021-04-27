using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using SimpleJSON;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Text;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.IO;
using Random = UnityEngine.Random;
public class scr_restoran : MonoBehaviour
{
    #region var


    private string[] str_num_input;
    private  int[] int_input_array_v, int_input_array_v2, int_arr_dis_c_v;
    private string[] int_cat_v4_array;

    private int[] int_input_array, int_arr_dis_c;
    private int int_lenghth_qq, ii;
    private bool b_ctrl_run_fun_ins = false;

    public GameObject content, contentv2;
    [SerializeField]
    private GameObject food_plate;
    public Transform scroll_food_type, scroll_food_type_v, scroll_food_type_v2, content_v, content_v2,food_placed;
    private instantiation inst; 
    public GameObject scroll_food_type_in, plate_place;
    private GameObject[] obj_ins_plate, obj_in_v_scroll_instant, obj_in_v2_scroll_instant;
   
    add_ingredients add_ingred;
    #endregion



    #region fun
    public int i_for_fun_split;
    public string fullpath()
    {
        string str_path = Path.Combine(Application.dataPath, "json.json");
        return str_path;
    }

    public void readpath()
    {

        StreamReader reader = new StreamReader(fullpath());
        string data = reader.ReadToEnd();
        // Debug.Log(data );
        JSONNode jdata = JSON.Parse(data);
        str_num_input = new string[jdata.Count];

      //  t3.text = (jdata[1]["cost"].Value);
        reader.Close();
        for (int i = 0; i < str_num_input.Length; i++)
        {

            str_num_input[i] = (jdata[i]["food_id"].Value);
          //  t3.text = t3.text + (jdata[i]["food_id"].Value);
        }

    }

    #region calculation 

    public string str_cost;
    public decimal dec_cost;
  // public void pricing()
  // {
  //     for (int i = 0; i <= food_placed.childCount; i++)
  //     {
  //
  //         if ()
  //         {
  //
  //
  //
  //         }
  //
  //
  //     }
  //     foreach (var item in food_placed)
  //     {
  //         
  //     }
  //
  // }

    public void calorie()
    {



    }


    #endregion
    public void fun_split_C(string[] str_c)//
    {


        for (i_for_fun_split = str_c.GetLowerBound(0); i_for_fun_split <= str_c.GetUpperBound(0); i_for_fun_split++)
        {
            int_input_array[i_for_fun_split] = Convert.ToInt32(str_c[i_for_fun_split].Substring(0, 2));//c
               //  int_input_array_v[i_for_fun_split] = Convert.ToInt32(str_c[i_for_fun_split].Substring(2, 2));//v
            int_cat_v4_array[i_for_fun_split] = str_c[i].Substring(0, 4);//v2
            
            int_arr_dis_c = int_input_array.Distinct().ToArray();//c dis

            //  int_arr_dis_value_c[i_for_fun_split] =Convert.ToInt32( int_arr_dis_c.GetValue(i_for_fun_split));
            obj_ins_plate = new GameObject[(int_arr_dis_c.Length)];

        }
        fun_ins_food_type();

    }
    public Sprite spr_cc, spr_vv;
    public void fun_ins_food_type()
    {
        //last_update

        for (int iii = 0; iii < int_arr_dis_c.Length; iii++)
        {

            C_obj = Resources.Load("C_obj") as GameObject;
            obj_ins_plate[iii] = Instantiate(C_obj, new Vector3(0, 0, 0), scroll_food_type.transform.rotation);
            obj_ins_plate[iii].transform.parent = gameObject.transform;
            obj_ins_plate[iii].transform.name = int_arr_dis_c[iii].ToString();
            string name_c = obj_ins_plate[iii].transform.name;


            transform.GetChild(iii).gameObject.AddComponent<Light>();
           
            transform.GetChild(iii).gameObject.AddComponent<UnityEngine.UI.Button>().onClick.AddListener((() => fun_v_manager(name_c)));
            
            transform.GetChild(iii).GetComponent<UnityEngine.UI.Image>().sprite = Resources.Load<Sprite>("sprite/sprite_c/spr_c_" + int_arr_dis_c[iii].ToString());




        }


        i_run_move = 1;
        count_scroll = int_arr_dis_c.Length;
        array_count_scroll = new int[count_scroll];


    } //تولید C و ارسال به فانکشن V


    public void scroll_movement()
    {
        pos = new float[count_scroll];
        float distance = 1f / (pos.Length - 1f);
        for (i = 0; i < pos.Length; i++)
        {
            pos[i] = distance * i;
        }
        if (Input.GetMouseButton(0))
        {
            scrol_pos = my_scrol.GetComponent<Scrollbar>().value;


        }
        else
        {
            for (j = 0; j < pos.Length; j++)
            {
                if (scrol_pos < pos[j] + (distance / 2) && scrol_pos > pos[j] - (distance / 2))
                {
                    scrol_pos = my_scrol.GetComponent<Scrollbar>().value = Mathf.Lerp(my_scrol.GetComponent<Scrollbar>().value, pos[j], 0.1f);

                    transform.GetChild(j).GetComponent<UnityEngine.UI.Image>().color = UnityEngine.Color.clear;
                    transform.GetChild(j).GetComponent<Light>().enabled = true;
                }
            }
        }
        for (ii_move = 0; ii_move < pos.Length; ii_move++)// active c key
        {

            if (scrol_pos < pos[ii_move] + (distance / 2) && scrol_pos > pos[ii_move] - (distance / 2))
            {
                transform.GetChild(ii_move).localScale = Vector2.Lerp(transform.GetChild(ii_move).localScale, new Vector2(1f, 1f), 0.1f);
                transform.GetChild(ii_move).GetComponent<UnityEngine.UI.Image>().color = UnityEngine.Color.yellow;
                t1.text = Convert.ToString(int_arr_dis_c.GetValue(ii_move));



                transform.GetChild(ii_move).GetComponent<Light>().enabled = true;

                for (a = 0; a < pos.Length; a++)
                {
                    if (a != ii)
                    {
                        transform.GetChild(a).localScale = Vector2.Lerp(transform.GetChild(a).localScale, new Vector2(0.5f, 0.5f), 0.1f);
                        transform.GetChild(a).GetComponent<UnityEngine.UI.Image>().color = UnityEngine.Color.gray;
                        transform.GetChild(a).GetComponent<Light>().enabled = false;

                    }
                }
            }

        }
        //transform.GetChild(ii_move).GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => fun_run_v(t1.text, ii_move));
    }
    public string s, str_sub_c_for_goll, str_sub_v_for_goll;
    public string[] str_arr_sub_c_for_goll, str_v_4, str_arr_sub_v_for_goll;

    public void fun_v_manager(string name_c)//s<-----c  //
    {
        int child_v = content_v.childCount;
        for (int chi = child_v - 1; chi >= 0; chi--)
        {

         
            Destroy(content_v.GetChild(chi).gameObject);

        }
        //  { "102030", "102131", "152632", "112333",#"152434","102835",#"152435", "152435", #"152435" };
        for (int i = 0; i < str_num_input.Length; i++)
        {
            if (str_num_input[i].Substring(0, 2) == name_c)
            {

                int_input_array_v[i] = Convert.ToInt32(str_num_input[i].Substring(2, 4));//v
                Debug.Log("V: " + str_num_input[i].Substring(2, 4)); 
                string part_v = int_input_array_v[i].ToString();
                obj_in_v_scroll_instant = new GameObject[int_input_array_v.Length];
                for (int j = 0; j <= int_input_array_v.Length; j++)
                {
                    if (content_v.Find(name_c + part_v) == null)
                    {
                        V_obj = Resources.Load("V_obj") as GameObject;
                        obj_in_v_scroll_instant[j] = Instantiate(V_obj, new Vector3(0, 0, 0), scroll_food_type_v.transform.rotation);
                        obj_in_v_scroll_instant[j].transform.SetParent(content_v);

                        obj_in_v_scroll_instant[j].transform.name = name_c + part_v;

                        obj_in_v_scroll_instant[j].gameObject.AddComponent<Light>();
                      

                        obj_in_v_scroll_instant[j].GetComponent<UnityEngine.UI.Image>().sprite = Resources.Load<Sprite>("sprite/sprite_v/" + name_c + part_v);
                        obj_in_v_scroll_instant[j].gameObject.AddComponent<UnityEngine.UI.Button>().onClick.AddListener((() => send_to_plate(name_c, part_v)));
                    }
                }





            }

        }








        inst.b_desrtroy = false;

    }
    #region V2

    //  public void fun_v2_manager(string name_c, string name_v)
    //  {
    //      int child_v = content_v2.childCount;
    //      for (int chi = child_v - 1; chi >= 0; chi--)
    //      {
    //
    //          Debug.Log("childv  :    " + child_v);
    //          Destroy(content_v2.GetChild(chi).gameObject);
    //
    //      }
    //      //  { "102030", "102131", "152632", "112333",#"152434","102835",#"152435", "152435", #"152435" };
    //      for (int i = 0; i < str_num_input.Length; i++)
    //      {
    //          if (str_num_input[i].Substring(0, 4) == name_c + name_v)
    //          {
    //
    //
    //              int_input_array_v2[i] = Convert.ToInt32(str_num_input[i].Substring(4, 2));//v2
    //
    //              string part_v2 = int_input_array_v2[i].ToString();
    //              obj_in_v2_scroll_instant = new GameObject[int_input_array_v2.Length];
    //              for (int j = 0; j <= int_input_array_v2.Length; j++)
    //              {
    //                  if (content_v2.Find(name_c + name_v + part_v2) == null)
    //                  {
    //                      v2_obj = Resources.Load("v2_obj") as GameObject;
    //                      obj_in_v2_scroll_instant[j] = Instantiate(v2_obj, new Vector3(0, 0, 0), scroll_food_type_v.transform.rotation);
    //                      obj_in_v2_scroll_instant[j].transform.SetParent(content_v2);
    //
    //                      obj_in_v2_scroll_instant[j].transform.name = name_c + name_v + part_v2;
    //
    //                      obj_in_v2_scroll_instant[j].gameObject.AddComponent<Light>();
    //                      //   obj_in_v2_scroll_instant[j].gameObject.AddComponent<Button>();
    //                      
    //                      obj_in_v2_scroll_instant[j].GetComponent<UnityEngine.UI.Image>().sprite = Resources.Load<Sprite>("sprite/sprite_v2/spr_v2_" + name_c + name_v + part_v2);
    //                      obj_in_v2_scroll_instant[j].gameObject.AddComponent<UnityEngine.UI.Button>().onClick.AddListener((() => fun_create_bread(name_c, name_v, part_v2)));
    //                  }
    //              }
    //
    //
    //          }
    //
    //      }
    //
    //  }
    #endregion



    public string str_obj_v2_name; 
   
    public void send_to_plate(string c, string v)
    {
      
            for (int i = 0; i < str_num_input .Length ; i++)
            {
                if (c + v == str_num_input[i])
                {

                inst.b_desrtroy = false;
                inst.create_instnce = false; 
                    str_obj_v2_name = str_num_input[i];
                    
                    //  { "102030", "102131", "152632", "112333",#"152434","102835",#"152435", "152435", #"152435" };

                }
            }
            
        
        
        StreamReader reader_v = new StreamReader(fullpath());
        string data = reader_v.ReadToEnd();
      
        JSONNode jdata = JSON.Parse(data);


        #region old v2  
       // string cvv2 = c + v;


        // if (c == "10")
        // {
        //     var plate = GameObject.Find("plate");
        //     var non = Instantiate(food_plate, plate.transform.position + new Vector3(0, 0, -0.1f), Quaternion.identity);
        //
        //     non.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("sprite/sprite_v2/spr_v2_" + c + v );
        //     non.AddComponent<PolygonCollider2D>().isTrigger = true;
        //     for (int i = 0; i < str_num_input.Length; i++)
        //     {
        //         if (cvv2 == jdata[i]["food_id"].Value)
        //         {
        //             str_cost= (jdata[i]["cost"].Value);
        //             Debug.Log("dec_cost 999: ");
        //             dec_cost = Convert.ToDecimal (str_cost);
        //             Debug.Log("dec_cost : " );
        //             t3.text = (jdata[i]["cost"].Value);
        //
        //         }
        //
        //     }
        // }
        //


        // else
        //  {
        //      str_obj_v2_name= c + v ;
        //      for (int i = 0; i < str_num_input.Length; i++)
        //      {
        //          if (cvv2 == jdata[i]["food_id"].Value)
        //          {
        //              str_cost = (jdata[i]["cost"].Value);
        //         
        //              dec_cost  = Convert.ToDecimal (str_cost);
        //              Debug.Log("dec_cost : "+ dec_cost);
        //              t3.text = (jdata[i]["cost"].Value);
        //          }
        //
        //      }
        //
        //  }
        //  reader_v.Close();
        //
        #endregion


    }

    int shot_width, shot_height;
    public RectTransform food_rect;
   // public Texture2D texx;

        public void fun_send_btn()
        {
        StartCoroutine(fun_send_food());
         }

    public IEnumerator  fun_send_food( )
    {
        WaitForEndOfFrame frameEnd = new WaitForEndOfFrame();
        yield return frameEnd;
        Vector2 v2_rect = food_rect.transform.position;
        var startx = v2_rect.x -shot_width/2 ;
        var starty = v2_rect.y - shot_height/2;
        var tex = new Texture2D(shot_width, shot_height, TextureFormat.RGB24, true);
        tex.ReadPixels(new Rect (startx-5,starty-5 ,shot_width ,shot_height ),0,0);
        tex.LoadRawTextureData(tex.GetRawTextureData());
        tex.Apply();
        var bytes = tex.EncodeToPNG();
        Destroy(tex );
        File.WriteAllBytes(Application.dataPath+"screenshotbbbbbbbbbbbbbbbb.png",bytes);
        Debug.Log("iegeh");
    }

    
 
  





    public bool[] b_switch_run;

    public int test_test;




    public int count_scroll;
    public int[] array_count_scroll;



    //move_var
    public int a, i, j, ii_move, i_run_move = 0;
    public float scrol_pos = 0;
    public GameObject my_scrol;
    public float[] pos;
    public Text t1;



    public GameObject C_obj, V_obj, v2_obj,button_shot;

    public Sprite[] spr_img_c;










    public void fun_find_obj_in_awake()
    {
        spr_img_c = new Sprite[int_arr_dis_c.Length];
       
      


        // GameObject.Find("plate_bread_img").gameObject.AddComponent<Light>();

        // GameObject.Find("plate_place").GetComponent<RectTransform>().position  = new Vector2(-350, 0);
        shot_height = System.Convert.ToInt32(food_rect.rect.height  );
        shot_width = System.Convert.ToInt32(food_rect.rect.width);
        button_shot = GameObject.Find("btn_send_shot");
        //button_shot.GetComponent<Button>().onClick.AddListener(fun_send_btn());
    }





    #endregion

    public int qq_v;
   


    void Awake()
    {
        readpath();
        my_scrol = GameObject.Find("Scrollbar Vertical");

        scroll_food_type_v = GameObject.Find("Scrollbar Vertical_v").GetComponent<Transform>();
        scroll_food_type = GameObject.Find("Scrollbar Vertical").GetComponent<Transform>();
      
        content_v = GameObject.Find("content_v").GetComponent<Transform>();
     
        content = GameObject.Find("Content");

        inst = GameObject.Find("plate").GetComponent<instantiation>();

        food_placed = GameObject.Find("foodholder").GetComponent<Transform>();

        int_lenghth_qq = str_num_input.Length;


        int_input_array = new int[int_lenghth_qq];
        int_input_array_v = new int[int_lenghth_qq];
        int_input_array_v2 = new int[int_lenghth_qq];
        obj_ins_plate = new GameObject[99];

        obj_in_v2_scroll_instant = new GameObject[99];
        int_arr_dis_c = new int[int_lenghth_qq];
        int_cat_v4_array = new string[int_lenghth_qq];


        b_switch_run = new bool[int_lenghth_qq];
                                                                 
        fun_split_C(str_num_input);

        fun_find_obj_in_awake();

    }
  

}
