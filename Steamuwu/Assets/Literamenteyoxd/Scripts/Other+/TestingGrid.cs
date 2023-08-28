using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingGrid : MonoBehaviour
{
    private void Start()
    {
        GridManager _grid;
        _grid = GetComponent<GridManager>();
        _grid.Grid(10, 10);
    }

}
