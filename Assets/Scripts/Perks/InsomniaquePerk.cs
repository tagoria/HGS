using System;
using Enums;

namespace Perks
{
    public class InsomniaquePerk : Perk
    {
        public InsomniaquePerk() : base((int) PerksEnum.Insomniaque, "Insomniaque")
        {
        }

        public override void appliquer()
        {
            throw new NotImplementedException();
        }
    }
}