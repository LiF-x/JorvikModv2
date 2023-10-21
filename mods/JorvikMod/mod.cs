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
      BackgrndImage = "art\\\\images\\\\warehouse"; // *STRING* Image reference to your inventory background, must be set if your object has a container
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
  function JorvikMod::ObjectsTypesSmall Wooden Bridge() {
    return new ScriptObject(ObjectsTypesSmall Wooden Bridge : ObjectsTypes)
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
      FaceImage = "yolauncher/modpack/mod\\JorvikMod\\art\\2D\\Objects\\small_wooden_bridge.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod::ObjectsTypesSmall Stone Bridge() {
    return new ScriptObject(ObjectsTypesSmall Stone Bridge : ObjectsTypes)
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
      FaceImage = "yolauncher/modpack/mod\\JorvikMod\\art\\2D\\Objects\\small_stone_bridge.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod::ObjectsTypesLarge Wooden Bridge() {
    return new ScriptObject(ObjectsTypesLarge Wooden Bridge : ObjectsTypes)
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
      FaceImage = "yolauncher/modpack/mod\\JorvikMod\\art\\2D\\Objects\\large_wooden_bridge.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod::ObjectsTypesLarge Stone Bridge() {
    return new ScriptObject(ObjectsTypesLarge Stone Bridge : ObjectsTypes)
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
      FaceImage = "yolauncher/modpack/mod\\JorvikMod\\art\\2D\\Objects\\large_stone_bridge.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod::ObjectsTypesLarge Stone Bridge End() {
    return new ScriptObject(ObjectsTypesLarge Stone Bridge End : ObjectsTypes)
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
      FaceImage = "yolauncher/modpack/mod\\JorvikMod\\art\\2D\\Objects\\large_stone_bridge_end.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod::ObjectsTypesSmall Stone Bridge End() {
    return new ScriptObject(ObjectsTypesSmall Stone Bridge End : ObjectsTypes)
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
      FaceImage = "yolauncher/modpack/mod\\JorvikMod\\art\\2D\\Objects\\small_stone_bridge_end.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
  function JorvikMod::ObjectsTypesModular Constructions() {
    return new ScriptObject(ObjectsTypesModular Constructions : ObjectsTypes)
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
  function JorvikMod::ObjectsTypesSmall Log Wall() {
    return new ScriptObject(ObjectsTypesSmall Log Wall : ObjectsTypes)
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
      FaceImage = "yolauncher/modpack/mod\\JorvikMod\\art\\2D\\Objects\\small_log_wall.png";
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
      FaceImage = "yolauncher/modpack/mod\\JorvikMod\\art\\2D\\Objects\\small_wooden_pillar.png";
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
      FaceImage = "yolauncher/modpack/mod\\JorvikMod\\art\\2D\\Objects\\small_log_corner_wall.png";
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
      FaceImage = "yolauncher/modpack/mod\\JorvikMod\\art\\2D\\Objects\\small_log_wall_with_window.png";
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
      FaceImage = "yolauncher/modpack/mod\\JorvikMod\\art\\2D\\Objects\\small_log_wall_with_shutters.png";
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
      FaceImage = "yolauncher/modpack/mod\\JorvikMod\\art\\2D\\Objects\\small_log_wall_with_entrance.png";
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
      FaceImage = "yolauncher/modpack/mod\\JorvikMod\\art\\2D\\Objects\\small_log_wall_with_door.png";
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
      FaceImage = "yolauncher/modpack/mod\\JorvikMod\\art\\2D\\Objects\\small_wooden_floor_entrance.png";
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
      FaceImage = "yolauncher/modpack/mod\\JorvikMod\\art\\2D\\Objects\\small_wooden_floor.png";
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
      FaceImage = "yolauncher/modpack/mod\\JorvikMod\\art\\2D\\Objects\\small_log_wall_slope_right.png";
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
      FaceImage = "yolauncher/modpack/mod\\JorvikMod\\art\\2D\\Objects\\small_log_wall_slope_left.png";
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
      FaceImage = "yolauncher/modpack/mod\\JorvikMod\\art\\2D\\Objects\\small_thatch_roof.png";
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
      FaceImage = "yolauncher/modpack/mod\\JorvikMod\\art\\2D\\Objects\\small_thatch_roof_rihgt_end.png";
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
      FaceImage = "yolauncher/modpack/mod\\JorvikMod\\art\\2D\\Objects\\small_thatch_roof_left_end.png";
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
      FaceImage = "yolauncher/modpack/mod\\JorvikMod\\art\\2D\\Objects\\small_thatch_roof_outer_corner.png";
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
      FaceImage = "yolauncher/modpack/mod\\JorvikMod\\art\\2D\\Objects\\small_log_wall_lvl1.png";
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
      FaceImage = "yolauncher/modpack/mod\\JorvikMod\\art\\2D\\Objects\\small_wooden_pillar_lvl1.png";
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
      FaceImage = "yolauncher/modpack/mod\\JorvikMod\\art\\2D\\Objects\\small_log_corner_wall.png_lvl1";
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
      FaceImage = "yolauncher/modpack/mod\\JorvikMod\\art\\2D\\Objects\\small_log_wall_with_window_lvl1.png";
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
      FaceImage = "yolauncher/modpack/mod\\JorvikMod\\art\\2D\\Objects\\small_log_wall_with_shutters_lvl1.png";
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
      FaceImage = "yolauncher/modpack/mod\\JorvikMod\\art\\2D\\Objects\\small_log_wall_with_entrance_lvl1.png";
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
      FaceImage = "yolauncher/modpack/mod\\JorvikMod\\art\\2D\\Objects\\small_log_wall_with_door_lvl1.png";
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
      FaceImage = "yolauncher/modpack/mod\\JorvikMod\\art\\2D\\Objects\\small_wooden_floor_entrance_lvl1.png";
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
      FaceImage = "yolauncher/modpack/mod\\JorvikMod\\art\\2D\\Objects\\small_wooden_floor.png";
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
      FaceImage = "yolauncher/modpack/mod\\JorvikMod\\art\\2D\\Objects\\small_wooden_stairs.png";
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
      FaceImage = "yolauncher/modpack/mod\\JorvikMod\\art\\2D\\Objects\\small_thatch_roof_top.png";
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
      FaceImage = "yolauncher/modpack/mod\\JorvikMod\\art\\2D\\Objects\\small_thatch_roof_outer_corner_top.png";
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
      FaceImage = "yolauncher/modpack/mod\\JorvikMod\\art\\2D\\Objects\\small_thatch_roof_top_left_end.png";
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
      FaceImage = "yolauncher/modpack/mod\\JorvikMod\\art\\2D\\Objects\\small_thatch_roof_top_right_end.png";
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
      FaceImage = "yolauncher/modpack/mod\\JorvikMod\\art\\2D\\Objects\\small_thatch_roof.png";
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
      FaceImage = "yolauncher/modpack/mod\\JorvikMod\\art\\2D\\Objects\\small_thatch_roof_outer_corner.png";
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
      FaceImage = "yolauncher/modpack/mod\\JorvikMod\\art\\2D\\Objects\\small_wooden_railing.png";
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
      FaceImage = "yolauncher/modpack/mod\\JorvikMod\\art\\2D\\Objects\\small_wooden_railing_lvl1.png";
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
      FaceImage = "yolauncher/modpack/mod\\JorvikMod\\art\\2D\\Objects\\small_thatch_roof_outer_corner.png";
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
      FaceImage = "yolauncher/modpack/mod\\JorvikMod\\art\\2D\\Recipes\\wall_torch.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
(2501,1902,'Wall Torch',0,0,0,0,0,0,0,0,3,1,1000,'',0,0,0,0,0,0,'mod\\JorvikMod\\art\\2D\\Recipes\\wall_torch.png','Object from Jorvik MOD',NULL,NULL,0,0),
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
      FaceImage = "yolauncher/modpack/mod\\JorvikMod\\art\\2D\\Recipes\\small_candle.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
(2503,1902,'Small Candle',0,0,0,0,0,0,0,0,3,1,1000,'',0,0,0,0,0,0,'mod\\JorvikMod\\art\\2D\\Recipes\\small_candle.png','Object from Jorvik MOD',NULL,NULL,0,0),
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
      FaceImage = "yolauncher/modpack/mod\\JorvikMod\\art\\2D\\Recipes\\aurochs_cow.png";
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
      FaceImage = "yolauncher/modpack/mod\\JorvikMod\\art\\2D\Recipes\\aurochs_cow.png";
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
      FaceImage = "yolauncher/modpack/mod\\JorvikMod\\art\\2D\\Recipes\\aurochs_cow.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 0; 
      OwnerTimeout = 0; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
(2507,1902,'Small Wooden Stairs',0,1,0,0,0,0,0,0,0,0,5000,'',0,0,0,0,0,0,'mod\\JorvikMod\\art\\2D\\Objects\\small_wooden_stairs.png','Object from Jorvik MOD',NULL,NULL,0,0),
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
      FaceImage = "yolauncher/modpack/mod\\JorvikMod\\art\\2D\\Recipes\\sow.png";
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
      FaceImage = "yolauncher/modpack/mod\\JorvikMod\\art\\2D\\Recipes\\sow.png";
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
      FaceImage = "yolauncher/modpack/mod\\JorvikMod\\art\\2D\\Recipes\\sow.png";
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
      FaceImage = "yolauncher/modpack/mod\\JorvikMod\\art\\2D\\Recipes\\horse.png";
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
      FaceImage = "yolauncher/modpack/mod\\JorvikMod\\art\\2D\\Recipes\\horse.png";
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
      FaceImage = "yolauncher/modpack/mod\\JorvikMod\\art\\2D\\Recipes\\horse.png";
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
      FaceImage = "yolauncher/modpack/mod\\JorvikMod\\art\\2D\\Recipes\\slave.png";
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
      FaceImage = "yolauncher/modpack/mod\\JorvikMod\\art\\2D\\Recipes\\wranen_the_hunter.png";
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
      FaceImage = "yolauncher/modpack/mod\\JorvikMod\\art\\2D\\Items\\paper.png";
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
      FaceImage = "yolauncher/modpack/mod\\JorvikMod\\art\\2D\\Items\\health_book.png";
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
      FaceImage = "yolauncher/modpack/mod\\JorvikMod\\art\\2D\\Objects\\small_thatch_roof_inner_corner.png";
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
      BackgrndImage = "art\\images\\universal"; 
      WorkAreaTop = 0;
      WorkAreaLeft = 0;
      WorkAreaWidth = 0;
      WorkAreaHeight = 0;
      BtnCloseTop = 0;
      BtnCloseLeft = 0;
      FaceImage = "yolauncher/modpack/mod\\JorvikMod\\art\\2D\\Objects\\wood_cart.png";
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
      BackgrndImage = "art\\images\\universal"; 
      WorkAreaTop = 0;
      WorkAreaLeft = 0;
      WorkAreaWidth = 0;
      WorkAreaHeight = 0;
      BtnCloseTop = 0;
      BtnCloseLeft = 0;
      FaceImage = "yolauncher/modpack/mod\\JorvikMod\\art\\2D\\Objects\\siegetower.png";
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
      FaceImage = "yolauncher/modpack/mod\\JorvikMod\\art\\2D\\Recipes\\aurochs_bull.png";
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
      FaceImage = "yolauncher/modpack/mod\\JorvikMod\\art\\2D\Recipes\\aurochs_bull.png";
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
      FaceImage = "yolauncher/modpack/mod\\JorvikMod\\art\\2D\\Recipes\\aurochs_bull.png";
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
      FaceImage = "yolauncher/modpack/mod\\JorvikMod\\art\\2D\\Recipes\\small_wooden_pier.png";
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
      FaceImage = "yolauncher/modpack/mod\\JorvikMod\\art\\2D\\Recipes\\small_wooden_pier_T.png";
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
      FaceImage = "yolauncher/modpack/mod\\JorvikMod\\art\\2D\\Recipes\\small_wooden_pier_L.png";
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
      FaceImage = "yolauncher/modpack/mod\\JorvikMod\\art\\2D\\Recipes\\wattle_wicket.png";
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
      FaceImage = "yolauncher/modpack/mod\\JorvikMod\\art\\2D\\Recipes\\idol_cross.png";
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
      FaceImage = "yolauncher/modpack/mod\\JorvikMod\\art\\2D\\Recipes\\wooden_church.png";
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
      FaceImage = "yolauncher/modpack/mod\\JorvikMod\\art\\2D\\Recipes\\church.png";
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
      FaceImage = "yolauncher/modpack/art\\2D\\Items\\decoration_kit_small.png";
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
      FaceImage = "yolauncher/modpack/art\\2D\\Items\\decoration_kit_medium.png";
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
      FaceImage = "yolauncher/modpack/art\\2D\\Items\\decoration_kit_large.png";
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
      FaceImage = "yolauncher/modpack/mod\\JorvikMod\\art\\2D\\Recipes\\wolf.png";
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
      FaceImage = "yolauncher/modpack/mod\\JorvikMod\\art\\2D\\Items\\gold_sheet.png";
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
      FaceImage = "yolauncher/modpack/mod\\JorvikMod\\art\\2D\\Items\\scissors.png";
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
      FaceImage = "yolauncher/modpack/mod\\JorvikMod\\art\\2D\\Items\\metal_stamp.png";
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
      FaceImage = "yolauncher/modpack/mod\\JorvikMod\\art\\2D\\Items\\gold_blanks.png";
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
      FaceImage = "yolauncher/modpack/mod\\JorvikMod\\art\\2D\\Items\\silver_sheet.png";
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
      FaceImage = "yolauncher/modpack/mod\\JorvikMod\\art\\2D\\Items\\copper_sheet.png";
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
      FaceImage = "yolauncher/modpack/mod\\JorvikMod\\art\\2D\\Items\\silver_blanks.png";
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
      FaceImage = "yolauncher/modpack/mod\\JorvikMod\\art\\2D\\Items\\silver_blanks.png";
      Description = "Object from Jorvik MOD"; 
      BasePrice = 9000; 
      OwnerTimeout = NULL; 
      AllowExportFromRed = 0; // Not in use
      AllowExportFromGreen = 0; // Not in use
   };
  }
};

// This command is from Torque, and activates your package so that the engine can reference it
// This is required for your mod to work, and have the code loaded in torque engine.
activatePackage(JorvikMod);
