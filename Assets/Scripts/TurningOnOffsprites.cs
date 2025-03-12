using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TurningOnOffsprites : MonoBehaviour
{
    public GameObject thoughtbubble;
    public GameObject bat;
    public float t = 0;
    // Start is called before the first frame update
    public void onExit()
    {
        thoughtbubble.SetActive(false);
    }

    // Update is called once per frame
    public void onEnter()
    {
        thoughtbubble.SetActive(true);
    }
    public void onDown()
    {
        
        t = 5;
        bat.GetComponent<Batmovement>().speed = t;

    }
    public void onUp()
    {

        t = 0;
        bat.GetComponent<Batmovement>().speed = t;
    }
}
