using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Element Info", order = 51)]
public class ElementInfo : ScriptableObject
{
    [SerializeField]
    public int Number;
    [SerializeField]
    public string Symbol;
    [SerializeField]
    public string Name;
    [SerializeField]
    public string AtomicMass;
    [SerializeField]
    public string MeltingTemperature;
    [SerializeField]
    public string BoilingTemperature;
    [SerializeField]
    public string FoundingYear;
    [SerializeField]
    public string Founder;
    [SerializeField]
    public string Information;
    [SerializeField]
    public string ImageText;
    [SerializeField]
    public Sprite Image;
}