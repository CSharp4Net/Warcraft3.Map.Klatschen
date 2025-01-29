gg_rct_Center = nil
gg_rct_ElfBarracksToCenter = nil
gg_rct_ElfBarracksToCenterSpawn = nil
gg_rct_ElfBarracksToHuman = nil
gg_rct_ElfBarracksToHumanSpawn = nil
gg_rct_ElfBarracksToUndead = nil
gg_rct_ElfBarracksToUndeadSpawn = nil
gg_rct_ElfBase = nil
gg_rct_ElfBaseHeroRespawn = nil
gg_rct_ElfBaseHeroSpawn = nil
gg_rct_ElfBaseToCenterSpawn = nil
gg_rct_ElfBaseToHumanSpawn = nil
gg_rct_ElfBaseToUndeadSpawn = nil
gg_rct_HeroSelectorSpawn = nil
gg_rct_HumanBarracksToCenter = nil
gg_rct_HumanBarracksToCenterSpawn = nil
gg_rct_HumanBarracksToElf = nil
gg_rct_HumanBarracksToElfSpawn = nil
gg_rct_HumanBarracksToOrcs = nil
gg_rct_HumanBarracksToOrcsSpawn = nil
gg_rct_HumanBase = nil
gg_rct_HumanBaseHeroRespawn = nil
gg_rct_HumanBaseHeroSpawn = nil
gg_rct_HumanBaseToCenterSpawn = nil
gg_rct_HumanBaseToElfSpawn = nil
gg_rct_HumanBaseToOrcsSpawn = nil
gg_rct_OrcBarracksToCenter = nil
gg_rct_OrcBarracksToCenterSpawn = nil
gg_rct_OrcBarracksToHuman = nil
gg_rct_OrcBarracksToHumanSpawn = nil
gg_rct_OrcBarracksToUndead = nil
gg_rct_OrcBarracksToUndeadSpawn = nil
gg_rct_OrcBase = nil
gg_rct_OrcBaseHeroRespawn = nil
gg_rct_OrcBaseHeroSpawn = nil
gg_rct_OrcBaseToCenterSpawn = nil
gg_rct_OrcBaseToHumanSpawn = nil
gg_rct_OrcBaseToUndeadSpawn = nil
gg_rct_UndeadBarracksToCenter = nil
gg_rct_UndeadBarracksToCenterSpawn = nil
gg_rct_UndeadBarracksToElf = nil
gg_rct_UndeadBarracksToElfSpawn = nil
gg_rct_UndeadBarracksToOrcs = nil
gg_rct_UndeadBarracksToOrcsSpawn = nil
gg_rct_UndeadBase = nil
gg_rct_UndeadBaseHeroRespawn = nil
gg_rct_UndeadBaseHeroSpawn = nil
gg_rct_UndeadBaseToCenterSpawn = nil
gg_rct_UndeadBaseToElfSpawn = nil
gg_rct_UndeadBaseToOrcsSpawn = nil
gg_trg_Melee_Initialization = nil
function InitGlobals()
end

function CreateUnitsForPlayer0()
local p = Player(0)
local u
local unitID
local t
local life

u = BlzCreateUnitWithSkin(p, FourCC("h006"), -11703.3, -8642.4, 78.796, FourCC("h006"))
u = BlzCreateUnitWithSkin(p, FourCC("h006"), 11698.8, -8637.9, 215.602, FourCC("h006"))
u = BlzCreateUnitWithSkin(p, FourCC("h006"), 11708.1, 14781.1, 303.056, FourCC("h006"))
end

function CreateBuildingsForPlayer3()
local p = Player(3)
local u
local unitID
local t
local life

u = BlzCreateUnitWithSkin(p, FourCC("h005"), -9728.0, 13824.0, 270.000, FourCC("h005"))
u = BlzCreateUnitWithSkin(p, FourCC("h004"), -10752.0, 12800.0, 270.000, FourCC("h004"))
end

function CreateBuildingsForPlayer7()
local p = Player(7)
local u
local unitID
local t
local life

u = BlzCreateUnitWithSkin(p, FourCC("h004"), 10752.0, 12800.0, 270.000, FourCC("h004"))
u = BlzCreateUnitWithSkin(p, FourCC("h005"), 9728.0, 13824.0, 270.000, FourCC("h005"))
end

function CreateBuildingsForPlayer11()
local p = Player(11)
local u
local unitID
local t
local life

u = BlzCreateUnitWithSkin(p, FourCC("h005"), -9728.0, -7680.0, 270.000, FourCC("h005"))
u = BlzCreateUnitWithSkin(p, FourCC("h004"), -10752.0, -6656.0, 270.000, FourCC("h004"))
end

function CreateBuildingsForPlayer15()
local p = Player(15)
local u
local unitID
local t
local life

u = BlzCreateUnitWithSkin(p, FourCC("h005"), 9728.0, -7680.0, 270.000, FourCC("h005"))
u = BlzCreateUnitWithSkin(p, FourCC("h004"), 10752.0, -6656.0, 270.000, FourCC("h004"))
end

