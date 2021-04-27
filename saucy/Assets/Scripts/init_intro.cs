using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using SimpleJSON;
using System.IO;

public class init_intro : MonoBehaviour
{

    // [SerializeField] private string url_register = "https://hormuzpay.com/main_entities_mysql/user/Authentication/web_service_register_any_app.php?";
    /// <summary>
    /// ////////////////main
    /// </summary>

    [SerializeField]
    private string url_register = "https://smartbnd.ir/api/v1/register";
    public string url_login = "https://smartbnd.ir/api/v1/login";


    public string new_log = "https://hormuzpay.com/main_entities_mysql/user/Authentication/web_service_login_phone_any_app.php?";
    public string url_sms = "https://api.kavenegar.com/v1/687176565938433253777741444C77455276326A5457307A6F46697A324F712B3353704249674E6B5239733D/verify/lookup.json";

    [SerializeField] UnityEngine.UI.InputField input_username, input_family, input_national_code;
    [SerializeField] UnityEngine.UI.InputField input_phone_number, input_token, input_number_login;
    public int rnd_token = 00000;
    string token;
    public bool b_login = false;



    [SerializeField]
    public Button arabi_btn, farsi_btn, english_btn;
    [SerializeField]
    private GameObject lan_panel, sign_panel, arabi, parsi, english,
        login, signup, signup_panel,
        mainsignup, mainsign_btn,
        log_panel, mainlogin_btn
        ;

    [SerializeField]
    private LeanTweenType type;

    [SerializeField]
    private LeanTweenType act;
    [SerializeField]
    private LeanTweenType ease;

    public float time;
    private void Awake()
    {
        Debug.Log(PlayerPrefs.GetString("lancode"));
        Debug.Log(PlayerPrefs.GetString("user_name"));
        Debug.Log("empty" + PlayerPrefs.GetString("fname"));
        // signup_panel
        mainlogin_btn = GameObject.Find("Button_mainlogin_btn");
        mainsignup = GameObject.Find("signup_panel");
        mainsign_btn = GameObject.Find("signup_btn");
        lan_panel = GameObject.Find("lan_panel");
        sign_panel = GameObject.Find("sign_panel");
        signup_panel = GameObject.Find("sign_panel");
        log_panel = GameObject.Find("login_panel");
        // mainsignup = GameObject.Find("signup_panel");

        login = GameObject.Find("log_btn");
        signup = GameObject.Find("sign_btn");


        arabi = GameObject.Find("arab_btn");
        parsi = GameObject.Find("parsi_btn");
        english = GameObject.Find("english_btn");


        input_number_login = GameObject.Find("input_number_login").GetComponent<InputField>();


        input_username = GameObject.Find("input_name").GetComponent<InputField>();
        input_family = GameObject.Find("input_family").GetComponent<InputField>();
        input_phone_number = GameObject.Find("input_number").GetComponent<InputField>();
        input_national_code = GameObject.Find("input_national_code").GetComponent<InputField>();
        input_token = GameObject.Find("input_token_sms").GetComponent<InputField>();
        farsi_btn = GameObject.Find("parsi_btn").GetComponent<Button>();
        arabi_btn = GameObject.Find("arab_btn").GetComponent<Button>();
        english_btn = GameObject.Find("english_btn").GetComponent<Button>();
        Debug.Log(PlayerPrefs.GetString("user_name"));
        if (PlayerPrefs.GetString("lancode") != null)
        {
            log_sign(PlayerPrefs.GetString("lancode"));
            PlayerPrefs.Save();
        }

        PlayerPrefs.SetString("b_switch_page", "false");
        PlayerPrefs.Save();
        if (PlayerPrefs.HasKey("lancode") && PlayerPrefs.HasKey("fname") && PlayerPrefs.GetString("b_switch_page") == "false")
        {

            PlayerPrefs.SetString("b_switch_page", "true");
            PlayerPrefs.Save();
            SceneManager.LoadScene("CVV2");
        }
        if (PlayerPrefs.GetString("b_switch_page") == "true" && PlayerPrefs.HasKey("lancode"))
        {

        }

        farsi_btn.GetComponent<Button>().onClick.AddListener((() => log_sign("fa")));
        arabi_btn.GetComponent<Button>().onClick.AddListener((() => log_sign("ar")));
        english_btn.GetComponent<Button>().onClick.AddListener((() => log_sign("eng")));

        GameObject.Find("Button_signup_btn").GetComponent<Button>().onClick.AddListener(run_sms);

        GameObject.Find("btn_sms").GetComponent<Button>().onClick.AddListener(fun_register_btn);
        GameObject.Find("btn_sms").GetComponent<Button>().interactable = false;
        GameObject.Find("btn_sms").GetComponent<Image>().enabled = false;
        GameObject.Find("txt_btn_sms").GetComponent<Text>().enabled = false;


        GameObject.Find("sign_btnn").GetComponent<Button>().onClick.AddListener(main_signup);
        GameObject.Find("log_btn").GetComponent<Button>().onClick.AddListener(main_login);
        GameObject.Find("btn_back_lang").GetComponent<Button>().onClick.AddListener(back_lan);
        GameObject.Find("btn_back_login").GetComponent<Button>().onClick.AddListener(back_logsign_from_login);
        GameObject.Find("btn_bak_from_signup").GetComponent<Button>().onClick.AddListener(back_logsign_from_signup);
        GameObject.Find("Button_mainlogin_btn").GetComponent<Button>().onClick.AddListener(fun_login_btn);

        log_panel.transform.localScale = Vector2.zero;
        sign_panel.transform.localScale = Vector2.zero;
        signup_panel.transform.localScale = Vector2.zero;
        mainsignup.transform.localScale = Vector2.zero;
        parsi.transform.localScale = new Vector2(1f, 1.5f);
        arabi.transform.localScale = new Vector2(1f, 1.5f);
        english.transform.localScale = new Vector2(1f, 1.5f);
        signup.transform.localScale = new Vector2(1f, 1.8f);
        login.transform.localScale = new Vector2(1f, 1.8f);
        mainsign_btn.transform.localScale = new Vector2(1.1f, 1.1f);
    }

