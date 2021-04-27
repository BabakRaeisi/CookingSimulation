using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;
using SimpleJSON;

public class cart_script : MonoBehaviour
{
    [SerializeField]
    private instantiation inst;
    [SerializeField]
    private GameObject content;
    private Transform cart_content;
    public Transform foodHolder;
    public string location; 
    public  Text total_text; 
    [SerializeField]
    public decimal total_amount =0 ; 

    private void Awake()
    {
        inst = GameObject.Find("plate").GetComponent<instantiation>();
        cart_content = GameObject.Find("Cart_content").GetComponent<Transform>();
        total_text  = GameObject.Find("total_text").GetComponent<Text>(); 
        
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

      

            foodHolder = GameObject.Find("foodholder").GetComponent<Transform>();
       // AssetDatabase.Refresh(); 
        if (foodHolder.childCount > 0)
        {

            int child_v = foodHolder.childCount;
            for (int chi = child_v - 1; chi >= 0; chi--)
            {


                Destroy(foodHolder.GetChild(chi).gameObject);


            }
        }

        if (scene.name == "Cart")
        {
            location = PlayerPrefs.GetString("location");
            inst = GameObject.Find("plate").GetComponent<instantiation>();
            
            for (int i = 0; i < inst.foodlist.Count; i++)
            {
                Instantiate(content,cart_content);
            }
            
            int coun_content = cart_content.childCount;
           
            for (int i = 0; i < coun_content; i++)
            {
                
               //  cart_content.GetChild(i).Find("food_img").GetComponent<Image>().sprite = Resources.Load<Sprite>(inst.foodlist[i].foodname + ".png");
                // Texture2D tex = Resources.Load<Texture2D>(inst.foodlist[i].foodname) as Texture2D;
                 Texture2D tex = new Texture2D(1, 1, TextureFormat.ARGB32, false);
                 tex.LoadImage(System.Convert.FromBase64String(PlayerPrefs.GetString(inst.foodlist[i].foodname)));
               Debug.Log(PlayerPrefs.GetString(inst.foodlist[i].foodname)) ;

                if (tex != null)
                {
                    
                    Debug.Log("tex is filled with somthing ");
                   //  Sprite sprite_sc = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(.5f, .5f),128);
                   //   Debug.Log("asasasasasasasas" + sprite_sc.ToString());
                    // Sprite sprite = Sprite.Create(tex, new Rect(0, 0, 100, 100), new Vector2(0.5f, 0.5f),40);
                     cart_content.GetChild(i).Find("food_img").GetComponent<Image>().sprite= Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(.5f, .5f), 128);
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

    //pay function
    public void pay_fun()
    {
        StartCoroutine(Ie_pay_panel(str_login));
    }
    public string port_bank_url = "https://hormuzpay.com/EWallet/payment/sendPay.php";
    public string str_login = "https://smartbnd.ir/api/v1/login";
    public string QR = null;

    IEnumerator Ie_pay_panel(string url2)
    {
        // int number = 09212246850;

        WWWForm form = new WWWForm();
        JSONNode jdata23;

        form.AddField("phone_number", PlayerPrefs.GetString("phone_number"));
        UnityWebRequest uu = UnityWebRequest.Post(url2, form);
        Debug.Log("login");

        yield return uu.SendWebRequest();
        if (uu.isNetworkError)
        {
            Debug.Log("not network");
        }
        else
        {

            Debug.Log("login..." + PlayerPrefs.GetString("phone_number"));

            jdata23 = JSON.Parse(uu.downloadHandler.text);
            Debug.Log("uu..." + uu.downloadHandler.text);
            QR = jdata23["data"]["QR"];
            Debug.Log("jdata :" + QR);
            string scription = "poool vadeh";
            if (QR != null)
            {


                Application.OpenURL(port_bank_url + "?" + "Amount=" + total_text.text + "&qr=" + QR + "&Description=" + scription);
                Debug.Log("Ba movafaghiat sabt nam anjam shod");
            }
            else
            {
                // QR = "$2b$10$9XbrQbR09FNPHx/jjDrso.onWSqbNEbfbdf7rZ44OmZaknOmEYiFK";
                Application.OpenURL(port_bank_url + "?" + "Amount=" + total_text.text + "&qr=" + QR + "&Description=" + scription);
                Debug.Log("Ba movafaghiat sabt nam anjam shod");
            }
        }

    }


}
