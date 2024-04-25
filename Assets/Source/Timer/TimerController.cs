using UnityEngine;
using Zenject;

public class TimerController : AJsonSaver
{
    private const string TIME_KEY = "TimePlayed";

    private TimerView _view;
    private float _passedTime;

    [Inject]
    public void Construct(TimerView timerView)
    {
        _view = timerView;
        saveKey = TIME_KEY;
    }

    void Update()
    {
        _passedTime += Time.deltaTime;
        ConvertToTime();
    }

    public override void SetLoadedData(object data)
    {
        _passedTime = float.Parse(data.ToString());
    }
    
    
    public override object GetDataForSave()
    {
        return _passedTime;
    }

    private void ConvertToTime()
    {
        int hours = Mathf.FloorToInt(_passedTime / 3600f);
        int minutes = Mathf.FloorToInt((_passedTime - hours * 3600f) / 60f);
        int seconds = Mathf.FloorToInt((_passedTime - hours * 3600f) - (minutes * 60f));

        _view.SetTimeText(hours, minutes, seconds);
    }
}
