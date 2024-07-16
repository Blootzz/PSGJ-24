using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuInator : MonoBehaviour
{
    [SerializeField] GameObject optionsMenu;

    // called by play button
    public void _PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    // called by settings button
    public void _OpenSettings()
    {
        optionsMenu.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
