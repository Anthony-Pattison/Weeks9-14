using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HexagonSpawner : MonoBehaviour
{
    public GameObject prefab;
    public Button ButtonToChangeColor;
    public TextMeshProUGUI numberofclicks;
    int clicks = 0;
    public void spawn()
    {
        GameObject newHexagon = Instantiate(prefab, Random.insideUnitCircle * 4,transform.rotation);

        Hexagon hexagon = newHexagon.GetComponent<Hexagon>();

        ButtonToChangeColor.onClick.AddListener(hexagon.ChangeColor);

        hexagon.OnClick.AddListener(AddToClickCounter);
    }
   public void StopListning()
    {
        ButtonToChangeColor.onClick.RemoveAllListeners();
    }
    public void AddToClickCounter()
    {
        clicks++;
        numberofclicks.text = clicks.ToString();
    }
}
