using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Build;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Events.Evenements.Social
{
    public class SoireInteEvenement : EvenementDeuxChoix
    {
        public static readonly EventResult SoireeAssistee = new EventResult(EvenementsEnum.SoireeInte,0);
        public static readonly EventResult SoireeSkippee = new EventResult(EvenementsEnum.SoireeInte,1);
        public SoireInteEvenement() : base(id: (int)EvenementsEnum.SoireeInte, proba: 20, conditions: generateConditions(new ConditionJoueurOccupe(false),
                new ConditionEvenementProduit(SoireeAssistee,false,365*12)
                ,new ConditionEvenementProduit(SoireeSkippee,false,365*12)),
            choix1: "Y aller", choix2: "Ne pas y aller", titre: "Soiree inté",
            texte: "La soirée d'intégration commence et durera sans doute toute la nuit",
            creneaux: generateCreneau(10), texteSiChoix1: "Vous rentrez tôt de la soirée",
            texteSiChoix2: "Pas le temps")
        {
        }

        public override void realiserChoix1()
        {
            Horloge.instance.addToHistorique(SoireeAssistee);
            int duree = Random.Range(Personnage.instance.hasPerk(PerksEnum.Fetard) ? 4 : 2, 7);
            if (Personnage.instance.getEnergieActuelle() <= duree * 10)
            {
                this.texteSiChoix1 = "Vous vous réveillez à 12 sans aucun souvenir de la veille";
                Horloge.instance.setCreneauActuel(6);
                Personnage.instance.diminuerEnergieActuelle(Personnage.instance.getEnergieActuelle()-10);
                return;
            }
            switch (duree)
            {
                case 2:
                case 3:
                    
                    this.texteSiChoix1 = "Vous rentrez tôt";
                    break;
                case 4:
                    this.texteSiChoix1 = "Vous vous êtes bien intégré";
                    break;
                case 5:
                    this.texteSiChoix1 = "Vous dépassez un peu les limites du raisonnable";
                    break;
                case 6:
                    this.texteSiChoix2 = "Vous rentrez juste assez tôt pour les cours du matin";
                    break;
                default:
                    Debug.Log("Unexpected value");
                    break;
            }
            Horloge.instance.avancerDePlusierusCreneauxEnEtantOccupe(duree);
            Personnage.instance.augmentersocialActuelle((float) (Math.Pow(duree,1.5)*10));
            Personnage.instance.diminuerEnergieActuelle(duree*10);
            
            
        }

        public override void realiserChoix2()
        {
            Horloge.instance.addToHistorique(SoireeSkippee);
            Personnage.instance.diminuersocialActuelle(10);
        }
    }
}