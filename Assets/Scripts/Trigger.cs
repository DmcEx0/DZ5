using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    private float _valueOfTarget;
    private bool _isStartCorutine;

    private AudioSource _audio;
    private Coroutine _changingSound;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    private void Update()
    {

    }

    private void StartChangeSound()
    {
        _isStartCorutine = true;
        _changingSound = StartCoroutine(ChangeSound());
        _audio.Play();
    }

    private void StopChangeSound()
    {
        _isStartCorutine = false;
        StopCoroutine(_changingSound);
        _audio.Stop();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            StartChangeSound();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            StopChangeSound();
        }
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
}
