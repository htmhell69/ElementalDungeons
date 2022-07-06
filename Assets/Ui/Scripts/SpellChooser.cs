using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SpellChooser : MonoBehaviour
{
    List<GameObject> pages = new List<GameObject>();
    public GameObject spellCaster;
    public GameObject spellButton;
    public GameObject page;
    int lastSpellNumber = 0;
    SpellHandler spellHandler;


    void OnEnable()
    {
        spellHandler = spellCaster.GetComponent<SpellHandler>();
        for (int i = lastSpellNumber; i < spellHandler.currentSpells.Count; i++)
        {
            CreateSpellButton(i);
        }
        lastSpellNumber = spellHandler.currentSpells.Count;
    }

    void CreateSpellButton(int index)
    {
        GameObject spell = spellHandler.currentSpells[index];
        Spell spellScript = spell.GetComponent<Spell>();
        GameObject newSpellButton = Instantiate(spellButton);
        newSpellButton.GetComponent<Button>().onClick.AddListener(spellCaster.GetComponent<PlayerController>().ui.RunCallBack);
        SpellButtonData spellButtonData = newSpellButton.GetComponent<SpellButtonData>();
        spellButtonData.index = index;
        spellButtonData.owner = spellCaster;
        int pageIndex = Mathf.FloorToInt(index / 39);
        if (pages.Count - 1 < pageIndex)
        {
            GameObject newPage = Instantiate(page, page.GetComponent<RectTransform>().anchoredPosition, page.transform.rotation);
            newPage.transform.SetParent(transform, false);
            pages.Add(newPage);
        }
        pages[pageIndex].SetActive(true);

        spellButtonData.transform.SetParent(pages[pageIndex].transform, false);
        TMP_Text buttonText = newSpellButton.transform.GetChild(0).gameObject.GetComponent<TMP_Text>();
        buttonText.text = spellScript.spellData.spellName;
    }
}
