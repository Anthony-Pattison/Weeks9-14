using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TakingMovementAwaywithCoroutine : MonoBehaviour
{
    public bool move = true;
    public SpriteRenderer sr;
    public Transform knife;
    // Start is called before the first frame update
    public float speed = 5;
    public float rotationSpeed = 50;
    void Start()
    {
        StartCoroutine(Moving());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("space"))
        {
           move = false;
        }
        if (Input.GetKey("x"))
        {
            move = true;
            
        }
    }

    public IEnumerator Moving()
    {
        
        while (move) {
           
            transform.Translate(0, Input.GetAxisRaw("Vertical") * speed * Time.deltaTime, 0);
            transform.Rotate(0, 0, Input.GetAxisRaw("Horizontal") * rotationSpeed * Time.deltaTime);
            yield return null;

        }
        
    }
}
