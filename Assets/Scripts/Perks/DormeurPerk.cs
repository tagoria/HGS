using System;
using Enums;

namespace Perks
{
    public class DormeurPerk : Perk
    {
        public DormeurPerk() : base((int) PerksEnum.Dormeur, "Dormeur")
        {
        }

        public override void appliquer()
        {

        }
    }
}