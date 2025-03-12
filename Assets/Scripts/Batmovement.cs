using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Batmovement : MonoBehaviour
{
    public GameObject Sword;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;
        Vector2 screenpos = Camera.main.WorldToScreenPoint(pos);

        Debug.Log(speed);
;        if (pos.x <= 0 || pos.x >= Screen.width)
        {
           
            speed = speed * -1;
        }
        pos.x += speed;
        transform.position = pos;
    }
}
