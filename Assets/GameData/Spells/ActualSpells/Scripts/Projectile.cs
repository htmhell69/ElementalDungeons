using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : Spell
{

    public override void OnCast()
    {
        Debug.Log("i was casted");
    }

    void Update()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * spellData.speed);
    }
}
