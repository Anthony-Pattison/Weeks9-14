using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followmouse : MonoBehaviour
{
 
    // Update is called once per frame
    void Update()
    {
 
        Vector2 screenpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        transform.position = screenpos;

        if (Input.GetKeyDown("space"))
        {
            GetComponent<SpriteRenderer>().color = Random.ColorHSV();
        }
    }
}
