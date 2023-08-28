using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Unit", menuName = "Scriptable Unit")]
public class ScriptableUnit : ScriptableObject
{
    public Faction _Faction;
    public BaseUnit _UnitPrefab;
}

public enum Faction
{
    Player = 1,
    Enemy = 2
}