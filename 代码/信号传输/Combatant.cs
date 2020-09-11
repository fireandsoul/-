using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 枚举区分出玩家和敌人
/// </summary>
public class Combatant : MonoBehaviour
{
    public Faction myselfFaction = Faction.Player;
    public Faction enemyFaction;
    public float health = 100f;   //敌人和玩家公用这个血量变量


}

public enum Faction
{
    Player,
    Enemy
};