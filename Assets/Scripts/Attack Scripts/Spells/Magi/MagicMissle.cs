using UnityEngine;

public class MagicMissile : MonoBehaviour, Spells
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
    	displayName = "Magic Missle";
    	levelRequirement = 2;
    	abilityPowerCost = 10;
    	magicDamageModifier = 2;
    	instantCast = true;
			descriptionLong = $"{displayName}\nCost - {abilityPowerCost} Stamina\nRequired Level - {levelRequirement}\nDescription - Deals {magicDamageModifier * 100} magic damage to the nearest enemy.";
		}

    public void MagicMissileScript(Creature castingCreature, Creature defender, bool isPlayerAttack)
    {
        if (defender != null)
        {
            castingCreature.currentAbilityPool -= abilityPowerCost;
            isPlayerAttack = castingCreature.CompareTag("Player");

            float damage = castingCreature.GetDamageValue() + castingCreature.GetDamageValue() * magicDamageModifier;
            damage *= calcCritAndDamage.CalculateCritAndDamage(castingCreature);

            if (isPlayerAttack)
            {
                // The logic for finding the nearest mob should be handled externally.
            }
            else
            {
                // This assumes the player is tagged "Player" in the game.
                defender = GameObject.FindGameObjectWithTag("Player").GetComponent<Creature>();
            }

            damage -= damage * defender.magicDamageResist;

            defender.currentHealth -= damage;

            cooldown = 3;
        }
    }
}
