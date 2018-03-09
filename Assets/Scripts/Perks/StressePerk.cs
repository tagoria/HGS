using System;
using Enums;

namespace Perks
{
    public class StressePerk : Perk
    {
        public StressePerk() : base((int) PerksEnum.StressePerk, "Stressé")
        {
        }

        public override void appliquer()
        {

        }
    }
}