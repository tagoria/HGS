using System;
using Enums;

namespace Perks
{
    public class RedoublantPerk : Perk
    {
        public RedoublantPerk() : base((int) PerksEnum.Redoublant, "Redoublant")
        {
        }

        public override void appliquer()
        {
            throw new NotImplementedException();
        }
    }
}