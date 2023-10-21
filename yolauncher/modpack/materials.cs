﻿//Jorvik Mod v2.0

//Flag PvE
singleton Material(flag_PVE_flag)
{
   mapTo = "flag";
   diffuseMap[0] = "mod/JorvikMod/art//Textures/TextureLib/flag.dds";
   diffuseMap[1] = "mod/JorvikMod/art/Textures/TextureLib/flag_nm.dds";
   translucentBlendOp = "None";
};
//Flag PvP
singleton Material(flag_PVP_flag)
{
   mapTo = "flag";
   diffuseMap[0] = "mod/JorvikMod/art/Textures/TextureLib/flag.dds";
   diffuseMap[1] = "mod/JorvikMod/art/Textures/TextureLib/flag_nm.dds";
   translucentBlendOp = "None";
};
//------------- WoodCart ---------------->
singleton Material(MapleBark_Diffuse_Cart)
{
   mapTo = "MapleBark_cart";
   diffuseMap[0] = "art/models/3d/environment/trees/maple/textures/maplebark_diffuse.dds";
   diffuseMap[1] = "art/models/3d/environment/trees/maple/textures/maplebark_normal.dds";
};

singleton Material(MapleTree_Cart) // клен
{
   mapTo = "MapleTree_cart";
   diffuseMap[0] = "art/models/3d/environment/trees/maple/textures/mapletree_diffuse.dds";
   diffuseMap[1] = "art/models/3d/environment/trees/maple/textures/mapletree_normal.dds";
};

singleton Material(OakTree_Cart) // дуб
{
   mapTo = "OakTree_Diffuse_cart";
   diffuseMap[0] = "art/models/3d/environment/trees/oak/textures/oaktree_diffuse.dds";
   diffuseMap[1] = "art/models/3d/environment/trees/oak/textures/oaktree_normal.dds";
};

singleton Material(OakBark01_Cart) // дуб ствол
{
   mapTo = "OakBark01_cart";
   diffuseMap[0] = "art/models/3d/environment/trees/oak/textures/oakbark_diffuse.dds";
   diffuseMap[1] = "art/models/3d/environment/trees/oak/textures/oakbark_normal.dds";
};

singleton Material(BirchTree_Cart) // береза
{
   mapTo = "BirchTree_cart";
   diffuseMap[0] = "art/models/3d/environment/trees/birch/textures/birchtree_diffuse.dds";
   diffuseMap[1] = "art/models/3d/environment/trees/birch/textures/birchtree_normal.dds";
};

singleton Material(BirchBark_Cart) // береза ствол
{
   mapTo = "BirchBark_cart";
   diffuseMap[0] = "art/models/3d/environment/trees/birch/textures/birchbark_diffuse.dds";
   diffuseMap[1] = "art/models/3d/environment/trees/birch/textures/birchbark_normal.dds";
};

singleton Material(PineTree_Cart) // сосна
{
   mapTo = "PineTree_cart";
   diffuseMap[0] = "art/models/3d/environment/trees/pine/textures/pinetree_diffuse.dds";
   diffuseMap[1] = "art/models/3d/environment/trees/pine/textures/pinetree_normal.dds";
};

singleton Material(PineBark_Cart) // сосна ствол
{
   mapTo = "PineBark_cart";
   diffuseMap[0] = "art/models/3d/environment/trees/pine/textures/pinebark_diffuse.dds";
   diffuseMap[1] = "art/models/3d/environment/trees/pine/textures/pinebark_normal.dds";
};
//------------- Church ---------------->

singleton Material(BlueWall_A_mat)
{
   mapTo = "BlueWall_A_M1";
   diffuseMap[0] = "mod/JorvikMod/art/Textures/TextureLib/BlueWall_A_DIFFUSE.dds";
   diffuseMap[1] = "mod/JorvikMod/art/Textures/TextureLib/BlueWall_A_NORMALMAP.dds";
   diffuseMap[2] = "mod/JorvikMod/art/Textures/TextureLib/BlueWall_A_SPECULAR.dds";
};

singleton Material(BlueWall_B_mat)
{
   mapTo = "BlueWall_B_M1";
   diffuseMap[0] = "mod/JorvikMod/art/Textures/TextureLib/BlueWall_B_DIFFUSE.dds";
   diffuseMap[1] = "mod/JorvikMod/art/Textures/TextureLib/BlueWall_B_NORMALMAP.dds";
   diffuseMap[2] = "mod/JorvikMod/art/Textures/TextureLib/BlueWall_B_SPECULAR.dds";
   diffuseMap[12] = "mod/JorvikMod/art/Textures/TextureLib/BlueWall_B_EMISSIVE.dds";
   emission = "1";
   emissionIntensityMin = "0";
   emissionIntensityMax = "1.0";
   emissionScale = "0.5";
};

singleton Material(ChurchGlass_mat)
{
   mapTo = "ChurchGlass_diff";
   diffuseMap[0] = "mod/JorvikMod/art/Textures/TextureLib/ChurchGlass_DIFFUSE.dds";
   diffuseMap[2] = "mod/JorvikMod/art/Textures/TextureLib/ChurchGlass_SPECULAR.dds";
   diffuseMap[12] = "mod/JorvikMod/art/Textures/TextureLib/ChurchGlass_EMISSIVE.dds";
};

