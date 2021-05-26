using System;
using System.Collections.Generic;
using UnityEngine;

public class SoundLocator : MonoBehaviour
{
    private static readonly Dictionary<string, SoundPlayer> _players = new Dictionary<string, SoundPlayer>();

    void Start()
    {
        // _players.Add("", GameObject new HeroSoundPlayer());
    }

    public static SoundPlayer getPlayer(String playerName)
    {
        return _players[playerName];
    }

    private static void registerPlayer(String playerName, SoundPlayer soundPlayer)
    {
        _players.Add(playerName, soundPlayer);
    }
}