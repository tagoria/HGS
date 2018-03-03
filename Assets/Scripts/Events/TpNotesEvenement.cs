using Events.Conditions;
using UnityEngine;

namespace Events
{
    public class Evenement8_TP : EvenementDeuxChoix
    {
        // id, proba, conditions, texteChoix1, texteChoix2, Description, DescriptionChoix1, Description Choix2

        public Evenement8_TP() : base(Enums.Evenement.TpNotesEvenement, 20, generateConditions(new ConditionJoueurOccupe(false),new HasStatusCondition(Enums.StatusEnum.JourFerie)), "Tout à fait",
            "Désolé, mais non", "TP",
            "Vous avez cours de Travaux pratiques, ce serait dommage de ne pas y aller, pas vrai ?",
            generateCreneau(7),
            "Le Tp d'aujourd'hui est Chimie, vous truquez vos volumes équivalents et demandez au professeur pourquoi la question 1, pourquoi la question 3... Cela vous prend 4h.",
            "Vous séchez les cours, votre cerveau perd un peu de muscle")
        {
        }


        public override void realiserChoix1()
        {
            Horloge.instance.setCreneauActuel(8);
            Personnage.Player.instance.diminuerEnergieActuelle(15);
            Personnage.Player.instance.augmenterTravailActuel(10);
        }

        public override void realiserChoix2()
        {
            Personnage.Player.instance.diminuerTravailActuel(5);
        }
    }
}