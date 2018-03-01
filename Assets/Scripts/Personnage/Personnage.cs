
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Personnage : MonoBehaviour {
    private void Awake()
    {
        listeStatus = new Dictionary<int, StatusAbstract>();
        instance = this;
    }
    // Use this for initialization
    void Start () {
        
    }
    internal void setPerks(Dictionary<int,Perk> perks)
    {
        listePerk = perks;
        appliquerPerks();
    }

    public bool hasPerk(PerksEnum perk)
    {
        return listePerk.ContainsKey((int)perk);
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
        return listeStatus.ContainsKey((int)status);
    }

    public void ajouterStatus(StatusAbstract status)
    {
        if (listeStatus.ContainsKey(status.id))
        {
            if (status.isAddable())
            {
                listeStatus[status.id].add(status);
            }
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
        barreEnergie.setValeur(energieActuelle);
        barresocial.setValeur(socialActuel);
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
        socialActuel = socialDep;
        travailActuel = travailDep;
        remplirBarre();
    }
    private Dictionary<int,StatusAbstract> listeStatus;
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
            Dictionary<int,StatusAbstract>.ValueCollection copie = listeStatus.Values;
            foreach (StatusAbstract status in listeStatus.Values.ToArray())
            {
                status.onTimePass();
            }
        }
        StatusHolder.instance.afficherStatus(listeStatus);
    }
    public void removeStatus(int status)
    {
        listeStatus.Remove(status);
        StatusHolder.instance.afficherStatus(listeStatus);
    }

    internal static Personnage instance;
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
    private float socialActuel;
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
    public float getSocialActuel()
    {
        return socialActuel;
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
    public void augmenterSocialActuel(float f)
    {
        if (socialActuel + f > maxsocialPerso)
        {
            socialActuel = maxsocialPerso;
        }
        else
        {
            socialActuel += f;
        }
        barresocial.setValeur(socialActuel);
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
    public void diminuerSocialActuel(float f)
    {
        if (socialActuel - f <=0)
        {
            GameOver();
        }
        else
        {
            socialActuel -= f;
        }
        barresocial.setValeur(socialActuel);
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
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync((int) NumeroSceneEnum.GameOver, UnityEngine.SceneManagement.LoadSceneMode.Single);
    }
    public void SetNom(string nom)
    {
        this.nom = nom;
    }
}

