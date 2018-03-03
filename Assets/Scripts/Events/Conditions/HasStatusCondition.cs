using Enums;

namespace Events.Conditions
{
    public class HasStatusCondition : EvenementAbstract.Condition
    {
        private readonly bool shouldHave;
        private readonly StatusEnum status;

        public HasStatusCondition(StatusEnum status, bool shouldHave = true)
        {
            this.status = status;
            this.shouldHave = shouldHave;
        }

        public override bool verify()
        {
            return Personnage.Player.instance.hasStatus(status) && shouldHave ||
                   !Personnage.Player.instance.hasStatus(status) && !shouldHave;
        }
    }
}