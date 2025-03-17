using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class showrolloverhightlights : MonoBehaviour
{
    public Image image;

    public Sprite highlight;
    public Sprite normal;

    public TextMeshProUGUI reactionText;
  public void MouseisOver()
    {
        image.sprite = highlight;
        reactionText.text = "Blergh";
    }
    public void OnMouseisnoton()
    {
        image.sprite = normal;
        reactionText.text = "yummers";
    }
}
