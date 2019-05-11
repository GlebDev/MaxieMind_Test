using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instane {
        get {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<GameManager>();
            }
            return instance;
        } 
    }

    [SerializeField] private GameObject playerBall;
    [SerializeField] private PlatformController platform;

    private int score = 0;
    public int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
            InterfaceManager.Instane.SetScoreText(score);
        }
    }

    public Vector3 StartBallPosition;
    public float StartPlatformZRot;

    private void Start()
    {
        ReloadGame();
        InterfaceManager.Instane.ReloadBttnCallback += ReloadGame;
    }

    public void ReloadGame()
    {
        SpawnManager.Instane.StopSpawn();
        SpawnManager.Instane.DespawnAllObject();
        playerBall.transform.position = StartBallPosition;
        platform.Zrotate = StartPlatformZRot;
        Score = 0;
        SpawnManager.Instane.StartSpawn();
    }
}
