using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Personnage : MonoBehaviour {
    private void Awake()
    {
        main = this;
        afficheNom = GetComponentInChildren<Text>();
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
        socialActuel = socialDep;
        travailActuel = travailDep;
        remplirBarre();
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
    private Text afficheNom;
    public Barre barreEnergie;
    public Barre barreTravail;
    public Barre barresocial;
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
    private float socialActuel;
    private float travailActuel;
    private string nom;
    
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
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync((int) NumeroScene.GameOver, UnityEngine.SceneManagement.LoadSceneMode.Single);
    }
    public void SetNom(string nom)
    {
        this.nom = nom;
        afficheNom.text = "Bonjour "+nom;
    }
}

