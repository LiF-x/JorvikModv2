/**
* <author>Christophe Roblin</author>
* <email>lifxmod@gmail.com</email>
* <url>lifxmod.com</url>
* <credits>Jorvik for creating the original modification</credits>
* <description>Jorvik V2 mod introduced to be lifx and yolauncher compatible, with robust rule display and GUI-triggered rule requests</description>
* <license>GNU GENERAL PUBLIC LICENSE Version 3, 29 June 2007</license>
*/

if (!isObject(JorvikMod2))
{
    new ScriptObject(JorvikMod2) {};
}

package JorvikMod2
{
    // ------------------------------------------------------------------------
    // COPY HERALDRY FROM MOD → GAME DIRECTORY
    // ------------------------------------------------------------------------
    function JorvikMod2::copyHeraldryFolder(%this, %sourceFolder, %targetBase)
    {
        %targetFolder = %targetBase @ "/" @ fileName(%sourceFolder); // "Heraldry"
        echo("[JorvikMod2] Copying Heraldry folder: " @ %sourceFolder @ " -> " @ %targetFolder);

        // Ensure target folder exists
        createPath(%targetBase);

        // Copy entire folder, overwrite existing
        if (!pathCopy(%sourceFolder, %targetFolder, false))
            echo("!! Failed to copy Heraldry folder!");
        else
            echo("✔ Heraldry folder copied successfully.");
    }

    // ------------------------------------------------------------------------
    // NORMAL MOD FUNCTIONS
    // ------------------------------------------------------------------------
    function JorvikMod2::setup()
    {
        echo("JorvikMod2 setup called!");

        LiFx::registerCallback($LiFx::hooks::onMaterialsLoad,   RegisterMaterials,   JorvikMod2);
        LiFx::registerCallback($LiFx::hooks::onInitialized,     onInitialized,       JorvikMod2);
        LiFx::registerCallback($LiFx::hooks::onDatablockLoad,   RegisterDatablock,   JorvikMod2);

        $JorvikMod2::RulesBuffer = "";
    }

    function JorvikMod2::RegisterMaterials()
    {
        LiFx::loadRecursivelyInFolder("yolauncher/modpack/mods/Jorvik2/", "materials.cs");
    }

    function JorvikMod2::RegisterDatablock()
    {
        LiFx::loadRecursivelyInFolder("yolauncher/modpack/mods/Jorvik2/art/datablocks", "Transport.cs");
        LiFx::loadRecursivelyInFolder("yolauncher/modpack/mods/Jorvik2/art/datablocks", "audioProfiles.cs");
    }

    function JorvikMod2::loadHeraldryRecursively(%this, %folder)
    {
        echo("Scanning folder: " @ %folder);

        %pattern = %folder @ "/*.png";
        for (%file = findFirstFile(%pattern); %file !$= ""; %file = findNextFile(%pattern))
        {
            %name   = fileName(%file);
            %dir    = filePath(%file);

            echo(" - Loading Heraldry Image: " @ %name);
            LiFx::loadRecursivelyInFolder(%dir, %name);
        }

        %subPattern = %folder @ "/*";
        for (%sub = findFirstFile(%subPattern); %sub !$= ""; %sub = findNextFile(%subPattern))
        {
            if (isDirectory(%sub))
                JorvikMod2.loadHeraldryRecursively(%sub);
        }
    }

    // ------------------------------------------------------------------------
    // INITIALIZED → LOAD GUI + COPY HERALDRY INTO GAME
    // ------------------------------------------------------------------------
    function JorvikMod2::onInitialized()
    {
        if (isObject(MainMenuGui))
            MainMenuGui.delete();
        if (isObject(SettingsMenuGui))
            SettingsMenuGui.delete();
        if (isObject(selectCharacterDlg))
            selectCharacterDlg.delete();

        LiFx::loadRecursivelyInFolder("yolauncher/modpack/mods/Jorvik2/art/gui/forms", "LiFxheraldryDialog.gui");
        LiFx::loadRecursivelyInFolder("yolauncher/modpack/mods/Jorvik2/art/gui/forms", "LiFxmainMenuGui.gui");
        LiFx::loadRecursivelyInFolder("yolauncher/modpack/mods/Jorvik2/art/gui/forms", "LiFxselectCharacter.gui");
        LiFx::loadRecursivelyInFolder("yolauncher/modpack/mods/Jorvik2/art/gui/forms", "LiFxloadingGui.gui");

        // Load mod heraldry for GUI
        JorvikMod2.loadHeraldryRecursively("yolauncher/modpack/mods/Jorvik2/art/Textures/Heraldry");

        // 🔥 COPY MOD HERALDRY INTO REAL GAME DIRECTORY (preserves folder structure)
        %source = "yolauncher/modpack/mods/Jorvik2/art/Textures/Heraldry";
        %targetBase = "art/Textures"; // game textures folder
        JorvikMod2.copyHeraldryFolder(%source, %targetBase);
    }

    // ------------------------------------------------------------------------
    // RULES SYSTEM
    // ------------------------------------------------------------------------
    function clientCmdDisplayRules(%chunk)
    {
        if (!isDefined("$JorvikMod2::RulesBuffer"))
            $JorvikMod2::RulesBuffer = "";

        $JorvikMod2::RulesBuffer = $JorvikMod2::RulesBuffer @ %chunk;
    }

    function clientCmdEndRulesTransmission()
    {
        if ($JorvikMod2::RulesBuffer $= "")
        {
            echo("No rules received from server.");
            return;
        }

        echo("Rules received:\n" @ $JorvikMod2::RulesBuffer);
        messageBoxOK("Server Rules", $JorvikMod2::RulesBuffer);

        $JorvikMod2::RulesBuffer = "";
    }

    function displayRules(%request)
    {
        if (%request)
        {
            echo("Requesting rules from server...");
            commandToServer('RequestRules');
        }
    }
};

activatePackage(JorvikMod2);
LiFx::registerCallback($LiFx::hooks::mods, setup, JorvikMod2);
