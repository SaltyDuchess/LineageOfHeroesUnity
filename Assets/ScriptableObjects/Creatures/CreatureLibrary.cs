using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CreatureLibrary", menuName = "CreatureLibrary", order = 1)]
public class CreatureLibrary : ScriptableObject
{
    public List<Mob> mobs;
}
