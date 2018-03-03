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

        internal void setPerks(Dictionary<int, Perk> perks)
        {
            listePerk = perks;
            appliquerPerks();
        }

        public bool hasPerk(PerksEnum perk)
        {
            return listePerk.ContainsKey((int) perk);
        }

        public void recommencer()
        {
            energieActuelle = energieDep;
            socialActuel = socialDep;
            travailActuel = travailDep;
            remplirBarre();
        }

        internal bool hasStatus(StatusEnum status)
        {
            return listeStatus.ContainsKey((int) status);
        }

        public void ajouterStatus(StatusAbstract status)
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

        public void remplirBarre()
        {
            barreEnergie.valeurCap = maxEnergiePerso;
            barresocial.valeurCap = maxsocialPerso;
            barreTravail.valeurCap = maxTravailPerso;
            barreEnergie.Valeur=energieActuelle;
            barresocial.Valeur=socialActuel;
            barreTravail.Valeur=travailActuel;
        }

        private void appliquerPerks()
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
            remplirBarre();
        }

        internal void affecterStatus(int nbCréneaux)
        {
            if (listeStatus == null || listeStatus.Count == 0) return;
            for (var i = 0; i < nbCréneaux; i++)
            {
                var copie = listeStatus.Values;
                foreach (var status in listeStatus.Values.ToArray()) status.onTimePass();
            }

            StatusHolder.instance.afficherStatus(listeStatus);
        }

        public void removeStatus(int status)
        {
            listeStatus.Remove(status);
            StatusHolder.instance.afficherStatus(listeStatus);
        }


        public float getEnergieActuelle()
        {
            return energieActuelle;
        }

        public float getSocialActuel()
        {
            return socialActuel;
        }

        public float getTravailActuel()
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

        public void augmenterTravailActuel(float f)
        {
            if (travailActuel + f > maxTravailPerso)
                travailActuel = maxTravailPerso;
            else
                travailActuel += f;
            barreTravail.Valeur=travailActuel;
        }

        public void diminuerEnergieActuelle(float f)
        {
            if (energieActuelle - f <= 0)
                GameOver();
            else
                energieActuelle -= f;
            barreEnergie.Valeur=energieActuelle;
        }

        public void diminuerSocialActuel(float f)
        {
            if (socialActuel - f <= 0)
                GameOver();
            else
                socialActuel -= f;
            barresocial.Valeur=socialActuel;
        }

        public void diminuerTravailActuel(float f)
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