using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Difficulty : MonoBehaviour
{

    [SerializeField] private GameManager gameManager;
    [SerializeField] private Button button;

    public float difficulty = 1;
    void Start()
    {
        button.onClick.AddListener(SetDifficulty);
    }
   private void SetDifficulty()
    {
        gameManager.StartGame(difficulty);
    }
}
