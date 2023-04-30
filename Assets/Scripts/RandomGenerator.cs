namespace LineageOfHeroes.Randomization
{
	public static class RandomGenerator
	{
			private static System.Random _random = new System.Random();

			public static int Range(int minValue, int maxValue)
			{
					return _random.Next(minValue, maxValue);
			}

			public static float Range(float minValue, float maxValue)
			{
					return (float)(_random.NextDouble() * (maxValue - minValue) + minValue);
			}
	}
}
