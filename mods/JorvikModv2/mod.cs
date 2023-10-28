/**
* <author>Christophe Roblin</author>
* <url>lifxmod.com</url>
* <credits>Odin one Eye of Jorvik</credits>
* <description>LiFx compatible v2.1.0 of Jorvik Mod</description>
* <license>GNU GENERAL PUBLIC LICENSE Version 3, 29 June 2007</license>
*/

// Register your mod as an object in the game engine, important for loading and unloading a package (mod)
if (!isObject(JorvikMod2))
{
    new ScriptObject(JorvikMod2)
    {
    };
}


// LiFx expect each mod to be it's own unique package
package JorvikMod2
{
  // Returns a string as a version, LiFx will look for this specific function to output version to new connecting players
  // Takes no parameters, is a reserved function for LiFx compatability.
  function JorvikMod2::version() {
    return "v2.1.0";
  }

  // The setup method is required, and will be looked for by the framework, if it doesn't have it your mod will not execute
  // This is where you tell the framework, which hooks you use and what object types you have added, so that the framework can call your code at the appropiate time
  function JorvikMod2::setup() {
    JorvikMod2.modRoot = getSubStr($Con::File,0,strrchrpos($Con::File,"/") + 1);
    // Register callback hooks, do not run any form of code that does anything here, just register the hook
	/**
	* LiFx::registerCallback is a global framework function, it takes 3 parameters
    * Parameter 1: The hook to register your function on
    * Parameter 2: Non scoped name of function in your package
    * Parameter 3: The package name to scope your function appropiately.
	*/
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, objectsConversions, JorvikMod2);
    LiFx::registerCallback($LiFx::hooks::preServerCreatedCallbacks, loadDatablocks, JorvikMod2);
	/**
	* LiFx::registerObjectsTypes is a global framework function, it takes 2 parameters
	* It is used to write to the dump.sql on start, prior to the server reading it, and is necessary as bitbox wipes the objectstypes table on each start up.
    * Parameter 1: The function including scope to your objectstypes definition
    * Parameter 2: The package name of your mod
	*/

    // Buildings
    LiFx::registerObjectsTypes(JorvikMod2::ObjectsTypesSmallWoodenShed(), JorvikMod2); // same ID as V1
    LiFx::registerObjectsTypes(JorvikMod2::ObjectsTypesFlagPvP(), JorvikMod2);
    LiFx::registerObjectsTypes(JorvikMod2::ObjectsTypesFlagPvE(), JorvikMod2);
    LiFx::registerObjectsTypes(JorvikMod2::ObjectsTypesLonghouse(), JorvikMod2);
    LiFx::registerObjectsTypes(JorvikMod2::ObjectsTypesStoneGate(), JorvikMod2);
    LiFx::registerObjectsTypes(JorvikMod2::ObjectsTypesSmallWoodenBridge(), JorvikMod2);
    LiFx::registerObjectsTypes(JorvikMod2::ObjectsTypesSmallStoneBridge(), JorvikMod2);
    LiFx::registerObjectsTypes(JorvikMod2::ObjectsTypesLargeWoodenBridge(), JorvikMod2);
    LiFx::registerObjectsTypes(JorvikMod2::ObjectsTypesLargeStoneBridge(), JorvikMod2);
    LiFx::registerObjectsTypes(JorvikMod2::ObjectsTypesLargeStoneBridgeEnd(), JorvikMod2);
    LiFx::registerObjectsTypes(JorvikMod2::ObjectsTypesSmallStoneBridgeEnd(), JorvikMod2);
    LiFx::registerObjectsTypes(JorvikMod2::ObjectsTypesModularConstructions(), JorvikMod2);
    LiFx::registerObjectsTypes(JorvikMod2::ObjectsTypesSmallLogWall(), JorvikMod2);
    LiFx::registerObjectsTypes(JorvikMod2::ObjectsTypesSmallWoodenPillar(), JorvikMod2);
    LiFx::registerObjectsTypes(JorvikMod2::ObjectsTypesSmallLogCornerWall(), JorvikMod2);
    LiFx::registerObjectsTypes(JorvikMod2::ObjectsTypesSmallLogWallWithWindow(), JorvikMod2);
    LiFx::registerObjectsTypes(JorvikMod2::ObjectsTypesSmallLogWallWithShutters(), JorvikMod2);
    LiFx::registerObjectsTypes(JorvikMod2::ObjectsTypesSmallLogWallWithEntrance(), JorvikMod2);
    LiFx::registerObjectsTypes(JorvikMod2::ObjectsTypesSmallLogWallWithDoor(), JorvikMod2);
    LiFx::registerObjectsTypes(JorvikMod2::ObjectsTypesSmallWoodenFloorEntrance(), JorvikMod2);
    LiFx::registerObjectsTypes(JorvikMod2::ObjectsTypesSmallWoodenFloor(), JorvikMod2);
    LiFx::registerObjectsTypes(JorvikMod2::ObjectsTypesSmallLogWallSlopeRight(), JorvikMod2);
    LiFx::registerObjectsTypes(JorvikMod2::ObjectsTypesSmallLogWallSlopeLeft(), JorvikMod2);
    LiFx::registerObjectsTypes(JorvikMod2::ObjectsTypesSmallThatchRoof(), JorvikMod2);
    LiFx::registerObjectsTypes(JorvikMod2::ObjectsTypesSmallThatchRoofRightEnd(), JorvikMod2);
    LiFx::registerObjectsTypes(JorvikMod2::ObjectsTypesSmallThatchRoofLeftEnd(), JorvikMod2);
    LiFx::registerObjectsTypes(JorvikMod2::ObjectsTypesSmallThatchRoofOuterCorner(), JorvikMod2);
    LiFx::registerObjectsTypes(JorvikMod2::ObjectsTypesModularConstructionslvl1(), JorvikMod2);
    LiFx::registerObjectsTypes(JorvikMod2::ObjectsTypesSmallLogWalllvl1(), JorvikMod2);
    LiFx::registerObjectsTypes(JorvikMod2::ObjectsTypesSmallWoodenPillarlvl1(), JorvikMod2);
    LiFx::registerObjectsTypes(JorvikMod2::ObjectsTypesSmallLogCornerWalllvl1(), JorvikMod2);
    LiFx::registerObjectsTypes(JorvikMod2::ObjectsTypesSmallLogWallWithWindowlvl1(), JorvikMod2);
    LiFx::registerObjectsTypes(JorvikMod2::ObjectsTypesSmallLogWallWithShutterslvl1(), JorvikMod2);
    LiFx::registerObjectsTypes(JorvikMod2::ObjectsTypesSmallLogWallWithEntrancelvl1(), JorvikMod2);
    LiFx::registerObjectsTypes(JorvikMod2::ObjectsTypesSmallLogWallWithDoorlvl1(), JorvikMod2);
    LiFx::registerObjectsTypes(JorvikMod2::ObjectsTypesSmallWoodenFloorEntrancelvl1(), JorvikMod2);
    LiFx::registerObjectsTypes(JorvikMod2::ObjectsTypesSmallWoodenFloorlvl1(), JorvikMod2);
    LiFx::registerObjectsTypes(JorvikMod2::ObjectsTypesSmallWoodenStairs(), JorvikMod2);
    LiFx::registerObjectsTypes(JorvikMod2::ObjectsTypesSmallThatchRoofTop(), JorvikMod2);
    LiFx::registerObjectsTypes(JorvikMod2::ObjectsTypesSmallThatchRoofOuterCornerTop(), JorvikMod2);
    LiFx::registerObjectsTypes(JorvikMod2::ObjectsTypesSmallThatchRoofTopLeftEnd(), JorvikMod2);
    LiFx::registerObjectsTypes(JorvikMod2::ObjectsTypesSmallThatchRoofTopRightEnd(), JorvikMod2);
    LiFx::registerObjectsTypes(JorvikMod2::ObjectsTypesSmallThatchRooflvl1(), JorvikMod2);
    LiFx::registerObjectsTypes(JorvikMod2::ObjectsTypesSmallThatchRoofOuterCornerlvl1(), JorvikMod2);
    LiFx::registerObjectsTypes(JorvikMod2::ObjectsTypesSmallWoodenRailing(), JorvikMod2);
    LiFx::registerObjectsTypes(JorvikMod2::ObjectsTypesSmallWoodenRailinglvl1(), JorvikMod2);
    LiFx::registerObjectsTypes(JorvikMod2::ObjectsTypesSmallThatchRoofOuterCornerToplvl1(), JorvikMod2);
    LiFx::registerObjectsTypes(JorvikMod2::ObjectsTypesWallTorch(), JorvikMod2);
    LiFx::registerObjectsTypes(JorvikMod2::ObjectsTypesWallTorchMovable(), JorvikMod2);
    LiFx::registerObjectsTypes(JorvikMod2::ObjectsTypesSmallCandle(), JorvikMod2);
    LiFx::registerObjectsTypes(JorvikMod2::ObjectsTypesSmallCandleMovable(), JorvikMod2);
    LiFx::registerObjectsTypes(JorvikMod2::ObjectsTypesAurochsCowstand(), JorvikMod2);
    LiFx::registerObjectsTypes(JorvikMod2::ObjectsTypesAurochsCoweat(), JorvikMod2);
    LiFx::registerObjectsTypes(JorvikMod2::ObjectsTypesAurochsCowsleep(), JorvikMod2);
    LiFx::registerObjectsTypes(JorvikMod2::ObjectsTypesSowstand(), JorvikMod2);
    LiFx::registerObjectsTypes(JorvikMod2::ObjectsTypesSoweat(), JorvikMod2);
    LiFx::registerObjectsTypes(JorvikMod2::ObjectsTypesSowsleep(), JorvikMod2);
    LiFx::registerObjectsTypes(JorvikMod2::ObjectsTypesHorsestand(), JorvikMod2);
    LiFx::registerObjectsTypes(JorvikMod2::ObjectsTypesHorseeat(), JorvikMod2);
    LiFx::registerObjectsTypes(JorvikMod2::ObjectsTypesHorsesleep(), JorvikMod2);
    LiFx::registerObjectsTypes(JorvikMod2::ObjectsTypesSlaveworking(), JorvikMod2);
    LiFx::registerObjectsTypes(JorvikMod2::ObjectsTypesWranentheHunterstand(), JorvikMod2);
    LiFx::registerObjectsTypes(JorvikMod2::ObjectsTypesBookPaper(), JorvikMod2);
    LiFx::registerObjectsTypes(JorvikMod2::ObjectsTypesHealthBook(), JorvikMod2);
    LiFx::registerObjectsTypes(JorvikMod2::ObjectsTypesSmallThatchRoofInnerCorner(), JorvikMod2);
    LiFx::registerObjectsTypes(JorvikMod2::ObjectsTypesWoodCart(), JorvikMod2);
    LiFx::registerObjectsTypes(JorvikMod2::ObjectsTypesSiegeTower(), JorvikMod2);
    LiFx::registerObjectsTypes(JorvikMod2::ObjectsTypesAurochsBullstand(), JorvikMod2);
    LiFx::registerObjectsTypes(JorvikMod2::ObjectsTypesAurochsBulleat(), JorvikMod2);
    LiFx::registerObjectsTypes(JorvikMod2::ObjectsTypesAurochsBullsleep(), JorvikMod2);
    LiFx::registerObjectsTypes(JorvikMod2::ObjectsTypesSmallWoodenPier(), JorvikMod2);
    LiFx::registerObjectsTypes(JorvikMod2::ObjectsTypesSmallWoodenPierT(), JorvikMod2);
    LiFx::registerObjectsTypes(JorvikMod2::ObjectsTypesSmallWoodenPierL(), JorvikMod2);
    LiFx::registerObjectsTypes(JorvikMod2::ObjectsTypesWattleWicket(), JorvikMod2);
    LiFx::registerObjectsTypes(JorvikMod2::ObjectsTypesIdolCross(), JorvikMod2);
    LiFx::registerObjectsTypes(JorvikMod2::ObjectsTypesWoodenChurch(), JorvikMod2);
    LiFx::registerObjectsTypes(JorvikMod2::ObjectsTypesSanctumoftheSleeper(), JorvikMod2);
    LiFx::registerObjectsTypes(JorvikMod2::ObjectsTypesNoviceDecoratorKit(), JorvikMod2);
    LiFx::registerObjectsTypes(JorvikMod2::ObjectsTypesApprenticeDecoratorKit(), JorvikMod2);
    LiFx::registerObjectsTypes(JorvikMod2::ObjectsTypesMasterDecoratorKit(), JorvikMod2);
    LiFx::registerObjectsTypes(JorvikMod2::ObjectsTypesWolfstand(), JorvikMod2);
    LiFx::registerObjectsTypes(JorvikMod2::ObjectsTypesGoldSheet(), JorvikMod2);
    LiFx::registerObjectsTypes(JorvikMod2::ObjectsTypesMetalScissors(), JorvikMod2);
    LiFx::registerObjectsTypes(JorvikMod2::ObjectsTypesMetalStamp(), JorvikMod2);
    LiFx::registerObjectsTypes(JorvikMod2::ObjectsTypesGoldBlanks(), JorvikMod2);
    LiFx::registerObjectsTypes(JorvikMod2::ObjectsTypesSilverSheet(), JorvikMod2);
    LiFx::registerObjectsTypes(JorvikMod2::ObjectsTypesCopperSheet(), JorvikMod2);
    LiFx::registerObjectsTypes(JorvikMod2::ObjectsTypesSilverBlanks(), JorvikMod2);
    LiFx::registerObjectsTypes(JorvikMod2::ObjectsTypesCopperBlanks(), JorvikMod2);  
    LiFx::registerObjectsTypes(JorvikMod2::ObjectsTypesWoodCartHarnessed(), JorvikMod2);
    //Register Callbacks
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, SmallWoodenShed, JorvikMod2);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, FlagPvP, JorvikMod2);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, FlagPvE, JorvikMod2);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, Longhouse, JorvikMod2);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, StoneGate, JorvikMod2);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, SmallWoodenBridge, JorvikMod2);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, SmallStoneBridge, JorvikMod2);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, LargeWoodenBridge, JorvikMod2);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, LargeStoneBridge, JorvikMod2);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, LargeStoneBridgeEnd, JorvikMod2);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, SmallStoneBridgeEnd, JorvikMod2);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, ModularConstructions, JorvikMod2);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, SmallLogWall, JorvikMod2);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, SmallWoodenPillar, JorvikMod2);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, SmallLogCornerWall, JorvikMod2);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, SmallLogWallWithWindow, JorvikMod2);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, SmallLogWallWithShutters, JorvikMod2);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, SmallLogWallWithEntrance, JorvikMod2);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, SmallLogWallWithDoor, JorvikMod2);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, SmallWoodenFloorEntrance, JorvikMod2);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, SmallWoodenFloor, JorvikMod2);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, SmallLogWallSlopeRight, JorvikMod2);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, SmallLogWallSlopeLeft, JorvikMod2);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, SmallThatchRoof, JorvikMod2);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, SmallThatchRoofRightEnd, JorvikMod2);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, SmallThatchRoofLeftEnd, JorvikMod2);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, SmallThatchRoofOuterCorner, JorvikMod2);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, SmallLogWalllvl1, JorvikMod2);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, SmallWoodenPillarlvl1, JorvikMod2);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, SmallLogCornerWalllvl1, JorvikMod2);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, SmallLogWallWithWindowlvl1, JorvikMod2);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, SmallLogWallWithShutterslvl1, JorvikMod2);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, SmallLogWallWithEntrancelvl1, JorvikMod2);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, SmallLogWallWithDoorlvl1, JorvikMod2);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, SmallWoodenFloorEntrancelvl1, JorvikMod2);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, SmallWoodenFloorlvl1, JorvikMod2);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, SmallWoodenStairs, JorvikMod2);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, SmallThatchRoofTop, JorvikMod2);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, SmallThatchRoofOuterCornerTop, JorvikMod2);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, SmallThatchRoofTopLeftEnd, JorvikMod2);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, SmallThatchRoofTopRightEnd, JorvikMod2);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, SmallThatchRooflvl1, JorvikMod2);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, SmallThatchRoofOuterCornerlvl1, JorvikMod2);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, SmallWoodenRailing, JorvikMod2);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, SmallWoodenRailinglvl1, JorvikMod2);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, SmallThatchRoofOuterCornerToplvl1, JorvikMod2);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, WallTorch, JorvikMod2);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, SmallCandle, JorvikMod2);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, AurochsCowstand, JorvikMod2);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, AurochsCoweat, JorvikMod2);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, AurochsCowsleep, JorvikMod2);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, Sowstand, JorvikMod2);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, Soweat, JorvikMod2);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, Sowsleep, JorvikMod2);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, Horsestand, JorvikMod2);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, Horseeat, JorvikMod2);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, Horsesleep, JorvikMod2);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, Slaveworking, JorvikMod2);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, WranentheHunterstand, JorvikMod2);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, BookPaper, JorvikMod2);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, HealthBook, JorvikMod2);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, SmallThatchRoofInnerCorner, JorvikMod2);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, WoodCart, JorvikMod2);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, SiegeTower, JorvikMod2);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, AurochsBullstand, JorvikMod2);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, AurochsBulleat, JorvikMod2);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, AurochsBullsleep, JorvikMod2);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, SmallWoodenPier, JorvikMod2);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, SmallWoodenPierT, JorvikMod2);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, SmallWoodenPierL, JorvikMod2);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, WattleWicket, JorvikMod2);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, IdolCross, JorvikMod2);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, WoodenChurch, JorvikMod2);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, SanctumoftheSleeper, JorvikMod2);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, NoviceDecoratorKit, JorvikMod2);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, ApprenticeDecoratorKit, JorvikMod2);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, MasterDecoratorKit, JorvikMod2);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, Wolfstand, JorvikMod2);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, GoldSheet, JorvikMod2);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, MetalScissors, JorvikMod2);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, MetalStamp, JorvikMod2);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, GoldBlanks, JorvikMod2);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, SilverSheet, JorvikMod2);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, CopperSheet, JorvikMod2);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, SilverBlanks, JorvikMod2);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, CopperBlanks, JorvikMod2);

  }

  function JorvikMod2::objectsConversions(%this, %client) {
      dbi.Update("INSERT IGNORE `objects_conversions` VALUES (NULL, 2549, 2507)");
      dbi.Update("INSERT IGNORE `objects_conversions` VALUES (NULL, 2500, 2501)");
      dbi.Update("INSERT IGNORE `objects_conversions` VALUES (NULL, 2502, 2503)");
  }
  function JorvikMod2::loadDatablocks() {
  //  loadRecursivelyInFolder("yolauncher/modpack/mods/Jorvik2/art/datablocks", "audioProfiles.cs");
      loadRecursivelyInFolder("yolauncher/modpack/mods/Jorvik2/art/datablocks", "Transport.cs");
  }
  function JorvikMod2::ObjectsTypesSmallWoodenShed() {
    return new ScriptObject(ObjectsTypesSmallWoodenShed : ObjectsTypes)
    {
      id = 2403; // *UNIQUE INT* Has to be a unique id - grab id from here: https://lifxmod.com/Docs/objects-types-id-list.html
      ObjectName = "Small Wooden Shed"; // *STRING* Name of your object
      ParentID = 69; // *INT* ParentID decides what type of object you have, think of it as class inheritance
      IsContainer = 1; // *BOOL* 1 (true) or 0 (false) - If your object is supposed to have a container referenced
      IsMovableObject = 1; // *BOOL* 1 (true) or 0 (false) - If your object is supposed to be movable
      IsUnmovableobject = 0; // *BOOL* 1 (true) or 0 (false) - If your object is supposed to be unmovable
      IsTool = 0; // *BOOL* 1 (true) or 0 (false) - If your object is supposed to be a tool to cut down trees or build buildings
      IsDevice = 0; // *BOOL* 1 (true) or 0 (false) - If your object is a device used in crafting or other interactions
      IsDoor = 0; // *BOOL* 1 (true) or 0 (false) - If your object has a door
      IsPremium = 0; // *BOOL* 1 (true) or 0 (false) - Premium defintion currently is not in use for Your Own.
      MaxContSize = 5000000; // *INT* The Max size of the container, if IsContainer is true
      Length = 8;  // *INT* Length of your object, used to decide if your object fits in a particular container
      MaxStackSize = 0; // *INT* Max number of items in a stack of your item in the inventory
      UnitWeight = 10000; // *INT* The weight of your object, used in calculation of encumbarance
      BackgrndImage = "art/images/warehouse"; // *STRING* Image reference to your inventory background, must be set if your object has a container
      WorkAreaTop = 0;
      WorkAreaLeft = 0;
      WorkAreaWidth = 0;
      WorkAreaHeight = 0;
      BtnCloseTop = 0;
      BtnCloseLeft = 0;
      FaceImage = "yolauncher/modpack/mods/Jorvik2/art/2D/objects/small_wooden_shed.png"; // *STRING* Reference to png that will be displayed in crafting menu
      Description = "Object from Jorvik MOD"; // *STRING* Used in crafting and skill to describe your object
      BasePrice = 0; // *INT* Used as price for sacrificing to monuments, high value gives more maintenance points
      OwnerTimeout = 0; // *INT* Used to set a timer on the object when made or dropped.
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
    };
  }
  function JorvikMod2::SmallWoodenShed() {
                                   //dbi.update("INSERT IGNORE INTO `recipe` VALUES (NULL,      Name,                 Description,      StartingToolsID,   SkillTypeID, SkillLvl, ResultObjectTypeID, SkillDepends,       Quantity, Autorepeat, isBluePrint, ImagePath)
    dbi.Select(JorvikMod2, "SmallWoodenShedRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Wooden Shed', 'Object from Jorvik MOD',        32,               18,          60,        2403,               25,           1,        0,          0,           'yolauncher/modpack/mods/Jorvik2/art/2D/Recipes/small_wooden_shed.png') RETURNING ID");
  }
  function JorvikMod2::SmallWoodenShedRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
    //dbi.update("INSERT IGNORE INTO `recipe_requirement` VALUES (RecipeID,            MaterialObjectTypeID, Quality, Influence, Quantity, IsRegionalItemRequired)
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  233,                  0,       20,         4,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  281,                  0,       20,         40,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  235,                  0,       20,         40,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  1356,                  0,       20,         10,       0)");
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }
  function JorvikMod2::ObjectsTypesFlagPvP() {
    return new ScriptObject(ObjectsTypesFlagPvP : ObjectsTypes)
    {
      id = 2452; 
      ObjectName = "Flag PvP"; 
      ParentID = 60; 
      IsContainer = 0;
      IsMovableObject = 0; 
      IsUnmovableobject = 1; 
      IsTool = 0; 
      IsDevice = 0; 
      IsDoor = 0; 
      IsPremium = 0; 
      MaxContSize = 1000;
      Length = 8;  
      MaxStackSize = 0; 
      UnitWeight = 10000; 
      BackgrndImage = ""; 
      WorkAreaTop = 0;
      WorkAreaLeft = 0;
      WorkAreaWidth = 0;
      WorkAreaHeight = 0;
      BtnCloseTop = 0;
      BtnCloseLeft = 0;
      FaceImage = "yolauncher/modpack/mods/Jorvik2/art/2D/Objects/flag_pvp.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 20300; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
    };
  }
  function JorvikMod2::FlagPvP() {
                                   //dbi.update("INSERT IGNORE INTO `recipe` VALUES (NULL,      Name,                 Description,      StartingToolsID,   SkillTypeID, SkillLvl, ResultObjectTypeID, SkillDepends,       Quantity, Autorepeat, isBluePrint, ImagePath)
    dbi.Select(JorvikMod2, "FlagPvPRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Flag PvP', 'Object from Jorvik MOD',        32,               19,          100,        2452,               20,                       1,        0,          0,           'yolauncher/modpack/mods/Jorvik2/art/2D/Recipes/flag_pvp.png') RETURNING ID");
  }
  function JorvikMod2::FlagPvPRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
    //dbi.update("INSERT IGNORE INTO `recipe_requirement` VALUES (RecipeID,            MaterialObjectTypeID, Quality, Influence, Quantity, IsRegionalItemRequired)
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  234,                  0,       30,         1,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  264,                  0,       30,         1,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  262,                  0,       10,         1,       0)");
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }
  function JorvikMod2::ObjectsTypesFlagPvE() {
    return new ScriptObject(ObjectsTypesFlagPvE : ObjectsTypes)
    {
      id = 2453; 
      ObjectName = "Flag PvE"; 
      ParentID = 60; 
      IsContainer = 0;
      IsMovableObject = 0; 
      IsUnmovableobject = 1; 
      IsTool = 0; 
      IsDevice = 0; 
      IsDoor = 0; 
      IsPremium = 0; 
      MaxContSize = 1000;
      Length = 8;  
      MaxStackSize = 0; 
      UnitWeight = 10000; 
      BackgrndImage = ""; 
      WorkAreaTop = 0;
      WorkAreaLeft = 0;
      WorkAreaWidth = 0;
      WorkAreaHeight = 0;
      BtnCloseTop = 0;
      BtnCloseLeft = 0;
      FaceImage = "yolauncher/modpack/mods/Jorvik2/art/2D/Objects/flag_pve.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 20300; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
    };
  }
  function JorvikMod2::FlagPvE() {
                                   //dbi.update("INSERT IGNORE INTO `recipe` VALUES (NULL,      Name,                 Description,      StartingToolsID,   SkillTypeID, SkillLvl, ResultObjectTypeID, SkillDepends,       Quantity, Autorepeat, isBluePrint, ImagePath)
    dbi.Select(JorvikMod2, "FlagPvERequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Flag PvE', 'Object from Jorvik MOD',        32,               19,          100,        2453,               20,                       1,        0,          0,           'yolauncher/modpack/mods/Jorvik2/art/2D/Recipes/flag_pvp.png') RETURNING ID");
  }
  function JorvikMod2::FlagPvERequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
    //dbi.update("INSERT IGNORE INTO `recipe_requirement` VALUES (RecipeID,            MaterialObjectTypeID, Quality, Influence, Quantity, IsRegionalItemRequired)
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  234,                  0,       30,         1,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  264,                  0,       30,         1,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  262,                  0,       10,         1,       0)");
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }
  function JorvikMod2::ObjectsTypesLonghouse() {
    return new ScriptObject(ObjectsTypesLonghouse : ObjectsTypes)
    {
      id = 2543; 
      ObjectName = "Longhouse"; 
      ParentID = 72; 
      IsContainer = 0;
      IsMovableObject = 0; 
      IsUnmovableobject = 1; 
      IsTool = 0; 
      IsDevice = 0; 
      IsDoor = 1; 
      IsPremium = 0; 
      MaxContSize = 0;
      Length = 0;  
      MaxStackSize = 12; 
      UnitWeight = 1000000; 
      BackgrndImage = ""; 
      WorkAreaTop = 0;
      WorkAreaLeft = 0;
      WorkAreaWidth = 0;
      WorkAreaHeight = 0;
      BtnCloseTop = 0;
      BtnCloseLeft = 0;
      FaceImage = "yolauncher/modpack/mods/Jorvik2/art/2D/Objects/long_house.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
    };
  }
  function JorvikMod2::Longhouse() {
                                   //dbi.update("INSERT IGNORE INTO `recipe` VALUES (NULL,      Name,                 Description,      StartingToolsID,   SkillTypeID, SkillLvl, ResultObjectTypeID, SkillDepends,       Quantity, Autorepeat, isBluePrint, ImagePath)
    dbi.Select(JorvikMod2, "LonghouseRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Longhouse', 'Object from Jorvik MOD',        32,               20,          60,        2543,               20,                       1,        0,          0,           'yolauncher/modpack/mods/Jorvik2/art/2D/Recipes/long_house.png') RETURNING ID");
  }
  function JorvikMod2::LonghouseRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
    //dbi.update("INSERT IGNORE INTO `recipe_requirement` VALUES (RecipeID,            MaterialObjectTypeID, Quality, Influence, Quantity, IsRegionalItemRequired)
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  233,                  0,       30,         500,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  326,                  0,       20,         300,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  281,                  0,       30,         1000,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  286,                  0,       20,         1,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  241,                  0,       20,         1500,       0)");
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }
  function JorvikMod2::ObjectsTypesStoneGate() {
    return new ScriptObject(ObjectsTypesStoneGate : ObjectsTypes)
    {
      id = 2554; 
      ObjectName = "Stone Gate"; 
      ParentID = 172; 
      IsContainer = 0;
      IsMovableObject = 0; 
      IsUnmovableobject = 1; 
      IsTool = 0; 
      IsDevice = 0; 
      IsDoor = 1; 
      IsPremium = 0; 
      MaxContSize = 0;
      Length = 0;  
      MaxStackSize = 12; 
      UnitWeight = 1000000; 
      BackgrndImage = ""; 
      WorkAreaTop = 0;
      WorkAreaLeft = 0;
      WorkAreaWidth = 0;
      WorkAreaHeight = 0;
      BtnCloseTop = 0;
      BtnCloseLeft = 0;
      FaceImage = "yolauncher/modpack/mods/Jorvik2/art/2D/Objects/long_house.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
    };
  }
  function JorvikMod2::StoneGate() {
                                   //dbi.update("INSERT IGNORE INTO `recipe` VALUES (NULL,      Name,                 Description,      StartingToolsID,   SkillTypeID, SkillLvl, ResultObjectTypeID, SkillDepends,       Quantity, Autorepeat, isBluePrint, ImagePath)
    dbi.Select(JorvikMod2, "StoneGateRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Stone Gate', 'Object from Jorvik MOD',        32,               19,          60,        2554,               35,                       1,        0,          0,           'yolauncher/modpack/mods/Jorvik2/art/2D/Recipes/stone_gate.png') RETURNING ID");
  }
  function JorvikMod2::StoneGateRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
    //dbi.update("INSERT IGNORE INTO `recipe_requirement` VALUES (RecipeID,            MaterialObjectTypeID, Quality, Influence, Quantity, IsRegionalItemRequired)
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  269,                  0,       30,         50,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  235,                  0,       30,         30,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  244,                  0,       30,         400,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  1356,                  0,       30,         20,       0)");
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }
  function JorvikMod2::ObjectsTypesSmallWoodenBridge() {
    return new ScriptObject(ObjectsTypesSmallWoodenBridge : ObjectsTypes)
    {
      id = 2455; 
      ObjectName = "Small Wooden Bridge"; 
      ParentID = 61; 
      IsContainer = 0;
      IsMovableObject = 0; 
      IsUnmovableobject = 1; 
      IsTool = 0; 
      IsDevice = 0; 
      IsDoor = 0; 
      IsPremium = 0; 
      MaxContSize = 0;
      Length = 0;  
      MaxStackSize = 0; 
      UnitWeight = 400000; 
      BackgrndImage = ""; 
      WorkAreaTop = 0;
      WorkAreaLeft = 0;
      WorkAreaWidth = 0;
      WorkAreaHeight = 0;
      BtnCloseTop = 0;
      BtnCloseLeft = 0;
      FaceImage = "yolauncher/modpack/mods/Jorvik2/art/2D/Objects/small_wooden_bridge.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod2::SmallWoodenBridge() {
                                   //dbi.update("INSERT IGNORE INTO `recipe` VALUES (NULL,      Name,                 Description,      StartingToolsID,   SkillTypeID, SkillLvl, ResultObjectTypeID, SkillDepends,                  Quantity,Autorepeat,isBluePrint,           ImagePath)
    dbi.Select(JorvikMod2, "SmallWoodenBridgeRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Wooden Bridge', 'Object from Jorvik MOD',        32,               18,          60,        2455,               10,                       1,        0,          0,           'yolauncher/modpack/mods/Jorvik2/art/2D/Recipes/small_wooden_bridge.png') RETURNING ID");
  }
  function JorvikMod2::SmallWoodenBridgeRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
    //dbi.update("INSERT IGNORE INTO `recipe_requirement` VALUES (RecipeID,            MaterialObjectTypeID, Quality, Influence, Quantity, IsRegionalItemRequired)
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  1356,                  0,       10,         10,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  233,                  0,       20,         10,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  235,                  0,       10,         40,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  281,                  0,       10,         30,       0)");

    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }
  function JorvikMod2::ObjectsTypesSmallStoneBridge() {
    return new ScriptObject(ObjectsTypesSmallStoneBridge : ObjectsTypes)
    {
      id = 2456; 
      ObjectName = "Small Stone Bridge"; 
      ParentID = 61; 
      IsContainer = 0;
      IsMovableObject = 0; 
      IsUnmovableobject = 1; 
      IsTool = 0; 
      IsDevice = 0; 
      IsDoor = 0; 
      IsPremium = 0; 
      MaxContSize = 0;
      Length = 0;  
      MaxStackSize = 0; 
      UnitWeight = 700000; 
      BackgrndImage = ""; 
      WorkAreaTop = 0;
      WorkAreaLeft = 0;
      WorkAreaWidth = 0;
      WorkAreaHeight = 0;
      BtnCloseTop = 0;
      BtnCloseLeft = 0;
      FaceImage = "yolauncher/modpack/mods/Jorvik2/art/2D/Objects/small_stone_bridge.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod2::SmallStoneBridge() {
                                   //dbi.update("INSERT IGNORE INTO `recipe` VALUES (NULL,      Name,                 Description,      StartingToolsID,   SkillTypeID, SkillLvl, ResultObjectTypeID, SkillDepends,                  Quantity,Autorepeat,isBluePrint,           ImagePath)
    dbi.Select(JorvikMod2, "SmallStoneBridgeRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Stone Gate', 'Object from Jorvik MOD',        32,               18,          60,        2456,               35,                       0,        0,          0,           'yolauncher/modpack/mods/Jorvik2/art/2D/Recipes/small_wooden_bridge.png') RETURNING ID");
  }
  function JorvikMod2::SmallStoneBridgeRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
    //dbi.update("INSERT IGNORE INTO `recipe_requirement` VALUES (RecipeID,            MaterialObjectTypeID, Quality, Influence, Quantity, IsRegionalItemRequired)
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  269,                  0,       40,         100,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  244,                  0,       10,         600,       0)");
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }
  function JorvikMod2::ObjectsTypesLargeWoodenBridge() {
    return new ScriptObject(ObjectsTypesLargeWoodenBridge : ObjectsTypes)
    {
      id = 2457; 
      ObjectName = "Large Wooden Bridge"; 
      ParentID = 61; 
      IsContainer = 0;
      IsMovableObject = 0; 
      IsUnmovableobject = 1; 
      IsTool = 0; 
      IsDevice = 0; 
      IsDoor = 0; 
      IsPremium = 0; 
      MaxContSize = 0;
      Length = 0;  
      MaxStackSize = 0; 
      UnitWeight = 600000; 
      BackgrndImage = ""; 
      WorkAreaTop = 0;
      WorkAreaLeft = 0;
      WorkAreaWidth = 0;
      WorkAreaHeight = 0;
      BtnCloseTop = 0;
      BtnCloseLeft = 0;
      FaceImage = "yolauncher/modpack/mods/Jorvik2/art/2D/Objects/large_wooden_bridge.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod2::ObjectsTypesLargeStoneBridge() {
    return new ScriptObject(ObjectsTypesLargeStoneBridge : ObjectsTypes)
    {
      id = 2458; 
      ObjectName = "Large Stone Bridge"; 
      ParentID = 61; 
      IsContainer = 0;
      IsMovableObject = 0; 
      IsUnmovableobject = 1; 
      IsTool = 0; 
      IsDevice = 0; 
      IsDoor = 0; 
      IsPremium = 0; 
      MaxContSize = 0;
      Length = 0;  
      MaxStackSize = 0; 
      UnitWeight = 900000; 
      BackgrndImage = ""; 
      WorkAreaTop = 0;
      WorkAreaLeft = 0;
      WorkAreaWidth = 0;
      WorkAreaHeight = 0;
      BtnCloseTop = 0;
      BtnCloseLeft = 0;
      FaceImage = "yolauncher/modpack/mods/Jorvik2/art/2D/Objects/large_stone_bridge.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod2::ObjectsTypesLargeStoneBridgeEnd() {
    return new ScriptObject(ObjectsTypesLargeStoneBridgeEnd : ObjectsTypes)
    {
      id = 2459; 
      ObjectName = "Large Stone Bridge End"; 
      ParentID = 61; 
      IsContainer = 0;
      IsMovableObject = 0; 
      IsUnmovableobject = 1; 
      IsTool = 0; 
      IsDevice = 0; 
      IsDoor = 0; 
      IsPremium = 0; 
      MaxContSize = 0;
      Length = 0;  
      MaxStackSize = 0; 
      UnitWeight = 500000; 
      BackgrndImage = ""; 
      WorkAreaTop = 0;
      WorkAreaLeft = 0;
      WorkAreaWidth = 0;
      WorkAreaHeight = 0;
      BtnCloseTop = 0;
      BtnCloseLeft = 0;
      FaceImage = "yolauncher/modpack/mods/Jorvik2/art/2D/Objects/large_stone_bridge_end.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod2::ObjectsTypesSmallStoneBridgeEnd() {
    return new ScriptObject(ObjectsTypesSmallStoneBridgeEnd : ObjectsTypes)
    {
      id = 2460; 
      ObjectName = "Small Stone Bridge End"; 
      ParentID = 61; 
      IsContainer = 0;
      IsMovableObject = 0; 
      IsUnmovableobject = 1; 
      IsTool = 0; 
      IsDevice = 0; 
      IsDoor = 0; 
      IsPremium = 0; 
      MaxContSize = 0;
      Length = 0;  
      MaxStackSize = 0; 
      UnitWeight = 400000; 
      BackgrndImage = ""; 
      WorkAreaTop = 0;
      WorkAreaLeft = 0;
      WorkAreaWidth = 0;
      WorkAreaHeight = 0;
      BtnCloseTop = 0;
      BtnCloseLeft = 0;
      FaceImage = "yolauncher/modpack/mods/Jorvik2/art/2D/Objects/small_stone_bridge_end.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod2::ObjectsTypesModularConstructions() {
    return new ScriptObject(ObjectsTypesModularConstructions : ObjectsTypes)
    {
      id = 2473; 
      ObjectName = "Modular Constructions"; 
      ParentID = 13; 
      IsContainer = 0;
      IsMovableObject = 0; 
      IsUnmovableobject = 0; 
      IsTool = 0; 
      IsDevice = 0; 
      IsDoor = 0; 
      IsPremium = 0; 
      MaxContSize = 0;
      Length = 0;  
      MaxStackSize = 0; 
      UnitWeight = 0; 
      BackgrndImage = ""; 
      WorkAreaTop = 0;
      WorkAreaLeft = 0;
      WorkAreaWidth = 0;
      WorkAreaHeight = 0;
      BtnCloseTop = 0;
      BtnCloseLeft = 0;
      FaceImage = "";
      Description = ""; 
      BasePrice = 10; 
      OwnerTimeout = NULL; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod2::ObjectsTypesSmallLogWall() {
    return new ScriptObject(ObjectsTypesSmallLogWall : ObjectsTypes)
    {
      id = 2561; 
      ObjectName = "Small Log Wall"; 
      ParentID = 2473; 
      IsContainer = 0;
      IsMovableObject = 1; 
      IsUnmovableobject = 0; 
      IsTool = 0; 
      IsDevice = 0; 
      IsDoor = 0; 
      IsPremium = 0; 
      MaxContSize = 0;
      Length = 0;  
      MaxStackSize = 0; 
      UnitWeight = 5000; 
      BackgrndImage = ""; 
      WorkAreaTop = 0;
      WorkAreaLeft = 0;
      WorkAreaWidth = 0;
      WorkAreaHeight = 0;
      BtnCloseTop = 0;
      BtnCloseLeft = 0;
      FaceImage = "yolauncher/modpack/mods/Jorvik2/art/2D/Objects/small_log_wall.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod2::ObjectsTypesSmallWoodenPillar() {
    return new ScriptObject(ObjectsTypesSmallWoodenPillar : ObjectsTypes)
    {
      id = 2562; 
      ObjectName = "Small Wooden Pillar"; 
      ParentID = 2473; 
      IsContainer = 0;
      IsMovableObject = 1; 
      IsUnmovableobject = 0; 
      IsTool = 0; 
      IsDevice = 0; 
      IsDoor = 0; 
      IsPremium = 0; 
      MaxContSize = 0;
      Length = 0;  
      MaxStackSize = 0; 
      UnitWeight = 1000; 
      BackgrndImage = ""; 
      WorkAreaTop = 0;
      WorkAreaLeft = 0;
      WorkAreaWidth = 0;
      WorkAreaHeight = 0;
      BtnCloseTop = 0;
      BtnCloseLeft = 0;
      FaceImage = "yolauncher/modpack/mods/Jorvik2/art/2D/Objects/small_wooden_pillar.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod2::ObjectsTypesSmallLogCornerWall() {
    return new ScriptObject(ObjectsTypesSmallLogCornerWall : ObjectsTypes)
    {
      id = 2563; 
      ObjectName = "Small Log Corner Wall"; 
      ParentID = 2473; 
      IsContainer = 0;
      IsMovableObject = 1; 
      IsUnmovableobject = 0; 
      IsTool = 0; 
      IsDevice = 0; 
      IsDoor = 0; 
      IsPremium = 0; 
      MaxContSize = 0;
      Length = 0;  
      MaxStackSize = 0; 
      UnitWeight = 10000; 
      BackgrndImage = ""; 
      WorkAreaTop = 0;
      WorkAreaLeft = 0;
      WorkAreaWidth = 0;
      WorkAreaHeight = 0;
      BtnCloseTop = 0;
      BtnCloseLeft = 0;
      FaceImage = "yolauncher/modpack/mods/Jorvik2/art/2D/Objects/small_log_corner_wall.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod2::ObjectsTypesSmallLogWallWithWindow() {
    return new ScriptObject(ObjectsTypesSmallLogWallWithWindow : ObjectsTypes)
    {
      id = 2564; 
      ObjectName = "Small Log Wall With Window"; 
      ParentID = 2473; 
      IsContainer = 0;
      IsMovableObject = 1; 
      IsUnmovableobject = 0; 
      IsTool = 0; 
      IsDevice = 0; 
      IsDoor = 0; 
      IsPremium = 0; 
      MaxContSize = 0;
      Length = 0;  
      MaxStackSize = 0; 
      UnitWeight = 5000; 
      BackgrndImage = ""; 
      WorkAreaTop = 0;
      WorkAreaLeft = 0;
      WorkAreaWidth = 0;
      WorkAreaHeight = 0;
      BtnCloseTop = 0;
      BtnCloseLeft = 0;
      FaceImage = "yolauncher/modpack/mods/Jorvik2/art/2D/Objects/small_log_wall_with_window.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod2::ObjectsTypesSmallLogWallWithShutters() {
    return new ScriptObject(ObjectsTypesSmallLogWallWithShutters : ObjectsTypes)
    {
      id = 2565; 
      ObjectName = "Small Log Wall With Shutters"; 
      ParentID = 2473; 
      IsContainer = 0;
      IsMovableObject = 1; 
      IsUnmovableobject = 0; 
      IsTool = 0; 
      IsDevice = 0; 
      IsDoor = 1; 
      IsPremium = 0; 
      MaxContSize = 0;
      Length = 0;  
      MaxStackSize = 0; 
      UnitWeight = 5000; 
      BackgrndImage = ""; 
      WorkAreaTop = 0;
      WorkAreaLeft = 0;
      WorkAreaWidth = 0;
      WorkAreaHeight = 0;
      BtnCloseTop = 0;
      BtnCloseLeft = 0;
      FaceImage = "yolauncher/modpack/mods/Jorvik2/art/2D/Objects/small_log_wall_with_shutters.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod2::ObjectsTypesSmallLogWallWithEntrance() {
    return new ScriptObject(ObjectsTypesSmallLogWallWithEntrance : ObjectsTypes)
    {
      id = 2566; 
      ObjectName = "Small Log Wall With Entrance"; 
      ParentID = 2473; 
      IsContainer = 0;
      IsMovableObject = 1; 
      IsUnmovableobject = 0; 
      IsTool = 0; 
      IsDevice = 0; 
      IsDoor = 0; 
      IsPremium = 0; 
      MaxContSize = 0;
      Length = 0;  
      MaxStackSize = 0; 
      UnitWeight = 5000; 
      BackgrndImage = ""; 
      WorkAreaTop = 0;
      WorkAreaLeft = 0;
      WorkAreaWidth = 0;
      WorkAreaHeight = 0;
      BtnCloseTop = 0;
      BtnCloseLeft = 0;
      FaceImage = "yolauncher/modpack/mods/Jorvik2/art/2D/Objects/small_log_wall_with_entrance.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod2::ObjectsTypesSmallLogWallWithDoor() {
    return new ScriptObject(ObjectsTypesSmallLogWallWithDoor : ObjectsTypes)
    {
      id = 2567; 
      ObjectName = "Small Log Wall With Door"; 
      ParentID = 2473; 
      IsContainer = 0;
      IsMovableObject = 1; 
      IsUnmovableobject = 0; 
      IsTool = 0; 
      IsDevice = 0; 
      IsDoor = 1; 
      IsPremium = 0; 
      MaxContSize = 0;
      Length = 0;  
      MaxStackSize = 0; 
      UnitWeight = 5000; 
      BackgrndImage = ""; 
      WorkAreaTop = 0;
      WorkAreaLeft = 0;
      WorkAreaWidth = 0;
      WorkAreaHeight = 0;
      BtnCloseTop = 0;
      BtnCloseLeft = 0;
      FaceImage = "yolauncher/modpack/mods/Jorvik2/art/2D/Objects/small_log_wall_with_door.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod2::ObjectsTypesSmallWoodenFloorEntrance() {
    return new ScriptObject(ObjectsTypesSmallWoodenFloorEntrance : ObjectsTypes)
    {
      id = 2568; 
      ObjectName = "Small Wooden Floor Entrance"; 
      ParentID = 2473; 
      IsContainer = 0;
      IsMovableObject = 1; 
      IsUnmovableobject = 0; 
      IsTool = 0; 
      IsDevice = 0; 
      IsDoor = 0; 
      IsPremium = 0; 
      MaxContSize = 0;
      Length = 0;  
      MaxStackSize = 0; 
      UnitWeight = 2000; 
      BackgrndImage = ""; 
      WorkAreaTop = 0;
      WorkAreaLeft = 0;
      WorkAreaWidth = 0;
      WorkAreaHeight = 0;
      BtnCloseTop = 0;
      BtnCloseLeft = 0;
      FaceImage = "yolauncher/modpack/mods/Jorvik2/art/2D/Objects/small_wooden_floor_entrance.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod2::ObjectsTypesSmallWoodenFloor() {
    return new ScriptObject(ObjectsTypesSmallWoodenFloor : ObjectsTypes)
    {
      id = 2569; 
      ObjectName = "Small Wooden Floor"; 
      ParentID = 2473; 
      IsContainer = 0;
      IsMovableObject = 1; 
      IsUnmovableobject = 0; 
      IsTool = 0; 
      IsDevice = 0; 
      IsDoor = 0; 
      IsPremium = 0; 
      MaxContSize = 0;
      Length = 0;  
      MaxStackSize = 0; 
      UnitWeight = 1000; 
      BackgrndImage = ""; 
      WorkAreaTop = 0;
      WorkAreaLeft = 0;
      WorkAreaWidth = 0;
      WorkAreaHeight = 0;
      BtnCloseTop = 0;
      BtnCloseLeft = 0;
      FaceImage = "yolauncher/modpack/mods/Jorvik2/art/2D/Objects/small_wooden_floor.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod2::ObjectsTypesSmallLogWallSlopeRight() {
    return new ScriptObject(ObjectsTypesSmallLogWallSlopeRight : ObjectsTypes)
    {
      id = 2474; 
      ObjectName = "Small Log Wall Slope Right"; 
      ParentID = 2473; 
      IsContainer = 0;
      IsMovableObject = 1; 
      IsUnmovableobject = 0; 
      IsTool = 0; 
      IsDevice = 0; 
      IsDoor = 0; 
      IsPremium = 0; 
      MaxContSize = 0;
      Length = 0;  
      MaxStackSize = 0; 
      UnitWeight = 5000; 
      BackgrndImage = ""; 
      WorkAreaTop = 0;
      WorkAreaLeft = 0;
      WorkAreaWidth = 0;
      WorkAreaHeight = 0;
      BtnCloseTop = 0;
      BtnCloseLeft = 0;
      FaceImage = "yolauncher/modpack/mods/Jorvik2/art/2D/Objects/small_log_wall_slope_right.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod2::ObjectsTypesSmallLogWallSlopeLeft() {
    return new ScriptObject(ObjectsTypesSmallLogWallSlopeLeft : ObjectsTypes)
    {
      id = 2475; 
      ObjectName = "Small Log Wall Slope Left"; 
      ParentID = 2473; 
      IsContainer = 0;
      IsMovableObject = 1; 
      IsUnmovableobject = 0; 
      IsTool = 0; 
      IsDevice = 0; 
      IsDoor = 0; 
      IsPremium = 0; 
      MaxContSize = 0;
      Length = 0;  
      MaxStackSize = 0; 
      UnitWeight = 5000; 
      BackgrndImage = ""; 
      WorkAreaTop = 0;
      WorkAreaLeft = 0;
      WorkAreaWidth = 0;
      WorkAreaHeight = 0;
      BtnCloseTop = 0;
      BtnCloseLeft = 0;
      FaceImage = "yolauncher/modpack/mods/Jorvik2/art/2D/Objects/small_log_wall_slope_left.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod2::ObjectsTypesSmallThatchRoof() {
    return new ScriptObject(ObjectsTypesSmallThatchRoof : ObjectsTypes)
    {
      id = 2476; 
      ObjectName = "SmallThatchRoof"; 
      ParentID = 2473; 
      IsContainer = 0;
      IsMovableObject = 1; 
      IsUnmovableobject = 0; 
      IsTool = 0; 
      IsDevice = 0; 
      IsDoor = 0; 
      IsPremium = 0; 
      MaxContSize = 0;
      Length = 0;  
      MaxStackSize = 0; 
      UnitWeight = 5000; 
      BackgrndImage = ""; 
      WorkAreaTop = 0;
      WorkAreaLeft = 0;
      WorkAreaWidth = 0;
      WorkAreaHeight = 0;
      BtnCloseTop = 0;
      BtnCloseLeft = 0;
      FaceImage = "yolauncher/modpack/mods/Jorvik2/art/2D/Objects/small_thatch_roof.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod2::ObjectsTypesSmallThatchRoofRightEnd() {
    return new ScriptObject(ObjectsTypesSmallThatchRoofRightEnd : ObjectsTypes)
    {
      id = 2477; 
      ObjectName = "SmallThatchRoofRightEnd"; 
      ParentID = 2473; 
      IsContainer = 0;
      IsMovableObject = 1; 
      IsUnmovableobject = 0; 
      IsTool = 0; 
      IsDevice = 0; 
      IsDoor = 0; 
      IsPremium = 0; 
      MaxContSize = 0;
      Length = 0;  
      MaxStackSize = 0; 
      UnitWeight = 5000; 
      BackgrndImage = ""; 
      WorkAreaTop = 0;
      WorkAreaLeft = 0;
      WorkAreaWidth = 0;
      WorkAreaHeight = 0;
      BtnCloseTop = 0;
      BtnCloseLeft = 0;
      FaceImage = "yolauncher/modpack/mods/Jorvik2/art/2D/Objects/small_thatch_roof_rihgt_end.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod2::ObjectsTypesSmallThatchRoofLeftEnd() {
    return new ScriptObject(ObjectsTypesSmallThatchRoofLeftEnd : ObjectsTypes)
    {
      id = 2478; 
      ObjectName = "SmallThatchRoofLeftEnd"; 
      ParentID = 2473; 
      IsContainer = 0;
      IsMovableObject = 1; 
      IsUnmovableobject = 0; 
      IsTool = 0; 
      IsDevice = 0; 
      IsDoor = 0; 
      IsPremium = 0; 
      MaxContSize = 0;
      Length = 0;  
      MaxStackSize = 0; 
      UnitWeight = 5000; 
      BackgrndImage = ""; 
      WorkAreaTop = 0;
      WorkAreaLeft = 0;
      WorkAreaWidth = 0;
      WorkAreaHeight = 0;
      BtnCloseTop = 0;
      BtnCloseLeft = 0;
      FaceImage = "yolauncher/modpack/mods/Jorvik2/art/2D/Objects/small_thatch_roof_left_end.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod2::ObjectsTypesSmallThatchRoofOuterCorner() {
    return new ScriptObject(ObjectsTypesSmallThatchRoofOuterCorner : ObjectsTypes)
    {
      id = 2479; 
      ObjectName = "SmallThatchRoofOuterCorner"; 
      ParentID = 2473; 
      IsContainer = 0;
      IsMovableObject = 1; 
      IsUnmovableobject = 0; 
      IsTool = 0; 
      IsDevice = 0; 
      IsDoor = 0; 
      IsPremium = 0; 
      MaxContSize = 0;
      Length = 0;  
      MaxStackSize = 0; 
      UnitWeight = 10000; 
      BackgrndImage = ""; 
      WorkAreaTop = 0;
      WorkAreaLeft = 0;
      WorkAreaWidth = 0;
      WorkAreaHeight = 0;
      BtnCloseTop = 0;
      BtnCloseLeft = 0;
      FaceImage = "yolauncher/modpack/mods/Jorvik2/art/2D/Objects/small_thatch_roof_outer_corner.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod2::ObjectsTypesModularConstructionslvl1() {
    return new ScriptObject(ObjectsTypesModularConstructionslvl1 : ObjectsTypes)
    {
      id = 2480; 
      ObjectName = "Modular Constructions lvl 1"; 
      ParentID = 13; 
      IsContainer = 0;
      IsMovableObject = 0; 
      IsUnmovableobject = 0; 
      IsTool = 0; 
      IsDevice = 0; 
      IsDoor = 0; 
      IsPremium = 0; 
      MaxContSize = 0;
      Length = 0;  
      MaxStackSize = 0; 
      UnitWeight = 0; 
      BackgrndImage = ""; 
      WorkAreaTop = 0;
      WorkAreaLeft = 0;
      WorkAreaWidth = 0;
      WorkAreaHeight = 0;
      BtnCloseTop = 0;
      BtnCloseLeft = 0;
      FaceImage = "";
      Description = ""; 
      BasePrice = 10; 
      OwnerTimeout = NULL; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod2::ObjectsTypesSmallLogWalllvl1() {
    return new ScriptObject(ObjectsTypesSmallLogWalllvl1 : ObjectsTypes)
    {
      id = 2481; 
      ObjectName = "Small Log Wall"; 
      ParentID = 2480;
      IsContainer = 0;
      IsMovableObject = 1; 
      IsUnmovableobject = 0; 
      IsTool = 0; 
      IsDevice = 0; 
      IsDoor = 0; 
      IsPremium = 0; 
      MaxContSize = 0;
      Length = 0;  
      MaxStackSize = 0; 
      UnitWeight = 5000; 
      BackgrndImage = ""; 
      WorkAreaTop = 0;
      WorkAreaLeft = 0;
      WorkAreaWidth = 0;
      WorkAreaHeight = 0;
      BtnCloseTop = 0;
      BtnCloseLeft = 0;
      FaceImage = "yolauncher/modpack/mods/Jorvik2/art/2D/Objects/small_log_wall_lvl1.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod2::ObjectsTypesSmallWoodenPillarlvl1() {
    return new ScriptObject(ObjectsTypesSmallWoodenPillarlvl1 : ObjectsTypes)
    {
      id = 2482; 
      ObjectName = "Small Wooden Pillar"; 
      ParentID = 2480;
      IsContainer = 0;
      IsMovableObject = 1; 
      IsUnmovableobject = 0; 
      IsTool = 0; 
      IsDevice = 0; 
      IsDoor = 0; 
      IsPremium = 0; 
      MaxContSize = 0;
      Length = 0;  
      MaxStackSize = 0; 
      UnitWeight = 1000; 
      BackgrndImage = ""; 
      WorkAreaTop = 0;
      WorkAreaLeft = 0;
      WorkAreaWidth = 0;
      WorkAreaHeight = 0;
      BtnCloseTop = 0;
      BtnCloseLeft = 0;
      FaceImage = "yolauncher/modpack/mods/Jorvik2/art/2D/Objects/small_wooden_pillar_lvl1.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod2::ObjectsTypesSmallLogCornerWalllvl1() {
    return new ScriptObject(ObjectsTypesSmallLogCornerWalllvl1 : ObjectsTypes)
    {
      id = 2483; 
      ObjectName = "Small Log Corner Wall"; 
      ParentID = 2480;
      IsContainer = 0;
      IsMovableObject = 1; 
      IsUnmovableobject = 0; 
      IsTool = 0; 
      IsDevice = 0; 
      IsDoor = 0; 
      IsPremium = 0; 
      MaxContSize = 0;
      Length = 0;  
      MaxStackSize = 0; 
      UnitWeight = 10000; 
      BackgrndImage = ""; 
      WorkAreaTop = 0;
      WorkAreaLeft = 0;
      WorkAreaWidth = 0;
      WorkAreaHeight = 0;
      BtnCloseTop = 0;
      BtnCloseLeft = 0;
      FaceImage = "yolauncher/modpack/mods/Jorvik2/art/2D/Objects/small_log_corner_wall.png_lvl1";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod2::ObjectsTypesSmallLogWallWithWindowlvl1() {
    return new ScriptObject(ObjectsTypesSmallLogWallWithWindowlvl1 : ObjectsTypes)
    {
      id = 2484; 
      ObjectName = "Small Log Wall With Window"; 
      ParentID = 2480;
      IsContainer = 0;
      IsMovableObject = 1; 
      IsUnmovableobject = 0; 
      IsTool = 0; 
      IsDevice = 0; 
      IsDoor = 0; 
      IsPremium = 0; 
      MaxContSize = 0;
      Length = 0;  
      MaxStackSize = 0; 
      UnitWeight = 5000; 
      BackgrndImage = ""; 
      WorkAreaTop = 0;
      WorkAreaLeft = 0;
      WorkAreaWidth = 0;
      WorkAreaHeight = 0;
      BtnCloseTop = 0;
      BtnCloseLeft = 0;
      FaceImage = "yolauncher/modpack/mods/Jorvik2/art/2D/Objects/small_log_wall_with_window_lvl1.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod2::ObjectsTypesSmallLogWallWithShutterslvl1() {
    return new ScriptObject(ObjectsTypesSmallLogWallWithShutterslvl1 : ObjectsTypes)
    {
      id = 2544; 
      ObjectName = "Small Log Wall With Shutters"; 
      ParentID = 2480;
      IsContainer = 0;
      IsMovableObject = 1; 
      IsUnmovableobject = 0; 
      IsTool = 0; 
      IsDevice = 0; 
      IsDoor = 1; 
      IsPremium = 0; 
      MaxContSize = 0;
      Length = 0;  
      MaxStackSize = 0; 
      UnitWeight = 5000; 
      BackgrndImage = ""; 
      WorkAreaTop = 0;
      WorkAreaLeft = 0;
      WorkAreaWidth = 0;
      WorkAreaHeight = 0;
      BtnCloseTop = 0;
      BtnCloseLeft = 0;
      FaceImage = "yolauncher/modpack/mods/Jorvik2/art/2D/Objects/small_log_wall_with_shutters_lvl1.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod2::ObjectsTypesSmallLogWallWithEntrancelvl1() {
    return new ScriptObject(ObjectsTypesSmallLogWallWithEntrancelvl1 : ObjectsTypes)
    {
      id = 2545; 
      ObjectName = "Small Log Wall With Entrance"; 
      ParentID = 2480;
      IsContainer = 0;
      IsMovableObject = 1; 
      IsUnmovableobject = 0; 
      IsTool = 0; 
      IsDevice = 0; 
      IsDoor = 0; 
      IsPremium = 0; 
      MaxContSize = 0;
      Length = 0;  
      MaxStackSize = 0; 
      UnitWeight = 5000; 
      BackgrndImage = ""; 
      WorkAreaTop = 0;
      WorkAreaLeft = 0;
      WorkAreaWidth = 0;
      WorkAreaHeight = 0;
      BtnCloseTop = 0;
      BtnCloseLeft = 0;
      FaceImage = "yolauncher/modpack/mods/Jorvik2/art/2D/Objects/small_log_wall_with_entrance_lvl1.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod2::ObjectsTypesSmallLogWallWithDoorlvl1() {
    return new ScriptObject(ObjectsTypesSmallLogWallWithDoorlvl1 : ObjectsTypes)
    {
      id = 2546; 
      ObjectName = "Small Log Wall With Door"; 
      ParentID = 2480;
      IsContainer = 0;
      IsMovableObject = 1; 
      IsUnmovableobject = 0; 
      IsTool = 0; 
      IsDevice = 0; 
      IsDoor = 1; 
      IsPremium = 0; 
      MaxContSize = 0;
      Length = 0;  
      MaxStackSize = 0; 
      UnitWeight = 5000; 
      BackgrndImage = ""; 
      WorkAreaTop = 0;
      WorkAreaLeft = 0;
      WorkAreaWidth = 0;
      WorkAreaHeight = 0;
      BtnCloseTop = 0;
      BtnCloseLeft = 0;
      FaceImage = "yolauncher/modpack/mods/Jorvik2/art/2D/Objects/small_log_wall_with_door_lvl1.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod2::ObjectsTypesSmallWoodenFloorEntrancelvl1() {
    return new ScriptObject(ObjectsTypesSmallWoodenFloorEntrancelvl1: ObjectsTypes)
    {
      id = 2547; 
      ObjectName = "Small Wooden Floor Entrance"; 
      ParentID = 2480;
      IsContainer = 0;
      IsMovableObject = 1; 
      IsUnmovableobject = 0; 
      IsTool = 0; 
      IsDevice = 0; 
      IsDoor = 0; 
      IsPremium = 0; 
      MaxContSize = 0;
      Length = 0;  
      MaxStackSize = 0; 
      UnitWeight = 2000; 
      BackgrndImage = ""; 
      WorkAreaTop = 0;
      WorkAreaLeft = 0;
      WorkAreaWidth = 0;
      WorkAreaHeight = 0;
      BtnCloseTop = 0;
      BtnCloseLeft = 0;
      FaceImage = "yolauncher/modpack/mods/Jorvik2/art/2D/Objects/small_wooden_floor_entrance_lvl1.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod2::ObjectsTypesSmallWoodenFloorlvl1() {
    return new ScriptObject(ObjectsTypesSmallWoodenFloorlvl1 : ObjectsTypes)
    {
      id = 2548; 
      ObjectName = "Small Wooden Floor"; 
      ParentID = 2480;
      IsContainer = 0;
      IsMovableObject = 1; 
      IsUnmovableobject = 0; 
      IsTool = 0; 
      IsDevice = 0; 
      IsDoor = 0; 
      IsPremium = 0; 
      MaxContSize = 0;
      Length = 0;  
      MaxStackSize = 0; 
      UnitWeight = 5000; 
      BackgrndImage = ""; 
      WorkAreaTop = 0;
      WorkAreaLeft = 0;
      WorkAreaWidth = 0;
      WorkAreaHeight = 0;
      BtnCloseTop = 0;
      BtnCloseLeft = 0;
      FaceImage = "yolauncher/modpack/mods/Jorvik2/art/2D/Objects/small_wooden_floor.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod2::ObjectsTypesSmallWoodenStairs() {
    return new ScriptObject(ObjectsTypesSmallWoodenStairs : ObjectsTypes)
    {
      id = 2549; 
      ObjectName = "Small Wooden Stairs"; 
      ParentID = 61; 
      IsContainer = 0;
      IsMovableObject = 1; 
      IsUnmovableobject = 0; 
      IsTool = 0; 
      IsDevice = 0; 
      IsDoor = 0; 
      IsPremium = 0; 
      MaxContSize = 0;
      Length = 0;  
      MaxStackSize = 0; 
      UnitWeight = 5000; 
      BackgrndImage = ""; 
      WorkAreaTop = 0;
      WorkAreaLeft = 0;
      WorkAreaWidth = 0;
      WorkAreaHeight = 0;
      BtnCloseTop = 0;
      BtnCloseLeft = 0;
      FaceImage = "yolauncher/modpack/mods/Jorvik2/art/2D/Objects/small_wooden_stairs.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 100; 
      OwnerTimeout = 120; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod2::ObjectsTypesSmallWoodenStairsMovable() {
    return new ScriptObject(ObjectsTypesSmallWoodenStairsMovable : ObjectsTypes)
    {
      id = 2507; 
      ObjectName = "Small Wooden Stairs"; 
      ParentID = 1902; 
      IsContainer = 0;
      IsMovableObject = 0; 
      IsUnmovableobject = 0; 
      IsTool = 0; 
      IsDevice = 0; 
      IsDoor = 0; 
      IsPremium = 0; 
      MaxContSize = 0;
      Length = 0;  
      MaxStackSize = 0; 
      UnitWeight = 5000; 
      BackgrndImage = ""; 
      WorkAreaTop = 0;
      WorkAreaLeft = 0;
      WorkAreaWidth = 0;
      WorkAreaHeight = 0;
      BtnCloseTop = 0;
      BtnCloseLeft = 0;
      FaceImage = "yolauncher/modpack/mods/Jorvik2/art/2D/Objects/small_wooden_stairs.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 100; 
      OwnerTimeout = 120; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod2::ObjectsTypesSmallThatchRoofTop() {
    return new ScriptObject(ObjectsTypesSmallThatchRoofTop: ObjectsTypes)
    {
      id = 2550; 
      ObjectName = "SmallThatchRoofTop"; 
      ParentID = 2473; 
      IsContainer = 0;
      IsMovableObject = 1; 
      IsUnmovableobject = 0; 
      IsTool = 0; 
      IsDevice = 0; 
      IsDoor = 0; 
      IsPremium = 0; 
      MaxContSize = 0;
      Length = 0;  
      MaxStackSize = 0; 
      UnitWeight = 5000; 
      BackgrndImage = ""; 
      WorkAreaTop = 0;
      WorkAreaLeft = 0;
      WorkAreaWidth = 0;
      WorkAreaHeight = 0;
      BtnCloseTop = 0;
      BtnCloseLeft = 0;
      FaceImage = "yolauncher/modpack/mods/Jorvik2/art/2D/Objects/small_thatch_roof_top.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod2::ObjectsTypesSmallThatchRoofOuterCornerTop() {
    return new ScriptObject(ObjectsTypesSmallThatchRoofOuterCornerTop: ObjectsTypes)
    {
      id = 2551; 
      ObjectName = "SmallThatchRoofOuterCornerTop"; 
      ParentID = 2473; 
      IsContainer = 0;
      IsMovableObject = 1; 
      IsUnmovableobject = 0; 
      IsTool = 0; 
      IsDevice = 0; 
      IsDoor = 0; 
      IsPremium = 0; 
      MaxContSize = 0;
      Length = 0;  
      MaxStackSize = 0; 
      UnitWeight = 5000; 
      BackgrndImage = ""; 
      WorkAreaTop = 0;
      WorkAreaLeft = 0;
      WorkAreaWidth = 0;
      WorkAreaHeight = 0;
      BtnCloseTop = 0;
      BtnCloseLeft = 0;
      FaceImage = "yolauncher/modpack/mods/Jorvik2/art/2D/Objects/small_thatch_roof_outer_corner_top.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod2::ObjectsTypesSmallThatchRoofTopLeftEnd() {
    return new ScriptObject(ObjectsTypesSmallThatchRoofTopLeftEnd : ObjectsTypes)
    {
      id = 2493; 
      ObjectName = "SmallThatchRoofTopLeftEnd"; 
      ParentID = 2473; 
      IsContainer = 0;
      IsMovableObject = 1; 
      IsUnmovableobject = 0; 
      IsTool = 0; 
      IsDevice = 0; 
      IsDoor = 0; 
      IsPremium = 0; 
      MaxContSize = 0;
      Length = 0;  
      MaxStackSize = 0; 
      UnitWeight = 5000; 
      BackgrndImage = ""; 
      WorkAreaTop = 0;
      WorkAreaLeft = 0;
      WorkAreaWidth = 0;
      WorkAreaHeight = 0;
      BtnCloseTop = 0;
      BtnCloseLeft = 0;
      FaceImage = "yolauncher/modpack/mods/Jorvik2/art/2D/Objects/small_thatch_roof_top_left_end.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod2::ObjectsTypesSmallThatchRoofTopRightEnd() {
    return new ScriptObject(ObjectsTypesSmallThatchRoofTopRightEnd : ObjectsTypes)
    {
      id = 2494; 
      ObjectName = "SmallThatchRoofTopRightEnd"; 
      ParentID = 2473; 
      IsContainer = 0;
      IsMovableObject = 1; 
      IsUnmovableobject = 0; 
      IsTool = 0; 
      IsDevice = 0; 
      IsDoor = 0; 
      IsPremium = 0; 
      MaxContSize = 0;
      Length = 0;  
      MaxStackSize = 0; 
      UnitWeight = 5000; 
      BackgrndImage = ""; 
      WorkAreaTop = 0;
      WorkAreaLeft = 0;
      WorkAreaWidth = 0;
      WorkAreaHeight = 0;
      BtnCloseTop = 0;
      BtnCloseLeft = 0;
      FaceImage = "yolauncher/modpack/mods/Jorvik2/art/2D/Objects/small_thatch_roof_top_right_end.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod2::ObjectsTypesSmallThatchRooflvl1() {
    return new ScriptObject(ObjectsTypesSmallThatchRooflvl1 : ObjectsTypes)
    {
      id = 2495; 
      ObjectName = "SmallThatchRoof"; 
      ParentID = 2480;
      IsContainer = 0;
      IsMovableObject = 1; 
      IsUnmovableobject = 0; 
      IsTool = 0; 
      IsDevice = 0; 
      IsDoor = 0; 
      IsPremium = 0; 
      MaxContSize = 0;
      Length = 0;  
      MaxStackSize = 0; 
      UnitWeight = 5000; 
      BackgrndImage = ""; 
      WorkAreaTop = 0;
      WorkAreaLeft = 0;
      WorkAreaWidth = 0;
      WorkAreaHeight = 0;
      BtnCloseTop = 0;
      BtnCloseLeft = 0;
      FaceImage = "yolauncher/modpack/mods/Jorvik2/art/2D/Objects/small_thatch_roof.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod2::ObjectsTypesSmallThatchRoofOuterCornerlvl1() {
    return new ScriptObject(ObjectsTypesSmallThatchRoofOuterCornerlvl1 : ObjectsTypes)
    {
      id = 2496; 
      ObjectName = "SmallThatchRoofOuterCorner"; 
      ParentID = 2480;
      IsContainer = 0;
      IsMovableObject = 1; 
      IsUnmovableobject = 0; 
      IsTool = 0; 
      IsDevice = 0; 
      IsDoor = 0; 
      IsPremium = 0; 
      MaxContSize = 0;
      Length = 0;  
      MaxStackSize = 0; 
      UnitWeight = 10000; 
      BackgrndImage = ""; 
      WorkAreaTop = 0;
      WorkAreaLeft = 0;
      WorkAreaWidth = 0;
      WorkAreaHeight = 0;
      BtnCloseTop = 0;
      BtnCloseLeft = 0;
      FaceImage = "yolauncher/modpack/mods/Jorvik2/art/2D/Objects/small_thatch_roof_outer_corner.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod2::ObjectsTypesSmallWoodenRailing() {
    return new ScriptObject(ObjectsTypesSmallWoodenRailing : ObjectsTypes)
    {
      id = 2497; 
      ObjectName = "Small Wooden Railing"; 
      ParentID = 2473; 
      IsContainer = 0;
      IsMovableObject = 1; 
      IsUnmovableobject = 0; 
      IsTool = 0; 
      IsDevice = 0; 
      IsDoor = 0; 
      IsPremium = 0; 
      MaxContSize = 0;
      Length = 0;  
      MaxStackSize = 0; 
      UnitWeight = 1000; 
      BackgrndImage = ""; 
      WorkAreaTop = 0;
      WorkAreaLeft = 0;
      WorkAreaWidth = 0;
      WorkAreaHeight = 0;
      BtnCloseTop = 0;
      BtnCloseLeft = 0;
      FaceImage = "yolauncher/modpack/mods/Jorvik2/art/2D/Objects/small_wooden_railing.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod2::ObjectsTypesSmallWoodenRailinglvl1() {
    return new ScriptObject(ObjectsTypesSmallWoodenRailinglvl1 : ObjectsTypes)
    {
      id = 2498; 
      ObjectName = "Small Wooden Railing"; 
      ParentID = 2480;
      IsContainer = 0;
      IsMovableObject = 1; 
      IsUnmovableobject = 0; 
      IsTool = 0; 
      IsDevice = 0; 
      IsDoor = 0; 
      IsPremium = 0; 
      MaxContSize = 0;
      Length = 0;  
      MaxStackSize = 0; 
      UnitWeight = 1000; 
      BackgrndImage = ""; 
      WorkAreaTop = 0;
      WorkAreaLeft = 0;
      WorkAreaWidth = 0;
      WorkAreaHeight = 0;
      BtnCloseTop = 0;
      BtnCloseLeft = 0;
      FaceImage = "yolauncher/modpack/mods/Jorvik2/art/2D/Objects/small_wooden_railing_lvl1.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod2::ObjectsTypesSmallThatchRoofOuterCornerToplvl1() {
    return new ScriptObject(ObjectsTypesSmallThatchRoofOuterCornerToplvl1 : ObjectsTypes)
    {
      id = 2499; 
      ObjectName = "SmallThatchRoofOuterCorner"; 
      ParentID = 2480;
      IsContainer = 0;
      IsMovableObject = 1; 
      IsUnmovableobject = 0; 
      IsTool = 0; 
      IsDevice = 0; 
      IsDoor = 0; 
      IsPremium = 0; 
      MaxContSize = 0;
      Length = 0;  
      MaxStackSize = 0; 
      UnitWeight = 5000; 
      BackgrndImage = ""; 
      WorkAreaTop = 0;
      WorkAreaLeft = 0;
      WorkAreaWidth = 0;
      WorkAreaHeight = 0;
      BtnCloseTop = 0;
      BtnCloseLeft = 0;
      FaceImage = "yolauncher/modpack/mods/Jorvik2/art/2D/Objects/small_thatch_roof_outer_corner_top.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod2::ObjectsTypesWallTorch() {
    return new ScriptObject(ObjectsTypesWallTorch : ObjectsTypes)
    {
      id = 2500; 
      ObjectName = "Wall Torch"; 
      ParentID = 1637; 
      IsContainer = 0;
      IsMovableObject = 1; 
      IsUnmovableobject = 0; 
      IsTool = 0; 
      IsDevice = 0; 
      IsDoor = 0; 
      IsPremium = 1; 
      MaxContSize = 0;
      Length = 3;  
      MaxStackSize = 0; 
      UnitWeight = 1000; 
      BackgrndImage = ""; 
      WorkAreaTop = 0;
      WorkAreaLeft = 0;
      WorkAreaWidth = 0;
      WorkAreaHeight = 0;
      BtnCloseTop = 0;
      BtnCloseLeft = 0;
      FaceImage = "yolauncher/modpack/mods/Jorvik2/art/2D/Recipes/wall_torch.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod2::ObjectsTypesWallTorchMovable() {
    return new ScriptObject(ObjectsTypesWallTorchMovable : ObjectsTypes)
    {
      id = 2501; 
      ObjectName = "Wall Torch"; 
      ParentID = 1902; 
      IsContainer = 0;
      IsMovableObject = 0; 
      IsUnmovableobject = 0; 
      IsTool = 0; 
      IsDevice = 0; 
      IsDoor = 0; 
      IsPremium = 0; 
      MaxContSize = 0;
      Length = 3;  
      MaxStackSize = 1; 
      UnitWeight = 1000; 
      BackgrndImage = ""; 
      WorkAreaTop = 0;
      WorkAreaLeft = 0;
      WorkAreaWidth = 0;
      WorkAreaHeight = 0;
      BtnCloseTop = 0;
      BtnCloseLeft = 0;
      FaceImage = "yolauncher/modpack/mods/Jorvik2/art/2D/Recipes/wall_torch.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod2::ObjectsTypesSmallCandle() {
    return new ScriptObject(ObjectsTypesSmallCandle : ObjectsTypes)
    {
      id = 2502; 
      ObjectName = "Small Candle"; 
      ParentID = 1637; 
      IsContainer = 0;
      IsMovableObject = 1; 
      IsUnmovableobject = 0; 
      IsTool = 0; 
      IsDevice = 0; 
      IsDoor = 0; 
      IsPremium = 1; 
      MaxContSize = 0;
      Length = 3;  
      MaxStackSize = 0; 
      UnitWeight = 1000; 
      BackgrndImage = ""; 
      WorkAreaTop = 0;
      WorkAreaLeft = 0;
      WorkAreaWidth = 0;
      WorkAreaHeight = 0;
      BtnCloseTop = 0;
      BtnCloseLeft = 0;
      FaceImage = "yolauncher/modpack/mods/Jorvik2/art/2D/Recipes/small_candle.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod2::ObjectsTypesSmallCandleMovable() {
    return new ScriptObject(ObjectsTypesSmallCandleMovable : ObjectsTypes)
    {
      id = 2503; 
      ObjectName = "Small Candle"; 
      ParentID = 1902; 
      IsContainer = 0;
      IsMovableObject = 0; 
      IsUnmovableobject = 0; 
      IsTool = 0; 
      IsDevice = 0; 
      IsDoor = 0; 
      IsPremium = 1; 
      MaxContSize = 0;
      Length = 3;  
      MaxStackSize = 0; 
      UnitWeight = 1000; 
      BackgrndImage = ""; 
      WorkAreaTop = 0;
      WorkAreaLeft = 0;
      WorkAreaWidth = 0;
      WorkAreaHeight = 0;
      BtnCloseTop = 0;
      BtnCloseLeft = 0;
      FaceImage = "yolauncher/modpack/mods/Jorvik2/art/2D/Recipes/small_candle.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod2::ObjectsTypesAurochsCowstand() {
    return new ScriptObject(ObjectsTypesAurochsCowstand : ObjectsTypes)
    {
      id = 2504; 
      ObjectName = "Aurochs Cow (stand)"; 
      ParentID = 1637; 
      IsContainer = 0;
      IsMovableObject = 0; 
      IsUnmovableobject = 1; 
      IsTool = 0; 
      IsDevice = 0; 
      IsDoor = 0; 
      IsPremium = 1; 
      MaxContSize = 0;
      Length = 3;  
      MaxStackSize = 0; 
      UnitWeight = 400000; 
      BackgrndImage = ""; 
      WorkAreaTop = 0;
      WorkAreaLeft = 0;
      WorkAreaWidth = 0;
      WorkAreaHeight = 0;
      BtnCloseTop = 0;
      BtnCloseLeft = 0;
      FaceImage = "yolauncher/modpack/mods/Jorvik2/art/2D/Recipes/aurochs_cow.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod2::ObjectsTypesAurochsCoweat() {
    return new ScriptObject(ObjectsTypesAurochsCoweat : ObjectsTypes)
    {
      id = 2505; 
      ObjectName = "Aurochs Cow (eat)"; 
      ParentID = 1637; 
      IsContainer = 0;
      IsMovableObject = 0; 
      IsUnmovableobject = 1; 
      IsTool = 0; 
      IsDevice = 0; 
      IsDoor = 0; 
      IsPremium = 1; 
      MaxContSize = 0;
      Length = 3;  
      MaxStackSize = 0; 
      UnitWeight = 400000; 
      BackgrndImage = ""; 
      WorkAreaTop = 0;
      WorkAreaLeft = 0;
      WorkAreaWidth = 0;
      WorkAreaHeight = 0;
      BtnCloseTop = 0;
      BtnCloseLeft = 0;
      FaceImage = "yolauncher/modpack/mods/Jorvik2/art/2D/Recipes/aurochs_cow.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod2::ObjectsTypesAurochsCowsleep() {
    return new ScriptObject(ObjectsTypesAurochsCowsleep : ObjectsTypes)
    {
      id = 2506; 
      ObjectName = "Aurochs Cow (sleep)"; 
      ParentID = 1637; 
      IsContainer = 0;
      IsMovableObject = 0; 
      IsUnmovableobject = 1; 
      IsTool = 0; 
      IsDevice = 0; 
      IsDoor = 0; 
      IsPremium = 1; 
      MaxContSize = 0;
      Length = 3;  
      MaxStackSize = 0; 
      UnitWeight = 400000; 
      BackgrndImage = ""; 
      WorkAreaTop = 0;
      WorkAreaLeft = 0;
      WorkAreaWidth = 0;
      WorkAreaHeight = 0;
      BtnCloseTop = 0;
      BtnCloseLeft = 0;
      FaceImage = "yolauncher/modpack/mods/Jorvik2/art/2D/Recipes/aurochs_cow.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod2::ObjectsTypesSowstand() {
    return new ScriptObject(ObjectsTypesSowstand : ObjectsTypes)
    {
      id = 2508; 
      ObjectName = "Sow (stand)"; 
      ParentID = 1637; 
      IsContainer = 0;
      IsMovableObject = 0; 
      IsUnmovableobject = 1; 
      IsTool = 0; 
      IsDevice = 0; 
      IsDoor = 0; 
      IsPremium = 1; 
      MaxContSize = 0;
      Length = 1;  
      MaxStackSize = 1; 
      UnitWeight = 100000; 
      BackgrndImage = ""; 
      WorkAreaTop = 0;
      WorkAreaLeft = 0;
      WorkAreaWidth = 0;
      WorkAreaHeight = 0;
      BtnCloseTop = 0;
      BtnCloseLeft = 0;
      FaceImage = "yolauncher/modpack/mods/Jorvik2/art/2D/Recipes/sow.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod2::ObjectsTypesSoweat() {
    return new ScriptObject(ObjectsTypesSoweat : ObjectsTypes)
    {
      id = 2509; 
      ObjectName = "Sow (eat)"; 
      ParentID = 1637; 
      IsContainer = 0;
      IsMovableObject = 0; 
      IsUnmovableobject = 1; 
      IsTool = 0; 
      IsDevice = 0; 
      IsDoor = 0; 
      IsPremium = 1; 
      MaxContSize = 0;
      Length = 1;  
      MaxStackSize = 1; 
      UnitWeight = 100000; 
      BackgrndImage = ""; 
      WorkAreaTop = 0;
      WorkAreaLeft = 0;
      WorkAreaWidth = 0;
      WorkAreaHeight = 0;
      BtnCloseTop = 0;
      BtnCloseLeft = 0;
      FaceImage = "yolauncher/modpack/mods/Jorvik2/art/2D/Recipes/sow.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod2::ObjectsTypesSowsleep() {
    return new ScriptObject(ObjectsTypesSowsleep : ObjectsTypes)
    {
      id = 2510; 
      ObjectName = "Sow (sleep)"; 
      ParentID = 1637; 
      IsContainer = 0;
      IsMovableObject = 0; 
      IsUnmovableobject = 1; 
      IsTool = 0; 
      IsDevice = 0; 
      IsDoor = 0; 
      IsPremium = 1; 
      MaxContSize = 0;
      Length = 1;  
      MaxStackSize = 1; 
      UnitWeight = 100000; 
      BackgrndImage = ""; 
      WorkAreaTop = 0;
      WorkAreaLeft = 0;
      WorkAreaWidth = 0;
      WorkAreaHeight = 0;
      BtnCloseTop = 0;
      BtnCloseLeft = 0;
      FaceImage = "yolauncher/modpack/mods/Jorvik2/art/2D/Recipes/sow.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod2::ObjectsTypesHorsestand() {
    return new ScriptObject(ObjectsTypesHorsestand : ObjectsTypes)
    {
      id = 2511; 
      ObjectName = "Horse (stand)"; 
      ParentID = 1637; 
      IsContainer = 0;
      IsMovableObject = 0; 
      IsUnmovableobject = 1; 
      IsTool = 0; 
      IsDevice = 0; 
      IsDoor = 0; 
      IsPremium = 1; 
      MaxContSize = 0;
      Length = 3;  
      MaxStackSize = 1; 
      UnitWeight = 300000; 
      BackgrndImage = ""; 
      WorkAreaTop = 0;
      WorkAreaLeft = 0;
      WorkAreaWidth = 0;
      WorkAreaHeight = 0;
      BtnCloseTop = 0;
      BtnCloseLeft = 0;
      FaceImage = "yolauncher/modpack/mods/Jorvik2/art/2D/Recipes/horse.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod2::ObjectsTypesHorseeat() {
    return new ScriptObject(ObjectsTypesHorseeat : ObjectsTypes)
    {
      id = 2512; 
      ObjectName = "Horse (eat)"; 
      ParentID = 1637; 
      IsContainer = 0;
      IsMovableObject = 0; 
      IsUnmovableobject = 1; 
      IsTool = 0; 
      IsDevice = 0; 
      IsDoor = 0; 
      IsPremium = 1; 
      MaxContSize = 0;
      Length = 3;  
      MaxStackSize = 1; 
      UnitWeight = 300000; 
      BackgrndImage = ""; 
      WorkAreaTop = 0;
      WorkAreaLeft = 0;
      WorkAreaWidth = 0;
      WorkAreaHeight = 0;
      BtnCloseTop = 0;
      BtnCloseLeft = 0;
      FaceImage = "yolauncher/modpack/mods/Jorvik2/art/2D/Recipes/horse.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod2::ObjectsTypesHorsesleep() {
    return new ScriptObject(ObjectsTypesHorsesleep : ObjectsTypes)
    {
      id = 2513; 
      ObjectName = "Horse (sleep)"; 
      ParentID = 1637; 
      IsContainer = 0;
      IsMovableObject = 0; 
      IsUnmovableobject = 1; 
      IsTool = 0; 
      IsDevice = 0; 
      IsDoor = 0; 
      IsPremium = 1; 
      MaxContSize = 0;
      Length = 3;  
      MaxStackSize = 1; 
      UnitWeight = 300000; 
      BackgrndImage = ""; 
      WorkAreaTop = 0;
      WorkAreaLeft = 0;
      WorkAreaWidth = 0;
      WorkAreaHeight = 0;
      BtnCloseTop = 0;
      BtnCloseLeft = 0;
      FaceImage = "yolauncher/modpack/mods/Jorvik2/art/2D/Recipes/horse.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod2::ObjectsTypesSlaveworking() {
    return new ScriptObject(ObjectsTypesSlaveworking : ObjectsTypes)
    {
      id = 2514; 
      ObjectName = "Slave (working)"; 
      ParentID = 1637; 
      IsContainer = 0;
      IsMovableObject = 0; 
      IsUnmovableobject = 1; 
      IsTool = 0; 
      IsDevice = 0; 
      IsDoor = 0; 
      IsPremium = 1; 
      MaxContSize = 0;
      Length = 3;  
      MaxStackSize = 1; 
      UnitWeight = 300000; 
      BackgrndImage = ""; 
      WorkAreaTop = 0;
      WorkAreaLeft = 0;
      WorkAreaWidth = 0;
      WorkAreaHeight = 0;
      BtnCloseTop = 0;
      BtnCloseLeft = 0;
      FaceImage = "yolauncher/modpack/mods/Jorvik2/art/2D/Recipes/slave.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod2::ObjectsTypesWranentheHunterstand() {
    return new ScriptObject(ObjectsTypesWranentheHunterstand : ObjectsTypes)
    {
      id = 2515; 
      ObjectName = "Wranen the Hunter (stand)"; 
      ParentID = 1637; 
      IsContainer = 0;
      IsMovableObject = 0; 
      IsUnmovableobject = 1; 
      IsTool = 0; 
      IsDevice = 0; 
      IsDoor = 0; 
      IsPremium = 1; 
      MaxContSize = 0;
      Length = 3;  
      MaxStackSize = 1; 
      UnitWeight = 300000; 
      BackgrndImage = ""; 
      WorkAreaTop = 0;
      WorkAreaLeft = 0;
      WorkAreaWidth = 0;
      WorkAreaHeight = 0;
      BtnCloseTop = 0;
      BtnCloseLeft = 0;
      FaceImage = "yolauncher/modpack/mods/Jorvik2/art/2D/Recipes/wranen_the_hunter.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 1; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod2::ObjectsTypesBookPaper() {
    return new ScriptObject(ObjectsTypesBookPaper : ObjectsTypes)
    {
      id = 2516; 
      ObjectName = "Book Paper"; 
      ParentID = 7; 
      IsContainer = 0;
      IsMovableObject = 0; 
      IsUnmovableobject = 0; 
      IsTool = 0; 
      IsDevice = 0; 
      IsDoor = 0; 
      IsPremium = 0; 
      MaxContSize = 0;
      Length = 4;  
      MaxStackSize = 1000; 
      UnitWeight = 100; 
      BackgrndImage = ""; 
      WorkAreaTop = 0;
      WorkAreaLeft = 0;
      WorkAreaWidth = 0;
      WorkAreaHeight = 0;
      BtnCloseTop = 0;
      BtnCloseLeft = 0;
      FaceImage = "yolauncher/modpack/mods/Jorvik2/art/2D/Items/paper.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 100; 
      OwnerTimeout = NULL; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod2::ObjectsTypesHealthBook() {
    return new ScriptObject(ObjectsTypesHealthBook : ObjectsTypes)
    {
      id = 2517; 
      ObjectName = "Health Book"; 
      ParentID = 10; 
      IsContainer = 0;
      IsMovableObject = 0; 
      IsUnmovableobject = 0; 
      IsTool = 1; 
      IsDevice = 0; 
      IsDoor = 0; 
      IsPremium = 0; 
      MaxContSize = 0;
      Length = 3;  
      MaxStackSize = 1; 
      UnitWeight = 1000; 
      BackgrndImage = ""; 
      WorkAreaTop = 0;
      WorkAreaLeft = 0;
      WorkAreaWidth = 0;
      WorkAreaHeight = 0;
      BtnCloseTop = 0;
      BtnCloseLeft = 0;
      FaceImage = "yolauncher/modpack/mods/Jorvik2/art/2D/Items/health_book.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 9000; 
      OwnerTimeout = NULL; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod2::ObjectsTypesSmallThatchRoofInnerCorner() {
    return new ScriptObject(ObjectsTypesSmallThatchRoofInnerCorner : ObjectsTypes)
    {
      id = 2518; 
      ObjectName = "SmallThatchRoof Inner Corner"; 
      ParentID = 2473; 
      IsContainer = 0;
      IsMovableObject = 1; 
      IsUnmovableobject = 0; 
      IsTool = 0; 
      IsDevice = 0; 
      IsDoor = 0; 
      IsPremium = 0; 
      MaxContSize = 0;
      Length = 0;  
      MaxStackSize = 0; 
      UnitWeight = 10000; 
      BackgrndImage = ""; 
      WorkAreaTop = 0;
      WorkAreaLeft = 0;
      WorkAreaWidth = 0;
      WorkAreaHeight = 0;
      BtnCloseTop = 0;
      BtnCloseLeft = 0;
      FaceImage = "yolauncher/modpack/mods/Jorvik2/art/2D/Objects/small_thatch_roof_inner_corner.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod2::ObjectsTypesWoodCart() {
    return new ScriptObject(ObjectsTypesWoodCart : ObjectsTypes)
    {
      id = 2519; 
      ObjectName = "Wood Cart"; 
      ParentID = 77; 
      IsContainer = 1;
      IsMovableObject = 1; 
      IsUnmovableobject = 0; 
      IsTool = 0; 
      IsDevice = 0; 
      IsDoor = 0; 
      IsPremium = 0; 
      MaxContSize = 3000000;
      Length = 7;  
      MaxStackSize = 0; 
      UnitWeight = 10000; 
      BackgrndImage = "art/images/universal"; 
      WorkAreaTop = 0;
      WorkAreaLeft = 0;
      WorkAreaWidth = 0;
      WorkAreaHeight = 0;
      BtnCloseTop = 0;
      BtnCloseLeft = 0;
      FaceImage = "yolauncher/modpack/mods/Jorvik2/art/2D/Objects/wood_cart.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 135600; 
      OwnerTimeout = 30; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod2::ObjectsTypesSiegeTower() {
    return new ScriptObject(ObjectsTypesSiegeTower : ObjectsTypes)
    {
      id = 2520; 
      ObjectName = "Siege Tower"; 
      ParentID = 75; 
      IsContainer = 0;
      IsMovableObject = 1; 
      IsUnmovableobject = 0; 
      IsTool = 0; 
      IsDevice = 0; 
      IsDoor = 1; 
      IsPremium = 0; 
      MaxContSize = 0;
      Length = 7;  
      MaxStackSize = 0; 
      UnitWeight = 100000; 
      BackgrndImage = "art/images/universal"; 
      WorkAreaTop = 0;
      WorkAreaLeft = 0;
      WorkAreaWidth = 0;
      WorkAreaHeight = 0;
      BtnCloseTop = 0;
      BtnCloseLeft = 0;
      FaceImage = "yolauncher/modpack/mods/Jorvik2/art/2D/Objects/siegetower.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 135600; 
      OwnerTimeout = 30; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod2::ObjectsTypesAurochsBullstand() {
    return new ScriptObject(ObjectsTypesAurochsBullstand : ObjectsTypes)
    {
      id = 2521; 
      ObjectName = "Aurochs Bull (stand)"; 
      ParentID = 1637; 
      IsContainer = 0;
      IsMovableObject = 0; 
      IsUnmovableobject = 1; 
      IsTool = 0; 
      IsDevice = 0; 
      IsDoor = 0; 
      IsPremium = 1; 
      MaxContSize = 0;
      Length = 3;  
      MaxStackSize = 0; 
      UnitWeight = 400000; 
      BackgrndImage = ""; 
      WorkAreaTop = 0;
      WorkAreaLeft = 0;
      WorkAreaWidth = 0;
      WorkAreaHeight = 0;
      BtnCloseTop = 0;
      BtnCloseLeft = 0;
      FaceImage = "yolauncher/modpack/mods/Jorvik2/art/2D/Recipes/aurochs_bull.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod2::ObjectsTypesAurochsBulleat() {
    return new ScriptObject(ObjectsTypesAurochsBulleat : ObjectsTypes)
    {
      id = 2522; 
      ObjectName = "Aurochs Bull (eat)"; 
      ParentID = 1637; 
      IsContainer = 0;
      IsMovableObject = 0; 
      IsUnmovableobject = 1; 
      IsTool = 0; 
      IsDevice = 0; 
      IsDoor = 0; 
      IsPremium = 1; 
      MaxContSize = 0;
      Length = 3;  
      MaxStackSize = 0; 
      UnitWeight = 400000; 
      BackgrndImage = ""; 
      WorkAreaTop = 0;
      WorkAreaLeft = 0;
      WorkAreaWidth = 0;
      WorkAreaHeight = 0;
      BtnCloseTop = 0;
      BtnCloseLeft = 0;
      FaceImage = "yolauncher/modpack/mods/Jorvik2/art/2D/Recipes/aurochs_bull.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod2::ObjectsTypesAurochsBullsleep() {
    return new ScriptObject(ObjectsTypesAurochsBullsleep : ObjectsTypes)
    {
      id = 2523; 
      ObjectName = "Aurochs Bull (sleep)"; 
      ParentID = 1637; 
      IsContainer = 0;
      IsMovableObject = 0; 
      IsUnmovableobject = 1; 
      IsTool = 0; 
      IsDevice = 0; 
      IsDoor = 0; 
      IsPremium = 1; 
      MaxContSize = 0;
      Length = 3;  
      MaxStackSize = 0; 
      UnitWeight = 400000; 
      BackgrndImage = ""; 
      WorkAreaTop = 0;
      WorkAreaLeft = 0;
      WorkAreaWidth = 0;
      WorkAreaHeight = 0;
      BtnCloseTop = 0;
      BtnCloseLeft = 0;
      FaceImage = "yolauncher/modpack/mods/Jorvik2/art/2D/Recipes/aurochs_bull.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod2::ObjectsTypesSmallWoodenPier() {
    return new ScriptObject(ObjectsTypesSmallWoodenPier : ObjectsTypes)
    {
      id = 2524; 
      ObjectName = "Small Wooden Pier"; 
      ParentID = 61; 
      IsContainer = 0;
      IsMovableObject = 0; 
      IsUnmovableobject = 1; 
      IsTool = 0; 
      IsDevice = 0; 
      IsDoor = 0; 
      IsPremium = 0; 
      MaxContSize = 0;
      Length = 0;  
      MaxStackSize = 0; 
      UnitWeight = 100000; 
      BackgrndImage = ""; 
      WorkAreaTop = 0;
      WorkAreaLeft = 0;
      WorkAreaWidth = 0;
      WorkAreaHeight = 0;
      BtnCloseTop = 0;
      BtnCloseLeft = 0;
      FaceImage = "yolauncher/modpack/mods/Jorvik2/art/2D/Recipes/small_wooden_pier.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod2::ObjectsTypesSmallWoodenPierT() {
    return new ScriptObject(ObjectsTypesSmallWoodenPierT : ObjectsTypes)
    {
      id = 2525; 
      ObjectName = "Small Wooden Pier T"; 
      ParentID = 61; 
      IsContainer = 0;
      IsMovableObject = 0; 
      IsUnmovableobject = 1; 
      IsTool = 0; 
      IsDevice = 0; 
      IsDoor = 0; 
      IsPremium = 0; 
      MaxContSize = 0;
      Length = 0;  
      MaxStackSize = 0; 
      UnitWeight = 100000; 
      BackgrndImage = ""; 
      WorkAreaTop = 0;
      WorkAreaLeft = 0;
      WorkAreaWidth = 0;
      WorkAreaHeight = 0;
      BtnCloseTop = 0;
      BtnCloseLeft = 0;
      FaceImage = "yolauncher/modpack/mods/Jorvik2/art/2D/Recipes/small_wooden_pier_T.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod2::ObjectsTypesSmallWoodenPierL() {
    return new ScriptObject(ObjectsTypesSmallWoodenPierL : ObjectsTypes)
    {
      id = 2526; 
      ObjectName = "Small Wooden Pier L"; 
      ParentID = 61; 
      IsContainer = 0;
      IsMovableObject = 0; 
      IsUnmovableobject = 1; 
      IsTool = 0; 
      IsDevice = 0; 
      IsDoor = 0; 
      IsPremium = 0; 
      MaxContSize = 0;
      Length = 0;  
      MaxStackSize = 0; 
      UnitWeight = 100000; 
      BackgrndImage = ""; 
      WorkAreaTop = 0;
      WorkAreaLeft = 0;
      WorkAreaWidth = 0;
      WorkAreaHeight = 0;
      BtnCloseTop = 0;
      BtnCloseLeft = 0;
      FaceImage = "yolauncher/modpack/mods/Jorvik2/art/2D/Recipes/small_wooden_pier_L.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod2::ObjectsTypesWattleWicket() {
    return new ScriptObject(ObjectsTypesWattleWicket : ObjectsTypes)
    {
      id = 2527; 
      ObjectName = "Wattle Wicket"; 
      ParentID = 66; 
      IsContainer = 0;
      IsMovableObject = 0; 
      IsUnmovableobject = 1; 
      IsTool = 0; 
      IsDevice = 0; 
      IsDoor = 1; 
      IsPremium = 0; 
      MaxContSize = 0;
      Length = 0;  
      MaxStackSize = 0; 
      UnitWeight = 5000; 
      BackgrndImage = ""; 
      WorkAreaTop = 0;
      WorkAreaLeft = 0;
      WorkAreaWidth = 0;
      WorkAreaHeight = 0;
      BtnCloseTop = 0;
      BtnCloseLeft = 0;
      FaceImage = "yolauncher/modpack/mods/Jorvik2/art/2D/Recipes/wattle_wicket.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 3100; 
      OwnerTimeout = 86400; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod2::ObjectsTypesIdolCross() {
    return new ScriptObject(ObjectsTypesIdolCross : ObjectsTypes)
    {
      id = 2528; 
      ObjectName = "Idol Cross"; 
      ParentID = 1722; 
      IsContainer = 0;
      IsMovableObject = 0; 
      IsUnmovableobject = 1; 
      IsTool = 0; 
      IsDevice = 0; 
      IsDoor = 0; 
      IsPremium = 0; 
      MaxContSize = 0;
      Length = 0;  
      MaxStackSize = 0; 
      UnitWeight = 5000; 
      BackgrndImage = ""; 
      WorkAreaTop = 0;
      WorkAreaLeft = 0;
      WorkAreaWidth = 0;
      WorkAreaHeight = 0;
      BtnCloseTop = 0;
      BtnCloseLeft = 0;
      FaceImage = "yolauncher/modpack/mods/Jorvik2/art/2D/Recipes/idol_cross.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 1; 
      OwnerTimeout = NULL; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod2::ObjectsTypesWoodenChurch() {
    return new ScriptObject(ObjectsTypesWoodenChurch : ObjectsTypes)
    {
      id = 2529; 
      ObjectName = "Wooden Church"; 
      ParentID = 72; 
      IsContainer = 0;
      IsMovableObject = 0; 
      IsUnmovableobject = 1; 
      IsTool = 0; 
      IsDevice = 0; 
      IsDoor = 1; 
      IsPremium = 0; 
      MaxContSize = 0;
      Length = 4;  
      MaxStackSize = 0; 
      UnitWeight = 2000000; 
      BackgrndImage = ""; 
      WorkAreaTop = 0;
      WorkAreaLeft = 0;
      WorkAreaWidth = 0;
      WorkAreaHeight = 0;
      BtnCloseTop = 0;
      BtnCloseLeft = 0;
      FaceImage = "yolauncher/modpack/mods/Jorvik2/art/2D/Recipes/wooden_church.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 2400; 
      OwnerTimeout = 120; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod2::ObjectsTypesSanctumoftheSleeper() {
    return new ScriptObject(ObjectsTypesSanctumoftheSleeper : ObjectsTypes)
    {
      id = 2485; 
      ObjectName = "Sanctum of the Sleeper"; 
      ParentID = 72; 
      IsContainer = 0;
      IsMovableObject = 0; 
      IsUnmovableobject = 1; 
      IsTool = 0; 
      IsDevice = 0; 
      IsDoor = 1; 
      IsPremium = 0; 
      MaxContSize = 0;
      Length = 10;  
      MaxStackSize = 0; 
      UnitWeight = 4000000; 
      BackgrndImage = ""; 
      WorkAreaTop = 0;
      WorkAreaLeft = 0;
      WorkAreaWidth = 0;
      WorkAreaHeight = 0;
      BtnCloseTop = 0;
      BtnCloseLeft = 0;
      FaceImage = "yolauncher/modpack/mods/Jorvik2/art/2D/Recipes/church.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 2400; 
      OwnerTimeout = 120; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod2::ObjectsTypesNoviceDecoratorKit() {
    return new ScriptObject(ObjectsTypesNoviceDecoratorKit : ObjectsTypes)
    {
      id = 2531; 
      ObjectName = "Novice Decorator Kit"; 
      ParentID = 7; 
      IsContainer = 0;
      IsMovableObject = 0; 
      IsUnmovableobject = 0; 
      IsTool = 0; 
      IsDevice = 0; 
      IsDoor = 0; 
      IsPremium = 0; 
      MaxContSize = 0;
      Length = 4;  
      MaxStackSize = 10000; 
      UnitWeight = 10000; 
      BackgrndImage = ""; 
      WorkAreaTop = 0;
      WorkAreaLeft = 0;
      WorkAreaWidth = 0;
      WorkAreaHeight = 0;
      BtnCloseTop = 0;
      BtnCloseLeft = 0;
      FaceImage = "yolauncher/modpack/mods/Jorvik2/art/2D/Items/decoration_kit_small.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 100; 
      OwnerTimeout = NULL; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod2::ObjectsTypesApprenticeDecoratorKit() {
    return new ScriptObject(ObjectsTypesApprenticeDecoratorKit : ObjectsTypes)
    {
      id = 2532; 
      ObjectName = "Apprentice Decorator Kit"; 
      ParentID = 7; 
      IsContainer = 0;
      IsMovableObject = 0; 
      IsUnmovableobject = 0; 
      IsTool = 0; 
      IsDevice = 0; 
      IsDoor = 0; 
      IsPremium = 0; 
      MaxContSize = 0;
      Length = 4;  
      MaxStackSize = 10000; 
      UnitWeight = 20000; 
      BackgrndImage = ""; 
      WorkAreaTop = 0;
      WorkAreaLeft = 0;
      WorkAreaWidth = 0;
      WorkAreaHeight = 0;
      BtnCloseTop = 0;
      BtnCloseLeft = 0;
      FaceImage = "yolauncher/modpack/mods/Jorvik2/art/2D/Items/decoration_kit_medium.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 100; 
      OwnerTimeout = NULL; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod2::ObjectsTypesMasterDecoratorKit() {
    return new ScriptObject(ObjectsTypesMasterDecoratorKit : ObjectsTypes)
    {
      id = 2533; 
      ObjectName = "Master Decorator Kit"; 
      ParentID = 7; 
      IsContainer = 0;
      IsMovableObject = 0; 
      IsUnmovableobject = 0; 
      IsTool = 0; 
      IsDevice = 0; 
      IsDoor = 0; 
      IsPremium = 0; 
      MaxContSize = 0;
      Length = 4;  
      MaxStackSize = 10000; 
      UnitWeight = 30000; 
      BackgrndImage = ""; 
      WorkAreaTop = 0;
      WorkAreaLeft = 0;
      WorkAreaWidth = 0;
      WorkAreaHeight = 0;
      BtnCloseTop = 0;
      BtnCloseLeft = 0;
      FaceImage = "yolauncher/modpack/mods/Jorvik2/art/2D/Items/decoration_kit_large.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 100; 
      OwnerTimeout = NULL; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod2::ObjectsTypesWolfstand() {
    return new ScriptObject(ObjectsTypesWolfstand : ObjectsTypes)
    {
      id = 2534; 
      ObjectName = "Wolf (stand)"; 
      ParentID = 1637; 
      IsContainer = 0;
      IsMovableObject = 0; 
      IsUnmovableobject = 1; 
      IsTool = 0; 
      IsDevice = 0; 
      IsDoor = 0; 
      IsPremium = 1; 
      MaxContSize = 0;
      Length = 3;  
      MaxStackSize = 0; 
      UnitWeight = 100000; 
      BackgrndImage = ""; 
      WorkAreaTop = 0;
      WorkAreaLeft = 0;
      WorkAreaWidth = 0;
      WorkAreaHeight = 0;
      BtnCloseTop = 0;
      BtnCloseLeft = 0;
      FaceImage = "yolauncher/modpack/mods/Jorvik2/art/2D/Recipes/wolf.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod2::ObjectsTypesGoldSheet() {
    return new ScriptObject(ObjectsTypesGoldSheet : ObjectsTypes)
    {
      id = 2535; 
      ObjectName = "Gold Sheet"; 
      ParentID = 213; 
      IsContainer = 0;
      IsMovableObject = 0; 
      IsUnmovableobject = 0; 
      IsTool = 0; 
      IsDevice = 0; 
      IsDoor = 0; 
      IsPremium = 0; 
      MaxContSize = 0;
      Length = 3;  
      MaxStackSize = 10000; 
      UnitWeight = 10000; 
      BackgrndImage = ""; 
      WorkAreaTop = 0;
      WorkAreaLeft = 0;
      WorkAreaWidth = 0;
      WorkAreaHeight = 0;
      BtnCloseTop = 0;
      BtnCloseLeft = 0;
      FaceImage = "yolauncher/modpack/mods/Jorvik2/art/2D/Items/gold_sheet.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 9000; 
      OwnerTimeout = NULL; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod2::ObjectsTypesMetalScissors() {
    return new ScriptObject(ObjectsTypesMetalScissors : ObjectsTypes)
    {
      id = 2536; 
      ObjectName = "Metal Scissors"; 
      ParentID = 10; 
      IsContainer = 0;
      IsMovableObject = 0; 
      IsUnmovableobject = 0; 
      IsTool = 1; 
      IsDevice = 0; 
      IsDoor = 0; 
      IsPremium = 0; 
      MaxContSize = 0;
      Length = 3;  
      MaxStackSize = 1; 
      UnitWeight = 1000; 
      BackgrndImage = ""; 
      WorkAreaTop = 0;
      WorkAreaLeft = 0;
      WorkAreaWidth = 0;
      WorkAreaHeight = 0;
      BtnCloseTop = 0;
      BtnCloseLeft = 0;
      FaceImage = "yolauncher/modpack/mods/Jorvik2/art/2D/Items/scissors.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 9000; 
      OwnerTimeout = NULL; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod2::ObjectsTypesMetalStamp() {
    return new ScriptObject(ObjectsTypesMetalStamp : ObjectsTypes)
    {
      id = 2537; 
      ObjectName = "Metal Stamp"; 
      ParentID = 10; 
      IsContainer = 0;
      IsMovableObject = 0; 
      IsUnmovableobject = 0; 
      IsTool = 1; 
      IsDevice = 0; 
      IsDoor = 0; 
      IsPremium = 0; 
      MaxContSize = 0;
      Length = 3;  
      MaxStackSize = 1; 
      UnitWeight = 1000; 
      BackgrndImage = ""; 
      WorkAreaTop = 0;
      WorkAreaLeft = 0;
      WorkAreaWidth = 0;
      WorkAreaHeight = 0;
      BtnCloseTop = 0;
      BtnCloseLeft = 0;
      FaceImage = "yolauncher/modpack/mods/Jorvik2/art/2D/Items/metal_stamp.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 9000; 
      OwnerTimeout = NULL; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod2::ObjectsTypesGoldBlanks() {
    return new ScriptObject(ObjectsTypesGoldBlanks : ObjectsTypes)
    {
      id = 2538; 
      ObjectName = "Gold Blanks"; 
      ParentID = 213; 
      IsContainer = 0;
      IsMovableObject = 0; 
      IsUnmovableobject = 0; 
      IsTool = 0; 
      IsDevice = 0; 
      IsDoor = 0; 
      IsPremium = 0; 
      MaxContSize = 0;
      Length = 3;  
      MaxStackSize = 10000; 
      UnitWeight = 1000; 
      BackgrndImage = ""; 
      WorkAreaTop = 0;
      WorkAreaLeft = 0;
      WorkAreaWidth = 0;
      WorkAreaHeight = 0;
      BtnCloseTop = 0;
      BtnCloseLeft = 0;
      FaceImage = "yolauncher/modpack/mods/Jorvik2/art/2D/Items/gold_blanks.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 9000; 
      OwnerTimeout = NULL; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod2::ObjectsTypesSilverSheet() {
    return new ScriptObject(ObjectsTypesSilverSheet : ObjectsTypes)
    {
      id = 2539; 
      ObjectName = "Silver Sheet"; 
      ParentID = 213; 
      IsContainer = 0;
      IsMovableObject = 0; 
      IsUnmovableobject = 0; 
      IsTool = 0; 
      IsDevice = 0; 
      IsDoor = 0; 
      IsPremium = 0; 
      MaxContSize = 0;
      Length = 3;  
      MaxStackSize = 10000; 
      UnitWeight = 10000; 
      BackgrndImage = ""; 
      WorkAreaTop = 0;
      WorkAreaLeft = 0;
      WorkAreaWidth = 0;
      WorkAreaHeight = 0;
      BtnCloseTop = 0;
      BtnCloseLeft = 0;
      FaceImage = "yolauncher/modpack/mods/Jorvik2/art/2D/Items/silver_sheet.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 9000; 
      OwnerTimeout = NULL; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod2::ObjectsTypesCopperSheet() {
    return new ScriptObject(ObjectsTypesCopperSheet : ObjectsTypes)
    {
      id = 2540; 
      ObjectName = "Copper Sheet"; 
      ParentID = 213; 
      IsContainer = 0;
      IsMovableObject = 0; 
      IsUnmovableobject = 0; 
      IsTool = 0; 
      IsDevice = 0; 
      IsDoor = 0; 
      IsPremium = 0; 
      MaxContSize = 0;
      Length = 3;  
      MaxStackSize = 10000; 
      UnitWeight = 10000; 
      BackgrndImage = ""; 
      WorkAreaTop = 0;
      WorkAreaLeft = 0;
      WorkAreaWidth = 0;
      WorkAreaHeight = 0;
      BtnCloseTop = 0;
      BtnCloseLeft = 0;
      FaceImage = "yolauncher/modpack/mods/Jorvik2/art/2D/Items/copper_sheet.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 9000; 
      OwnerTimeout = NULL; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod2::ObjectsTypesSilverBlanks() {
    return new ScriptObject(ObjectsTypesSilverBlanks : ObjectsTypes)
    {
      id = 2541; 
      ObjectName = "Silver Blanks"; 
      ParentID = 213; 
      IsContainer = 0;
      IsMovableObject = 0; 
      IsUnmovableobject = 0; 
      IsTool = 0; 
      IsDevice = 0; 
      IsDoor = 0; 
      IsPremium = 0; 
      MaxContSize = 0;
      Length = 3;  
      MaxStackSize = 10000; 
      UnitWeight = 1000; 
      BackgrndImage = ""; 
      WorkAreaTop = 0;
      WorkAreaLeft = 0;
      WorkAreaWidth = 0;
      WorkAreaHeight = 0;
      BtnCloseTop = 0;
      BtnCloseLeft = 0;
      FaceImage = "yolauncher/modpack/mods/Jorvik2/art/2D/Items/silver_blanks.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 9000; 
      OwnerTimeout = NULL; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod2::ObjectsTypesCopperBlanks() {
    return new ScriptObject(ObjectsTypesCopperBlanks : ObjectsTypes)
    {
      id = 2542; 
      ObjectName = "Copper Blanks"; 
      ParentID = 213; 
      IsContainer = 0;
      IsMovableObject = 0; 
      IsUnmovableobject = 0; 
      IsTool = 0; 
      IsDevice = 0; 
      IsDoor = 0; 
      IsPremium = 0; 
      MaxContSize = 0;
      Length = 3;  
      MaxStackSize = 10000; 
      UnitWeight = 1000; 
      BackgrndImage = ""; 
      WorkAreaTop = 0;
      WorkAreaLeft = 0;
      WorkAreaWidth = 0;
      WorkAreaHeight = 0;
      BtnCloseTop = 0;
      BtnCloseLeft = 0;
      FaceImage = "yolauncher/modpack/mods/Jorvik2/art/2D/Items/silver_blanks.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 9000; 
      OwnerTimeout = NULL; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod2::LargeWoodenBridge() {
    dbi.Select(JorvikMod2, "LargeWoodenBridgeRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Large Wooden Bridge', 'Object from Jorvik MOD',        32,               18,          60,        2457,               10,                       1,        0,          0,           'yolauncher/modpack/mods/Jorvik2/art/2D/Recipes/large_wooden_bridge.png') RETURNING ID");
  }
  function JorvikMod2::LargeWoodenBridgeRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  1356,                  0,       10,         15,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  233,                  0,       20,         12,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  235,                  0,       10,         50,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  281,                  0,       10,         60,       0)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }  function JorvikMod2::LargeStoneBridge() {
    dbi.Select(JorvikMod2, "LargeStoneBridgeRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Large Stone Bridge', 'Object from Jorvik MOD',        32,               19,          60,        2458,               35,                       1,        0,          0,           'yolauncher/modpack/mods/Jorvik2/art/2D/Recipes/large_stone_bridge.png') RETURNING ID");
  }
  function JorvikMod2::LargeStoneBridgeRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  269,                  0,       40,         200,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  244,                  0,       10,         1200,       0)");
	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }  function JorvikMod2::LargeStoneBridgeEnd() {
    dbi.Select(JorvikMod2, "LargeStoneBridgeEndRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Large Stone Bridge End', 'Object from Jorvik MOD',        32,               19,          60,        2459,               35,                       1,        0,          0,           'yolauncher/modpack/mods/Jorvik2/art/2D/Recipes/large_stone_bridge_end.png') RETURNING ID");
  }
  function JorvikMod2::LargeStoneBridgeEndRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  269,                  0,       40,         100,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  244,                  0,       10,         600,       0)");
	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }  function JorvikMod2::SmallStoneBridgeEnd() {
    dbi.Select(JorvikMod2, "SmallStoneBridgeEndRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Stone Bridge End', 'Object from Jorvik MOD',        32,               19,          60,        2460,               35,                       1,        0,          0,           'yolauncher/modpack/mods/Jorvik2/art/2D/Recipes/small_stone_bridge_end.png') RETURNING ID");
  }
  function JorvikMod2::SmallStoneBridgeEndRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  269,                  0,       40,         50,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  244,                  0,       10,         300,       0)");
	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }
  function JorvikMod2::SmallLogWall() {
    dbi.Select(JorvikMod2, "SmallLogWallRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Log Wall', 'Object from Jorvik MOD',        32,               18,          30,        2561,               35,                       1,        0,          0,           'yolauncher/modpack/mods/Jorvik2/art/2D/Recipes/small_log_wall.png') RETURNING ID");
  }
  function JorvikMod2::SmallLogWallRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  233,                  0,       10,         2,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  234,                  0,       10,         15,       0)");
	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }
  function JorvikMod2::SmallWoodenPillar() {
    dbi.Select(JorvikMod2, "SmallWoodenPillarRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Wooden Pillar', 'Object from Jorvik MOD',        32,               18,          30,        2562,               35,                       1,        0,          0,           'yolauncher/modpack/mods/Jorvik2/art/2D/Recipes/small_wooden_pillar.png') RETURNING ID");
  }
  function JorvikMod2::SmallWoodenPillarRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  233,                  0,       10,         1,       0)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }
  function JorvikMod2::SmallLogCornerWall() {
    dbi.Select(JorvikMod2, "SmallLogCornerWallRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Log Corner Wall', 'Object from Jorvik MOD',        32,               18,          30,        2563,               35,                       1,        0,          0,           'yolauncher/modpack/mods/Jorvik2/art/2D/Recipes/small_log_corner_wall.png') RETURNING ID");
  }
  function JorvikMod2::SmallLogCornerWallRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  233,                  0,       10,         2,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  234,                  0,       10,         30,       0)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }
  function JorvikMod2::SmallLogWallWithWindow() {
    dbi.Select(JorvikMod2, "SmallLogWallWithWindowRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Log Wall With Window', 'Object from Jorvik MOD',        32,               18,          30,        2564,               35,                       1,        0,          0,           'yolauncher/modpack/mods/Jorvik2/art/2D/Recipes/small_log_wall_with_window.png') RETURNING ID");
  }
  function JorvikMod2::SmallLogWallWithWindowRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  233,                  0,       10,         2,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  234,                  0,       10,         12,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  235,                  0,       10,         4,       0)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }
  function JorvikMod2::SmallLogWallWithShutters() {
    dbi.Select(JorvikMod2, "SmallLogWallWithShuttersRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Log Wall With Shutters', 'Object from Jorvik MOD',        32,               18,          30,        2565,               35,                       1,        0,          0,           'yolauncher/modpack/mods/Jorvik2/art/2D/Recipes/small_log_wall_with_shutters.png') RETURNING ID");
  }
  function JorvikMod2::SmallLogWallWithShuttersRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  233,                  0,       10,         2,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  1356,                  0,       10,         4,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  234,                  0,       10,         12,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  288,                  0,       10,         1,       0)");
 
	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }
  function JorvikMod2::SmallLogWallWithEntrance() {
    dbi.Select(JorvikMod2, "SmallLogWallWithEntranceRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Log Wall With Entrance', 'Object from Jorvik MOD',        32,               18,          30,        2566,               35,                       1,        0,          0,           'yolauncher/modpack/mods/Jorvik2/art/2D/Recipes/small_log_wall_with_entrance.png') RETURNING ID");
  }
  function JorvikMod2::SmallLogWallWithEntranceRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  233,                  0,       10,         4,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  1356,                  0,       10,         4,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  234,                  0,       10,         8,       0)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }
  function JorvikMod2::SmallLogWallWithDoor() {
    dbi.Select(JorvikMod2, "SmallLogWallWithDoorRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Log Wall With Door', 'Object from Jorvik MOD',        32,               18,          30,        2567,               35,                       1,        0,          0,           'yolauncher/modpack/mods/Jorvik2/art/2D/Recipes/small_log_wall_with_door.png') RETURNING ID");
  }
  function JorvikMod2::SmallLogWallWithDoorRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  233,                  0,       10,         4,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  1356,                  0,       10,         10,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  234,                  0,       10,         8,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  286,                  0,       10,         1,       1)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }
  function JorvikMod2::SmallWoodenFloorEntrance() {
    dbi.Select(JorvikMod2, "SmallWoodenFloorEntranceRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Wooden Floor Entrance', 'Object from Jorvik MOD',        32,               18,          30,        2568,               35,                       1,        0,          0,           'yolauncher/modpack/mods/Jorvik2/art/2D/Recipes/small_wooden_floor_entrance.png') RETURNING ID");
  }
  function JorvikMod2::SmallWoodenFloorEntranceRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  235,                  0,       10,         8,       0)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }
  function JorvikMod2::SmallWoodenFloor() {
    dbi.Select(JorvikMod2, "SmallWoodenFloorRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Wooden Floor', 'Object from Jorvik MOD',        32,               18,          30,        2569,               35,                       1,        0,          0,           'yolauncher/modpack/mods/Jorvik2/art/2D/Recipes/small_wooden_floor.png') RETURNING ID");
  }
  function JorvikMod2::SmallWoodenFloorRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  235,                  0,       10,         5,       0)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }
  function JorvikMod2::SmallLogWallSlopeRight() {
    dbi.Select(JorvikMod2, "SmallLogWallSlopeRightRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Log Wall Slope Right', 'Object from Jorvik MOD',        32,               18,          30,        2474,               35,                       1,        0,          0,           'yolauncher/modpack/mods/Jorvik2/art/2D/Recipes/small_log_wall_slope_right.png') RETURNING ID");
  }
  function JorvikMod2::SmallLogWallSlopeRightRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  234,                  0,       10,         5,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  233,                  0,       10,         2,       0)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }
  function JorvikMod2::SmallLogWallSlopeLeft() {
    dbi.Select(JorvikMod2, "SmallLogWallSlopeLeftRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Log Wall Slope Left', 'Object from Jorvik MOD',        32,               18,          30,        2475,               35,                       1,        0,          0,           'yolauncher/modpack/mods/Jorvik2/art/2D/Recipes/small_log_wall_slope_left.png') RETURNING ID");
  }
  function JorvikMod2::SmallLogWallSlopeLeftRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  234,                  0,       10,         5,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  233,                  0,       10,         2,       0)");
 
	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }
  function JorvikMod2::SmallThatchRoof() {
    dbi.Select(JorvikMod2, "SmallThatchRoofRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'SmallThatchRoof', 'Object from Jorvik MOD',        32,               18,          30,        2476,               35,                       1,        0,          0,           'yolauncher/modpack/mods/Jorvik2/art/2D/Recipes/small_thatch_roof.png') RETURNING ID");
  }
  function JorvikMod2::SmallThatchRoofRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  233,                  0,       10,         1,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  234,                  0,       10,         2,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  362,                  0,       10,         5,       0)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }
  function JorvikMod2::SmallThatchRoofRightEnd() {
    dbi.Select(JorvikMod2, "SmallThatchRoofRightEndRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'SmallThatchRoofRightEnd', 'Object from Jorvik MOD',        32,               18,          30,        2477,               35,                       1,        0,          0,           'yolauncher/modpack/mods/Jorvik2/art/2D/Recipes/small_thatch_roof_right_end.png') RETURNING ID");
  }
  function JorvikMod2::SmallThatchRoofRightEndRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  233,                  0,       10,         1,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  234,                  0,       10,         2,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  362,                  0,       10,         5,       0)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }
  function JorvikMod2::SmallThatchRoofLeftEnd() {
    dbi.Select(JorvikMod2, "SmallThatchRoofLeftEndRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'SmallThatchRoofLeftEnd', 'Object from Jorvik MOD',        32,               18,          30,        2478,               35,                       1,        0,          0,           'yolauncher/modpack/mods/Jorvik2/art/2D/Recipes/small_thatch_roof_left_end.png') RETURNING ID");
  }
  function JorvikMod2::SmallThatchRoofLeftEndRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  233,                  0,       10,         1,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  234,                  0,       10,         2,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  362,                  0,       10,         5,       0)");
 
	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }
  function JorvikMod2::SmallThatchRoofOuterCorner() {
    dbi.Select(JorvikMod2, "SmallThatchRoofOuterCornerRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'SmallThatchRoofOuterCorner', 'Object from Jorvik MOD',        32,               18,          30,        2479,               35,                       1,        0,          0,           'yolauncher/modpack/mods/Jorvik2/art/2D/Recipes/small_thatch_roof_outer_corner.png') RETURNING ID");
  }
  function JorvikMod2::SmallThatchRoofOuterCornerRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  233,                  0,       10,         1,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  234,                  0,       10,         2,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  362,                  0,       10,         10,       0)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }  function JorvikMod2::SmallLogWalllvl1() {
    dbi.Select(JorvikMod2, "SmallLogWalllvl1Requirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Log Wall', 'Object from Jorvik MOD',        32,               18,          30,        2481,               35,                       1,        0,          0,           'yolauncher/modpack/mods/Jorvik2/art/2D/Recipes/small_log_wall_lvl1.png') RETURNING ID");
  }
  function JorvikMod2::SmallLogWalllvl1Requirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  233,                  0,       10,         2,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  234,                  0,       10,         15,       0)");
	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }
  function JorvikMod2::SmallWoodenPillarlvl1() {
    dbi.Select(JorvikMod2, "SmallWoodenPillarlvl1Requirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Wooden Pillar', 'Object from Jorvik MOD',        32,               18,          30,        2482,               35,                       1,        0,          0,           'yolauncher/modpack/mods/Jorvik2/art/2D/Recipes/small_wooden_pillar_lvl1.png') RETURNING ID");
  }
  function JorvikMod2::SmallWoodenPillarlvl1Requirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  233,                  0,       10,         1,       0)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	  
  function JorvikMod2::SmallLogCornerWalllvl1() {
    dbi.Select(JorvikMod2, "SmallLogCornerWallRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Log Corner Wall', 'Object from Jorvik MOD',        32,               18,          30,        2483,               35,                       1,        0,          0,           'yolauncher/modpack/mods/Jorvik2/art/2D/Recipes/small_log_corner_wall_lvl1.png') RETURNING ID");
  }
  function JorvikMod2::SmallLogCornerWalllvl1Requirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  233,                  0,       10,         2,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  234,                  0,       10,         30,       0)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	  
  function JorvikMod2::SmallLogWallWithWindowlvl1() {
    dbi.Select(JorvikMod2, "SmallLogWallWithWindowlvl1Requirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Log Wall With Window', 'Object from Jorvik MOD',        32,               18,          30,        2484,               35,                       1,        0,          0,           'yolauncher/modpack/mods/Jorvik2/art/2D/Recipes/small_log_wall_with_window_lvl1.png') RETURNING ID");
  }
  function JorvikMod2::SmallLogWallWithWindowlvl1Requirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  233,                  0,       10,         2,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  234,                  0,       10,         12,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  235,                  0,       10,         4,       0)");
 
	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod2::SmallLogWallWithShutterslvl1() {
    dbi.Select(JorvikMod2, "SmallLogWallWithShutterslvl1Requirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Log Wall With Shutters', 'Object from Jorvik MOD',        32,               18,          30,        2544,               35,                       1,        0,          0,           'yolauncher/modpack/mods/Jorvik2/art/2D/Recipes/small_log_wall_with_shutters_lvl1.png') RETURNING ID");
  }
  function JorvikMod2::SmallLogWallWithShutterslvl1Requirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  233,                  0,       10,         2,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  1356,                  0,       10,         4,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  234,                  0,       10,         12,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  288,                  0,       10,         1,       0)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod2::SmallLogWallWithEntrancelvl1() {
    dbi.Select(JorvikMod2, "SmallLogWallWithEntrancelvl1Requirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Log Wall With Entrance', 'Object from Jorvik MOD',        32,               18,          30,        2545,               35,                       1,        0,          0,           'yolauncher/modpack/mods/Jorvik2/art/2D/Recipes/small_log_wall_with_entrance_lvl1.png') RETURNING ID");
  }
  function JorvikMod2::SmallLogWallWithEntrancelvl1Requirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  233,                  0,       10,         4,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  1356,                  0,       10,         4,       0)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod2::SmallLogWallWithDoorlvl1() {
    dbi.Select(JorvikMod2, "SmallLogWallWithDoorlvl1Requirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Log Wall With Door', 'Object from Jorvik MOD',        32,               18,          30,        2546,               35,                       1,        0,          0,           'yolauncher/modpack/mods/Jorvik2/art/2D/Recipes/small_log_wall_with_door_lvl1.png') RETURNING ID");
  }
  function JorvikMod2::SmallLogWallWithDoorlvl1Requirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  233,                  0,       10,         4,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  1356,                  0,       10,         10,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  234,                  0,       10,         8,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  286,                  0,       10,         1,       1)");
 
	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod2::SmallWoodenFloorEntrancelvl1() {
    dbi.Select(JorvikMod2, "SmallWoodenFloorEntranceRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Wooden Floor Entrance', 'Object from Jorvik MOD',        32,               18,          30,        2547,               35,                       1,        0,          0,           'yolauncher/modpack/mods/Jorvik2/art/2D/Recipes/small_wooden_floor_entrance_lvl1.png') RETURNING ID");
  }
  function JorvikMod2::SmallWoodenFloorEntrancelvl1Requirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  235,                  0,       10,         8,       0)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod2::SmallWoodenFloorlvl1() {
    dbi.Select(JorvikMod2, "SmallWoodenFloorlvl1Requirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Wooden Floor', 'Object from Jorvik MOD',        32,               18,          30,        2548,               35,                       1,        0,          0,           'yolauncher/modpack/mods/Jorvik2/art/2D/Recipes/small_wooden_floor_lvl1.png') RETURNING ID");
  }
  function JorvikMod2::SmallWoodenFloorlvl1Requirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  235,                  0,       10,         5,       0)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod2::SmallWoodenStairs() {
    dbi.Select(JorvikMod2, "SmallWoodenStairsRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Wooden Stairs', 'Object from Jorvik MOD',        32,               18,          30,        2549,               35,                       1,        0,          0,           'yolauncher/modpack/mods/Jorvik2/art/2D/Recipes/small_wooden_stairs.png') RETURNING ID");
  }
  function JorvikMod2::SmallWoodenStairsRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  324,                  0,       30,         6,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  327,                  0,       20,         15,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  281,                  0,       30,         20,       0)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod2::SmallThatchRoofTop() {
    dbi.Select(JorvikMod2, "SmallThatchRoofTopRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'SmallThatchRoofTop', 'Object from Jorvik MOD',        32,               18,          30,        2550,               35,                       1,        0,          0,           'yolauncher/modpack/mods/Jorvik2/art/2D/Recipes/small_thatch_roof_top.png') RETURNING ID");
  }
  function JorvikMod2::SmallThatchRoofTopRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  233,                  0,       10,         1,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  234,                  0,       10,         2,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  362,                  0,       10,         5,       0)");
 
	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod2::SmallThatchRoofOuterCornerTop() {
    dbi.Select(JorvikMod2, "SmallThatchRoofOuterCornerTopRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'SmallThatchRoofOuterCornerTop', 'Object from Jorvik MOD',        32,               18,          30,        2551,               35,                       1,        0,          0,           'yolauncher/modpack/mods/Jorvik2/art/2D/Recipes/small_thatch_roof_outer_corner_top.png') RETURNING ID");
  }
  function JorvikMod2::SmallThatchRoofOuterCornerTopRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  233,                  0,       10,         1,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  234,                  0,       10,         2,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  362,                  0,       10,         5,       0)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod2::SmallThatchRoofTopLeftEnd() {
    dbi.Select(JorvikMod2, "SmallThatchRoofTopLeftEndRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'SmallThatchRoofTopLeftEnd', 'Object from Jorvik MOD',        32,               18,          30,        2493,               35,                       1,        0,          0,           'yolauncher/modpack/mods/Jorvik2/art/2D/Recipes/small_thatch_roof_top_left_end.png') RETURNING ID");
  }
  function JorvikMod2::SmallThatchRoofTopLeftEndRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  233,                  0,       10,         1,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  234,                  0,       10,         2,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  362,                  0,       10,         5,       0)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod2::SmallThatchRoofTopRightEnd() {
    dbi.Select(JorvikMod2, "SmallThatchRoofTopRightEndRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'SmallThatchRoofTopRightEnd', 'Object from Jorvik MOD',        32,               18,          30,        2494,               35,                       1,        0,          0,           'yolauncher/modpack/mods/Jorvik2/art/2D/Recipes/small_thatch_roof_top_right_end.png') RETURNING ID");
  }
  function JorvikMod2::SmallThatchRoofTopRightEndRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  233,                  0,       10,         1,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  234,                  0,       10,         2,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  362,                  0,       10,         5,       0)");
 
	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod2::SmallThatchRooflvl1() {
    dbi.Select(JorvikMod2, "SmallThatchRooflvl1Requirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'SmallThatchRoof', 'Object from Jorvik MOD',        32,               18,          30,        2495,               35,                       1,        0,          0,           'yolauncher/modpack/mods/Jorvik2/art/2D/Recipes/small_thatch_roof.png') RETURNING ID");
  }
  function JorvikMod2::SmallThatchRooflvl1Requirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  233,                  0,       10,         1,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  234,                  0,       10,         2,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  362,                  0,       10,         5,       0)");
  
	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod2::SmallThatchRoofOuterCornerlvl1() {
    dbi.Select(JorvikMod2, "SmallThatchRoofOuterCornerlvl1Requirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'SmallThatchRoofOuterCorner', 'Object from Jorvik MOD',        32,               18,          30,        2496,               35,                       1,        0,          0,           'yolauncher/modpack/mods/Jorvik2/art/2D/Recipes/small_thatch_roof_outer_corner.png') RETURNING ID");
  }
  function JorvikMod2::SmallThatchRoofOuterCornerlvl1Requirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  233,                  0,       10,         1,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  234,                  0,       10,         2,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  362,                  0,       10,         10,       0)");
    
	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod2::SmallWoodenRailing() {
    dbi.Select(JorvikMod2, "SmallWoodenRailingRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Wooden Railing', 'Object from Jorvik MOD',        32,               18,          30,        2497,               35,                       1,        0,          0,           'yolauncher/modpack/mods/Jorvik2/art/2D/Recipes/small_wooden_railing.png') RETURNING ID");
  }
  function JorvikMod2::SmallWoodenRailingRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  235,                  0,       10,         5,       0)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod2::SmallWoodenRailinglvl1() {
    dbi.Select(JorvikMod2, "SmallWoodenRailinglvl1Requirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Wooden Railing', 'Object from Jorvik MOD',        32,               18,          30,        2498,               35,                       1,        0,          0,           'yolauncher/modpack/mods/Jorvik2/art/2D/Recipes/small_wooden_railing_lvl1.png') RETURNING ID");
  }
  function JorvikMod2::SmallWoodenRailinglvl1Requirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  235,                  0,       10,         5,       0)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod2::SmallThatchRoofOuterCornerToplvl1() {
    dbi.Select(JorvikMod2, "SmallThatchRoofOuterCornerToplvl1Requirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'SmallThatchRoofOuterCornerTop', 'Object from Jorvik MOD',        32,               18,          30,        2499,               35,                       1,        0,          0,           'yolauncher/modpack/mods/Jorvik2/art/2D/Recipes/small_thatch_roof_outer_corner_top.png') RETURNING ID");
  }
  function JorvikMod2::SmallThatchRoofOuterCornerToplvl1Requirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  233,                  0,       10,         1,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  234,                  0,       10,         2,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  362,                  0,       10,         5,       0)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod2::WallTorch() {
    dbi.Select(JorvikMod2, "WallTorchRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Wall Torch', 'Object from Jorvik MOD',        0,               62,          0,        2500,               10,                       1,        0,          0,           'yolauncher/modpack/mods/Jorvik2/art/2D/Recipes/wall_torch.png') RETURNING ID");
  }
  function JorvikMod2::WallTorchRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  1634,                  0,       90,         1,       0)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod2::SmallCandle() {
    dbi.Select(JorvikMod2, "SmallCandleRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Candle', 'Object from Jorvik MOD',        0,               62,          0,        2502 ,               10,                       1,        0,          0,           'yolauncher/modpack/mods/Jorvik2/art/2D/Recipes/small_candle.png') RETURNING ID");
  }
  function JorvikMod2::SmallCandleRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  1634,                  0,       90,         1,       0)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod2::AurochsCowstand() {
    dbi.Select(JorvikMod2, "AurochsCowstandRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Aurochs Cow (stand)', 'Object from Jorvik MOD',        2517,                14,          90,        2504,               90,                       1,        0,          0,           'yolauncher/modpack/mods/Jorvik2/art/2D/Recipes/aurochs_cow.png') RETURNING ID");
  }
  function JorvikMod2::AurochsCowstandRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  675,                  0,       10,         2,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  342,                  0,       10,         100,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  1046,                  0,       10,         1,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  427,                  0,       10,         1,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  386,                  0,       10,         200,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  2517,                  0,       10,         1,       0)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod2::AurochsCoweat() {
    dbi.Select(JorvikMod2, "AurochsCoweatRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Aurochs Cow (eat)', 'Object from Jorvik MOD',        2517,                14,          90,        2505,               90,                       1,        0,          0,           'yolauncher/modpack/mods/Jorvik2/art/2D/Recipes/aurochs_cow.png') RETURNING ID");
  }
  function JorvikMod2::AurochsCoweatRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  675,                  0,       10,         2,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  342,                  0,       10,         100,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  1046,                  0,       10,         1,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  427,                  0,       10,         1,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  386,                  0,       10,         200,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  2517,                  0,       10,         1,       0)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod2::Aurochssleep() {
    dbi.Select(JorvikMod2, "AurochsCowsleepRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Aurochs Cow (sleep)', 'Object from Jorvik MOD',        2517,                14,          90,        2506,               90,                       1,        0,          0,           'yolauncher/modpack/mods/Jorvik2/art/2D/Recipes/aurochs_cow.png') RETURNING ID");
  }
  function JorvikMod2::AurochsCowsleepRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  675,                  0,       10,         2,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  342,                  0,       10,         100,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  1046,                  0,       10,         1,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  427,                  0,       10,         1,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  386,                  0,       10,         200,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  2517,                  0,       10,         1,       0)");
 
	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod2::Sowstand() {
    dbi.Select(JorvikMod2, "SowstandRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Sow (stand)', 'Object from Jorvik MOD',        2517,                14,          90,        2508,               90,                       1,        0,          0,           'yolauncher/modpack/mods/Jorvik2/art/2D/Recipes/sow.png') RETURNING ID");
  }
  function JorvikMod2::SowstandRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  675,                  0,       10,         2,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  342,                  0,       10,         50,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  1048,                  0,       10,         1,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  429,                  0,       10,         1,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  386,                  0,       10,         100,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  2517,                  0,       10,         1,       0)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod2::Soweat() {
    dbi.Select(JorvikMod2, "SoweatRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Sow (eat)', 'Object from Jorvik MOD',        2517,                14,          90,        2509,               90,                       1,        0,          0,           'yolauncher/modpack/mods/Jorvik2/art/2D/Recipes/sow.png') RETURNING ID");
  }
  function JorvikMod2::SoweatRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  675,                  0,       10,         2,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  342,                  0,       10,         50,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  1048,                  0,       10,         1,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  429,                  0,       10,         1,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  386,                  0,       10,         100,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  2517,                  0,       10,         1,       0)");
 
	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod2::Sowsleep() {
    dbi.Select(JorvikMod2, "SowsleepRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Sow (sleep)', 'Object from Jorvik MOD',        2517,                14,          90,        2510,               90,                       1,        0,          0,           'yolauncher/modpack/mods/Jorvik2/art/2D/Recipes/sow.png') RETURNING ID");
  }
  function JorvikMod2::SowsleepRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  675,                  0,       10,         2,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  342,                  0,       10,         50,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  1048,                  0,       10,         1,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  429,                  0,       10,         1,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  386,                  0,       10,         100,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  2517,                  0,       10,         1,       0)");
 
	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod2::Horsestand() {
    dbi.Select(JorvikMod2, "HorsestandRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Horse (stand)', 'Object from Jorvik MOD',        2517,                14,          90,        2510,               90,                       1,        0,          0,           'yolauncher/modpack/mods/Jorvik2/art/2D/Recipes/horse.png') RETURNING ID");
  }
  function JorvikMod2::HorsestandRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  675,                  0,       10,         2,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  342,                  0,       10,         100,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  1039,                  0,       10,         1,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  427,                  0,       10,         1,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  386,                  0,       10,         200,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  2517,                  0,       10,         1,       0)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod2::Horseeat() {
    dbi.Select(JorvikMod2, "HorseeatRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Horse (eat)', 'Object from Jorvik MOD',        2517,                14,          90,        2512,               90,                       1,        0,          0,           'yolauncher/modpack/mods/Jorvik2/art/2D/Recipes/horse.png') RETURNING ID");
  }
  function JorvikMod2::HorseeatRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  675,                  0,       10,         2,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  342,                  0,       10,         100,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  1039,                  0,       10,         1,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  427,                  0,       10,         1,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  386,                  0,       10,         200,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  2517,                  0,       10,         1,       0)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod2::Horsesleep() {
    dbi.Select(JorvikMod2, "HorsesleepRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Horse (sleep)', 'Object from Jorvik MOD',        2517,                14,          90,        2513,               90,                       1,        0,          0,           'yolauncher/modpack/mods/Jorvik2/art/2D/Recipes/horse.png') RETURNING ID");
  }
  function JorvikMod2::HorsesleepRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  675,                  0,       10,         2,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  342,                  0,       10,         100,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  1039,                  0,       10,         1,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  427,                  0,       10,         1,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  386,                  0,       10,         200,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  2517,                  0,       10,         1,       0)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod2::Slaveworking() {
    dbi.Select(JorvikMod2, "SlaveworkingRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Slave (working)', 'Object from Jorvik MOD',        2517,                14,          90,        2514,               90,                       1,        0,          0,           'yolauncher/modpack/mods/Jorvik2/art/2D/Recipes/slave.png') RETURNING ID");
  }
  function JorvikMod2::SlaveworkingRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  675,                  0,       10,         2,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  342,                  0,       10,         80,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  1409,                  0,       10,         1,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  1700,                  0,       10,         1,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  386,                  0,       10,         100,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  2517,                  0,       10,         1,       0)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod2::WranentheHunterstand() {
    dbi.Select(JorvikMod2, "WranentheHunterstandRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Wranen the Hunter (stand)', 'Object from Jorvik MOD',        2517,                14,          90,        2515,               90,                       1,        0,          0,           'yolauncher/modpack/mods/Jorvik2/art/2D/Recipes/wranen_the_hunter.png') RETURNING ID");
  }
  function JorvikMod2::WranentheHunterstandRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  675,                  0,       10,         2,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  342,                  0,       10,         80,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  1409,                  0,       10,         1,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  1700,                  0,       10,         1,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  386,                  0,       10,         100,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  2517,                  0,       10,         1,       0)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod2::BookPaper() {
    dbi.Select(JorvikMod2, "BookPaperRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Book Paper', 'Object from Jorvik MOD',        293,               8,          90,        2516,               10,                       1,        1,          0,           'yolauncher/modpack/mods/Jorvik2/art/2D/Items/paper.png') RETURNING ID");
  }
  function JorvikMod2::BookPaperRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  1130,                  0,       10,         10,       0)");
	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod2::HealthBook() {
    dbi.Select(JorvikMod2, "HealthBookRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Health Book', 'Object from Jorvik MOD',        293,               8,          90,        2517,               10,                       1,        1,          0,           'yolauncher/modpack/mods/Jorvik2/art/2D/Items/health_book.png') RETURNING ID");
  }
  function JorvikMod2::HealthBookRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  2516,                  0,       10,         100,       1)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  374,                  0,       10,         10,       0)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod2::SmallThatchRoofInnerCorner() {
    dbi.Select(JorvikMod2, "SmallThatchRoofInnerCornerRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'SmallThatchRoof Inner Corner', 'Object from Jorvik MOD',        32,               18,          30,        2518,               35,                       1,        0,          0,           'yolauncher/modpack/mods/Jorvik2/art/2D/Recipes/small_thatch_roof_inner_corner.png') RETURNING ID");
  }
  function JorvikMod2::SmallThatchRoofInnerCornerRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  233,                  0,       10,         1,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  234,                  0,       10,         2,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  362,                  0,       10,         10,       0)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
	  function JorvikMod2::WoodCart() {
    dbi.Select(JorvikMod2, "WoodCartRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Wood Cart', 'Object from Jorvik MOD',        36,               8,          90,        2519,               30,                       1,        0,          0,           'yolauncher/modpack/mods/Jorvik2/art/2D/Recipes/wood_cart.png') RETURNING ID");
  }
  function JorvikMod2::WoodCartRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  235,                  0,       20,         30,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  255,                  0,       10,         4,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  1131,                  0,       10,         20,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  36,                  0,       10,         40,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  262,                  0,       10,         10,       0)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod2::SiegeTower() {
    dbi.Select(JorvikMod2, "SiegeTowerRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Siege Tower', 'Object from Jorvik MOD',        36,               10,          0,        2520,               30,                       1,        0,          0,           'yolauncher/modpack/mods/Jorvik2/art/2D/Recipes/siegetower.png') RETURNING ID");
  }
  function JorvikMod2::SiegeTowerRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  1135,                  0,       10,         2,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  1134,                  0,       10,         1,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  255,                  0,       10,         6,       0)");
 
	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod2::AurochsBullstand() {
    dbi.Select(JorvikMod2, "AurochsBullstandRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Aurochs Bull (stand)', 'Object from Jorvik MOD',        2517,                14,          90,        2521,               90,                       1,        0,          0,           'yolauncher/modpack/mods/Jorvik2/art/2D/Recipes/aurochs_bull.png') RETURNING ID");
  }
  function JorvikMod2::AurochsBullstandRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  675,                  0,       10,         2,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  342,                  0,       10,         100,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  1047,                  0,       10,         1,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  427,                  0,       10,         1,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  386,                  0,       10,         200,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  2517,                  0,       10,         1,       0)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod2::AurochsBulleat() {
    dbi.Select(JorvikMod2, "AurochsBulleatRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Aurochs Bull (eat)', 'Object from Jorvik MOD',        2517,                14,          90,        2522,               90,                       1,        0,          0,           'yolauncher/modpack/mods/Jorvik2/art/2D/Recipes/aurochs_bull.png') RETURNING ID");
  }
  function JorvikMod2::AurochsBulleatRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  675,                  0,       10,         2,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  342,                  0,       10,         100,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  1047,                  0,       10,         1,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  427,                  0,       10,         1,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  386,                  0,       10,         200,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  2517,                  0,       10,         1,       0)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod2::AurochsBullsleep() {
    dbi.Select(JorvikMod2, "AurochsBullsleepRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Aurochs Bull (sleep)', 'Object from Jorvik MOD',        2517,                14,          90,        2523,               90,                       1,        0,          0,           'yolauncher/modpack/mods/Jorvik2/art/2D/Recipes/aurochs_bull.png') RETURNING ID");
  }
  function JorvikMod2::AurochsBullsleepRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  675,                  0,       10,         2,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  342,                  0,       10,         100,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  1047,                  0,       10,         1,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  427,                  0,       10,         1,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  386,                  0,       10,         200,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  2517,                  0,       10,         1,       0)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod2::SmallWoodenPier() {
    dbi.Select(JorvikMod2, "SmallWoodenPierRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Wooden Pier', 'Object from Jorvik MOD',        32,               18,          60,        2524,               10,                       1,        0,          0,           'yolauncher/modpack/mods/Jorvik2/art/2D/Recipes/small_wooden_pier.png') RETURNING ID");
  }
  function JorvikMod2::SmallWoodenPierRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  324,                  0,       10,         16,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  326,                  0,       10,         32,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  1356,                  0,       10,         10,       0)");
	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod2::SmallWoodenPierT() {
    dbi.Select(JorvikMod2, "SmallWoodenPierTRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Wooden Pier T', 'Object from Jorvik MOD',        32,               18,          60,        2525,               10,                       1,        0,          0,           'yolauncher/modpack/mods/Jorvik2/art/2D/Recipes/small_wooden_pier_T.png') RETURNING ID");
  }
  function JorvikMod2::SmallWoodenPierTRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  324,                  0,       10,         30,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  326,                  0,       10,         64,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  1356,                  0,       10,         20,       0)");
	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod2::SmallWoodenPierL() {
    dbi.Select(JorvikMod2, "SmallWoodenPierLRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Wooden Pier L', 'Object from Jorvik MOD',        32,               18,          60,        2526,               10,                       1,        0,          0,           'yolauncher/modpack/mods/Jorvik2/art/2D/Recipes/small_wooden_pier_L.png') RETURNING ID");
  }
  function JorvikMod2::SmallWoodenPierLRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  324,                  0,       10,         30,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  326,                  0,       10,         64,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  1356,                  0,       10,         20,       0)");
	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod2::WattleWicket() {
    dbi.Select(JorvikMod2, "WattleWicketRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Wattle Wicket', 'Object from Jorvik MOD',        32,               18,          0,        2527,               30,                       1,        0,          0,           'yolauncher/modpack/mods/Jorvik2/art/2D/Recipes/wattle_wicket.png') RETURNING ID");
  }
  function JorvikMod2::WattleWicketRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  237,                  0,       45,         12,       0)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod2::IdolCross() {
    dbi.Select(JorvikMod2, "IdolCrossRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Idol Cross', 'Object from Jorvik MOD',        34,               54,          0,        2528,               25,                       1,        0,          0,           'yolauncher/modpack/mods/Jorvik2/art/2D/Recipes/idol_cross.png') RETURNING ID");
  }
  function JorvikMod2::IdolCrossRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  233,                  0,       10,         2,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  1356,                  0,       10,         2,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  247,                  0,       10,         1,       0)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod2::WoodenChurch() {
    dbi.Select(JorvikMod2, "WoodenChurchRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Wooden Church', 'Object from Jorvik MOD',        32,               20,          60,        2529,               35,                       1,        0,          0,           'yolauncher/modpack/mods/Jorvik2/art/2D/Recipes/wooden_church.png') RETURNING ID");
  }
  function JorvikMod2::WoodenChurchRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  233,                  0,       30,         150,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  268,                  0,       10,         250,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  286,                  0,       10,         1,       1)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  288,                  0,       5,         7,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  326,                  0,       5,         250,       0)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }
  function JorvikMod2::SanctumoftheSleeper() {
    dbi.Select(JorvikMod2, "SanctumoftheSleeperRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Sanctum of the Sleeper', 'Object from Jorvik MOD',        32,               20,          60,        2485,               35,                       1,        0,          0,           'yolauncher/modpack/mods/Jorvik2/art/2D/Recipes/church.png') RETURNING ID");
  }
  function JorvikMod2::SanctumoftheSleeperRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  271,                  0,       30,         6000,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  1490,                  0,       30,         10,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  528,                  0,       30,         800,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  268,                  0,       30,         500,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  409,                  0,       30,         10,       0)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }
  function JorvikMod2::NoviceDecoratorsKit() {
    dbi.Select(JorvikMod2, "NoviceDecoratorsKitRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Novice Decorator/'s Kit', 'Object from Jorvik MOD',        293,               8,          90,        2531,               10,                       1,        1,          0,           'yolauncher/modpack/mods/Jorvik2/art/2D/Items/decoration_kit_small.png') RETURNING ID");
  }
  function JorvikMod2::NoviceDecoratorsKitRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  1130,                  0,       30,         20,       1)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  349,                  0,       30,         1,       1)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  242,                  0,       30,         15,       1)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  409,                  0,       30,         2,       1)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  1356,                  0,       30,         5,       1)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }  function JorvikMod2::ApprenticeDecoratorsKit() {
    dbi.Select(JorvikMod2, "ApprenticeDecoratorsKitRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Apprentice Decorator/'s Kit', 'Object from Jorvik MOD',        293,               8,          90,        2532,               10,                       1,        1,          0,           'yolauncher/modpack/mods/Jorvik2/art/2D/Items/decoration_kit_medium.png') RETURNING ID");
  }
  function JorvikMod2::ApprenticeDecoratorsKitRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  1130,                  0,       30,         50,       1)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  269,                  0,       30,         30,       1)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  411,                  0,       30,         2,       1)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  343,                  0,       30,         20,       1)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  1477,                  0,       30,         5,       1)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }  function JorvikMod2::MasterDecoratorsKit() {
    dbi.Select(JorvikMod2, "MasterDecoratorsKitRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Master Decorator/'s Kit', 'Object from Jorvik MOD',        293,               8,          90,        2533,               10,                       1,        1,          0,           'yolauncher/modpack/mods/Jorvik2/art/2D/Items/decoration_kit_large.png') RETURNING ID");
  }
  function JorvikMod2::MasterDecoratorsKitRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  1130,                  0,       30,         100,       1)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  271,                  0,       30,         50,       1)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  412,                  0,       30,         2,       1)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  345,                  0,       30,         20,       1)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  261,                  0,       30,         5,       1)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod2::Wolfstand() {
    dbi.Select(JorvikMod2, "WolfstandRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Wolf (stand)', 'Object from Jorvik MOD',        2517,                14,          90,        2534,               90,                       1,        0,          0,           'yolauncher/modpack/mods/Jorvik2/art/2D/Recipes/wolf.png') RETURNING ID");
  }
  function JorvikMod2::WolfstandRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  675,                  0,       10,         2,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  342,                  0,       10,         50,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  1404,                  0,       10,         1,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  428,                  0,       10,         1,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  386,                  0,       10,         100,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  2517,                  0,       10,         1,       0)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod2::GoldSheet() {
    dbi.Select(JorvikMod2, "GoldSheetRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Gold Sheet', 'Object from Jorvik MOD',        453,               4,          0,        2535,               20,                       1,        1,          0,           'yolauncher/modpack/mods/Jorvik2/art/2D/Items/gold_sheet.png') RETURNING ID");
  }
  function JorvikMod2::GoldSheetRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  406,                  0,       60,         2,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  1647,                  0,       10,         40,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  453,                  0,       10,         15,       0)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod2::MetalScissors() {
    dbi.Select(JorvikMod2, "MetalScissorsRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Metal Scissors', 'Object from Jorvik MOD',        453,               4,          0,        2536,               20,                       1,        1,          0,           'yolauncher/modpack/mods/Jorvik2/art/2D/Items/scissors.png') RETURNING ID");
  }
  function JorvikMod2::MetalScissorsRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  364,                  0,       50,         1,       1)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  1647,                  0,       10,         40,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  453,                  0,       10,         15,       0)");
 
	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod2::MetalStamp() {
    dbi.Select(JorvikMod2, "MetalStampRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Metal Stamp', 'Object from Jorvik MOD',        453,               4,          0,        2537,               20,                       1,        1,          0,           'yolauncher/modpack/mods/Jorvik2/art/2D/Items/metal_stamp.png') RETURNING ID");
  }
  function JorvikMod2::MetalStampRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  364,                  0,       50,         1,       1)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  1647,                  0,       10,         40,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  453,                  0,       10,         15,       0)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	

  function JorvikMod2::GoldBlanks() {
    dbi.Select(JorvikMod2, "GoldBlanksRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Gold Blanks', 'Object from Jorvik MOD',        453,               4,          90,        2538,               90,                       5,        1,          0,           'yolauncher/modpack/mods/Jorvik2/art/2D/Items/gold_blanks.png') RETURNING ID");
  }
  function JorvikMod2::GoldBlanksRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  2535,                  0,       10,         1,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  2536,                  0,       10,         40,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  453,                  0,       10,         15,       0)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod2::SilverSheet() {
    dbi.Select(JorvikMod2, "Silver SheetRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Silver Sheet', 'Object from Jorvik MOD',        453,               4,          0,        2539,               20,                       1,        1,          0,           'yolauncher/modpack/mods/Jorvik2/art/2D/Items/silver_sheet.png') RETURNING ID");
  }
  function JorvikMod2::SilverSheetRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  405,                  0,       60,         2,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  1647,                  0,       10,         40,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  453,                  0,       10,         15,       0)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }
  function JorvikMod2::CopperSheet() {
    dbi.Select(JorvikMod2, "CopperSheetRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Copper Sheet', 'Object from Jorvik MOD',        453,               4,          0,        2540,               20,                       1,        1,          0,           'yolauncher/modpack/mods/Jorvik2/art/2D/Items/copper_sheet.png') RETURNING ID");
  }
  function JorvikMod2::CopperSheetRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  403,                  0,       60,         2,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  1647,                  0,       10,         40,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  453,                  0,       10,         15,       0)");



	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod2::SilverBlanks() {
    dbi.Select(JorvikMod2, "SilverBlanksRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Silver Blanks', 'Object from Jorvik MOD',        453,               4,          90,        2541,               90,                       5,        1,          0,           'yolauncher/modpack/mods/Jorvik2/art/2D/Items/silver_blanks.png') RETURNING ID");
  }
  function JorvikMod2::SilverBlanksRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  2539,                  0,       10,         1,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  2536,                  0,       10,         40,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  453,                  0,       10,         15,       0)");


	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod2::CopperBlanks() {
    dbi.Select(JorvikMod2, "CopperBlanksRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Copper Blanks', 'Object from Jorvik MOD',        453,               4,          90,        2542,               90,                       5,        1,          0,           'yolauncher/modpack/mods/Jorvik2/art/2D/Items/copper_blanks.png') RETURNING ID");
  }
  function JorvikMod2::CopperBlanksRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  2540,                  0,       10,         1,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  2536,                  0,       10,         40,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  453,                  0,       10,         15,       0)");
 

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }
  function JorvikMod2::GoldCoins() {
    dbi.Select(JorvikMod2, "GoldCoinsRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Gold Coins', 'Object from Jorvik MOD',        453,               4,          100,        1061,               100,                       5,        1,          0,           'yolauncher/modpack/mods/Jorvik2/art/2D/Items/gold_coins.png') RETURNING ID");
  }
  function JorvikMod2::GoldCoinsRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");

      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  2538,                  0,       50,         5,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  2537,                  0,       10,         40,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  453,                  0,       10,         15,       0)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod2::SilverCoins() {
    dbi.Select(JorvikMod2, "SilverCoinsRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Silver Coins', 'Object from Jorvik MOD',        453,               4,          100,        1060,               100,                       5,        1,          0,           'yolauncher/modpack/mods/Jorvik2/art/2D/Items/silver_coins.png') RETURNING ID");
  }
  function JorvikMod2::SilverCoinsRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  2541,                  0,       50,         5,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  2537,                  0,       10,         40,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  453,                  0,       10,         15,       0)");
  
	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod2::CopperCoins() {
    dbi.Select(JorvikMod2, "CopperCoinsRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Copper Coins', 'Object from Jorvik MOD',        453,               4,          100,        1059,               100,                       5,        1,          0,           'yolauncher/modpack/mods/Jorvik2/art/2D/Items/copper_coins.png') RETURNING ID");
  }
  function JorvikMod2::CopperCoinsRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  2542,                  0,       50,         5,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  2537,                  0,       10,         40,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  453,                  0,       10,         15,       0)");
	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }  
  function JorvikMod2::ObjectsTypesWoodCartHarnessed() {
    return new ScriptObject(ObjectsTypesWoodCartHarnessed : ObjectsTypes)
    {
      id = 2570; 
      ObjectName = "Wood Cart (harnessed)"; 
      ParentID = 77; 
      IsContainer = 1;
      IsMovableObject = 1; 
      IsUnmovableobject = 0; 
      IsTool = 0; 
      IsDevice = 0; 
      IsDoor = 0; 
      IsPremium = 0; 
      MaxContSize = 3000000;
      Length = 7;  
      MaxStackSize = 0; 
      UnitWeight = 10000; 
      BackgrndImage = "art/images/universal"; 
      WorkAreaTop = 0;
      WorkAreaLeft = 0;
      WorkAreaWidth = 0;
      WorkAreaHeight = 0;
      BtnCloseTop = 0;
      BtnCloseLeft = 0;
      FaceImage = "yolauncher/modpack/mods/Jorvik2/art/2D/Objects/wood_cart.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 100; 
      OwnerTimeout = 30; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }

  function serverCmdRequestRules(%client)
  {
      LiFx::debugEcho(JorvikMod2.modRoot);
      %file = new FileObject();
      %file.openForRead(JorvikMod2.modRoot @ "server_rules.txt");

      %content = "";
      while (!%file.isEOF())
      {
          %line = %file.readLine();
          %content = %content @ %line @ "\n";
      }

      %file.close();
      %file.delete();

      %packets = mCeil(strLen(%content) / 255);
      %count = 0;

      while (%count < %packets)
      {
          %subContent = getSubStr(%content, %count * 255, 255);
          commandToClient(%client, 'DisplayRules', %subContent);
          %count++;
      }

      commandToClient(%client, 'EndRulesTransmission');
  }
};
// This command is from Torque, and activates your package so that the engine can reference it
// This is required for your mod to work, and have the code loaded in torque engine.
activatePackage(JorvikMod2);