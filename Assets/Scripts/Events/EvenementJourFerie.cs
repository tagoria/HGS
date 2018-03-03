using System.Collections.Generic;
using Enums;
using Status;

namespace Events
{
    public class EvenementJourFerie : EvenementUnSeulChoix
    {
        private static readonly List<int> creneaux = new List<int>
        {
            0
        };

        public EvenementJourFerie() : base( Evenement.EvenementJourFerie, 30, null, "super", "Jour férié",
            "jour férié", creneaux)
        {
        }

        public override void realiserChoix1()
        {
            Personnage.Player.instance.ajouterStatus(new StatusJourFerie());
            addEventResultToHistorique();
        }
    }
}