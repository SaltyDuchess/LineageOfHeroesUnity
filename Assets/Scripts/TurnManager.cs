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
				Debug.Log("All actors removed, stopping turn manager.");
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
