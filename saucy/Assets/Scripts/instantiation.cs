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
using RTLTMPro;
using TMPro;
using UnityEngine.Networking;

public class instantiation : MonoBehaviour
{

    public Text calorie_txt, value,cart_text ;


    private cart_script cart; 



    public string food_name_tag;             
    [SerializeField]
    private GameObject D_obj;
    [SerializeField]
    private scr_restoran n_scr_Restoran;
    private done_script done;
    private MoveScene move;
    public Transform foodHolder;
    [SerializeField]
    private Transform content_delete;
    [SerializeField]
    private Button cart_btn, pay_btn; 
    private rewire_buttons rewire;

    public int Saved_calorie;
    public decimal Saved_price; 

   
    public int amount;
    [SerializeField]
    private Transform scroll_Delete;    
    public GameObject[] delete_group_ar;
    private Button profile_btn, close_profile; 
   
   
   // private Button delete_btn; 
    
    public bool create_instnce = false; 
    public bool b_desrtroy = false;
   // public bool first_turn = true; 

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
        cart_text = GameObject.Find("cart_text").GetComponent<Text>();
        cart_text.text = foodlist.Count.ToString();

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

        if (scene.name == "type_select" )
        {
            cart_text = GameObject.Find("cart_text").GetComponent<Text>();
            cart_btn = GameObject.Find("cart_btn").GetComponent<Button>();
            move = GetComponent<MoveScene>(); 
            cart_text.text = foodlist.Count.ToString();



            cart_btn.GetComponent<Button>().onClick.AddListener((() => move.Cart_scene()));
        }
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
            cart_text = GameObject.Find("cart_text").GetComponent<Text>();
            cart_text.text = foodlist.Count.ToString();

            profile_btn = GameObject.Find("profile_btn").GetComponent<Button>();
            profile_btn.GetComponent<Button>().onClick.AddListener((() => enable_profile_field())); 
            close_profile = GameObject.Find("close_profile_btn").GetComponent<Button>();
            close_profile.GetComponent<Button>().onClick.AddListener((() => enable_profile_field()));
            create_instnce = false;


            calorie_txt.text = calorie.ToString(); 

            value.text = price.ToString();

         


