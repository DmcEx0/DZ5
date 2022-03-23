using UnityEngine.Events;
using UnityEngine;

public class TriggerForAlarm : MonoBehaviour
{
    [SerializeField] private UnityEvent _alarmOn;
    [SerializeField] private UnityEvent _alarmOff;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _alarmOn.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _alarmOff.Invoke();
        }
    }
}
