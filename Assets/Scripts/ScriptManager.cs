using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptManager : MonoBehaviour
{
    public ScriptManager instance { get; private set; }
    public UiManager uiManager;
    public PlayerMovement playerMovement;
    public AudioManager audioManager;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("Duplicate GameManager instance found, destroying this one.");
            Destroy(gameObject);
        }
    }
}
