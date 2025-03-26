using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Batmovement : MonoBehaviour
{
    public GameObject Sword;
    public float speed;
    public float t = 1;

    public AnimationCurve curve;

    Vector2 Beginpos;
    Vector2 Endpos;

    public Vector2 pos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;
        Vector2 temppos = new Vector2(0,0);
        Vector2 screenpos = Camera.main.WorldToScreenPoint(pos);

        if (t>=1)
        {
            Beginpos = new Vector2(pos.x, pos.y);
            Endpos = new Vector2(pos.x, pos.y + 5);
            t = 0;
            Debug.Log("working");
        }
        if (t < 1)
        {
            t += 0.8f * Time.deltaTime;
            temppos = Vector2.Lerp(Beginpos, Endpos, curve.Evaluate(t));
            pos.y = temppos.y;
        }
;        if (screenpos.x >= Screen.width)
        {
            
            screenpos.x = 0;
            pos.x -= (pos.x * 2);
            transform.position = pos;
            GetComponent<TrailRenderer>().Clear();
        }
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
       
    }

    
    
}
