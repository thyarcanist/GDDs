using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Human", menuName = "VoidOS/AI")]
public class Humanoid : ScriptableObject
{
    public string AIName;
    public string AIRefCode;
    Team currentTeam;

    public GameObject SetPlayerModel;
    private GameObject CurrentPlayerModel;

    public double Weight;
    public double Height;
    public double Wallet;
    public List<InventoryItem> Inventory;
    public string PatronSpirit;

    public int statDexterity;
    public int statStrength;
    public int statIntelligence;
    private float fearThreshold;

}