singleton Material(Church_Door_mat)
{
   mapTo = "Church_DoorA_M2";
   diffuseMap[0] = "mod/JorvikMod/art/Textures/TextureLib/Church_DoorA_DIFFUSE.dds";
   diffuseMap[1] = "mod/JorvikMod/art/Textures/TextureLib/Church_DoorA_NORMALMAP.dds";
   diffuseMap[2] = "mod/JorvikMod/art/Textures/TextureLib/Church_DoorA_SPECULAR.dds";
};

singleton Material(floor_mat)
{
   mapTo = "floor_diff";
   diffuseMap[0] = "mod/JorvikMod/art/Textures/TextureLib/floor_diff.dds";
   diffuseMap[1] = "mod/JorvikMod/art/Textures/TextureLib/floor_nm.dds";
};

singleton Material(Fence_inside_mat)
{
   mapTo = "Fence_inside_diff";
   diffuseMap[0] = "mod/JorvikMod/art/Textures/TextureLib/Fence_inside_diff.dds";
   diffuseMap[1] = "mod/JorvikMod/art/Textures/TextureLib/Fence_inside_nm.dds";
   diffuseMap[2] = "mod/JorvikMod/art/Textures/TextureLib/Fence_inside_spec.dds";
};

singleton Material(RedArc_mat)
{
   mapTo = "RedArc_M1";
   diffuseMap[0] = "mod/JorvikMod/art/Textures/TextureLib/RedArc_DIFFUSE.dds";
   diffuseMap[1] = "mod/JorvikMod/art/Textures/TextureLib/RedArc_NORMALMAP.dds";
   diffuseMap[2] = "mod/JorvikMod/art/Textures/TextureLib/RedArc_SPECULAR.dds";
};

singleton Material(RedEntranceA_mat)
{
   mapTo = "RedEntranceA";
   diffuseMap[0] = "mod/JorvikMod/art/Textures/TextureLib/RedEntranceA_DIFFUSE.dds";
   diffuseMap[1] = "mod/JorvikMod/art/Textures/TextureLib/RedEntranceA_NORMALMAP.dds";
   diffuseMap[2] = "mod/JorvikMod/art/Textures/TextureLib/RedEntranceA_SPECULAR.dds";
};

singleton Material(Svefni_mat)
{
   mapTo = "Svefni1";
   diffuseMap[0] = "mod/JorvikMod/art/Textures/TextureLib/Svefni_DIFFUSE.dds";
   diffuseMap[1] = "mod/JorvikMod/art/Textures/TextureLib/Svefni_NORMALMAP.dds";
   diffuseMap[2] = "mod/JorvikMod/art/Textures/TextureLib/Svefni_SPECULAR.dds";
};

singleton Material(Church_Roof_B_mat)
{
   mapTo = "Church_Roof_B_M1";
   diffuseMap[0] = "art/Textures/TextureLib/roof_tile_diff.dds";
   diffuseMap[1] = "art/Textures/TextureLib/roof_tile_nm.dds";
};

singleton Material(planks_02_inside_mat)
{
   mapTo = "planks_02_inside_diff";
   diffuseMap[0] = "mod/JorvikMod/art/Textures/TextureLib/planks_02_inside_diff.dds";
   diffuseMap[1] = "mod/JorvikMod/art/Textures/TextureLib/planks_02_inside_nm.dds";
};

singleton Material(Church_Bricks_mat)
{
   mapTo = "Church_Bricks_M1";
   diffuseMap[0] = "mod/JorvikMod/art/Textures/TextureLib/Church_Bricks_A_DIFFUSE.dds";
   diffuseMap[1] = "mod/JorvikMod/art/Textures/TextureLib/Church_Bricks_A_NORMALMAP.dds";
   diffuseMap[2] = "mod/JorvikMod/art/Textures/TextureLib/Church_Bricks_A_SPECULAR.dds";
};

singleton Material(Church_EmbossWall_mat)
{
   mapTo = "EmbossWall";
   diffuseMap[0] = "mod/JorvikMod/art/Textures/TextureLib/Church_EmbossWall_DIFFUSE.dds";
   diffuseMap[1] = "mod/JorvikMod/art/Textures/TextureLib/Church_EmbossWall_NORMALMAP.dds";
   diffuseMap[2] = "mod/JorvikMod/art/Textures/TextureLib/Church_EmbossWall_SPECULAR.dds";
};

singleton Material(Altar_Stone2_Colored_mat)
{
   mapTo = "Altar_Stone2_Colored";
   diffuseMap[0] = "mod/JorvikMod/art/Textures/TextureLib/Altar_Stones_Part2_DIFFUSE.dds";
   diffuseMap[1] = "mod/JorvikMod/art/Textures/TextureLib/Altar_Stones_Part2_NORMALMAP.dds";
   diffuseMap[2] = "mod/JorvikMod/art/Textures/TextureLib/Altar_Stones_Part2_SPECULAR.dds";
};


