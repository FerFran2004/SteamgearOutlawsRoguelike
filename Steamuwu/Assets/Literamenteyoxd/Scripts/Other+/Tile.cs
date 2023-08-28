using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public string _tileName;
    [SerializeField] private GameObject _highlight;
    [SerializeField] private Color _baseColor, _offsetColor ;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private bool _isWalkable;
    private bool _isWalking;

    public BaseUnit OccupiedUnit;
    public bool _walkable => _isWalkable && OccupiedUnit == null;
    public void Init(bool isOffset)
    {
        _spriteRenderer.color = isOffset ?  _offsetColor : _baseColor;

    }
    private void OnMouseEnter()
    {
        _highlight.SetActive(true);
        MenuManager.instance.ShowTileInfo(this);

    }

    private void OnMouseExit()
    {
        _highlight.SetActive(false);
        MenuManager.instance.ShowTileInfo(null);
    }

    private void OnMouseDown()
    {
        if (GameManager.Instance.State != GameState.PlanningPhase) return;

        Debug.Log(OccupiedUnit);
        if (OccupiedUnit != null)
        {
            if (OccupiedUnit.Faction == Faction.Player) UnitManager.Instance.SetSelectedPlayer((Player)OccupiedUnit);

            else if (UnitManager.Instance._selectedPlayer != null)
            {
                var Enemy = (BaseEnemy)OccupiedUnit;
                Destroy(Enemy.gameObject);
                UnitManager.Instance.SetSelectedPlayer(null);
            }
        }

        if (OccupiedUnit == null) 
            {
                if (UnitManager.Instance._selectedPlayer != null)
                {

                    SetUnit(UnitManager.Instance._selectedPlayer);
                    UnitManager.Instance.SetSelectedPlayer(null);

                } 
            }

    }

    public void SetUnit(BaseUnit unit)
    {
        Debug.Log("AAAA");
        if (unit.OccupiedTile != null) unit.OccupiedTile.OccupiedUnit = null;
        unit.transform.position = transform.position;
        OccupiedUnit = unit;
        unit.OccupiedTile = this;
    }


}
