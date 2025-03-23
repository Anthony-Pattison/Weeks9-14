using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDrawing : MonoBehaviour
{
    LineRenderer LR;
    public List<Vector2> ListofPoints;

    private void Start()
    {
        LR = GetComponent<LineRenderer>();
        LR.positionCount = 0; 
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            ListofPoints.Add(newPosition);

            LR.positionCount++;
            LR.SetPosition(LR.positionCount - 1, newPosition);       
        }

        if (Input.GetKey("space"))
        {
            LR.positionCount = 0;
            ListofPoints.Clear();
        }
    }
}
