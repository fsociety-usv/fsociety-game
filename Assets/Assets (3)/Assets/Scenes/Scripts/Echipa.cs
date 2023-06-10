using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class Echipa : MonoBehaviour
{
    public GameObject textPrefab; 
    public Transform parentTransform;  

    private string[] teamMembers = { "Albu Tudor", "Livadariu Dan Mihai", "Domnita Andrei Claudiu", "Lungu Sorin", "Filip Leonard" };

    private List<GameObject> memberTexts = new List<GameObject>(); 

    private void Start()
    {
        foreach (string member in teamMembers)
        {
            GameObject newText = Instantiate(textPrefab, parentTransform);
            newText.GetComponent<Text>().text = member;
            memberTexts.Add(newText);
        }
    }
}
