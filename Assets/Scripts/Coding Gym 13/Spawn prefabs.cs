using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnprefabs : MonoBehaviour
{
    public GameObject prefab;
    GameObject t;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            
            t = Instantiate(prefab);
            t.transform.position = mousepos;
        }
        
        
    }
}
