using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    [SerializeField, Min(0)] private float fadeTime;

    private AudioSource _audioSource;
    private float _targetVolume;
    private float _maxVolume = 1;
    private float _minVolume = 0;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void ActivateAlarm()
    {
        _targetVolume = _maxVolume;
        StartCoroutine(ChangeVolume());
    }

    public void DeactivateAlarm()
    {
        _targetVolume = _minVolume;
        StartCoroutine(ChangeVolume());
    }

    private IEnumerator ChangeVolume()
    {
        while (_audioSource.volume != _targetVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _targetVolume, Time.deltaTime / fadeTime);

            yield return null;
        }
    }
}
