using System;
using Enums;

namespace Perks
{
    public class StressePerk : Perk
    {
        public StressePerk() : base((int) PerksEnum.Stresse, "Stressé")
        {
        }

        public override void appliquer()
        {

        }
    }
}