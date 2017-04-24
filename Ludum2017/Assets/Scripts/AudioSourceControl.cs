using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceControl : MonoBehaviour
{
    //FIELDS
    private AudioSource _audioSource;
    public AudioClip[] AudioFiles;
    private int _SoundFileSelect = 0;

    //Methods

    private void Start()
    {
        _audioSource = this.GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (!_audioSource.isPlaying)
        {
            _audioSource.PlayOneShot(AudioFiles[_SoundFileSelect], 2);
            _SoundFileSelect += 1;
            if (_SoundFileSelect > AudioFiles.Length - 1)
            {
                _SoundFileSelect = 0;
            }
        }
        
    }
}
