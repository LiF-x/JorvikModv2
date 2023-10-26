	
// Jorvik Mod
datablock SFXProfile(env_bell)
{
   local = 1;
   filename = "art/sound/SFX/env_bell.ogg";
   description = AudioObjectsCloseLoop3D;
};
datablock SFXProfile(env_bell)
{
   filename = "art/sound/SFX/env_bell.ogg";
   description = AudioDefault3D;
   referenceDistance = 10;
   maxDistance = 100;
   preload = true;
};
datablock AudioDescription(AudioDefault3D)
{
   volume = 1.0;
   isLooping = false;
   is3D = true;
   ReferenceDistance = 10.0;
   maxDistance = 100.0;
};
