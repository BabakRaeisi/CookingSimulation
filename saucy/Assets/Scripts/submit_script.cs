using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 


public class submit_script : MonoBehaviour
{
    private instantiation inst;
    private MoveScene moveScene;
    private Transform foodholder; 

    private void Awake()
    {
        inst = GameObject.Find("plate").GetComponent<instantiation>();
        moveScene = GameObject.Find("plate").GetComponent<MoveScene>();
        foodholder = GameObject.Find("foodholder").GetComponent<Transform>(); 
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

        if (scene.name == "CVV2")
        {
            gameObject.GetComponent<Button>().onClick.AddListener((() => inst.create_instnce = true));
            gameObject.GetComponent<Button>().onClick.AddListener((() => inst.submit_name()));
          
            
                gameObject.GetComponent<Button>().onClick.AddListener((() => moveScene.nextScene()));
            
        }
    }
    private void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener((()=>inst.create_instnce = true)) ; 
        gameObject.GetComponent<Button>().onClick.AddListener((() => inst.submit_name()));
        gameObject.GetComponent<Button>().onClick.AddListener((() => moveScene.nextScene()));
        
    }
}
