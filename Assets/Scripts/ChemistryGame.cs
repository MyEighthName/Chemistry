using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChemistryGame : MonoBehaviour
{
    public ElementInput ElementInput;
    public GameObject[] Attempts;
    public GameObject WrongGuessPrefab;
    public GameObject WrongGuessParent;
    public GameObject MainIcon;
    public GameObject EnterButton;
    public GameObject PlayAgainButton;
    public GameObject LoseMessage;

    private ElementPTInformation ElementToGuess;
    private List<GameObject> WrongGuesses;

    void Start()
    {
        GetElementToGuess();
        WrongGuesses = new List<GameObject>();
    }

    private void GetElementToGuess()
    {
        var index = Random.Range(0, Constants.ElementsCount);
        ElementToGuess = Constants.Elements[index];
    }

    public void Guess(ElementPTInformation element)
    {
        if (element.Number == ElementToGuess.Number)
            OnCorrectGuess();
        else
            OnWrongGuess(element);
    }

    private void OnCorrectGuess()
    {
        Attempts[WrongGuesses.Count].transform.GetChild(0).GetComponent<Image>().color = new Color(.77f, .77f, .77f);
        Attempts[WrongGuesses.Count].transform.GetChild(1).GetComponent<Text>().text = ElementToGuess.Name;

        MainIcon.GetComponent<Image>().color = Constants.PTColors[ElementToGuess.Group].textColor;
        MainIcon.transform.GetChild(0).GetComponent<Image>().color = Constants.PTColors[ElementToGuess.Group].backColor;
        MainIcon.transform.GetChild(1).GetComponent<SymbolRandomizer>().EnableElementsSymbols = false;
        MainIcon.transform.GetChild(1).GetComponent<Text>().text = ElementToGuess.Symbol;
        MainIcon.transform.GetChild(2).GetComponent<Text>().text = ElementToGuess.Name;
        MainIcon.transform.GetChild(3).GetComponent<Text>().text = ElementToGuess.Number.ToString();

        for (var i = 1; i <= 3; i++)
        {
            MainIcon.transform.GetChild(i).GetComponent<Text>().color = Constants.PTColors[ElementToGuess.Group].textColor;
            MainIcon.transform.GetChild(i).GetComponent<SymbolRandomizer>().Enable = false;
        }

        EndGame();
    }
    
    private void OnWrongGuess(ElementPTInformation element)
    {
        var position = Attempts[WrongGuesses.Count].transform.position;
        Attempts[WrongGuesses.Count].SetActive(false);
        var guess = Instantiate(WrongGuessPrefab, Vector3.zero, Quaternion.identity);
        guess.SetActive(true);
        guess.name = $"WrongGuess{WrongGuesses.Count + 1}";
        var rectTransform = guess.GetComponent<RectTransform>();
        rectTransform.SetParent(WrongGuessParent.transform);
        guess.transform.position = position;
        rectTransform.localScale = Vector3.one;

        guess.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = element.Name;
        guess.transform.GetChild(1).GetChild(1).GetComponent<Text>().text = GetDirectionSymbol(element);
        guess.transform.GetChild(2).GetChild(0).GetComponent<Image>().color = GetGroupColor(element).backColor;
        guess.transform.GetChild(2).GetChild(1).GetComponent<Text>().color = GetGroupColor(element).textColor;
        guess.transform.GetChild(2).GetChild(1).GetComponent<Text>().text = Constants.ElementsGroupsNames[(int) element.Group];

        WrongGuesses.Add(guess);
        if (WrongGuesses.Count == Attempts.Length)
        {
            LoseMessage.SetActive(true);
            EndGame();
        }
    }

    private void EndGame()
    {
        EnterButton.SetActive(false);
        ElementInput.gameObject.SetActive(false);
        PlayAgainButton.SetActive(true);
    }

    private string GetDirectionSymbol(ElementPTInformation element)
    {
        var vector = new Vector2(ElementToGuess.X - element.X, ElementToGuess.Y - element.Y);
        vector.Normalize();

        if (vector.x < -.924)
            return "←";
        if (vector.x < -.383)
        {
            if (vector.y > 0)
                return "↖";
            return "↙";
        }
        if (vector.x < .383)
        {
            if (vector.y > 0)
                return "↑";
            return "↓";
        }
        if (vector.x < .924)
        {
            if (vector.y > 0)
                return "↗";
            return "↘";
        }
        return "→";
    }

    private (Color backColor, Color textColor) GetGroupColor(ElementPTInformation element)
    {
        if (element.Group == ElementToGuess.Group)
            return Constants.PTColors[element.Group];
        return (Color.white, Color.black);
    }
}
