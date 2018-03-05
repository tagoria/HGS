using Enums;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Utils
{
    public class Recommencer : MonoBehaviour
    {
        public void recommencer()
        {
            Personnage.Player.instance.Recommencer();
            SceneManager.LoadSceneAsync((int) NumeroSceneEnum.EcranPrincipal, LoadSceneMode.Single);
        }
    }
}