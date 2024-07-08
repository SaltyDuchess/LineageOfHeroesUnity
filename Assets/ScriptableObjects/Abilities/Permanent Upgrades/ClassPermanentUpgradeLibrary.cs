using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ClassPermanentUpgradeLibrary", menuName = "ClassPermanentUpgradeLibrary", order = 1)]
public class ClassPermanentUpgradeLibrary : ScriptableObject
{
    public List<PermanentUpgradeData> classPermanentUpgrades;

		public ClassPermanentUpgradeLibrary(){}
}
