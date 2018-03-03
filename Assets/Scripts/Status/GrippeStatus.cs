using Enums;

namespace Status
{
    public class GrippeStatus : StatusAbstract
    {
        public GrippeStatus() : base(36, "Grippé",
            "Votre grippe non soignée peut vous faire perdre connaissance à tout moment", (int) StatusEnum.Grippe)
        {
        }

        public override void onStart()
        {
            //rien
        }
    }
}