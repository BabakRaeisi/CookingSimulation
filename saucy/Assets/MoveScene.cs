using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
public class MoveScene : MonoBehaviour
{



   public void nextScene()
    {
        SceneManager.LoadScene("ready_scene"); 
    }
    public void pizza_scene()
    {
        SceneManager.LoadScene("CVV2"); 
    }
}
