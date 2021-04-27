using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ScreenShotHandler : MonoBehaviour
{
    private static ScreenShotHandler instance;
     

    private Camera mycamera;
    private bool takescreenshotOnNextFrame;
    private string food_name ;
    public Text text1;
    public instantiation inst; 

   void Awake()
    {
        instance = this;
        mycamera = gameObject.GetComponent<Camera>();
        inst = GameObject.Find("plate").GetComponent<instantiation>(); 
      
    }
    private void OnPostRender()
    {
        if (takescreenshotOnNextFrame)
        {
            takescreenshotOnNextFrame = false;
            RenderTexture renderTexture = mycamera.targetTexture;
            Texture2D renderResult = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.ARGB32,false);
            Rect rect = new Rect(0, 0, renderTexture.width, renderTexture.height);
            renderResult.ReadPixels(rect, 0, 0);
            var bytes = renderResult.EncodeToPNG();
            food_name = inst.food_name_tag;
         // string newscrn = bytes.ToString();

            string base64 = null;
            base64 = Convert.ToBase64String(bytes);
           // Debug.Log("tex string   : " + base64);


            PlayerPrefs.SetString(food_name, base64); 
            byte[] byteArray = renderResult.EncodeToPNG();
            
            
            
           // System.IO.File.WriteAllBytes(Application.dataPath +"/Resources"+ "/" + food_name + ".png", byteArray);

            Debug.Log("click-clack!"); 

            RenderTexture.ReleaseTemporary(renderTexture);
            mycamera.targetTexture = null;
            foreach (var item in inst.foodlist)
            {
                if (food_name == item.foodname)
                { item.foodImage = base64;  }

            }
            //creating sprite
          //
          //  float floatWidthCam = renderResult.width;
          //  float floatHeightCam = renderResult.height;
          //  float widthSprite = (floatWidthCam - floatHeightCam) / 2.0f;
          //  float ratio = (renderResult.width) / (renderResult.height);


          


           // Sprite newsprite = Sprite.Create(texture, new Rect(widthSprite, 0.0f, (texture.width) / ratio, texture.height), new Vector2(0.5f, 0.5f), 300.0f);

        }
    }
   

    private void TakeScreenshot(int width, int height)
    {
        mycamera.targetTexture = RenderTexture.GetTemporary(width, height, 16);
        takescreenshotOnNextFrame = true;
        text1.text = "snapped hard"; 

    }
    public static void TakeScreenShot_static(int width, int height)
    {
        instance.TakeScreenshot(width, height);
        
    }

    
}
