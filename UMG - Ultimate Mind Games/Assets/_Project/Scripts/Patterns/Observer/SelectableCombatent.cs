using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectableCombatent : MonoBehaviour, ISelectHandler
{
    [SerializeField] private Button _button;
    [SerializeField] private Image _image;
    [SerializeField] private CombatentData _combatentData;

    private IEventService _eventService;

    public void Awake()
    {
        _eventService = ServiceLocator.GetService<IEventService>();
        _button.onClick.AddListener(HandleButtonPressed);
        _image.sprite = _combatentData.PreviewSprite;
    }

    public void OnSelect(BaseEventData eventData)
    {
        _eventService.TryInvokeEvent(new SelectedCharacterEvent(_combatentData, false));
        Debug.Log("Selected");
    }

    private void HandleButtonPressed()
    {
        _eventService.TryInvokeEvent(new SelectedCharacterEvent(_combatentData, true));
        Debug.Log("Pressed");
    }


}
