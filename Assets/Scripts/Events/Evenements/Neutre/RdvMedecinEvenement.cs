using System.Collections.Generic;
using Enums;
using Events.Conditions;

namespace Events
{
    public class RdvMedecinEvenement : EvenementUnSeulChoix
    {
        private static readonly List<int> creneauInit = new List<int>
        {
            7
        };

        public RdvMedecinEvenement() : base( Evenement.RdvMedecinEvenementSUITE, 100,
            generateConditions(new ConditionJoueurOccupe(false)), "Ok", "Rdv Medecin", "Rdv Medecin", creneauInit)
        {
        }

        public override void realiserChoix1()
        {
            Botin.instance.supprimerEvenementSurToutLesCreneaux(this);
            Personnage.Player.instance.RemoveStatus((int) StatusEnum.Grippe);
            Horloge.instance.setCreneauActuel(Horloge.instance.getCreneauActuel() + 1);
            addEventResultToHistorique();
        }
    }
}