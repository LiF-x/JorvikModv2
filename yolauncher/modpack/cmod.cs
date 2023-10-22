/**
* <author>Christophe Roblin</author>
* <email>lifxmod@gmail.com</email>
* <url>lifxmod.com</url>
*  <credits>Jorvik for creating the original modification</credits>
* <description>Jorvik mod introduced to be lifx and yolauncher compatible</description>
* <license>GNU GENERAL PUBLIC LICENSE Version 3, 29 June 2007</license>
*/

if (!isObject(JorvikMod))
{
    new ScriptObject(JorvikMod)
    {
    };
}
package JorvikMod
{
  function JorvikMod::setup() {
    LiFx::registerCallback($LiFx::hooks::onMaterialsLoad, RegisterMaterials, JorvikMod);
    LiFx::registerCallback($LiFx::hooks::onInitialized, onInitialized, JorvikMod);
    LiFx::registerCallback($LiFx::hooks::onDatablockLoad, RegisterDatablock, JorvikMod);
  }
  function JorvikMod::RegisterMaterials() {
  }
  function JorvikMod::path() {
    return $Con::File;
  }
  
  function JorvikMod::RegisterDatablock() {
    LiFx::loadRecursivelyInFolder("yolauncher/modpack/art/datablocks", "Transport.cs");
    LiFx::loadRecursivelyInFolder("yolauncher/modpack/art/datablocks", "audioProfiles.cs");
  }

  function JorvikMod::onInitialized() {
    LiFx::loadRecursivelyInFolder("yolauncher/modpack/art/gui/forms", "heraldryDialog.gui");
    LiFx::loadRecursivelyInFolder("yolauncher/modpack/art/gui/forms", "mainMenuGui.gui");
    LiFx::loadRecursivelyInFolder("yolauncher/modpack/art/gui/forms", "selectCharacter.gui");

  }
  
};
activatePackage(JorvikMod);
LiFx::registerCallback($LiFx::hooks::mods, setup, JorvikMod);