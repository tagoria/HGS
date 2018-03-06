using Enums;
using Events.Conditions;

// Condition sur la probabilité selon perk Glouton, non réalisée...

namespace Events
{
    public class FrigoVide : EvenementUnSeulChoix
    {
        public static readonly int FRIGO_REMPLI = 0;

        public FrigoVide() : base( Evenement.FrigoVide, (int) ProbaEnum.FrigoVide,
            generateConditions(new HasStatusCondition(StatusEnum.JourFerie, false)),
            "Ok",
            "Oups, le frigo est vide",
            "Il reste à peine un pot de sauce mi-entamé. Votre estomac commence à se plaindre, il est temps de faire les courses",
            generateCreneau(9))
        {
        }

        public override void realiserChoix1()
        {
            Personnage.Player.instance.DiminuerEnergieActuelle(25);
             addEventResultToHistorique();
            //Est -ce nécessaire d'enregistrer une telle action ? 
            Horloge.instance.avancerDePlusieursCreneauxEnEtantOccupe(1);
        }
    }
}