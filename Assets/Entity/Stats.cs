using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Stats : MonoBehaviour
{
    public float maxHp;

    public float maxMana;
    public float manaSpeed;

    public float movementSpeed = 1;
    public float baseDamage;
    public float level;
    [Header("PlaceHolders")]
    public float xp;
    public float iFrameTimer;
    public float freezeTimer;
    public float mana;
    public float hp;
    PlayerController playerController;

    void Start()
    {
        playerController = GetComponent<PlayerController>();
    }
    void Update()
    {
        if (gameObject.tag == "Player" && xp == level * 100 && !playerController.canLevelUp)
        {
            xp -= level * 100;
            level += 1;
            playerController.canLevelUp = true;
        }
    }



    public void UpgradeStat(EntityStats stat, float multiplier, bool closeUi)
    {
        switch (stat)
        {
            case EntityStats.maxHp:
                maxHp *= multiplier;
                break;
            case EntityStats.maxMana:
                maxMana *= multiplier;
                break;
            case EntityStats.manaSpeed:
                manaSpeed *= multiplier;
                break;
            case EntityStats.movementSpeed:
                movementSpeed *= multiplier;
                break;
            case EntityStats.baseDamage:
                movementSpeed *= multiplier;
                break;
        }
        if (playerController.ui.currentMenu == Menus.LevelUp)
        {
            playerController.canLevelUp = false;
        }
        if (closeUi)
        {
            playerController.ui.SwitchMenus(Menus.None);
        }

    }

    public void UpgradeSpell()
    {
        if (playerController.ui.currentMenu == Menus.LevelUp)
        {
            playerController.canLevelUp = false;
        }
        playerController.ui.callbackFunction = PostUpgradeSpellUi;
        playerController.ui.SwitchMenus(Menus.SpellChooser);
    }

    public bool PostUpgradeSpellUi(GameObject button)
    {

        if (button == null)
        {
            return false;
        }
        else
        {
            playerController.ui.SwitchMenus(Menus.None);
            SpellButtonData buttonData = button.GetComponent<SpellButtonData>();
            int spellIndex = buttonData.index;
            GameObject owner = buttonData.owner;
            owner.GetComponent<SpellHandler>().spellLevels[spellIndex] += 1;
            return true;
        }
    }
}

public enum EntityStats
{
    maxHp,

    maxMana,
    manaSpeed,

    movementSpeed,
    baseDamage,
    level,
    xp,
    iFrameTimer,
    freezeTimer,
    mana,
    hp
}