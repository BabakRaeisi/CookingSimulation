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
    private Button done_btn, reset_btn,  cart_btn;
    [SerializeField]
    private Transform content_del, foodholder, scroll_Delete;
 
    public GameObject[] delete_group_ar;
    

    private void Awake()
    {
        inst = GameObject.Find("plate").GetComponent<instantiation>();
        
        done_btn = GameObject.Find("done").GetComponent<Button>();
        reset_btn = GameObject.Find("reset_btn").GetComponent<Button>();
      //  delete_btn = GameObject.Find("delete_key").GetComponent<Button>();
        cart_btn = GameObject.Find("cart_btn").GetComponent<Button>();
      
      //  cart_btn.GetComponent<Button>().onClick.AddListener((() => Cart_scene()));
        
        content_del = GameObject.Find("content_delete").GetComponent<Transform>();
        foodholder = GameObject.Find("foodholder").GetComponent<Transform>();

        scroll_Delete = GameObject.Find("Viewport_del").GetComponent<Transform>();

        reset_btn.GetComponent<Button>().onClick.AddListener((() => inst.remove_all()));
      // delete_btn.GetComponent<Button>().onClick.AddListener((() =>  activate_delete()));
    }
    void Start()
    {
        inst = GameObject.Find("plate").GetComponent<instantiation>();
       // delete_btn.GetComponent<Button>().onClick.AddListener((() => inst.activate_delete()));

        trashbin.SetActive(false);
        active_trash = false;
        if (inst.foodlist.Count > 0)
        {
            cart_btn.GetComponent<Button>().onClick.AddListener((() => Cart_scene()));
        }

    }
   
   
 
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

   public void activate_delete()
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
    public void Cart_scene()
    { SceneManager.LoadScene("Cart"); }
}
