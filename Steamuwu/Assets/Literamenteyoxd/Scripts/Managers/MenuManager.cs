using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;
    [SerializeField] private GameObject _selectedPlayerObject, _tileObject, _unitObject;

    private void Awake()
    {
        instance = this;
    }

    public void ShowTileInfo(Tile tile)
    {
        if (tile == null)
        {
            _tileObject.SetActive(false);
            _unitObject.SetActive(false);
            return;
        } 

        _tileObject.GetComponentInChildren<Text>().text = tile._tileName;
        _tileObject.SetActive(true);

        if (tile.OccupiedUnit)
        {
            _unitObject.GetComponentInChildren<Text>().text = tile.OccupiedUnit.UnitName;
            _unitObject.SetActive(true);
        }
    }
    public void ShowSelectedPlayer(Player player)
    {
        if (player == null)
        {
            _selectedPlayerObject.SetActive(false);
            return;
        }
        _selectedPlayerObject.GetComponentInChildren<Text>().text = player.UnitName;
        _selectedPlayerObject.SetActive(true);  
    }
}
