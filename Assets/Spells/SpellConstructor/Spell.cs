using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Spell", menuName = "Spells/Spell")]
public class Spell : ScriptableObject
{
    public int manaCost;
    public GameObject spell;
}
