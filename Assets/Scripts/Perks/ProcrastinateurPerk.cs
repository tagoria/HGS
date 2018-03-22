using System;
using Enums;

namespace Perks
{
    public class ProcrastinateurPerk : Perk
    {
        public ProcrastinateurPerk() : base((int) PerksEnum.ProcrastinateurPerk, "Procristanateur")
        {
        }

        public override void Appliquer()
        {

        }
    }
}