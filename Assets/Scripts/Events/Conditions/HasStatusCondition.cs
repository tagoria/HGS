
public class HasStatusCondition : EvenementAbstract.Condition
{
    private StatusEnum status;
    private bool shouldHave;
    public HasStatusCondition(StatusEnum status,bool shouldHave=true)
    {
        this.status = status;
        this.shouldHave = shouldHave;
    }

    public override bool verify()
    {
        return (Personnage.main.hasStatus(status)&&shouldHave)||(!Personnage.main.hasStatus(status)&&!shouldHave);
    }
}