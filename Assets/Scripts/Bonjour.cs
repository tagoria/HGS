using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonjour : MonoBehaviour{

    public void Update()
    {
        Renderer sprite = GetComponent<Renderer>();
        float red = 0;
        Mathf.PingPong(red, 1);
        sprite.material.color = new Color(1,1,1);
        transform.Translate(new Vector2(1/60f,0));
    }

}
