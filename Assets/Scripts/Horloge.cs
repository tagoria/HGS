using System;
using System.Collections.Generic;
using Events;
using UnityEngine;
using UnityEngine.UI;
using Action = Actions.Action;

public class Horloge : MonoBehaviour ,ISauvegardable
{
    private static int creneauActuel;
    private static int creneauPrecedent;
    public static Horloge instance;
    private Botin botin;
    public Text Calendrier;
    private int crenauxEcoules;
    private Enums.Action derniereActionRealisee;
    private List<EventResult> historique;
    private int nbJoursEcoules;

    public Text TexteHorloge;

    public const string keyCreneauActuel = "creneauAct";

    public const string keyCreneauxEcoules = "creneauxEcoules";

    public const string keyNbJoursEcoules = "joursEcoules";

    public const string keyHistorique = "historique";

    public const string keyDerniereActionRealisee = "derniereAction";
    // Use this for initialization
    private void Awake()
    {
        instance = this;
        LoadState();
    }

    internal bool LookForResult(EventResult eventResult, int nbCreneaux)
    {
        try
        {
            var lastHappened = historique.LastIndexOf(eventResult);
            if (lastHappened == -1) return false;
            return historique[lastHappened].CreneauDebut - crenauxEcoules < nbCreneaux;
        }
        catch (Exception e)
        {
            Debug.LogException(e);
            return false;
        }
    }

    private void Start()
    {
        botin = FindObjectOfType<Botin>();
    }

    public void addToHistorique(EventResult eventResult)
    {
        historique.Add(eventResult);
    }

    public Enums.Action getDerniereActionRealisee()
    {
        return derniereActionRealisee;
    }

    public void setDerniereActionRealisee(Action action)
    {
        derniereActionRealisee = action.GetId();
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public int getCreneauActuel()
    {
        return creneauActuel;
    }

    public void avancerDePlusieursCreneauxEnEtantOccupe(int creneaux)
    {
        setCreneauActuel((creneauActuel + creneaux) % 12);
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
        Personnage.Player.instance.occuppe = true;
        var iterations = nouveauCreneau - creneauActuel;
        if (iterations < 0) iterations += 12;
        for (var i = 0; i < iterations; i++) avancerDunCreneau();
        Personnage.Player.instance.occuppe = false;
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
        creneauActuel = creneauActuel % 12;
        AnimationHorloge();
        //TexteHorloge.text = creneauActuel * 2 + ":00";
        Personnage.Player.instance.AffecterStatus(1);
        botin.ChangerDeCreneau();
    }

    public static int getCreneauxLeftTo(int daysToWait, int creneauWanted)
    {
        var creneauxLeft = daysToWait * 12;
        creneauxLeft += -creneauActuel + creneauWanted;
        return creneauxLeft;
    }

    public void SaveState()
    {
        PlayerPrefs.SetInt(keyCreneauActuel,creneauActuel);
        PlayerPrefs.SetInt(keyDerniereActionRealisee,(int) derniereActionRealisee);
        PlayerPrefs.SetInt(keyNbJoursEcoules,nbJoursEcoules);
        PlayerPrefs.SetInt(keyCreneauxEcoules,crenauxEcoules);
        string histString = JsonUtility.ToJson(historique);
        PlayerPrefs.SetString(keyHistorique,histString);
    }

    public void LoadState()
    {
        if (PlayerPrefs.HasKey(keyCreneauxEcoules))
        {
            historique = new List<EventResult>();
            historique.Add(new EventResult(Enums.Evenement.EvenementCanette,0));
            historique.Add(new EventResult(Enums.Evenement.EvenementCanette,0));
            creneauActuel = PlayerPrefs.GetInt(keyCreneauActuel);
            derniereActionRealisee = (Enums.Action) PlayerPrefs.GetInt(keyDerniereActionRealisee);
            nbJoursEcoules = PlayerPrefs.GetInt(keyNbJoursEcoules);
            crenauxEcoules = PlayerPrefs.GetInt(keyCreneauxEcoules);
            TexteHorloge.text = creneauActuel * 2 + ":00";
            Calendrier.text = nbJoursEcoules.ToString();
        }
        else
        {
            nbJoursEcoules = 0;
            crenauxEcoules = 0;
            creneauActuel = 0;
            historique = new List<EventResult>();
            historique.Add(new EventResult(Enums.Evenement.EvenementCanette,0));

    }
    
    
}

    public void AnimationHorloge()
    {
        for(int i=0; i<59;++i)
        {
            TexteHorloge.text = creneauActuel * 2 + ":"+i;
        }
    }

    private void OnApplicationQuit()
    {
        SaveState();
    }
}