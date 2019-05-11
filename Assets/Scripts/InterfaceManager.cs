using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceManager : MonoBehaviour
{
    private static InterfaceManager instance;
    public static InterfaceManager Instane
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<InterfaceManager>();
            }
            return instance;
        }
    }

    [SerializeField] private ScorePanel scorePanel;
    [SerializeField] private Button reloadButton;
    public System.Action ReloadBttnCallback;

    public void SetScoreText(int score) {
        scorePanel.Score = score;
    }

    public void PressReloadBttn() {
        if (ReloadBttnCallback != null)
            ReloadBttnCallback();
    }
}
