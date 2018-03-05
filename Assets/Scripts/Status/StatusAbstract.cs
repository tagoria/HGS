using UnityEngine;

namespace Status
{
    public abstract class StatusAbstract
    {
        public readonly string description;
        public readonly int id;
        public readonly string nom;
        private readonly bool addable;
        protected int duration;
        protected int timeLeft;

        public StatusAbstract(int duration, string nom, string description, int id, bool addable = true)
        {
            this.duration = duration;
            timeLeft = duration;
            this.nom = nom;
            this.description = description;
            this.id = id;
            this.addable = addable;
        }

        public abstract void onStart();

        public bool isAddable()
        {
            return addable;
        }

        public virtual void onEnd()
        {
            Personnage.Player.instance.RemoveStatus(id);
        }

        public virtual void onTimePass()
        {
            timeLeft--;
            if (timeLeft == 0) onEnd();
        }

        public override string ToString()
        {
            return nom + " : " + description + " temps restant : " + timeLeft * 2 + " heures";
        }

        public void add(StatusAbstract status)
        {
            if (status.addable)
                timeLeft += status.timeLeft;
            else
                Debug.Log("trying to add " + GetType() + " with " + status.GetType());
        }

        public int getTimeLeft()
        {
            return timeLeft;
        }

        public int getDuration()
        {
            return duration;
        }
    }
}