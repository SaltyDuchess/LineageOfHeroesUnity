using LineageOfHeroes.Spells;
using UnityEngine;
using UnityEngine.UI;

public class CooldownController : MonoBehaviour
{
	public Sprite[] cooldownSprites;
	public IAbility associatedAbility;
	private Image cooldownImageComponent;

	void Awake()
	{
		cooldownImageComponent = GetComponent<Image>();
	}

	void Update()
	{
		if (associatedAbility != null)
		{
			if (associatedAbility.currentCooldown == 0)
			{
				Destroy(gameObject);
				return;
			}
			cooldownImageComponent.sprite = cooldownSprites[associatedAbility.currentCooldown - 1];
		}
	}
}