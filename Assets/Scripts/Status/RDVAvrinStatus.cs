using Enums;
using Events;

namespace Status
{
    public class RDVAvrinStatus : StatusAbstract
    {
        public RDVAvrinStatus() : base(Horloge.getCreneauxLeftTo(1, 9), "Rdv Avrin", "Vous avez rdv avec Avrin",
            (int) StatusEnum.RdvAvrin, false)
        {
        }

        public override string ToString()
        {
            return "Vous avez rdv avec Avrin dans " + timeLeft * 2 + " heures";
        }

        public override void onStart()
        {
            //rien
        }

        public override void onEnd()
        {
            Botin.instance.essayerForcerEvenement(new RdvAvrinEvenement());
            base.onEnd();
        }
    }
}