using UnityEngine;

public class PiedPiper : MonoBehaviour, Spells
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
			displayName = "Pied Piper";
    	levelRequirement = 2;
    	abilityPowerCost = 25;
    	instantCast = true;
			descriptionLong = $"{displayName}\nCost - {abilityPowerCost} Stamina\nRequired Level - {levelRequirement}\nDescription - Summons a rat familiar";
		}

    public void PiedPiperScript(Creature castingCreature)
    {
        castingCreature.currentAbilityPool -= abilityPowerCost;

        Vector2[] offsets = new Vector2[]
        {
            new Vector2(32, 0),
            new Vector2(0, -32),
            new Vector2(0, 32),
            new Vector2(-32, 0),
            new Vector2(-32, -32),
            new Vector2(32, -32),
            new Vector2(32, 32),
            new Vector2(-32, 32)
        };

        foreach (Vector2 offset in offsets)
        {
            Vector3 newPosition = castingCreature.transform.position + (Vector3)offset;
            if (!Physics2D.OverlapCircle(newPosition, 0.1f))
            {
                Instantiate(Resources.Load("Familiar"), newPosition, Quaternion.identity);
                break;
            }
        }

        cooldown = 12;
    }
}
