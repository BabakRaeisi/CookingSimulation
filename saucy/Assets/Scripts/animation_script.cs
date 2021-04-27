using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class animation_script : MonoBehaviour
{

    bool setting_content = true;
    [SerializeField]
    private Transform settings;
    [SerializeField]
    private GameObject settings_btn, sound, music, notif, Qa, cart, leftbtn, rightbtn, rightbtn_popUp, profile, profile_field,
        reset, trash_bin, done;





    //--------------------profile----------------//
    //button section
    [SerializeField]
    private GameObject adress, orders, recipe, profile_editor , profile_holder;
    //section
    [SerializeField]
    private GameObject adress_sec, order_sec, recipe_sec, profile_sec;
    private Button back_adress_sec, back_order_sec, back_recipe_sec, back_profile_sec;

    [SerializeField]
    private Button profile_btn , close_profile_btn  ; 
    bool sound_on = true;
    bool notif_on = true;
    bool music_on = true;

    [SerializeField]
    private LeanTweenType type;
    // Start is called before the first frame update
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

        if (scene.name == "type_select")
        {
           
            rightbtn = GameObject.Find("right_btn");
            leftbtn = GameObject.Find("left_btn");
            rightbtn_popUp = GameObject.Find("popup_right"); 
            cart.LeanScale(new Vector2(1.07f, 1.06f), 0.8f).setLoopPingPong();
            rightbtn.LeanScale(new Vector2(1.07f, 1.06f), 0.8f).setLoopPingPong();
            leftbtn.LeanScale(new Vector2(1.07f, 1.06f), 0.8f).setLoopPingPong();
            settings_btn.LeanScale(new Vector2(1.1f, 1.1f), 0.5f).setLoopPingPong();
           // profile.transform.localScale = new Vector2(0, 0);
            sound.transform.localScale = Vector2.zero;
            music.transform.localScale = Vector2.zero;
            notif.transform.localScale = Vector2.zero;
            Qa.transform.localScale = Vector2.zero;


            

        }
        if (scene.name == "CVV2")
        {
            profile_field = GameObject.Find("profile_popup");
            profile = GameObject.Find("profile_btn");
           trash_bin = GameObject.Find("trash_btn");
            reset = GameObject.Find("reset_btn");
            done = GameObject.Find("done"); 
            profile_btn = GameObject.Find("profile_btn").GetComponent<Button>();
            cart = GameObject.Find("cart_btn");

            cart.LeanScale(new Vector2(1.07f, 1.06f), 0.8f).setLoopPingPong();
            profile.LeanScale(new Vector2(1.07f, 1.06f), 0.8f).setLoopPingPong();

            settings_btn.LeanScale(new Vector2(1.1f, 1.1f), 0.5f).setLoopPingPong();
          //  profile.transform.localScale = new Vector2(0, 0);
            sound.transform.localScale = Vector2.zero;
            music.transform.localScale = Vector2.zero;
            notif.transform.localScale = Vector2.zero;
            Qa.transform.localScale = Vector2.zero;
            profile_field.transform.localScale = Vector2.zero;

            sound.GetComponent<Button>().onClick.AddListener((() => mute_unmute())); 
            music.GetComponent<Button>().onClick.AddListener((() => music_on_off()));
            notif.GetComponent<Button>().onClick.AddListener((() => notif_onOff()));

            profile.GetComponent<Button>().onClick.AddListener((() => OpenProfilefield()));









            profile_holder = GameObject.Find("profile_holder");
            adress = GameObject.Find("address");
            orders = GameObject.Find("orders");
            recipe = GameObject.Find("recipe");
            profile_editor = GameObject.Find("profile_editor");


            adress_sec  = GameObject.Find("Address_section");
            order_sec   = GameObject.Find("orders_section");
            recipe_sec  = GameObject.Find("recipe_section");
            profile_sec = GameObject.Find("profile_section");

            back_adress_sec = GameObject.Find("back_adress_sec").GetComponent<Button>();
                back_order_sec  =GameObject.Find("back_order_sec")  .GetComponent<Button>();
                back_recipe_sec =GameObject.Find("back_recipe_sec") .GetComponent<Button>();
                back_profile_sec=GameObject.Find("back_profile_sec").GetComponent<Button>();

                    back_adress_sec.GetComponent<Button>().onClick.AddListener((() => close_profile_section(adress_sec)));
                    back_order_sec.GetComponent<Button>().onClick.AddListener((() => close_profile_section(order_sec)));
                    back_recipe_sec.GetComponent<Button>().onClick.AddListener((() => close_profile_section(recipe_sec)));
                    back_profile_sec.GetComponent<Button>().onClick.AddListener((() => close_profile_section(profile_sec)));

            adress.GetComponent<Button>().onClick.AddListener((() => open_profile_section( adress_sec)));
            orders.GetComponent<Button>().onClick.AddListener((() => open_profile_section( order_sec)));
            recipe.GetComponent<Button>().onClick.AddListener((() => open_profile_section( recipe_sec)));
            profile_editor.GetComponent<Button>().onClick.AddListener((() => open_profile_section( profile_sec)));

            adress.LeanScale(new Vector2(1.07f, 1.06f), 0.8f).setLoopPingPong();
            orders.LeanScale(new Vector2(1.07f, 1.06f), 0.8f).setLoopPingPong();
            recipe.LeanScale(new Vector2(1.07f, 1.06f), 0.8f).setLoopPingPong();
            profile_editor.LeanScale(new Vector2(1.07f, 1.06f), 0.8f).setLoopPingPong();

            adress_sec.transform.localScale = Vector2.zero;
            order_sec.transform.localScale = Vector2.zero;
            recipe_sec.transform.localScale = Vector2.zero;
            profile_sec.transform.localScale = Vector2.zero;





        }
    }



    void open_profile_section( GameObject section )
    {
  
            profile_holder.LeanScale(Vector2.zero, 0.4f).setEaseInExpo();
            section.LeanScale(Vector2.one, 0.9f).setEaseOutElastic();

    }
    void close_profile_section(GameObject section)
    {
        section.LeanScale(Vector2.zero, 0.2f).setEaseInExpo();
        profile_holder.LeanScale(Vector2.one, 0.5f).setEaseInQuart();
    }
    


    bool profile_bool = false; 
    // Update is called once per frame
    public void OpenProfilefield()
    {
        if (profile_bool == false)
        {
            profile_field.LeanScale(Vector2.one, 0.9f).setEaseOutElastic();
            profile_bool = true;
        }
        else {
            profile_field.LeanScale(Vector2.zero, 0.4f).setEaseInExpo();
            profile_bool = false; 
        }
    }
    public void tween_play()
    {

        if (setting_content == true)
        {
            sound.LeanScale(Vector2.one, 0.1f).setEaseOutQuart();
            notif.LeanScale(Vector2.one, 0.5f).setEaseOutQuart();
            music.LeanScale(Vector2.one, 0.9f).setEaseOutQuart();
            Qa.LeanScale(Vector2.one, 1.3f).setEaseOutQuart();
          //  profile.LeanScale(Vector2.one, 1.7f).setEaseOutQuart();

        

         //   sound.LeanScale(new Vector2(1.07f, 1.06f), 0.8f).setLoopPingPong();
         //   notif.LeanScale(new Vector2(1.07f, 1.06f), 0.8f).setLoopPingPong();
         //   music.LeanScale(new Vector2(1.07f, 1.06f), 0.8f).setLoopPingPong();
         //   Qa.LeanScale(new Vector2(1.07f, 1.06f), 0.8f).setLoopPingPong();
         //   profile.LeanScale(new Vector2(1.07f, 1.06f), 0.8f).setLoopPingPong();
            setting_content = false;
        }
        else
        {
           // LeanTween.cancel(profile);
           // profile.LeanScale(Vector2.zero, 0.3f).setEaseOutQuart();
            LeanTween.cancel(sound);
            sound.LeanScale(Vector2.zero, 0.3f).setEaseOutQuart();
            LeanTween.cancel(music);
            music.LeanScale(Vector2.zero, 0.3f).setEaseOutQuart();
            LeanTween.cancel(notif);
            notif.LeanScale(Vector2.zero, 0.3f).setEaseOutQuart();
            LeanTween.cancel(Qa);
            Qa.LeanScale(Vector2.zero, 0.3f).setEaseOutQuart();
            setting_content = true; 
        }

    }


    public void mute_unmute()
    {
        if (sound_on == true)
        {
            sound.GetComponent<Image>().sprite = Resources.Load<Sprite>("sprite/app_sprite/mute");

            sound_on = false;
        }
        else {

            sound.GetComponent<Image>().sprite = Resources.Load<Sprite>("sprite/app_sprite/unmute");

            sound_on = true;

        }
    }
        public void music_on_off()
        {
            if (music_on == true)
            {
                music.GetComponent<Image>().sprite = Resources.Load<Sprite>("sprite/app_sprite/musicoff");

                music_on = false;
            }
            else
            {

                music.GetComponent<Image>().sprite = Resources.Load<Sprite>("sprite/app_sprite/musicon");

                music_on = true;

            }


        }
    public void notif_onOff()
    {
        if (notif_on == true)
        {
            notif.GetComponent<Image>().sprite = Resources.Load<Sprite>("sprite/app_sprite/NoNotification");

            notif_on = false;
        }
        else
        {

            notif.GetComponent<Image>().sprite = Resources.Load<Sprite>("sprite/app_sprite/notification");

            notif_on = true;

        }



    }

    public void popup_right_btn()
    {

      rightbtn_popUp.LeanScale(Vector2.zero, 0.3f).setEaseOutQuart();
    }
}
