

using Enums;
using Personnage;

namespace Events.Conditions
{
    public class HasPerkCondition : EvenementAbstract.Condition
    {
        private readonly PerksEnum _perksEnum;
        public HasPerkCondition(PerksEnum perksEnum)
        {
            _perksEnum=perksEnum;
        }
        public override bool verify()
        {
            return Player.instance.HasPerk(_perksEnum);
        }
    }
}