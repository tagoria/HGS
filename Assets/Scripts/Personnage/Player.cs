using System.Collections.Generic;
using System.Linq;
using Enums;
using Perks;
using Status;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utils;

namespace Personnage
{
    public class Player : MonoBehaviour
    {
        internal static Player instance;
        public Barre barreEnergie;
        public Barre barresocial;
        public Barre barreTravail;
        private float energieActuelle;
        internal float energieDep;
        public float energieDepBase;

        internal Dictionary<int, Perk> listePerk;
        private Dictionary<int, StatusAbstract> listeStatus;
        public float maxEnergieBase;
        internal float maxEnergiePerso;
        public float maxsocialBase;
        internal float maxsocialPerso;
        public float maxTravailBase;
        internal float maxTravailPerso;

        private string nom;

        //Représente le fait que le personnage est occupé où non ,influe sur les évènements en faisant raté des RDV par exemple
        public bool occuppe;
        private float socialActuel;
        internal float socialDep;
        public float socialDepBase;
        private float travailActuel;
        internal float travailDep;
        public float travailDepBase;

        private void Awake()
        {
            listeStatus = new Dictionary<int, StatusAbstract>();
            instance = this;
        }

        // Use this for initialization
        private void Start()
        {
        }

        internal void SetPerks(Dictionary<int, Perk> perks)
        {
            listePerk = perks;
            AppliquerPerks();
        }

        public bool HasPerk(PerksEnum perk)
        {
            return listePerk.ContainsKey((int) perk);
        }

        public void Recommencer()
        {
            energieActuelle = energieDep;
            socialActuel = socialDep;
            travailActuel = travailDep;
            RemplirBarres();
        }

        internal bool HasStatus(StatusEnum status)
        {
            return listeStatus.ContainsKey((int) status);
        }

        public void AjouterStatus(StatusAbstract status)
        {
            if (listeStatus.ContainsKey(status.id))
            {
                if (status.isAddable()) listeStatus[status.id].add(status);
            }
            else
            {
                status.onStart();
                listeStatus.Add(status.id, status);
            }

            StatusHolder.instance.afficherStatus(listeStatus);
        }

        public void RemplirBarres()
        {
            barreEnergie.valeurCap = maxEnergiePerso;
            barresocial.valeurCap = maxsocialPerso;
            barreTravail.valeurCap = maxTravailPerso;
            barreEnergie.Valeur=energieActuelle;
            barresocial.Valeur=socialActuel;
            barreTravail.Valeur=travailActuel;
        }

        private void AppliquerPerks()
        {
            maxEnergiePerso = maxEnergieBase;
            maxsocialPerso = maxsocialBase;
            maxTravailPerso = maxTravailBase;
            energieDep = energieDepBase;
            travailDep = travailDepBase;
            socialDep = socialDepBase;
            foreach (var perk in listePerk.Values)
            {
                print(perk.id);
                perk.appliquer();
            }

            energieActuelle = energieDep;
            socialActuel = socialDep;
            travailActuel = travailDep;
            RemplirBarres();
        }

        internal void AffecterStatus(int nbCréneaux)
        {
            if (listeStatus == null || listeStatus.Count == 0) return;
            for (var i = 0; i < nbCréneaux; i++)
            {
                var copie = listeStatus.Values;
                foreach (var status in listeStatus.Values.ToArray()) status.onTimePass();
            }

            StatusHolder.instance.afficherStatus(listeStatus);
        }

        public void RemoveStatus(int status)
        {
            listeStatus.Remove(status);
            StatusHolder.instance.afficherStatus(listeStatus);
        }


        public float GetEnergieActuelle()
        {
            return energieActuelle;
        }

        public float GetSocialActuel()
        {
            return socialActuel;
        }

        public float GetTravailActuel()
        {
            return travailActuel;
        }

        public void AugmenterEnergieActuelle(float f)
        {
            if (energieActuelle + f > maxEnergiePerso)
                energieActuelle = maxEnergiePerso;
            else
                energieActuelle += f;
            barreEnergie.Valeur=energieActuelle;
        }

        public void AugmenterSocialActuel(float f)
        {
            if (socialActuel + f > maxsocialPerso)
                socialActuel = maxsocialPerso;
            else
                socialActuel += f;
            barresocial.Valeur=socialActuel;
        }

        public void AugmenterTravailActuel(float f)
        {
            if (travailActuel + f > maxTravailPerso)
                travailActuel = maxTravailPerso;
            else
                travailActuel += f;
            barreTravail.Valeur=travailActuel;
        }

        public void DiminuerEnergieActuelle(float f)
        {
            if (energieActuelle - f <= 0)
                GameOver();
            else
                energieActuelle -= f;
            barreEnergie.Valeur=energieActuelle;
        }

        public void DiminuerSocialActuel(float f)
        {
            if (socialActuel - f <= 0)
                GameOver();
            else
                socialActuel -= f;
            barresocial.Valeur=socialActuel;
        }

        public void DiminuerTravailActuel(float f)
        {
            if (travailActuel - f <= 0)
                GameOver();
            else
                travailActuel -= f;
            barreTravail.Valeur=travailActuel;
        }

        public void GameOver()
        {
            SceneManager.LoadSceneAsync((int) NumeroSceneEnum.GameOver, LoadSceneMode.Single);
        }

        public void SetNom(string nom)
        {
            this.nom = nom;
        }
    }
}