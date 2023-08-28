using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public static UnitManager Instance;

    private List<ScriptableUnit> _Units;

    public Player _selectedPlayer;

    [SerializeField] private ScriptableUnit _player;

    private void Awake()
    {
        Instance = this;

        _Units = Resources.LoadAll<ScriptableUnit>("Units").ToList();
    }

    public void SpawnPlayer()
    {
        var Player = GetPlayer(_player);
        var SpawnedPlayer = Instantiate(Player);
        var randomSpawnTile = GridManager.instance.GetPlayerSpawnTile();

        randomSpawnTile.SetUnit(SpawnedPlayer);
    }

    public void SpawnEnemy()
    {
        var EnemyCount = 3;

        for (int i = 0; i < EnemyCount; i++)
        {
            var Enemy = GetRandomUnit<BaseEnemy>(Faction.Enemy);
            var SpawnedEnemy = Instantiate(Enemy);
            var randomSpawnTile = GridManager.instance.GetEnemySpawnTile();

            randomSpawnTile.SetUnit(SpawnedEnemy);
        }

        GameManager.Instance.UpdateGameState(GameState.PlanningPhase);
        
    }




    private T GetRandomUnit<T>(Faction faction) where T : BaseUnit
    {
        return (T)_Units.Where(u => u._Faction == faction).OrderBy(o => Random.value).First()._UnitPrefab;
    }

    private BaseUnit GetPlayer(ScriptableUnit Player) 
    {
        return Player._UnitPrefab;
    }

    public void SetSelectedPlayer(Player player)
    {
        _selectedPlayer = player;
        MenuManager.instance.ShowSelectedPlayer(player);
    }
}
