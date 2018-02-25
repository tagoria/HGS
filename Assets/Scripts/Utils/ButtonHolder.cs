using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHolder : MonoBehaviour {
    public GameObject button;
    private Vector2 depPosition;
    private List<Action> actionActuelles;
    public GameObject scrollbarAction;
    private Scrollbar scrollbar;
	// Use this for initialization
	void Awake () {
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
        foreach(Transform transfo in transform.GetComponentsInChildren<Transform>())
        {
            if (transfo != this.transform)
            {
                Destroy(transfo.gameObject);
            }

        }
        int hauteur = 0;
        foreach(Action action in list)
        {
            GameObject o = Instantiate(button,transform);
            o.transform.localPosition = new Vector2(0,hauteur);
            hauteur -= 300;
            Button b =o.GetComponent<Button>();
            b.onClick.AddListener(action.Act);
            b.GetComponentInChildren<Text>().text = action.GetNom();
        }
        scrollbar.size = 1-(actionActuelles.Count - 4 )* 0.1f;
    }
    private static List<Action> initActions;
    public float slider = 0;
    public void SliderValueChange(float value)
    {
        slider = value;
        float maxValue = (actionActuelles.Count - 3) * 60;
        transform.position = new Vector2(depPosition.x, depPosition.y + slider * maxValue);
    }
	void Update () {
        
	}
}
