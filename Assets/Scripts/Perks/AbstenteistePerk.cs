using System;
using Enums;

namespace Perks
{
    public class AbstenteistePerk : Perk
    {
        public AbstenteistePerk() : base((int) PerksEnum.Abstenteiste, "Abstenteiste")
        {
        }

        public override void appliquer()
        {

        }
    }
}