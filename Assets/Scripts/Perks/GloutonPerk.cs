using System;
using Enums;

namespace Perks
{
    public class GloutonPerk : Perk
    {
        public GloutonPerk() : base((int) PerksEnum.Glouton, "Glouton")
        {
        }

        public override void appliquer()
        {
            throw new NotImplementedException();
        }
    }
}