namespace Events
{
    public abstract partial class EvenementAbstract
    {
        public abstract class Condition
        {
            public abstract bool verify(); //methode qui renvoie vraie ssi la condition est vérifiée
            
        }
        
    }
}