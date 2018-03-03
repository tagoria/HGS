using Enums;
using Events.Conditions;

namespace Events
{
    public class EvenementCoursSoir : EvenementDeuxChoix
    {
        public static int COURS_ASSISTE = 0;
        public static int COURS_SECHE = 1;

        public EvenementCoursSoir() : base( Evenement.EvenementCoursSoir, 30,
            generateConditions(new HasStatusCondition(StatusEnum.JourFerie, false)), "oui", "non",
            "Cours de l'après-midi", "aller en cours?", generateCreneau(7), "Vous allez en cours",
            "Vous allez pas en cours")
        {
        }

        //l'evenement se produit sur les créneuax 4 et 5 uniquement si il ne s'est pas produit la veille
        public override void realiserChoix1()
        {
            Personnage.Player.instance.augmenterTravailActuel(20);
            Personnage.Player.instance.diminuerEnergieActuelle(10);
            Horloge.instance.setCreneauActuel(Horloge.instance.getCreneauActuel() + 2);
            Horloge.instance.addToHistorique(new EventResult(this, COURS_ASSISTE));
        }


        public override void realiserChoix2()
        {
            //rien
            Horloge.instance.addToHistorique(new EventResult(this, COURS_SECHE));
        }
    }
}