using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Alarm : MonoBehaviour
{
    private float _valueOfTarget;
    private bool _isActivationCoroutine;

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
        float maxDelta = 2f;

        while (_isActivationCoroutine)
        {
            _audio.volume = Mathf.MoveTowards(_audio.volume, _valueOfTarget, maxDelta * Time.deltaTime);

            if (_audio.volume == maxValue)
                _valueOfTarget = minValue;

            if (_audio.volume <= minValue)
                _valueOfTarget = maxValue;

            yield return waitForSecond;
        }
    }

    public void TurnOn()
    {
        _isActivationCoroutine = true;
        _changingSound = StartCoroutine(ChangeSound());
        _audio.Play();
    }

    public void TurnOff()
    {
        _isActivationCoroutine = false;
        StopCoroutine(_changingSound);
        _audio.Stop();
    }
}
