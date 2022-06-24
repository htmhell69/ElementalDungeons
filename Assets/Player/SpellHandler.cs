using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SpellHandler : MonoBehaviour
{
    public List<GameObject> currentSpells = new List<GameObject>();
    public SpellBook currentSpellBook;
    public int currentSpell = 0;
    private Stats stats;
    private PlayerController playerController;
    public Slider manaSlider;
    private bool canCast;

    void Start()
    {
        stats = GetComponent<Stats>();
        playerController = GetComponent<PlayerController>();
    }
    void Update()
    {
        if (playerController.ui.isActive && canCast == true)
        {
            canCast = false;
        }
        if (playerController.ui.isActive && canCast == false)
        {
            canCast = true;
        }

        if (Input.GetMouseButtonDown(0) && canCast)
        {
            CastSpell(currentSpellBook.spells[currentSpell]);
        }
        if (Input.GetMouseButtonDown(1))
        {
            if (currentSpell >= currentSpellBook.spells.Length)
            {
                currentSpell = 0;
            }
            else
            {
                currentSpell += 1;
            }
        }
        if (stats.mana < stats.maxMana)
        {
            stats.mana += 1 * Time.deltaTime * stats.manaSpeed;
        }
        manaSlider.value = stats.mana;
        manaSlider.maxValue = stats.maxMana;
    }

    void CastSpell(GameObject spell)
    {
        Spell spellScript = spell.GetComponent<Spell>();
        SpellData spellData = spellScript.spellData;
        if (stats.mana >= spellData.manaCost)
        {
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
            stats.mana -= spellData.manaCost;
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
