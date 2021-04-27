using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 


public class handler : MonoBehaviour
{
    private instantiation inst;
    private Transform foodHolder; 

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

        if (scene.name == "ready_scene")
        {
            inst = GameObject.Find("plate").GetComponent<instantiation>();
            foodHolder = GameObject.Find("foodholder").GetComponent<Transform>();

        }
        else if(scene.name == "Cart")
        {

            inst = GameObject.Find("plate").GetComponent<instantiation>();
        }
    }





    public void snap()
    {
      {
       ScreenShotHandler.TakeScreenShot_static(500, 500);
      }
    }
    public void Select_scene()
    {
        if (foodHolder.childCount > 0)
        {

            int child_v = foodHolder.childCount;
            for (int chi = child_v - 1; chi >= 0; chi--)
            {


                Destroy(foodHolder.GetChild(chi).gameObject);


            }
        }
        inst.submit_all();
        inst.Saved_price = 0;
        inst.price = 0;
        inst.Saved_calorie = 0;
        inst.calorie = 0;
        
        SceneManager.LoadScene("type_select");
       
    }

    public void firstScene()
    {

        SceneManager.LoadScene("CVV2");
        
    }

    public void AnotherFood()
    {
        
      
        inst.Saved_price = 0;
        inst.price = 0;
        inst.Saved_calorie = 0;
        inst.calorie = 0; 
        SceneManager.LoadScene("type_select");
    }

}
