using TMPro;
using UnityEngine;


public class ClickerView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI pointsText;

    public void SetText(string text)
    {
        pointsText.text = text;
    }
}
