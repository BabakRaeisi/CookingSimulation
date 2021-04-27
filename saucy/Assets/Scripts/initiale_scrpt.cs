using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class initiale_scrpt : MonoBehaviour
{
    [SerializeField]
    private GameObject lan_panel, sign_panel, arabi, parsi, english,
        login, signup, signup_panel,
        mainsignup, mainsign_btn,
        log_panel , mainlogin_btn
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

        log_panel.transform.localScale = Vector2.zero;
        sign_panel.transform.localScale = Vector2.zero;
        signup_panel.transform.localScale = Vector2.zero;
        mainsignup.transform.localScale = Vector2.zero; 
        parsi.transform.localScale = new Vector2(1f, 1.5f);
        arabi.transform.localScale = new Vector2(1f , 1.5f);
        english.transform.localScale = new Vector2(1f, 1.5f);
        signup.transform.localScale = new Vector2(1f, 1.8f);
        login.transform.localScale = new Vector2(1f, 1.8f);
        mainsign_btn.transform.localScale = new Vector2(1.1f, 1.1f);
    }
    // Start is called before the first frame update
    void Start()
    {
        arabi.LeanScale(new Vector2(1.1f,2f) , 1.5f).setLoopType(type);
        parsi.LeanScale(new Vector2(1.1f, 2f), 1.5f).setLoopType(type);
        english.LeanScale(new Vector2(1.1f, 2f), 1.5f).setLoopType(type);
        signup.LeanScale(new Vector2(1.1f, 2f), 1.5f).setLoopType(type);
        login.LeanScale(new Vector2(1.1f, 2f), 1.5f).setLoopType(type);
        mainsign_btn.LeanScale(new Vector2(1.2f, 1.3f), 1.5f).setLoopType(type);


    }

    public void log_sign()
    {
       
        lan_panel.LeanScale(Vector2.zero, 0.4f).setEase(ease); 
        sign_panel.LeanScale(Vector2.one , 0.9f).setEaseOutElastic() ;
      

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


    public void back_lan() {
        sign_panel.LeanScale(Vector2.zero, 0.4f).setEase(ease);
        lan_panel.LeanScale(Vector2.one, 0.9f).setEaseOutElastic();

    }
    public void back_logsign_from_signup() {
        mainsignup.LeanScale(Vector2.zero, 0.4f).setEase(ease);
        sign_panel.LeanScale(Vector2.one, 0.9f).setEaseOutElastic();
    }
    public void back_logsign_from_login()
    {
        log_panel.LeanScale(Vector2.zero, 0.4f).setEase(ease);
        sign_panel.LeanScale(Vector2.one, 0.9f).setEaseOutElastic();
    }

}
