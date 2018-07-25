# Inventory

## Feature: ScriptableItem
Sets Win condition
Steps to configure:
1. Right click the project and create __ScriptableItem__
2. Tick __WinCondition__ if you want this item to be the winning item (IE has to be loaded into the __computer__)
3. Leave unticked if its one of the other items
4. Done


## Feature: Inventory
1. Attach __inventory__ Script to object
2. Set the size to __1__ and attach __ScriptableItem__ into the inspector
3. __IF__ you want to record the location of a item, Set __Activate Location__ to __true__ (Ie. a desk object that has a diary item inside), set the tag of the gameobject to __Item__
4. __IMPORTANT__ When you have a item in the scene (Ie. __Note__) you must make a canvas called the __Scriptable item__ name (IE. __Note__) and child a panel to it (That panel is the UI for your __ScriptableItem__)
5. Done

### For the Player
1. Attach __inventory__ Script to object
2. Create a __ScriptableItem__ called Empty
3. Set the size to __1__ and attach __Empty__ __ScriptableItem__ into the inspector
4. Create a canvas called Empty and child a panel to it, set no image to the panel
5. Done

### For the Computer
1. Attach __inventory__ Script to object
2. Set the size to __1__ 
3. Set the gameObject tag to __Computer__
4. Done


## Feature: Computer
1. Set the Upload Time
2. Child a cube to __Computer__, call the cube __LoadBar__ 
3. Done 

## Feature: InventoryOverSeer
For Checking if items are in position 
Steps to configure:
1. Attach __InventoryOverSeer__ to player
2. Set the size of __ItemLocations__ equal to the item locations in the scene (If you have 3 items in objects, Ie. Note, Diary, receipt, you would set this size to 3)
3. Set the size of __Items__ to the size as __ItemLocations__
5. Done

### Feature: OnExit
When the player walks onto Exit of your level, call the function IventoryOverSeer.__ItemCurrentLocations()__
