using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int _width;
    [SerializeField] private int _height;
    

    public static GameManager Instance;

    public GameState State;

    public static event Action <GameState> OnGameStateChanged;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UpdateGameState(GameState.GenerateGrid);
    }

    public void UpdateGameState(GameState newState)
    {
        State = newState;

        switch (State)
        {
            case GameState.GenerateGrid:
                GridManager.instance.Grid(_width,_height);
                break;
            case GameState.SpawnPhase:
                UnitManager.Instance.SpawnPlayer();
                UnitManager.Instance.SpawnEnemy();
                break;
            case GameState.PlanningPhase:
                break;
            case GameState.ResolvePhase:
                break;
            case GameState.RoundEnd:
                break;
            case GameState.Victory:
                break;
            case GameState.Defeat:
                break;
        }

        OnGameStateChanged?.Invoke(newState);
    }
}

public enum GameState
{
    GenerateGrid,
    SpawnPhase,
    PlanningPhase,
    ResolvePhase,
    RoundEnd,
    Victory,
    Defeat,


}
