using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Knight : MonoBehaviour
{
    public Animator animator;
    float direction;
    float speed = 2;
    SpriteRenderer sr;
    bool canRun = true;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
       direction = Input.GetAxis("Horizontal");

        
        sr.flipX = (direction < 0);
        animator.SetFloat("movement", Mathf.Abs(direction));

        if (canRun) {
            transform.position += transform.right * direction * speed * Time.deltaTime;
        }
        if (Input.GetKey("e"))
        {
            canRun = false;
            animator.SetTrigger("Attack");
            
        }
            
    }

    private void StopRunning()
    {
        canRun = true;
    }
}
