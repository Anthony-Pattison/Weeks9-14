using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointatmouse : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.up = mousepos - (Vector2)transform.position;
    }
}
