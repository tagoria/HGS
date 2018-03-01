
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Horloge : MonoBehaviour {
    private static int creneauActuel;
    private Text texteHorloge;
    private Botin botin;
    public static Horloge instance;
    private List<EventResult> historique;
    private int crenauxEcoules;
    public Text Calendrier;
    private int nbJoursEcoules;
    // Use this for initialization
    private void Awake()
    {
        nbJoursEcoules = 0;
        crenauxEcoules = 0;
        instance = this;
        historique = new List<EventResult>();
    }

    internal bool LookForResult(EventResult eventResult, int nbCreneaux)
    {
        try
        {
            int lastHappened = historique.LastIndexOf(eventResult);
            if (lastHappened == -1)
            {
                return false;
            }
            return lastHappened - crenauxEcoules < nbCreneaux;
        }catch(Exception e)
        {
            return false;
        }

    }

    void Start () {
        botin = FindObjectOfType<Botin>();
        texteHorloge = GetComponent<Text>();
	}
    public void addToHistorique(EventResult eventResult)
    {
        historique.Add(eventResult);
    }
    private Action derniereActionRealisee;
    public Action getDerniereActionRealisee()
    {
        return derniereActionRealisee;
    }
    public void setDerniereActionRealisee(Action action)
    {
        derniereActionRealisee = action;
    }
	// Update is called once per frame
	void Update () {
		
	}
    public int getCreneauActuel()
    {
        return creneauActuel;
    }
    public void avancerDePlusierusCreneauxEnEtantOccupe(int creneaux)
    {
        this.setCreneauActuel((creneauActuel+creneaux)%12);
    }
    /**
     * fixe l'heure actuelle sans passer par avancerDunCreneau()
     * représente une période de temps pendant laquelle le joueur ne peut pas agir , n'a pas agi
     * et pendant laquelle certain événement vont se produire avec une résolution automatique
     * (exemple cours raté parce que on dort)
     * en opposition a avancerDunCreneau()
     * */

    public void setCreneauActuel(int nouveauCreneau)
    {
        Personnage.main.occuppe = true;
        int iterations = nouveauCreneau-creneauActuel;
        if (iterations < 0)
        {
            iterations += 12;
        }
        for (int i = 0; i < iterations; i++)
        {
            avancerDunCreneau();
        }
        Personnage.main.occuppe = false;
    }
    /**
     * représente un déplacement dans le temps de 2 heures normal pendant lequel des événements peuvent se produire
     * en général la méthode est appellée après que le joueur a réalisé une action pour symboliser que 
     * les actions prennent du temps à être effectuées
     * */
    public void avancerDunCreneau()
    {
        crenauxEcoules++;
        if (crenauxEcoules / 12 > nbJoursEcoules)
        {
            nbJoursEcoules++;
            Calendrier.text = nbJoursEcoules.ToString();
        }
        creneauActuel++;
        creneauActuel = creneauActuel%12;
        texteHorloge.text = creneauActuel * 2 + ":00";
        Personnage.main.affecterStatus(1);
        botin.changerDeCreneau();
    }
    public static int getCreneauxLeftTo(int daysToWait,int creneauWanted)
    {
        int creneauxLeft = daysToWait*12;
        creneauxLeft += -creneauActuel + creneauWanted;
        return creneauxLeft;
    }
}
