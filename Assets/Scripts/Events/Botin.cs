using UnityEngine;
using System.Collections.Generic;
using System;

public class Botin : MonoBehaviour
{
    private List<List<EvenementAbstract>> cases;
    private Horloge horloge;
    private GenerationEvenement generationEvenement;
    public static Botin instance;
    public bool ferie = false;
    private int caseActuelle;
    private bool evenmentIsAboutToHappen;
    private void Awake()
    {
        instance = this;
    }
    public void ajouterUnEvenementSurToutSesCreneaux(EvenementAbstract evenement)
    {
        foreach (int creneau in evenement.getCreneaux())
        {
            ajouterEvenementSurUnCreneau(evenement, creneau);
        }
    }
    private void Start()
    {
        caseActuelle = 0;
        cases = new List<List<EvenementAbstract>>();
        for (int i = 0; i < 12; i++)
        {
            cases.Add(new List<EvenementAbstract>());
        }
        List<EvenementAbstract> evenements = new List<EvenementAbstract>();
        evenements.Add(new EvenementCanette());
        evenements.Add(new EvenementCoursMatin());
        evenements.Add(new EvenementEpuisement());
        evenements.Add(new EvenementJourFerie());
        evenements.Add(new GrippeEvenement());
        evenements.Add(new EvenementCoursSoir());
        evenements.Add(new OuvertureCulturelleEvenement());
        evenements.Add(new ConferenceHeiEvenement());
        evenements.Add(new ReunionDeProjetEvenement());
        evenements.Add(new TpNotesEvenement());
        evenements.Add(new CoursClarifeEvenement());
        foreach (EvenementAbstract evenement in evenements)
        {
            ajouterUnEvenementSurToutSesCreneaux(evenement);
        }
        horloge = FindObjectOfType<Horloge>();
        generationEvenement = FindObjectOfType<GenerationEvenement>();
    }
    public void supprimerEvenementSurToutLesCreneaux(EvenementAbstract evenementAbstract)
    {
        foreach (List<EvenementAbstract> liste in cases)
        {
            if (liste.Contains(evenementAbstract))
            {
                liste.Remove(evenementAbstract);
            }
        }
    }
    public void ajouterEvenementSurUnCreneau(EvenementAbstract evenementAbstract)
    {
        ajouterEvenementSurUnCreneau(evenementAbstract, evenementAbstract.getCreneaux()[0]);
    }
    public void ajouterEvenementSurUnCreneau(EvenementAbstract evenementAbstract, int creneau)
    {
        cases[creneau].Add(evenementAbstract);
    }
    /**
     * détermine si un évenement devrait se réaliser sur le prochaine créneau et le réalise si oui
     * */
    public void changerDeCreneau()
    {
        caseActuelle = horloge.getCreneauActuel();
        cases[caseActuelle].Sort();
        float rand = UnityEngine.Random.Range(0, 100);
        if (!evenmentIsAboutToHappen)
        {
            foreach (EvenementAbstract evenement in cases[caseActuelle])
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
        evenmentIsAboutToHappen = false;
    }
    public bool essayerForcerEvenement(EvenementAbstract evenementAbstract)
    {
        if (evenementAbstract.isRealisable() && !evenmentIsAboutToHappen)
        {
            evenmentIsAboutToHappen = true;
            generationEvenement.afficher(evenementAbstract);
            return true;
        }
        return false;
    }
}