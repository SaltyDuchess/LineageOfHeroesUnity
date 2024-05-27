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
		if (associatedSpell.currentCooldown == 0)
		{
			Destroy(gameObject);
			return;
		}
		cooldownImageComponent.sprite = cooldownSprites[associatedSpell.currentCooldown - 1];
	}
}