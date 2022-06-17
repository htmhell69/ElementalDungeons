using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityEffects : MonoBehaviour
{
    List<GameData.Effects> effects;

    void Update()
    {
        if (effects.Count != 0)
        {
            for (int i = 0; i > effects.Count; i++)
            {
                if (effects[i] == GameData.Effects.Poison)
                {

                }
            }
        }
    }
}
