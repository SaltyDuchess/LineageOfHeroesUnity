using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour
{
	public Stats stats = new Stats();
	public virtual bool IsPlayer => false;
	public List<float> damageRange { get; set; } = new List<float> { 6.5f, 13.2f };
	public string displayName { get; set; } = "A mob";
	public string mobDescription { get; set; } = "Ya forgot a mob description";
	public int[] mobLevelArray { get; set; } = new int[0];
}
