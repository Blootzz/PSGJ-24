using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] [Tooltip("This Canvas will be set active upon closing settings menu")]
    GameObject returnMenu;

    // called by settings button
    public void _CloseSettings()
    {
        returnMenu.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
