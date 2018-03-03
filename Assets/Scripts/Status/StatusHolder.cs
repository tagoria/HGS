using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Status
{
    public class StatusHolder : MonoBehaviour
    {
        public static StatusHolder instance;
        private List<GameObject> statusAffiches;
        public GameObject statusTemplate;

        private void Awake()
        {
            instance = this;
            statusAffiches = new List<GameObject>();
        }

        public void afficherStatus(Dictionary<int, StatusAbstract> status)
        {
            foreach (var textes in statusAffiches) Destroy(textes);
            var hauteur = 0;
            foreach (var statu in status.Values)
            {
                var texte = Instantiate(statusTemplate, transform);
                statusAffiches.Add(texte);
                texte.GetComponent<Text>().text = statu.ToString();
                texte.transform.localPosition = new Vector2(0, hauteur);
                hauteur -= 60;
            }
        }
    }
}