            if (foodHolder.childCount < 1)
            {
                int child_v = content_delete.childCount;
                for (int chi = child_v - 1; chi >= 0; chi--)
                {

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
        if (scene.name == "type_select")
        {
            cart_text = GameObject.Find("cart_text").GetComponent<Text>();
            cart_btn = GameObject.Find("cart_btn").GetComponent<Button>();
            move = GetComponent<MoveScene>();
            cart_text.text = foodlist.Count.ToString();



            cart_btn.GetComponent<Button>().onClick.AddListener((() => move.Cart_scene()));

            if (foodHolder.childCount > 0)
            {

                int child_v = foodHolder.childCount;
                for (int chi = child_v - 1; chi >= 0; chi--)
                {


                    Destroy(foodHolder.GetChild(chi).gameObject);


                }
            }
        }

        if (scene.name == "box_scene")
        {


            foodHolder.transform.position = new Vector3(-0.66f, 1.06f, -1.58f); 



        }
        if (scene.name == "Cart")
        {

            cart = GameObject.Find("Canvas").GetComponent<cart_script>(); 
            pay_btn = GameObject.Find("pay_btn").GetComponent<Button>();
            pay_btn.GetComponent<Button>().onClick.AddListener((() => finalize()));
         


        }
    }

    void enable_profile_field()
    {
        if (create_instnce == false)
        { create_instnce = true; }
        else
        {
            create_instnce = false;
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

       
    }

    public void activate_delete()
    {
        if (b_desrtroy == false) { b_desrtroy = true; }
        else { b_desrtroy = false; }
    }

   
    void instance_of_food(string v2)
    {
        
      
        GameObject food_obj = Resources.Load<GameObject>("prefab/Burger3D/" + v2);
        Vector3 mousepos = Input.mousePosition;
        Vector3 platepos = gameObject.transform.position + new Vector3(0 + 0.01f, 0);


       
        try
        {


            //   mousepos.z = Random.Range(-2f, 2f);
            // mousepos.y = 2.9f;
            //   mousepos.x = Random.Range(-2f, 2f);
            //   if (food_obj.transform.localScale.x > 100)
            //   {
            //       Instantiate(food_obj, new Vector3(0, 4f, 0), Quaternion.Euler(-90f, 0, 0));
            //   }
            //   else {


            if (food_obj.tag == "supreme_pizza_bread"|| food_obj.tag == "mini_pizza_bread" || food_obj.tag == "triangle_pizza_bread"|| food_obj.tag == "burger_bread")
            {

                PlayerPrefs.SetString("box_type" , food_obj.tag);
                if (foodHolder.childCount > 0 && foodHolder.GetChild(0).gameObject.name.Substring(0, 6) != food_obj.name)
                {
                    deduct(foodHolder.GetChild(0).gameObject.name.Substring(0, 6));
                    Destroy(foodHolder.GetChild(0).gameObject);
                    Instantiate(food_obj, new Vector3(0, 0.1f, 0), Quaternion.identity, foodHolder);
                    base_ingred(food_obj.name);
                    create_delete_group(food_obj.name);
                    create_instnce = true;
                }

                else if (foodHolder.childCount == 0)
                {
                    Instantiate(food_obj, new Vector3(0, 0.1f, 0), Quaternion.identity, foodHolder);
                    base_ingred(food_obj.name);
                    create_delete_group(food_obj.name);
                    create_instnce = true; 
                }
                else { Debug.Log("nope"); }
               
            }
        
               
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;


            if (Physics.Raycast(ray, out hit) && food_obj.tag == "food_tag")
            {
                if (hit.collider.tag == "food_tag" || hit.collider.tag == "plate_tag" || hit.collider.tag == "supreme_pizza_bread" || hit.collider.tag == "mini_pizza_bread" || hit.collider.tag =="burger_bread")
                {

                    // Debug.Log("turn is over");
                    // Debug.Log("number of keys and values" + food_dict.Count);
                    Instantiate(food_obj, hit.point, Quaternion.Euler(0,Random.Range(0,180f), 0), foodHolder);
                    
                    manage_ingred(food_obj.name);
                    create_delete_group(food_obj.name);
                    Debug.Log("foodobj: "+ food_obj.name);
                  
                }
            }
           


        }
        catch { }


    }
    bool base_exist = false; 
    public void base_ingred(string name)
    {
        foreach (var item in ListIngred)
        {
            if (item.ingred_name == name)
            {
                item.ingred_amount = item.ingred_amount + 1;
                base_exist = true;
            }
        }
            if(base_exist == false)
            {
                Ingredient newbase = new Ingredient();
                newbase.ingred_name = name;
                newbase.ingred_amount = 1;
                ListIngred.Add(newbase);
            base_exist = true; 

            }

        base_exist = false; 
        calculate(name);

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
        

        for (int i = 0; i < n_scr_Restoran.food_input_list.Count; i++)
        {
            if (name == n_scr_Restoran.food_input_list[i].input_name)
            {
                Debug.Log("name : " + name + " list item name " + n_scr_Restoran.food_input_list[i].input_name); 
                string str_cost = n_scr_Restoran.food_input_list[i].input_cost;
                Debug.Log("strCost : "+ str_cost);
               decimal dec_cost = System.Convert.ToDecimal(str_cost);
               price = price + (dec_cost);

                string str_calorie = n_scr_Restoran.food_input_list[i].input_calorie;
                Debug.Log("strCal : " + str_calorie);
                int int_Calorie = System.Convert.ToInt16(str_calorie);
                calorie = calorie + int_Calorie;


            }
        }


     

        value.text = price.ToString();
        calorie_txt.text = calorie.ToString();
    }




    public void deduct(string name)
    {
        
   
     

        for (int i = 0; i <n_scr_Restoran.food_input_list.Count; i++)
        {
            if (name == n_scr_Restoran.food_input_list[i].input_name)
            {
                string str_cost = n_scr_Restoran.food_input_list[i].input_cost;
                decimal dec_cost = System.Convert.ToDecimal(str_cost);
                price = price - (dec_cost);

                string str_calorie = n_scr_Restoran.food_input_list[i].input_calorie;
                int int_Calorie = System.Convert.ToInt16(str_calorie);
                calorie = calorie - int_Calorie;


            }

           
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
      //  final_info.information = ListInfo.ToArray();
        Saved_calorie = calorie;
        Saved_price = price; 

       
      //  StreamWriter writer = new StreamWriter(writepath());
      //  writer.WriteLine("[");
      //  foreach (var item in ListInfo)
      //  {
      //      writer.WriteLine("{" + '"' + "Calorie " + '"' + ":" + '"' + item.food_calorie + '"' + "," + '"' + "price " + '"' + ":" + '"' + item.food_price + '"' + "," + '"' + "name " + '"' + ":" + '"' + item.food_name + '"' + "}"+",");
      //    
      //  }
      //  foreach (var item in ListIngred)
      //  {
      //      writer.WriteLine("{" + '"' + "food_id " + '"' + ":" + '"' + item.ingred_name + '"' + "," + '"' + " amount " + '"' + ":" + '"' + item.ingred_amount + '"' + "},");
      //
      //  }
      //  writer.WriteLine("{}]");
      //  writer.Close();
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
        newfood.food_ingred = ListIngred.ToArray();
        newfood.foodcalorie = calorie_txt.text;
        newfood.foodamount = 1.ToString(); 
        return newfood; 

    }
    #endregion



    #region jsonpath
  //  public string writepath()
  //  {
  //      string str_path = Path.Combine(Application.dataPath, "foodInscene.json");
  //      return str_path;
  //  }

    

    #endregion




    #region Delete function
   

  
    void create_delete_group(string spritecode)
     {
        Debug.Log("group_delete"); 
         delete_group_ar = new GameObject[foodHolder.childCount];
        
         for (int i = 0; i <= ListIngred.Count; i++)
         {
            Debug.Log("group_delete_ in For");
            if (content_delete.Find(spritecode+"(Clone)") == null)
             {
                Debug.Log("group_delete");
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
            if (hit.collider.tag == "food_tag"|| hit.collider.tag == "foodbase_tag"|| hit.collider.tag == "supreme_pizza_bread" || hit.collider.tag == "mini_pizza_bread" || hit.collider.tag == "triangle_pizza_bread" || hit.collider.tag == "burger_bread")
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


    public void finalize()
    {

        final(); 

    }
    public void final()
    {
        
        final_info.foods = foodlist.ToArray(); 
       final_info.address = GameObject.Find("adress_input").GetComponent<TMP_InputField>().text;
        final_info.cordinates = cart.location; 
        final_info.total = GameObject.Find("total_text").GetComponent<Text>().text;
        StartCoroutine(send_panel(url_sender));

    }
    [SerializeField]
    private string url_sender = "https://smartbnd.ir/api/v1/saveRequest";

    IEnumerator send_panel(string url)
    {
        // int number = 09155151515;
        Debug.Log("starting");
        WWWForm form = new WWWForm();

        form.AddField("project_name", "gargot");//ok
        form.AddField("product_name", "username.text");//food name
        form.AddField("name", foodlist[0].foodname);//
        form.AddField("sub_category", "username.text");//
        form.AddField("product_image", foodlist[0].foodImage);
        form.AddField("cost", cart.total_amount.ToString());
        form.AddField("calary", foodlist[0].foodcalorie);
        form.AddField("product_detail", foodlist[0].food_ingred.ToString());
        form.AddField("request_name", "food request");//ok
        form.AddField("organ_name", "username.text");
        form.AddField("user_id", PlayerPrefs.GetString("phone_number"));//number
        form.AddField("detail", foodlist[0].foodamount  );//address
        form.AddField("x_loc", "26");
        form.AddField("y_loc", "27");
        form.AddField(" send_address", "GameObject.Find(adress_input).GetComponent<TMP_InputField>().text");




        UnityWebRequest uu = UnityWebRequest.Post(url, form);
        yield return uu.SendWebRequest();
        if (uu.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log("not network");
        }
        else
        {
            Debug.Log("sent");

            Debug.Log("results are :" + uu.result.ToString()); 



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

    public Ingredient[] food_ingred;
    public string foodImage;
    public string foodcalorie; 
    public string foodamount; 


 

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
    public Food[] foods;
    public string address;
    public string cordinates; 
    public string total; 

}


#endregion