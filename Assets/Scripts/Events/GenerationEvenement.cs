using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

// Bonjour, ce script va générer un événement
// Ce n'est pas lui qui décide quel événement aura été choisi

namespace Events
{
    public class GenerationEvenement : MonoBehaviour
    {
        public static GenerationEvenement instance;

        private Button[] buttons;
        private Text corpsTexte;
        private EvenementAbstract evenement;
        private GameObject fenetre;
        public GameObject fenetreTemplate;
        private Text titre;
        private bool evenementEstAffiche;
        public List<EvenementAbstract> evenementsEnAttente;
        public bool EvenementEstAffiche
        {
            get
            {
                return evenementEstAffiche;
            }
        }

        private void Awake()
        {
            evenementsEnAttente = new List<EvenementAbstract>();
            instance = this;
        }

        public void afficher(EvenementAbstract evenement)
        {
            if (evenementEstAffiche)
            {
                evenementsEnAttente.Add(evenement);
                return;
            }
            this.evenement = evenement;
            evenementEstAffiche = true;
            fenetre = Instantiate(fenetreTemplate, transform.parent);
            var textes = fenetre.GetComponentsInChildren<Text>();
            foreach (var text in textes)
                if (text.text.Equals("CorpsTexte"))
                    corpsTexte = text;
                else if (text.text.Equals("Titre")) titre = text;
            if (evenement.GetType().GetInterface("EvenementEffetSiOccuppe") != null &&
                Personnage.Player.instance.occuppe)
            {
                var evnmt = (IEvenementEffetSiOccuppe) evenement;
                evnmt.onOccuppe();
                corpsTexte.text = "Vous ratez l'événement " + evenement.getTitre() + " car vous êtes occuppé";
                titre.text = evenement.getTitre() + " raté";
                buttons = fenetre.GetComponentsInChildren<Button>();
                buttons[0].onClick.AddListener(supprimerEvenement);
                buttons[0].GetComponentInChildren<Text>().text = "Ok";
                Destroy(buttons[1].gameObject);
                return;
            }

            buttons = fenetre.GetComponentsInChildren<Button>();
            buttons[0].onClick.AddListener(realiserChoix1);
            buttons[0].GetComponentInChildren<Text>().text = evenement.getChoix1();
            if (evenement.isEvenmentDeuxChoix())
            {
                var evnmt = (EvenementDeuxChoix) evenement;
                buttons[1].onClick.AddListener(realiserChoix2);
                buttons[1].GetComponentInChildren<Text>().text = evnmt.getChoix2();
            }
            else
            {
                Destroy(buttons[1].gameObject);
            }

            corpsTexte.text = evenement.getTexte();
            titre.text = evenement.getTitre();
        }

        private void supprimerEvenement()
        {
            Destroy(fenetre);
            evenementEstAffiche = false;
            switch (evenementsEnAttente.Count)
            {
                case 1:
                    evenementsEnAttente.RemoveAt(0);
                    break;
                case 0:
                    break;
                default:
                    evenementsEnAttente.RemoveAt(0);
                    afficher(evenementsEnAttente[0]);
                    break;
            }

        }

        private void afficherResultat(string resultat)
        {
            corpsTexte.text = resultat;
            for (var i = 0; i < buttons.Length; i++)
                if (i == 0)
                {
                    buttons[i].GetComponentInChildren<Text>().text = "Ok";
                    buttons[i].onClick.RemoveAllListeners();
                    buttons[i].onClick.AddListener(supprimerEvenement);
                }
                else
                {
                    Destroy(buttons[i].gameObject);
                }
        }

        public void realiserChoix1()
        {
            evenement.realiserChoix1();
            if (evenement.isEvenmentDeuxChoix())
            {
                var evnmt = (EvenementDeuxChoix) evenement;
                afficherResultat(evnmt.getTexteSiChoix1());
            }
            else
            {
                supprimerEvenement();
            }
        }

        public void realiserChoix2()
        {
            if (evenement.isEvenmentDeuxChoix())
            {
                var evnmt = (EvenementDeuxChoix) evenement;
                evnmt.realiserChoix2();
                afficherResultat(evnmt.getTexteSiCHoix2());
            }
        }
    }
}