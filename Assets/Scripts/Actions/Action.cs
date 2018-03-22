using UnityEngine;

namespace Actions
{
    public abstract class Action : MonoBehaviour
    {
        private Horloge horloge;
        protected string nom;
        protected Enums.Action id;
        private void Start()
        {
            horloge = FindObjectOfType<Horloge>();
        }

        public virtual void Act()
        {
            horloge.setDerniereActionRealisee(this);
            horloge.avancerDunCreneau();
        }

        public string GetNom()
        {
            return nom;
        }

        public Enums.Action GetId()
        {
            return id;
        }
    }
}