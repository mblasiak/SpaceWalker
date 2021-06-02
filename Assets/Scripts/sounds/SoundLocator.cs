using System;
using System.Collections.Generic;
using UnityEngine;

public class SoundLocator
{
    private static readonly Dictionary<string, SoundPlayer> _players = new Dictionary<string, SoundPlayer>();

    public static SoundPlayer getPlayer(String playerName)
    {
        return _players[playerName];
    }

    public static void registerPlayer(String playerName, SoundPlayer soundPlayer)
    {
        _players.Add(playerName, soundPlayer);
    }
}