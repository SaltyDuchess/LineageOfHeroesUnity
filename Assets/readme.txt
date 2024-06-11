Steps to add a new equipment item to the game (steps very similar for new consumable or new spell)

Steps for implementing a new item

1. Update the (item type here) enum to include your new weapon
2. Add a new scriptable object of the type of the item you are adding and set all of its properties (especially rarity)
2b. If adding a item with unique behaviours, a new script under object/items/equipment must be added
3. Add a new prefab for the item and use the scriptable object from the previous step, the item script if needed
as well as a tooltip trigger
4. Add this prefab to the appropriate scriptable object table (loot, class spell list, etc)
5. Update the appropriate item factory to include your new item

For consumables/spells

6. Update the consumable library or spell library on the ability manager under
prefabs -> abilities -> consumables/spells -> library

For consumables

7. Update the list on consumable manager


Steps to add a new mob to the game
1. Add an appropriate scriptable object to the creatures scriptable object folder
2. Create a custom script if the creature is going to have unique behaviours
3. Create a prefab with a tooltip trigger, mob script, mob behaviour script, health bar controller and script from step 2
if one was created
4. Add prefab to appropriate creature library, the master creature library at a minimum