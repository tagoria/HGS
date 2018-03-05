namespace Events.Conditions
{
    public class ConditionJoueurOccupe : EvenementAbstract.Condition
    {
        private readonly bool condition;

        public ConditionJoueurOccupe(bool occupe)
        {
            condition = occupe;
        }

        public override bool verify()
        {
            return condition && Personnage.Player.instance.occuppe ||
                   !condition && !Personnage.Player.instance.occuppe;
        }
        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != typeof(ConditionJoueurOccupe))
            {
                return false;
            }
            ConditionJoueurOccupe condition = (ConditionJoueurOccupe) obj;
            return this.condition == condition.condition;
        }

        public override int GetHashCode()
        {
            return -1453244818 + condition.GetHashCode();
        }
        public override string ToString()
        {
            return "Condition joueur occupe = " + condition;
        }
    }
}