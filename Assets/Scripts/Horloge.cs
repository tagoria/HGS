
using UnityEngine;
using UnityEngine.UI;
public class Horloge : MonoBehaviour {
    private int creneauActuel;
    private Text texteHorloge;
    private Botin botin;
    public static Horloge instance;
    // Use this for initialization
    private void Awake()
    {
        instance = this;
    }
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
     * et pendant laquelle certain événement vont se produire avec une résolution automatique
     * (exemple cours raté parce que on dort)
     * en opposition a avancerDunCreneau()
     * */

    public void setCreneauActuel(int creneauActuel)
    {
        Personnage.main.occuppe = true;
        int iterations = creneauActuel - this.creneauActuel;
        if (iterations < 0)
        {
            iterations += 12;
        }
        for (int i = 0; i < iterations; i++)
        {
            avancerDunCreneau();
        }
    }
    /**
     * représente un déplacement dans le temps de 2 heures normal pendant lequel des événements peuvent se produire
     * en général la méthode est appellée après que le joueur a réalisé une action pour symboliser que 
     * les actions prennent du temps à être effectuées
     * */
    public void avancerDunCreneau()
    {
        creneauActuel++;
        creneauActuel = creneauActuel%12;
        texteHorloge.text = creneauActuel * 2 + ":00";
        Personnage.main.affecterStatus(1);
        botin.changerDeCreneau();
    }
}
