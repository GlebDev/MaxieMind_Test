using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FallObject : MonoBehaviour
{
    const string PLAYER_STR = "Player";
    [SerializeField] private int ScoreImpact = 1;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.CompareTag(PLAYER_STR))
        {
            GameManager.Instane.Score += ScoreImpact;
        }
        SpawnManager.Instane.DespawnObject(this.gameObject);
    }
}
