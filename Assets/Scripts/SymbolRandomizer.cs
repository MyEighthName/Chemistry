using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SymbolRandomizer : MonoBehaviour
{
    public bool Enable;
    public bool EnableElementsSymbols;
    public string PossibleCharactersString;
    public float Delay;

    private string text;
    private float elapsedTime;

    private void Start()
    {
        text = GetComponent<Text>().text;
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= Delay)
        {
            if (Enable && PossibleCharactersString.Length > 0)
            {
                var chars = new object[text.Length]
                    .Select(e => Random.Range(0, PossibleCharactersString.Length))
                    .Select(e => PossibleCharactersString[e]);
                GetComponent<Text>().text = string.Join("", chars);
            }
            else if (EnableElementsSymbols)
                GetComponent<Text>().text = Constants.Elements[Random.Range(0, Constants.ElementsCount)].Symbol;
            elapsedTime = 0;
        }
    }
}
