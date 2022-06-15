using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ElementMenu : MonoBehaviour
{
    public int ElementNumber;
    public GameObject Menu;

    private const string pathFromResourcesFolder = @"Elements\";
    private const string elementFoundText = "открыт в          году";
    private const string elementNotFoundText = "Точное время открытия не установлено";

    public void StartElementMenu()
    {
        var ei = Resources.Load($"{pathFromResourcesFolder}{ElementNumber}", typeof(ElementInfo)) as ElementInfo;
        var menu = Menu.transform.GetChild(1);

        menu.transform.GetChild(0).GetComponent<Text>().text = ei.Name;
        menu.transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite = ei.Image;
        menu.transform.GetChild(1).GetChild(1).GetComponent<Text>().text = ei.ImageText;
        menu.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = ei.AtomicMass;
        menu.transform.GetChild(3).GetChild(0).GetComponent<Text>().text = ei.MeltingTemperature;
        menu.transform.GetChild(4).GetChild(0).GetComponent<Text>().text = ei.BoilingTemperature;
        if (!string.IsNullOrEmpty(ei.FoundingYear) || !string.IsNullOrEmpty(ei.Founder))
        {
            menu.transform.GetChild(5).GetComponent<Text>().text = elementFoundText;
            menu.transform.GetChild(5).GetChild(0).GetComponent<Text>().text = ei.FoundingYear;
            menu.transform.GetChild(5).GetChild(1).GetComponent<Text>().text = ei.Founder;
        }
        else
        {
            menu.transform.GetChild(5).GetComponent<Text>().text = elementNotFoundText;
            menu.transform.GetChild(5).GetChild(0).GetComponent<Text>().text = "";
            menu.transform.GetChild(5).GetChild(1).GetComponent<Text>().text = "";
        }
        menu.transform.GetChild(6).GetComponent<Text>().text = ei.Information;

        Menu.SetActive(true);
    }
}