function CreateNeutralPassiveBuildings()
local p = Player(PLAYER_NEUTRAL_PASSIVE)
local u
local unitID
local t
local life

u = BlzCreateUnitWithSkin(p, FourCC("n003"), -18432.0, 18176.0, 270.000, FourCC("n003"))
SetUnitColor(u, ConvertPlayerColor(0))
u = BlzCreateUnitWithSkin(p, FourCC("n005"), -11264.0, 14336.0, 270.000, FourCC("n005"))
u = BlzCreateUnitWithSkin(p, FourCC("h003"), 19200.0, 18688.0, 270.000, FourCC("h003"))
u = BlzCreateUnitWithSkin(p, FourCC("h007"), 17664.0, 18688.0, 270.000, FourCC("h007"))
u = BlzCreateUnitWithSkin(p, FourCC("h004"), 16640.0, 18688.0, 270.000, FourCC("h004"))
u = BlzCreateUnitWithSkin(p, FourCC("h005"), 17152.0, 18688.0, 270.000, FourCC("h005"))
u = BlzCreateUnitWithSkin(p, FourCC("n005"), 11264.0, 14336.0, 270.000, FourCC("n005"))
u = BlzCreateUnitWithSkin(p, FourCC("n005"), -11264.0, -8192.0, 270.000, FourCC("n005"))
u = BlzCreateUnitWithSkin(p, FourCC("n005"), 11264.0, -8192.0, 270.000, FourCC("n005"))
end

function CreatePlayerBuildings()
CreateBuildingsForPlayer3()
CreateBuildingsForPlayer7()
CreateBuildingsForPlayer11()
CreateBuildingsForPlayer15()
end

function CreatePlayerUnits()
CreateUnitsForPlayer0()
end

function CreateAllUnits()
CreateNeutralPassiveBuildings()
CreatePlayerBuildings()
CreatePlayerUnits()
end

function CreateRegions()
local we

gg_rct_Center = Rect(-128.0, 2944.0, 128.0, 3200.0)
gg_rct_ElfBarracksToCenter = Rect(-6208.0, -3136.0, -6080.0, -3008.0)
gg_rct_ElfBarracksToCenterSpawn = Rect(-5952.0, -3136.0, -5824.0, -3008.0)
gg_rct_ElfBarracksToHuman = Rect(-10304.0, -1856.0, -10176.0, -1728.0)
gg_rct_ElfBarracksToHumanSpawn = Rect(-10304.0, -1600.0, -10176.0, -1472.0)
gg_rct_ElfBarracksToUndead = Rect(-4928.0, -7232.0, -4800.0, -7104.0)
gg_rct_ElfBarracksToUndeadSpawn = Rect(-4672.0, -7232.0, -4544.0, -7104.0)
gg_rct_ElfBase = Rect(-10304.0, -7232.0, -10176.0, -7104.0)
gg_rct_ElfBaseHeroRespawn = Rect(-11136.0, -8064.0, -11008.0, -7936.0)
gg_rct_ElfBaseHeroSpawn = Rect(-10816.0, -7744.0, -10688.0, -7616.0)
gg_rct_ElfBaseToCenterSpawn = Rect(-9984.0, -6912.0, -9856.0, -6784.0)
gg_rct_ElfBaseToHumanSpawn = Rect(-10304.0, -6912.0, -10176.0, -6784.0)
gg_rct_ElfBaseToUndeadSpawn = Rect(-9984.0, -7232.0, -9856.0, -7104.0)
gg_rct_HeroSelectorSpawn = Rect(-18176.0, 18048.0, -18048.0, 18176.0)
gg_rct_HumanBarracksToCenter = Rect(-6208.0, 9152.0, -6080.0, 9280.0)
gg_rct_HumanBarracksToCenterSpawn = Rect(-6208.0, 8896.0, -6080.0, 9024.0)
gg_rct_HumanBarracksToElf = Rect(-10304.0, 7872.0, -10176.0, 8000.0)
gg_rct_HumanBarracksToElfSpawn = Rect(-10304.0, 7616.0, -10176.0, 7744.0)
gg_rct_HumanBarracksToOrcs = Rect(-4928.0, 13248.0, -4800.0, 13376.0)
gg_rct_HumanBarracksToOrcsSpawn = Rect(-4672.0, 13248.0, -4544.0, 13376.0)
gg_rct_HumanBase = Rect(-10304.0, 13248.0, -10176.0, 13376.0)
gg_rct_HumanBaseHeroRespawn = Rect(-11136.0, 14080.0, -11008.0, 14208.0)
gg_rct_HumanBaseHeroSpawn = Rect(-10816.0, 13760.0, -10688.0, 13888.0)
gg_rct_HumanBaseToCenterSpawn = Rect(-9984.0, 12928.0, -9856.0, 13056.0)
gg_rct_HumanBaseToElfSpawn = Rect(-10304.0, 12928.0, -10176.0, 13056.0)
gg_rct_HumanBaseToOrcsSpawn = Rect(-9984.0, 13248.0, -9856.0, 13376.0)
gg_rct_OrcBarracksToCenter = Rect(6080.0, 9152.0, 6208.0, 9280.0)
gg_rct_OrcBarracksToCenterSpawn = Rect(5824.0, 9152.0, 5952.0, 9280.0)
gg_rct_OrcBarracksToHuman = Rect(4800.0, 13248.0, 4928.0, 13376.0)
gg_rct_OrcBarracksToHumanSpawn = Rect(4544.0, 13248.0, 4672.0, 13376.0)
gg_rct_OrcBarracksToUndead = Rect(10176.0, 7872.0, 10304.0, 8000.0)
gg_rct_OrcBarracksToUndeadSpawn = Rect(10176.0, 7616.0, 10304.0, 7744.0)
gg_rct_OrcBase = Rect(10176.0, 13248.0, 10304.0, 13376.0)
gg_rct_OrcBaseHeroRespawn = Rect(11008.0, 14080.0, 11136.0, 14208.0)
gg_rct_OrcBaseHeroSpawn = Rect(10688.0, 13760.0, 10816.0, 13888.0)
gg_rct_OrcBaseToCenterSpawn = Rect(9856.0, 12928.0, 9984.0, 13056.0)
gg_rct_OrcBaseToHumanSpawn = Rect(9856.0, 13248.0, 9984.0, 13376.0)
gg_rct_OrcBaseToUndeadSpawn = Rect(10176.0, 12928.0, 10304.0, 13056.0)
gg_rct_UndeadBarracksToCenter = Rect(6080.0, -3136.0, 6208.0, -3008.0)
gg_rct_UndeadBarracksToCenterSpawn = Rect(6080.0, -2880.0, 6208.0, -2752.0)
gg_rct_UndeadBarracksToElf = Rect(4800.0, -7232.0, 4928.0, -7104.0)
gg_rct_UndeadBarracksToElfSpawn = Rect(4544.0, -7232.0, 4672.0, -7104.0)
gg_rct_UndeadBarracksToOrcs = Rect(10176.0, -1856.0, 10304.0, -1728.0)
gg_rct_UndeadBarracksToOrcsSpawn = Rect(10176.0, -1600.0, 10304.0, -1472.0)
gg_rct_UndeadBase = Rect(10176.0, -7232.0, 10304.0, -7104.0)
gg_rct_UndeadBaseHeroRespawn = Rect(11008.0, -8064.0, 11136.0, -7936.0)
gg_rct_UndeadBaseHeroSpawn = Rect(10688.0, -7744.0, 10816.0, -7616.0)
gg_rct_UndeadBaseToCenterSpawn = Rect(9856.0, -6912.0, 9984.0, -6784.0)
gg_rct_UndeadBaseToElfSpawn = Rect(9856.0, -7232.0, 9984.0, -7104.0)
gg_rct_UndeadBaseToOrcsSpawn = Rect(10176.0, -6912.0, 10304.0, -6784.0)
end

