using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "new SpellData", menuName = "Spells/SpellData")]
public class SpellData : ScriptableObject
{
    [Header("Spell Info")]
    public string spellName;
    public GameData.Types elementType;
    public int manaCost;
    public float castCooldown;
    [Header("Base Stats")]
    public float main;
    public float size;
    public float effectChance;
    public GameData.Effects effect;

    [Header("Projectile Stats")]
    public float range;
    public float speed;
    public float blastRadius;
}

