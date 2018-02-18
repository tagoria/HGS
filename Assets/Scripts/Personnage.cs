using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Personnage : MonoBehaviour {
    private void Awake()
    {
        listeStatus = new List<StatusAbstract>();
        main = this;
    }
    // Use this for initialization
    void Start () {
        
    }
    internal void setPerks(Dictionary<int,Perk> perks)
    {
        listePerk = perks;
        appliquerPerks();
    }
    public void recommencer()
    {
        energieActuelle = energieDep;
        socialActuelle = socialDep;
        travailActuel = travailDep;
        remplirBarre();
    }
    public void ajouterStatus(StatusAbstract status)
    {
        status.onStart();
        listeStatus.Add(status);
        StatusHolder.instance.afficherStatus(listeStatus);

    }
    public void remplirBarre()
    {
        barreEnergie.valeurCap = maxEnergiePerso;
        barresocial.valeurCap = maxsocialPerso;
        barreTravail.valeurCap = maxTravailPerso;
        barreEnergie.setValeur(energieActuelle);
        barresocial.setValeur(socialActuelle);
        barreTravail.setValeur(travailActuel);
    }
    private void appliquerPerks()
    {
        maxEnergiePerso = maxEnergieBase;
        maxsocialPerso = maxsocialBase;
        maxTravailPerso = maxTravailBase;
        energieDep = energieDepBase;
        travailDep = travailDepBase;
        socialDep = socialDepBase;
        foreach (Perk perk in listePerk.Values)
        {
            print(perk.id);
            perk.appliquer();
        }
        energieActuelle = energieDep;
        socialActuelle = socialDep;
        travailActuel = travailDep;
        remplirBarre();
    }
    private List<StatusAbstract> listeStatus;
    public Barre barreEnergie;
    public Barre barreTravail;
    public Barre barresocial;

    internal void affecterStatus(int nbCréneaux)
    {
        if (listeStatus == null || listeStatus.Count == 0)
        {
            return;
        }
        for (int i = 0; i < nbCréneaux; i++)
        {
            foreach (StatusAbstract status in listeStatus.ToArray())
            {
                status.onTimePass();
            }
        }
        StatusHolder.instance.afficherStatus(listeStatus);
    }
    public void removeStatus(StatusAbstract status)
    {
        listeStatus.Remove(status);
        StatusHolder.instance.afficherStatus(listeStatus);
    }

    internal static Personnage main;
    public float maxEnergieBase;
    public float maxTravailBase;
    public float maxsocialBase;
    public float energieDepBase;
    public float travailDepBase;
    public float socialDepBase;
    internal float maxEnergiePerso;
    internal float maxTravailPerso;
    internal float maxsocialPerso;
    internal float energieDep;
    internal float travailDep;
    internal float socialDep;
    private float energieActuelle;
    private float socialActuelle;
    private float travailActuel;
    private string nom;
    //Représente le fait que le personnage est occupé où non ,influe sur les évènements en faisant raté des RDV par exemple
    public bool occuppe = false;
    
    internal  Dictionary<int,Perk> listePerk;
	// Update is called once per frame
	void Update () {
		
	}
    public float getEnergieActuelle()
    {
        return energieActuelle;
    }
    public float getsocialActuelle()
    {
        return socialActuelle;
    }
    public float getTravailActuel()
    {
        return travailActuel;
    }
    public void augmenterEnergieActuelle(float f)
    {
        if (energieActuelle + f > maxEnergiePerso)
        {
            energieActuelle = maxEnergiePerso;
        }
        else
        {
            energieActuelle += f;
        }
        barreEnergie.setValeur(energieActuelle);
    }
    public void augmentersocialActuelle(float f)
    {
        if (socialActuelle + f > maxsocialPerso)
        {
            socialActuelle = maxsocialPerso;
        }
        else
        {
            socialActuelle += f;
        }
        barresocial.setValeur(socialActuelle);
    }
    public void augmenterTravailActuel(float f)
    {
        if (travailActuel + f > maxTravailPerso)
        {
            travailActuel = maxTravailPerso;
        }
        else
        {
            travailActuel += f;
        }
        barreTravail.setValeur(travailActuel);
    }
    public void diminuerEnergieActuelle(float f)
    {
        if (energieActuelle - f <=0)
        {
            GameOver();
        }
        else
        {
            energieActuelle -= f;
        }
        barreEnergie.setValeur(energieActuelle);
    }
    public void diminuersocialActuelle(float f)
    {
        if (socialActuelle - f <=0)
        {
            GameOver();
        }
        else
        {
            socialActuelle -= f;
        }
        barresocial.setValeur(socialActuelle);
    }
    public void diminuerTravailActuel(float f)
    {
        if (travailActuel - f <=0)
        {
            GameOver ();
        }
        else
        {
            travailActuel -= f;
        }
        barreTravail.setValeur(travailActuel);
    }
    public void GameOver()
    {
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync((int) NumeroScene.GameOver, UnityEngine.SceneManagement.LoadSceneMode.Single);
    }
    public void SetNom(string nom)
    {
        this.nom = nom;
    }
}

