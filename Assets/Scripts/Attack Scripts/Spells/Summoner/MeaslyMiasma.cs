using UnityEngine;

public class MeaslyMiasma : MonoBehaviour, Spells
{
		[SerializeField] public Sprite uiElement { get; set; }
    public string displayName { get; set; }
    public int cooldown { get; set; }
    public int levelRequirement { get; set; }
    public string descriptionLong { get; set; }
    public bool instantCast { get; set; }
    public float abilityPowerCost { get; set; }
    public bool isCastable { get; set; }
    public Creature targetedEnemy { get; set; }
    public float physDamageModifier { get; set; }
    public float magicDamageModifier { get; set; }
    public float DOT { get; set; }
    public int DOTTurns { get; set; }
    public int stunTurns { get; set; }
    public CalcCritAndDamage calcCritAndDamage { get; set; }

		private void Awake()
		{
    	displayName = "Measly Miasma";
    	levelRequirement = 2;
    	abilityPowerCost = 17;
    	magicDamageModifier = 1;
    	instantCast = true;
			descriptionLong = $"{displayName}\nCost - {abilityPowerCost} Stamina\nRequired Level - {levelRequirement}\nDescription - Deals {magicDamageModifier * 100} magic damage to all enemies";
		}
    public void MeaslyMiasmaScript(Creature castingCreature, PlayerEquipment playerEquipment)
    {
        castingCreature.currentAbilityPool -= abilityPowerCost;
        float damage;

        if (playerEquipment.equippedWeapon != null)
        {
            damage = playerEquipment.GetDamageValue() + playerEquipment.GetDamageValue() * magicDamageModifier;
            damage *= calcCritAndDamage.CalculateCritAndDamage(playerEquipment.equippedWeapon);
        }
        else
        {
            damage = castingCreature.GetDamageValue() + castingCreature.GetDamageValue() * magicDamageModifier;
            damage *= calcCritAndDamage.CalculateCritAndDamage(castingCreature);
        }

        Mob[] mobs = FindObjectsOfType<Mob>();

        foreach (Mob defender in mobs)
        {
            float finalDamage = damage - (damage * defender.magicDamageResist);
            defender.currentHealth -= finalDamage;
        }

        cooldown = 8;
    }
}
