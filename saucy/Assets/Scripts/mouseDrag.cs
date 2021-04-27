using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseDrag : MonoBehaviour
{
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); 

    }
    private void OnMouseDrag()
    {
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z + transform.position.z);
        Vector3 objpos = Camera.main.ScreenToWorldPoint(mousePos);
        transform.position = objpos;
        rb.isKinematic = true;
    }
    private void OnMouseUp()
    {
        rb.isKinematic = false; 

    }
}