    // Start is called before the first frame update
    void Start()
    {
        arabi.LeanScale(new Vector2(1.1f, 2f), 1.5f).setLoopType(type);
        parsi.LeanScale(new Vector2(1.1f, 2f), 1.5f).setLoopType(type);
        english.LeanScale(new Vector2(1.1f, 2f), 1.5f).setLoopType(type);
        signup.LeanScale(new Vector2(1.1f, 2f), 1.5f).setLoopType(type);
        login.LeanScale(new Vector2(1.1f, 2f), 1.5f).setLoopType(type);
        mainsign_btn.LeanScale(new Vector2(1.2f, 1.3f), 1.5f).setLoopType(type);
        GameObject.Find("Text_btn_ok").GetComponent<Text>().text = "ﻡﺎﻧ ﺖﺒﺛ";

    }

    public string str_fname = "", str_family = "", str_user_name = "", str_phone_number = "", str_national_code = "";
    public void run_sms()
    {/*
        if (GameObject.Find("register_page_panel").GetComponent<Image>().enabled == false)
        {
            GameObject.Find("register_page_panel").GetComponent<Image>().enabled = true;
            GameObject.Find("btn_register").GetComponent<Image>().enabled = true;
            input_token.image.enabled = true;
            GameObject.Find("input_token_p").GetComponent<Text>().text = "Enter text...";

   
        }*/
        str_fname = input_username.text;
        str_family = input_family.text;
        str_national_code = input_national_code.text;
        str_phone_number = input_phone_number.text;
        if (str_fname != "" && str_family != "" && str_national_code != "" && str_phone_number != "")
        {
            if (run_register == 0)
            {
                StartCoroutine(sms(url_sms));
            }

        }
        else
        {

            Debug.Log("empty");
        }


    }
    IEnumerator sms(string r)
    {
        GameObject.Find("Text_input_token").GetComponent<Text>().text = rnd_token.ToString();
        System.Random rnd = new System.Random();
        rnd_token = rnd.Next(10000, 99999);

        WWWForm form = new WWWForm();
        form.AddField("receptor", input_phone_number.text);//phone number
        form.AddField("token", Convert.ToString(rnd_token));//random number send into user
        form.AddField("template", "userlogin");





        UnityWebRequest uwr = UnityWebRequest.Post(r, form);
        yield return uwr.SendWebRequest();
        if (uwr.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log("Error While Sending: " + uwr.error);
        }
        else
        {
            Debug.Log("Reved: " + uwr.downloadHandler.text);
            GameObject.Find("btn_sms").GetComponent<Button>().interactable = true;
            GameObject.Find("btn_sms").GetComponent<Image>().enabled = true;
            GameObject.Find("txt_btn_sms").GetComponent<Text>().enabled = true;
            GameObject.Find("Text_btn_ok").GetComponent<Text>().text = "ﻦﻔﻠﺗ ﻩﺭﺎﻤﺷ ﺪﯿﯾﺎﺗ";
            run_register = 1;


        }
    }
    public int run_register = 0;
    public void fun_register_btn()
    {
        run_register = 1;//بعد از فعال سازی پنل اس ام اس این خط پاک شود 

        if (run_register == 1)
        {
            Debug.Log("name : " + str_fname + "&&& family  : " + str_family + " &&& number : " + str_phone_number + " &&& natinol : " + str_national_code);
            StartCoroutine(fun_register(url_register));
        }

        //  GameObject.Find ("Button_signup_btn").GetComponent<Button>().onClick.AddListener((() => fun_register(url_register)));


    }
    IEnumerator fun_register(string url)
    {
        JSONNode jdata23;
        if (GameObject.Find("Text_input_token").GetComponent<Text>().text != null)
        {
            token = GameObject.Find("Text_input_token").GetComponent<Text>().text.ToString();
            //   if (rnd_token == Convert.ToInt32(token))//شرط پنل sms فعلا غیر فعال شده و حتما از کامنت خارج شود
            //  {
            Debug.Log("name2 : " + str_fname + "&&& family2  : " + str_family + " &&& number2 : " + str_phone_number + " &&& natinol2 : " + str_national_code);
            Debug.Log("number: " + input_phone_number.text);
            WWWForm form = new WWWForm();
            form.AddField("first_name", input_username.text);
            form.AddField("last_name", input_family.text);
            form.AddField("phone_number", (input_phone_number.text));
            form.AddField("national_code", (input_national_code.text));
            // Debug.Log("not equall");
            UnityWebRequest uwr = UnityWebRequest.Post(url, form);
            yield return uwr.SendWebRequest();

            if (uwr.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log("Error While Sending: " + uwr.error);
            }
            else
            {
                // StartCoroutine(sms(url_sms));
                Debug.Log("Reved: " + uwr.downloadHandler.text);
                b_login = true;
                string result = uwr.downloadHandler.text;

                jdata23 = JSON.Parse(uwr.downloadHandler.text);

                Debug.Log("Revedddddddddddddddddddddddddddd ::" + jdata23["data"].Value);



                // fun_save_json(result);
                if (jdata23["data"].Value == "succesfully registered.")
                {
                    Debug.Log("Revedddddddddddddddddddddddddddd2 ::" + jdata23["success"].Value);
                    PlayerPrefs.DeleteKey("fname");
                    PlayerPrefs.DeleteKey("family");
                    PlayerPrefs.DeleteKey("str_national_code");
                    PlayerPrefs.DeleteKey("phone_number");

                    // GameObject.Find("txt_8000").GetComponent<Text>().text = result;
                    PlayerPrefs.SetString("fname", str_fname);
                    PlayerPrefs.SetString("family", str_family);
                    PlayerPrefs.SetString("str_national_code", str_national_code);
                    PlayerPrefs.SetString("phone_number", str_phone_number);

                    PlayerPrefs.Save();


                    input_token.image.enabled = true;
                    // GameObject.Find("input_token_p").GetComponent<Text>().text = "Enter text...";
                    // txt_register_btn.text = "sms";
                    // StartCoroutine(sms(url_sms));
                    /*
                    if (input_token.text=="56789")
                    {

                    }
                    else
                    {
                        Debug.Log("not currect token");
                    }
                  */
                    SceneManager.LoadScene("CVV2");
                    run_register = 0;
                    Debug.Log("CVV2");
                }
                else
                {

                    // GameObject.Find("txt_input_token").GetComponent<Text>().text = "";
                    input_token.image.enabled = false;


                }
            }
            // } //بررسی اس ام اس به دلیل کاهش مصرف  کامنت شده 
            //else
            // {
            Debug.Log("incorrect token");
            // }

        }
        else
        {
            Debug.Log("empty token");
        }









    }

