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
    Vector2 PlayerPos;

    // Start is called before the first frame update
    void Start()
    {
        // sets the box list from the boxmanager to a value
        Boxeslist = BoxManager.GetComponent<BoxManagerSpawner>().Boxes;
    }

    // Update is called once per frame
    void Update()
    {
        // assign player position
        PlayerPos = transform.position;
        // take keyboard input
        PlayerPos.x += Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        PlayerPos.y += Input.GetAxis("Vertical") * speed * Time.deltaTime;
        // for player animation if player is moving play animation
        DirectionofWalk = Input.GetAxis("Horizontal");
        // is the value is negaive(player walking left) filp the sprite
        sr.flipX = (DirectionofWalk < 0);
        // change animator value
        animator.SetFloat("Walkleftani", Mathf.Abs(DirectionofWalk));
        // allow for running
        if (Input.GetKey("left shift"))
        {
            speed = 5;
        }
        else
        {
            speed = 3;
        }
        // runs though the box list and sees if the player intersects with a box
        for (int i = 0; i < Boxeslist.Count; i++)
        {

            GameObject t = Boxeslist[i];
            Vector2 tempPos = t.transform.position;
            // if the player is inside one of the boxes and it's not shrinking
            if (Boxeslist[i].GetComponent<SpriteRenderer>().bounds.Contains(transform.position) && !Boxeslist[i].GetComponent<Boxeskeychanger>().StartShrink)
            {
                // runs the carry function
                carring(t);
            }

        }
        // apply the movement
        transform.position = PlayerPos;
    }
    // this function takes any box that the player is on and follows them if the space key is pressed
    private void carring(GameObject t)
    {
        // temp position of the passes box
        Vector2 tempPos = t.transform.position;
        // is space is pressed and the player is not carrying somthing
        if (Input.GetKey("space") && !carrying)
        {
            // if its a golden box and its moving with its coroutine stop it
            if (t.GetComponent<Boxeskeychanger>().BoxKey == 4)
            {
                // stops the coroutine
                t.GetComponent<Boxeskeychanger>().Stopgoldenbox(t);
                // apply movement
                tempPos = transform.position;
                carrying = true;
            }
            else
            {
                //apply movement
                tempPos = transform.position;
                carrying = true;
            }
        }
        else
        {
            // not carrying something
            carrying = false;
        }
        // gives movement to the picked up box
        t.transform.position = tempPos;
    }
}