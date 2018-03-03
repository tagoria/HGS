using UnityEngine;

namespace Utils
{
    public class HideOnLoad : MonoBehaviour
    {
        public bool hide;

        // Use this for initialization
        private void Start()
        {
            if (hide) Destroy(gameObject);
        }

        // Update is called once per frame
        private void Update()
        {
        }
    }
}