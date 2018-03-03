using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

namespace Utils
{
    public class ScaleCanvas : MonoBehaviour
    {
        public void Scale()
        {
            var scale = GetComponent<Slider>().value;
            GetComponentInParent<CanvasScaler>().matchWidthOrHeight = scale;
            GetComponentInChildren<Text>().text = scale.ToString(CultureInfo.InvariantCulture);
        }
    }
}