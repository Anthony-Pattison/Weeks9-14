using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject BoxManager;
    public float speed = 3;
    public List<GameObject> Boxeslist;
    bool carrying = false;
    public Animator animator;
    float DirectionofWalk;
    public SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        
        Boxeslist = BoxManager.GetComponent<BoxManagerSpawner>().Boxes;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 PlayerPos = transform.position;

        PlayerPos.x += Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        PlayerPos.y += Input.GetAxis("Vertical") * speed * Time.deltaTime;

        DirectionofWalk = Input.GetAxis("Horizontal");
        sr.flipX = (DirectionofWalk < 0);
        animator.SetFloat("Walkleftani", Mathf.Abs(DirectionofWalk));

        if (Input.GetKey("left shift"))
        {
            speed = 5;
        }
        else
        {
            speed = 3;
        }
        for (int i = 0; i < Boxeslist.Count; i++)
        {

            GameObject t = Boxeslist[i];
            Vector2 tempPos = t.transform.position;

            if (Boxeslist[i].GetComponent<SpriteRenderer>().bounds.Contains(transform.position) && !Boxeslist[i].GetComponent<Boxeskeychanger>().StartShrink)
            {
                carring(t);
            }

        }
        transform.position = PlayerPos;
    }

    private void carring(GameObject t)
    {
        Vector2 tempPos = t.transform.position;
        if (Input.GetKey("space") && !carrying)
        {
            if (t.GetComponent<Boxeskeychanger>().BoxKey == 4)
            {

                t.GetComponent<Boxeskeychanger>().Stopgoldenbox(t);

                t.transform.position = transform.position;
                carrying = true;
            }
            else
            {
                t.transform.position = transform.position;
                carrying = true;
            }
        }
        else
        {
            carrying = false;
        }

    }
}