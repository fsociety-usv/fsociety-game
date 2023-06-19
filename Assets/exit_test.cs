using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exit_test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Exit!");
    }
}
