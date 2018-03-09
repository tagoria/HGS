using System;
using Enums;

namespace Perks
{
    public class DormeurPerk : Perk
    {
        public DormeurPerk() : base((int) PerksEnum.DormeurPerk, "Dormeur")
        {
        }

        public override void appliquer()
        {

        }
    }
}