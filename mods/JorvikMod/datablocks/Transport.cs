datablock ShapeBaseImageData(MountedPlough)
{
    ID = 689;
    Object_typeID = 53;
    mountPoint = 2;
    shapeFile = "art/models/3d/construction/farming/plough/plough.dts";
    wheelRadius = 0.7;
    stateName[0] = "Lift";
    stateName[1] = "Plow";
    stateSound[1] = WagonSound;
    stateEmitter0[1] = plough_dust;
    stateEmitterNode0[1] = "mount3";
    stateEmitter1[1] = plough_dirt_elements;
    stateEmitterNode1[1] = "mount3";
    stateEmitter2[1] = plough_dirt_elements_2;
    stateEmitterNode2[1] = "mount3";
};
datablock ShapeBaseImageData(MountedWheelbarrow)
{
    ID = 690;
    Object_typeID = 167;
    mountPoint = 2;
    shapeFile = "art/models/3d/mobiles/transportation/wheelbarrow/wheelbarrow.dts";
    wheelRadius = 1;
    stateName[0] = "Lift";
    stateName[1] = "Transport";
    stateSound[1] = WagonSound;
};
datablock ShapeBaseImageData(MountedCart)
{
    ID = 691;
    Object_typeID = 168;
    mountPoint = 2;
    shapeFile = "art/models/3d/mobiles/transportation/cart/cart.dts";
    wheelRadius = 1;
    stateName[0] = "Lift";
    stateName[1] = "Transport";
    stateSound[1] = WagonSound;
};
datablock ShapeBaseImageData(MountedTrader_cart)
{
    ID = 692;
    Object_typeID = 169;
    mountPoint = 2;
    shapeFile = "art/models/3d/mobiles/transportation/tradecart/tradecart.dts";
    wheelRadius = 1.2;
    stateName[0] = "Lift";
    stateName[1] = "Transport";
    stateSound[1] = WagonSound;
};
singleton SFXDescription(Audio_TraderCart_default : AudioDefault3D)
{
    is3D = 1;
    referenceDistance = 20;
    maxDistance = 100;
    volume = 0.4;
};
$Cart::wheelsAnimScale = 0.33;
datablock AttachedShapeData(HarnessedHorseCart)
{
    ID = 694;
    objectTypeId = 1437;
    shapeFile = "art/models/3d/mobiles/transportation/horsecart/horsecart.dts";
};
datablock AttachedShapeData(HarnessedHorseCartNoTent)
{
    ID = 701;
    objectTypeId = 1496;
    shapeFile = "art/models/3d/mobiles/transportation/horsecart/horsecartnotent.dts";
};
datablock AttachedShapeData(HarnessedWoodHorseCart)
{
    ID = 702;
    objectTypeId = 2466;
    shapeFile = "mod/JorvikMod/art/models/3d/mobiles/transportation/woodcart/woodhorsecart.dts";
};
datablock AttachedShapeData(HarnessedSiegeTower)
{
    ID = 703;
    objectTypeId = 2467;
    shapeFile = "mod/JorvikMod/art/models/3d/mobiles/transportation/siegetower/siegetower.dts";
};

