using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PerkToggle : MonoBehaviour {

    public int perkId;
    public void TogglePerk()
    {
        bool newValue=GetComponentInChildren<Toggle>().isOn;
        if (newValue)
        {
            Component.FindObjectOfType<CreationPersonnage>().AddPerk(perkId);
        }
        else
        {
            Component.FindObjectOfType<CreationPersonnage>().DeletePerk(perkId);
        }
    }
}
