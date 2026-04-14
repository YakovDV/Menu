using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEffectPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip[] _audioClips;

    public void OnButtonClicked()
    {
        if (_audioClips == null || _audioClips.Length == 0)
        {
            return;
        }


        if (_audioSource.isPlaying)
        {
            _audioSource.Stop();
        }

        int index = Random.Range(0, _audioClips.Length);
        _audioSource.PlayOneShot(_audioClips[index]);
    }
}