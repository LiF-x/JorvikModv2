/**
* <author>Warped ibun</author>
* <email>lifxmod@gmail.com</email>
* <url>lifxmod.com</url>
* <credits>Christophe Roblin <christophe@roblin.no> modification to make it yolauncher server modpack and lifxcompatible</credits>
* <description>knools from mmo introduced to Lif:YO</description>
* <license>GNU GENERAL PUBLIC LICENSE Version 3, 29 June 2007</license>
*/

if (!isObject(LiFxJorvikConversion))
{
    new ScriptObject(LiFxJorvikConversion)
    {
    };
}

package LiFxJorvikConversion

{
    function LiFxJorvikConversion::setup() {
        LiFx::registerCallback($LiFx::hooks::onServerCreatedCallbacks, Datablock, LiFxJorvikConversion);
        LiFx::registerCallback($LiFx::hooks::onServerCreatedCallbacks, Dbchanges, LiFxJorvikConversion);
        LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, ConChanges, LiFxJorvikConversion);
        
        // Register new objects
        LiFx::registerObjectsTypes(LiFxJorvikConversion::ObjectsTypesWoodenCross(), LiFxJorvikConversion);
        LiFx::registerObjectsTypes(LiFxJorvikConversion::ObjectsTypesWoodenBridge(), LiFxJorvikConversion);
        LiFx::registerObjectsTypes(LiFxJorvikConversion::ObjectsTypesStoneBridge(), LiFxJorvikConversion);
        LiFx::registerObjectsTypes(LiFxJorvikConversion::ObjectsTypesSmallWoodenshed(), LiFxJorvikConversion);
        LiFx::registerObjectsTypes(LiFxJorvikConversion::ObjectsTypesMetalCage(), LiFxJorvikConversion);
        LiFx::registerObjectsTypes(LiFxJorvikConversion::ObjectsTypesWoodenPier(), LiFxJorvikConversion);
        LiFx::registerObjectsTypes(LiFxJorvikConversion::ObjectsTypesWoodenBarricadeA(), LiFxJorvikConversion);
        LiFx::registerObjectsTypes(LiFxJorvikConversion::ObjectsTypesWoodenBarricade(), LiFxJorvikConversion);
        LiFx::registerObjectsTypes(LiFxJorvikConversion::ObjectsTypesStoneAltar(), LiFxJorvikConversion);
        LiFx::registerObjectsTypes(LiFxJorvikConversion::ObjectsTypesWoodenTowerHouse(), LiFxJorvikConversion);
        LiFx::registerObjectsTypes(LiFxJorvikConversion::ObjectsTypesWoodenChurch(), LiFxJorvikConversion);
        LiFx::registerObjectsTypes(LiFxJorvikConversion::ObjectsTypesWoodenPierT(), LiFxJorvikConversion);
        LiFx::registerObjectsTypes(LiFxJorvikConversion::ObjectsTypesWoodenPierL(), LiFxJorvikConversion);
        LiFx::registerObjectsTypes(LiFxJorvikConversion::ObjectsTypesStoneTombCross(), LiFxJorvikConversion);
    }
    function LiFxJorvikConversion::version() {
        return "0.0.1";
    }

    function LiFxJorvikConversion::ObjectsTypesWoodenCross() {
        return new ScriptObject(ObjectsTypesWoodenCross : ObjectsTypes)
        {
            id = 2400; // has to be globally unique, please reserve ids here: https://www.lifxmod.com/info/object-id-list/
            ObjectName = "Wooden Cross";
            ParentID = 61;
            IsContainer = 0;
            IsMovableObject = 0;
            IsUnmovableobject = 1;
            IsTool = 0;
            IsDevice = 0;
            IsDoor = 0;
            IsPremium = 0;
            MaxContSize = 100000;
            Length = 6; 
            MaxStackSize = 1;
            UnitWeight = 100000;
            BackgrndImage = "art\\\\images\\\\bag";
            WorkAreaTop = 0;
            WorkAreaLeft = 0;
            WorkAreaWidth = 0;
            WorkAreaHeight = 0;
            BtnCloseTop = 0;
            BtnCloseLeft = 0;
            FaceImage = "yolauncher/modpack/mods/Jorvik/art/2D/recipes/wooden_cross.png";
            Description = "Object from Jorvik MOD pack CONVERTED TO LIFX AND YO LAUNCHER FRAMEWORK";
            BasePrice = NULL;
            OwnerTimeout = NULL;
            AllowExportFromRed = 0;
            AllowExportFromGreen = 0;
        };
    }
    function LiFxJorvikConversion::ObjectsTypesWoodenBridge() {
        return new ScriptObject(ObjectsTypesWoodenBridge : ObjectsTypes)
        {
            id = 2401; // has to be globally unique, please reserve ids here: https://www.lifxmod.com/info/object-id-list/
            ObjectName = "Wooden Bridge";
            ParentID = 61;
            IsContainer = 0;
            IsMovableObject = 0;
            IsUnmovableobject = 1;
            IsTool = 0;
            IsDevice = 0;
            IsDoor = 0;
            IsPremium = 0;
            MaxContSize = 100000;
            Length = 6; 
            MaxStackSize = 1;
            UnitWeight = 100000;
            BackgrndImage = "art\\\\images\\\\bag";
            WorkAreaTop = 0;
            WorkAreaLeft = 0;
            WorkAreaWidth = 0;
            WorkAreaHeight = 0;
            BtnCloseTop = 0;
            BtnCloseLeft = 0;
            FaceImage = "yolauncher/modpack/mods/Jorvik/art/2D/recipes/wooden_bridge.png";
            Description = "Object from Jorvik MOD pack CONVERTED TO LIFX AND YO LAUNCHER FRAMEWORK";
            BasePrice = NULL;
            OwnerTimeout = NULL;
            AllowExportFromRed = 0;
            AllowExportFromGreen = 0;
        };
    }
    function LiFxJorvikConversion::ObjectsTypesStoneBridge() {
        return new ScriptObject(ObjectsTypesStoneBridge : ObjectsTypes)
        {
            id = 2402; // has to be globally unique, please reserve ids here: https://www.lifxmod.com/info/object-id-list/
            ObjectName = "Stone Bridge";
            ParentID = 61;
            IsContainer = 0;
            IsMovableObject = 0;
            IsUnmovableobject = 1;
            IsTool = 0;
            IsDevice = 0;
            IsDoor = 0;
            IsPremium = 0;
            MaxContSize = 100000;
            Length = 6; 
            MaxStackSize = 1;
            UnitWeight = 100000;
            BackgrndImage = "art\\\\images\\\\bag";
            WorkAreaTop = 0;
            WorkAreaLeft = 0;
            WorkAreaWidth = 0;
            WorkAreaHeight = 0;
            BtnCloseTop = 0;
            BtnCloseLeft = 0;
            FaceImage = "yolauncher/modpack/mods/Jorvik/art/2D/recipes/stone_bridge.png";
            Description = "Object from Jorvik MOD pack CONVERTED TO LIFX AND YO LAUNCHER FRAMEWORK";
            BasePrice = NULL;
            OwnerTimeout = NULL;
            AllowExportFromRed = 0;
            AllowExportFromGreen = 0;
        };
    }
    function LiFxJorvikConversion::ObjectsTypesSmallWoodenshed() {
        return new ScriptObject(ObjectsTypesSmallWoodenshed : ObjectsTypes)
        {
            id = 2403; // has to be globally unique, please reserve ids here: https://www.lifxmod.com/info/object-id-list/
            ObjectName = "Small wooden shed";
            ParentID = 69;
            IsContainer = 1;
            IsMovableObject = 1;
            IsUnmovableobject = 0;
            IsTool = 0;
            IsDevice = 0;
            IsDoor = 0;
            IsPremium = 0;
            MaxContSize = 5000000;
            Length = 8; 
            MaxStackSize = 0;
            UnitWeight = 10000;
            BackgrndImage = "art\\\\images\\\\bag";
            WorkAreaTop = 0;
            WorkAreaLeft = 0;
            WorkAreaWidth = 0;
            WorkAreaHeight = 0;
            BtnCloseTop = 0;
            BtnCloseLeft = 0;
            FaceImage = "yolauncher/modpack/mods/Jorvik/art/2D/recipes/small_wooden_shed.png";
            Description = "Object from Jorvik MOD pack CONVERTED TO LIFX AND YO LAUNCHER FRAMEWORK";
            BasePrice = 194200;
            OwnerTimeout = NULL;
            AllowExportFromRed = 0;
            AllowExportFromGreen = 0;
        };
    } 
    function LiFxJorvikConversion::ObjectsTypesMetalCage() {
        return new ScriptObject(ObjectsTypesSmallMetalCage : ObjectsTypes)
        {
            id = 2404; // has to be globally unique, please reserve ids here: https://www.lifxmod.com/info/object-id-list/
            ObjectName = "Metal Cage";
            ParentID = 61;
            IsContainer = 0;
            IsMovableObject = 0;
            IsUnmovableobject = 1;
            IsTool = 0;
            IsDevice = 0;
            IsDoor = 1;
            IsPremium = 0;
            MaxContSize = 100000;
            Length = 6; 
            MaxStackSize = 1;
            UnitWeight = 100000;
            BackgrndImage = "art\\\\images\\\\bag";
            WorkAreaTop = 0;
            WorkAreaLeft = 0;
            WorkAreaWidth = 0;
            WorkAreaHeight = 0;
            BtnCloseTop = 0;
            BtnCloseLeft = 0;
            FaceImage = "yolauncher/modpack/mods/Jorvik/art/2D/recipes/metal_cage.png";
            Description = "Object from Jorvik MOD pack CONVERTED TO LIFX AND YO LAUNCHER FRAMEWORK";
            BasePrice = NULL;
            OwnerTimeout = NULL;
            AllowExportFromRed = 0;
            AllowExportFromGreen = 0;
        };
    }
    function LiFxJorvikConversion::ObjectsTypesWoodenPier() {
        return new ScriptObject(ObjectsTypesWoodenPier : ObjectsTypes)
        {
            id = 2405; // has to be globally unique, please reserve ids here: https://www.lifxmod.com/info/object-id-list/
            ObjectName = "Wooden Pier";
            ParentID = 69;
            IsContainer = 0;
            IsMovableObject = 0;
            IsUnmovableobject = 1;
            IsTool = 0;
            IsDevice = 0;
            IsDoor = 0;
            IsPremium = 0;
            MaxContSize = 100000;
            Length = 6; 
            MaxStackSize = 1;
            UnitWeight = 100000;
            BackgrndImage = "art\\\\images\\\\bag";
            WorkAreaTop = 0;
            WorkAreaLeft = 0;
            WorkAreaWidth = 0;
            WorkAreaHeight = 0;
            BtnCloseTop = 0;
            BtnCloseLeft = 0;
            FaceImage = "yolauncher/modpack/mods/Jorvik/art/2D/recipes/wooden_pier.png";
            Description = "Object from Jorvik MOD pack CONVERTED TO LIFX AND YO LAUNCHER FRAMEWORK";
            BasePrice = NULL;
            OwnerTimeout = NULL;
            AllowExportFromRed = 0;
            AllowExportFromGreen = 0;
        };
    }
    function LiFxJorvikConversion::ObjectsTypesWoodenBarricadeA() {
        return new ScriptObject(ObjectsTypesWoodenBarricadeA : ObjectsTypes)
        {
            id = 2406; // has to be globally unique, please reserve ids here: https://www.lifxmod.com/info/object-id-list/
            ObjectName = "Wooden Barricade";
            ParentID = 130;
            IsContainer = 0;
            IsMovableObject = 1;
            IsUnmovableobject = 0;
            IsTool = 0;
            IsDevice = 0;
            IsDoor = 0;
            IsPremium = 0;
            MaxContSize = 0;
            Length = 4; 
            MaxStackSize = 0;
            UnitWeight = 1000;
            BackgrndImage = "art\\\\images\\\\bag";
            WorkAreaTop = 0;
            WorkAreaLeft = 0;
            WorkAreaWidth = 0;
            WorkAreaHeight = 0;
            BtnCloseTop = 0;
            BtnCloseLeft = 0;
            FaceImage = "yolauncher/modpack/mods/Jorvik/art/2D/recipes/wooden_barricade.png";
            Description = "Object from Jorvik MOD pack CONVERTED TO LIFX AND YO LAUNCHER FRAMEWORK";
            BasePrice = 2400;
            OwnerTimeout = 120;
            AllowExportFromRed = 0;
            AllowExportFromGreen = 0;
        };
    }
        function LiFxJorvikConversion::ObjectsTypesWoodenBarricade() {
        return new ScriptObject(ObjectsTypesWoodenBarricade : ObjectsTypes)
        {
            id = 2407; // has to be globally unique, please reserve ids here: https://www.lifxmod.com/info/object-id-list/
            ObjectName = "Wooden Barricade";
            ParentID = 1902;
            IsContainer = 0;
            IsMovableObject = 0;
            IsUnmovableobject = 0;
            IsTool = 0;
            IsDevice = 0;
            IsDoor = 0;
            IsPremium = 0;
            MaxContSize = 2000;
            Length = 4; 
            MaxStackSize = 1;
            UnitWeight = 2000;
            BackgrndImage = "art\\\\images\\\\bag";
            WorkAreaTop = 0;
            WorkAreaLeft = 0;
            WorkAreaWidth = 0;
            WorkAreaHeight = 0;
            BtnCloseTop = 0;
            BtnCloseLeft = 0;
            FaceImage = "yolauncher/modpack/mods/Jorvik/art/2D/recipes/wooden_barricade.png";
            Description = "Object from Jorvik MOD pack CONVERTED TO LIFX AND YO LAUNCHER FRAMEWORK";
            BasePrice = NULL;
            OwnerTimeout = NULL;
            AllowExportFromRed = 0;
            AllowExportFromGreen = 0;
        };
    }
    function LiFxJorvikConversion::ObjectsTypesStoneAltar() {
        return new ScriptObject(ObjectsTypesStoneAltar : ObjectsTypes)
        {
            id = 2408; // has to be globally unique, please reserve ids here: https://www.lifxmod.com/info/object-id-list/
            ObjectName = "Stone Altar";
            ParentID = 61;
            IsContainer = 0;
            IsMovableObject = 0;
            IsUnmovableobject = 1;
            IsTool = 0;
            IsDevice = 0;
            IsDoor = 0;
            IsPremium = 0;
            MaxContSize = 100000;
            Length = 6; 
            MaxStackSize = 1;
            UnitWeight = 100000;
            BackgrndImage = "art\\\\images\\\\bag";
            WorkAreaTop = 0;
            WorkAreaLeft = 0;
            WorkAreaWidth = 0;
            WorkAreaHeight = 0;
            BtnCloseTop = 0;
            BtnCloseLeft = 0;
            FaceImage = "yolauncher/modpack/mods/Jorvik/art/2D/recipes/wooden_barricade.png";
            Description = "Object from Jorvik MOD pack CONVERTED TO LIFX AND YO LAUNCHER FRAMEWORK";
            BasePrice = NULL;
            OwnerTimeout = NULL;
            AllowExportFromRed = 0;
            AllowExportFromGreen = 0;
        };
    }
    function LiFxJorvikConversion::ObjectsTypesWoodenTowerHouse() {
        return new ScriptObject(ObjectsTypesWoodenTowerHouse : ObjectsTypes)
        {
            id = 2409; // has to be globally unique, please reserve ids here: https://www.lifxmod.com/info/object-id-list/
            ObjectName = "Wooden Tower House";
            ParentID = 61;
            IsContainer = 0;
            IsMovableObject = 0;
            IsUnmovableobject = 1;
            IsTool = 0;
            IsDevice = 0;
            IsDoor = 1;
            IsPremium = 0;
            MaxContSize = 100000;
            Length = 6; 
            MaxStackSize = 12;
            UnitWeight = 200000;
            BackgrndImage = "art\\\\images\\\\bag";
            WorkAreaTop = 0;
            WorkAreaLeft = 0;
            WorkAreaWidth = 0;
            WorkAreaHeight = 0;
            BtnCloseTop = 0;
            BtnCloseLeft = 0;
            FaceImage = "mods\JorvikMod\art\2D\objects\wooden_house_with_tower.png";
            Description = "Object from Jorvik MOD pack CONVERTED TO LIFX AND YO LAUNCHER FRAMEWORK";
            BasePrice = NULL;
            OwnerTimeout = NULL;
            AllowExportFromRed = 0;
            AllowExportFromGreen = 0;
        };
    }
    function LiFxJorvikConversion::ObjectsTypesWoodenChurch() {
        return new ScriptObject(ObjectsTypesWoodenChurch : ObjectsTypes)
        {
            id = 2410; // has to be globally unique, please reserve ids here: https://www.lifxmod.com/info/object-id-list/
            ObjectName = "Wooden Church";
            ParentID = 61;
            IsContainer = 0;
            IsMovableObject = 0;
            IsUnmovableobject = 1;
            IsTool = 0;
            IsDevice = 0;
            IsDoor = 1;
            IsPremium = 0;
            MaxContSize = 100000;
            Length = 6; 
            MaxStackSize = 1;
            UnitWeight = 100000;
            BackgrndImage = "art\\\\images\\\\bag";
            WorkAreaTop = 0;
            WorkAreaLeft = 0;
            WorkAreaWidth = 0;
            WorkAreaHeight = 0;
            BtnCloseTop = 0;
            BtnCloseLeft = 0;
            FaceImage = "yolauncher/modpack/mods/Jorvik/art/2D/recipes/wooden_church.png";
            Description = "Object from Jorvik MOD pack CONVERTED TO LIFX AND YO LAUNCHER FRAMEWORK";
            BasePrice = NULL;
            OwnerTimeout = NULL;
            AllowExportFromRed = 0;
            AllowExportFromGreen = 0;
        };
    }
    function LiFxJorvikConversion::ObjectsTypesWoodenPierT() {
        return new ScriptObject(ObjectsTypesWoodenPierT : ObjectsTypes)
        {
            id = 2411; // has to be globally unique, please reserve ids here: https://www.lifxmod.com/info/object-id-list/
            ObjectName = "Wooden Pier T";
            ParentID = 61;
            IsContainer = 0;
            IsMovableObject = 0;
            IsUnmovableobject = 1;
            IsTool = 0;
            IsDevice = 0;
            IsDoor = 0;
            IsPremium = 0;
            MaxContSize = 100000;
            Length = 6; 
            MaxStackSize = 1;
            UnitWeight = 100000;
            BackgrndImage = "art\\\\images\\\\bag";
            WorkAreaTop = 0;
            WorkAreaLeft = 0;
            WorkAreaWidth = 0;
            WorkAreaHeight = 0;
            BtnCloseTop = 0;
            BtnCloseLeft = 0;
            FaceImage = "yolauncher/modpack/mods/Jorvik/art/2D/recipes/pier_T.png";
            Description = "Object from Jorvik MOD pack CONVERTED TO LIFX AND YO LAUNCHER FRAMEWORK";
            BasePrice = NULL;
            OwnerTimeout = NULL;
            AllowExportFromRed = 0;
            AllowExportFromGreen = 0;
        };
    }
    function LiFxJorvikConversion::ObjectsTypesWoodenPierL() {
        return new ScriptObject(ObjectsTypesWoodenPierL : ObjectsTypes)
        {
            id = 2412; // has to be globally unique, please reserve ids here: https://www.lifxmod.com/info/object-id-list/
            ObjectName = "Wooden Pier L";
            ParentID = 61;
            IsContainer = 0;
            IsMovableObject = 0;
            IsUnmovableobject = 1;
            IsTool = 0;
            IsDevice = 0;
            IsDoor = 0;
            IsPremium = 0;
            MaxContSize = 100000;
            Length = 6; 
            MaxStackSize = 1;
            UnitWeight = 100000;
            BackgrndImage = "art\\\\images\\\\bag";
            WorkAreaTop = 0;
            WorkAreaLeft = 0;
            WorkAreaWidth = 0;
            WorkAreaHeight = 0;
            BtnCloseTop = 0;
            BtnCloseLeft = 0;
            FaceImage = "yolauncher/modpack/mods/Jorvik/art/2D/recipes/pier_T.png";
            Description = "Object from Jorvik MOD pack CONVERTED TO LIFX AND YO LAUNCHER FRAMEWORK";
            BasePrice = NULL;
            OwnerTimeout = NULL;
            AllowExportFromRed = 0;
            AllowExportFromGreen = 0;
        };
    }
    function LiFxJorvikConversion::ObjectsTypesStoneTombCross() {
        return new ScriptObject(ObjectsTypesStoneTombCross : ObjectsTypes)
        {
            id = 2413; // has to be globally unique, please reserve ids here: https://www.lifxmod.com/info/object-id-list/
            ObjectName = "Stone Tomb Cross";
            ParentID = 61;
            IsContainer = 0;
            IsMovableObject = 0;
            IsUnmovableobject = 1;
            IsTool = 0;
            IsDevice = 0;
            IsDoor = 0;
            IsPremium = 0;
            MaxContSize = 100000;
            Length = 6; 
            MaxStackSize = 1;
            UnitWeight = 100000;
            BackgrndImage = "art\\\\images\\\\bag";
            WorkAreaTop = 0;
            WorkAreaLeft = 0;
            WorkAreaWidth = 0;
            WorkAreaHeight = 0;
            BtnCloseTop = 0;
            BtnCloseLeft = 0;
            FaceImage = "yolauncher/modpack/mods/Jorvik/art/2D/recipes/stone_tomb_with_cross.png";
            Description = "Object from Jorvik MOD pack CONVERTED TO LIFX AND YO LAUNCHER FRAMEWORK";
            BasePrice = NULL;
            OwnerTimeout = NULL;
            AllowExportFromRed = 0;
            AllowExportFromGreen = 0;
        };
    }
    function LiFxJorvikConversion::conChanges() {
      dbi.Update("INSERT IGNORE `objects_conversions` VALUES (NULL, 2406, 2407)");
      }

  function LiFxJorvikConversion::dbChanges() {
           ///////////////////////////////////////Recipe /////////////////////////////////////////////
      dbi.Update("INSERT IGNORE `recipe` VALUES (1088, 'Wooden Cross', 'Object from Jorvik MOD pack CONVERTED TO LIFX AND YO LAUNCHER FRAMEWORK.', 34, 54, 60, 2400, 25, 1, 0, 0, 'yolauncher/modpack/mods/Jorvik/art/2D/recipes/wooden_cross.png')");
      dbi.Update("INSERT IGNORE `recipe` VALUES (1089, 'Wooden Bridge', 'Object from Jorvik MOD pack CONVERTED TO LIFX AND YO LAUNCHER FRAMEWORK.', 32, 18, 60, 2401, 10, 1, 0, 0, 'yolauncher/modpack/mods/Jorvik/art/2D/recipes/wooden_bridge.png')");
      dbi.Update("INSERT IGNORE `recipe` VALUES (1090, 'Stone Bridge', 'Object from Jorvik MOD pack CONVERTED TO LIFX AND YO LAUNCHER FRAMEWORK.', 32, 19, 60, 2402, 10, 1, 0, 0, 'yolauncher/modpack/mods/Jorvik/art/2D/recipes/stone_bridge.png')");
      dbi.Update("INSERT IGNORE `recipe` VALUES (1091, 'Small Wooden Shed', 'Object from Jorvik MOD pack CONVERTED TO LIFX AND YO LAUNCHER FRAMEWORK.', 32, 18, 60, 2403, 25, 1, 0, 0, 'yolauncher/modpack/mods/Jorvik/art/2D/recipes/small_wooden_shed.png')");
      dbi.Update("INSERT IGNORE `recipe` VALUES (1100, 'Metal Cage', 'Object from Jorvik MOD pack CONVERTED TO LIFX AND YO LAUNCHER FRAMEWORK.', 32, 19, 60, 2404, 35, 1, 0, 0, 'yolauncher/modpack/mods/Jorvik/art/2D/recipes/metal_cage.png')");
      dbi.Update("INSERT IGNORE `recipe` VALUES (1092, 'Wooden Pier', 'Object from Jorvik MOD pack CONVERTED TO LIFX AND YO LAUNCHER FRAMEWORK.', 32, 18, 60, 2405, 10, 1, 0, 0, 'yolauncher/modpack/mods/Jorvik/art/2D/recipes/wooden_pier.png')");
      dbi.Update("INSERT IGNORE `recipe` VALUES (1101, 'Wooden Barricade', 'Object from Jorvik MOD pack CONVERTED TO LIFX AND YO LAUNCHER FRAMEWORK.', 36, 18, 60, 2406, 40, 1, 0, 0, 'yolauncher/modpack/mods/Jorvik/art/2D/recipes/wooden_barricade.png')");
      dbi.Update("INSERT IGNORE `recipe` VALUES (1094, 'Stone Alter', 'Object from Jorvik MOD pack CONVERTED TO LIFX AND YO LAUNCHER FRAMEWORK.', 32, 19, 60, 2408, 10, 1, 0, 0, 'yolauncher/modpack/mods/Jorvik/art/2D/recipes/stone_altar.png')");
      dbi.Update("INSERT IGNORE `recipe` VALUES (1095, 'Wooden House with Tower', 'Object from Jorvik MOD pack CONVERTED TO LIFX AND YO LAUNCHER FRAMEWORK.', 36, 18, 60, 2409, 10, 1, 0, 0, 'yolauncher/modpack/mods/Jorvik/art/2D/recipes/wooden_house_with_tower.png')");
      dbi.Update("INSERT IGNORE `recipe` VALUES (1096, 'Wooden Church', 'Object from Jorvik MOD pack CONVERTED TO LIFX AND YO LAUNCHER FRAMEWORK.', 32, 19, 60, 2410, 35, 1, 0, 0, 'yolauncher/modpack/mods/Jorvik/art/2D/recipes/wooden_church.png')");
      dbi.Update("INSERT IGNORE `recipe` VALUES (1097, 'Wooden Pier T', 'Object from Jorvik MOD pack CONVERTED TO LIFX AND YO LAUNCHER FRAMEWORK.', 32, 18, 60, 2411, 10, 1, 0, 0, 'yolauncher/modpack/mods/Jorvik/art/2D/recipes/pier_T.png')");
      dbi.Update("INSERT IGNORE `recipe` VALUES (1098, 'Wooden Pier L', 'Object from Jorvik MOD pack CONVERTED TO LIFX AND YO LAUNCHER FRAMEWORK.', 32, 18, 60, 2412, 10, 1, 0, 0, 'yolauncher/modpack/mods/Jorvik/art/2D/recipes/pier_L.png')");
      dbi.Update("INSERT IGNORE `recipe` VALUES (1099, 'Stone tomb with cross', 'Object from Jorvik MOD pack CONVERTED TO LIFX AND YO LAUNCHER FRAMEWORK.', 32, 19, 60, 2413, 10, 1, 0, 0, 'yolauncher/modpack/mods/Jorvik/art/2D/recipes/stone_tomb_with_cross.png')");

 ///////////////////////////////////////Recipe Requirements /////////////////////////////////////////////

    //dbi.update("INSERT IGNORE INTO `recipe_requirement` VALUES (RecipeID,            MaterialObjectTypeID, Quality, Influence, Quantity, IsRegionalItemRequired)
    //Wooden Cross
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, 1088, 233, 0, 65, 2, 0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, 1088, 34, 0, 10, 40, 0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, 1088, 247, 0, 0, 1, 0)");
    //Wooden Bridge
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, 1089, 326, 0, 30, 18, 0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, 1089, 233, 0, 20, 4, 0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, 1089, 32, 0, 10, 15, 0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, 1089, 262, 0, 20, 8, 0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, 1089, 281, 0, 20, 40, 0)");
    //Stone Bridge
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, 1090, 269, 0, 30, 100, 0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, 1090, 233, 0, 20, 8, 0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, 1090, 32, 0, 10, 15, 0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, 1090, 528, 0, 20, 40, 0)");
    // Wooden Shed 
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, 1091, 233, 0, 20, 4, 0)");//no tool
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, 1091, 326, 0, 20, 40, 0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, 1091, 281, 0, 10, 40, 0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, 1091, 1356, 0, 20, 10, 0)");    
    //Metal Cage **
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, 1100, 282, 0, 20, 4, 0)");//no tool
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, 1100, 283, 0, 20, 2, 0)"); //done
    //Wooden Pier
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, 1092, 326, 0, 30, 18, 0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, 1092, 233, 0, 20, 8, 0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, 1092, 32, 0, 10, 25, 0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, 1092, 281, 0, 10, 40, 0)");
    //Wooden Barricade **
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, 1101, 233, 0, 20, 3, 0)");//no tool
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, 1101, 1356, 0, 20, 4, 0)");
    //Stone Alter
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, 1094, 269, 0, 30, 80, 0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, 1094, 32, 0, 10, 10, 0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, 1094, 528, 0, 20, 30, 0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, 1094, 270, 0, 20, 4, 0)");
    //Wooden Tower House
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, 1095, 233, 0, 30, 200, 0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, 1095, 281, 0, 10, 400, 0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, 1095, 286, 0, 10, 1, 0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, 1095, 326, 0, 5, 230, 0)");
    //Wooden Church
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, 1096, 233, 0, 30, 250, 0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, 1096, 281, 0, 10, 400, 0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, 1096, 286, 0, 10, 2, 0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, 1096, 288, 0, 5, 6, 0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, 1096, 326, 0, 5, 280, 0)");
    //Wooden Wooden Pier T
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, 1097, 326, 0, 30, 36, 0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, 1097, 233, 0, 20, 16, 0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, 1097, 32, 0, 10, 50, 0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, 1097, 281, 0, 10, 80, 0)");
    //Wooden Wooden Pier L
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, 1098, 326, 0, 30, 36, 0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, 1098, 233, 0, 20, 16, 0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, 1098, 32, 0, 10, 50, 0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, 1098, 281, 0, 10, 80, 0)");
    //Stone Tomb with Cross
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, 1099, 269, 0, 30, 50, 0)");
      dbi.Update("INSERT IGNORE INTO `recipe_requirement` VALUES (NULL, 1099, 528, 0, 20, 20, 0)");
  
  }
};
activatePackage(LiFxJorvikConversion);
LiFx::registerCallback($LiFx::hooks::mods, setup, LiFxJorvikConversion);