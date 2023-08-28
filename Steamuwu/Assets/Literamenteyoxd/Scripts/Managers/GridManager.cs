using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GridManager:MonoBehaviour
{
    public static GridManager instance;
    private int _width;
    private int _height;
    private int[,] _gridArray;
    [SerializeField] private GameObject _tilePrefab;
    Tile _tile;
    [SerializeField] private float _cellSize;

    private Dictionary<Vector2, Tile> _tiles;

    private void Awake()
    {
        instance = this;
    }
    public void Grid(int width, int height)
    {
        this._width = width;
        this._height = height;
        _cellSize *= gameObject.transform.localScale.x;

        _gridArray = new int[width,height];
        _tiles = new Dictionary<Vector2, Tile>();
        for (int x = 0; x < _gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < _gridArray.GetLength(1); y++)
            {
                var spawnedTile = Instantiate(_tilePrefab, new Vector3(x -8 ,0,0) * _cellSize + 
                    new Vector3(0,y -4 ) *_cellSize *.85f + 
                    ((y%2 == 1) ? new Vector3(1,0,0) * _cellSize * .5f :Vector3.zero) , Quaternion.identity, gameObject.transform);
                spawnedTile.name = $" tile {x} {y}";
                
                _tile = spawnedTile.GetComponent<Tile>();
                _tile._tileName = spawnedTile.name;
                var isOffset = (x % 2 == 0 && y%2 !=0) || (x % 2 != 0 && y % 2 == 0);
                _tile.Init(isOffset);

                _tiles[new Vector2(x, y)] = _tile;
            }
        }
        GameManager.Instance.UpdateGameState(GameState.SpawnPhase);
    }

    public Tile GetPlayerSpawnTile()
    {
        return _tiles.Where(t=> t.Value._walkable).OrderBy(t => Random.value).First().Value;
    }

    public Tile GetEnemySpawnTile()
    {
        return _tiles.Where(t => t.Value._walkable).OrderBy(t => Random.value).First().Value;
    }

}

