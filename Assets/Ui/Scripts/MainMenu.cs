using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class MainMenu : MonoBehaviour
{
    public Button levelUp;
    public PlayerController playerController;
    public Ui ui;
    void OnEnable()
    {
        if (!playerController.canLevelUp)
        {
            levelUp.interactable = false;
        }
        else
        {
            levelUp.onClick.AddListener(delegate { ui.SwitchMenus(Menus.LevelUp); });
        }
    }
}
