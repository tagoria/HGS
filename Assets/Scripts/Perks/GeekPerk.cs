using System;
using Enums;

namespace Perks
{
    public class GeekPerk : Perk
    {
        public GeekPerk() : base((int) PerksEnum.GeekPerk, "Geek")
        {
        }

        public override void appliquer()
        {

        }
    }
}