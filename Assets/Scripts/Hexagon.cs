using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Hexagon : MonoBehaviour
{
    SpriteRenderer sr;
    public UnityEvent OnClick;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void ChangeColor()
    {
        sr.color = Random.ColorHSV();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (sr.bounds.Contains(mousePos))
            {
                OnClick.Invoke();
            }
        }
    }
    public void GetBigger()
    {
        transform.localScale += Vector3.one * 0.1f;
    }
}
