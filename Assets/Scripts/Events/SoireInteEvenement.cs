using System;
using Enums;
using Events.Conditions;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Events
{
    public class SoireInteEvenement : EvenementDeuxChoix
    {
        public static readonly EventResult SoireeAssistee = new EventResult(Evenement.SoireeInteEvenement, 0);
        public static readonly EventResult SoireeSkippee = new EventResult(Evenement.SoireeInteEvenement, 1);

        public SoireInteEvenement() : base(Evenement.SoireeInteEvenement, 20, generateConditions(
                new ConditionJoueurOccupe(false),
                new ConditionEvenementProduit(SoireeAssistee, false, 365 * 12)
                , new ConditionEvenementProduit(SoireeSkippee, false, 365 * 12)),
            "Y aller", "Ne pas y aller", "Soiree inté",
            "La soirée d'intégration commence et durera sans doute toute la nuit",
            generateCreneau(10), "Vous rentrez tôt de la soirée",
            "Pas le temps")
        {
        }

        public override void realiserChoix1()
        {
            Horloge.instance.addToHistorique(SoireeAssistee);
            var duree = Random.Range(Personnage.Player.instance.hasPerk(PerksEnum.Fetard) ? 4 : 2, 7);
            if (Personnage.Player.instance.getEnergieActuelle() <= duree * 10)
            {
                texteSiChoix1 = "Vous vous réveillez à 12 sans aucun souvenir de la veille";
                Horloge.instance.setCreneauActuel(6);
                Personnage.Player.instance.diminuerEnergieActuelle(
                    Personnage.Player.instance.getEnergieActuelle() - 10);
                return;
            }

            switch (duree)
            {
                case 2:
                case 3:

                    texteSiChoix1 = "Vous rentrez tôt";
                    break;
                case 4:
                    texteSiChoix1 = "Vous vous êtes bien intégré";
                    break;
                case 5:
                    texteSiChoix1 = "Vous dépassez un peu les limites du raisonnable";
                    break;
                case 6:
                    texteSiChoix2 = "Vous rentrez juste assez tôt pour les cours du matin";
                    break;
                default:
                    Debug.Log("Unexpected value");
                    break;
            }

            Horloge.instance.avancerDePlusierusCreneauxEnEtantOccupe(duree);
            Personnage.Player.instance.AugmenterSocialActuel((float) (Math.Pow(duree, 1.5) * 10));
            Personnage.Player.instance.diminuerEnergieActuelle(duree * 10);
        }

        public override void realiserChoix2()
        {
            Horloge.instance.addToHistorique(SoireeSkippee);
            Personnage.Player.instance.diminuerSocialActuel(10);
        }
    }
}