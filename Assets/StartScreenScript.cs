using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement; // Needed to load scenes

public class StartScreenScript : MonoBehaviour
{
    // Method that gets called when the button is clicked
    public void StartScreen()
    {
    
        SceneManager.LoadScene("ApplePicker");  
    }
}