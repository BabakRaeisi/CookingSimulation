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
    private string str = "https://hormuzpay.com/main_entities_mysql/food/restful_web_service_read_all_stuffs.php";
    public UnityWebRequest uu;
    JSONNode jdata2;





    public string str_cost, type_select;
    public decimal dec_cost;

    private int[] int_input_array_v, int_input_array_v2, int_arr_dis_c_v;
    private string[] int_cat_v4_array, str_num_input;

    private int[] int_input_array, int_arr_dis_c;
    private int int_lenghth_qq, ii;


    public GameObject content, contentv2, viewPort;
    [SerializeField]
    private GameObject food_plate;
    public Transform scroll_food_type, scroll_food_type_v, scroll_food_type_v2, content_v, content_v2, food_placed, PopUpholder;
    private instantiation inst;
    public GameObject scroll_food_type_in, plate_place, popup;
    private GameObject[] obj_ins_plate, obj_in_v_scroll_instant, obj_in_v2_scroll_instant;


    #endregion



    #region fun



    public void fun_split_C(List<food_input> str_c)//
    {


        for (int i = 0; i < food_input_list.Count; i++)
        {

            int_input_array[i] = Convert.ToInt32(str_c[i].input_name.Substring(0, 2));//c

            //   int_cat_v4_array[i] = str_c[i].input_name.Substring(0, 4);//v2

            int_arr_dis_c = int_input_array.Distinct().ToArray();//c dis


            obj_ins_plate = new GameObject[(int_arr_dis_c.Length)];

        }
        fun_ins_food_type();

    }

    public void fun_ins_food_type()
    {


        for (int i = 0; i < int_arr_dis_c.Length; i++)
        {

            C_obj = Resources.Load("C_obj") as GameObject;
            // if(int_arr_dis_c[i].name == type_select)
            obj_ins_plate[i] = Instantiate(C_obj, new Vector3(0, 0, 0), Quaternion.identity);

            obj_ins_plate[i].transform.SetParent(gameObject.transform);
            obj_ins_plate[i].transform.name = int_arr_dis_c[i].ToString();
            string name_c = obj_ins_plate[i].transform.name;




            transform.GetChild(i).gameObject.AddComponent<UnityEngine.UI.Button>().onClick.AddListener((() => fun_v_manager(name_c)));


            transform.GetChild(i).GetComponent<UnityEngine.UI.Image>().sprite = Resources.Load<Sprite>("sprite/sprite_c/spr_c_" + int_arr_dis_c[i].ToString());
            transform.GetChild(i).GetComponent<UnityEngine.UI.Image>().color = Color.white;
            // LeanTween.scale(transform.GetChild(iii).gameObject, new Vector2(3f, 3f), 0.9f).setEasePunch().setLoopPingPong();



        }


        i_run_move = 1;
        count_scroll = int_arr_dis_c.Length;
        array_count_scroll = new int[count_scroll];


    }


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


    [SerializeField]
    private LeanTweenType act;



    public void fun_v_manager(string name_c)//s<-----c  //
    {


        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            if (gameObject.transform.Find(name_c) == gameObject.transform.GetChild(i))
            {
                gameObject.transform.GetChild(i).LeanScale(new Vector2(0.5f, 0.5f), 0.3f).setEase(act);

            }

            else
            {



            }
        }


        viewPort.SetActive(true);
        int child_v = content_v.childCount;

        for (int chi = child_v - 1; chi >= 0; chi--)
        {


            Destroy(content_v.GetChild(chi).gameObject);

        }
        //  { "102030", "102131", "152632", "112333",#"152434","102835",#"152435", "152435", #"152435" };
        for (int i = 0; i < food_input_list.Count; i++)
        {
            if (food_input_list[i].input_name.Substring(0, 2) == name_c)
            {

                int_input_array_v[i] = Convert.ToInt32(food_input_list[i].input_name.Substring(2, 4));//v

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




    public string str_obj_v2_name;

    public void send_to_plate(string c, string v)
    {

        for (int i = 0; i < food_input_list.Count; i++)
        {
            if (c + v == food_input_list[i].input_name)
            {


                inst.b_desrtroy = false;
                inst.create_instnce = false;
                str_obj_v2_name = food_input_list[i].input_name;

                Instantiate(popup, content_v.transform.Find(str_obj_v2_name).position + new Vector3(-150f, 0, 0), Quaternion.identity, PopUpholder);

                StartCoroutine(popup_function(popup, str_obj_v2_name));





                //  { "102030", "102131", "152632", "112333",#"152434","102835",#"152435", "152435", #"152435" };

            }
        }



        // StreamReader reader_v = new StreamReader(fullpath());
        //  string data = reader_v.ReadToEnd();

        //  JSONNode jdata = JSON.Parse(data);


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
    IEnumerator popup_function(GameObject s, string Name1)
    {


        s.LeanScale(Vector2.zero, 2f).setEaseOutQuart();

        yield return new WaitForSeconds(5);

    }
    int shot_width, shot_height;
    public RectTransform food_rect;
    // public Texture2D texx;

    public void fun_send_btn()
    {
        StartCoroutine(fun_send_food());
    }

    public IEnumerator fun_send_food()
    {
        WaitForEndOfFrame frameEnd = new WaitForEndOfFrame();
        yield return frameEnd;
        Vector2 v2_rect = food_rect.transform.position;
        var startx = v2_rect.x - shot_width / 2;
        var starty = v2_rect.y - shot_height / 2;
        var tex = new Texture2D(shot_width, shot_height, TextureFormat.RGB24, true);
        tex.ReadPixels(new Rect(startx - 5, starty - 5, shot_width, shot_height), 0, 0);
        tex.LoadRawTextureData(tex.GetRawTextureData());
        tex.Apply();
        var bytes = tex.EncodeToPNG();
        Destroy(tex);
        File.WriteAllBytes(Application.dataPath + "screenshotbbbbbbbbbbbbbbbb.png", bytes);
        Debug.Log("iegeh");
    }











    public int test_test;




    public int count_scroll;
    public int[] array_count_scroll;



    //move_var
    public int a, i, j, ii_move, i_run_move = 0;
    public float scrol_pos = 0;
    public GameObject my_scrol;
    public float[] pos;
    public Text t1;



    public GameObject C_obj, V_obj, v2_obj, button_shot;

    public Sprite[] spr_img_c;










    public void fun_find_obj_in_awake()
    {
        spr_img_c = new Sprite[int_arr_dis_c.Length];




        // GameObject.Find("plate_bread_img").gameObject.AddComponent<Light>();

        // GameObject.Find("plate_place").GetComponent<RectTransform>().position  = new Vector2(-350, 0);
        shot_height = System.Convert.ToInt32(food_rect.rect.height);
        shot_width = System.Convert.ToInt32(food_rect.rect.width);
        button_shot = GameObject.Find("btn_send_shot");
        //button_shot.GetComponent<Button>().onClick.AddListener(fun_send_btn());
    }





    #endregion





    void Awake()
    {
        GameObject.Find("Logout").GetComponent<Button>().onClick.AddListener(logout);
        my_scrol = GameObject.Find("Scrollbar Vertical");

        scroll_food_type_v = GameObject.Find("Scrollbar Vertical_v").GetComponent<Transform>();
        scroll_food_type = GameObject.Find("Scrollbar Vertical").GetComponent<Transform>();

        content_v = GameObject.Find("content_v").GetComponent<Transform>();

        content = GameObject.Find("Content");

        inst = GameObject.Find("plate").GetComponent<instantiation>();

        food_placed = GameObject.Find("foodholder").GetComponent<Transform>();



    }

    public void logout()
    {
        PlayerPrefs.SetString("b_switch_page", "true");
        PlayerPrefs.DeleteKey("fname");
        PlayerPrefs.Save();
        Debug.Log(PlayerPrefs.GetString("b_switch_page"));
        SceneManager.LoadScene("start");

    }


    public List<food_input> food_input_list = new List<food_input>();
    food_input server_food(string name, string cal, string cost)
    {
        food_input newInp = new food_input();

        newInp.input_name = name;
        newInp.input_cost = cost;
        newInp.input_calorie = cal;

        return newInp;
    }
    IEnumerator Maxw(string url)
    {


        string name;
        string cal;
        string cost;




        Debug.Log("starting");
        WWWForm formm = new WWWForm();
        //form.AddField("organId", 1);
        // form.AddField("organId");
        uu = UnityWebRequest.Post(url, formm);
        yield return uu.SendWebRequest();
        if (uu.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log("no network connection!");
        }
        else
        {

            string str_uwr = uu.downloadHandler.text;
            Debug.Log(str_uwr);

            jdata2 = JSON.Parse(uu.downloadHandler.text);
            // input = new string[jdata2.Count];
            //  jfile =<TextAsset> str_uwr;
            str_num_input = new string[jdata2.Count];

            for (int i = 0; i < jdata2.Count; i++)
            {

                name = (jdata2[i]["food_code"].Value);
                cal = (jdata2[i]["calorie"].Value);
                cost = (jdata2[i]["cost"].Value);

                food_input_list.Add(server_food(name, cal, cost));

            }


            int_lenghth_qq = str_num_input.Length;


            int_input_array = new int[int_lenghth_qq];
            int_input_array_v = new int[int_lenghth_qq];
            int_input_array_v2 = new int[int_lenghth_qq];
            obj_ins_plate = new GameObject[99];

            obj_in_v2_scroll_instant = new GameObject[99];
            int_arr_dis_c = new int[int_lenghth_qq];
            int_cat_v4_array = new string[int_lenghth_qq];

            type_select = PlayerPrefs.GetString("type");
            fun_split_C(food_input_list);
            //first_turn = false; 
            fun_find_obj_in_awake();



        }

    }
   
   
      void Start()
      {

        string user = PlayerPrefs.GetString("fname");
        GameObject.Find("txt_online_user").GetComponent<Text>().text = user;

        StartCoroutine(Maxw(str));
          
         
          viewPort.SetActive(false);
    
    
      }

}
[System.Serializable]
public class food_input
{
    public string input_name;
    public string input_cost;
    public string input_calorie; 

}
