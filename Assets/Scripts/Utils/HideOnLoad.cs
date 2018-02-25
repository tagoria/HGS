
using UnityEngine;

public class HideOnLoad : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if (hide)
        {
            Destroy(this.gameObject);
        }
	}
    public bool hide;
	// Update is called once per frame
	void Update () {
		
	}
}
