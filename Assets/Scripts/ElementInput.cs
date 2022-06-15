using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ElementInput : MonoBehaviour
{
    public ChemistryGame Game;
    public Text BadElementMessage;

    private Text Text;
    private Text Placeholder;

    void Start()
    {
        Text = transform.Find("Text").GetComponent<Text>();
        Placeholder = transform.Find("Placeholder").GetComponent<Text>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
            Enter();
    }

    public void Enter()
    {
        var element = Constants.Elements.FirstOrDefault(e => IsCorrectElement(e, Text.text));
        if (element != null)
        {
            GetComponent<InputField>().text = "";
            Game.Guess(element);
        }
        else if (Text.text.Length > 0)
        {
            var c = BadElementMessage.color;
            BadElementMessage.color = new Color(c.r, c.g, c.b, 1);
        }
    }

    public static bool IsCorrectElement(ElementPTInformation e, string s)
        => string.Equals(e.Name.ToLower(), s.ToLower()) || string.Equals(e.Symbol.ToLower(), s.ToLower())
            || string.Equals(e.EnglishName.ToLower(), s.ToLower());
}
