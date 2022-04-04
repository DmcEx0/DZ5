using UnityEngine.Events;
using UnityEngine;

public class TriggerForAlarm : MonoBehaviour
{
    [SerializeField] private UnityEvent _entryInTrigger;
    [SerializeField] private UnityEvent _exitFromTrigger;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _entryInTrigger?.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _exitFromTrigger?.Invoke();
    }
}
