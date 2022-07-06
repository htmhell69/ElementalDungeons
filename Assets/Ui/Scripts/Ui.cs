using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Ui : MonoBehaviour
{
    public Func<GameObject, bool> callbackFunction;
    public GameObject levelUp;
    public GameObject mainMenu;
    public GameObject spellChooser;
    public GameObject inventory;
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

    public void RunCallBack()
    {
        if (callbackFunction != null)
        {
            callbackFunction(EventSystem.current.currentSelectedGameObject);
            callbackFunction = null;
        }
    }

    public GameObject GetMenu(Menus menu)
    {
        switch (menu)
        {
            case Menus.LevelUp:
                return levelUp;
            case Menus.SpellChooser:
                return spellChooser;
            case Menus.MainMenu:
                return mainMenu;
            case Menus.Inventory:
                return inventory;
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

    public void Quit()
    {
        Application.Quit();
    }
}

public enum Menus
{
    None,
    LevelUp,
    SpellChooser,
    MainMenu,
    Inventory
}