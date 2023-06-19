using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class Echipa : MonoBehaviour
{
   
    public void OnStartButtonClicked()
    {
        SceneManager.LoadScene("Assets/Scenes/info"); //NumeScenaJoc
    }
}
