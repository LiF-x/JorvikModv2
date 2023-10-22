/**
* <author>Christophe Roblin</author>
* <url>lifxmod.com</url>
* <credits>Odin one Eye of Jorvik</credits>
* <description>LiFx compatible v2.1.0 of Jorvik Mod</description>
* <license>GNU GENERAL PUBLIC LICENSE Version 3, 29 June 2007</license>
*/

// Register your mod as an object in the game engine, important for loading and unloading a package (mod)
if (!isObject(JorvikMod))
{
    new ScriptObject(JorvikMod)
    {
    };
}


// LiFx expect each mod to be it's own unique package
package JorvikMod
{
  // Returns a string as a version, LiFx will look for this specific function to output version to new connecting players
  // Takes no parameters, is a reserved function for LiFx compatability.
  function JorvikMod::version() {
    return "v2.1.0";
  }

  // The setup method is required, and will be looked for by the framework, if it doesn't have it your mod will not execute
  // This is where you tell the framework, which hooks you use and what object types you have added, so that the framework can call your code at the appropiate time
  function JorvikMod::setup() {
    JorvikMod.modRoot = getSubStr($Con::File,0,strrchrpos($Con::File,"/") + 1);
    // Register callback hooks, do not run any form of code that does anything here, just register the hook
	/**
	* LiFx::registerCallback is a global framework function, it takes 3 parameters
    * Parameter 1: The hook to register your function on
    * Parameter 2: Non scoped name of function in your package
    * Parameter 3: The package name to scope your function appropiately.
	*/
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, objectsConversions, JorvikMod);
    LiFx::registerCallback($LiFx::hooks::onServerCreatedCallbacks, loadDatablocks, JorvikMod);
	/**
	* LiFx::registerObjectsTypes is a global framework function, it takes 2 parameters
	* It is used to write to the dump.sql on start, prior to the server reading it, and is necessary as bitbox wipes the objectstypes table on each start up.
    * Parameter 1: The function including scope to your objectstypes definition
    * Parameter 2: The package name of your mod
	*/

    // Buildings
    LiFx::registerObjectsTypes(JorvikMod::ObjectsTypesSmallWoodenShed(), JorvikMod); // same ID as V1
    LiFx::registerObjectsTypes(JorvikMod::ObjectsTypesFlagPvP(), JorvikMod);
    LiFx::registerObjectsTypes(JorvikMod::ObjectsTypesFlagPvE(), JorvikMod);
    LiFx::registerObjectsTypes(JorvikMod::ObjectsTypesLonghouse(), JorvikMod);
    LiFx::registerObjectsTypes(JorvikMod::ObjectsTypesStoneGate(), JorvikMod);
    LiFx::registerObjectsTypes(JorvikMod::ObjectsTypesSmallWoodenBridge(), JorvikMod);
    LiFx::registerObjectsTypes(JorvikMod::ObjectsTypesSmallStoneBridge(), JorvikMod);
    LiFx::registerObjectsTypes(JorvikMod::ObjectsTypesLargeWoodenBridge(), JorvikMod);
    LiFx::registerObjectsTypes(JorvikMod::ObjectsTypesLargeStoneBridge(), JorvikMod);
    LiFx::registerObjectsTypes(JorvikMod::ObjectsTypesLargeStoneBridgeEnd(), JorvikMod);
    LiFx::registerObjectsTypes(JorvikMod::ObjectsTypesSmallStoneBridgeEnd(), JorvikMod);
    LiFx::registerObjectsTypes(JorvikMod::ObjectsTypesModularConstructions(), JorvikMod);
    LiFx::registerObjectsTypes(JorvikMod::ObjectsTypesSmallLogWall(), JorvikMod);
    LiFx::registerObjectsTypes(JorvikMod::ObjectsTypesSmallWoodenPillar(), JorvikMod);
    LiFx::registerObjectsTypes(JorvikMod::ObjectsTypesSmallLogCornerWall(), JorvikMod);
    LiFx::registerObjectsTypes(JorvikMod::ObjectsTypesSmallLogWallWithWindow(), JorvikMod);
    LiFx::registerObjectsTypes(JorvikMod::ObjectsTypesSmallLogWallWithShutters(), JorvikMod);
    LiFx::registerObjectsTypes(JorvikMod::ObjectsTypesSmallLogWallWithEntrance(), JorvikMod);
    LiFx::registerObjectsTypes(JorvikMod::ObjectsTypesSmallLogWallWithDoor(), JorvikMod);
    LiFx::registerObjectsTypes(JorvikMod::ObjectsTypesSmallWoodenFloorEntrance(), JorvikMod);
    LiFx::registerObjectsTypes(JorvikMod::ObjectsTypesSmallWoodenFloor(), JorvikMod);
    LiFx::registerObjectsTypes(JorvikMod::ObjectsTypesSmallLogWallSlopeRight(), JorvikMod);
    LiFx::registerObjectsTypes(JorvikMod::ObjectsTypesSmallLogWallSlopeLeft(), JorvikMod);
    LiFx::registerObjectsTypes(JorvikMod::ObjectsTypesSmallThatchRoof(), JorvikMod);
    LiFx::registerObjectsTypes(JorvikMod::ObjectsTypesSmallThatchRoofRightEnd(), JorvikMod);
    LiFx::registerObjectsTypes(JorvikMod::ObjectsTypesSmallThatchRoofLeftEnd(), JorvikMod);
    LiFx::registerObjectsTypes(JorvikMod::ObjectsTypesSmallThatchRoofOuterCorner(), JorvikMod);
    LiFx::registerObjectsTypes(JorvikMod::ObjectsTypesModularConstructionslvl1(), JorvikMod);
    LiFx::registerObjectsTypes(JorvikMod::ObjectsTypesSmallLogWalllvl1(), JorvikMod);
    LiFx::registerObjectsTypes(JorvikMod::ObjectsTypesSmallWoodenPillarlvl1(), JorvikMod);
    LiFx::registerObjectsTypes(JorvikMod::ObjectsTypesSmallLogCornerWalllvl1(), JorvikMod);
    LiFx::registerObjectsTypes(JorvikMod::ObjectsTypesSmallLogWallWithWindowlvl1(), JorvikMod);
    LiFx::registerObjectsTypes(JorvikMod::ObjectsTypesSmallLogWallWithShutterslvl1(), JorvikMod);
    LiFx::registerObjectsTypes(JorvikMod::ObjectsTypesSmallLogWallWithEntrancelvl1(), JorvikMod);
    LiFx::registerObjectsTypes(JorvikMod::ObjectsTypesSmallLogWallWithDoorlvl1(), JorvikMod);
    LiFx::registerObjectsTypes(JorvikMod::ObjectsTypesSmallWoodenFloorEntrancelvl1(), JorvikMod);
    LiFx::registerObjectsTypes(JorvikMod::ObjectsTypesSmallWoodenFloorlvl1(), JorvikMod);
    LiFx::registerObjectsTypes(JorvikMod::ObjectsTypesSmallWoodenStairs(), JorvikMod);
    LiFx::registerObjectsTypes(JorvikMod::ObjectsTypesSmallThatchRoofTop(), JorvikMod);
    LiFx::registerObjectsTypes(JorvikMod::ObjectsTypesSmallThatchRoofOuterCornerTop(), JorvikMod);
    LiFx::registerObjectsTypes(JorvikMod::ObjectsTypesSmallThatchRoofTopLeftEnd(), JorvikMod);
    LiFx::registerObjectsTypes(JorvikMod::ObjectsTypesSmallThatchRoofTopRightEnd(), JorvikMod);
    LiFx::registerObjectsTypes(JorvikMod::ObjectsTypesSmallThatchRooflvl1(), JorvikMod);
    LiFx::registerObjectsTypes(JorvikMod::ObjectsTypesSmallThatchRoofOuterCornerlvl1(), JorvikMod);
    LiFx::registerObjectsTypes(JorvikMod::ObjectsTypesSmallWoodenRailing(), JorvikMod);
    LiFx::registerObjectsTypes(JorvikMod::ObjectsTypesSmallWoodenRailinglvl1(), JorvikMod);
    LiFx::registerObjectsTypes(JorvikMod::ObjectsTypesSmallThatchRoofOuterCornerToplvl1(), JorvikMod);
    LiFx::registerObjectsTypes(JorvikMod::ObjectsTypesWallTorch(), JorvikMod);
    LiFx::registerObjectsTypes(JorvikMod::ObjectsTypesWallTorchMovable(), JorvikMod);
    LiFx::registerObjectsTypes(JorvikMod::ObjectsTypesSmallCandle(), JorvikMod);
    LiFx::registerObjectsTypes(JorvikMod::ObjectsTypesSmallCandleMovable(), JorvikMod);
    LiFx::registerObjectsTypes(JorvikMod::ObjectsTypesAurochsCowstand(), JorvikMod);
    LiFx::registerObjectsTypes(JorvikMod::ObjectsTypesAurochsCoweat(), JorvikMod);
    LiFx::registerObjectsTypes(JorvikMod::ObjectsTypesAurochsCowsleep(), JorvikMod);
    LiFx::registerObjectsTypes(JorvikMod::ObjectsTypesSowstand(), JorvikMod);
    LiFx::registerObjectsTypes(JorvikMod::ObjectsTypesSoweat(), JorvikMod);
    LiFx::registerObjectsTypes(JorvikMod::ObjectsTypesSowsleep(), JorvikMod);
    LiFx::registerObjectsTypes(JorvikMod::ObjectsTypesHorsestand(), JorvikMod);
    LiFx::registerObjectsTypes(JorvikMod::ObjectsTypesHorseeat(), JorvikMod);
    LiFx::registerObjectsTypes(JorvikMod::ObjectsTypesHorsesleep(), JorvikMod);
    LiFx::registerObjectsTypes(JorvikMod::ObjectsTypesSlaveworking(), JorvikMod);
    LiFx::registerObjectsTypes(JorvikMod::ObjectsTypesWranentheHunterstand(), JorvikMod);
    LiFx::registerObjectsTypes(JorvikMod::ObjectsTypesBookPaper(), JorvikMod);
    LiFx::registerObjectsTypes(JorvikMod::ObjectsTypesHealthBook(), JorvikMod);
    LiFx::registerObjectsTypes(JorvikMod::ObjectsTypesSmallThatchRoofInnerCorner(), JorvikMod);
    LiFx::registerObjectsTypes(JorvikMod::ObjectsTypesWoodCart(), JorvikMod);
    LiFx::registerObjectsTypes(JorvikMod::ObjectsTypesSiegeTower(), JorvikMod);
    LiFx::registerObjectsTypes(JorvikMod::ObjectsTypesAurochsBullstand(), JorvikMod);
    LiFx::registerObjectsTypes(JorvikMod::ObjectsTypesAurochsBulleat(), JorvikMod);
    LiFx::registerObjectsTypes(JorvikMod::ObjectsTypesAurochsBullsleep(), JorvikMod);
    LiFx::registerObjectsTypes(JorvikMod::ObjectsTypesSmallWoodenPier(), JorvikMod);
    LiFx::registerObjectsTypes(JorvikMod::ObjectsTypesSmallWoodenPierT(), JorvikMod);
    LiFx::registerObjectsTypes(JorvikMod::ObjectsTypesSmallWoodenPierL(), JorvikMod);
    LiFx::registerObjectsTypes(JorvikMod::ObjectsTypesWattleWicket(), JorvikMod);
    LiFx::registerObjectsTypes(JorvikMod::ObjectsTypesIdolCross(), JorvikMod);
    LiFx::registerObjectsTypes(JorvikMod::ObjectsTypesWoodenChurch(), JorvikMod);
    LiFx::registerObjectsTypes(JorvikMod::ObjectsTypesSanctumoftheSleeper(), JorvikMod);
    LiFx::registerObjectsTypes(JorvikMod::ObjectsTypesNoviceDecoratorKit(), JorvikMod);
    LiFx::registerObjectsTypes(JorvikMod::ObjectsTypesApprenticeDecoratorKit(), JorvikMod);
    LiFx::registerObjectsTypes(JorvikMod::ObjectsTypesMasterDecoratorKit(), JorvikMod);
    LiFx::registerObjectsTypes(JorvikMod::ObjectsTypesWolfstand(), JorvikMod);
    LiFx::registerObjectsTypes(JorvikMod::ObjectsTypesGoldSheet(), JorvikMod);
    LiFx::registerObjectsTypes(JorvikMod::ObjectsTypesMetalScissors(), JorvikMod);
    LiFx::registerObjectsTypes(JorvikMod::ObjectsTypesMetalStamp(), JorvikMod);
    LiFx::registerObjectsTypes(JorvikMod::ObjectsTypesGoldBlanks(), JorvikMod);
    LiFx::registerObjectsTypes(JorvikMod::ObjectsTypesSilverSheet(), JorvikMod);
    LiFx::registerObjectsTypes(JorvikMod::ObjectsTypesCopperSheet(), JorvikMod);
    LiFx::registerObjectsTypes(JorvikMod::ObjectsTypesSilverBlanks(), JorvikMod);
    LiFx::registerObjectsTypes(JorvikMod::ObjectsTypesCopperBlanks(), JorvikMod);  
    //Register Callbacks
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, SmallWoodenShed, JorvikMod);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, FlagPvP, JorvikMod);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, FlagPvE, JorvikMod);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, Longhouse, JorvikMod);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, StoneGate, JorvikMod);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, SmallWoodenBridge, JorvikMod);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, SmallStoneBridge, JorvikMod);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, LargeWoodenBridge, JorvikMod);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, LargeStoneBridge, JorvikMod);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, LargeStoneBridgeEnd, JorvikMod);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, SmallStoneBridgeEnd, JorvikMod);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, ModularConstructions, JorvikMod);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, SmallLogWall, JorvikMod);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, SmallWoodenPillar, JorvikMod);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, SmallLogCornerWall, JorvikMod);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, SmallLogWallWithWindow, JorvikMod);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, SmallLogWallWithShutters, JorvikMod);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, SmallLogWallWithEntrance, JorvikMod);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, SmallLogWallWithDoor, JorvikMod);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, SmallWoodenFloorEntrance, JorvikMod);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, SmallWoodenFloor, JorvikMod);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, SmallLogWallSlopeRight, JorvikMod);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, SmallLogWallSlopeLeft, JorvikMod);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, SmallThatchRoof, JorvikMod);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, SmallThatchRoofRightEnd, JorvikMod);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, SmallThatchRoofLeftEnd, JorvikMod);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, SmallThatchRoofOuterCorner, JorvikMod);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, SmallLogWalllvl1, JorvikMod);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, SmallWoodenPillarlvl1, JorvikMod);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, SmallLogCornerWalllvl1, JorvikMod);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, SmallLogWallWithWindowlvl1, JorvikMod);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, SmallLogWallWithShutterslvl1, JorvikMod);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, SmallLogWallWithEntrancelvl1, JorvikMod);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, SmallLogWallWithDoorlvl1, JorvikMod);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, SmallWoodenFloorEntrancelvl1, JorvikMod);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, SmallWoodenFloorlvl1, JorvikMod);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, SmallWoodenStairs, JorvikMod);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, SmallThatchRoofTop, JorvikMod);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, SmallThatchRoofOuterCornerTop, JorvikMod);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, SmallThatchRoofTopLeftEnd, JorvikMod);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, SmallThatchRoofTopRightEnd, JorvikMod);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, SmallThatchRooflvl1, JorvikMod);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, SmallThatchRoofOuterCornerlvl1, JorvikMod);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, SmallWoodenRailing, JorvikMod);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, SmallWoodenRailinglvl1, JorvikMod);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, SmallThatchRoofOuterCornerToplvl1, JorvikMod);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, WallTorch, JorvikMod);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, SmallCandle, JorvikMod);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, AurochsCowstand, JorvikMod);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, AurochsCoweat, JorvikMod);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, AurochsCowsleep, JorvikMod);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, Sowstand, JorvikMod);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, Soweat, JorvikMod);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, Sowsleep, JorvikMod);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, Horsestand, JorvikMod);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, Horseeat, JorvikMod);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, Horsesleep, JorvikMod);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, Slaveworking, JorvikMod);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, WranentheHunterstand, JorvikMod);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, BookPaper, JorvikMod);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, HealthBook, JorvikMod);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, SmallThatchRoofInnerCorner, JorvikMod);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, WoodCart, JorvikMod);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, SiegeTower, JorvikMod);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, AurochsBullstand, JorvikMod);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, AurochsBulleat, JorvikMod);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, AurochsBullsleep, JorvikMod);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, SmallWoodenPier, JorvikMod);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, SmallWoodenPierT, JorvikMod);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, SmallWoodenPierL, JorvikMod);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, WattleWicket, JorvikMod);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, IdolCross, JorvikMod);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, WoodenChurch, JorvikMod);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, SanctumoftheSleeper, JorvikMod);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, NoviceDecoratorKit, JorvikMod);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, ApprenticeDecoratorKit, JorvikMod);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, MasterDecoratorKit, JorvikMod);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, Wolfstand, JorvikMod);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, GoldSheet, JorvikMod);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, MetalScissors, JorvikMod);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, MetalStamp, JorvikMod);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, GoldBlanks, JorvikMod);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, SilverSheet, JorvikMod);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, CopperSheet, JorvikMod);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, SilverBlanks, JorvikMod);
    LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, CopperBlanks, JorvikMod);

  }

  function JorvikMod::objectsConversions(%this, %client) {
      dbi.Update("INSERT IGNORE `objects_conversions` VALUES (NULL, 2549, 2507)");
      dbi.Update("INSERT IGNORE `objects_conversions` VALUES (NULL, 2500, 2501)");
      dbi.Update("INSERT IGNORE `objects_conversions` VALUES (NULL, 2502, 2503)");
  }
  function JorvikMod::loadDatablocks() {
    LiFx::loadRecursivelyInFolder("yolauncher/modpack/art/datablocks", "audioProfiles.cs");
    LiFx::loadRecursivelyInFolder("yolauncher/modpack/art/datablocks", "Transport.cs");
  }
  function JorvikMod::ObjectsTypesSmallWoodenShed() {
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
      FaceImage = "yolauncher/modpack/art/2D/objects/small_wooden_shed.png"; // *STRING* Reference to png that will be displayed in crafting menu
      Description = "Object from Jorvik MOD"; // *STRING* Used in crafting and skill to describe your object
      BasePrice = 0; // *INT* Used as price for sacrificing to monuments, high value gives more maintenance points
      OwnerTimeout = 0; // *INT* Used to set a timer on the object when made or dropped.
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
    };
  }
  function JorvikMod::SmallWoodenShed() {
                                   //dbi.update("INSERT IGNORE INTO `recipe` VALUES (NULL,      Name,                 Description,      StartingToolsID,   SkillTypeID, SkillLvl, ResultObjectTypeID, SkillDepends,       Quantity, Autorepeat, isBluePrint, ImagePath)
    dbi.Select(JorvikMod, "SmallWoodenShedRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Wooden Shed', 'Object from Jorvik MOD',        32,               18,          60,        2403,               25,           1,        0,          0,           'yolauncher/modpack/art/2D/Recipes/small_wooden_shed.png') RETURNING ID");
  }
  function JorvikMod::SmallWoodenShedRequirements(%this, %resultSet) {
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
  function JorvikMod::ObjectsTypesFlagPvP() {
    return new ScriptObject(ObjectsTypesFlagPvP : ObjectsTypes)
    {
      id = 2401; 
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
      FaceImage = "yolauncher/modpack/art/2D/Objects/flag_pvp.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 20300; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
    };
  }
  function JorvikMod::FlagPvP() {
                                   //dbi.update("INSERT IGNORE INTO `recipe` VALUES (NULL,      Name,                 Description,      StartingToolsID,   SkillTypeID, SkillLvl, ResultObjectTypeID, SkillDepends,       Quantity, Autorepeat, isBluePrint, ImagePath)
    dbi.Select(JorvikMod, "FlagPvPRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Flag PvP', 'Object from Jorvik MOD',        32,               19,          100,        2401,               20,                       1,        0,          0,           'yolauncher/modpack/art/2D/Recipes/flag_pvp.png') RETURNING ID");
  }
  function JorvikMod::FlagPvPRequirements(%this, %resultSet) {
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
  function JorvikMod::ObjectsTypesFlagPvE() {
    return new ScriptObject(ObjectsTypesFlagPvE : ObjectsTypes)
    {
      id = 2402; 
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
      FaceImage = "yolauncher/modpack/art/2D/Objects/flag_pve.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 20300; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
    };
  }
  function JorvikMod::FlagPvE() {
                                   //dbi.update("INSERT IGNORE INTO `recipe` VALUES (NULL,      Name,                 Description,      StartingToolsID,   SkillTypeID, SkillLvl, ResultObjectTypeID, SkillDepends,       Quantity, Autorepeat, isBluePrint, ImagePath)
    dbi.Select(JorvikMod, "FlagPvERequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Flag PvE', 'Object from Jorvik MOD',        32,               19,          100,        2402,               20,                       1,        0,          0,           'yolauncher/modpack/art/2D/Recipes/flag_pvp.png') RETURNING ID");
  }
  function JorvikMod::FlagPvERequirements(%this, %resultSet) {
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
  function JorvikMod::ObjectsTypesLonghouse() {
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
      FaceImage = "yolauncher/modpack/art/2D/Objects/long_house.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
    };
  }
  function JorvikMod::Longhouse() {
                                   //dbi.update("INSERT IGNORE INTO `recipe` VALUES (NULL,      Name,                 Description,      StartingToolsID,   SkillTypeID, SkillLvl, ResultObjectTypeID, SkillDepends,       Quantity, Autorepeat, isBluePrint, ImagePath)
    dbi.Select(JorvikMod, "LonghouseRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Longhouse', 'Object from Jorvik MOD',        32,               20,          60,        2543,               20,                       1,        0,          0,           'yolauncher/modpack/art/2D/Recipes/long_house.png') RETURNING ID");
  }
  function JorvikMod::LonghouseRequirements(%this, %resultSet) {
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
  function JorvikMod::ObjectsTypesStoneGate() {
    return new ScriptObject(ObjectsTypesStoneGate : ObjectsTypes)
    {
      id = 2404; 
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
      FaceImage = "yolauncher/modpack/art/2D/Objects/long_house.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
    };
  }
  function JorvikMod::StoneGate() {
                                   //dbi.update("INSERT IGNORE INTO `recipe` VALUES (NULL,      Name,                 Description,      StartingToolsID,   SkillTypeID, SkillLvl, ResultObjectTypeID, SkillDepends,       Quantity, Autorepeat, isBluePrint, ImagePath)
    dbi.Select(JorvikMod, "StoneGateRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Stone Gate', 'Object from Jorvik MOD',        32,               19,          60,        2404,               35,                       1,        0,          0,           'yolauncher/modpack/art/2D/Recipes/stone_gate.png') RETURNING ID");
  }
  function JorvikMod::StoneGateRequirements(%this, %resultSet) {
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
  function JorvikMod::ObjectsTypesSmallWoodenBridge() {
    return new ScriptObject(ObjectsTypesSmallWoodenBridge : ObjectsTypes)
    {
      id = 2405; 
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
      FaceImage = "yolauncher/modpack/art/2D/Objects/small_wooden_bridge.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod::SmallWoodenBridge() {
                                   //dbi.update("INSERT IGNORE INTO `recipe` VALUES (NULL,      Name,                 Description,      StartingToolsID,   SkillTypeID, SkillLvl, ResultObjectTypeID, SkillDepends,                  Quantity,Autorepeat,isBluePrint,           ImagePath)
    dbi.Select(JorvikMod, "SmallWoodenBridgeRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Wooden Bridge', 'Object from Jorvik MOD',        32,               18,          60,        2405,               10,                       1,        0,          0,           'yolauncher/modpack/art/2D/Recipes/small_wooden_bridge.png') RETURNING ID");
  }
  function JorvikMod::SmallWoodenBridgeRequirements(%this, %resultSet) {
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
  function JorvikMod::ObjectsTypesSmallStoneBridge() {
    return new ScriptObject(ObjectsTypesSmallStoneBridge : ObjectsTypes)
    {
      id = 2406; 
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
      FaceImage = "yolauncher/modpack/art/2D/Objects/small_stone_bridge.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod::SmallStoneBridge() {
                                   //dbi.update("INSERT IGNORE INTO `recipe` VALUES (NULL,      Name,                 Description,      StartingToolsID,   SkillTypeID, SkillLvl, ResultObjectTypeID, SkillDepends,                  Quantity,Autorepeat,isBluePrint,           ImagePath)
    dbi.Select(JorvikMod, "SmallStoneBridgeRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Stone Gate', 'Object from Jorvik MOD',        32,               18,          60,        2406,               35,                       0,        0,          0,           'yolauncher/modpack/art/2D/Recipes/small_wooden_bridge.png') RETURNING ID");
  }
  function JorvikMod::SmallStoneBridgeRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
    //dbi.update("INSERT IGNORE INTO `recipe_requirement` VALUES (RecipeID,            MaterialObjectTypeID, Quality, Influence, Quantity, IsRegionalItemRequired)
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  269,                  0,       40,         100,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  244,                  0,       10,         600,       0)");
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }
  function JorvikMod::ObjectsTypesLargeWoodenBridge() {
    return new ScriptObject(ObjectsTypesLargeWoodenBridge : ObjectsTypes)
    {
      id = 2407; 
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
      FaceImage = "yolauncher/modpack/art/2D/Objects/large_wooden_bridge.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod::ObjectsTypesLargeStoneBridge() {
    return new ScriptObject(ObjectsTypesLargeStoneBridge : ObjectsTypes)
    {
      id = 2408; 
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
      FaceImage = "yolauncher/modpack/art/2D/Objects/large_stone_bridge.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod::ObjectsTypesLargeStoneBridgeEnd() {
    return new ScriptObject(ObjectsTypesLargeStoneBridgeEnd : ObjectsTypes)
    {
      id = 2409; 
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
      FaceImage = "yolauncher/modpack/art/2D/Objects/large_stone_bridge_end.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod::ObjectsTypesSmallStoneBridgeEnd() {
    return new ScriptObject(ObjectsTypesSmallStoneBridgeEnd : ObjectsTypes)
    {
      id = 2410; 
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
      FaceImage = "yolauncher/modpack/art/2D/Objects/small_stone_bridge_end.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod::ObjectsTypesModularConstructions() {
    return new ScriptObject(ObjectsTypesModularConstructions : ObjectsTypes)
    {
      id = 2411; 
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
  function JorvikMod::ObjectsTypesSmallLogWall() {
    return new ScriptObject(ObjectsTypesSmallLogWall : ObjectsTypes)
    {
      id = 2412; 
      ObjectName = "Small Log Wall"; 
      ParentID = 2411; 
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
      FaceImage = "yolauncher/modpack/art/2D/Objects/small_log_wall.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod::ObjectsTypesSmallWoodenPillar() {
    return new ScriptObject(ObjectsTypesSmallWoodenPillar : ObjectsTypes)
    {
      id = 2413; 
      ObjectName = "Small Wooden Pillar"; 
      ParentID = 2411; 
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
      FaceImage = "yolauncher/modpack/art/2D/Objects/small_wooden_pillar.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod::ObjectsTypesSmallLogCornerWall() {
    return new ScriptObject(ObjectsTypesSmallLogCornerWall : ObjectsTypes)
    {
      id = 2414; 
      ObjectName = "Small Log Corner Wall"; 
      ParentID = 2411; 
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
      FaceImage = "yolauncher/modpack/art/2D/Objects/small_log_corner_wall.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod::ObjectsTypesSmallLogWallWithWindow() {
    return new ScriptObject(ObjectsTypesSmallLogWallWithWindow : ObjectsTypes)
    {
      id = 2415; 
      ObjectName = "Small Log Wall With Window"; 
      ParentID = 2411; 
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
      FaceImage = "yolauncher/modpack/art/2D/Objects/small_log_wall_with_window.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod::ObjectsTypesSmallLogWallWithShutters() {
    return new ScriptObject(ObjectsTypesSmallLogWallWithShutters : ObjectsTypes)
    {
      id = 2416; 
      ObjectName = "Small Log Wall With Shutters"; 
      ParentID = 2411; 
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
      FaceImage = "yolauncher/modpack/art/2D/Objects/small_log_wall_with_shutters.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod::ObjectsTypesSmallLogWallWithEntrance() {
    return new ScriptObject(ObjectsTypesSmallLogWallWithEntrance : ObjectsTypes)
    {
      id = 2417; 
      ObjectName = "Small Log Wall With Entrance"; 
      ParentID = 2411; 
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
      FaceImage = "yolauncher/modpack/art/2D/Objects/small_log_wall_with_entrance.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod::ObjectsTypesSmallLogWallWithDoor() {
    return new ScriptObject(ObjectsTypesSmallLogWallWithDoor : ObjectsTypes)
    {
      id = 2418; 
      ObjectName = "Small Log Wall With Door"; 
      ParentID = 2411; 
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
      FaceImage = "yolauncher/modpack/art/2D/Objects/small_log_wall_with_door.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod::ObjectsTypesSmallWoodenFloorEntrance() {
    return new ScriptObject(ObjectsTypesSmallWoodenFloorEntrance : ObjectsTypes)
    {
      id = 2419; 
      ObjectName = "Small Wooden Floor Entrance"; 
      ParentID = 2411; 
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
      FaceImage = "yolauncher/modpack/art/2D/Objects/small_wooden_floor_entrance.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod::ObjectsTypesSmallWoodenFloor() {
    return new ScriptObject(ObjectsTypesSmallWoodenFloor : ObjectsTypes)
    {
      id = 2473; 
      ObjectName = "Small Wooden Floor"; 
      ParentID = 2411; 
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
      FaceImage = "yolauncher/modpack/art/2D/Objects/small_wooden_floor.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod::ObjectsTypesSmallLogWallSlopeRight() {
    return new ScriptObject(ObjectsTypesSmallLogWallSlopeRight : ObjectsTypes)
    {
      id = 2474; 
      ObjectName = "Small Log Wall Slope Right"; 
      ParentID = 2411; 
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
      FaceImage = "yolauncher/modpack/art/2D/Objects/small_log_wall_slope_right.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod::ObjectsTypesSmallLogWallSlopeLeft() {
    return new ScriptObject(ObjectsTypesSmallLogWallSlopeLeft : ObjectsTypes)
    {
      id = 2475; 
      ObjectName = "Small Log Wall Slope Left"; 
      ParentID = 2411; 
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
      FaceImage = "yolauncher/modpack/art/2D/Objects/small_log_wall_slope_left.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod::ObjectsTypesSmallThatchRoof() {
    return new ScriptObject(ObjectsTypesSmallThatchRoof : ObjectsTypes)
    {
      id = 2476; 
      ObjectName = "SmallThatchRoof"; 
      ParentID = 2411; 
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
      FaceImage = "yolauncher/modpack/art/2D/Objects/small_thatch_roof.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod::ObjectsTypesSmallThatchRoofRightEnd() {
    return new ScriptObject(ObjectsTypesSmallThatchRoofRightEnd : ObjectsTypes)
    {
      id = 2477; 
      ObjectName = "SmallThatchRoofRightEnd"; 
      ParentID = 2411; 
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
      FaceImage = "yolauncher/modpack/art/2D/Objects/small_thatch_roof_rihgt_end.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod::ObjectsTypesSmallThatchRoofLeftEnd() {
    return new ScriptObject(ObjectsTypesSmallThatchRoofLeftEnd : ObjectsTypes)
    {
      id = 2478; 
      ObjectName = "SmallThatchRoofLeftEnd"; 
      ParentID = 2411; 
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
      FaceImage = "yolauncher/modpack/art/2D/Objects/small_thatch_roof_left_end.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod::ObjectsTypesSmallThatchRoofOuterCorner() {
    return new ScriptObject(ObjectsTypesSmallThatchRoofOuterCorner : ObjectsTypes)
    {
      id = 2479; 
      ObjectName = "SmallThatchRoofOuterCorner"; 
      ParentID = 2411; 
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
      FaceImage = "yolauncher/modpack/art/2D/Objects/small_thatch_roof_outer_corner.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod::ObjectsTypesModularConstructionslvl1() {
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
  function JorvikMod::ObjectsTypesSmallLogWalllvl1() {
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
      FaceImage = "yolauncher/modpack/art/2D/Objects/small_log_wall_lvl1.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod::ObjectsTypesSmallWoodenPillarlvl1() {
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
      FaceImage = "yolauncher/modpack/art/2D/Objects/small_wooden_pillar_lvl1.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod::ObjectsTypesSmallLogCornerWalllvl1() {
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
      FaceImage = "yolauncher/modpack/art/2D/Objects/small_log_corner_wall.png_lvl1";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod::ObjectsTypesSmallLogWallWithWindowlvl1() {
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
      FaceImage = "yolauncher/modpack/art/2D/Objects/small_log_wall_with_window_lvl1.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod::ObjectsTypesSmallLogWallWithShutterslvl1() {
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
      FaceImage = "yolauncher/modpack/art/2D/Objects/small_log_wall_with_shutters_lvl1.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod::ObjectsTypesSmallLogWallWithEntrancelvl1() {
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
      FaceImage = "yolauncher/modpack/art/2D/Objects/small_log_wall_with_entrance_lvl1.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod::ObjectsTypesSmallLogWallWithDoorlvl1() {
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
      FaceImage = "yolauncher/modpack/art/2D/Objects/small_log_wall_with_door_lvl1.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod::ObjectsTypesSmallWoodenFloorEntrancelvl1() {
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
      FaceImage = "yolauncher/modpack/art/2D/Objects/small_wooden_floor_entrance_lvl1.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod::ObjectsTypesSmallWoodenFloorlvl1() {
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
      FaceImage = "yolauncher/modpack/art/2D/Objects/small_wooden_floor.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod::ObjectsTypesSmallWoodenStairs() {
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
      FaceImage = "yolauncher/modpack/art/2D/Objects/small_wooden_stairs.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 100; 
      OwnerTimeout = 120; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod::ObjectsTypesSmallWoodenStairsMovable() {
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
      FaceImage = "yolauncher/modpack/art/2D/Objects/small_wooden_stairs.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 100; 
      OwnerTimeout = 120; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod::ObjectsTypesSmallThatchRoofTop() {
    return new ScriptObject(ObjectsTypesSmallThatchRoofTop: ObjectsTypes)
    {
      id = 2550; 
      ObjectName = "SmallThatchRoofTop"; 
      ParentID = 2411; 
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
      FaceImage = "yolauncher/modpack/art/2D/Objects/small_thatch_roof_top.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod::ObjectsTypesSmallThatchRoofOuterCornerTop() {
    return new ScriptObject(ObjectsTypesSmallThatchRoofOuterCornerTop: ObjectsTypes)
    {
      id = 2551; 
      ObjectName = "SmallThatchRoofOuterCornerTop"; 
      ParentID = 2411; 
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
      FaceImage = "yolauncher/modpack/art/2D/Objects/small_thatch_roof_outer_corner_top.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod::ObjectsTypesSmallThatchRoofTopLeftEnd() {
    return new ScriptObject(ObjectsTypesSmallThatchRoofTopLeftEnd : ObjectsTypes)
    {
      id = 2493; 
      ObjectName = "SmallThatchRoofTopLeftEnd"; 
      ParentID = 2411; 
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
      FaceImage = "yolauncher/modpack/art/2D/Objects/small_thatch_roof_top_left_end.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod::ObjectsTypesSmallThatchRoofTopRightEnd() {
    return new ScriptObject(ObjectsTypesSmallThatchRoofTopRightEnd : ObjectsTypes)
    {
      id = 2494; 
      ObjectName = "SmallThatchRoofTopRightEnd"; 
      ParentID = 2411; 
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
      FaceImage = "yolauncher/modpack/art/2D/Objects/small_thatch_roof_top_right_end.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod::ObjectsTypesSmallThatchRooflvl1() {
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
      FaceImage = "yolauncher/modpack/art/2D/Objects/small_thatch_roof.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod::ObjectsTypesSmallThatchRoofOuterCornerlvl1() {
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
      FaceImage = "yolauncher/modpack/art/2D/Objects/small_thatch_roof_outer_corner.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod::ObjectsTypesSmallWoodenRailing() {
    return new ScriptObject(ObjectsTypesSmallWoodenRailing : ObjectsTypes)
    {
      id = 2497; 
      ObjectName = "Small Wooden Railing"; 
      ParentID = 2411; 
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
      FaceImage = "yolauncher/modpack/art/2D/Objects/small_wooden_railing.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod::ObjectsTypesSmallWoodenRailinglvl1() {
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
      FaceImage = "yolauncher/modpack/art/2D/Objects/small_wooden_railing_lvl1.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod::ObjectsTypesSmallThatchRoofOuterCornerToplvl1() {
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
      FaceImage = "yolauncher/modpack/art/2D/Objects/small_thatch_roof_outer_corner_top.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod::ObjectsTypesWallTorch() {
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
      FaceImage = "yolauncher/modpack/art/2D/Recipes/wall_torch.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod::ObjectsTypesWallTorchMovable() {
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
      FaceImage = "yolauncher/modpack/art/2D/Recipes/wall_torch.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod::ObjectsTypesSmallCandle() {
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
      FaceImage = "yolauncher/modpack/art/2D/Recipes/small_candle.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod::ObjectsTypesSmallCandleMovable() {
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
      FaceImage = "yolauncher/modpack/art/2D/Recipes/small_candle.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod::ObjectsTypesAurochsCowstand() {
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
      FaceImage = "yolauncher/modpack/art/2D/Recipes/aurochs_cow.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod::ObjectsTypesAurochsCoweat() {
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
      FaceImage = "yolauncher/modpack/art/2D/Recipes/aurochs_cow.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod::ObjectsTypesAurochsCowsleep() {
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
      FaceImage = "yolauncher/modpack/art/2D/Recipes/aurochs_cow.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod::ObjectsTypesSowstand() {
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
      FaceImage = "yolauncher/modpack/art/2D/Recipes/sow.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod::ObjectsTypesSoweat() {
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
      FaceImage = "yolauncher/modpack/art/2D/Recipes/sow.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod::ObjectsTypesSowsleep() {
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
      FaceImage = "yolauncher/modpack/art/2D/Recipes/sow.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod::ObjectsTypesHorsestand() {
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
      FaceImage = "yolauncher/modpack/art/2D/Recipes/horse.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod::ObjectsTypesHorseeat() {
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
      FaceImage = "yolauncher/modpack/art/2D/Recipes/horse.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod::ObjectsTypesHorsesleep() {
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
      FaceImage = "yolauncher/modpack/art/2D/Recipes/horse.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod::ObjectsTypesSlaveworking() {
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
      FaceImage = "yolauncher/modpack/art/2D/Recipes/slave.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod::ObjectsTypesWranentheHunterstand() {
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
      FaceImage = "yolauncher/modpack/art/2D/Recipes/wranen_the_hunter.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 1; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod::ObjectsTypesBookPaper() {
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
      FaceImage = "yolauncher/modpack/art/2D/Items/paper.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 100; 
      OwnerTimeout = NULL; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod::ObjectsTypesHealthBook() {
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
      FaceImage = "yolauncher/modpack/art/2D/Items/health_book.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 9000; 
      OwnerTimeout = NULL; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod::ObjectsTypesSmallThatchRoofInnerCorner() {
    return new ScriptObject(ObjectsTypesSmallThatchRoofInnerCorner : ObjectsTypes)
    {
      id = 2518; 
      ObjectName = "SmallThatchRoof Inner Corner"; 
      ParentID = 2411; 
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
      FaceImage = "yolauncher/modpack/art/2D/Objects/small_thatch_roof_inner_corner.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod::ObjectsTypesWoodCart() {
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
      FaceImage = "yolauncher/modpack/art/2D/Objects/wood_cart.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 135600; 
      OwnerTimeout = 30; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod::ObjectsTypesSiegeTower() {
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
      FaceImage = "yolauncher/modpack/art/2D/Objects/siegetower.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 135600; 
      OwnerTimeout = 30; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod::ObjectsTypesAurochsBullstand() {
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
      FaceImage = "yolauncher/modpack/art/2D/Recipes/aurochs_bull.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod::ObjectsTypesAurochsBulleat() {
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
      FaceImage = "yolauncher/modpack/art/2D/Recipes/aurochs_bull.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod::ObjectsTypesAurochsBullsleep() {
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
      FaceImage = "yolauncher/modpack/art/2D/Recipes/aurochs_bull.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod::ObjectsTypesSmallWoodenPier() {
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
      FaceImage = "yolauncher/modpack/art/2D/Recipes/small_wooden_pier.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod::ObjectsTypesSmallWoodenPierT() {
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
      FaceImage = "yolauncher/modpack/art/2D/Recipes/small_wooden_pier_T.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod::ObjectsTypesSmallWoodenPierL() {
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
      FaceImage = "yolauncher/modpack/art/2D/Recipes/small_wooden_pier_L.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod::ObjectsTypesWattleWicket() {
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
      FaceImage = "yolauncher/modpack/art/2D/Recipes/wattle_wicket.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 3100; 
      OwnerTimeout = 86400; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod::ObjectsTypesIdolCross() {
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
      FaceImage = "yolauncher/modpack/art/2D/Recipes/idol_cross.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 1; 
      OwnerTimeout = NULL; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod::ObjectsTypesWoodenChurch() {
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
      FaceImage = "yolauncher/modpack/art/2D/Recipes/wooden_church.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 2400; 
      OwnerTimeout = 120; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod::ObjectsTypesSanctumoftheSleeper() {
    return new ScriptObject(ObjectsTypesSanctumoftheSleeper : ObjectsTypes)
    {
      id = 2530; 
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
      FaceImage = "yolauncher/modpack/art/2D/Recipes/church.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 2400; 
      OwnerTimeout = 120; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod::ObjectsTypesNoviceDecoratorKit() {
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
      FaceImage = "yolauncher/modpack/art/2D/Items/decoration_kit_small.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 100; 
      OwnerTimeout = NULL; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod::ObjectsTypesApprenticeDecoratorKit() {
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
      FaceImage = "yolauncher/modpack/art/2D/Items/decoration_kit_medium.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 100; 
      OwnerTimeout = NULL; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod::ObjectsTypesMasterDecoratorKit() {
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
      FaceImage = "yolauncher/modpack/art/2D/Items/decoration_kit_large.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 100; 
      OwnerTimeout = NULL; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod::ObjectsTypesWolfstand() {
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
      FaceImage = "yolauncher/modpack/art/2D/Recipes/wolf.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod::ObjectsTypesGoldSheet() {
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
      FaceImage = "yolauncher/modpack/art/2D/Items/gold_sheet.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 9000; 
      OwnerTimeout = NULL; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod::ObjectsTypesMetalScissors() {
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
      FaceImage = "yolauncher/modpack/art/2D/Items/scissors.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 9000; 
      OwnerTimeout = NULL; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod::ObjectsTypesMetalStamp() {
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
      FaceImage = "yolauncher/modpack/art/2D/Items/metal_stamp.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 9000; 
      OwnerTimeout = NULL; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod::ObjectsTypesGoldBlanks() {
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
      FaceImage = "yolauncher/modpack/art/2D/Items/gold_blanks.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 9000; 
      OwnerTimeout = NULL; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod::ObjectsTypesSilverSheet() {
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
      FaceImage = "yolauncher/modpack/art/2D/Items/silver_sheet.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 9000; 
      OwnerTimeout = NULL; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod::ObjectsTypesCopperSheet() {
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
      FaceImage = "yolauncher/modpack/art/2D/Items/copper_sheet.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 9000; 
      OwnerTimeout = NULL; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod::ObjectsTypesSilverBlanks() {
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
      FaceImage = "yolauncher/modpack/art/2D/Items/silver_blanks.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 9000; 
      OwnerTimeout = NULL; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod::ObjectsTypesCopperBlanks() {
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
      FaceImage = "yolauncher/modpack/art/2D/Items/silver_blanks.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 9000; 
      OwnerTimeout = NULL; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod::LargeWoodenBridge() {
    dbi.Select(JorvikMod, "LargeWoodenBridgeRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Large Wooden Bridge', 'Object from Jorvik MOD',        32,               18,          60,        2407,               10,                       1,        0,          0,           'yolauncher/modpack/art/2D/Recipes/large_wooden_bridge.png') RETURNING ID");
  }
  function JorvikMod::LargeWoodenBridgeRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  1356,                  0,       10,         15,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  233,                  0,       20,         12,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  235,                  0,       10,         50,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  281,                  0,       10,         60,       0)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }  function JorvikMod::LargeStoneBridge() {
    dbi.Select(JorvikMod, "LargeStoneBridgeRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Large Stone Bridge', 'Object from Jorvik MOD',        32,               19,          60,        2408,               35,                       1,        0,          0,           'yolauncher/modpack/art/2D/Recipes/large_stone_bridge.png') RETURNING ID");
  }
  function JorvikMod::LargeStoneBridgeRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  269,                  0,       40,         200,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  244,                  0,       10,         1200,       0)");
	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }  function JorvikMod::LargeStoneBridgeEnd() {
    dbi.Select(JorvikMod, "LargeStoneBridgeEndRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Large Stone Bridge End', 'Object from Jorvik MOD',        32,               19,          60,        2409,               35,                       1,        0,          0,           'yolauncher/modpack/art/2D/Recipes/large_stone_bridge_end.png') RETURNING ID");
  }
  function JorvikMod::LargeStoneBridgeEndRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  269,                  0,       40,         100,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  244,                  0,       10,         600,       0)");
	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }  function JorvikMod::SmallStoneBridgeEnd() {
    dbi.Select(JorvikMod, "SmallStoneBridgeEndRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Stone Bridge End', 'Object from Jorvik MOD',        32,               19,          60,        2410,               35,                       1,        0,          0,           'yolauncher/modpack/art/2D/Recipes/small_stone_bridge_end.png') RETURNING ID");
  }
  function JorvikMod::SmallStoneBridgeEndRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  269,                  0,       40,         50,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  244,                  0,       10,         300,       0)");
	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }
  function JorvikMod::SmallLogWall() {
    dbi.Select(JorvikMod, "SmallLogWallRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Log Wall', 'Object from Jorvik MOD',        32,               18,          30,        2412,               35,                       1,        0,          0,           'yolauncher/modpack/art/2D/Recipes/small_log_wall.png') RETURNING ID");
  }
  function JorvikMod::SmallLogWallRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  233,                  0,       10,         2,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  234,                  0,       10,         15,       0)");
	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }
  function JorvikMod::SmallWoodenPillar() {
    dbi.Select(JorvikMod, "SmallWoodenPillarRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Wooden Pillar', 'Object from Jorvik MOD',        32,               18,          30,        2413,               35,                       1,        0,          0,           'yolauncher/modpack/art/2D/Recipes/small_wooden_pillar.png') RETURNING ID");
  }
  function JorvikMod::SmallWoodenPillarRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  233,                  0,       10,         1,       0)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }
  function JorvikMod::SmallLogCornerWall() {
    dbi.Select(JorvikMod, "SmallLogCornerWallRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Log Corner Wall', 'Object from Jorvik MOD',        32,               18,          30,        2414,               35,                       1,        0,          0,           'yolauncher/modpack/art/2D/Recipes/small_log_corner_wall.png') RETURNING ID");
  }
  function JorvikMod::SmallLogCornerWallRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  233,                  0,       10,         2,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  234,                  0,       10,         30,       0)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }
  function JorvikMod::SmallLogWallWithWindow() {
    dbi.Select(JorvikMod, "SmallLogWallWithWindowRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Log Wall With Window', 'Object from Jorvik MOD',        32,               18,          30,        2415,               35,                       1,        0,          0,           'yolauncher/modpack/art/2D/Recipes/small_log_wall_with_window.png') RETURNING ID");
  }
  function JorvikMod::SmallLogWallWithWindowRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  233,                  0,       10,         2,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  234,                  0,       10,         12,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  235,                  0,       10,         4,       0)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }
  function JorvikMod::SmallLogWallWithShutters() {
    dbi.Select(JorvikMod, "SmallLogWallWithShuttersRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Log Wall With Shutters', 'Object from Jorvik MOD',        32,               18,          30,        2416,               35,                       1,        0,          0,           'yolauncher/modpack/art/2D/Recipes/small_log_wall_with_shutters.png') RETURNING ID");
  }
  function JorvikMod::SmallLogWallWithShuttersRequirements(%this, %resultSet) {
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
  function JorvikMod::SmallLogWallWithEntrance() {
    dbi.Select(JorvikMod, "SmallLogWallWithEntranceRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Log Wall With Entrance', 'Object from Jorvik MOD',        32,               18,          30,        2417,               35,                       1,        0,          0,           'yolauncher/modpack/art/2D/Recipes/small_log_wall_with_entrance.png') RETURNING ID");
  }
  function JorvikMod::SmallLogWallWithEntranceRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  233,                  0,       10,         4,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  1356,                  0,       10,         4,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  234,                  0,       10,         8,       0)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }
  function JorvikMod::SmallLogWallWithDoor() {
    dbi.Select(JorvikMod, "SmallLogWallWithDoorRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Log Wall With Door', 'Object from Jorvik MOD',        32,               18,          30,        2418,               35,                       1,        0,          0,           'yolauncher/modpack/art/2D/Recipes/small_log_wall_with_door.png') RETURNING ID");
  }
  function JorvikMod::SmallLogWallWithDoorRequirements(%this, %resultSet) {
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
  function JorvikMod::SmallWoodenFloorEntrance() {
    dbi.Select(JorvikMod, "SmallWoodenFloorEntranceRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Wooden Floor Entrance', 'Object from Jorvik MOD',        32,               18,          30,        2419,               35,                       1,        0,          0,           'yolauncher/modpack/art/2D/Recipes/small_wooden_floor_entrance.png') RETURNING ID");
  }
  function JorvikMod::SmallWoodenFloorEntranceRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  235,                  0,       10,         8,       0)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }
  function JorvikMod::SmallWoodenFloor() {
    dbi.Select(JorvikMod, "SmallWoodenFloorRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Wooden Floor', 'Object from Jorvik MOD',        32,               18,          30,        2473,               35,                       1,        0,          0,           'yolauncher/modpack/art/2D/Recipes/small_wooden_floor.png') RETURNING ID");
  }
  function JorvikMod::SmallWoodenFloorRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  235,                  0,       10,         5,       0)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }
  function JorvikMod::SmallLogWallSlopeRight() {
    dbi.Select(JorvikMod, "SmallLogWallSlopeRightRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Log Wall Slope Right', 'Object from Jorvik MOD',        32,               18,          30,        2474,               35,                       1,        0,          0,           'yolauncher/modpack/art/2D/Recipes/small_log_wall_slope_right.png') RETURNING ID");
  }
  function JorvikMod::SmallLogWallSlopeRightRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  234,                  0,       10,         5,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  233,                  0,       10,         2,       0)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }
  function JorvikMod::SmallLogWallSlopeLeft() {
    dbi.Select(JorvikMod, "SmallLogWallSlopeLeftRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Log Wall Slope Left', 'Object from Jorvik MOD',        32,               18,          30,        2475,               35,                       1,        0,          0,           'yolauncher/modpack/art/2D/Recipes/small_log_wall_slope_left.png') RETURNING ID");
  }
  function JorvikMod::SmallLogWallSlopeLeftRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  234,                  0,       10,         5,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  233,                  0,       10,         2,       0)");
 
	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }
  function JorvikMod::SmallThatchRoof() {
    dbi.Select(JorvikMod, "SmallThatchRoofRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'SmallThatchRoof', 'Object from Jorvik MOD',        32,               18,          30,        2476,               35,                       1,        0,          0,           'yolauncher/modpack/art/2D/Recipes/small_thatch_roof.png') RETURNING ID");
  }
  function JorvikMod::SmallThatchRoofRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  233,                  0,       10,         1,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  234,                  0,       10,         2,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  362,                  0,       10,         5,       0)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }
  function JorvikMod::SmallThatchRoofRightEnd() {
    dbi.Select(JorvikMod, "SmallThatchRoofRightEndRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'SmallThatchRoofRightEnd', 'Object from Jorvik MOD',        32,               18,          30,        2477,               35,                       1,        0,          0,           'yolauncher/modpack/art/2D/Recipes/small_thatch_roof_right_end.png') RETURNING ID");
  }
  function JorvikMod::SmallThatchRoofRightEndRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  233,                  0,       10,         1,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  234,                  0,       10,         2,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  362,                  0,       10,         5,       0)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }
  function JorvikMod::SmallThatchRoofLeftEnd() {
    dbi.Select(JorvikMod, "SmallThatchRoofLeftEndRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'SmallThatchRoofLeftEnd', 'Object from Jorvik MOD',        32,               18,          30,        2478,               35,                       1,        0,          0,           'yolauncher/modpack/art/2D/Recipes/small_thatch_roof_left_end.png') RETURNING ID");
  }
  function JorvikMod::SmallThatchRoofLeftEndRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  233,                  0,       10,         1,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  234,                  0,       10,         2,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  362,                  0,       10,         5,       0)");
 
	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }
  function JorvikMod::SmallThatchRoofOuterCorner() {
    dbi.Select(JorvikMod, "SmallThatchRoofOuterCornerRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'SmallThatchRoofOuterCorner', 'Object from Jorvik MOD',        32,               18,          30,        2479,               35,                       1,        0,          0,           'yolauncher/modpack/art/2D/Recipes/small_thatch_roof_outer_corner.png') RETURNING ID");
  }
  function JorvikMod::SmallThatchRoofOuterCornerRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  233,                  0,       10,         1,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  234,                  0,       10,         2,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  362,                  0,       10,         10,       0)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }  function JorvikMod::SmallLogWalllvl1() {
    dbi.Select(JorvikMod, "SmallLogWalllvl1Requirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Log Wall', 'Object from Jorvik MOD',        32,               18,          30,        2481,               35,                       1,        0,          0,           'yolauncher/modpack/art/2D/Recipes/small_log_wall_lvl1.png') RETURNING ID");
  }
  function JorvikMod::SmallLogWalllvl1Requirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  233,                  0,       10,         2,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  234,                  0,       10,         15,       0)");
	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }
  function JorvikMod::SmallWoodenPillarlvl1() {
    dbi.Select(JorvikMod, "SmallWoodenPillarlvl1Requirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Wooden Pillar', 'Object from Jorvik MOD',        32,               18,          30,        2482,               35,                       1,        0,          0,           'yolauncher/modpack/art/2D/Recipes/small_wooden_pillar_lvl1.png') RETURNING ID");
  }
  function JorvikMod::SmallWoodenPillarlvl1Requirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  233,                  0,       10,         1,       0)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	  
  function JorvikMod::SmallLogCornerWalllvl1() {
    dbi.Select(JorvikMod, "SmallLogCornerWallRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Log Corner Wall', 'Object from Jorvik MOD',        32,               18,          30,        2483,               35,                       1,        0,          0,           'yolauncher/modpack/art/2D/Recipes/small_log_corner_wall_lvl1.png') RETURNING ID");
  }
  function JorvikMod::SmallLogCornerWalllvl1Requirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  233,                  0,       10,         2,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  234,                  0,       10,         30,       0)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	  
  function JorvikMod::SmallLogWallWithWindowlvl1() {
    dbi.Select(JorvikMod, "SmallLogWallWithWindowlvl1Requirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Log Wall With Window', 'Object from Jorvik MOD',        32,               18,          30,        2484,               35,                       1,        0,          0,           'yolauncher/modpack/art/2D/Recipes/small_log_wall_with_window_lvl1.png') RETURNING ID");
  }
  function JorvikMod::SmallLogWallWithWindowlvl1Requirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  233,                  0,       10,         2,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  234,                  0,       10,         12,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  235,                  0,       10,         4,       0)");
 
	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod::SmallLogWallWithShutterslvl1() {
    dbi.Select(JorvikMod, "SmallLogWallWithShutterslvl1Requirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Log Wall With Shutters', 'Object from Jorvik MOD',        32,               18,          30,        2544,               35,                       1,        0,          0,           'yolauncher/modpack/art/2D/Recipes/small_log_wall_with_shutters_lvl1.png') RETURNING ID");
  }
  function JorvikMod::SmallLogWallWithShutterslvl1Requirements(%this, %resultSet) {
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
  function JorvikMod::SmallLogWallWithEntrancelvl1() {
    dbi.Select(JorvikMod, "SmallLogWallWithEntrancelvl1Requirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Log Wall With Entrance', 'Object from Jorvik MOD',        32,               18,          30,        2545,               35,                       1,        0,          0,           'yolauncher/modpack/art/2D/Recipes/small_log_wall_with_entrance_lvl1.png') RETURNING ID");
  }
  function JorvikMod::SmallLogWallWithEntrancelvl1Requirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  233,                  0,       10,         4,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  1356,                  0,       10,         4,       0)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod::SmallLogWallWithDoorlvl1() {
    dbi.Select(JorvikMod, "SmallLogWallWithDoorlvl1Requirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Log Wall With Door', 'Object from Jorvik MOD',        32,               18,          30,        2546,               35,                       1,        0,          0,           'yolauncher/modpack/art/2D/Recipes/small_log_wall_with_door_lvl1.png') RETURNING ID");
  }
  function JorvikMod::SmallLogWallWithDoorlvl1Requirements(%this, %resultSet) {
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
  function JorvikMod::SmallWoodenFloorEntrancelvl1() {
    dbi.Select(JorvikMod, "SmallWoodenFloorEntranceRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Wooden Floor Entrance', 'Object from Jorvik MOD',        32,               18,          30,        2547,               35,                       1,        0,          0,           'yolauncher/modpack/art/2D/Recipes/small_wooden_floor_entrance_lvl1.png') RETURNING ID");
  }
  function JorvikMod::SmallWoodenFloorEntrancelvl1Requirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  235,                  0,       10,         8,       0)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod::SmallWoodenFloorlvl1() {
    dbi.Select(JorvikMod, "SmallWoodenFloorlvl1Requirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Wooden Floor', 'Object from Jorvik MOD',        32,               18,          30,        2548,               35,                       1,        0,          0,           'yolauncher/modpack/art/2D/Recipes/small_wooden_floor_lvl1.png') RETURNING ID");
  }
  function JorvikMod::SmallWoodenFloorlvl1Requirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  235,                  0,       10,         5,       0)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod::SmallWoodenStairs() {
    dbi.Select(JorvikMod, "SmallWoodenStairsRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Wooden Stairs', 'Object from Jorvik MOD',        32,               18,          30,        2549,               35,                       1,        0,          0,           'yolauncher/modpack/art/2D/Recipes/small_wooden_stairs.png') RETURNING ID");
  }
  function JorvikMod::SmallWoodenStairsRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  324,                  0,       30,         6,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  327,                  0,       20,         15,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  281,                  0,       30,         20,       0)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod::SmallThatchRoofTop() {
    dbi.Select(JorvikMod, "SmallThatchRoofTopRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'SmallThatchRoofTop', 'Object from Jorvik MOD',        32,               18,          30,        2550,               35,                       1,        0,          0,           'yolauncher/modpack/art/2D/Recipes/small_thatch_roof_top.png') RETURNING ID");
  }
  function JorvikMod::SmallThatchRoofTopRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  233,                  0,       10,         1,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  234,                  0,       10,         2,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  362,                  0,       10,         5,       0)");
 
	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod::SmallThatchRoofOuterCornerTop() {
    dbi.Select(JorvikMod, "SmallThatchRoofOuterCornerTopRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'SmallThatchRoofOuterCornerTop', 'Object from Jorvik MOD',        32,               18,          30,        2551,               35,                       1,        0,          0,           'yolauncher/modpack/art/2D/Recipes/small_thatch_roof_outer_corner_top.png') RETURNING ID");
  }
  function JorvikMod::SmallThatchRoofOuterCornerTopRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  233,                  0,       10,         1,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  234,                  0,       10,         2,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  362,                  0,       10,         5,       0)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod::SmallThatchRoofTopLeftEnd() {
    dbi.Select(JorvikMod, "SmallThatchRoofTopLeftEndRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'SmallThatchRoofTopLeftEnd', 'Object from Jorvik MOD',        32,               18,          30,        2493,               35,                       1,        0,          0,           'yolauncher/modpack/art/2D/Recipes/small_thatch_roof_top_left_end.png') RETURNING ID");
  }
  function JorvikMod::SmallThatchRoofTopLeftEndRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  233,                  0,       10,         1,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  234,                  0,       10,         2,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  362,                  0,       10,         5,       0)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod::SmallThatchRoofTopRightEnd() {
    dbi.Select(JorvikMod, "SmallThatchRoofTopRightEndRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'SmallThatchRoofTopRightEnd', 'Object from Jorvik MOD',        32,               18,          30,        2494,               35,                       1,        0,          0,           'yolauncher/modpack/art/2D/Recipes/small_thatch_roof_top_right_end.png') RETURNING ID");
  }
  function JorvikMod::SmallThatchRoofTopRightEndRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  233,                  0,       10,         1,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  234,                  0,       10,         2,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  362,                  0,       10,         5,       0)");
 
	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod::SmallThatchRooflvl1() {
    dbi.Select(JorvikMod, "SmallThatchRooflvl1Requirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'SmallThatchRoof', 'Object from Jorvik MOD',        32,               18,          30,        2495,               35,                       1,        0,          0,           'yolauncher/modpack/art/2D/Recipes/small_thatch_roof.png') RETURNING ID");
  }
  function JorvikMod::SmallThatchRooflvl1Requirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  233,                  0,       10,         1,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  234,                  0,       10,         2,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  362,                  0,       10,         5,       0)");
  
	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod::SmallThatchRoofOuterCornerlvl1() {
    dbi.Select(JorvikMod, "SmallThatchRoofOuterCornerlvl1Requirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'SmallThatchRoofOuterCorner', 'Object from Jorvik MOD',        32,               18,          30,        2496,               35,                       1,        0,          0,           'yolauncher/modpack/art/2D/Recipes/small_thatch_roof_outer_corner.png') RETURNING ID");
  }
  function JorvikMod::SmallThatchRoofOuterCornerlvl1Requirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  233,                  0,       10,         1,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  234,                  0,       10,         2,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  362,                  0,       10,         10,       0)");
    
	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod::SmallWoodenRailing() {
    dbi.Select(JorvikMod, "SmallWoodenRailingRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Wooden Railing', 'Object from Jorvik MOD',        32,               18,          30,        2497,               35,                       1,        0,          0,           'yolauncher/modpack/art/2D/Recipes/small_wooden_railing.png') RETURNING ID");
  }
  function JorvikMod::SmallWoodenRailingRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  235,                  0,       10,         5,       0)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod::SmallWoodenRailinglvl1() {
    dbi.Select(JorvikMod, "SmallWoodenRailinglvl1Requirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Wooden Railing', 'Object from Jorvik MOD',        32,               18,          30,        2498,               35,                       1,        0,          0,           'yolauncher/modpack/art/2D/Recipes/small_wooden_railing_lvl1.png') RETURNING ID");
  }
  function JorvikMod::SmallWoodenRailinglvl1Requirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  235,                  0,       10,         5,       0)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod::SmallThatchRoofOuterCornerToplvl1() {
    dbi.Select(JorvikMod, "SmallThatchRoofOuterCornerToplvl1Requirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'SmallThatchRoofOuterCornerTop', 'Object from Jorvik MOD',        32,               18,          30,        2499,               35,                       1,        0,          0,           'yolauncher/modpack/art/2D/Recipes/small_thatch_roof_outer_corner_top.png') RETURNING ID");
  }
  function JorvikMod::SmallThatchRoofOuterCornerToplvl1Requirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  233,                  0,       10,         1,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  234,                  0,       10,         2,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  362,                  0,       10,         5,       0)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod::WallTorch() {
    dbi.Select(JorvikMod, "WallTorchRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Wall Torch', 'Object from Jorvik MOD',        0,               62,          0,        2500,               10,                       1,        0,          0,           'yolauncher/modpack/art/2D/Recipes/wall_torch.png') RETURNING ID");
  }
  function JorvikMod::WallTorchRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  1634,                  0,       90,         1,       0)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod::SmallCandle() {
    dbi.Select(JorvikMod, "SmallCandleRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Candle', 'Object from Jorvik MOD',        0,               62,          0,        2502 ,               10,                       1,        0,          0,           'yolauncher/modpack/art/2D/Recipes/small_candle.png') RETURNING ID");
  }
  function JorvikMod::SmallCandleRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  1634,                  0,       90,         1,       0)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod::AurochsCowstand() {
    dbi.Select(JorvikMod, "AurochsCowstandRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Aurochs Cow (stand)', 'Object from Jorvik MOD',        2517,                14,          90,        2504,               90,                       1,        0,          0,           'yolauncher/modpack/art/2D/Recipes/aurochs_cow.png') RETURNING ID");
  }
  function JorvikMod::AurochsCowstandRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  675,                  0,       10,         2,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  342,                  0,       10,         100,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  1046,                  0,       10,         1,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  427,                  0,       10,         1,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  386,                  0,       10,         200,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  2464,                  0,       10,         1,       0)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod::AurochsCoweat() {
    dbi.Select(JorvikMod, "AurochsCoweatRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Aurochs Cow (eat)', 'Object from Jorvik MOD',        2517,                14,          90,        2505,               90,                       1,        0,          0,           'yolauncher/modpack/art/2D/Recipes/aurochs_cow.png') RETURNING ID");
  }
  function JorvikMod::AurochsCoweatRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  675,                  0,       10,         2,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  342,                  0,       10,         100,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  1046,                  0,       10,         1,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  427,                  0,       10,         1,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  386,                  0,       10,         200,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  2464,                  0,       10,         1,       0)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod::Aurochssleep() {
    dbi.Select(JorvikMod, "AurochsCowsleepRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Aurochs Cow (sleep)', 'Object from Jorvik MOD',        2517,                14,          90,        2506,               90,                       1,        0,          0,           'yolauncher/modpack/art/2D/Recipes/aurochs_cow.png') RETURNING ID");
  }
  function JorvikMod::AurochsCowsleepRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  675,                  0,       10,         2,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  342,                  0,       10,         100,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  1046,                  0,       10,         1,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  427,                  0,       10,         1,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  386,                  0,       10,         200,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  2464,                  0,       10,         1,       0)");
 
	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod::Sowstand() {
    dbi.Select(JorvikMod, "SowstandRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Sow (stand)', 'Object from Jorvik MOD',        2517,                14,          90,        2508,               90,                       1,        0,          0,           'yolauncher/modpack/art/2D/Recipes/sow.png') RETURNING ID");
  }
  function JorvikMod::SowstandRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  675,                  0,       10,         2,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  342,                  0,       10,         50,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  1048,                  0,       10,         1,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  429,                  0,       10,         1,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  386,                  0,       10,         100,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  2464,                  0,       10,         1,       0)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod::Soweat() {
    dbi.Select(JorvikMod, "SoweatRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Sow (eat)', 'Object from Jorvik MOD',        2517,                14,          90,        2509,               90,                       1,        0,          0,           'yolauncher/modpack/art/2D/Recipes/sow.png') RETURNING ID");
  }
  function JorvikMod::SoweatRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  675,                  0,       10,         2,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  342,                  0,       10,         50,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  1048,                  0,       10,         1,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  429,                  0,       10,         1,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  386,                  0,       10,         100,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  2464,                  0,       10,         1,       0)");
 
	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod::Sowsleep() {
    dbi.Select(JorvikMod, "SowsleepRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Sow (sleep)', 'Object from Jorvik MOD',        2517,                14,          90,        2510,               90,                       1,        0,          0,           'yolauncher/modpack/art/2D/Recipes/sow.png') RETURNING ID");
  }
  function JorvikMod::SowsleepRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  675,                  0,       10,         2,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  342,                  0,       10,         50,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  1048,                  0,       10,         1,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  429,                  0,       10,         1,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  386,                  0,       10,         100,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  2464,                  0,       10,         1,       0)");
 
	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod::Horsestand() {
    dbi.Select(JorvikMod, "HorsestandRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Horse (stand)', 'Object from Jorvik MOD',        2517,                14,          90,        2510,               90,                       1,        0,          0,           'yolauncher/modpack/art/2D/Recipes/horse.png') RETURNING ID");
  }
  function JorvikMod::HorsestandRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  675,                  0,       10,         2,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  342,                  0,       10,         100,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  1039,                  0,       10,         1,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  427,                  0,       10,         1,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  386,                  0,       10,         200,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  2464,                  0,       10,         1,       0)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod::Horseeat() {
    dbi.Select(JorvikMod, "HorseeatRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Horse (eat)', 'Object from Jorvik MOD',        2517,                14,          90,        2512,               90,                       1,        0,          0,           'yolauncher/modpack/art/2D/Recipes/horse.png') RETURNING ID");
  }
  function JorvikMod::HorseeatRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  675,                  0,       10,         2,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  342,                  0,       10,         100,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  1039,                  0,       10,         1,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  427,                  0,       10,         1,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  386,                  0,       10,         200,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  2464,                  0,       10,         1,       0)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod::Horsesleep() {
    dbi.Select(JorvikMod, "HorsesleepRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Horse (sleep)', 'Object from Jorvik MOD',        2517,                14,          90,        2513,               90,                       1,        0,          0,           'yolauncher/modpack/art/2D/Recipes/horse.png') RETURNING ID");
  }
  function JorvikMod::HorsesleepRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  675,                  0,       10,         2,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  342,                  0,       10,         100,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  1039,                  0,       10,         1,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  427,                  0,       10,         1,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  386,                  0,       10,         200,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  2464,                  0,       10,         1,       0)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod::Slaveworking() {
    dbi.Select(JorvikMod, "SlaveworkingRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Slave (working)', 'Object from Jorvik MOD',        2517,                14,          90,        2514,               90,                       1,        0,          0,           'yolauncher/modpack/art/2D/Recipes/slave.png') RETURNING ID");
  }
  function JorvikMod::SlaveworkingRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  675,                  0,       10,         2,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  342,                  0,       10,         80,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  1409,                  0,       10,         1,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  1700,                  0,       10,         1,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  386,                  0,       10,         100,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  2464,                  0,       10,         1,       0)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod::WranentheHunterstand() {
    dbi.Select(JorvikMod, "WranentheHunterstandRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Wranen the Hunter (stand)', 'Object from Jorvik MOD',        2517,                14,          90,        2515,               90,                       1,        0,          0,           'yolauncher/modpack/art/2D/Recipes/wranen_the_hunter.png') RETURNING ID");
  }
  function JorvikMod::WranentheHunterstandRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  675,                  0,       10,         2,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  342,                  0,       10,         80,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  1409,                  0,       10,         1,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  1700,                  0,       10,         1,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  386,                  0,       10,         100,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  2464,                  0,       10,         1,       0)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod::BookPaper() {
    dbi.Select(JorvikMod, "BookPaperRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Book Paper', 'Object from Jorvik MOD',        293,               8,          90,        2516,               10,                       1,        1,          0,           'yolauncher/modpack/art/2D/Items/paper.png') RETURNING ID");
  }
  function JorvikMod::BookPaperRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  1130,                  0,       10,         10,       0)");
	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod::HealthBook() {
    dbi.Select(JorvikMod, "HealthBookRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Health Book', 'Object from Jorvik MOD',        293,               8,          90,        2517,               10,                       1,        1,          0,           'yolauncher/modpack/art/2D/Items/health_book.png') RETURNING ID");
  }
  function JorvikMod::HealthBookRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  2463,                  0,       10,         100,       1)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  374,                  0,       10,         10,       0)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod::SmallThatchRoofInnerCorner() {
    dbi.Select(JorvikMod, "SmallThatchRoofInnerCornerRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'SmallThatchRoof Inner Corner', 'Object from Jorvik MOD',        32,               18,          30,        2518,               35,                       1,        0,          0,           'yolauncher/modpack/art/2D/Recipes/small_thatch_roof_inner_corner.png') RETURNING ID");
  }
  function JorvikMod::SmallThatchRoofInnerCornerRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  233,                  0,       10,         1,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  234,                  0,       10,         2,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  362,                  0,       10,         10,       0)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
	  function JorvikMod::WoodCart() {
    dbi.Select(JorvikMod, "WoodCartRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Wood Cart', 'Object from Jorvik MOD',        36,               8,          90,        2519,               30,                       1,        0,          0,           'yolauncher/modpack/art/2D/Recipes/wood_cart.png') RETURNING ID");
  }
  function JorvikMod::WoodCartRequirements(%this, %resultSet) {
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
  function JorvikMod::SiegeTower() {
    dbi.Select(JorvikMod, "SiegeTowerRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Siege Tower', 'Object from Jorvik MOD',        36,               10,          0,        2520,               30,                       1,        0,          0,           'yolauncher/modpack/art/2D/Recipes/siegetower.png') RETURNING ID");
  }
  function JorvikMod::SiegeTowerRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  1135,                  0,       10,         2,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  1134,                  0,       10,         1,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  255,                  0,       10,         6,       0)");
 
	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod::AurochsBullstand() {
    dbi.Select(JorvikMod, "AurochsBullstandRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Aurochs Bull (stand)', 'Object from Jorvik MOD',        2517,                14,          90,        2521,               90,                       1,        0,          0,           'yolauncher/modpack/art/2D/Recipes/aurochs_bull.png') RETURNING ID");
  }
  function JorvikMod::AurochsBullstandRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  675,                  0,       10,         2,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  342,                  0,       10,         100,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  1047,                  0,       10,         1,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  427,                  0,       10,         1,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  386,                  0,       10,         200,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  2464,                  0,       10,         1,       0)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod::AurochsBulleat() {
    dbi.Select(JorvikMod, "AurochsBulleatRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Aurochs Bull (eat)', 'Object from Jorvik MOD',        2517,                14,          90,        2522,               90,                       1,        0,          0,           'yolauncher/modpack/art/2D/Recipes/aurochs_bull.png') RETURNING ID");
  }
  function JorvikMod::AurochsBulleatRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  675,                  0,       10,         2,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  342,                  0,       10,         100,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  1047,                  0,       10,         1,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  427,                  0,       10,         1,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  386,                  0,       10,         200,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  2464,                  0,       10,         1,       0)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod::AurochsBullsleep() {
    dbi.Select(JorvikMod, "AurochsBullsleepRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Aurochs Bull (sleep)', 'Object from Jorvik MOD',        2517,                14,          90,        2523,               90,                       1,        0,          0,           'yolauncher/modpack/art/2D/Recipes/aurochs_bull.png') RETURNING ID");
  }
  function JorvikMod::AurochsBullsleepRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  675,                  0,       10,         2,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  342,                  0,       10,         100,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  1047,                  0,       10,         1,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  427,                  0,       10,         1,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  386,                  0,       10,         200,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  2464,                  0,       10,         1,       0)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod::SmallWoodenPier() {
    dbi.Select(JorvikMod, "SmallWoodenPierRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Wooden Pier', 'Object from Jorvik MOD',        32,               18,          60,        2524,               10,                       1,        0,          0,           'yolauncher/modpack/art/2D/Recipes/small_wooden_pier.png') RETURNING ID");
  }
  function JorvikMod::SmallWoodenPierRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  324,                  0,       10,         16,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  326,                  0,       10,         32,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  1356,                  0,       10,         10,       0)");
	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod::SmallWoodenPierT() {
    dbi.Select(JorvikMod, "SmallWoodenPierTRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Wooden Pier T', 'Object from Jorvik MOD',        32,               18,          60,        2525,               10,                       1,        0,          0,           'yolauncher/modpack/art/2D/Recipes/small_wooden_pier_T.png') RETURNING ID");
  }
  function JorvikMod::SmallWoodenPierTRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  324,                  0,       10,         30,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  326,                  0,       10,         64,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  1356,                  0,       10,         20,       0)");
	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod::SmallWoodenPierL() {
    dbi.Select(JorvikMod, "SmallWoodenPierLRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Wooden Pier L', 'Object from Jorvik MOD',        32,               18,          60,        2526,               10,                       1,        0,          0,           'yolauncher/modpack/art/2D/Recipes/small_wooden_pier_L.png') RETURNING ID");
  }
  function JorvikMod::SmallWoodenPierLRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  324,                  0,       10,         30,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  326,                  0,       10,         64,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  1356,                  0,       10,         20,       0)");
	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod::WattleWicket() {
    dbi.Select(JorvikMod, "WattleWicketRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Wattle Wicket', 'Object from Jorvik MOD',        32,               18,          0,        2527,               30,                       1,        0,          0,           'yolauncher/modpack/art/2D/Recipes/wattle_wicket.png') RETURNING ID");
  }
  function JorvikMod::WattleWicketRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  237,                  0,       45,         12,       0)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod::IdolCross() {
    dbi.Select(JorvikMod, "IdolCrossRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Idol Cross', 'Object from Jorvik MOD',        34,               54,          0,        2528,               25,                       1,        0,          0,           'yolauncher/modpack/art/2D/Recipes/idol_cross.png') RETURNING ID");
  }
  function JorvikMod::IdolCrossRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  233,                  0,       10,         2,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  1356,                  0,       10,         2,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  247,                  0,       10,         1,       0)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod::WoodenChurch() {
    dbi.Select(JorvikMod, "WoodenChurchRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Wooden Church', 'Object from Jorvik MOD',        32,               20,          60,        2529,               35,                       1,        0,          0,           'yolauncher/modpack/art/2D/Recipes/wooden_church.png') RETURNING ID");
  }
  function JorvikMod::WoodenChurchRequirements(%this, %resultSet) {
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
  function JorvikMod::SanctumoftheSleeper() {
    dbi.Select(JorvikMod, "SanctumoftheSleeperRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Sanctum of the Sleeper', 'Object from Jorvik MOD',        32,               20,          60,        2530,               35,                       1,        0,          0,           'yolauncher/modpack/art/2D/Recipes/church.png') RETURNING ID");
  }
  function JorvikMod::SanctumoftheSleeperRequirements(%this, %resultSet) {
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
  function JorvikMod::NoviceDecoratorsKit() {
    dbi.Select(JorvikMod, "NoviceDecoratorsKitRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Novice Decorator/'s Kit', 'Object from Jorvik MOD',        293,               8,          90,        2531,               10,                       1,        1,          0,           'yolauncher/modpack/art/2D/Items/decoration_kit_small.png') RETURNING ID");
  }
  function JorvikMod::NoviceDecoratorsKitRequirements(%this, %resultSet) {
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
  }  function JorvikMod::ApprenticeDecoratorsKit() {
    dbi.Select(JorvikMod, "ApprenticeDecoratorsKitRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Apprentice Decorator/'s Kit', 'Object from Jorvik MOD',        293,               8,          90,        2532,               10,                       1,        1,          0,           'yolauncher/modpack/art/2D/Items/decoration_kit_medium.png') RETURNING ID");
  }
  function JorvikMod::ApprenticeDecoratorsKitRequirements(%this, %resultSet) {
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
  }  function JorvikMod::MasterDecoratorsKit() {
    dbi.Select(JorvikMod, "MasterDecoratorsKitRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Master Decorator/'s Kit', 'Object from Jorvik MOD',        293,               8,          90,        2533,               10,                       1,        1,          0,           'yolauncher/modpack/art/2D/Items/decoration_kit_large.png') RETURNING ID");
  }
  function JorvikMod::MasterDecoratorsKitRequirements(%this, %resultSet) {
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
  function JorvikMod::Wolfstand() {
    dbi.Select(JorvikMod, "WolfstandRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Wolf (stand)', 'Object from Jorvik MOD',        2517,                14,          90,        2534,               90,                       1,        0,          0,           'yolauncher/modpack/art/2D/Recipes/wolf.png') RETURNING ID");
  }
  function JorvikMod::WolfstandRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  675,                  0,       10,         2,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  342,                  0,       10,         50,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  1404,                  0,       10,         1,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  428,                  0,       10,         1,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  386,                  0,       10,         100,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  2464,                  0,       10,         1,       0)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod::GoldSheet() {
    dbi.Select(JorvikMod, "GoldSheetRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Gold Sheet', 'Object from Jorvik MOD',        453,               4,          0,        2535,               20,                       1,        1,          0,           'yolauncher/modpack/art/2D/Items/gold_sheet.png') RETURNING ID");
  }
  function JorvikMod::GoldSheetRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  406,                  0,       60,         2,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  1647,                  0,       10,         40,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  453,                  0,       10,         15,       0)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod::MetalScissors() {
    dbi.Select(JorvikMod, "MetalScissorsRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Metal Scissors', 'Object from Jorvik MOD',        453,               4,          0,        2536,               20,                       1,        1,          0,           'yolauncher/modpack/art/2D/Items/scissors.png') RETURNING ID");
  }
  function JorvikMod::MetalScissorsRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  364,                  0,       50,         1,       1)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  1647,                  0,       10,         40,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  453,                  0,       10,         15,       0)");
 
	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod::MetalStamp() {
    dbi.Select(JorvikMod, "MetalStampRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Metal Stamp', 'Object from Jorvik MOD',        453,               4,          0,        2537,               20,                       1,        1,          0,           'yolauncher/modpack/art/2D/Items/metal_stamp.png') RETURNING ID");
  }
  function JorvikMod::MetalStampRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  364,                  0,       50,         1,       1)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  1647,                  0,       10,         40,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  453,                  0,       10,         15,       0)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	

  function JorvikMod::GoldBlanks() {
    dbi.Select(JorvikMod, "GoldBlanksRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Gold Blanks', 'Object from Jorvik MOD',        453,               4,          90,        2538,               90,                       5,        1,          0,           'yolauncher/modpack/art/2D/Items/gold_blanks.png') RETURNING ID");
  }
  function JorvikMod::GoldBlanksRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  2535,                  0,       10,         1,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  2536,                  0,       10,         40,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  453,                  0,       10,         15,       0)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod::SilverSheet() {
    dbi.Select(JorvikMod, "Silver SheetRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Silver Sheet', 'Object from Jorvik MOD',        453,               4,          0,        2539,               20,                       1,        1,          0,           'yolauncher/modpack/art/2D/Items/silver_sheet.png') RETURNING ID");
  }
  function JorvikMod::SilverSheetRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  405,                  0,       60,         2,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  1647,                  0,       10,         40,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  453,                  0,       10,         15,       0)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }
  function JorvikMod::CopperSheet() {
    dbi.Select(JorvikMod, "CopperSheetRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Copper Sheet', 'Object from Jorvik MOD',        453,               4,          0,        2540,               20,                       1,        1,          0,           'yolauncher/modpack/art/2D/Items/copper_sheet.png') RETURNING ID");
  }
  function JorvikMod::CopperSheetRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  403,                  0,       60,         2,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  1647,                  0,       10,         40,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  453,                  0,       10,         15,       0)");



	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod::SilverBlanks() {
    dbi.Select(JorvikMod, "SilverBlanksRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Silver Blanks', 'Object from Jorvik MOD',        453,               4,          90,        2541,               90,                       5,        1,          0,           'yolauncher/modpack/art/2D/Items/silver_blanks.png') RETURNING ID");
  }
  function JorvikMod::SilverBlanksRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  2539,                  0,       10,         1,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  2536,                  0,       10,         40,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  453,                  0,       10,         15,       0)");


	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod::CopperBlanks() {
    dbi.Select(JorvikMod, "CopperBlanksRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Copper Blanks', 'Object from Jorvik MOD',        453,               4,          90,        2542,               90,                       5,        1,          0,           'yolauncher/modpack/art/2D/Items/copper_blanks.png') RETURNING ID");
  }
  function JorvikMod::CopperBlanksRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  2540,                  0,       10,         1,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  2536,                  0,       10,         40,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  453,                  0,       10,         15,       0)");
 

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }
  function JorvikMod::GoldCoins() {
    dbi.Select(JorvikMod, "GoldCoinsRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Gold Coins', 'Object from Jorvik MOD',        453,               4,          100,        1061,               100,                       5,        1,          0,           'yolauncher/modpack/art/2D/Items/gold_coins.png') RETURNING ID");
  }
  function JorvikMod::GoldCoinsRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");

      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  2538,                  0,       50,         5,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  2537,                  0,       10,         40,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  453,                  0,       10,         15,       0)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod::SilverCoins() {
    dbi.Select(JorvikMod, "SilverCoinsRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Silver Coins', 'Object from Jorvik MOD',        453,               4,          100,        1060,               100,                       5,        1,          0,           'yolauncher/modpack/art/2D/Items/silver_coins.png') RETURNING ID");
  }
  function JorvikMod::SilverCoinsRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  2541,                  0,       50,         5,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  2537,                  0,       10,         40,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  453,                  0,       10,         15,       0)");
  
	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod::CopperCoins() {
    dbi.Select(JorvikMod, "CopperCoinsRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Copper Coins', 'Object from Jorvik MOD',        453,               4,          100,        1059,               100,                       5,        1,          0,           'yolauncher/modpack/art/2D/Items/copper_coins.png') RETURNING ID");
  }
  function JorvikMod::CopperCoinsRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  2542,                  0,       50,         5,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  2537,                  0,       10,         40,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  453,                  0,       10,         15,       0)");
	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }  
  

  function serverCmdRequestRules(%client)
  {
      LiFx::debugEcho(JorvikMod.modRoot);
      %file = new FileObject();
      %file.openForRead(JorvikMod.modRoot @ "server_rules.txt");

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
activatePackage(JorvikMod);
