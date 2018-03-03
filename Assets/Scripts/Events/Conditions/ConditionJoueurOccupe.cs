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
    }
}