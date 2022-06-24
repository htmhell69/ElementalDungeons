using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if (gameObject.tag == "Player" && xp == level * 100)
        {
            level += 1;
            xp -= level * 100;
            playerController.ui.SwitchMenus(Menus.LevelUp);
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
        hp,
    }

    public void UpgradeStat(EntityStats stat)
    {
        float multiplier = 0.25f;
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
    }

    public void UpgradeSpeed()
    {
        movementSpeed *= 1.25f;
        playerController.ui.SwitchMenus(Menus.None);
    }

    public void UpgradeMaxMana()
    {
        maxMana *= 1.25f;
        playerController.ui.SwitchMenus(Menus.None);
    }
    public void UpgradeMaxHp()
    {
        maxHp *= 1.25f;
        playerController.ui.SwitchMenus(Menus.None);
    }
    public void UpgradeManaSpeed()
    {
        manaSpeed *= 1.25f;
        playerController.ui.SwitchMenus(Menus.None);
    }
    public void UpgradeBaseDamage()
    {
        baseDamage *= 10f;
        playerController.ui.SwitchMenus(Menus.None);
    }
}
