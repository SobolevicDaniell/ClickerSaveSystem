using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class ClickerController : APlayerPrefsSaver, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private float pointMult;

    private const string _key = "Points";
    
    private ClickerView _view;
    private float _points;
    private float _pointsPerPress;
    private bool isPressed;

    [Inject]
    public void Construct(ClickerView clickerView)
    {
        _view = clickerView;
        SaveKey = _key;
    }

    void Start()
    {
        _view.SetText($"{_points:F2}");
    }

    private void Update()
    {
        if (isPressed)
            _pointsPerPress += Time.deltaTime;

    }

    public void OnPointerDown(PointerEventData eventData) =>
        isPressed = true;

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
        _points += pointMult * _pointsPerPress;
        _pointsPerPress = 0;
        _view.SetText($"{_points:F2}");
    }

    public override void SetLoadedData(object data) =>
        _points = float.Parse(data.ToString());

    public override object GetDataForSave() => _points;
}
