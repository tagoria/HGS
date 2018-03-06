using System.Collections.Generic;
using Enums;

namespace Events
{
    public class EventResult : EqualityComparer<EventResult>
    {
        private readonly int _creneauDebut;
        private readonly Evenement _enumEvenement;
        private readonly int result;

        public int CreneauDebut
        {
            get
            {
                return _creneauDebut;
            }
        }

        public EventResult(Evenement enumEvenement, int result = 0)
        {
            _creneauDebut = Horloge.instance.getCreneauActuel();
            _enumEvenement = enumEvenement;
            this.result = result;
        }

        public EventResult(EvenementAbstract evenementAbstract, int result = 0) : this(
            (Evenement) evenementAbstract.getId(), result)
        {
        }

        public Evenement EnumEvenement
        {
            get { return _enumEvenement; }
        }

        public int Result
        {
            get { return result; }
        }

        

        public override int GetHashCode(EventResult obj)
        {
            return Result * 100000 + (int) EnumEvenement;
        }
        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != typeof(EventResult))
            {
                return false;
            }
            EventResult eventResult = (EventResult)obj;
            return Equals(eventResult, this);
        }

        public override bool Equals(EventResult x, EventResult y)
        {
            return x.EnumEvenement==y.EnumEvenement && x.Result == y.Result;
        }

        public override int GetHashCode()
        {
            var hashCode = -527389474;
            hashCode = hashCode * -1521134295 + _enumEvenement.GetHashCode();
            hashCode = hashCode * -1521134295 + result.GetHashCode();
            return hashCode;
        }
    }
}