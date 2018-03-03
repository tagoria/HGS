using System;
using Enums;

namespace Perks
{
    public class MaladePerk : Perk
    {
        public MaladePerk() : base((int) PerksEnum.Malade, "Malade")
        {
        }

        public override void appliquer()
        {
            throw new NotImplementedException();
        }
    }
}