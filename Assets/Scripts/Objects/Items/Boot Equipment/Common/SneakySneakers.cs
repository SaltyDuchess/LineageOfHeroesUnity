using LineageOfHeroes.Randomization;

namespace LineageOfHeroes.Items
{
	public class SneakySneakers : Boot
	{
		new private void Awake()
		{
			base.Awake();
			bonusDodgeChance = RandomGenerator.Range(2.5f, 5f);
		}
	}
}
