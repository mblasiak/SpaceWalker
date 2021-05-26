using System;
using System.Collections.Generic;
using UnityEngine;

public class HeroSoundPlayer : SoundPlayer
{
    Dictionary<string, AudioClip> clips =
        new Dictionary<string, AudioClip>();

    private static AudioSource _audioSource;

    public HeroSoundPlayer(AudioSource audioSource)
    {
        _audioSource = audioSource;
        clips.Add("jump_eq", Resources.Load<AudioClip>("sounds/player/jump_equipemnt_sound"));
        clips.Add("jump_fat", Resources.Load<AudioClip>("sounds/player/jump_fat_sound"));
    }

    public void playSound(String soundName)
    {
        _audioSource.PlayOneShot(clips[soundName]);
    }

    public void stopSounds()
    {
        _audioSource.Stop();
    }
}