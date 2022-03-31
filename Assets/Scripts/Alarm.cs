using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Alarm : MonoBehaviour
{
    private float _valueOfTarget;
    private bool _isStartCorutine;

    private Coroutine _changingSound;
    private AudioSource _audio;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    private IEnumerator ChangeSound()
    {
        float minValue = 0.2f;
        float maxValue = 1f;

        var waitForSecond = new WaitForSeconds(0.01f);
        var volume = _audio.volume;
        float maxDelta = 2f;

        while (_isStartCorutine)
        {
            volume = Mathf.MoveTowards(volume, _valueOfTarget, maxDelta * Time.deltaTime);
            _audio.volume = volume;

            if (_audio.volume == maxValue)
                _valueOfTarget = minValue;

            if (_audio.volume <= minValue)
                _valueOfTarget = maxValue;

            yield return waitForSecond;
        }
    }

    public void StartChangeSound()
    {
        _isStartCorutine = true;
        _changingSound = StartCoroutine(ChangeSound());
        _audio.Play();
    }

    public void StopChangeSound()
    {
        _isStartCorutine = false;
        StopCoroutine(_changingSound);
        _audio.Stop();
    }
}
