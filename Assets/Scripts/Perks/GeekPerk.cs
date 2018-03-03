using System;
using Enums;

namespace Perks
{
    public class GeekPerk : Perk
    {
        public GeekPerk() : base((int) PerksEnum.Geek, "Geek")
        {
        }

        public override void appliquer()
        {
            throw new NotImplementedException();
        }
    }
}