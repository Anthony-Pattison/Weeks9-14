using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Identifyboxscript : MonoBehaviour
{
    public int KeyNumber;
    int num;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        num++;
        Debug.Log(num%10);
    }
}