    public void fun_login_btn()
    {
        Debug.Log("login");


        StartCoroutine(fun_login(url_login));


        //  GameObject.Find ("Button_signup_btn").GetComponent<Button>().onClick.AddListener((() => fun_register(url_register)));


    }
    IEnumerator fun_login(string url2)
    {
        // int number = 09212246850;

        WWWForm form = new WWWForm();
        JSONNode jdata23;

        form.AddField("phone_number", input_number_login.text);
        UnityWebRequest uu = UnityWebRequest.Post(url2, form);
        Debug.Log("login");

        Debug.Log("loginn");
        yield return uu.SendWebRequest();
        if (uu.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log("not network");
        }
        else
        {

            Debug.Log("runing");
            string str_uwr = uu.downloadHandler.text;
            Debug.Log("jdata :" + str_uwr);
            jdata23 = JSON.Parse(uu.downloadHandler.text);

            if (jdata23["data"]["first_name"] != null)
            {
                Debug.Log("jdata trueeeeeeeeeeeeeeeee:" + jdata23["data"]["first_name"]);

                PlayerPrefs.SetString("fname", jdata23["data"]["first_name"]);
                SceneManager.LoadScene("CVV2");
            }
            else
            {
                Debug.Log("jdata falseeeeeeeeeeee:");
            }
            /*
            QR = jdata23["data"]["QR"];
            Debug.Log("jdata :" + QR);

            if (QR != null)
            {
                GameObject.Find("Main Camera").GetComponent<BarcodeCam>().ChangeLastResult(QR);
                // barcode.ChangeLastResult(QR );
                StartCoroutine(pay_api(url_pay));
                StartCoroutine(port_bank(port_bank_url));
            }
            */
        }
        //  first_name
    }


