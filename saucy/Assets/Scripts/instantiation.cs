using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.IO;
using SimpleJSON;
using System.Runtime.Serialization.Formatters.Binary;
using System.Linq;
using UnityEngine.SceneManagement;

public class instantiation : MonoBehaviour
{

    public Text calorie_txt, value;
    public string food_name_tag;
    [SerializeField]
    private GameObject D_obj;
    [SerializeField]
    private scr_restoran n_scr_Restoran;
    private done_script done; 
    public Transform foodHolder;
    [SerializeField]
    private Transform content_delete;

    private rewire_buttons rewire;

    public int Saved_calorie;
    public decimal Saved_price; 

   
    public int amount;
    [SerializeField]
    private Transform scroll_Delete;    
    public GameObject[] delete_group_ar;

   
   
   // private Button delete_btn; 
    
    public bool create_instnce = false; 
    public bool b_desrtroy = false;
    private Ingredient small_ingred; 

    public  List<Ingredient> ListIngred = new List<Ingredient>();
    
    public List<Info> ListInfo = new List<Info>();
    public List<Food> foodlist = new List<Food>(); 
  

    public FinalInfo final_info;

    #region main
    
    public void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        n_scr_Restoran = GameObject.Find("content").GetComponent<scr_restoran>();
        foodHolder = GameObject.Find("foodholder").GetComponent<Transform>();
       // scroll_Delete = GameObject.Find("Scrollbar Vertical_del").GetComponent<Transform>();
        content_delete = GameObject.Find("content_delete").GetComponent<Transform>();
       
