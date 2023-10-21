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
    // Register callback hooks, do not run any form of code that does anything here, just register the hook
	/**
	* LiFx::registerCallback is a global framework function, it takes 3 parameters
    * Parameter 1: The hook to register your function on
    * Parameter 2: Non scoped name of function in your package
    * Parameter 3: The package name to scope your function appropiately.
	*/
    LiFx::registerCallback($LiFx::hooks::onSpawnCallbacks, onSpawn, JorvikMod);

	/**
	* LiFx::registerObjectsTypes is a global framework function, it takes 2 parameters
	* It is used to write to the dump.sql on start, prior to the server reading it, and is necessary as bitbox wipes the objectstypes table on each start up.
    * Parameter 1: The function including scope to your objectstypes definition
    * Parameter 2: The package name of your mod
	*/

    // Buildings
    LiFx::registerObjectsTypes(JorvikMod::ObjectsTypesSmallWoodenShed(), JorvikMod);
    
    LiFx::registerObjectsTypes(JorvikMod::ObjectsTypesFlagPvP(), JorvikMod);
    LiFx::registerObjectsTypes(JorvikMod::ObjectsTypesFlagPvE(), JorvikMod);

    LiFx::registerObjectsTypes(JorvikMod::ObjectsTypesLonghouse(), JorvikMod);
  }

  // Example function references from setup above, this code will execute when the hook is called by the LiFx framework
  function JorvikMod::onSpawn(%this, %client) {
    echo(%this.getName() SPC %client.getName());

  }
  // The function name should match the object you create as a return object inside of the function
  function JorvikMod::ObjectsTypesSmallWoodenShed() {

    // this returns and writes to the dump.sql file for ease of distribution
	// The name of the object should be the same as the function name it registers
	// Each of the variables in the object, corrosponds to the column value in the database
    return new ScriptObject(ObjectsTypesSmallWoodenShed : ObjectsTypes)
    {
      id = 2400; // *UNIQUE INT* Has to be a unique id - grab id from here: https://lifxmod.com/Docs/objects-types-id-list.html
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
    dbi.Select(JorvikMod, "SmallWoodenShedRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Wooden Shed', 'Object from Jorvik MOD',        32,               18,          60,        2400,               25,           1,        0,          0,           'yolauncher/modpack/art/2D/Recipes/small_wooden_shed.png') RETURNING ID");
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
      id = 2403; 
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
    dbi.Select(JorvikMod, "LonghouseRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Longhouse', 'Object from Jorvik MOD',        32,               20,          60,        2403,               20,                       1,        0,          0,           'yolauncher/modpack/art/2D/Recipes/long_house.png') RETURNING ID");
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
    dbi.Select(JorvikMod, "SmallWoodenBridgeRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Stone Gate', 'Object from Jorvik MOD',        32,               18,          60,        2405,               10,                       1,        0,          0,           'yolauncher/modpack/art/2D/Recipes/small_wooden_bridge.png') RETURNING ID");
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
  function JorvikMod::ObjectsTypesSmallStoneBridge() {
                                   //dbi.update("INSERT IGNORE INTO `recipe` VALUES (NULL,      Name,                 Description,      StartingToolsID,   SkillTypeID, SkillLvl, ResultObjectTypeID, SkillDepends,                  Quantity,Autorepeat,isBluePrint,           ImagePath)
    dbi.Select(JorvikMod, "ObjectsTypesSmallStoneBridgeRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Stone Gate', 'Object from Jorvik MOD',        32,               18,          60,        2406,               35,                       0,        0,          0,           'yolauncher/modpack/art/2D/Recipes/small_wooden_bridge.png') RETURNING ID");
  }
  function JorvikMod::ObjectsTypesSmallStoneBridgeRequirements(%this, %resultSet) {
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
      FaceImage = "yolauncher/modpack/";
      Description = "Object from Jorvik MOD"; 
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
  function JorvikMod::ObjectsTypesSmall Wooden Floor() {
    return new ScriptObject(ObjectsTypesSmall Wooden Floor : ObjectsTypes)
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
  function JorvikMod::ObjectsTypesSmall Log Wall Slope Right() {
    return new ScriptObject(ObjectsTypesSmall Log Wall Slope Right : ObjectsTypes)
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
  function JorvikMod::ObjectsTypesSmall Log Wall Slope Left() {
    return new ScriptObject(ObjectsTypesSmall Log Wall Slope Left : ObjectsTypes)
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
  function JorvikMod::ObjectsTypesSmall Thatch Roof() {
    return new ScriptObject(ObjectsTypesSmall Thatch Roof : ObjectsTypes)
    {
      id = 2476; 
      ObjectName = "Small Thatch Roof"; 
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
  function JorvikMod::ObjectsTypesSmall Thatch Roof Right End() {
    return new ScriptObject(ObjectsTypesSmall Thatch Roof Right End : ObjectsTypes)
    {
      id = 2477; 
      ObjectName = "Small Thatch Roof Right End"; 
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
  function JorvikMod::ObjectsTypesSmall Thatch Roof Left End() {
    return new ScriptObject(ObjectsTypesSmall Thatch Roof Left End : ObjectsTypes)
    {
      id = 2478; 
      ObjectName = "Small Thatch Roof Left End"; 
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
  function JorvikMod::ObjectsTypesSmall Thatch Roof Outer Corner() {
    return new ScriptObject(ObjectsTypesSmall Thatch Roof Outer Corner : ObjectsTypes)
    {
      id = 2479; 
      ObjectName = "Small Thatch Roof Outer Corner"; 
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
  function JorvikMod::ObjectsTypesModular Constructions lvl 1() {
    return new ScriptObject(ObjectsTypesModular Constructions lvl 1 : ObjectsTypes)
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
      FaceImage = "yolauncher/modpack/";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 10; 
      OwnerTimeout = NULL; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod::ObjectsTypesSmall Log Wall() {
    return new ScriptObject(ObjectsTypesSmall Log Wall : ObjectsTypes)
    {
      id = 2481; 
      ObjectName = "Small Log Wall"; 
      ParentID = 2427; 
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
  function JorvikMod::ObjectsTypesSmall Wooden Pillar() {
    return new ScriptObject(ObjectsTypesSmall Wooden Pillar : ObjectsTypes)
    {
      id = 2482; 
      ObjectName = "Small Wooden Pillar"; 
      ParentID = 2427; 
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
  function JorvikMod::ObjectsTypesSmall Log Corner Wall() {
    return new ScriptObject(ObjectsTypesSmall Log Corner Wall : ObjectsTypes)
    {
      id = 2483; 
      ObjectName = "Small Log Corner Wall"; 
      ParentID = 2427; 
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
  function JorvikMod::ObjectsTypesSmall Log Wall With Window() {
    return new ScriptObject(ObjectsTypesSmall Log Wall With Window : ObjectsTypes)
    {
      id = 2484; 
      ObjectName = "Small Log Wall With Window"; 
      ParentID = 2427; 
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
  function JorvikMod::ObjectsTypesSmall Log Wall With Shutters() {
    return new ScriptObject(ObjectsTypesSmall Log Wall With Shutters : ObjectsTypes)
    {
      id = 2485; 
      ObjectName = "Small Log Wall With Shutters"; 
      ParentID = 2427; 
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
  function JorvikMod::ObjectsTypesSmall Log Wall With Entrance() {
    return new ScriptObject(ObjectsTypesSmall Log Wall With Entrance : ObjectsTypes)
    {
      id = 2486; 
      ObjectName = "Small Log Wall With Entrance"; 
      ParentID = 2427; 
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
  function JorvikMod::ObjectsTypesSmall Log Wall With Door() {
    return new ScriptObject(ObjectsTypesSmall Log Wall With Door : ObjectsTypes)
    {
      id = 2487; 
      ObjectName = "Small Log Wall With Door"; 
      ParentID = 2427; 
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
  function JorvikMod::ObjectsTypesSmall Wooden Floor Entrance() {
    return new ScriptObject(ObjectsTypesSmall Wooden Floor Entrance : ObjectsTypes)
    {
      id = 2488; 
      ObjectName = "Small Wooden Floor Entrance"; 
      ParentID = 2427; 
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
  function JorvikMod::ObjectsTypesSmall Wooden Floor() {
    return new ScriptObject(ObjectsTypesSmall Wooden Floor : ObjectsTypes)
    {
      id = 2489; 
      ObjectName = "Small Wooden Floor"; 
      ParentID = 2427; 
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
  function JorvikMod::ObjectsTypesSmall Wooden Stairs() {
    return new ScriptObject(ObjectsTypesSmall Wooden Stairs : ObjectsTypes)
    {
      id = 2490; 
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
  function JorvikMod::ObjectsTypesSmall Thatch Roof Top() {
    return new ScriptObject(ObjectsTypesSmall Thatch Roof Top : ObjectsTypes)
    {
      id = 2491; 
      ObjectName = "Small Thatch Roof Top"; 
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
  function JorvikMod::ObjectsTypesSmall Thatch Roof Outer Corner Top() {
    return new ScriptObject(ObjectsTypesSmall Thatch Roof Outer Corner Top : ObjectsTypes)
    {
      id = 2492; 
      ObjectName = "Small Thatch Roof Outer Corner Top"; 
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
  function JorvikMod::ObjectsTypesSmall Thatch Roof Top Left End() {
    return new ScriptObject(ObjectsTypesSmall Thatch Roof Top Left End : ObjectsTypes)
    {
      id = 2493; 
      ObjectName = "Small Thatch Roof Top Left End"; 
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
  function JorvikMod::ObjectsTypesSmall Thatch Roof Top Right End() {
    return new ScriptObject(ObjectsTypesSmall Thatch Roof Top Right End : ObjectsTypes)
    {
      id = 2494; 
      ObjectName = "Small Thatch Roof Top Right End"; 
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
  function JorvikMod::ObjectsTypesSmall Thatch Roof() {
    return new ScriptObject(ObjectsTypesSmall Thatch Roof : ObjectsTypes)
    {
      id = 2495; 
      ObjectName = "Small Thatch Roof"; 
      ParentID = 2427; 
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
  function JorvikMod::ObjectsTypesSmall Thatch Roof Outer Corner() {
    return new ScriptObject(ObjectsTypesSmall Thatch Roof Outer Corner : ObjectsTypes)
    {
      id = 2496; 
      ObjectName = "Small Thatch Roof Outer Corner"; 
      ParentID = 2427; 
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
  function JorvikMod::ObjectsTypesSmall Wooden Railing() {
    return new ScriptObject(ObjectsTypesSmall Wooden Railing : ObjectsTypes)
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
  function JorvikMod::ObjectsTypesSmall Wooden Railing() {
    return new ScriptObject(ObjectsTypesSmall Wooden Railing : ObjectsTypes)
    {
      id = 2498; 
      ObjectName = "Small Wooden Railing"; 
      ParentID = 2427; 
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
  function JorvikMod::ObjectsTypesSmall Thatch Roof Outer Corner() {
    return new ScriptObject(ObjectsTypesSmall Thatch Roof Outer Corner : ObjectsTypes)
    {
      id = 2499; 
      ObjectName = "Small Thatch Roof Outer Corner"; 
      ParentID = 2427; 
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
  function JorvikMod::ObjectsTypesWall Torch() {
    return new ScriptObject(ObjectsTypesWall Torch : ObjectsTypes)
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
(2501,1902,'Wall Torch',0,0,0,0,0,0,0,0,3,1,1000,'',0,0,0,0,0,0,'mod/JorvikMod/art/2D/Recipes/wall_torch.png','Object from Jorvik MOD',NULL,NULL,0,0),
  function JorvikMod::ObjectsTypesSmall Candle() {
    return new ScriptObject(ObjectsTypesSmall Candle : ObjectsTypes)
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
(2503,1902,'Small Candle',0,0,0,0,0,0,0,0,3,1,1000,'',0,0,0,0,0,0,'mod/JorvikMod/art/2D/Recipes/small_candle.png','Object from Jorvik MOD',NULL,NULL,0,0),
  function JorvikMod::ObjectsTypesAurochs Cow (stand)() {
    return new ScriptObject(ObjectsTypesAurochs Cow (stand) : ObjectsTypes)
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
  function JorvikMod::ObjectsTypesAurochs Cow (eat)() {
    return new ScriptObject(ObjectsTypesAurochs Cow (eat) : ObjectsTypes)
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
      FaceImage = "yolauncher/modpack/art/2D\Recipes/aurochs_cow.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod::ObjectsTypesAurochs Cow (sleep)() {
    return new ScriptObject(ObjectsTypesAurochs Cow (sleep) : ObjectsTypes)
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
(2507,1902,'Small Wooden Stairs',0,1,0,0,0,0,0,0,0,0,5000,'',0,0,0,0,0,0,'mod/JorvikMod/art/2D/Objects/small_wooden_stairs.png','Object from Jorvik MOD',NULL,NULL,0,0),
  function JorvikMod::ObjectsTypesSow (stand)() {
    return new ScriptObject(ObjectsTypesSow (stand) : ObjectsTypes)
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
  function JorvikMod::ObjectsTypesSow (eat)() {
    return new ScriptObject(ObjectsTypesSow (eat) : ObjectsTypes)
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
  function JorvikMod::ObjectsTypesSow (sleep)() {
    return new ScriptObject(ObjectsTypesSow (sleep) : ObjectsTypes)
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
  function JorvikMod::ObjectsTypesHorse (stand)() {
    return new ScriptObject(ObjectsTypesHorse (stand) : ObjectsTypes)
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
  function JorvikMod::ObjectsTypesHorse (eat)() {
    return new ScriptObject(ObjectsTypesHorse (eat) : ObjectsTypes)
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
  function JorvikMod::ObjectsTypesHorse (sleep)() {
    return new ScriptObject(ObjectsTypesHorse (sleep) : ObjectsTypes)
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
  function JorvikMod::ObjectsTypesSlave (working)() {
    return new ScriptObject(ObjectsTypesSlave (working) : ObjectsTypes)
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
  function JorvikMod::ObjectsTypesWranen the Hunter (stand)() {
    return new ScriptObject(ObjectsTypesWranen the Hunter (stand) : ObjectsTypes)
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
  function JorvikMod::ObjectsTypesBook Paper() {
    return new ScriptObject(ObjectsTypesBook Paper : ObjectsTypes)
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
  function JorvikMod::ObjectsTypesHealth Book() {
    return new ScriptObject(ObjectsTypesHealth Book : ObjectsTypes)
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
  function JorvikMod::ObjectsTypesSmall Thatch Roof Inner Corner() {
    return new ScriptObject(ObjectsTypesSmall Thatch Roof Inner Corner : ObjectsTypes)
    {
      id = 2518; 
      ObjectName = "Small Thatch Roof Inner Corner"; 
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
  function JorvikMod::ObjectsTypesWood Cart() {
    return new ScriptObject(ObjectsTypesWood Cart : ObjectsTypes)
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
  function JorvikMod::ObjectsTypesSiege Tower() {
    return new ScriptObject(ObjectsTypesSiege Tower : ObjectsTypes)
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
  function JorvikMod::ObjectsTypesAurochs Bull (stand)() {
    return new ScriptObject(ObjectsTypesAurochs Bull (stand) : ObjectsTypes)
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
  function JorvikMod::ObjectsTypesAurochs Bull (eat)() {
    return new ScriptObject(ObjectsTypesAurochs Bull (eat) : ObjectsTypes)
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
      FaceImage = "yolauncher/modpack/art/2D\Recipes/aurochs_bull.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod::ObjectsTypesAurochs Bull (sleep)() {
    return new ScriptObject(ObjectsTypesAurochs Bull (sleep) : ObjectsTypes)
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
  function JorvikMod::ObjectsTypesSmall Wooden Pier() {
    return new ScriptObject(ObjectsTypesSmall Wooden Pier : ObjectsTypes)
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
  function JorvikMod::ObjectsTypesSmall Wooden Pier T() {
    return new ScriptObject(ObjectsTypesSmall Wooden Pier T : ObjectsTypes)
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
  function JorvikMod::ObjectsTypesSmall Wooden Pier L() {
    return new ScriptObject(ObjectsTypesSmall Wooden Pier L : ObjectsTypes)
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
  function JorvikMod::ObjectsTypesWattle Wicket() {
    return new ScriptObject(ObjectsTypesWattle Wicket : ObjectsTypes)
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
  function JorvikMod::ObjectsTypesIdol Cross() {
    return new ScriptObject(ObjectsTypesIdol Cross : ObjectsTypes)
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
  function JorvikMod::ObjectsTypesWooden Church() {
    return new ScriptObject(ObjectsTypesWooden Church : ObjectsTypes)
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
  function JorvikMod::ObjectsTypesSanctum of the Sleeper() {
    return new ScriptObject(ObjectsTypesSanctum of the Sleeper : ObjectsTypes)
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
    return new ScriptObject(ObjectsTypesMetal Scissors : ObjectsTypes)
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
    return new ScriptObject(ObjectsTypesMetal Stamp : ObjectsTypes)
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
    return new ScriptObject(ObjectsTypesGold Blanks : ObjectsTypes)
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
    dbi.Select(JorvikMod, "LargeWoodenBridgeRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Large Wooden Bridge', 'Object from Jorvik MOD',        32,               18,          60,        2407,               10,                       1,        0,          0,           'yolauncher/modpack/mod\JorvikMod\art\2D\Recipes\large_wooden_bridge.png') RETURNING ID");
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
    dbi.Select(JorvikMod, "LargeStoneBridgeRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Large Stone Bridge', 'Object from Jorvik MOD',        32,               19,          60,        2408,               35,                       1,        0,          0,           'yolauncher/modpack/mod\JorvikMod\art\2D\Recipes\large_stone_bridge.png') RETURNING ID");
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
    dbi.Select(JorvikMod, "LargeStoneBridgeEndRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Large Stone Bridge End', 'Object from Jorvik MOD',        32,               19,          60,        2409,               35,                       1,        0,          0,           'yolauncher/modpack/mod\JorvikMod\art\2D\Recipes\large_stone_bridge_end.png') RETURNING ID");
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
    dbi.Select(JorvikMod, "SmallStoneBridgeEndRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Stone Bridge End', 'Object from Jorvik MOD',        32,               19,          60,        2410,               35,                       1,        0,          0,           'yolauncher/modpack/mod\JorvikMod\art\2D\Recipes\small_stone_bridge_end.png') RETURNING ID");
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
    dbi.Select(JorvikMod, "SmallLogWallRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Log Wall', 'Object from Jorvik MOD',        32,               18,          30,        2412,               35,                       1,        0,          0,           'yolauncher/modpack/mod\JorvikMod\art\2D\Recipes\small_log_wall.png') RETURNING ID");
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
    dbi.Select(JorvikMod, "SmallWoodenPillarRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Wooden Pillar', 'Object from Jorvik MOD',        32,               18,          30,        2413,               35,                       1,        0,          0,           'yolauncher/modpack/mod\JorvikMod\art\2D\Recipes\small_wooden_pillar.png') RETURNING ID");
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
    dbi.Select(JorvikMod, "SmallLogCornerWallRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Log Corner Wall', 'Object from Jorvik MOD',        32,               18,          30,        2414,               35,                       1,        0,          0,           'yolauncher/modpack/mod\JorvikMod\art\2D\Recipes\small_log_corner_wall.png') RETURNING ID");
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
    dbi.Select(JorvikMod, "SmallLogWallWithWindowRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Log Wall With Window', 'Object from Jorvik MOD',        32,               18,          30,        2415,               35,                       1,        0,          0,           'yolauncher/modpack/mod\JorvikMod\art\2D\Recipes\small_log_wall_with_window.png') RETURNING ID");
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
    dbi.Select(JorvikMod, "SmallLogWallWithShuttersRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Log Wall With Shutters', 'Object from Jorvik MOD',        32,               18,          30,        2416,               35,                       1,        0,          0,           'yolauncher/modpack/mod\JorvikMod\art\2D\Recipes\small_log_wall_with_shutters.png') RETURNING ID");
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
    dbi.Select(JorvikMod, "SmallLogWallWithEntranceRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Log Wall With Entrance', 'Object from Jorvik MOD',        32,               18,          30,        2417,               35,                       1,        0,          0,           'yolauncher/modpack/mod\JorvikMod\art\2D\Recipes\small_log_wall_with_entrance.png') RETURNING ID");
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
    dbi.Select(JorvikMod, "SmallLogWallWithDoorRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Log Wall With Door', 'Object from Jorvik MOD',        32,               18,          30,        2418,               35,                       1,        0,          0,           'yolauncher/modpack/mod\JorvikMod\art\2D\Recipes\small_log_wall_with_door.png') RETURNING ID");
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
    dbi.Select(JorvikMod, "SmallWoodenFloorEntranceRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Wooden Floor Entrance', 'Object from Jorvik MOD',        32,               18,          30,        2419,               35,                       1,        0,          0,           'yolauncher/modpack/mod\JorvikMod\art\2D\Recipes\small_wooden_floor_entrance.png') RETURNING ID");
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
    dbi.Select(JorvikMod, "SmallWoodenFloorRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Wooden Floor', 'Object from Jorvik MOD',        32,               18,          30,        2473,               35,                       1,        0,          0,           'yolauncher/modpack/mod\JorvikMod\art\2D\Recipes\small_wooden_floor.png') RETURNING ID");
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
    dbi.Select(JorvikMod, "SmallLogWallSlopeRightRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Log Wall Slope Right', 'Object from Jorvik MOD',        32,               18,          30,        2474,               35,                       1,        0,          0,           'yolauncher/modpack/mod\JorvikMod\art\2D\Recipes\small_log_wall_slope_right.png') RETURNING ID");
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
    dbi.Select(JorvikMod, "SmallLogWallSlopeLeftRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Log Wall Slope Left', 'Object from Jorvik MOD',        32,               18,          30,        2475,               35,                       1,        0,          0,           'yolauncher/modpack/mod\JorvikMod\art\2D\Recipes\small_log_wall_slope_left.png') RETURNING ID");
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
    dbi.Select(JorvikMod, "SmallThatchRoofRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Thatch Roof', 'Object from Jorvik MOD',        32,               18,          30,        2476,               35,                       1,        0,          0,           'yolauncher/modpack/mod\JorvikMod\art\2D\Recipes\small_thatch_roof.png') RETURNING ID");
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
    dbi.Select(JorvikMod, "SmallThatchRoofRightEndRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Thatch Roof Right End', 'Object from Jorvik MOD',        32,               18,          30,        2477,               35,                       1,        0,          0,           'yolauncher/modpack/mod\JorvikMod\art\2D\Recipes\small_thatch_roof_right_end.png') RETURNING ID");
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
    dbi.Select(JorvikMod, "SmallThatchRoofLeftEndRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Thatch Roof Left End', 'Object from Jorvik MOD',        32,               18,          30,        2478,               35,                       1,        0,          0,           'yolauncher/modpack/mod\JorvikMod\art\2D\Recipes\small_thatch_roof_left_end.png') RETURNING ID");
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
  }  function JorvikMod::SmallThatchRoofOuterCorner() {
    dbi.Select(JorvikMod, "SmallThatchRoofOuterCornerRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Thatch Roof Outer Corner', 'Object from Jorvik MOD',        32,               18,          30,        2479,               35,                       1,        0,          0,           'yolauncher/modpack/mod\JorvikMod\art\2D\Recipes\small_thatch_roof_outer_corner.png') RETURNING ID");
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
  }  function JorvikMod::SmallLogWall() {
    dbi.Select(JorvikMod, "SmallLogWallRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Log Wall', 'Object from Jorvik MOD',        32,               18,          30,        2481,               35,                       1,        0,          0,           'yolauncher/modpack/mod\JorvikMod\art\2D\Recipes\small_log_wall_lvl1.png') RETURNING ID");
  }
  function JorvikMod::SmallLogWallRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  233,                  0,       10,         2,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  234,                  0,       10,         15,       0)");
	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }  function JorvikMod::SmallWoodenPillar() {
    dbi.Select(JorvikMod, "SmallWoodenPillarRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Wooden Pillar', 'Object from Jorvik MOD',        32,               18,          30,        2482,               35,                       1,        0,          0,           'yolauncher/modpack/mod\JorvikMod\art\2D\Recipes\small_wooden_pillar_lvl1.png') RETURNING ID");
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
    dbi.Select(JorvikMod, "SmallLogCornerWallRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Log Corner Wall', 'Object from Jorvik MOD',        32,               18,          30,        2483,               35,                       1,        0,          0,           'yolauncher/modpack/mod\JorvikMod\art\2D\Recipes\small_log_corner_wall_lvl1.png') RETURNING ID");
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
    dbi.Select(JorvikMod, "SmallLogWallWithWindowRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Log Wall With Window', 'Object from Jorvik MOD',        32,               18,          30,        2484,               35,                       1,        0,          0,           'yolauncher/modpack/mod\JorvikMod\art\2D\Recipes\small_log_wall_with_window_lvl1.png') RETURNING ID");
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
    dbi.Select(JorvikMod, "SmallLogWallWithShuttersRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Log Wall With Shutters', 'Object from Jorvik MOD',        32,               18,          30,        2485,               35,                       1,        0,          0,           'yolauncher/modpack/mod\JorvikMod\art\2D\Recipes\small_log_wall_with_shutters_lvl1.png') RETURNING ID");
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
    dbi.Select(JorvikMod, "SmallLogWallWithEntranceRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Log Wall With Entrance', 'Object from Jorvik MOD',        32,               18,          30,        2486,               35,                       1,        0,          0,           'yolauncher/modpack/mod\JorvikMod\art\2D\Recipes\small_log_wall_with_entrance_lvl1.png') RETURNING ID");
  }
  function JorvikMod::SmallLogWallWithEntranceRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  233,                  0,       10,         4,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  1356,                  0,       10,         4,       0)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod::SmallLogWallWithDoor() {
    dbi.Select(JorvikMod, "SmallLogWallWithDoorRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Log Wall With Door', 'Object from Jorvik MOD',        32,               18,          30,        2487,               35,                       1,        0,          0,           'yolauncher/modpack/mod\JorvikMod\art\2D\Recipes\small_log_wall_with_door_lvl1.png') RETURNING ID");
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
    dbi.Select(JorvikMod, "SmallWoodenFloorEntranceRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Wooden Floor Entrance', 'Object from Jorvik MOD',        32,               18,          30,        2488,               35,                       1,        0,          0,           'yolauncher/modpack/mod\JorvikMod\art\2D\Recipes\small_wooden_floor_entrance_lvl1.png') RETURNING ID");
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
    dbi.Select(JorvikMod, "SmallWoodenFloorRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Wooden Floor', 'Object from Jorvik MOD',        32,               18,          30,        2489,               35,                       1,        0,          0,           'yolauncher/modpack/mod\JorvikMod\art\2D\Recipes\small_wooden_floor_lvl1.png') RETURNING ID");
  }
  function JorvikMod::SmallWoodenFloorRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  235,                  0,       10,         5,       0)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod::SmallWoodenStairs() {
    dbi.Select(JorvikMod, "SmallWoodenStairsRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Wooden Stairs', 'Object from Jorvik MOD',        32,               18,          30,        2490,               35,                       1,        0,          0,           'yolauncher/modpack/mod\JorvikMod\art\2D\Recipes\small_wooden_stairs.png') RETURNING ID");
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
    dbi.Select(JorvikMod, "SmallThatchRoofTopRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Thatch Roof Top', 'Object from Jorvik MOD',        32,               18,          30,        2491,               35,                       1,        0,          0,           'yolauncher/modpack/mod\JorvikMod\art\2D\Recipes\small_thatch_roof_top.png') RETURNING ID");
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
    dbi.Select(JorvikMod, "SmallThatchRoofOuterCornerTopRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Thatch Roof Outer Corner Top', 'Object from Jorvik MOD',        32,               18,          30,        2492,               35,                       1,        0,          0,           'yolauncher/modpack/mod\JorvikMod\art\2D\Recipes\small_thatch_roof_outer_corner_top.png') RETURNING ID");
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
    dbi.Select(JorvikMod, "SmallThatchRoofTopLeftEndRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Thatch Roof Top Left End', 'Object from Jorvik MOD',        32,               18,          30,        2493,               35,                       1,        0,          0,           'yolauncher/modpack/mod\JorvikMod\art\2D\Recipes\small_thatch_roof_top_left_end.png') RETURNING ID");
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
    dbi.Select(JorvikMod, "SmallThatchRoofTopRightEndRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Thatch Roof Top Right End', 'Object from Jorvik MOD',        32,               18,          30,        2494,               35,                       1,        0,          0,           'yolauncher/modpack/mod\JorvikMod\art\2D\Recipes\small_thatch_roof_top_right_end.png') RETURNING ID");
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
  function JorvikMod::SmallThatchRoof() {
    dbi.Select(JorvikMod, "SmallThatchRoofRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Thatch Roof', 'Object from Jorvik MOD',        32,               18,          30,        2495,               35,                       1,        0,          0,           'yolauncher/modpack/mod\JorvikMod\art\2D\Recipes\small_thatch_roof.png') RETURNING ID");
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
  function JorvikMod::SmallThatchRoofOuterCorner() {
    dbi.Select(JorvikMod, "SmallThatchRoofOuterCornerRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Thatch Roof Outer Corner', 'Object from Jorvik MOD',        32,               18,          30,        2496,               35,                       1,        0,          0,           'yolauncher/modpack/mod\JorvikMod\art\2D\Recipes\small_thatch_roof_outer_corner.png') RETURNING ID");
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
  }	
  function JorvikMod::SmallWoodenRailing() {
    dbi.Select(JorvikMod, "SmallWoodenRailingRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Wooden Railing', 'Object from Jorvik MOD',        32,               18,          30,        2497,               35,                       1,        0,          0,           'yolauncher/modpack/mod\JorvikMod\art\2D\Recipes\small_wooden_railing.png') RETURNING ID");
  }
  function JorvikMod::SmallWoodenRailingRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  235,                  0,       10,         5,       0)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod::SmallWoodenRailing() {
    dbi.Select(JorvikMod, "SmallWoodenRailingRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Wooden Railing', 'Object from Jorvik MOD',        32,               18,          30,        2498,               35,                       1,        0,          0,           'yolauncher/modpack/mod\JorvikMod\art\2D\Recipes\small_wooden_railing_lvl1.png') RETURNING ID");
  }
  function JorvikMod::SmallWoodenRailingRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  235,                  0,       10,         5,       0)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod::SmallThatchRoofOuterCornerTop() {
    dbi.Select(JorvikMod, "SmallThatchRoofOuterCornerTopRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Thatch Roof Outer Corner Top', 'Object from Jorvik MOD',        32,               18,          30,        2499,               35,                       1,        0,          0,           'yolauncher/modpack/mod\JorvikMod\art\2D\Recipes\small_thatch_roof_outer_corner_top.png') RETURNING ID");
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
  function JorvikMod::WallTorch() {
    dbi.Select(JorvikMod, "WallTorchRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Wall Torch', 'Object from Jorvik MOD',        0,               62,          0,        2500,               10,                       1,        0,          0,           'yolauncher/modpack/mod\JorvikMod\art\2D\Recipes\wall_torch.png') RETURNING ID");
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
    dbi.Select(JorvikMod, "SmallCandleRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Candle', 'Object from Jorvik MOD',        0,               62,          0,        2502 ,               10,                       1,        0,          0,           'yolauncher/modpack/mod\JorvikMod\art\2D\Recipes\small_candle.png') RETURNING ID");
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
    dbi.Select(JorvikMod, "AurochsCowstandRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Aurochs Cow (stand)', 'Object from Jorvik MOD',        2517,                14,          90,        2504,               90,                       1,        0,          0,           'yolauncher/modpack/mod\JorvikMod\art\2D\Recipes\aurochs_cow.png') RETURNING ID");
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
    dbi.Select(JorvikMod, "AurochsCoweatRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Aurochs Cow (eat)', 'Object from Jorvik MOD',        2517,                14,          90,        2505,               90,                       1,        0,          0,           'yolauncher/modpack/mod\JorvikMod\art\2D\Recipes\aurochs_cow.png') RETURNING ID");
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
    dbi.Select(JorvikMod, "AurochsCowsleepRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Aurochs Cow (sleep)', 'Object from Jorvik MOD',        2517,                14,          90,        2506,               90,                       1,        0,          0,           'yolauncher/modpack/mod\JorvikMod\art\2D\Recipes\aurochs_cow.png') RETURNING ID");
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
    dbi.Select(JorvikMod, "SowstandRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Sow (stand)', 'Object from Jorvik MOD',        2517,                14,          90,        2508,               90,                       1,        0,          0,           'yolauncher/modpack/mod\JorvikMod\art\2D\Recipes\sow.png') RETURNING ID");
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
    dbi.Select(JorvikMod, "SoweatRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Sow (eat)', 'Object from Jorvik MOD',        2517,                14,          90,        2509,               90,                       1,        0,          0,           'yolauncher/modpack/mod\JorvikMod\art\2D\Recipes\sow.png') RETURNING ID");
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
    dbi.Select(JorvikMod, "SowsleepRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Sow (sleep)', 'Object from Jorvik MOD',        2517,                14,          90,        2510,               90,                       1,        0,          0,           'yolauncher/modpack/mod\JorvikMod\art\2D\Recipes\sow.png') RETURNING ID");
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
    dbi.Select(JorvikMod, "HorsestandRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Horse (stand)', 'Object from Jorvik MOD',        2517,                14,          90,        2510,               90,                       1,        0,          0,           'yolauncher/modpack/mod\JorvikMod\art\2D\Recipes\horse.png') RETURNING ID");
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
    dbi.Select(JorvikMod, "HorseeatRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Horse (eat)', 'Object from Jorvik MOD',        2517,                14,          90,        2512,               90,                       1,        0,          0,           'yolauncher/modpack/mod\JorvikMod\art\2D\Recipes\horse.png') RETURNING ID");
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
    dbi.Select(JorvikMod, "HorsesleepRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Horse (sleep)', 'Object from Jorvik MOD',        2517,                14,          90,        2513,               90,                       1,        0,          0,           'yolauncher/modpack/mod\JorvikMod\art\2D\Recipes\horse.png') RETURNING ID");
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
    dbi.Select(JorvikMod, "SlaveworkingRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Slave (working)', 'Object from Jorvik MOD',        2517,                14,          90,        2514,               90,                       1,        0,          0,           'yolauncher/modpack/mod\JorvikMod\art\2D\Recipes\slave.png') RETURNING ID");
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
    dbi.Select(JorvikMod, "WranentheHunterstandRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Wranen the Hunter (stand)', 'Object from Jorvik MOD',        2517,                14,          90,        2515,               90,                       1,        0,          0,           'yolauncher/modpack/mod\JorvikMod\art\2D\Recipes\wranen_the_hunter.png') RETURNING ID");
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
    dbi.Select(JorvikMod, "BookPaperRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Book Paper', 'Object from Jorvik MOD',        293,               8,          90,        2516,               10,                       1,        1,          0,           'yolauncher/modpack/mod\JorvikMod\art\2D\Items\paper.png') RETURNING ID");
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
    dbi.Select(JorvikMod, "HealthBookRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Health Book', 'Object from Jorvik MOD',        293,               8,          90,        2517,               10,                       1,        1,          0,           'yolauncher/modpack/mod\JorvikMod\art\2D\Items\health_book.png') RETURNING ID");
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
    dbi.Select(JorvikMod, "SmallThatchRoofInnerCornerRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Thatch Roof Inner Corner', 'Object from Jorvik MOD',        32,               18,          30,        2518,               35,                       1,        0,          0,           'yolauncher/modpack/mod\JorvikMod\art\2D\Recipes\small_thatch_roof_inner_corner.png') RETURNING ID");
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
    dbi.Select(JorvikMod, "WoodCartRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Wood Cart', 'Object from Jorvik MOD',        36,               8,          90,        2519,               30,                       1,        0,          0,           'yolauncher/modpack/mod\JorvikMod\art\2D\Recipes\wood_cart.png') RETURNING ID");
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
    dbi.Select(JorvikMod, "SiegeTowerRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Siege Tower', 'Object from Jorvik MOD',        36,               10,          0,        2520,               30,                       1,        0,          0,           'yolauncher/modpack/mod\JorvikMod\art\2D\Recipes\siegetower.png') RETURNING ID");
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
    dbi.Select(JorvikMod, "AurochsBullstandRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Aurochs Bull (stand)', 'Object from Jorvik MOD',        2517,                14,          90,        2521,               90,                       1,        0,          0,           'yolauncher/modpack/mod\JorvikMod\art\2D\Recipes\aurochs_bull.png') RETURNING ID");
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
    dbi.Select(JorvikMod, "AurochsBulleatRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Aurochs Bull (eat)', 'Object from Jorvik MOD',        2517,                14,          90,        2522,               90,                       1,        0,          0,           'yolauncher/modpack/mod\JorvikMod\art\2D\Recipes\aurochs_bull.png') RETURNING ID");
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
    dbi.Select(JorvikMod, "AurochsBullsleepRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Aurochs Bull (sleep)', 'Object from Jorvik MOD',        2517,                14,          90,        2523,               90,                       1,        0,          0,           'yolauncher/modpack/mod\JorvikMod\art\2D\Recipes\aurochs_bull.png') RETURNING ID");
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
    dbi.Select(JorvikMod, "SmallWoodenPierRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Wooden Pier', 'Object from Jorvik MOD',        32,               18,          60,        2524,               10,                       1,        0,          0,           'yolauncher/modpack/mod\JorvikMod\art\2D\Recipes\small_wooden_pier.png') RETURNING ID");
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
    dbi.Select(JorvikMod, "SmallWoodenPierTRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Wooden Pier T', 'Object from Jorvik MOD',        32,               18,          60,        2525,               10,                       1,        0,          0,           'yolauncher/modpack/mod\JorvikMod\art\2D\Recipes\small_wooden_pier_T.png') RETURNING ID");
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
    dbi.Select(JorvikMod, "SmallWoodenPierLRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Small Wooden Pier L', 'Object from Jorvik MOD',        32,               18,          60,        2526,               10,                       1,        0,          0,           'yolauncher/modpack/mod\JorvikMod\art\2D\Recipes\small_wooden_pier_L.png') RETURNING ID");
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
    dbi.Select(JorvikMod, "WattleWicketRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Wattle Wicket', 'Object from Jorvik MOD',        32,               18,          0,        2527,               30,                       1,        0,          0,           'yolauncher/modpack/mod\JorvikMod\art\2D\Recipes\wattle_wicket.png') RETURNING ID");
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
    dbi.Select(JorvikMod, "IdolCrossRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Idol Cross', 'Object from Jorvik MOD',        34,               54,          0,        2528,               25,                       1,        0,          0,           'yolauncher/modpack/mod\JorvikMod\art\2D\Recipes\idol_cross.png') RETURNING ID");
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
    dbi.Select(JorvikMod, "WoodenChurchRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Wooden Church', 'Object from Jorvik MOD',        32,               20,          60,        2529,               35,                       1,        0,          0,           'yolauncher/modpack/mod\JorvikMod\art\2D\Recipes\wooden_church.png') RETURNING ID");
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
    dbi.Select(JorvikMod, "SanctumoftheSleeperRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Sanctum of the Sleeper', 'Object from Jorvik MOD',        32,               20,          60,        2530,               35,                       1,        0,          0,           'yolauncher/modpack/art\2D\Recipes\church.png') RETURNING ID");
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
    dbi.Select(JorvikMod, "NoviceDecoratorsKitRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Novice Decorator\'s Kit', 'Object from Jorvik MOD',        293,               8,          90,        2531,               10,                       1,        1,          0,           'yolauncher/modpack/art\2D\Items\decoration_kit_small.png') RETURNING ID");
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
    dbi.Select(JorvikMod, "ApprenticeDecoratorsKitRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Apprentice Decorator\'s Kit', 'Object from Jorvik MOD',        293,               8,          90,        2532,               10,                       1,        1,          0,           'yolauncher/modpack/art\2D\Items\decoration_kit_medium.png') RETURNING ID");
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
    dbi.Select(JorvikMod, "MasterDecoratorsKitRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Master Decorator\'s Kit', 'Object from Jorvik MOD',        293,               8,          90,        2533,               10,                       1,        1,          0,           'yolauncher/modpack/art\2D\Items\decoration_kit_large.png') RETURNING ID");
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
    dbi.Select(JorvikMod, "WolfstandRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Wolf (stand)', 'Object from Jorvik MOD',        2517,                14,          90,        2534,               90,                       1,        0,          0,           'yolauncher/modpack/mod\JorvikMod\art\2D\Recipes\wolf.png') RETURNING ID");
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
    dbi.Select(JorvikMod, "GoldSheetRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Gold Sheet', 'Object from Jorvik MOD',        453,               4,          0,        2535,               20,                       1,        1,          0,           'yolauncher/modpack/mod\JorvikMod\art\2D\Items\gold_sheet.png') RETURNING ID");
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
    dbi.Select(JorvikMod, "MetalScissorsRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Metal Scissors', 'Object from Jorvik MOD',        453,               4,          0,        2536,               20,                       1,        1,          0,           'yolauncher/modpack/mod\JorvikMod\art\2D\Items\scissors.png') RETURNING ID");
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
    dbi.Select(JorvikMod, "MetalStampRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Metal Stamp', 'Object from Jorvik MOD',        453,               4,          0,        2537,               20,                       1,        1,          0,           'yolauncher/modpack/mod\JorvikMod\art\2D\Items\metal_stamp.png') RETURNING ID");
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
    dbi.Select(JorvikMod, "GoldBlanksRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Gold Blanks', 'Object from Jorvik MOD',        453,               4,          90,        2538,               90,                       5,        1,          0,           'yolauncher/modpack/mod\JorvikMod\art\2D\Items\gold_blanks.png') RETURNING ID");
  }
  function JorvikMod::GoldBlanksRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  2482,                  0,       10,         1,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  2483,                  0,       10,         40,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  453,                  0,       10,         15,       0)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod::SilverSheet() {
    dbi.Select(JorvikMod, "Silver SheetRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Silver Sheet', 'Object from Jorvik MOD',        453,               4,          0,        2539,               20,                       1,        1,          0,           'yolauncher/modpack/mod\JorvikMod\art\2D\Items\silver_sheet.png') RETURNING ID");
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
    dbi.Select(JorvikMod, "CopperSheetRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Copper Sheet', 'Object from Jorvik MOD',        453,               4,          0,        2540,               20,                       1,        1,          0,           'yolauncher/modpack/mod\JorvikMod\art\2D\Items\copper_sheet.png') RETURNING ID");
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
  function JorvikMod::Silver Blanks() {
    dbi.Select(JorvikMod, "SilverBlanksRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Silver Blanks', 'Object from Jorvik MOD',        453,               4,          90,        2541,               90,                       5,        1,          0,           'yolauncher/modpack/mod\JorvikMod\art\2D\Items\silver_blanks.png') RETURNING ID");
  }
  function JorvikMod::SilverBlanksRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  2486,                  0,       10,         1,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  2483,                  0,       10,         40,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  453,                  0,       10,         15,       0)");


	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod::CopperBlanks() {
    dbi.Select(JorvikMod, "CopperBlanksRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Copper Blanks', 'Object from Jorvik MOD',        453,               4,          90,        2542,               90,                       5,        1,          0,           'yolauncher/modpack/mod\JorvikMod\art\2D\Items\copper_blanks.png') RETURNING ID");
  }
  function JorvikMod::CopperBlanksRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  2487,                  0,       10,         1,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  2483,                  0,       10,         40,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  453,                  0,       10,         15,       0)");
 

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }
  function JorvikMod::GoldCoins() {
    dbi.Select(JorvikMod, "GoldCoinsRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Gold Coins', 'Object from Jorvik MOD',        453,               4,          100,        1061,               100,                       5,        1,          0,           'yolauncher/modpack/art\2D\Items\gold_coins.png') RETURNING ID");
  }
  function JorvikMod::GoldCoinsRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");

      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  2485,                  0,       50,         5,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  2484,                  0,       10,         40,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  453,                  0,       10,         15,       0)");

	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod::SilverCoins() {
    dbi.Select(JorvikMod, "SilverCoinsRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Silver Coins', 'Object from Jorvik MOD',        453,               4,          100,        1060,               100,                       5,        1,          0,           'yolauncher/modpack/art\2D\Items\silver_coins.png') RETURNING ID");
  }
  function JorvikMod::SilverCoinsRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  2488,                  0,       50,         5,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  2484,                  0,       10,         40,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  453,                  0,       10,         15,       0)");
  
	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }	
  function JorvikMod::CopperCoins() {
    dbi.Select(JorvikMod, "CopperCoinsRequirements","INSERT IGNORE INTO `recipe` VALUES (NULL, 'Copper Coins', 'Object from Jorvik MOD',        453,               4,          100,        1059,               100,                       5,        1,          0,           'yolauncher/modpack/art\2D\Items\copper_coins.png') RETURNING ID");
  }
  function JorvikMod::CopperCoinsRequirements(%this, %resultSet) {
    if(%resultSet.ok() && %resultSet.nextRecord()) {
      %lastInsert = %resultSet.getFieldValue("ID");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  2489,                  0,       50,         5,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  2484,                  0,       10,         40,       0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, " @ %lastInsert @ ",  453,                  0,       10,         15,       0)");
	  
    }
    dbi.remove(%resultSet);
    %resultSet.delete();
  }  
  
};
// This command is from Torque, and activates your package so that the engine can reference it
// This is required for your mod to work, and have the code loaded in torque engine.
activatePackage(JorvikMod);
