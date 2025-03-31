using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Tileswaper : MonoBehaviour
{
    public Tilemap tm;

    public Tile grass;
    public Tile stone;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            Vector2 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector3Int gridPos = tm.WorldToCell(mousepos);

            Debug.Log(gridPos.ToString());
            if(tm.GetTile(gridPos) == stone)
            {
                tm.SetTile(gridPos, grass);
            }
            else
            {
                tm.SetTile(gridPos, stone);
                GetComponent<CinemachineImpulseSource>().GenerateImpulse();
            }
        }
    }
}