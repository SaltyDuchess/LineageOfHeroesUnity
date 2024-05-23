using LineageOfHeroes.Spells;
using UnityEngine;
using UnityEngine.UI;

public class CooldownController : MonoBehaviour
{
	public Sprite[] cooldownSprites;
	public SpellBase associatedSpell;
	private Image cooldownImageComponent;

	void Awake()
	{
		cooldownImageComponent = GetComponent<Image>();
	}

	void Update()
	{
		cooldownImageComponent.sprite = cooldownSprites[associatedSpell.currentCooldown - 1];
	}
}