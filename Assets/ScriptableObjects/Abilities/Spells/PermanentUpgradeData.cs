using UnityEngine;

[CreateAssetMenu(fileName = "NewPermanentUpgrade", menuName = "Abilities/PermanentUpgrade")]
public class PermanentUpgradeData : SpellData
{
    public float healthIncreasePercentage;
		public float abilityPowerIncreasePercentage;
		public bool turnRecurring;
		public bool bleedsCanCrit;
		public float bleedCritChance;
		public float bleedCritModifier;
}
