using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextTransparenter : MonoBehaviour
{
    public Text Text;
    public float DeltaA;

    void Update()
    {
        var c = Text.color;
        Text.color = new Color(c.r, c.g, c.b, Mathf.Max(0, c.a - DeltaA));
    }
}
