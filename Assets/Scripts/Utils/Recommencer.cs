using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recommencer : MonoBehaviour {

    public void recommencer()
    {
        Personnage.instance.recommencer();
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync((int)NumeroSceneEnum.EcranPrincipal, UnityEngine.SceneManagement.LoadSceneMode.Single);
    }
}