        done = GameObject.Find("done").GetComponent<done_script>();
      
    }
   

    void OnEnable()
    {
        SceneManager.sceneLoaded += Loadedscene;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= Loadedscene;
    }

    void Loadedscene(Scene scene, LoadSceneMode mode)
    {

        if (scene.name == "CVV2")
        {
            n_scr_Restoran = GameObject.Find("content").GetComponent<scr_restoran>();
            foodHolder = GameObject.Find("foodholder").GetComponent<Transform>();
            scroll_Delete = GameObject.Find("Scrollbar Vertical_del").GetComponent<Transform>();
            content_delete = GameObject.Find("content_delete").GetComponent<Transform>();
            calorie_txt = GameObject.Find("Calorie_Indicator").GetComponent<Text>();
            value = GameObject.Find("Price_Indicator").GetComponent<Text>();
            done = GameObject.Find("done").GetComponent<done_script>();
            rewire = GameObject.Find("Canvas").GetComponent<rewire_buttons>();
          
            create_instnce = false;



         

            calorie_txt.text = calorie.ToString(); 

            value.text = price.ToString(); 




            if (foodHolder.childCount < 1)
            {
                int child_v = content_delete.childCount;
                for (int chi = child_v - 1; chi >= 0; chi--)
                {


                    //  Destroy(content_delete.GetChild(chi).gameObject);

                    price = 0;
                    calorie = 0;
                    value.text = price.ToString();
                    calorie_txt.text = calorie.ToString();

                }



            }
            if (foodHolder.childCount > 1)
            {

                for (int i = 0; i < foodHolder.childCount; i++)
                {
                 
                    create_delete_group(foodHolder.GetChild(i).transform.name.Substring(0,6)); 
                }


            }



        }
        
    }

    void Start()
    {
     
       

        

    }
    void Update()
    {

        if (Input.GetMouseButtonUp(0) && b_desrtroy == false && create_instnce == false )
        {

            instance_of_food(n_scr_Restoran.str_obj_v2_name);


        }
        if (Input.GetMouseButtonUp(0) && b_desrtroy == true)
        { remove_me(); }

        //    Debug.Log(IngredList.Count); 
    }

    public void activate_delete()
    {
        if (b_desrtroy == false) { b_desrtroy = true; }
        else { b_desrtroy = false; }
    }


    void instance_of_food(string v2)
    {
        try
        {

            GameObject food_obj = Resources.Load<GameObject>("prefab/Burger3D/" + v2);
            Vector3 mousepos = Input.mousePosition;
            //   mousepos.z = Random.Range(-2f, 2f);
            // mousepos.y = 2.9f;
            //   mousepos.x = Random.Range(-2f, 2f);
            //   if (food_obj.transform.localScale.x > 100)
            //   {
            //       Instantiate(food_obj, new Vector3(0, 4f, 0), Quaternion.Euler(-90f, 0, 0));
            //   }
            //   else {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;


            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "food_tag" || hit.collider.tag == "plate_tag" || hit.collider.tag == "foodbase_tag" )
                {

                    // Debug.Log("turn is over");
                    // Debug.Log("number of keys and values" + food_dict.Count);
                    Instantiate(food_obj, hit.point, Quaternion.Euler(-90, Random.Range(-180f, 180f), 0), foodHolder);
                    manage_ingred(food_obj.name);
                    create_delete_group(food_obj.name);
                  
                }
            }
            if (food_obj.tag == "foodbase_tag")
            {
                food_obj.transform.position = new Vector3(0, 0.3f, 0.17f); 

            }


        }
        catch { }


    }

    bool exist = false;
    public void manage_ingred(string name)
    {
        foreach (var item in ListIngred)
        {
            if (item.ingred_name == name)
            {
                item.ingred_amount = item.ingred_amount + 1;

                exist = true;
            }


        }
        if (exist == false)
        {
            Ingredient newIngred = new Ingredient();
            newIngred.ingred_name = name;
            newIngred.ingred_amount = 1;
            ListIngred.Add(newIngred);
            exist = true;
        }
        exist = false;
        calculate(name);
    }


    #region calculation
    public int calorie = 0;
    public decimal price = 0;

    void calculate(string name)
    {
        StreamReader reader = new StreamReader(path());
        string data = reader.ReadToEnd();
        JSONNode jdata = JSON.Parse(data);

        for (int i = 0; i <= data.Length; i++)
        {
            if (name == jdata[i]["food_id"].Value)
            {
                string str_cost = jdata[i]["cost"].Value;
                decimal dec_cost = System.Convert.ToDecimal(str_cost);
                price = price + (dec_cost);

                string str_calorie = jdata[i]["calorie"].Value;
                int int_Calorie = System.Convert.ToInt16(str_calorie);
                calorie = calorie + int_Calorie;


            }
        }


        reader.Close();

        value.text = price.ToString();
        calorie_txt.text = calorie.ToString();
    }




    public void deduct(string name)
    {
        
        Debug.Log(name); 
        StreamReader reader = new StreamReader(path());
        string data = reader.ReadToEnd();
        JSONNode jdata = JSON.Parse(data);

        for (int i = 0; i <= data.Length; i++)
        {
            if (name == jdata[i]["food_id"].Value)
            {
                string str_cost = jdata[i]["cost"].Value;
                decimal dec_cost = System.Convert.ToDecimal(str_cost);
                price = price - (dec_cost);

                string str_calorie = jdata[i]["calorie"].Value;
                int int_Calorie = System.Convert.ToInt16(str_calorie);
                calorie = calorie - int_Calorie;


            }

            reader.Close();
            value.text = price.ToString();
            calorie_txt.text = calorie.ToString();
        }
    }

    #endregion



    #region submission

    public void submit_name() { food_name_tag = done.inp_food_name.text; }
    public void submit_all()
    {
        create_instnce = true; 
        ListInfo.Add(submit_info());
        final_info.information = ListInfo.ToArray();
        Saved_calorie = calorie;
        Saved_price = price; 

       
        StreamWriter writer = new StreamWriter(writepath());
        writer.WriteLine("[");
        foreach (var item in ListInfo)
        {
            writer.WriteLine("{" + '"' + "Calorie " + '"' + ":" + '"' + item.food_calorie + '"' + "," + '"' + "price " + '"' + ":" + '"' + item.food_price + '"' + "," + '"' + "name " + '"' + ":" + '"' + item.food_name + '"' + "}"+",");
          
        }
        foreach (var item in ListIngred)
        {
            writer.WriteLine("{" + '"' + "food_id " + '"' + ":" + '"' + item.ingred_name + '"' + "," + '"' + " amount " + '"' + ":" + '"' + item.ingred_amount + '"' + "},");

        }
        writer.WriteLine("{}]");
        writer.Close();
        next_scene_foods();
    }

    Info submit_info()
    {
        Info pcn = new Info();
        pcn.food_price = price.ToString();
        pcn.food_calorie = calorie;
        pcn.food_name = done.inp_food_name.text;


        return pcn;

    }


    public void next_scene_foods()
    {
       foodlist.Add(foodadder());
    }

    Food foodadder()
    {
        Food newfood = new Food();

        newfood.foodname = done.inp_food_name.text;
        newfood.foodprice = price.ToString(); 

        return newfood; 

    }
    #endregion



    #region jsonpath
    public string writepath()
    {
        string str_path = Path.Combine(Application.dataPath, "foodInscene.json");
        return str_path;
    }

    public string path()
    {
        string str_path = Path.Combine(Application.dataPath, "json.json");
        return str_path;
    }

    #endregion




    #region Delete function
   

  
    void create_delete_group(string spritecode)
     {
         delete_group_ar = new GameObject[foodHolder.childCount];
        
         for (int i = 0; i <= ListIngred.Count; i++)
         {
             if (content_delete.Find(spritecode+"(Clone)") == null)
             {
                 D_obj = Resources.Load("btn_D") as GameObject;
                 D_obj.transform.name = spritecode; 
                 delete_group_ar[i] = Instantiate(D_obj, new Vector3(0, 0, 0), scroll_Delete.transform.rotation);
                 delete_group_ar[i].transform.SetParent(content_delete);
                 delete_group_ar[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("sprite/sprite_del/"+spritecode);
               
                 
             }
         }
         
    
        
    
     }
    
    
     public void Delete_group(string group_code)
     {
    
    
         if (foodHolder.childCount > 0)
         {
    
             int child_v = foodHolder.childCount;
             for (int chi = child_v - 1; chi >= 0; chi--)
             {
    
                 if (group_code+"(Clone)" == foodHolder.GetChild(chi).name)
                 {
                     Destroy(foodHolder.GetChild(chi).gameObject);
                     deduct(group_code);
                 }
                 
                 
    
             }
         }
    
        
    
         for (int i = 0; i < ListIngred.Count; i++)
         {
             if(ListIngred[i].ingred_name==group_code)
             {
    
                 ListIngred.RemoveAt(i); 
             }
         }
    
     }
   

    public void remove_me()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag == "food_tag"|| hit.collider.tag == "foodbase_tag")
            {
                try
                {


                    Destroy(hit.transform.gameObject);
                    string name = hit.transform.name.Substring(0, 6);
                
                    foreach (var item in ListIngred)
                    {
                        if (item.ingred_name == name)
                        {
                            item.ingred_amount = item.ingred_amount - 1;
                            deduct(name);
                        }
                    }
                }

                catch
                {

                    Debug.Log("nin khalooo!!!!");
                }
            }
        }
    }
    public void remove_all()
    {
        if (foodHolder.childCount > 0)
        {

            int child_v = foodHolder.childCount;
            for (int chi = child_v - 1; chi >= 0; chi--)
            {


                Destroy(foodHolder.GetChild(chi).gameObject);
                ListIngred.Clear();
                price = 0;
                calorie = 0;
                value.text = price.ToString();
                calorie_txt.text = calorie.ToString();

            }
        }
        if (foodHolder.childCount > 0)
        {

            int child_v = foodHolder.childCount;
            for (int chi = child_v - 1; chi >= 0; chi--)
            {


                Destroy(foodHolder.GetChild(chi).gameObject);
               

            }
        }
        if (content_delete.childCount > 0)
        {

            int child_v = content_delete.childCount;
            for (int chi = child_v - 1; chi >= 0; chi--)
            {


                Destroy(content_delete.GetChild(chi).gameObject);
                ListIngred.Clear();
                price = 0;
                calorie = 0;
                value.text = price.ToString();
                calorie_txt.text = calorie.ToString();

            }
        }
    }

    #endregion

    #endregion
}

#region classes





[System.Serializable]
public class Ingredient
{
    public string ingred_name;
    public int ingred_amount;

}

[System.Serializable]
public class Food
{
    public string foodname;
    public string foodprice; 
}


[System.Serializable]
public class Info
{
    public string food_name;
    public string food_price;
    public int food_calorie;

}
[System.Serializable]
public class FinalInfo
{
    public Info[] information;

}


#endregion