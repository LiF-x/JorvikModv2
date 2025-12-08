/**
* <author>Christophe Roblin</author>
* <email>lifxmod@gmail.com</email>
* <url>lifxmod.com</url>
* <credits>Jorvik for creating the original modification</credits>
* <description>Jorvik mod introduced to be lifx and yolauncher compatible, with robust rule display and GUI-triggered rule requests</description>
* <license>GNU GENERAL PUBLIC LICENSE Version 3, 29 June 2007</license>
*/

if (!isObject(JorvikMod2))
{
    new ScriptObject(JorvikMod2)
    {
    };
}

package JorvikMod2
{
    function JorvikMod2::setup()
    {
        echo("JorvikMod2 setup called!"); // Debug to ensure setup runs

        LiFx::registerCallback($LiFx::hooks::onMaterialsLoad, RegisterMaterials, JorvikMod2);
        LiFx::registerCallback($LiFx::hooks::onInitialized, onInitialized, JorvikMod2);
        LiFx::registerCallback($LiFx::hooks::onDatablockLoad, RegisterDatablock, JorvikMod2);

        // Initialize rules buffer safely
        $JorvikMod2::RulesBuffer = "";
    }

    function JorvikMod2::RegisterMaterials()
    {
        LiFx::loadRecursivelyInFolder("yolauncher/modpack/mods/Jorvik2/", "materials.cs");
    }

    function JorvikMod2::path()
    {
        %path = $Con::File;
        echo(%path);
        return %path;
    }

    function JorvikMod2::RegisterDatablock()
    {
        LiFx::loadRecursivelyInFolder("yolauncher/modpack/mods/Jorvik2/art/datablocks", "Transport.cs");
        LiFx::loadRecursivelyInFolder("yolauncher/modpack/mods/Jorvik2/art/datablocks", "audioProfiles.cs");
    }

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
    }

    // ---------------------------------------------------------------------
    //  CLIENT-SIDE RULE DISPLAY HANDLERS
    // ---------------------------------------------------------------------

    // Buffer to collect all rule text chunks
    function clientCmdDisplayRules(%chunk)
    {
        if (!isDefined("$JorvikMod2::RulesBuffer"))
            $JorvikMod2::RulesBuffer = "";

        $JorvikMod2::RulesBuffer = $JorvikMod2::RulesBuffer @ %chunk;
    }

    // When server signals completion, show the rules
    function clientCmdEndRulesTransmission()
    {
        if ($JorvikMod2::RulesBuffer $= "")
        {
            echo("No rules received from server.");
            return;
        }

        echo("Rules received:\n" @ $JorvikMod2::RulesBuffer); // Debug
        messageBoxOK("Server Rules", $JorvikMod2::RulesBuffer);

        // Clear buffer for next use
        $JorvikMod2::RulesBuffer = "";
    }

    // ---------------------------------------------------------------------
    //  CLIENT FUNCTION TO REQUEST RULES FROM SERVER (for GUI button)
    // ---------------------------------------------------------------------
    function displayRules(%request)
    {
        if (%request)
        {
            echo("Requesting rules from server..."); // Debug
            commandToServer('RequestRules');
        }
    }
};

activatePackage(JorvikMod2);
LiFx::registerCallback($LiFx::hooks::mods, setup, JorvikMod2);
