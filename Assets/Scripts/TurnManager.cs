using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public List<ICreature> actors;
    public int currentPlayerIndex = -1;

    void Start()
    {
			actors = new List<ICreature>(FindObjectsOfType<Mob>());
			actors.Add(FindObjectOfType<Player>());
			actors.Sort((a, b) => b.speedPool.CompareTo(a.speedPool));
			NextTurn();
    }

    public void NextTurn()
    {
        currentPlayerIndex = (currentPlayerIndex + 1) % actors.Count;
        actors[currentPlayerIndex].speedPool += 100;

        if (actors[currentPlayerIndex].speedPool >= 100)
        {
            actors[currentPlayerIndex].OnTurn();
        }
        else
        {
            NextTurn();
        }
    }
}
