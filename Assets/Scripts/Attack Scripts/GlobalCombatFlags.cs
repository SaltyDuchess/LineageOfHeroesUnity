using UnityEngine;

namespace LineageOfHeroes.AttackScripts
{
	public class GlobalCombatFlags : MonoBehaviour
	{
		public static GlobalCombatFlags Instance { get; private set; }

		public bool playerCritQueued = false;

		public GlobalCombatFlags()
		{
			if (Instance == null)
			{
				Instance = this;
			}
		}
	}
}