function Trig_Melee_Initialization_Actions()
MeleeStartingVisibility()
MeleeStartingHeroLimit()
end

function InitTrig_Melee_Initialization()
gg_trg_Melee_Initialization = CreateTrigger()
TriggerAddAction(gg_trg_Melee_Initialization, Trig_Melee_Initialization_Actions)
end

function InitCustomTriggers()
InitTrig_Melee_Initialization()
end

function RunInitializationTriggers()
ConditionalTriggerExecute(gg_trg_Melee_Initialization)
end

function InitCustomPlayerSlots()
SetPlayerStartLocation(Player(0), 0)
ForcePlayerStartLocation(Player(0), 0)
SetPlayerColor(Player(0), ConvertPlayerColor(0))
SetPlayerRacePreference(Player(0), RACE_PREF_HUMAN)
SetPlayerRaceSelectable(Player(0), false)
SetPlayerController(Player(0), MAP_CONTROL_USER)
SetPlayerStartLocation(Player(1), 1)
ForcePlayerStartLocation(Player(1), 1)
SetPlayerColor(Player(1), ConvertPlayerColor(1))
SetPlayerRacePreference(Player(1), RACE_PREF_HUMAN)
SetPlayerRaceSelectable(Player(1), false)
SetPlayerController(Player(1), MAP_CONTROL_USER)
SetPlayerStartLocation(Player(2), 2)
ForcePlayerStartLocation(Player(2), 2)
SetPlayerColor(Player(2), ConvertPlayerColor(2))
SetPlayerRacePreference(Player(2), RACE_PREF_HUMAN)
SetPlayerRaceSelectable(Player(2), false)
SetPlayerController(Player(2), MAP_CONTROL_USER)
SetPlayerStartLocation(Player(3), 3)
ForcePlayerStartLocation(Player(3), 3)
SetPlayerColor(Player(3), ConvertPlayerColor(3))
SetPlayerRacePreference(Player(3), RACE_PREF_HUMAN)
SetPlayerRaceSelectable(Player(3), false)
SetPlayerController(Player(3), MAP_CONTROL_COMPUTER)
SetPlayerStartLocation(Player(4), 4)
ForcePlayerStartLocation(Player(4), 4)
SetPlayerColor(Player(4), ConvertPlayerColor(4))
SetPlayerRacePreference(Player(4), RACE_PREF_ORC)
SetPlayerRaceSelectable(Player(4), false)
SetPlayerController(Player(4), MAP_CONTROL_USER)
SetPlayerStartLocation(Player(5), 5)
ForcePlayerStartLocation(Player(5), 5)
SetPlayerColor(Player(5), ConvertPlayerColor(5))
SetPlayerRacePreference(Player(5), RACE_PREF_ORC)
SetPlayerRaceSelectable(Player(5), false)
SetPlayerController(Player(5), MAP_CONTROL_USER)
SetPlayerStartLocation(Player(6), 6)
ForcePlayerStartLocation(Player(6), 6)
SetPlayerColor(Player(6), ConvertPlayerColor(6))
SetPlayerRacePreference(Player(6), RACE_PREF_ORC)
SetPlayerRaceSelectable(Player(6), false)
SetPlayerController(Player(6), MAP_CONTROL_USER)
SetPlayerStartLocation(Player(7), 7)
ForcePlayerStartLocation(Player(7), 7)
SetPlayerColor(Player(7), ConvertPlayerColor(7))
SetPlayerRacePreference(Player(7), RACE_PREF_ORC)
SetPlayerRaceSelectable(Player(7), false)
SetPlayerController(Player(7), MAP_CONTROL_COMPUTER)
SetPlayerStartLocation(Player(8), 8)
ForcePlayerStartLocation(Player(8), 8)
SetPlayerColor(Player(8), ConvertPlayerColor(8))
SetPlayerRacePreference(Player(8), RACE_PREF_NIGHTELF)
SetPlayerRaceSelectable(Player(8), false)
SetPlayerController(Player(8), MAP_CONTROL_USER)
SetPlayerStartLocation(Player(9), 9)
ForcePlayerStartLocation(Player(9), 9)
SetPlayerColor(Player(9), ConvertPlayerColor(9))
SetPlayerRacePreference(Player(9), RACE_PREF_NIGHTELF)
SetPlayerRaceSelectable(Player(9), false)
SetPlayerController(Player(9), MAP_CONTROL_USER)
SetPlayerStartLocation(Player(10), 10)
ForcePlayerStartLocation(Player(10), 10)
SetPlayerColor(Player(10), ConvertPlayerColor(10))
SetPlayerRacePreference(Player(10), RACE_PREF_NIGHTELF)
SetPlayerRaceSelectable(Player(10), false)
SetPlayerController(Player(10), MAP_CONTROL_USER)
SetPlayerStartLocation(Player(11), 11)
ForcePlayerStartLocation(Player(11), 11)
SetPlayerColor(Player(11), ConvertPlayerColor(11))
SetPlayerRacePreference(Player(11), RACE_PREF_NIGHTELF)
SetPlayerRaceSelectable(Player(11), false)
SetPlayerController(Player(11), MAP_CONTROL_COMPUTER)
SetPlayerStartLocation(Player(12), 12)
ForcePlayerStartLocation(Player(12), 12)
SetPlayerColor(Player(12), ConvertPlayerColor(12))
SetPlayerRacePreference(Player(12), RACE_PREF_UNDEAD)
SetPlayerRaceSelectable(Player(12), false)
SetPlayerController(Player(12), MAP_CONTROL_USER)
SetPlayerStartLocation(Player(13), 13)
ForcePlayerStartLocation(Player(13), 13)
SetPlayerColor(Player(13), ConvertPlayerColor(13))
SetPlayerRacePreference(Player(13), RACE_PREF_UNDEAD)
SetPlayerRaceSelectable(Player(13), false)
SetPlayerController(Player(13), MAP_CONTROL_USER)
SetPlayerStartLocation(Player(14), 14)
ForcePlayerStartLocation(Player(14), 14)
SetPlayerColor(Player(14), ConvertPlayerColor(14))
SetPlayerRacePreference(Player(14), RACE_PREF_UNDEAD)
SetPlayerRaceSelectable(Player(14), false)
SetPlayerController(Player(14), MAP_CONTROL_USER)
SetPlayerStartLocation(Player(15), 15)
ForcePlayerStartLocation(Player(15), 15)
SetPlayerColor(Player(15), ConvertPlayerColor(15))
SetPlayerRacePreference(Player(15), RACE_PREF_UNDEAD)
SetPlayerRaceSelectable(Player(15), false)
SetPlayerController(Player(15), MAP_CONTROL_COMPUTER)
end

