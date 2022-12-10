/**
* <author>Warped ibun</author>
* <email>lifxmod@gmail.com</email>
* <url>lifxmod.com</url>
* <credits>Christophe Roblin <christophe@roblin.no> modification to make it yolauncher server modpack and lifxcompatible</credits>
  <credits>Jorvik for creating the original modification</credits>
* <description>Jorvik mod introduced to be lifx and yolauncher compatible</description>
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
    LiFx::registerCallback($LiFx::hooks::onMaterialsLoad, RegisterMaterials, LiFxJorvikConversion);

  }
  function LiFxJorvikConversion::RegisterMaterials() {
    LiFx::loadRecursivelyInFolder("yolauncher/modpack/mods/Jorvik", "Jorvikmaterials.cs");
  }
  function LiFxJorvikConversion::path() {
    return $Con::File;
  }
};
activatePackage(LiFxJorvikConversion);
LiFx::registerCallback($LiFx::hooks::mods, setup, LiFxJorvikConversion);