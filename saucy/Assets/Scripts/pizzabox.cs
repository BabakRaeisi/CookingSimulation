using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pizzabox : MonoBehaviour
{
    [SerializeField]
    GameObject main_bone;
    public string price= "10000"; 
    bool open = true;
    [SerializeField]
    private LeanTweenType type;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Door_function();
        }
    }

    public float X_close;


    public void Door_function()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;


        if (Physics.Raycast(ray, out hit))
        {
            if ( hit.collider.tag == "pizza_box")
            {

           



                if (open == true)
                {

                    main_bone.LeanRotateX(X_close, 1f).setEase(type);
                    open = false;
                }
                else
                {

                    main_bone.LeanRotateX(0, 0.7f).setEaseSpring();
                    open = true;
                }
            }
        }
    }
}
