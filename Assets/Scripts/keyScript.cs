using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyScript : MonoBehaviour
{
    public int keycode;
    public GameObject box;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<SpriteRenderer>().bounds.Contains(box.transform.position) && box.GetComponent<Identifyboxscript>().KeyNumber <= keycode)
        {
            Debug.Log("Good Job");
            Destroy(this);
        }
    }
}
