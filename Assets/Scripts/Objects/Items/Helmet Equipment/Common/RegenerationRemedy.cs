using LineageOfHeroes.Randomization;

namespace LineageOfHeroes.Items
{
	public class RegenerationRemedy : Helmet
	{
			new private void Awake()
			{
					base.Awake();

					bonusHpRegen = RandomGenerator.Range(.3f, 1.2f);

					descriptionLong = $"{displayName}\nType - {type}\nIncreases hp regen regen by {bonusHpRegen}";
			}
	}
}
