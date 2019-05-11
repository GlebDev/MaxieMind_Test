using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePanel : MonoBehaviour
{
    [SerializeField] private Text ScoreText;
    public int Score {
        set {
            ScoreText.text = $"score: {value}";
        }
    }
}
