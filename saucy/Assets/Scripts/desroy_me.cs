using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class desroy_me : MonoBehaviour
{
    private instantiation inst;
    private Transform foodHolder;

    void Awake()
    {


        inst = GameObject.Find("plate").GetComponent<instantiation>();
        foodHolder = GameObject.Find("foodholder").GetComponent<Transform>();


    }

    public void Delete_group()
    {


        if (foodHolder.childCount > 0)
        {

            int child_v = foodHolder.childCount;
            for (int chi = child_v - 1; chi >= 0; chi--)
            {

                if (gameObject.transform.name == foodHolder.GetChild(chi).name)
                {
                    Destroy(foodHolder.GetChild(chi).gameObject);
                    inst.deduct(gameObject.transform.name.Substring(0,6));
                }



            }
        }



        for (int i = 0; i < inst.ListIngred.Count; i++)
        {
            if (inst.ListIngred[i].ingred_name == gameObject.transform.name)
            {

                inst.ListIngred.RemoveAt(i);
            }
        }

    }
    // Start is called before the first frame update
    public void selfDestruct()
    {
        Destroy(gameObject);
    }
}
