using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
	public List<ICreature> actors;
	public int currentPlayerIndex = -1;

	void Awake()
	{
		StartCoroutine(InitializeActors());
	}

	IEnumerator InitializeActors()
	{
		yield return new WaitUntil(() => Mob.instanceCounter == FindObjectsOfType<Mob>().Length);

		actors = new List<ICreature>(FindObjectsOfType<Mob>());
		actors.Add(FindObjectOfType<Player>());
		NextTurn();
	}

	public void NextTurn()
	{
		currentPlayerIndex = (currentPlayerIndex + 1) % actors.Count;
		actors[currentPlayerIndex].speedPool += 100;

		if (actors[currentPlayerIndex].speedPool >= actors[currentPlayerIndex].actionSpeedCost)
		{
			actors[currentPlayerIndex].speedPool -= actors[currentPlayerIndex].actionSpeedCost;
			actors[currentPlayerIndex].OnTurn();

			if (actors[currentPlayerIndex] is Creature creature)
			{
				if (creature.movementDisabledTurns > 0 && creature.TryAttack(null))
				{
					// If the creature can attack but not move, handle it
					actors[currentPlayerIndex].speedPool -= actors[currentPlayerIndex].actionSpeedCost;
				}
				else if (creature.movementDisabledTurns > 0)
				{
					// Skip the turn if the creature cannot attack
					NextTurn();
				}
			}
		}
		else
		{
			NextTurn();
		}
	}

	public void RemoveActor(ICreature actor)
	{
		if (actors.Contains(actor))
		{
			actors.Remove(actor);
			if (actors.Count == 0)
			{
				StopAllCoroutines();
			}
			else
			{
				// Adjust currentPlayerIndex if necessary
				if (currentPlayerIndex >= actors.Count)
				{
					currentPlayerIndex = 0;
				}
			}
		}
	}

	public void AddActor(ICreature actor)
	{
		actors.Add(actor);
		actors.Sort((a, b) => b.speedPool.CompareTo(a.speedPool));
	}
}

