using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class rewire_buttons : MonoBehaviour
{
    private GameObject D_obj;
    private Text Calorie, price;

    public GameObject popUp , trashbin;

    [SerializeField]
    private instantiation inst;
    [SerializeField]
    private InputField inp_food_name;
    [SerializeField]
    private Button done_btn, reset_btn, delete_btn;
    [SerializeField]
    private Transform content_del, foodholder, scroll_Delete;
 
    public GameObject[] delete_group_ar;
    

    private void Awake()
    {
        inst = GameObject.Find("plate").GetComponent<instantiation>();
        
        done_btn = GameObject.Find("done").GetComponent<Button>();
        reset_btn = GameObject.Find("reset_btn").GetComponent<Button>();
        delete_btn = GameObject.Find("delete_key").GetComponent<Button>();


        content_del = GameObject.Find("content_delete").GetComponent<Transform>();
        foodholder = GameObject.Find("foodholder").GetComponent<Transform>();

        scroll_Delete = GameObject.Find("Viewport_del").GetComponent<Transform>();

        reset_btn.GetComponent<Button>().onClick.AddListener((() => inst.remove_all()));
      // delete_btn.GetComponent<Button>().onClick.AddListener((() =>  activate_delete()));
    }
    void Start()
    {
        inst = GameObject.Find("plate").GetComponent<instantiation>();
        delete_btn.GetComponent<Button>().onClick.AddListener((() => inst.activate_delete()));

        trashbin.SetActive(false);
        active_trash = false;


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
           // inst = GameObject.Find("plate").GetComponent<instantiation>();
           //
           // done_btn = GameObject.Find("done").GetComponent<Button>();
           // reset_btn = GameObject.Find("reset_btn").GetComponent<Button>();
           // delete_btn = GameObject.Find("delete_key").GetComponent<Button>();


           // content_del = GameObject.Find("content_delete").GetComponent<Transform>();
           // foodholder = GameObject.Find("foodholder").GetComponent<Transform>();
           //
           // scroll_Delete = GameObject.Find("Viewport_del").GetComponent<Transform>();



           // reset_btn.GetComponent<Button>().onClick.AddListener((() => inst.remove_all()));
           // delete_btn.GetComponent<Button>().onClick.AddListener(delegate { activate_delete(); Debug.Log("well recieved"); });







        }
    }
   //private void OnLevelWasLoaded(int level)
   //
   //  
   //
   // if(level==0)
   // {
   //       inst = GameObject.Find("plate").GetComponent<instantiation>();
   //
   //       done_btn = GameObject.Find("done").GetComponent<Button>();
   //       reset_btn = GameObject.Find("reset_btn").GetComponent<Button>();
   //       delete_btn = GameObject.Find("delete_key").GetComponent<Button>();
   //
   //
   //       content_del = GameObject.Find("content_delete").GetComponent<Transform>();
   //       foodholder = GameObject.Find("foodholder").GetComponent<Transform>();
   //
   //       scroll_Delete=GameObject.Find("Viewport_del").GetComponent<Transform>();
   //
   //
   //       reset_btn.GetComponent<Button>().onClick.AddListener((() => inst.remove_all()));
   //       delete_btn.GetComponent<Button>().onClick.AddListener((() => inst.activate_delete()));
   //       done_btn.GetComponent<Button>().onClick.AddListener((() => inst.create_instnce = true));


      //  if (foodholder.childCount > 0)
      //    { 
      //    delete_group_ar = new GameObject[foodholder.childCount];
      //  
      //    for (int i = 0; i < foodholder.childCount; i++)
      //    {
      //            if (content_del.Find(inst.ListIngred[i].ingred_name) == null)
      //            {
      //               
      //                D_obj = Resources.Load("btn_D") as GameObject;
      //                D_obj.transform.name = inst.ListIngred[i].ingred_name;
      //                delete_group_ar[i] = Instantiate(D_obj, new Vector3(0, 0, 0), scroll_Delete.transform.rotation);
      //                delete_group_ar[i].transform.SetParent(content_del);
      //                delete_group_ar[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("sprite/sprite_del/" + D_obj.transform.name);
      //                delete_group_ar[i].GetComponent<Button>().onClick.AddListener((() => Delete_group(D_obj.transform.name)));
      //            }
      //    }
      //        
      // }
        // Calorie = GameObject.Find("Calorie_Indicator").GetComponent<Text>();
       //  price = GameObject.Find("Price_Indicator").GetComponent<Text>();

           
            
     // }

  //  }
   
 
    public void popup()
    {
        if (foodholder.childCount > 0)
        {
            popUp.SetActive(true);
            inst.create_instnce = true;
        }
    }
    public void disablePopUp()
    {
        popUp.SetActive(false);
      
    }
    bool active_trash = false; 
    public void trashBin()
    {
        if (active_trash == false)
        {
            trashbin.SetActive(true);
            active_trash = true;
        }
        else
        { trashbin.SetActive(false);
            active_trash = false; 
        }

    }

    void activate_delete()
    {
        if (inst.b_desrtroy == false) { inst.b_desrtroy = true; }
        else { inst.b_desrtroy = false; }

    }

    private void Delete_group(string code)
    {
        if (foodholder.childCount > 0)
        {
      
            int child_v = foodholder.childCount;
            for (int chi = child_v - 1; chi >= 0; chi--)
            {
      
                if (code + "(Clone)" == foodholder.GetChild(chi).name)
                {
                    Destroy(foodholder.GetChild(chi).gameObject);
                    inst.deduct(code);
                }
      
      
      
            }
        }
      
      
      
        for (int i = 0; i < inst.ListIngred.Count; i++)
        {
            if (inst.ListIngred[i].ingred_name == code)
            {
      
                inst.ListIngred.RemoveAt(i);
            }
        }

    }
}
