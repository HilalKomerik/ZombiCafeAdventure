using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance  { get; private set; }

    public enum GameState
    {
        menu,
        gameRunning,
        endGame,
        pause
    }

    public GameState gameState;

    private void Awake()
    {
        if (Instance == null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
}

