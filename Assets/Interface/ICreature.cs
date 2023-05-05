public interface ICreature
{
	void OnTurn();
	float speedPool { get; set; }
	float healthPool { get; set; }
	float currentHealth { get; set; }
}
