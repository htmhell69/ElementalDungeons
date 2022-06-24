using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ui : MonoBehaviour
{
    public GameObject levelUp;
    public bool isActive;
    public Menus currentMenu;
    public Menus previousMenu;
    public void SwitchMenus(Menus menu)
    {
        if (menu == Menus.None)
        {
            isActive = false;
            GetMenu(currentMenu).SetActive(false);
            previousMenu = currentMenu;
            currentMenu = menu;
        }
        else
        {
            isActive = true;
            if (currentMenu != Menus.None)
            {
                GetMenu(currentMenu).SetActive(false);
            }
            GameObject menuGO = GetMenu(menu);
            menuGO.SetActive(true);
            currentMenu = menu;
            previousMenu = currentMenu;
        }
    }

    public GameObject GetMenu(Menus menu)
    {
        switch (menu)
        {
            case Menus.LevelUp:
                return levelUp;
        }
        return null;
    }


    public void Back()
    {
        currentMenu = previousMenu;
        previousMenu = currentMenu;
    }

    public void Start()
    {
        isActive = false;
    }
}

public enum Menus
{
    None,
    LevelUp
}