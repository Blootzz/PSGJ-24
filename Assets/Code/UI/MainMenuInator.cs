using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuInator : MonoBehaviour
{
    // called by play button
    public void _PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void _OpenSettings()
    {
        
    }
}