    public void fun_save_json(string result)
    {
        if (result == "8000")
        {

            StreamWriter writer = new StreamWriter(path());

            //lst
            writer.WriteLine("[{" + '"' + "fname" + '"' + ":" + '"' + input_username.text + '"' + "," + '"' + "family" + '"' + ":" + '"' + input_username.text + '"' + ","
               + '"' + "user_name" + '"' + ":" + '"' + input_username.text + '"' + "," + '"' + "input_phone_number" + '"' + ":" + '"' + input_phone_number.text + '"' + "}]");




            writer.Close();
        }
        else
        {
            Debug.Log("Reved: gujgujhooooooooonok");
        }

        //StartCoroutine(log2(loginUrl));
    }
    public string path()
    {
        string str_path = Path.Combine(Application.dataPath, "save_user.json");
        return str_path;
    }












    public string lancode;

    public void log_sign(string code)
    {

        lan_panel.LeanScale(Vector2.zero, 0.4f).setEase(ease);
        lancode = code;

        sign_panel.LeanScale(Vector2.one, 0.9f).setEaseOutElastic();

        PlayerPrefs.SetString("lancode", lancode);

        PlayerPrefs.Save();
    }


    public void main_signup()
    {
        sign_panel.LeanScale(Vector2.zero, 0.4f).setEase(ease);
        mainsignup.LeanScale(Vector2.one, 0.9f).setEaseOutElastic();

    }

    public void main_login()
    {
        sign_panel.LeanScale(Vector2.zero, 0.4f).setEase(ease);
        log_panel.LeanScale(Vector2.one, 0.9f).setEaseOutElastic();
    }


    public void back_lan()
    {
        sign_panel.LeanScale(Vector2.zero, 0.4f).setEase(ease);
        lan_panel.LeanScale(Vector2.one, 0.9f).setEaseOutElastic();

    }
    public void back_logsign_from_signup()
    {
        mainsignup.LeanScale(Vector2.zero, 0.4f).setEase(ease);
        sign_panel.LeanScale(Vector2.one, 0.9f).setEaseOutElastic();
    }
    public void back_logsign_from_login()
    {
        log_panel.LeanScale(Vector2.zero, 0.4f).setEase(ease);
        sign_panel.LeanScale(Vector2.one, 0.9f).setEaseOutElastic();
    }
    public void Update()
    {
        //  Fa.faConvert(input_family.text);
        //  Fa.faConvert(input_username.text);
    }

}

