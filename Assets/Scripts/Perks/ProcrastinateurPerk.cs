using System;
using Enums;

namespace Perks
{
    public class ProcrastinateurPerk : Perk
    {
        public ProcrastinateurPerk() : base((int) PerksEnum.Procrastinateur, "Procristanateur")
        {
        }

        public override void appliquer()
        {

        }
    }
}