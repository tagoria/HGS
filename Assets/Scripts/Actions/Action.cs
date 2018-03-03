using UnityEngine;

namespace Actions
{
    public abstract class Action : MonoBehaviour
    {
        private Horloge horloge;
        protected string nom;

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
    }
}