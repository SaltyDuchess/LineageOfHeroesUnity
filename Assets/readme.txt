Steps to add a new equipment item to the game

Steps for a basic item that add purely stat bonuses without randomization or unique behaviours

1. Update the (item type here) enum to include your new weapon
2. Add a new scriptable object of the type of the item you are adding and set all of its properties (especially rarity)
3. Add a new prefab for the item and use the scriptable object from the previous step, as well as a tooltip trigger
4. Add this prefab to the appropriate loot table scriptable object
5. Update the appropriate item factory to include your new item