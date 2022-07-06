using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StatDelegateButton : MonoBehaviour
{
    public EntityStats stat;
    public float multiplier;
    public GameObject player;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(delegate { player.GetComponent<Stats>().UpgradeStat(stat, multiplier, true); });
    }
}
