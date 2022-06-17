using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    SpellData spellData;

    public virtual void OnCast()
    {
        Debug.Log("i was casted");
    }
}