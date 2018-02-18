using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScaleCanvas : MonoBehaviour {

	public void Scale()
    {
        float scale = GetComponent<Slider>().value;
        GetComponentInParent<CanvasScaler>().matchWidthOrHeight = scale;
        GetComponentInChildren<Text>().text = scale.ToString();
    }
}
