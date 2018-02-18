using UnityEngine;
using System.Collections.Generic;

public class Botin : MonoBehaviour
{
    private List<List<Evenement>> cases;
    private void Awake()
    {
        instance= this;
    }
    private Horloge horloge;
    private GenerationEvenement generationEvenement;
    public static Botin instance;
    public bool ferie=false;
    private void Start()
    {
        caseActuelle = 0;
        cases = new List<List<Evenement>>();
        for (int i = 0; i < 12; i++)
        {
            List<Evenement> liste = new List<Evenement>();
            if (i == 5)
            {
                liste.Add(new EvenementJourFerie());
            }
            if (i < 4)
            {
                liste.Add(new EvenementEpuisement());
            }
            else
            {
                liste.Add(new EvenementCanette());
            }
            cases.Add(liste);
        }
        horloge =FindObjectOfType<Horloge>();
        generationEvenement = FindObjectOfType<GenerationEvenement>();
    }
    private int caseActuelle;
    /**
     * détermine si un évenement devrait se réaliser sur le prochaine créneau et le réalise si oui
     * */
    public void changerDeCreneau()
    {
        caseActuelle = horloge.getCreneauActuel();
        cases[caseActuelle].Sort();
        float rand = Random.Range(0,100);
            foreach (Evenement evenement in cases[caseActuelle])
            {
                if (evenement.isRealisable())
                {
                    if (evenement.getProba() >= rand)
                    {
                        generationEvenement.afficher(evenement);
                        break;
                    }
                }
            }
    }
}