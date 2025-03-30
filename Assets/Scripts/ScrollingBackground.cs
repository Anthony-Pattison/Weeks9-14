using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    public Renderer r;
    public float speed;

    // Update is called once per frame
    void Update()
    {
        r.material.mainTextureOffset += new Vector2(speed * Time.deltaTime, 0);
        
    }
}
