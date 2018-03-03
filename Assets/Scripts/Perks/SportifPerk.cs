using System;
using Enums;

namespace Perks
{
    public class SportifPerk : Perk
    {
        public SportifPerk() : base((int) PerksEnum.Sportif, "Sportif")
        {
        }

        public override void appliquer()
        {
            throw new NotImplementedException();
        }
    }
}