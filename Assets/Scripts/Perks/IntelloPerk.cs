using System;
using Enums;

namespace Perks
{
    public class IntelloPerk : Perk
    {
        public IntelloPerk() : base((int) PerksEnum.IntelloPerk, "Intello")
        {
        }

        public override void appliquer()
        {

        }
    }
}