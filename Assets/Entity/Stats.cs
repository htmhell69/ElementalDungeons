using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public float maxHp;
    public float hp;
    public float maxMana;
    public float mana;
    public float movementSpeed = 1;
    public float baseDamage;
    public LevelMultipliers levelMultipliers;
    public float level;
    public float xp;
}

[System.Serializable]
public class LevelMultipliers
{
    public float maxHp;
    public float maxMana;
    public float movementSpeed;
    public float baseDamage;
    public float manaSpeed;
    public LevelMultipliers(float maxHp, float maxMana, float manaSpeed, float movementSpeed, float baseDamage)
    {
        this.maxHp = maxHp;
        this.maxMana = maxMana;
        this.movementSpeed = movementSpeed;
        this.baseDamage = baseDamage;
        this.manaSpeed = manaSpeed;
    }
}