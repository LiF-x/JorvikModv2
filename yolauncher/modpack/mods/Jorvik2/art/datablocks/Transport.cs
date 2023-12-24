datablock ShapeBaseImageData( MountedCart) {
	id = 691;
	Object_typeID = 168;
	mountPoint = 2;
	shapefile = "art/models/3d/mobiles/transportation/cart/cart.dts";
	wheelRadius = 1.0;

	stateName[0] = "Lift";

	stateName[1] = "Transport";
	stateSound[1] = WagonSound;
};

//---------------------------- Wood Cart -----------------------------------
$Cart::wheelsAnimScale = 0.33;

datablock AttachedShapeData(HarnessedWoodHorseCart)
{
	id = 702;
	objectTypeId = 3016;
	
	shapeFile = "yolauncher/modpack/mods/Jorvik2/art/models/3d/mobiles/transportation/woodcart/woodhorsecart.dts";
};

//---------------------------- Siege Tower-----------------------------------
datablock AttachedShapeData(HarnessedSiegeTower)
{
        id = 703;
        objectTypeId = 2520;
        
        shapeFile = "yolauncher/modpack/mods/Jorvik2/art/models/3d/mobiles/transportation/siegetower/siegetower.dts";
};
