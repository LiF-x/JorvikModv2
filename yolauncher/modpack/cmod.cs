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

  }
  function JorvikMod::RegisterMaterials() {
  }
  function JorvikMod::path() {
    return $Con::File;
  }
};
activatePackage(JorvikMod);
LiFx::registerCallback($LiFx::hooks::mods, setup, JorvikMod);