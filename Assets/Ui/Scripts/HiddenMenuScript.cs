using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HiddenMenuScript : MonoBehaviour
{
    public GameObject menu;
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(delegate { menu.SetActive(!menu.activeSelf); });
    }

}
