using Enums;
using Events.Conditions;
using Status;

namespace Events
{
    public class GrippeEvenement : EvenementDeuxChoix
    {
        public static int RDV_PRIS = 0;
        public static int PAS_DE_RDV = 1;

        public GrippeEvenement() : base( Evenement.GrippeEvenement, 10,
            generateConditions(new ConditionJoueurOccupe(false)), "Prendre un rdv chez le médecin", "Se rendormir",
            "La grippe", "Vous vous sentes fébrile", generateCreneau(4, 5, 6),
            "Vous prenez un rdv chez le médecin avant de sombrer", "Vous sombrez dans l'inconscience")
        {
        }

        public override double getProba()
        {
            var malade = Personnage.Player.instance.HasPerk(PerksEnum.Malade) ? 1 : 0;
            var grippe = Personnage.Player.instance.HasStatus(StatusEnum.Grippe) ? 1 : 0;
            return base.getProba() + 10 * malade + 15 * grippe;
        }

        public override void realiserChoix1()
        {
            Personnage.Player.instance.AjouterStatus(new RdvMedecinStatus(3));
            Personnage.Player.instance.AjouterStatus(new GrippeStatus());
            Horloge.instance.setCreneauActuel(Horloge.instance.getCreneauActuel() + 1);
            Horloge.instance.addToHistorique(new EventResult(this, RDV_PRIS));
        }

        public override void realiserChoix2()
        {
            Personnage.Player.instance.AjouterStatus(new GrippeStatus());
            Horloge.instance.setCreneauActuel(Horloge.instance.getCreneauActuel() + 1);
            Horloge.instance.addToHistorique(new EventResult(this, PAS_DE_RDV));
        }
    }
}