using UnityEngine;
using UnityEngine.UI;

public class PeriodicTableCreator : MonoBehaviour
{
    public GameObject Parent;
    public float IconSize;
    public float GapSize;

    public GameObject ButtonPrefab;

    public void Start()
    {
        foreach (var element in Constants.Elements)
            CreateElementIcon(element);
        Parent.GetComponent<RectTransform>().localScale = Vector2.one *
            Parent.transform.parent.GetComponent<RectTransform>().localScale.x;
    }

    private void CreateElementIcon(ElementPTInformation element)
    {
        var button = Instantiate(ButtonPrefab, Vector3.zero, Quaternion.identity);
        button.SetActive(true);
        button.name = element.Number.ToString();
        var rectTransform = button.GetComponent<RectTransform>();
        rectTransform.SetParent(Parent.transform);

        button.GetComponent<Image>().color = element.BackColor;

        var buttonColors = button.GetComponent<Button>().colors;
        buttonColors.highlightedColor = element.BackColor;
        button.GetComponent<Button>().colors = buttonColors;

        var symbol = button.transform.Find("Symbol");
        symbol.GetComponent<Text>().text = element.Symbol;
        symbol.GetComponent<Text>().color = element.TextColor;

        var number = button.transform.Find("Number");
        number.GetComponent<Text>().text = element.Number.ToString();
        number.GetComponent<Text>().color = element.TextColor;

        var name = button.transform.Find("Name");
        name.GetComponent<Text>().text = element.Name;
        name.GetComponent<Text>().color = element.TextColor;

        button.GetComponent<ElementMenu>().ElementNumber = element.Number;

        rectTransform.position = new Vector2((IconSize + GapSize) * element.X, (IconSize + GapSize) * element.Y);
    }
}
