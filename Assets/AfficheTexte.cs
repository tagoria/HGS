using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfficheTexte : MonoBehaviour {

	// Use this for initialization
	private void Start () {
		
	}
	
	// Update is called once per frame
	private void Update ()
	{
		if (Input.touchCount <= 0) return;
		Debug.Log(Input.touchCount);
		if (Vector2.Distance(Input.GetTouch(0).position,transform.position)<50)
		{
			Debug.Log("mouse in");
			Destroy(this.gameObject);
		}
	}

	
}
