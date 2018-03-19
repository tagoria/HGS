using System.Collections.Generic;
using Actions;
using UnityEngine;
using UnityEngine.UI;

namespace Utils
{
    public class ButtonHolder : MonoBehaviour
    {
        private static List<Action> initActions;
        private List<Action> actionActuelles;
        public GameObject button;
        private Vector2 depPosition;
        private Scrollbar scrollbar;
        public GameObject scrollbarAction;

        public float slider;

        // Use this for initialization
        private void Awake()
        {
            scrollbar = scrollbarAction.GetComponent<Scrollbar>();
            depPosition = transform.position;
            initActions = new List<Action>();
            initActions.Add(gameObject.AddComponent<Travailler>());
            initActions.Add(gameObject.AddComponent<SeReposer>());
            UpdateActions(initActions);
        }

        private void UpdateActions(List<Action> list)
        {
            actionActuelles = list;
            foreach (var transfo in transform.GetComponentsInChildren<Transform>())
                if (transfo != transform)
                    Destroy(transfo.gameObject);
            var positionX = 0;
            var positionY = 0;
            foreach (var action in list)
            {
                var o = Instantiate(button, transform);
                o.transform.localPosition = new Vector2(positionX,positionY);
                positionX += 850;
               // positionY -= 25;
                var b = o.GetComponent<Button>();
                b.onClick.AddListener(action.Act);
                b.GetComponentInChildren<Text>().text = action.GetNom();
            }

            scrollbar.size = 1 - (actionActuelles.Count - 4) * 0.1f;
        }

        public void SliderValueChange(float value)
        {
            slider = value;
            float maxValue = (actionActuelles.Count - 3) * 60;
            transform.position = new Vector2(depPosition.x, depPosition.y + slider * maxValue);
        }

        private void Update()
        {
        }
    }
}