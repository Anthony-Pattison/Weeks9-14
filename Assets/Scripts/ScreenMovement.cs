using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ScreenMovement : MonoBehaviour
{
    public float speed = .01f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;
        pos.x += speed;
        Vector2 screenpos = Camera.main.WorldToScreenPoint(pos);

        
        if (screenpos.x <= 0 || screenpos.x >= Screen.width)
        {
            speed = speed * -1;
        }
        
        transform.position = pos;
    }
}
