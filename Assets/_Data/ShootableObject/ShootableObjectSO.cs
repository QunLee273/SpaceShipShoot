using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShootableObject", menuName = "ScriptableObjects/ShootableObject")]
public class ShootableObjectSO : ScriptableObject
{
    public string objName = "Shootable Object";
    public ObjectType objType;
    public int hpMax = 0;
    public List<ItemDropRate> dropList;
}