singleton Material(altar_statues_pack2_mat)
{
   mapTo = "altar_statues_pack2";
   diffuseMap[0] = "mod/JorvikMod/art/Textures/TextureLib/Altar_Statues_DIFFUSE.dds";
   diffuseMap[1] = "mod/JorvikMod/art/Textures/TextureLib/Altar_Statues_NORMALMAP.dds";
   diffuseMap[2] = "mod/JorvikMod/art/Textures/TextureLib/Altar_Statues_SPECULAR.dds";
};

singleton Material(OakTree_mat)
{
   mapTo = "OakTree_diff";
   diffuseMap[0] = "mod/JorvikMod/art/Textures/TextureLib/OakTree_Diffuse.dds";
   alphaTest = "1";
   alphaRef = "80";
};

singleton Material(OakBark_mat)
{
   mapTo = "OakBark_diff";
   diffuseMap[0] = "mod/JorvikMod/art/Textures/TextureLib/OakBark_Diffuse.dds";
   diffuseMap[1] = "mod/JorvikMod/art/Textures/TextureLib/OakBark_Normal.dds";
};

singleton Material(FloorDecal_mat)
{
   mapTo = "FloorDecal_diff";
   diffuseMap[0] = "mod/JorvikMod/art/Textures/TextureLib/FloorDecal_Diffuse.dds";
   alphaTest = "1";
   alphaRef = "200";
};

singleton Material(ChurchTree_mat)
{
   mapTo = "ChurchTree";
   diffuseMap[0] = "mod/JorvikMod/art/Textures/TextureLib/ChurchTree_DIFFUSE.dds";
   diffuseMap[1] = "mod/JorvikMod/art/Textures/TextureLib/ChurchTree_NORMALMAP.dds";
   diffuseMap[2] = "mod/JorvikMod/art/Textures/TextureLib/ChurchTree_SPECULAR.dds";
};

singleton Material(Church70_mat)
{
   mapTo = "Church70_diff";
   diffuseMap[0] = "mod/JorvikMod/art/Textures/TextureLib/Church70_DIFFUSE.dds";
   diffuseMap[1] = "mod/JorvikMod/art/Textures/TextureLib/Church70_NORMALMAP.dds";
   diffuseMap[2] = "mod/JorvikMod/art/Textures/TextureLib/Church70_SPECULAR.dds";
};

singleton Material(RedColumn_mat)
{
   mapTo = "RedColumn";
   diffuseMap[0] = "mod/JorvikMod/art/Textures/TextureLib/RedColumn_DIFFUSE.dds";
   diffuseMap[1] = "mod/JorvikMod/art/Textures/TextureLib/RedColumn_NORMALMAP.dds";
   diffuseMap[2] = "mod/JorvikMod/art/Textures/TextureLib/RedColumn_SPECULAR.dds";
   alphaTest = "1";
   alphaRef = "80";
};

singleton Material(Church_Roof_A_mat)
{
   mapTo = "Church_Roof_A_M1";
   diffuseMap[0] = "art/Textures/TextureLib/roof_tile_diff.dds";
   diffuseMap[1] = "art/Textures/TextureLib/roof_tile_nm.dds";
};

singleton Material(Church_RoofRed_mat)
{
   mapTo = "Church_RoofRed_M1";
   diffuseMap[0] = "art/Textures/TextureLib/roof_tile_diff.dds";
   diffuseMap[1] = "art/Textures/TextureLib/roof_tile_nm.dds";
};

singleton Material(LeavesA_mat)
{
   mapTo = "LeavesA_M1";
   diffuseMap[0] = "mod/JorvikMod/art/Textures/TextureLib/Decal_ScatteredLeaves2_1k_d.dds";
   diffuseMap[1] = "mod/JorvikMod/art/Textures/TextureLib/Decal_ScatteredLeaves2_1k_n.dds";
   diffuseMap[2] = "mod/JorvikMod/art/Textures/TextureLib/Decal_ScatteredLeaves1_1k_s.dds";
   alphaTest = "1";
   alphaRef = "80";
};

singleton Material(Wall_PlasterA_mat)
{
   mapTo = "Wall_PlasterA_M1";
   diffuseMap[0] = "mod/JorvikMod/art/Textures/TextureLib/Church_WallA_DIFFUSE.dds";
   diffuseMap[1] = "mod/JorvikMod/art/Textures/TextureLib/Church_WallA_NORMALMAP.dds";
   diffuseMap[2] = "mod/JorvikMod/art/Textures/TextureLib/Church_WallA_SPECULAR.dds";
};

singleton Material(Church_floor_M2_mat)
{
   mapTo = "Church_floor_M2";
   diffuseMap[0] = "art/Textures/TextureLib/CastleConstructions_Beam_DIFFUSE.dds";
   diffuseMap[1] = "art/Textures/TextureLib/CastleConstructions_Beam_NORMALMAP.dds";
   diffuseMap[2] = "art/Textures/TextureLib/CastleConstructions_Beam_SPECULAR.dds";	
};