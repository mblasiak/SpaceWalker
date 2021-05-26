using System;
using System.Collections.Generic;
using UnityEngine;

public class HeroSoundPlayer : MonoBehaviour, SoundPlayer
{
    Dictionary<string, AudioClip> clips =
        new Dictionary<string, AudioClip>();

    private static AudioSource _audioSource;

    void Start()
    {
        clips.Add("jump", Resources.Load<AudioClip>("sounds/player/jump_equipemnt_sound"));
        _audioSource = GetComponent<AudioSource>();
    }

    public void playSound(String soundName)
    {
        _audioSource.PlayOneShot(clips["jump"]);
    }

    public void stopSounds()
    {
        _audioSource.Stop();
    }
}