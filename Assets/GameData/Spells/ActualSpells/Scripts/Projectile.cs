using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : Spell
{
    public bool hasEffects;
    private Vector3 startPosition;
    public override void OnCast()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * spellData.speed);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == 7)
        {
            if (other.gameObject != caster)
            {
                other.gameObject.GetComponent<Stats>().hp -= spellData.main + caster.GetComponent<Stats>().level * spellData.levelMultiplier;
                if (Random.Range(1, 100) >= spellData.effectChance)
                {
                    GetComponent<MeshRenderer>().enabled = false;
                    Destroy(this);
                }
                else
                {
                    Destroy(this.gameObject);
                }
            }
        }
        else if (other.gameObject.layer == 6)
        {
            Destroy(this.gameObject);
        }
    }
}
