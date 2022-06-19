using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Spell Book", menuName = "Spells/Spell Book")]
public class SpellBook : ScriptableObject
{
    public GameObject[] spells = new GameObject[4];

}
