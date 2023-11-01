using UnityEngine;

[CreateAssetMenu(fileName = "Ship", menuName = "ScriptableObjects/Ship")]
public class ShipSO : ScriptableObject
{
    public string shipName = "Ship";
    public int hpMax = 2;
}