function InitCustomTeams()
SetPlayerTeam(Player(0), 0)
SetPlayerState(Player(0), PLAYER_STATE_ALLIED_VICTORY, 1)
SetPlayerTeam(Player(1), 0)
SetPlayerState(Player(1), PLAYER_STATE_ALLIED_VICTORY, 1)
SetPlayerTeam(Player(2), 0)
SetPlayerState(Player(2), PLAYER_STATE_ALLIED_VICTORY, 1)
SetPlayerTeam(Player(3), 0)
SetPlayerState(Player(3), PLAYER_STATE_ALLIED_VICTORY, 1)
SetPlayerAllianceStateAllyBJ(Player(0), Player(1), true)
SetPlayerAllianceStateAllyBJ(Player(0), Player(2), true)
SetPlayerAllianceStateAllyBJ(Player(0), Player(3), true)
SetPlayerAllianceStateAllyBJ(Player(1), Player(0), true)
SetPlayerAllianceStateAllyBJ(Player(1), Player(2), true)
SetPlayerAllianceStateAllyBJ(Player(1), Player(3), true)
SetPlayerAllianceStateAllyBJ(Player(2), Player(0), true)
SetPlayerAllianceStateAllyBJ(Player(2), Player(1), true)
SetPlayerAllianceStateAllyBJ(Player(2), Player(3), true)
SetPlayerAllianceStateAllyBJ(Player(3), Player(0), true)
SetPlayerAllianceStateAllyBJ(Player(3), Player(1), true)
SetPlayerAllianceStateAllyBJ(Player(3), Player(2), true)
SetPlayerAllianceStateVisionBJ(Player(0), Player(1), true)
SetPlayerAllianceStateVisionBJ(Player(0), Player(2), true)
SetPlayerAllianceStateVisionBJ(Player(0), Player(3), true)
SetPlayerAllianceStateVisionBJ(Player(1), Player(0), true)
SetPlayerAllianceStateVisionBJ(Player(1), Player(2), true)
SetPlayerAllianceStateVisionBJ(Player(1), Player(3), true)
SetPlayerAllianceStateVisionBJ(Player(2), Player(0), true)
SetPlayerAllianceStateVisionBJ(Player(2), Player(1), true)
SetPlayerAllianceStateVisionBJ(Player(2), Player(3), true)
SetPlayerAllianceStateVisionBJ(Player(3), Player(0), true)
SetPlayerAllianceStateVisionBJ(Player(3), Player(1), true)
SetPlayerAllianceStateVisionBJ(Player(3), Player(2), true)
SetPlayerTeam(Player(4), 1)
SetPlayerState(Player(4), PLAYER_STATE_ALLIED_VICTORY, 1)
SetPlayerTeam(Player(5), 1)
SetPlayerState(Player(5), PLAYER_STATE_ALLIED_VICTORY, 1)
SetPlayerTeam(Player(6), 1)
SetPlayerState(Player(6), PLAYER_STATE_ALLIED_VICTORY, 1)
SetPlayerTeam(Player(7), 1)
SetPlayerState(Player(7), PLAYER_STATE_ALLIED_VICTORY, 1)
SetPlayerAllianceStateAllyBJ(Player(4), Player(5), true)
SetPlayerAllianceStateAllyBJ(Player(4), Player(6), true)
SetPlayerAllianceStateAllyBJ(Player(4), Player(7), true)
SetPlayerAllianceStateAllyBJ(Player(5), Player(4), true)
SetPlayerAllianceStateAllyBJ(Player(5), Player(6), true)
SetPlayerAllianceStateAllyBJ(Player(5), Player(7), true)
SetPlayerAllianceStateAllyBJ(Player(6), Player(4), true)
SetPlayerAllianceStateAllyBJ(Player(6), Player(5), true)
SetPlayerAllianceStateAllyBJ(Player(6), Player(7), true)
SetPlayerAllianceStateAllyBJ(Player(7), Player(4), true)
SetPlayerAllianceStateAllyBJ(Player(7), Player(5), true)
SetPlayerAllianceStateAllyBJ(Player(7), Player(6), true)
SetPlayerAllianceStateVisionBJ(Player(4), Player(5), true)
SetPlayerAllianceStateVisionBJ(Player(4), Player(6), true)
SetPlayerAllianceStateVisionBJ(Player(4), Player(7), true)
SetPlayerAllianceStateVisionBJ(Player(5), Player(4), true)
SetPlayerAllianceStateVisionBJ(Player(5), Player(6), true)
SetPlayerAllianceStateVisionBJ(Player(5), Player(7), true)
SetPlayerAllianceStateVisionBJ(Player(6), Player(4), true)
SetPlayerAllianceStateVisionBJ(Player(6), Player(5), true)
SetPlayerAllianceStateVisionBJ(Player(6), Player(7), true)
SetPlayerAllianceStateVisionBJ(Player(7), Player(4), true)
SetPlayerAllianceStateVisionBJ(Player(7), Player(5), true)
SetPlayerAllianceStateVisionBJ(Player(7), Player(6), true)
SetPlayerTeam(Player(8), 2)
SetPlayerState(Player(8), PLAYER_STATE_ALLIED_VICTORY, 1)
SetPlayerTeam(Player(9), 2)
SetPlayerState(Player(9), PLAYER_STATE_ALLIED_VICTORY, 1)
SetPlayerTeam(Player(10), 2)
SetPlayerState(Player(10), PLAYER_STATE_ALLIED_VICTORY, 1)
SetPlayerTeam(Player(11), 2)
SetPlayerState(Player(11), PLAYER_STATE_ALLIED_VICTORY, 1)
SetPlayerAllianceStateAllyBJ(Player(8), Player(9), true)
SetPlayerAllianceStateAllyBJ(Player(8), Player(10), true)
SetPlayerAllianceStateAllyBJ(Player(8), Player(11), true)
SetPlayerAllianceStateAllyBJ(Player(9), Player(8), true)
SetPlayerAllianceStateAllyBJ(Player(9), Player(10), true)
SetPlayerAllianceStateAllyBJ(Player(9), Player(11), true)
SetPlayerAllianceStateAllyBJ(Player(10), Player(8), true)
SetPlayerAllianceStateAllyBJ(Player(10), Player(9), true)
SetPlayerAllianceStateAllyBJ(Player(10), Player(11), true)
SetPlayerAllianceStateAllyBJ(Player(11), Player(8), true)
SetPlayerAllianceStateAllyBJ(Player(11), Player(9), true)
SetPlayerAllianceStateAllyBJ(Player(11), Player(10), true)
SetPlayerAllianceStateVisionBJ(Player(8), Player(9), true)
SetPlayerAllianceStateVisionBJ(Player(8), Player(10), true)
SetPlayerAllianceStateVisionBJ(Player(8), Player(11), true)
SetPlayerAllianceStateVisionBJ(Player(9), Player(8), true)
SetPlayerAllianceStateVisionBJ(Player(9), Player(10), true)
SetPlayerAllianceStateVisionBJ(Player(9), Player(11), true)
SetPlayerAllianceStateVisionBJ(Player(10), Player(8), true)
SetPlayerAllianceStateVisionBJ(Player(10), Player(9), true)
SetPlayerAllianceStateVisionBJ(Player(10), Player(11), true)
SetPlayerAllianceStateVisionBJ(Player(11), Player(8), true)
SetPlayerAllianceStateVisionBJ(Player(11), Player(9), true)
SetPlayerAllianceStateVisionBJ(Player(11), Player(10), true)
SetPlayerTeam(Player(12), 3)
SetPlayerTeam(Player(13), 3)
SetPlayerTeam(Player(14), 3)
SetPlayerTeam(Player(15), 3)
SetPlayerAllianceStateAllyBJ(Player(12), Player(13), true)
SetPlayerAllianceStateAllyBJ(Player(12), Player(14), true)
SetPlayerAllianceStateAllyBJ(Player(12), Player(15), true)
SetPlayerAllianceStateAllyBJ(Player(13), Player(12), true)
SetPlayerAllianceStateAllyBJ(Player(13), Player(14), true)
SetPlayerAllianceStateAllyBJ(Player(13), Player(15), true)
SetPlayerAllianceStateAllyBJ(Player(14), Player(12), true)
SetPlayerAllianceStateAllyBJ(Player(14), Player(13), true)
SetPlayerAllianceStateAllyBJ(Player(14), Player(15), true)
SetPlayerAllianceStateAllyBJ(Player(15), Player(12), true)
SetPlayerAllianceStateAllyBJ(Player(15), Player(13), true)
SetPlayerAllianceStateAllyBJ(Player(15), Player(14), true)
SetPlayerAllianceStateVisionBJ(Player(12), Player(13), true)
SetPlayerAllianceStateVisionBJ(Player(12), Player(14), true)
SetPlayerAllianceStateVisionBJ(Player(12), Player(15), true)
SetPlayerAllianceStateVisionBJ(Player(13), Player(12), true)
SetPlayerAllianceStateVisionBJ(Player(13), Player(14), true)
SetPlayerAllianceStateVisionBJ(Player(13), Player(15), true)
SetPlayerAllianceStateVisionBJ(Player(14), Player(12), true)
SetPlayerAllianceStateVisionBJ(Player(14), Player(13), true)
SetPlayerAllianceStateVisionBJ(Player(14), Player(15), true)
SetPlayerAllianceStateVisionBJ(Player(15), Player(12), true)
SetPlayerAllianceStateVisionBJ(Player(15), Player(13), true)
SetPlayerAllianceStateVisionBJ(Player(15), Player(14), true)
end

