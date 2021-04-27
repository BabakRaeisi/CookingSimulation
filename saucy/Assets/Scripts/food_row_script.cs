using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class food_row_script : MonoBehaviour
{
    
    [SerializeField]
    private Text price_tag;
    [SerializeField]
    private instantiation inst; 
    private cart_script cart; 

    [SerializeField]
    private Text amount ; 

    private Text food_name;
    private Image image;

    private int int_amount =  0;

    private decimal dec_price ;
    private decimal final_price; 



    private void Awake()
    {
        cart = GameObject.Find("Canvas").GetComponent<cart_script>();
        inst = GameObject.Find("plate").GetComponent<instantiation>(); 

    }

    private void Start()
    {
        dec_price = System.Convert.ToDecimal(price_tag.text);
        
        int_amount = System.Convert.ToInt32(amount.text);
        cart.total_amount += dec_price;
        cart.total_text.text = cart.total_amount.ToString();

        food_name = gameObject.transform.Find("foodname").GetComponent<Text>();
    }


    public void increase()
    {

        dec_price = System.Convert.ToDecimal(price_tag.text);
        int_amount++;

        cart.total_amount += dec_price; 

        amount.text = int_amount.ToString();
        cart.calculate_total();


        foreach (var item in inst.foodlist)
        {
            if (item.foodname == food_name.text)
            {
                item.foodamount = int_amount.ToString(); 

            }
        }

    }
    
     public void decrease()
    {
        if (int_amount > 0)
        {
            dec_price = System.Convert.ToDecimal(price_tag.text);
            int_amount--;
            cart.total_amount -= dec_price;

            amount.text = int_amount.ToString();
            cart.calculate_total();

            foreach (var item in inst.foodlist)
            {
                if (item.foodname == food_name.text)
                {
                    item.foodamount = int_amount.ToString();

                }
            }
        }
    }

}
