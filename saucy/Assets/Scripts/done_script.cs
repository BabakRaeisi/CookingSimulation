using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 


public class done_script : MonoBehaviour
{

    private instantiation inst; 

    public InputField inp_food_name;


    private void Awake()
    {
        inst = GameObject.Find("plate").GetComponent<instantiation>();
        gameObject.GetComponent<Button>().onClick.AddListener((() => inst.create_instnce = true)) ;
        gameObject.GetComponent<Button>().onClick.AddListener((() => inst.b_desrtroy = false));
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

        if (scene.name == "type_select")
        {
            inst = GameObject.Find("plate").GetComponent<instantiation>();
            gameObject.GetComponent<Button>().onClick.AddListener((() => inst.create_instnce = true));
            gameObject.GetComponent<Button>().onClick.AddListener((() => inst.b_desrtroy = false));
        }
    }

}
