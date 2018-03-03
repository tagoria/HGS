using System.Collections.Generic;
using UnityEngine;

namespace Events
{
    public class Botin : MonoBehaviour
    {
        public static Botin instance;
        private int caseActuelle;
        private List<List<EvenementAbstract>> cases;
        private bool evenmentIsAboutToHappen;
        public bool ferie;
        private GenerationEvenement generationEvenement;
        private Horloge horloge;

        private void Awake()
        {
            instance = this;
        }

        public void ajouterUnEvenementSurToutSesCreneaux(EvenementAbstract evenement)
        {
            foreach (var creneau in evenement.getCreneaux()) ajouterEvenementSurUnCreneau(evenement, creneau);
        }

        private void Start()
        {
            caseActuelle = 0;
            cases = new List<List<EvenementAbstract>>();
            for (var i = 0; i < 12; i++) cases.Add(new List<EvenementAbstract>());
            var evenements = EvenementAbstract.loopThrough();
            foreach (var evenement in evenements) ajouterUnEvenementSurToutSesCreneaux(evenement);
            horloge = FindObjectOfType<Horloge>();
            generationEvenement = FindObjectOfType<GenerationEvenement>();
        }

        public void supprimerEvenementSurToutLesCreneaux(EvenementAbstract evenementAbstract)
        {
            foreach (var liste in cases)
                if (liste.Contains(evenementAbstract))
                    liste.Remove(evenementAbstract);
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
            float rand = Random.Range(0, 100);
            if (!evenmentIsAboutToHappen)
                foreach (var evenement in cases[caseActuelle])
                    if (evenement.isRealisable())
                        if (evenement.getProba() >= rand)
                        {
                            generationEvenement.afficher(evenement);
                            break;
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
}