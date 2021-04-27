using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class box_select : MonoBehaviour
{
    [SerializeField]
    private Transform Box_holder , box_selection , foodHolder;
    private instantiation inst;
    private MoveScene movescene; 
    [SerializeField]
    GameObject[] box_array , box_type;


    public GameObject btn_object;

    private Button btn1, btn2, btn3, btn4;

    public string box;


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
        inst = GameObject.Find("plate").GetComponent<instantiation>();
       movescene = GameObject.Find("plate").GetComponent<MoveScene>();
        box_type = new GameObject[box_array.Length]; 
        if (scene.name == "box_scene")
        {
            foodHolder = GameObject.Find("foodholder").GetComponent<Transform>();
            foodHolder.transform.position = new Vector3(-0.66f, 1.06f, -1.58f);
            box = PlayerPrefs.GetString("box_type"); 

            for (int i = 0; i < box_array.Length; i++)
            {
                if (box_array[i].transform.tag == box)
                {
                    create_button(box_array[i].name); 
                }
        
            }

            
        }
    }

    public void create_button(string boxname )
    {
        for (int i = 0; i < box_array.Length; i++)
        {
            if (box_selection.Find(boxname) == null)
            {
                box_type[i] = Instantiate(btn_object,box_selection);
                box_type[i].transform.name = boxname;
                box_type[i].gameObject.GetComponent<Image>().sprite  = Resources.Load<Sprite>("sprite/box_sprite/" + boxname);
                box_type[i].gameObject.GetComponent<Button>().onClick.AddListener((() => newbox(boxname))); 

            }
        }


    }
    public void newbox(string boxname)
    {
        if (Box_holder.childCount > 0)
        {
            Destroy(Box_holder.GetChild(0).gameObject);
        }
        GameObject box = Resources.Load<GameObject>("prefab/boxes/" + boxname);

        Instantiate(box, new Vector3(0, 0, 0), Quaternion.Euler(0, -156f , 0), Box_holder); 
        
    }


  //  public void add_box_to_order()
  //  {
  //      if (Box_holder.childCount > 0)
  //      {
  //          string price = Box_holder.GetChild(0).GetComponent<pizzabox>().price;
  //          foreach (var item in inst.foodlist)
  //          {
  //              if (item.foodbox_price == null && item.foodbox_name == null)
  //              {
  //                  item.foodbox_price = price;
  //                  item.foodbox_name = Box_holder.GetChild(0).name; 
  //    
  //              }
  //          }
  //      }
  //    
  //
  //  }

    public void proceeding()
    {
       if (Box_holder.childCount > 0)
       {
           movescene.type_select();
       }
    }
}
