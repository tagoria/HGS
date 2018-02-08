using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Horloge : MonoBehaviour {
    private int creneauActuel;
    private Text texteHorloge;
    private Botin botin;
	// Use this for initialization
	void Start () {
        botin = FindObjectOfType<Botin>();
        texteHorloge = GetComponent<Text>();
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
    /**
     * fixe l'heure actuelle sans passer par avancerDunCreneau()
     * représente une période de temps pendant laquelle le joueur ne peut pas agir , n'a pas agi
     * et pendant laquelle aucun événement ne va se produire
     * en opposition a avancerDunCreneau()
     * */

    public void setCreneauActuel(int creneauActuel)
    {
        this.creneauActuel = creneauActuel;
        texteHorloge.text = creneauActuel * 2 + ":00";
    }
    /**
     * représente un déplacement dans le temps de 2 heures normal pendant lequel des événements peuvent se produire
     * en général la méthode est appellée après que le joueur a réalisé une action pour symboliser que 
     * les actions prennent du temps à être effectuées
     * */
    public void avancerDunCreneau()
    {
        botin.changerDeCreneau();
        creneauActuel++;
        creneauActuel = creneauActuel%12;
        texteHorloge.text = creneauActuel * 2 + ":00";
    }
}
