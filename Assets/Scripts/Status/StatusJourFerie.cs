using Enums;
using Events;

namespace Status
{
    public class StatusJourFerie : StatusAbstract
    {
        public StatusJourFerie() : base(12 - Horloge.instance.getCreneauActuel(), "Jour férié",
            "Aujourd'hui c'est férié donc pas de cours", (int) StatusEnum.JourFerie)
        {
        }

        public override void onEnd()
        {
            Botin.instance.ferie = false;
            base.onEnd();
        }

        public override void onStart()
        {
            Botin.instance.ferie = true;
        }
    }
}