using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
public class cart_script : MonoBehaviour
{
    [SerializeField]
    private instantiation inst;
    [SerializeField]
    private GameObject content;
    private Transform cart_content;
    public Transform foodHolder;

    public  Text total_text; 
    [SerializeField]
    public decimal total_amount =0 ; 

    private void Awake()
    {
        inst = GameObject.Find("plate").GetComponent<instantiation>();
        cart_content = GameObject.Find("Cart_content").GetComponent<Transform>();
        total_text  = GameObject.Find("total_text").GetComponent<Text>(); 
        
    }
    private void OnLevelWasLoaded(int level)
    {

        foodHolder = GameObject.Find("foodholder").GetComponent<Transform>();
        AssetDatabase.Refresh(); 
        if (foodHolder.childCount > 0)
        {

            int child_v = foodHolder.childCount;
            for (int chi = child_v - 1; chi >= 0; chi--)
            {


                Destroy(foodHolder.GetChild(chi).gameObject);


            }
        }

        if (level == 2)
        {

            inst = GameObject.Find("plate").GetComponent<instantiation>();

            for (int i = 0; i < inst.foodlist.Count; i++)
            {
                Instantiate(content,cart_content);
            }
            
            int coun_content = cart_content.childCount;
           
            for (int i = 0; i < coun_content; i++)
            {

               //  cart_content.GetChild(i).Find("food_img").GetComponent<Image>().sprite = Resources.Load<Sprite>(inst.foodlist[i].foodname + ".png");
                Texture2D tex = Resources.Load<Texture2D>(inst.foodlist[i].foodname) as Texture2D;
                if(tex != null)
                {
                    Debug.Log("tex is filled with somthing "); 
                   Sprite sprite = Sprite.Create(tex, new Rect(0, 0, 100, 100), new Vector2(0.5f, 0.5f),40);
                    cart_content.GetChild(i).Find("food_img").GetComponent<Image>().sprite = sprite;
                }
               

                cart_content.GetChild(i).Find("price_tag").GetComponent<Text>().text = (inst.foodlist[i].foodprice);
                cart_content.GetChild(i).Find("foodname").GetComponent<Text>().text = (inst.foodlist[i].foodname);
               // total_amount = total_amount + System.Convert.ToDecimal(inst.foodlist[i].foodprice);
               // total_text.text = total_amount.ToString(); 
            }
        }


      


    }


    public void calculate_total()
    {
        total_text.text = total_amount.ToString(); 
    }

   
}
