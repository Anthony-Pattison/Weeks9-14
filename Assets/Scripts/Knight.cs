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
    AudioSource Soundsource;
    bool canRun = true;
    bool jumping = true;

    public AudioClip[] sounds;

    public float t = 0;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        Soundsource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {


        if (canRun)
        {
            direction = Input.GetAxis("Horizontal");
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

    private void isJumping()
    {
        canRun = false;
        jumping = false;
        StartCoroutine(Jumpcurve());

    }
    private void Startrunning()
    {
        canRun = true;
    }
    public IEnumerator Jumpcurve()
    {
        t = 0;

        Vector2 pos = transform.position;
        Beginpos = new Vector2(pos.x, pos.y);
        Endpos = new Vector2(pos.x, pos.y + 4);
        PS.Emit(pos, new Vector2(pos.x, pos.y - 3), 1, .5f, Color.grey);
        while (t < .5f)
        {
            animator.SetFloat("movement", 0);
            t += 0.5f * Time.deltaTime;
            transform.position = Vector2.Lerp(Beginpos, Endpos, curve.Evaluate(t));
            yield return null;
        }
        Startrunning();
        jumping = true;
        //PS.enableEmission = false;
        //PS.enableEmission = false;
    }
    void pickRandomSound()
    {
        int i = Random.RandomRange(0, 8);

        Soundsource.PlayOneShot(sounds[i]);
    }
}
