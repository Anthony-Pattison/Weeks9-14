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

    bool carrying = false;
    public List<GameObject> moveableBoxes;

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
        for (int i = 0; i<moveableBoxes.Count; i++) {
            if (moveableBoxes[i].GetComponent<SpriteRenderer>().bounds.Contains(transform.position))
            {
                PickUp(moveableBoxes[i]);
            }
        }
    }
    private void PickUp(GameObject t)
    {
        Vector2 pos = transform.position;
        if (Input.GetKey("f") && !carrying)
        {
            t.transform.position = pos;
            carrying = true;
        }
        else
        {
            carrying = false;
        }
        pos = t.transform.position;
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
