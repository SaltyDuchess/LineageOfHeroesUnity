using System.Collections.Generic;
using UnityEngine;

public class GameSystem : MonoBehaviour
{
    public List<Mob> mobsSortedByDistance;
    public int lastMobNumber;
    public int progressState;
		public TurnManager turnManager;
}