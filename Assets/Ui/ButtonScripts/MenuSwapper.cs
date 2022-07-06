using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MenuSwapper : MonoBehaviour
{
    public Ui ui;
    public Menus menu;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(delegate { ui.SwitchMenus(menu); });
    }


}
