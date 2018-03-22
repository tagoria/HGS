using System;
using Enums;

namespace Perks
{
    public class MaladePerk : Perk
    {
        public MaladePerk() : base((int) PerksEnum.MaladePerk, "Malade")
        {
        }

        public override void Appliquer()
        {

        }
    }
}