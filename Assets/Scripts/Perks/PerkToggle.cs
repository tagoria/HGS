using Personnage;
using UnityEngine;
using UnityEngine.UI;

namespace Perks
{
    public class PerkToggle : MonoBehaviour
    {
        public int perkId;

        public void TogglePerk()
        {
            var newValue = GetComponentInChildren<Toggle>().isOn;
            if (newValue)
                FindObjectOfType<CreationPersonnage>().AddPerk(perkId);
            else
                FindObjectOfType<CreationPersonnage>().DeletePerk(perkId);
        }
    }
}