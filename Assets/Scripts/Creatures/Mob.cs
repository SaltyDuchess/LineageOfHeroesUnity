using System.Collections.Generic;
using UnityEngine;

public class Mob : Creature
{
    public new List<float> damageRange = new List<float> { 6.5f, 13.2f };
    public int XPValue = 5;
    public string displayName = "A mob";
    public string mobDescription = "Ya forgot a mob description";

    // Start is called before the first frame update
    void Start()
    {
        // Initialize your variables here, if necessary
    }

    // Update is called once per frame
    void Update()
    {
        // Implement any necessary Mob logic here
    }
}
