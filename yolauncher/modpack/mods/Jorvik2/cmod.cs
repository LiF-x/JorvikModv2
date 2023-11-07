/**
* <author>Christophe Roblin</author>
* <email>lifxmod@gmail.com</email>
* <url>lifxmod.com</url>
*  <credits>Jorvik for creating the original modification</credits>
* <description>Jorvik mod introduced to be lifx and yolauncher compatible</description>
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
  function JorvikMod2::setup() {
    LiFx::registerCallback($LiFx::hooks::onMaterialsLoad, RegisterMaterials, JorvikMod2);
    LiFx::registerCallback($LiFx::hooks::onInitialized, onInitialized, JorvikMod2);
    LiFx::registerCallback($LiFx::hooks::onDatablockLoad, RegisterDatablock, JorvikMod2);
  }
  function JorvikMod2::RegisterMaterials() {
    LiFx::loadRecursivelyInFolder("yolauncher/modpack/mods/Jorvik2/", "materials.cs");
  }
  function JorvikMod2::path() {
    %path = $Con::File; 
    echo(%path);
    return %path;
  }
  
  function JorvikMod2::RegisterDatablock() {
    LiFx::loadRecursivelyInFolder("yolauncher/modpack/mods/Jorvik2/art/datablocks", "Transport.cs");
    LiFx::loadRecursivelyInFolder("yolauncher/modpack/mods/Jorvik2/art/datablocks", "audioProfiles.cs");
  }

  function JorvikMod2::onInitialized() {
    if(isObject(MainMenuGui))
    {
      MainMenuGui.delete();
    }
    if(isObject(SettingsMenuGui))
    {
      SettingsMenuGui.delete();
    }
    if(isObject(selectCharacterDlg))
    {
      selectCharacterDlg.delete();
    }
    LiFx::loadRecursivelyInFolder("yolauncher/modpack/mods/Jorvik2/art/gui/forms", "LiFxheraldryDialog.gui");
    LiFx::loadRecursivelyInFolder("yolauncher/modpack/mods/Jorvik2/art/gui/forms", "LiFxmainMenuGui.gui");
    LiFx::loadRecursivelyInFolder("yolauncher/modpack/mods/Jorvik2/art/gui/forms", "LiFxselectCharacter.gui");

  }
  
};
activatePackage(JorvikMod2);
LiFx::registerCallback($LiFx::hooks::mods, setup, JorvikMod2);