function InitAllyPriorities()
SetStartLocPrioCount(0, 2)
SetStartLocPrio(0, 0, 1, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(0, 1, 2, MAP_LOC_PRIO_HIGH)
SetStartLocPrioCount(1, 2)
SetStartLocPrio(1, 0, 0, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(1, 1, 2, MAP_LOC_PRIO_HIGH)
SetStartLocPrioCount(2, 2)
SetStartLocPrio(2, 0, 0, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(2, 1, 1, MAP_LOC_PRIO_HIGH)
SetStartLocPrioCount(3, 11)
SetStartLocPrio(3, 0, 0, MAP_LOC_PRIO_LOW)
SetStartLocPrio(3, 1, 1, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(3, 2, 2, MAP_LOC_PRIO_LOW)
SetStartLocPrio(3, 3, 4, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(3, 4, 5, MAP_LOC_PRIO_LOW)
SetStartLocPrio(3, 5, 6, MAP_LOC_PRIO_LOW)
SetStartLocPrio(3, 6, 8, MAP_LOC_PRIO_LOW)
SetStartLocPrio(3, 7, 9, MAP_LOC_PRIO_LOW)
SetStartLocPrio(3, 8, 10, MAP_LOC_PRIO_LOW)
SetStartLocPrio(3, 9, 11, MAP_LOC_PRIO_LOW)
SetStartLocPrioCount(4, 2)
SetStartLocPrio(4, 0, 5, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(4, 1, 6, MAP_LOC_PRIO_HIGH)
SetStartLocPrioCount(5, 2)
SetStartLocPrio(5, 0, 4, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(5, 1, 6, MAP_LOC_PRIO_HIGH)
SetStartLocPrioCount(6, 2)
SetStartLocPrio(6, 0, 4, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(6, 1, 5, MAP_LOC_PRIO_HIGH)
SetStartLocPrioCount(7, 6)
SetStartLocPrio(7, 0, 0, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(7, 1, 2, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(7, 2, 5, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(7, 3, 9, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(7, 4, 13, MAP_LOC_PRIO_LOW)
SetStartLocPrio(7, 5, 15, MAP_LOC_PRIO_LOW)
SetStartLocPrioCount(8, 2)
SetStartLocPrio(8, 0, 9, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(8, 1, 10, MAP_LOC_PRIO_HIGH)
SetStartLocPrioCount(9, 2)
SetStartLocPrio(9, 0, 8, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(9, 1, 10, MAP_LOC_PRIO_HIGH)
SetStartLocPrioCount(10, 2)
SetStartLocPrio(10, 0, 8, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(10, 1, 9, MAP_LOC_PRIO_HIGH)
SetStartLocPrioCount(11, 11)
SetStartLocPrio(11, 0, 1, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(11, 1, 2, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(11, 2, 5, MAP_LOC_PRIO_LOW)
SetStartLocPrio(11, 3, 6, MAP_LOC_PRIO_LOW)
SetStartLocPrio(11, 4, 7, MAP_LOC_PRIO_LOW)
SetStartLocPrio(11, 5, 9, MAP_LOC_PRIO_LOW)
SetStartLocPrio(11, 6, 12, MAP_LOC_PRIO_LOW)
SetStartLocPrio(11, 7, 13, MAP_LOC_PRIO_LOW)
SetStartLocPrio(11, 8, 14, MAP_LOC_PRIO_LOW)
SetStartLocPrio(11, 9, 15, MAP_LOC_PRIO_LOW)
SetEnemyStartLocPrioCount(11, 10)
SetEnemyStartLocPrio(11, 0, 1, MAP_LOC_PRIO_HIGH)
SetEnemyStartLocPrio(11, 1, 2, MAP_LOC_PRIO_HIGH)
SetEnemyStartLocPrio(11, 2, 4, MAP_LOC_PRIO_LOW)
SetEnemyStartLocPrio(11, 3, 5, MAP_LOC_PRIO_LOW)
SetEnemyStartLocPrio(11, 4, 7, MAP_LOC_PRIO_LOW)
SetEnemyStartLocPrio(11, 5, 9, MAP_LOC_PRIO_LOW)
SetEnemyStartLocPrio(11, 6, 10, MAP_LOC_PRIO_LOW)
SetEnemyStartLocPrio(11, 7, 12, MAP_LOC_PRIO_LOW)
SetEnemyStartLocPrio(11, 8, 13, MAP_LOC_PRIO_LOW)
SetEnemyStartLocPrio(11, 9, 14, MAP_LOC_PRIO_LOW)
SetStartLocPrioCount(12, 2)
SetStartLocPrio(12, 0, 13, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(12, 1, 14, MAP_LOC_PRIO_HIGH)
SetStartLocPrioCount(13, 2)
SetStartLocPrio(13, 0, 12, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(13, 1, 14, MAP_LOC_PRIO_HIGH)
SetStartLocPrioCount(14, 2)
SetStartLocPrio(14, 0, 12, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(14, 1, 13, MAP_LOC_PRIO_HIGH)
SetStartLocPrioCount(15, 16)
SetStartLocPrio(15, 0, 0, MAP_LOC_PRIO_LOW)
SetStartLocPrio(15, 1, 1, MAP_LOC_PRIO_LOW)
SetStartLocPrio(15, 2, 2, MAP_LOC_PRIO_LOW)
SetStartLocPrio(15, 3, 3, MAP_LOC_PRIO_LOW)
SetStartLocPrio(15, 4, 4, MAP_LOC_PRIO_LOW)
SetStartLocPrio(15, 5, 5, MAP_LOC_PRIO_LOW)
SetStartLocPrio(15, 6, 6, MAP_LOC_PRIO_LOW)
SetStartLocPrio(15, 7, 7, MAP_LOC_PRIO_LOW)
SetStartLocPrio(15, 8, 8, MAP_LOC_PRIO_LOW)
SetStartLocPrio(15, 9, 9, MAP_LOC_PRIO_LOW)
SetStartLocPrio(15, 10, 10, MAP_LOC_PRIO_LOW)
SetStartLocPrio(15, 11, 11, MAP_LOC_PRIO_LOW)
SetStartLocPrio(15, 12, 12, MAP_LOC_PRIO_LOW)
SetStartLocPrio(15, 13, 13, MAP_LOC_PRIO_LOW)
SetStartLocPrio(15, 14, 14, MAP_LOC_PRIO_LOW)
SetEnemyStartLocPrioCount(15, 16)
SetEnemyStartLocPrio(15, 0, 0, MAP_LOC_PRIO_LOW)
SetEnemyStartLocPrio(15, 1, 1, MAP_LOC_PRIO_LOW)
SetEnemyStartLocPrio(15, 2, 2, MAP_LOC_PRIO_LOW)
SetEnemyStartLocPrio(15, 3, 3, MAP_LOC_PRIO_LOW)
SetEnemyStartLocPrio(15, 4, 4, MAP_LOC_PRIO_LOW)
SetEnemyStartLocPrio(15, 5, 5, MAP_LOC_PRIO_LOW)
SetEnemyStartLocPrio(15, 6, 6, MAP_LOC_PRIO_LOW)
SetEnemyStartLocPrio(15, 7, 7, MAP_LOC_PRIO_LOW)
SetEnemyStartLocPrio(15, 8, 8, MAP_LOC_PRIO_LOW)
SetEnemyStartLocPrio(15, 9, 9, MAP_LOC_PRIO_LOW)
SetEnemyStartLocPrio(15, 10, 10, MAP_LOC_PRIO_LOW)
SetEnemyStartLocPrio(15, 11, 11, MAP_LOC_PRIO_LOW)
SetEnemyStartLocPrio(15, 12, 12, MAP_LOC_PRIO_LOW)
SetEnemyStartLocPrio(15, 13, 13, MAP_LOC_PRIO_LOW)
SetEnemyStartLocPrio(15, 14, 14, MAP_LOC_PRIO_LOW)
end

function main()
SetCameraBounds(-19712.0 + GetCameraMargin(CAMERA_MARGIN_LEFT), -19968.0 + GetCameraMargin(CAMERA_MARGIN_BOTTOM), 19712.0 - GetCameraMargin(CAMERA_MARGIN_RIGHT), 19456.0 - GetCameraMargin(CAMERA_MARGIN_TOP), -19712.0 + GetCameraMargin(CAMERA_MARGIN_LEFT), 19456.0 - GetCameraMargin(CAMERA_MARGIN_TOP), 19712.0 - GetCameraMargin(CAMERA_MARGIN_RIGHT), -19968.0 + GetCameraMargin(CAMERA_MARGIN_BOTTOM))
SetDayNightModels("Environment\\DNC\\DNCLordaeron\\DNCLordaeronTerrain\\DNCLordaeronTerrain.mdl", "Environment\\DNC\\DNCLordaeron\\DNCLordaeronUnit\\DNCLordaeronUnit.mdl")
NewSoundEnvironment("Default")
SetAmbientDaySound("LordaeronSummerDay")
SetAmbientNightSound("LordaeronSummerNight")
SetMapMusic("Music", true, 0)
CreateRegions()
CreateAllUnits()
InitBlizzard()
InitGlobals()
InitCustomTriggers()
RunInitializationTriggers()
end

function config()
SetMapName("TRIGSTR_001")
SetMapDescription("TRIGSTR_003")
SetPlayers(16)
SetTeams(16)
SetGamePlacement(MAP_PLACEMENT_TEAMS_TOGETHER)
DefineStartLocation(0, -10752.0, 13824.0)
DefineStartLocation(1, -10752.0, 13824.0)
DefineStartLocation(2, -10752.0, 13824.0)
DefineStartLocation(3, -10240.0, 13312.0)
DefineStartLocation(4, 10752.0, 13824.0)
DefineStartLocation(5, 10752.0, 13824.0)
DefineStartLocation(6, 10752.0, 13824.0)
DefineStartLocation(7, 10240.0, 13312.0)
DefineStartLocation(8, -10752.0, -7680.0)
DefineStartLocation(9, -10752.0, -7680.0)
DefineStartLocation(10, -10752.0, -7680.0)
DefineStartLocation(11, -10240.0, -7168.0)
DefineStartLocation(12, 10752.0, -7680.0)
DefineStartLocation(13, 10752.0, -7680.0)
DefineStartLocation(14, 10752.0, -7680.0)
DefineStartLocation(15, 10240.0, -7168.0)
InitCustomPlayerSlots()
InitCustomTeams()
InitAllyPriorities()
end

