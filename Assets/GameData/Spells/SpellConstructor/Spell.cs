using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    public SpellData spellData;
    public GameObject caster;
    public int level;
    public virtual void OnCast()
    {
        Debug.Log("spell was casted");
    }
}
