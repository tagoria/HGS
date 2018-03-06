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
            return Personnage.Player.instance.HasStatus(status) == shouldHave;
        }
        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != typeof(HasStatusCondition))
            {
                return false;
            }
            HasStatusCondition condition = (HasStatusCondition) obj;
            return condition.shouldHave == shouldHave && status == condition.status;
        }

        public override int GetHashCode()
        {
            var hashCode = 135441907;
            hashCode = hashCode * -1521134295 + shouldHave.GetHashCode();
            hashCode = hashCode * -1521134295 + status.GetHashCode();
            return hashCode;
        }
        public override string ToString()
        {
            return "HasStatusCondition status : "+this.status;
        }
    }
}