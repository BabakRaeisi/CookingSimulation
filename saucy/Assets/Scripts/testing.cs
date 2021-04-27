using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using System.Linq;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Text;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.IO;


public class testing : MonoBehaviour
{
    public string str = "https://smartbnd.ir/api/v1/register";
    [SerializeField] UnityEngine.UI.InputField phone_number;
    [SerializeField] UnityEngine.UI.InputField username;
    // Start is called before the first frame update
    public void ppppp()
    {
        StartCoroutine(PostRequest(str));
    }
    IEnumerator PostRequest(string url)
    {
        WWWForm form = new WWWForm();
        form.AddField("first_name", username.text);
        form.AddField("last_name", username.text);




        form.AddField("phone_number", phone_number.text);
        Debug.Log("staerting");
        UnityWebRequest uwr = UnityWebRequest.Post(url, form);
        yield return uwr.SendWebRequest();

        if (uwr.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log("Error While Sending: " + uwr.error);
        }
        else
        {
            Debug.Log("Reved: " + uwr.downloadHandler.text);


        }
    }
    IEnumerator Maxw(string url)
    {
        // int number = 09155151515;
        Debug.Log("starting");
        WWWForm form = new WWWForm();
        form.AddField("first_name", username.text);
        form.AddField("last_name", username.text);
        // form.AddField("password", "eslsamifeffis");
        form.AddField("phone_number", phone_number.text);
        uu = UnityWebRequest.Post(url, form);
        yield return uu.SendWebRequest();
        if (uu.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log("not network");
        }
        else
        {
            Debug.Log("runing");
            string str_uwr = uu.downloadHandler.text;
            Debug.Log(phone_number.text);
            Debug.Log(str_uwr);



        }

    }
    public UnityWebRequest uu;
    // Update is called once per frame
    void Update()
    {

    }
}
