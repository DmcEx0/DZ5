using UnityEngine.Events;
using UnityEngine;

public class TriggerForAlarm : MonoBehaviour
{
    [SerializeField] private UnityEvent _alarmOn;
    [SerializeField] private UnityEvent _alarmOff;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _alarmOn?.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _alarmOff?.Invoke();
    }
}
