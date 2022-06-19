using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellHandler : MonoBehaviour
{
    public List<GameObject> currentSpells = new List<GameObject>();
    public SpellBook currentSpellBook;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            CastSpell(currentSpellBook.spells[0]);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            CastSpell(currentSpellBook.spells[1]);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            CastSpell(currentSpellBook.spells[2]);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            CastSpell(currentSpellBook.spells[3]);
        }
    }

    void CastSpell(GameObject spell)
    {
        Spell spellScript = spell.GetComponent<Spell>();
        SpellData spellData = spellScript.spellData;
        spellScript.caster = gameObject;
        if (spellData.spellTypes == GameData.SpellTypes.Self)
        {
            CastSelf(spell);
        }
        else if (spellData.spellTypes == GameData.SpellTypes.Touch)
        {
            CastTouch(spell, spellData);
        }
        else
        {
            CastProjectile(spell, spellData);
        }
    }

    void CastSelf(GameObject spell)
    {
        GameObject spellGO = Instantiate(spell, transform.position, transform.localRotation);
        spellGO.transform.parent = transform;
        spellGO.GetComponent<Spell>().OnCast();
    }

    void CastTouch(GameObject spell, SpellData spellData)
    {
        Vector3 position = transform.position + (transform.forward * spellData.size);
        Collider[] colliders = Physics.OverlapSphere(position, spellData.size, 3);
        for (int i = 0; i < colliders.Length; i++)
        {
            GameObject spellGO = Instantiate(spell, colliders[i].transform.position, colliders[i].transform.localRotation);
            spellGO.transform.parent = colliders[i].transform;
            spellGO.GetComponent<Spell>().OnCast();
        }
    }

    void CastProjectile(GameObject spell, SpellData spellData)
    {
        Transform camera = transform.GetChild(0);
        Vector3 positionOffset = new Vector3(camera.transform.forward.x * spell.transform.localScale.x, 0, camera.transform.forward.z * spell.transform.localScale.z);
        GameObject spellGO = Instantiate(spell, transform.position + positionOffset, camera.transform.localRotation);
        spellGO.GetComponent<Spell>().OnCast();
    }
}
