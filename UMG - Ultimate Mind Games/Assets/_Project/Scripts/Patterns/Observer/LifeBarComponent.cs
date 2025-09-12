using UnityEngine;
using UnityEngine.UI;

public class LifeBarComponent : MonoBehaviour
{
    [SerializeField] private Image _fillImage;
    [SerializeField] private bool _flipY;
    [SerializeField] private int _player;

    private Combatent _combatent;

    private void Awake()
    {
        IEventService eventService = ServiceLocator.GetService<IEventService>();
        eventService.AddListener<OnSetUpPlayerEvent>(Setup, GetHashCode());
    }

    private void OnDestroy()
    {
        IEventService eventService = ServiceLocator.GetService<IEventService>();
        eventService.RemoveListener<OnSetUpPlayerEvent>(GetHashCode());
    }

    private void Setup(OnSetUpPlayerEvent onSetUpPlayerEvent)
    {
        if(_player != onSetUpPlayerEvent.Player)
        {
            return;
        }

        _combatent = onSetUpPlayerEvent.CombatentModule;
        _combatent.OnTookDamage = UpdateLifeBar;

        _fillImage.fillAmount = 1;
        _fillImage.fillOrigin = !_flipY ? 0 : 1;
    }

    private void UpdateLifeBar(int currentLife, int maxLife)
    {
        _fillImage.fillAmount = currentLife / (float)maxLife;
    }
}
