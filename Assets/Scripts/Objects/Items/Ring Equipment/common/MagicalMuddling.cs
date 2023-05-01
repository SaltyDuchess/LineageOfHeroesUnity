using LineageOfHeroes.Randomization;
using UnityEngine;

namespace LineageOfHeroes.Items
{
	public class MagicalMuddling : Ring
	{
		new private void Awake()
		{
			base.Awake();

			magicDamageResist = RandomGenerator.Range(4f, 7f);

			descriptionLong = $"{displayName}\nType - {type}\nIncreases magical damage resistance by {magicDamageResist} %";
		}
	}
}
