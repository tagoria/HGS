using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHolder : MonoBehaviour {
    public GameObject button;
    private Vector2 depPosition;
    private List<Action> actionActuelles;
	// Use this for initialization
	void Start () {
        depPosition = transform.position;
        initActions = new List<Action>();
        initActions.Add(gameObject.AddComponent<Action1>());
        initActions.Add(gameObject.AddComponent<Action2>());
        initActions.Add(gameObject.AddComponent<Action1>());
        initActions.Add(gameObject.AddComponent<Action1>());
        initActions.Add(gameObject.AddComponent<Action2>());
        initActions.Add(gameObject.AddComponent<Action1>());
        initActions.Add(gameObject.AddComponent<Action1>());
        initActions.Add(gameObject.AddComponent<Action2>());
        initActions.Add(gameObject.AddComponent<Action1>());
        initActions.Add(gameObject.AddComponent<Action1>());
        initActions.Add(gameObject.AddComponent<Action2>());
        initActions.Add(gameObject.AddComponent<Action1>());
        UpdateActions(initActions);
    }
    private void UpdateActions(List<Action> list)
    {
        actionActuelles = list;
        foreach(Transform transform in transform.GetComponentsInChildren<Transform>())
        {
            if (transform != this.transform)
            {
                Destroy(transform.gameObject);
            }

        }
        int hauteur = 0;
        foreach(Action action in list)
        {
            GameObject o = Instantiate(button,transform);
            o.transform.localPosition = new Vector2(0,hauteur);
            hauteur -= 60;
            Button b =o.GetComponent<Button>();
            b.onClick.AddListener(action.Act);
            b.GetComponentInChildren<Text>().text = action.GetNom();
        }
    }
    private static List<Action> initActions;
    public float slider = 0;
    public void SliderValueChange(float value)
    {
        slider = value;
    }
	void Update () {
        float maxValue = (actionActuelles.Count-4)*60;
        transform.position = new Vector2(depPosition.x,depPosition.y+slider*maxValue);
	}
}
