using System.Collections;
using System.Collections.Generic;
using Events;
using UnityEngine;

namespace Utils
{
    public class Sauvegarde : MonoBehaviour
    {
        public static readonly string TRAVAIL = "travail";
        public static readonly string ENERGIE = "energie";
        public static readonly string BONHEUR = "bonheur";
        public static readonly string EVENEMENTPASSE = "evenement";
        public static readonly string ATTRIBUTSJOUEUR = "atbjoueur";
        public static readonly string SAUVEGARDEFLOTTANTE = "SauvegardeFloat";
        private static IDictionary valeursFlottantes;

        private static IDictionary evenementPasse;

        // Use this for initialization
        private void Awake()
        {
            load();
        }

        public object get(string key)
        {
            return valeursFlottantes[key];
        }

        // Update is called once per frame
        private void Update()
        {
        }

        public void save()
        {
            PlayerPrefs.SetFloat(TRAVAIL, (float) valeursFlottantes[TRAVAIL]);
            PlayerPrefs.SetFloat(BONHEUR, (float) valeursFlottantes[BONHEUR]);
            PlayerPrefs.SetFloat(ENERGIE, (float) valeursFlottantes[ENERGIE]);
            var sauvegardeHistoriqueEvenement = JsonUtility.ToJson(evenementPasse);
            PlayerPrefs.SetString(EVENEMENTPASSE, sauvegardeHistoriqueEvenement);
            PlayerPrefs.Save();
        }

        public void load()
        {
            if (PlayerPrefs.HasKey(TRAVAIL) && PlayerPrefs.HasKey(BONHEUR) && PlayerPrefs.HasKey(ENERGIE))
            {
                valeursFlottantes[TRAVAIL] = PlayerPrefs.GetFloat(TRAVAIL);
                valeursFlottantes[ENERGIE] = PlayerPrefs.GetFloat(ENERGIE);
                valeursFlottantes[BONHEUR] = PlayerPrefs.GetFloat(BONHEUR);
            }
            else
            {
                valeursFlottantes = new Dictionary<string, float>();
                valeursFlottantes[TRAVAIL] = 50f;
                valeursFlottantes[ENERGIE] = 50f;
                valeursFlottantes[BONHEUR] = 50f;
            }

            if (PlayerPrefs.HasKey(EVENEMENTPASSE))
                evenementPasse =
                    JsonUtility.FromJson<Dictionary<int, EvenementAbstract>>(PlayerPrefs.GetString(EVENEMENTPASSE));
            else
                evenementPasse = new Dictionary<int, EvenementAbstract>();
        }

        private void OnApplicationQuit()
        {
            save();
        }

        private void OnApplicationPause(bool pause)
        {
            save();
        }

        public void addEventToHistoric(EvenementAbstract evenement)
        {
            if (!evenementPasse.Contains(evenement.getId()))
            {
                evenementPasse.Add(evenement.getId(), evenement);
                save();
            }
        }

        public Dictionary<int, EvenementAbstract> getEventHistoric()
        {
            return (Dictionary<int, EvenementAbstract>) evenementPasse;
        }

        public void setTravail(float f)
        {
            valeursFlottantes[TRAVAIL] = f;
            save();
        }
    }
}