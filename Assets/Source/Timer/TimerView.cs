using TMPro;
using UnityEngine;


public class TimerView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _time;

    public void SetTimeText(int hours, int minutes, int seconds) =>
        _time.text = $"{hours}h {minutes}m {seconds}s";
}
