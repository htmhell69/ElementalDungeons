using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameData
{
    public enum Types
    {
        Fire,
        Earth,
        Water,
        Lightning,
        DarkMagic,
        LightMagic
    }

    public enum SpellTypes
    {
        Projectile
    }

    public enum Effects
    {
        None,
        Poison
    }



}

public struct EffectParams
{
    public float multiplier;
    public float duration;
}