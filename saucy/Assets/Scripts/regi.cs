using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
public class regi : MonoBehaviour
{



    public Text txt_onlline_show;
    //my pc ip is :   100.127.255.249
    //  public GetUser n_getUser;
    public string phone_number_go_to_main_page;
    [SerializeField] public Text error;
    [SerializeField] public Text txt3, txt2, txt4;
    [SerializeField] UnityEngine.UI.InputField username;
    [SerializeField] UnityEngine.UI.InputField phone_number;
    public bool b_login = false;
    [SerializeField] private string ur = "https://hormuzpay.com/main_entities_mysql/user/Authentication/web_service_register_any_app.php?";

    public string new_log = "https://hormuzpay.com/main_entities_mysql/user/Authentication/web_service_login_phone_any_app.php?";

    public static string result;
    public string str_test = result;
    void Start()
    {

        // StartCoroutine(PostRequest("https:///https://hormuzpay.com/main_entities_mysql/user/Authentication/web_service_register_any_app.php?"));
    }
    public void fun_register_btn()
    {
        StartCoroutine(PostRequest(ur));
    }
    IEnumerator PostRequest(string url)
    {
        WWWForm form = new WWWForm();
        form.AddField("fname", username.text);
        form.AddField("family", username.text);
        form.AddField("user_name", username.text);



        form.AddField("phone_number", phone_number.text);
        phone_number_go_to_main_page = phone_number.text;
        UnityWebRequest uwr = UnityWebRequest.Post(url, form);
        yield return uwr.SendWebRequest();

        if (uwr.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log("Error While Sending: " + uwr.error);
        }
        else
        {
            Debug.Log("Reved: " + uwr.downloadHandler.text);
            b_login = true;

        }
    }


    public void fun_btn_log2()
    {
        //StartCoroutine(log2(loginUrl));
    }
    //56789012314 
    /*
    IEnumerator log2(string url) {
        int i_id = 55;
        
      ///  WWW w = new WWW(loginUrl +"phone_number"+ phone_number.text);
       // yield return w;

        if (w.error == null)
        {

            error.color = Color.green;
            error.text = "okkkk brrrrrrrrrem beza";
            //User_online n_user_online = JsonUtility.FromJson<User_online >(w.text);
          //  yield return new WaitForSeconds(0.5f);

            // Debug.Log("user_online " + n_user_online.phon_number );
            txt3.text = "666666666666666666666";

        }
        else
        {

//User_online ne_user_online = JsonUtility.FromJson<User_online>(w.text);

            //string json = System.Text.Encoding.UTF8.GetString(w.bytes, 3,w.bytes.Length - 3);
            error.color = Color.red;
            error.text = "login ba moshkel barkhord";
          
        }


    }

    */
    public void LoginBtn()
    {
        if (phone_number.text.Length > 0)
        {
            StartCoroutine(_Login(new_log));

        }
        else
        {
            error.color = Color.red;
            error.text = "Lotfa input field ha ra por konid";
        }
    }


    public bool is_error = false, b_invalid = false;

    //56789012314 
    IEnumerator _Login(string url)
    {
        //   UnityWebRequest METARInfoRequest = UnityWebRequest.Get(loginUrl + phone_number.text);
        // WWW ww = new WWW(loginUrl + "phone_number" + phone_number.text);
        WWWForm form = new WWWForm();
        form.AddField("phone_number", phone_number.text);
        str_test = phone_number.text;
        UnityWebRequest uwr = UnityWebRequest.Post(new_log, form);
        yield return uwr.SendWebRequest();

        if (uwr.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log("Error While Sending: " + uwr.error);
            txt3.text = "00000000000000000000000000000000";

        }
        else
        {

            try
            {
                byte[] token = uwr.downloadHandler.data;
                string result1 = Encoding.Default.GetString(token);
                result = System.Text.Encoding.UTF8.GetString(token);
                Debug.Log(uwr.downloadHandler.text);
                // Debug.Log("result1 = " + result1);
                // Debug.Log("result = " + result);
                txt2.text = uwr.downloadHandler.text;
                txt3.text = result;

                if (txt2.text == Convert.ToString(13000))
                {
                    b_invalid = true;

                }
                else
                {
                    b_invalid = false;
                }

                if (b_invalid)
                {
                    error.text = "Invalid phone number";
                }
                else if (b_invalid == false)
                {
                    str_test = txt3.text;
                    txt_onlline_show.text = System.Text.Encoding.UTF8.GetString(token);
                    SceneManager.LoadScene("Game");
                    str_test = System.Text.Encoding.UTF8.GetString(token);

                    Debug.Log("result = " + result);
                }

            }
            catch (System.Exception)
            {

                error.text = " not valid";
            }

            //Debug.Log("Reved: " + uwr.downloadHandler.text);


            //  b_login = true;
            // txt3.text = username.text;
            //Debug.Log("ok  :" + username.text);
            //  Debug.Log("Reved: " + uwr.downloadHandler.text);
            //  txt3.text = "1111111111";

            //  JSONNode METARInfo = JSON.Parse(METARInfoRequest.downloadHandler.text);

            // var ne_user_online = JsonUtility.FromJson<User_online>(uwr.downloadHandler .text);

        }
        /*  else
          {
              if (w.isDone)
              {
                  if (w.text.Contains("error")) 
                  {
                      txt3.text = "server erorr";
                  }
                  else
                  {
                      SceneManager.LoadScene("Game");
                  }
              }

              //  Debug.Log("Reved: " + uwr.downloadHandler.text);

          }*/
    }
    /*
                if (ww.text[0] == '0')
                {
                    Debug.Log("User Login Success.");
                }
                else
                {
                    Debug.Log("User Login Failed.");
                }
                string responseText = uwr.downloadHandler.text;
                if (responseText.StartsWith("Success"))
                {
                    string[] dataChunks = responseText.Split('|');

                      Debug.Log("Received: " + uwr.downloadHandler.text);
                    b_login = true;
                    error.text = "okkkk brrrrrrrrrem beza";
                    SceneManager.LoadScene("Game");

                }
    */
    //error.text = "login ba moshkel barkhord";


    /*
    txt3.text = Convert.ToString("phone_number=" + email.text);
     txt3.text = Convert.ToString("phone_number=" + email.text);
    yield return ww;

    if (ww.error == null)
    {
        error.color = Color.green;
        error.text = "okkkk brrrrrrrrrem beza";
        yield return new WaitForSeconds(0.5f);

    }
    else
    {
        error.color = Color.red;
        error.text = "login ba moshkel barkhord";
    }*/
    // }//




    // Update is called once per frame
    void Update()
    {
        str_test = txt3.text;
    }
    public class User_online
    {
        public string user_name, phone_number;


    }
    [System.Serializable]
    public class People
    {
        public string user_name, phone_number;

    }
    public class PeopleList
    {
        public People[] users;
    }

}


