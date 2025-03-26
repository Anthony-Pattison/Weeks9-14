using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Knight : MonoBehaviour
{
    public Animator animator;
    float direction;
    float speed = 2;

    Vector3 Beginpos;
    Vector3 Endpos;

    public ParticleSystem PS;
    SpriteRenderer sr;
    public AnimationCurve curve;

    bool canRun = true;
    bool jumping = true;

    public float t = 0;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    
       
    }

    // Update is called once per frame
    void Update()
    {
        
        Debug.Log(Endpos);

        
        direction = Input.GetAxis("Horizontal");

        
        

        if (canRun)
        {
            transform.position += transform.right * direction * speed * Time.deltaTime;
            sr.flipX = (direction < 0);
            animator.SetFloat("movement", Mathf.Abs(direction));
        }
        if (Input.GetKey("e"))
        {
            canRun = false;
            animator.SetTrigger("Attack");

        }
        if (Input.GetKey("space") && jumping)
        {
            isJumping();
           
        }
    }

    private void StopRunning()
    {
        canRun = true;
    }

    private void isJumping()
    {
        
        StartCoroutine(Jumpcurve());
        canRun = false;
        jumping = false;
    }

    public IEnumerator Jumpcurve()
    {
        t = 0;
        
        Vector2 pos = transform.position;
        Beginpos = new Vector2(pos.x, pos.y);
        Endpos = new Vector2(pos.x, pos.y + 4);
        PS.Emit(pos, new Vector2(pos.x, pos.y - 3), 1, .5f, Color.grey);
        while (t < 1f)
        {
            
            t += 0.5f * Time.deltaTime;
            transform.position = Vector2.Lerp(Beginpos, Endpos, curve.Evaluate(t));
            yield return null;
        }
        canRun = true;
        jumping = true;
        //PS.enableEmission = false;
        //PS.enableEmission = false;
    }
}
