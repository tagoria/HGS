using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class Botin : MonoBehaviour
{
    private List<List<Evenement>> cases;
    private void Awake()
    {
        
    }
    private Horloge horloge;
    private GenerationEvenement generationEvenement;
    private void Start()
    {
        List<Evenement.Condition> condtions = new List<Evenement.Condition>();
        condtions.Add(new ConditionDerniereActionTravailler(FindObjectOfType<Action1>()));
        caseActuelle = 0;
        cases = new List<List<Evenement>>();
        for (int i = 0; i < 12; i++)
        {
            List<Evenement> liste = new List<Evenement>();
            if (i < 4)
            {
                liste.Add(new Evenement2(condtions));
            }
            else
            {
                liste.Add(new Evenement1(condtions));
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
        double sommeProba = 0;
        foreach (Evenement evenemnt in cases[caseActuelle])
        {
            if (evenemnt.isRealisable())
            {
                sommeProba += evenemnt.getProba();
            }
        }
        float rand = Random.Range(0,10);
        if (rand < sommeProba )
        {
            sommeProba=0;
            foreach (Evenement evenement in cases[caseActuelle])
            {
                if (evenement.isRealisable())
                {
                    sommeProba += evenement.getProba();
                    if (sommeProba > rand)
                    {
                        generationEvenement.afficher(evenement);
                        break;
                    }
                }
            }
        }
    }
}