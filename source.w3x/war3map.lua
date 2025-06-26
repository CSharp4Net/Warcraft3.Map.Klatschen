gg_rct_Center = nil
gg_rct_CenterBottom = nil
gg_rct_CenterBottomComplete = nil
gg_rct_CenterComplete = nil
gg_rct_CenterLeft = nil
gg_rct_CenterLeftComplete = nil
gg_rct_CenterRight = nil
gg_rct_CenterRightComplete = nil
gg_rct_CenterTop = nil
gg_rct_CenterTopComplete = nil
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
gg_rct_ElfCreepToHumanSpawn = nil
gg_rct_ElfCreepToHumanSpawnBuilding = nil
gg_rct_ElfCreepToUndeadSpawn = nil
gg_rct_ElfCreepToUndeadSpawnBuilding = nil
gg_rct_HeroAlchemist = nil
gg_rct_HeroArchmage = nil
gg_rct_HeroBlademaster = nil
gg_rct_HeroBloodMage = nil
gg_rct_HeroBrewmaster = nil
gg_rct_HeroCryptLord = nil
gg_rct_HeroDarkRanger = nil
gg_rct_HeroDeathKnight = nil
gg_rct_HeroFarSeer = nil
gg_rct_HeroFirelord = nil
gg_rct_HeroKeeperOfTheGrove = nil
gg_rct_HeroLich = nil
gg_rct_HeroMountainKing = nil
gg_rct_HeroPitLord = nil
gg_rct_HeroPriestessOfMoon = nil
gg_rct_HeroSeaWitch = nil
gg_rct_HeroSelectionTotal = nil
gg_rct_HeroSelectorSpawn = nil
gg_rct_HeroShadowHunter = nil
gg_rct_HeroTaurenChieftain = nil
gg_rct_HeroTinker = nil
gg_rct_HeroWarden = nil
gg_rct_HumanBarracksToCenter = nil
gg_rct_HumanBarracksToCenterSpawn = nil
gg_rct_HumanBarracksToElf = nil
gg_rct_HumanBarracksToElfSpawn = nil
gg_rct_HumanBarracksToOrc = nil
gg_rct_HumanBarracksToOrcSpawn = nil
gg_rct_HumanBase = nil
gg_rct_HumanBaseHeroRespawn = nil
gg_rct_HumanBaseHeroSpawn = nil
gg_rct_HumanBaseToCenterSpawn = nil
gg_rct_HumanBaseToElfSpawn = nil
gg_rct_HumanBaseToOrcSpawn = nil
gg_rct_HumanCreepToElfSpawn = nil
gg_rct_HumanCreepToElfSpawnBuilding = nil
gg_rct_HumanCreepToOrcSpawn = nil
gg_rct_HumanCreepToOrcSpawnBuilding = nil
gg_rct_LegionSpawnBottom = nil
gg_rct_LegionSpawnBottom1 = nil
gg_rct_LegionSpawnBottom2 = nil
gg_rct_LegionSpawnEast = nil
gg_rct_LegionSpawnEast1 = nil
gg_rct_LegionSpawnEast2 = nil
gg_rct_LegionSpawnTop = nil
gg_rct_LegionSpawnTop1 = nil
gg_rct_LegionSpawnTop2 = nil
gg_rct_LegionSpawnWest = nil
gg_rct_LegionSpawnWest1 = nil
gg_rct_LegionSpawnWest2 = nil
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
gg_rct_OrcCreepToHumanSpawn = nil
gg_rct_OrcCreepToHumanSpawnBuilding = nil
gg_rct_OrcCreepToUndeadSpawn = nil
gg_rct_OrcCreepToUndeadSpawnBuilding = nil
gg_rct_TestArea = nil
gg_rct_TestArea2 = nil
gg_rct_TestArea3 = nil
gg_rct_UndeadBarracksToCenter = nil
gg_rct_UndeadBarracksToCenterSpawn = nil
gg_rct_UndeadBarracksToElf = nil
gg_rct_UndeadBarracksToElfSpawn = nil
gg_rct_UndeadBarracksToOrc = nil
gg_rct_UndeadBarracksToOrcSpawn = nil
gg_rct_UndeadBase = nil
gg_rct_UndeadBaseHeroRespawn = nil
gg_rct_UndeadBaseHeroSpawn = nil
gg_rct_UndeadBaseToCenterSpawn = nil
gg_rct_UndeadBaseToElfSpawn = nil
gg_rct_UndeadBaseToOrcSpawn = nil
gg_rct_UndeadCreepToElfSpawn = nil
gg_rct_UndeadCreepToElfSpawnBuilding = nil
gg_rct_UndeadCreepToOrcSpawn = nil
gg_rct_UndeadCreepToOrcSpawnBuilding = nil
gg_snd_blowitup_cutted = ""
gg_trg_Untitled_Trigger_001 = nil
function InitGlobals()
end

function InitSounds()
gg_snd_blowitup_cutted = "war3mapImported/blowitup_cutted.mp3"
end

function CreateBuildingsForPlayer0()
local p = Player(0)
local u
local unitID
local t
local life

u = BlzCreateUnitWithSkin(p, FourCC("h005"), -7680.0, 13568.0, 270.000, FourCC("h005"))
u = BlzCreateUnitWithSkin(p, FourCC("h005"), -7680.0, 13056.0, 270.000, FourCC("h005"))
u = BlzCreateUnitWithSkin(p, FourCC("h005"), -6656.0, 13312.0, 270.000, FourCC("h005"))
u = BlzCreateUnitWithSkin(p, FourCC("h004"), -5120.0, 13568.0, 270.000, FourCC("h004"))
u = BlzCreateUnitWithSkin(p, FourCC("h004"), -5120.0, 13056.0, 270.000, FourCC("h004"))
u = BlzCreateUnitWithSkin(p, FourCC("h004"), -4096.0, 13312.0, 270.000, FourCC("h004"))
u = BlzCreateUnitWithSkin(p, FourCC("h005"), -9984.0, 10752.0, 270.000, FourCC("h005"))
u = BlzCreateUnitWithSkin(p, FourCC("h005"), -10496.0, 10752.0, 270.000, FourCC("h005"))
u = BlzCreateUnitWithSkin(p, FourCC("h005"), -10240.0, 9728.0, 270.000, FourCC("h005"))
u = BlzCreateUnitWithSkin(p, FourCC("n005"), -12032.0, 15104.0, 270.000, FourCC("n005"))
u = BlzCreateUnitWithSkin(p, FourCC("h009"), -11264.0, 15232.0, 270.000, FourCC("h009"))
u = BlzCreateUnitWithSkin(p, FourCC("h02R"), -9472.0, 13312.0, 270.000, FourCC("h02R"))
u = BlzCreateUnitWithSkin(p, FourCC("h005"), -8576.0, 11264.0, 270.000, FourCC("h005"))
u = BlzCreateUnitWithSkin(p, FourCC("h005"), -8192.0, 11648.0, 270.000, FourCC("h005"))
u = BlzCreateUnitWithSkin(p, FourCC("h005"), -7808.0, 10880.0, 270.000, FourCC("h005"))
u = BlzCreateUnitWithSkin(p, FourCC("h004"), -9984.0, 8192.0, 270.000, FourCC("h004"))
u = BlzCreateUnitWithSkin(p, FourCC("h004"), -10496.0, 8192.0, 270.000, FourCC("h004"))
u = BlzCreateUnitWithSkin(p, FourCC("h004"), -10240.0, 7168.0, 270.000, FourCC("h004"))
u = BlzCreateUnitWithSkin(p, FourCC("h004"), -6016.0, 8704.0, 270.000, FourCC("h004"))
u = BlzCreateUnitWithSkin(p, FourCC("h004"), -5632.0, 9088.0, 270.000, FourCC("h004"))
u = BlzCreateUnitWithSkin(p, FourCC("h004"), -5248.0, 8320.0, 270.000, FourCC("h004"))
u = BlzCreateUnitWithSkin(p, FourCC("h02R"), -11008.0, 14080.0, 270.000, FourCC("h02R"))
u = BlzCreateUnitWithSkin(p, FourCC("h02R"), -12160.0, 14720.0, 270.000, FourCC("h02R"))
u = BlzCreateUnitWithSkin(p, FourCC("h02R"), -11648.0, 15232.0, 270.000, FourCC("h02R"))
u = BlzCreateUnitWithSkin(p, FourCC("n01I"), 4832.0, 10656.0, 270.000, FourCC("n01I"))
u = BlzCreateUnitWithSkin(p, FourCC("n02A"), 8416.0, 7200.0, 270.000, FourCC("n02A"))
u = BlzCreateUnitWithSkin(p, FourCC("h00T"), -10880.0, 15232.0, 270.000, FourCC("h00T"))
u = BlzCreateUnitWithSkin(p, FourCC("n02A"), 8224.0, 6688.0, 270.000, FourCC("n02A"))
u = BlzCreateUnitWithSkin(p, FourCC("n02A"), 7328.0, 7840.0, 270.000, FourCC("n02A"))
u = BlzCreateUnitWithSkin(p, FourCC("n02A"), 6944.0, 7072.0, 270.000, FourCC("n02A"))
u = BlzCreateUnitWithSkin(p, FourCC("h02R"), -10240.0, 12544.0, 270.000, FourCC("h02R"))
u = BlzCreateUnitWithSkin(p, FourCC("h02R"), -9600.0, 12672.0, 270.000, FourCC("h02R"))
end

function CreateUnitsForPlayer0()
local p = Player(0)
local u
local unitID
local t
local life

u = BlzCreateUnitWithSkin(p, FourCC("n02L"), 16821.3, 19262.4, 270.000, FourCC("n02L"))
u = BlzCreateUnitWithSkin(p, FourCC("nvlw"), -10481.6, 15017.3, 144.112, FourCC("nvlw"))
u = BlzCreateUnitWithSkin(p, FourCC("nvil"), -10534.3, 14958.8, 126.830, FourCC("nvil"))
u = BlzCreateUnitWithSkin(p, FourCC("nvlk"), -10586.0, 15049.3, 150.000, FourCC("nvlk"))
u = BlzCreateUnitWithSkin(p, FourCC("O005"), 14920.7, 16948.4, 270.000, FourCC("O005"))
end

function CreateBuildingsForPlayer1()
local p = Player(1)
local u
local unitID
local t
local life

u = BlzCreateUnitWithSkin(p, FourCC("h00A"), -12160.0, 14336.0, 270.000, FourCC("h00A"))
end

function CreateBuildingsForPlayer2()
local p = Player(2)
local u
local unitID
local t
local life

u = BlzCreateUnitWithSkin(p, FourCC("h00A"), -12160.0, 13952.0, 270.000, FourCC("h00A"))
end

function CreateBuildingsForPlayer3()
local p = Player(3)
local u
local unitID
local t
local life

u = BlzCreateUnitWithSkin(p, FourCC("h00A"), -12160.0, 13568.0, 270.000, FourCC("h00A"))
end

function CreateBuildingsForPlayer4()
local p = Player(4)
local u
local unitID
local t
local life

u = BlzCreateUnitWithSkin(p, FourCC("h00U"), 5248.0, 8320.0, 270.000, FourCC("h00U"))
u = BlzCreateUnitWithSkin(p, FourCC("h00V"), 7808.0, 10880.0, 270.000, FourCC("h00V"))
u = BlzCreateUnitWithSkin(p, FourCC("h00V"), 8192.0, 11648.0, 270.000, FourCC("h00V"))
u = BlzCreateUnitWithSkin(p, FourCC("h02S"), 9600.0, 12672.0, 270.000, FourCC("h02S"))
u = BlzCreateUnitWithSkin(p, FourCC("h02S"), 10240.0, 12544.0, 270.000, FourCC("h02S"))
u = BlzCreateUnitWithSkin(p, FourCC("h00V"), 6656.0, 13312.0, 270.000, FourCC("h00V"))
u = BlzCreateUnitWithSkin(p, FourCC("h00W"), 11264.0, 15232.0, 270.000, FourCC("h00W"))
u = BlzCreateUnitWithSkin(p, FourCC("h00U"), 4096.0, 13312.0, 270.000, FourCC("h00U"))
u = BlzCreateUnitWithSkin(p, FourCC("h00U"), 5632.0, 9088.0, 270.000, FourCC("h00U"))
u = BlzCreateUnitWithSkin(p, FourCC("h00V"), 7680.0, 13568.0, 270.000, FourCC("h00V"))
u = BlzCreateUnitWithSkin(p, FourCC("h00V"), 7680.0, 13056.0, 270.000, FourCC("h00V"))
u = BlzCreateUnitWithSkin(p, FourCC("h00V"), 8576.0, 11264.0, 270.000, FourCC("h00V"))
u = BlzCreateUnitWithSkin(p, FourCC("h00X"), 10880.0, 15232.0, 270.000, FourCC("h00X"))
u = BlzCreateUnitWithSkin(p, FourCC("h02S"), 9472.0, 13312.0, 270.000, FourCC("h02S"))
u = BlzCreateUnitWithSkin(p, FourCC("NBDB"), 12032.0, 15104.0, 270.000, FourCC("NBDB"))
u = BlzCreateUnitWithSkin(p, FourCC("h00V"), 10240.0, 9728.0, 270.000, FourCC("h00V"))
u = BlzCreateUnitWithSkin(p, FourCC("h00V"), 9984.0, 10752.0, 270.000, FourCC("h00V"))
u = BlzCreateUnitWithSkin(p, FourCC("h00V"), 10496.0, 10752.0, 270.000, FourCC("h00V"))
u = BlzCreateUnitWithSkin(p, FourCC("h00U"), 10240.0, 7168.0, 270.000, FourCC("h00U"))
u = BlzCreateUnitWithSkin(p, FourCC("h00U"), 9984.0, 8192.0, 270.000, FourCC("h00U"))
u = BlzCreateUnitWithSkin(p, FourCC("h00U"), 6016.0, 8704.0, 270.000, FourCC("h00U"))
u = BlzCreateUnitWithSkin(p, FourCC("h00U"), 5120.0, 13568.0, 270.000, FourCC("h00U"))
u = BlzCreateUnitWithSkin(p, FourCC("h00U"), 5120.0, 13056.0, 270.000, FourCC("h00U"))
u = BlzCreateUnitWithSkin(p, FourCC("h00U"), 10496.0, 8192.0, 270.000, FourCC("h00U"))
u = BlzCreateUnitWithSkin(p, FourCC("h02S"), 11008.0, 14080.0, 270.000, FourCC("h02S"))
u = BlzCreateUnitWithSkin(p, FourCC("h02S"), 12160.0, 14720.0, 270.000, FourCC("h02S"))
u = BlzCreateUnitWithSkin(p, FourCC("h02S"), 11648.0, 15232.0, 270.000, FourCC("h02S"))
end

function CreateUnitsForPlayer4()
local p = Player(4)
local u
local unitID
local t
local life

u = BlzCreateUnitWithSkin(p, FourCC("n02O"), 16835.8, 19002.6, 270.000, FourCC("n02O"))
end

function CreateBuildingsForPlayer5()
local p = Player(5)
local u
local unitID
local t
local life

u = BlzCreateUnitWithSkin(p, FourCC("h017"), 12160.0, 14336.0, 270.000, FourCC("h017"))
end

function CreateBuildingsForPlayer6()
local p = Player(6)
local u
local unitID
local t
local life

u = BlzCreateUnitWithSkin(p, FourCC("h017"), 12160.0, 13952.0, 270.000, FourCC("h017"))
end

function CreateBuildingsForPlayer7()
local p = Player(7)
local u
local unitID
local t
local life

u = BlzCreateUnitWithSkin(p, FourCC("h017"), 12160.0, 13568.0, 270.000, FourCC("h017"))
end

function CreateBuildingsForPlayer8()
local p = Player(8)
local u
local unitID
local t
local life

u = BlzCreateUnitWithSkin(p, FourCC("h010"), -10240.0, -1024.0, 270.000, FourCC("h010"))
IssueImmediateOrder(u, "root")
u = BlzCreateUnitWithSkin(p, FourCC("h010"), -10496.0, -2048.0, 270.000, FourCC("h010"))
u = BlzCreateUnitWithSkin(p, FourCC("h011"), -8192.0, -5504.0, 270.000, FourCC("h011"))
u = BlzCreateUnitWithSkin(p, FourCC("h011"), -8576.0, -5120.0, 270.000, FourCC("h011"))
u = BlzCreateUnitWithSkin(p, FourCC("h02U"), -11008.0, -7936.0, 270.000, FourCC("h02U"))
u = BlzCreateUnitWithSkin(p, FourCC("h02U"), -11648.0, -9088.0, 270.000, FourCC("h02U"))
u = BlzCreateUnitWithSkin(p, FourCC("h011"), -7680.0, -6912.0, 270.000, FourCC("h011"))
u = BlzCreateUnitWithSkin(p, FourCC("h010"), -5248.0, -2176.0, 270.000, FourCC("h010"))
u = BlzCreateUnitWithSkin(p, FourCC("h010"), -5632.0, -2944.0, 270.000, FourCC("h010"))
u = BlzCreateUnitWithSkin(p, FourCC("h010"), -9984.0, -2048.0, 270.000, FourCC("h010"))
u = BlzCreateUnitWithSkin(p, FourCC("h010"), -4096.0, -7168.0, 270.000, FourCC("h010"))
u = BlzCreateUnitWithSkin(p, FourCC("h010"), -5120.0, -7424.0, 270.000, FourCC("h010"))
u = BlzCreateUnitWithSkin(p, FourCC("h010"), -5120.0, -6912.0, 270.000, FourCC("h010"))
u = BlzCreateUnitWithSkin(p, FourCC("h011"), -6656.0, -7168.0, 270.000, FourCC("h011"))
u = BlzCreateUnitWithSkin(p, FourCC("h011"), -7680.0, -7424.0, 270.000, FourCC("h011"))
u = BlzCreateUnitWithSkin(p, FourCC("h010"), -6016.0, -2560.0, 270.000, FourCC("h010"))
u = BlzCreateUnitWithSkin(p, FourCC("h013"), -11264.0, -9088.0, 270.000, FourCC("h013"))
u = BlzCreateUnitWithSkin(p, FourCC("h02U"), -12160.0, -8576.0, 270.000, FourCC("h02U"))
u = BlzCreateUnitWithSkin(p, FourCC("h012"), -10880.0, -9088.0, 270.000, FourCC("h012"))
u = BlzCreateUnitWithSkin(p, FourCC("h02U"), -9472.0, -7168.0, 270.000, FourCC("h02U"))
u = BlzCreateUnitWithSkin(p, FourCC("h011"), -7808.0, -4736.0, 270.000, FourCC("h011"))
u = BlzCreateUnitWithSkin(p, FourCC("h011"), -10240.0, -3584.0, 270.000, FourCC("h011"))
u = BlzCreateUnitWithSkin(p, FourCC("h011"), -10496.0, -4608.0, 270.000, FourCC("h011"))
u = BlzCreateUnitWithSkin(p, FourCC("h011"), -9984.0, -4608.0, 270.000, FourCC("h011"))
u = BlzCreateUnitWithSkin(p, FourCC("h02U"), -9600.0, -6528.0, 270.000, FourCC("h02U"))
u = BlzCreateUnitWithSkin(p, FourCC("h02U"), -10240.0, -6400.0, 270.000, FourCC("h02U"))
end

function CreateUnitsForPlayer8()
local p = Player(8)
local u
local unitID
local t
local life

u = BlzCreateUnitWithSkin(p, FourCC("n02M"), 16818.3, 18761.9, 270.000, FourCC("n02M"))
end

function CreateBuildingsForPlayer9()
local p = Player(9)
local u
local unitID
local t
local life

u = BlzCreateUnitWithSkin(p, FourCC("h016"), -12160.0, -8192.0, 270.000, FourCC("h016"))
end

function CreateBuildingsForPlayer10()
local p = Player(10)
local u
local unitID
local t
local life

u = BlzCreateUnitWithSkin(p, FourCC("h016"), -12160.0, -7808.0, 270.000, FourCC("h016"))
end

function CreateBuildingsForPlayer11()
local p = Player(11)
local u
local unitID
local t
local life

u = BlzCreateUnitWithSkin(p, FourCC("h016"), -12160.0, -7424.0, 270.000, FourCC("h016"))
end

function CreateBuildingsForPlayer12()
local p = Player(12)
local u
local unitID
local t
local life

u = BlzCreateUnitWithSkin(p, FourCC("NEBL"), 12032.0, -8960.0, 270.000, FourCC("NEBL"))
u = BlzCreateUnitWithSkin(p, FourCC("h018"), 4096.0, -7168.0, 270.000, FourCC("h018"))
u = BlzCreateUnitWithSkin(p, FourCC("h01C"), 12160.0, -7808.0, 270.000, FourCC("h01C"))
u = BlzCreateUnitWithSkin(p, FourCC("h018"), 5120.0, -6784.0, 270.000, FourCC("h018"))
u = BlzCreateUnitWithSkin(p, FourCC("h019"), 10240.0, -3584.0, 270.000, FourCC("h019"))
u = BlzCreateUnitWithSkin(p, FourCC("h019"), 10496.0, -4608.0, 270.000, FourCC("h019"))
u = BlzCreateUnitWithSkin(p, FourCC("h018"), 10240.0, -1024.0, 270.000, FourCC("h018"))
u = BlzCreateUnitWithSkin(p, FourCC("h018"), 10496.0, -2048.0, 270.000, FourCC("h018"))
u = BlzCreateUnitWithSkin(p, FourCC("h019"), 6656.0, -7168.0, 270.000, FourCC("h019"))
u = BlzCreateUnitWithSkin(p, FourCC("h019"), 9984.0, -4608.0, 270.000, FourCC("h019"))
u = BlzCreateUnitWithSkin(p, FourCC("h02T"), 11008.0, -7936.0, 270.000, FourCC("h02T"))
u = BlzCreateUnitWithSkin(p, FourCC("h02T"), 11648.0, -9088.0, 270.000, FourCC("h02T"))
u = BlzCreateUnitWithSkin(p, FourCC("h01D"), 12160.0, -8192.0, 270.000, FourCC("h01D"))
u = BlzCreateUnitWithSkin(p, FourCC("h019"), 7680.0, -6912.0, 270.000, FourCC("h019"))
u = BlzCreateUnitWithSkin(p, FourCC("h019"), 7680.0, -7424.0, 270.000, FourCC("h019"))
u = BlzCreateUnitWithSkin(p, FourCC("h018"), 5120.0, -7424.0, 270.000, FourCC("h018"))
u = BlzCreateUnitWithSkin(p, FourCC("h018"), 9984.0, -2048.0, 270.000, FourCC("h018"))
u = BlzCreateUnitWithSkin(p, FourCC("h019"), 8576.0, -5120.0, 270.000, FourCC("h019"))
u = BlzCreateUnitWithSkin(p, FourCC("h019"), 8192.0, -5504.0, 270.000, FourCC("h019"))
u = BlzCreateUnitWithSkin(p, FourCC("h019"), 7808.0, -4736.0, 270.000, FourCC("h019"))
u = BlzCreateUnitWithSkin(p, FourCC("h018"), 5248.0, -2176.0, 270.000, FourCC("h018"))
u = BlzCreateUnitWithSkin(p, FourCC("h018"), 5632.0, -2944.0, 270.000, FourCC("h018"))
u = BlzCreateUnitWithSkin(p, FourCC("h018"), 6016.0, -2560.0, 270.000, FourCC("h018"))
u = BlzCreateUnitWithSkin(p, FourCC("h02T"), 12160.0, -8576.0, 270.000, FourCC("h02T"))
u = BlzCreateUnitWithSkin(p, FourCC("h02T"), 9472.0, -7168.0, 270.000, FourCC("h02T"))
u = BlzCreateUnitWithSkin(p, FourCC("h02T"), 9600.0, -6528.0, 270.000, FourCC("h02T"))
u = BlzCreateUnitWithSkin(p, FourCC("h02T"), 10240.0, -6400.0, 270.000, FourCC("h02T"))
end

function CreateUnitsForPlayer12()
local p = Player(12)
local u
local unitID
local t
local life

u = BlzCreateUnitWithSkin(p, FourCC("n02N"), 16822.7, 18506.3, 270.000, FourCC("n02N"))
end

function CreateBuildingsForPlayer13()
local p = Player(13)
local u
local unitID
local t
local life

u = BlzCreateUnitWithSkin(p, FourCC("h01F"), 10880.0, -9088.0, 270.000, FourCC("h01F"))
end

function CreateBuildingsForPlayer14()
local p = Player(14)
local u
local unitID
local t
local life

u = BlzCreateUnitWithSkin(p, FourCC("h01F"), 10496.0, -9088.0, 270.000, FourCC("h01F"))
end

function CreateBuildingsForPlayer15()
local p = Player(15)
local u
local unitID
local t
local life

u = BlzCreateUnitWithSkin(p, FourCC("h01F"), 11264.0, -9088.0, 270.000, FourCC("h01F"))
end

function CreateNeutralHostileBuildings()
local p = Player(PLAYER_NEUTRAL_AGGRESSIVE)
local u
local unitID
local t
local life

u = BlzCreateUnitWithSkin(p, FourCC("n02F"), 17760.0, 17504.0, 270.000, FourCC("n02F"))
u = BlzCreateUnitWithSkin(p, FourCC("n02B"), 18112.0, 18560.0, 270.000, FourCC("n02B"))
u = BlzCreateUnitWithSkin(p, FourCC("n02G"), 18080.0, 17504.0, 270.000, FourCC("n02G"))
u = BlzCreateUnitWithSkin(p, FourCC("n00V"), 17760.0, 19296.0, 270.000, FourCC("n00V"))
u = BlzCreateUnitWithSkin(p, FourCC("n01G"), 18080.0, 19296.0, 270.000, FourCC("n01G"))
u = BlzCreateUnitWithSkin(p, FourCC("n01H"), 17760.0, 19040.0, 270.000, FourCC("n01H"))
u = BlzCreateUnitWithSkin(p, FourCC("n01I"), 18080.0, 19040.0, 270.000, FourCC("n01I"))
u = BlzCreateUnitWithSkin(p, FourCC("n01J"), 17760.0, 18784.0, 270.000, FourCC("n01J"))
u = BlzCreateUnitWithSkin(p, FourCC("n02E"), 18080.0, 18784.0, 270.000, FourCC("n02E"))
u = BlzCreateUnitWithSkin(p, FourCC("n02D"), 17728.0, 18560.0, 270.000, FourCC("n02D"))
u = BlzCreateUnitWithSkin(p, FourCC("n026"), 17696.0, 18336.0, 270.000, FourCC("n026"))
u = BlzCreateUnitWithSkin(p, FourCC("n02A"), 18080.0, 18336.0, 270.000, FourCC("n02A"))
u = BlzCreateUnitWithSkin(p, FourCC("n00K"), 18048.0, 18112.0, 270.000, FourCC("n00K"))
u = BlzCreateUnitWithSkin(p, FourCC("n00P"), 17728.0, 18112.0, 270.000, FourCC("n00P"))
u = BlzCreateUnitWithSkin(p, FourCC("n024"), 17760.0, 17824.0, 270.000, FourCC("n024"))
u = BlzCreateUnitWithSkin(p, FourCC("n025"), 18080.0, 17824.0, 270.000, FourCC("n025"))
end

function CreateNeutralPassiveBuildings()
local p = Player(PLAYER_NEUTRAL_PASSIVE)
local u
local unitID
local t
local life

u = BlzCreateUnitWithSkin(p, FourCC("h004"), 16320.0, 19264.0, 270.000, FourCC("h004"))
u = BlzCreateUnitWithSkin(p, FourCC("h005"), 16576.0, 19264.0, 270.000, FourCC("h005"))
u = BlzCreateUnitWithSkin(p, FourCC("h00V"), 16576.0, 19008.0, 270.000, FourCC("h00V"))
u = BlzCreateUnitWithSkin(p, FourCC("h00U"), 16320.0, 19008.0, 270.000, FourCC("h00U"))
u = BlzCreateUnitWithSkin(p, FourCC("h011"), 16576.0, 18752.0, 270.000, FourCC("h011"))
u = BlzCreateUnitWithSkin(p, FourCC("h010"), 16320.0, 18752.0, 270.000, FourCC("h010"))
u = BlzCreateUnitWithSkin(p, FourCC("h018"), 16320.0, 18496.0, 270.000, FourCC("h018"))
u = BlzCreateUnitWithSkin(p, FourCC("h019"), 16576.0, 18496.0, 270.000, FourCC("h019"))
u = BlzCreateUnitWithSkin(p, FourCC("n01G"), -7392.0, 7712.0, 270.000, FourCC("n01G"))
u = BlzCreateUnitWithSkin(p, FourCC("n01G"), -7072.0, 7264.0, 270.000, FourCC("n01G"))
u = BlzCreateUnitWithSkin(p, FourCC("n01G"), -8160.0, 6944.0, 270.000, FourCC("n01G"))
u = BlzCreateUnitWithSkin(p, FourCC("NBDL"), -12032.0, -8960.0, 270.000, FourCC("NBDL"))
u = BlzCreateUnitWithSkin(p, FourCC("n01G"), -7968.0, 6496.0, 270.000, FourCC("n01G"))
u = BlzCreateUnitWithSkin(p, FourCC("n00K"), -8192.0, -704.0, 270.000, FourCC("n00K"))
u = BlzCreateUnitWithSkin(p, FourCC("n00K"), -7168.0, -768.0, 270.000, FourCC("n00K"))
u = BlzCreateUnitWithSkin(p, FourCC("n00K"), -8256.0, -1216.0, 270.000, FourCC("n00K"))
u = BlzCreateUnitWithSkin(p, FourCC("n00K"), -7104.0, -1280.0, 270.000, FourCC("n00K"))
u = BlzCreateUnitWithSkin(p, FourCC("n01G"), -7264.0, 6880.0, 270.000, FourCC("n01G"))
u = BlzCreateUnitWithSkin(p, FourCC("n02G"), -3488.0, 10784.0, 270.000, FourCC("n02G"))
u = BlzCreateUnitWithSkin(p, FourCC("n02G"), -3424.0, 10592.0, 270.000, FourCC("n02G"))
u = BlzCreateUnitWithSkin(p, FourCC("n02G"), -4768.0, 10528.0, 270.000, FourCC("n02G"))
u = BlzCreateUnitWithSkin(p, FourCC("n02G"), -4512.0, 10208.0, 270.000, FourCC("n02G"))
u = BlzCreateUnitWithSkin(p, FourCC("n01I"), 4576.0, 10208.0, 270.000, FourCC("n01I"))
u = BlzCreateUnitWithSkin(p, FourCC("n01I"), 3808.0, 10016.0, 270.000, FourCC("n01I"))
u = BlzCreateUnitWithSkin(p, FourCC("n01I"), 3552.0, 10208.0, 270.000, FourCC("n01I"))
u = BlzCreateUnitWithSkin(p, FourCC("n01I"), 3360.0, 10784.0, 270.000, FourCC("n01I"))
u = BlzCreateUnitWithSkin(p, FourCC("n00K"), -7424.0, -1600.0, 270.000, FourCC("n00K"))
u = BlzCreateUnitWithSkin(p, FourCC("n025"), 7136.0, -1056.0, 270.000, FourCC("n025"))
u = BlzCreateUnitWithSkin(p, FourCC("n025"), 8224.0, -800.0, 270.000, FourCC("n025"))
u = BlzCreateUnitWithSkin(p, FourCC("n025"), 7264.0, -736.0, 270.000, FourCC("n025"))
u = BlzCreateUnitWithSkin(p, FourCC("n025"), 7264.0, -1568.0, 270.000, FourCC("n025"))
u = BlzCreateUnitWithSkin(p, FourCC("n02E"), 4448.0, -4256.0, 270.000, FourCC("n02E"))
u = BlzCreateUnitWithSkin(p, FourCC("n02E"), 4704.0, -4640.0, 270.000, FourCC("n02E"))
u = BlzCreateUnitWithSkin(p, FourCC("n02E"), 3808.0, -4960.0, 270.000, FourCC("n02E"))
u = BlzCreateUnitWithSkin(p, FourCC("n02E"), 3744.0, -4384.0, 270.000, FourCC("n02E"))
u = BlzCreateUnitWithSkin(p, FourCC("n02B"), -3456.0, -4352.0, 270.000, FourCC("n02B"))
u = BlzCreateUnitWithSkin(p, FourCC("n02B"), -4608.0, -4224.0, 270.000, FourCC("n02B"))
u = BlzCreateUnitWithSkin(p, FourCC("n02B"), -4032.0, -5248.0, 270.000, FourCC("n02B"))
u = BlzCreateUnitWithSkin(p, FourCC("n02G"), -3552.0, 10336.0, 270.000, FourCC("n02G"))
u = BlzCreateUnitWithSkin(p, FourCC("n02B"), -3584.0, -4800.0, 270.000, FourCC("n02B"))
u = BlzCreateUnitWithSkin(p, FourCC("n02I"), 16320.0, 17344.0, 270.000, FourCC("n02I"))
end

function CreateNeutralPassive()
local p = Player(PLAYER_NEUTRAL_PASSIVE)
local u
local unitID
local t
local life

u = BlzCreateUnitWithSkin(p, FourCC("e001"), 14145.4, 18111.5, 270.000, FourCC("e001"))
u = BlzCreateUnitWithSkin(p, FourCC("e002"), 14280.2, 18114.0, 270.000, FourCC("e002"))
u = BlzCreateUnitWithSkin(p, FourCC("h001"), 14141.2, 19257.5, 270.000, FourCC("h001"))
u = BlzCreateUnitWithSkin(p, FourCC("h00C"), 14266.6, 19272.0, 270.000, FourCC("h00C"))
u = BlzCreateUnitWithSkin(p, FourCC("h00B"), 14396.9, 19263.5, 270.000, FourCC("h00B"))
u = BlzCreateUnitWithSkin(p, FourCC("e003"), 14415.8, 18106.7, 270.000, FourCC("e003"))
u = BlzCreateUnitWithSkin(p, FourCC("h00P"), 14533.0, 18101.8, 270.000, FourCC("h00P"))
u = BlzCreateUnitWithSkin(p, FourCC("h002"), 14532.2, 19269.6, 270.000, FourCC("h002"))
u = BlzCreateUnitWithSkin(p, FourCC("h00F"), 14658.8, 19267.2, 270.000, FourCC("h00F"))
u = BlzCreateUnitWithSkin(p, FourCC("h00G"), 14783.0, 19263.5, 270.000, FourCC("h00G"))
u = BlzCreateUnitWithSkin(p, FourCC("h00J"), 14909.5, 19264.8, 270.000, FourCC("h00J"))
u = BlzCreateUnitWithSkin(p, FourCC("h00K"), 15034.9, 19257.5, 270.000, FourCC("h00K"))
u = BlzCreateUnitWithSkin(p, FourCC("h00L"), 15152.9, 19266.0, 270.000, FourCC("h00L"))
u = BlzCreateUnitWithSkin(p, FourCC("h008"), 15297.6, 19264.8, 270.000, FourCC("h008"))
u = BlzCreateUnitWithSkin(p, FourCC("h00H"), 15418.1, 19266.0, 270.000, FourCC("h00H"))
u = BlzCreateUnitWithSkin(p, FourCC("h00I"), 15548.4, 19261.1, 270.000, FourCC("h00I"))
u = BlzCreateUnitWithSkin(p, FourCC("h00E"), 15686.6, 19268.7, 270.000, FourCC("h00E"))
u = BlzCreateUnitWithSkin(p, FourCC("h00S"), 15809.1, 19266.0, 270.000, FourCC("h00S"))
u = BlzCreateUnitWithSkin(p, FourCC("h01J"), 14271.5, 19010.4, 270.000, FourCC("h01J"))
u = BlzCreateUnitWithSkin(p, FourCC("h01I"), 14129.5, 19009.3, 270.000, FourCC("h01I"))
u = BlzCreateUnitWithSkin(p, FourCC("h01K"), 14395.9, 19005.8, 270.000, FourCC("h01K"))
u = BlzCreateUnitWithSkin(p, FourCC("h01L"), 14539.7, 19013.3, 270.000, FourCC("h01L"))
u = BlzCreateUnitWithSkin(p, FourCC("h01M"), 14664.6, 19014.8, 270.000, FourCC("h01M"))
u = BlzCreateUnitWithSkin(p, FourCC("h01N"), 14789.6, 19004.6, 270.000, FourCC("h01N"))
u = BlzCreateUnitWithSkin(p, FourCC("h01V"), 15810.1, 19013.3, 270.000, FourCC("h01V"))
u = BlzCreateUnitWithSkin(p, FourCC("h01U"), 15682.2, 19022.0, 270.000, FourCC("h01U"))
u = BlzCreateUnitWithSkin(p, FourCC("h01P"), 15051.4, 19007.5, 270.000, FourCC("h01P"))
u = BlzCreateUnitWithSkin(p, FourCC("h01O"), 14935.4, 18997.3, 270.000, FourCC("h01O"))
u = BlzCreateUnitWithSkin(p, FourCC("h01Q"), 15180.8, 19013.3, 270.000, FourCC("h01Q"))
u = BlzCreateUnitWithSkin(p, FourCC("h01R"), 15302.8, 19011.9, 270.000, FourCC("h01R"))
u = BlzCreateUnitWithSkin(p, FourCC("h01S"), 15429.3, 19006.0, 270.000, FourCC("h01S"))
u = BlzCreateUnitWithSkin(p, FourCC("h01T"), 15543.8, 19006.0, 270.000, FourCC("h01T"))
u = BlzCreateUnitWithSkin(p, FourCC("H00M"), 16059.3, 19259.2, 270.000, FourCC("H00M"))
u = BlzCreateUnitWithSkin(p, FourCC("H01W"), 16055.7, 19011.1, 270.000, FourCC("H01W"))
u = BlzCreateUnitWithSkin(p, FourCC("h020"), 14258.2, 18489.2, 270.000, FourCC("h020"))
u = BlzCreateUnitWithSkin(p, FourCC("h01Y"), 14138.7, 18482.8, 270.000, FourCC("h01Y"))
u = BlzCreateUnitWithSkin(p, FourCC("h022"), 14397.3, 18495.6, 270.000, FourCC("h022"))
u = BlzCreateUnitWithSkin(p, FourCC("h024"), 14518.3, 18490.8, 270.000, FourCC("h024"))
u = BlzCreateUnitWithSkin(p, FourCC("h026"), 14649.3, 18498.8, 270.000, FourCC("h026"))
u = BlzCreateUnitWithSkin(p, FourCC("h028"), 14780.2, 18484.4, 270.000, FourCC("h028"))
u = BlzCreateUnitWithSkin(p, FourCC("h02E"), 14914.4, 18503.6, 270.000, FourCC("h02E"))
u = BlzCreateUnitWithSkin(p, FourCC("h02A"), 15153.9, 18484.9, 270.000, FourCC("h02A"))
u = BlzCreateUnitWithSkin(p, FourCC("h02K"), 15290.8, 18494.0, 270.000, FourCC("h02K"))
u = BlzCreateUnitWithSkin(p, FourCC("h02I"), 15403.7, 18492.4, 270.000, FourCC("h02I"))
u = BlzCreateUnitWithSkin(p, FourCC("h02O"), 15670.4, 18510.0, 270.000, FourCC("h02O"))
u = BlzCreateUnitWithSkin(p, FourCC("h02M"), 15798.1, 18487.6, 270.000, FourCC("h02M"))
u = BlzCreateUnitWithSkin(p, FourCC("h02G"), 15537.9, 18487.6, 270.000, FourCC("h02G"))
u = BlzCreateUnitWithSkin(p, FourCC("h02C"), 15030.6, 18490.8, 270.000, FourCC("h02C"))
u = BlzCreateUnitWithSkin(p, FourCC("h01Z"), 14272.9, 18756.5, 270.000, FourCC("h01Z"))
u = BlzCreateUnitWithSkin(p, FourCC("h01X"), 14151.8, 18750.1, 270.000, FourCC("h01X"))
u = BlzCreateUnitWithSkin(p, FourCC("h021"), 14394.0, 18751.7, 270.000, FourCC("h021"))
u = BlzCreateUnitWithSkin(p, FourCC("h023"), 14520.0, 18750.1, 270.000, FourCC("h023"))
u = BlzCreateUnitWithSkin(p, FourCC("h025"), 14647.6, 18751.7, 270.000, FourCC("h025"))
u = BlzCreateUnitWithSkin(p, FourCC("h027"), 14801.5, 18758.1, 270.000, FourCC("h027"))
u = BlzCreateUnitWithSkin(p, FourCC("h02D"), 14919.3, 18742.1, 270.000, FourCC("h02D"))
u = BlzCreateUnitWithSkin(p, FourCC("h029"), 15174.6, 18754.9, 270.000, FourCC("h029"))
u = BlzCreateUnitWithSkin(p, FourCC("h02J"), 15300.6, 18748.5, 270.000, FourCC("h02J"))
u = BlzCreateUnitWithSkin(p, FourCC("h02H"), 15428.2, 18750.1, 270.000, FourCC("h02H"))
u = BlzCreateUnitWithSkin(p, FourCC("h02N"), 15680.0, 18752.7, 270.000, FourCC("h02N"))
u = BlzCreateUnitWithSkin(p, FourCC("h02L"), 15804.6, 18761.3, 270.000, FourCC("h02L"))
u = BlzCreateUnitWithSkin(p, FourCC("h02F"), 15541.1, 18756.5, 270.000, FourCC("h02F"))
u = BlzCreateUnitWithSkin(p, FourCC("h02B"), 15051.8, 18751.7, 270.000, FourCC("h02B"))
u = BlzCreateUnitWithSkin(p, FourCC("H02P"), 16060.4, 18751.7, 270.000, FourCC("H02P"))
u = BlzCreateUnitWithSkin(p, FourCC("H02Q"), 16058.8, 18500.4, 270.000, FourCC("H02Q"))
u = BlzCreateUnitWithSkin(p, FourCC("N006"), 16059.5, 17347.9, 270.000, FourCC("N006"))
u = BlzCreateUnitWithSkin(p, FourCC("n01O"), 17222.7, 19253.2, 270.000, FourCC("n01O"))
u = BlzCreateUnitWithSkin(p, FourCC("n014"), 17227.1, 19142.6, 270.000, FourCC("n014"))
u = BlzCreateUnitWithSkin(p, FourCC("n00T"), 15802.6, 17340.8, 270.000, FourCC("n00T"))
u = BlzCreateUnitWithSkin(p, FourCC("n00J"), 15292.0, 17346.3, 270.000, FourCC("n00J"))
u = BlzCreateUnitWithSkin(p, FourCC("h00Q"), 14665.7, 18111.5, 270.000, FourCC("h00Q"))
u = BlzCreateUnitWithSkin(p, FourCC("n00C"), 15172.4, 17343.6, 270.000, FourCC("n00C"))
u = BlzCreateUnitWithSkin(p, FourCC("n00N"), 15545.3, 17334.9, 270.000, FourCC("n00N"))
u = BlzCreateUnitWithSkin(p, FourCC("n00F"), 15421.9, 17340.8, 270.000, FourCC("n00F"))
u = BlzCreateUnitWithSkin(p, FourCC("h00R"), 14788.8, 18114.0, 270.000, FourCC("h00R"))
u = BlzCreateUnitWithSkin(p, FourCC("h02V"), 14919.7, 18106.7, 270.000, FourCC("h02V"))
u = BlzCreateUnitWithSkin(p, FourCC("h02W"), 15044.5, 18104.2, 270.000, FourCC("h02W"))
u = BlzCreateUnitWithSkin(p, FourCC("E000"), -2111.0, 18750.9, 270.000, FourCC("E000"))
u = BlzCreateUnitWithSkin(p, FourCC("h02X"), 15159.2, 18099.4, 270.000, FourCC("h02X"))
u = BlzCreateUnitWithSkin(p, FourCC("o002"), 15294.7, 18101.8, 270.000, FourCC("o002"))
u = BlzCreateUnitWithSkin(p, FourCC("o003"), 15436.0, 18118.8, 270.000, FourCC("o003"))
u = BlzCreateUnitWithSkin(p, FourCC("o004"), 15558.5, 18104.2, 270.000, FourCC("o004"))
u = BlzCreateUnitWithSkin(p, FourCC("u000"), 15685.0, 18099.4, 270.000, FourCC("u000"))
u = BlzCreateUnitWithSkin(p, FourCC("n00Q"), 15672.7, 17339.3, 270.000, FourCC("n00Q"))
u = BlzCreateUnitWithSkin(p, FourCC("n01D"), 17471.1, 19138.2, 270.000, FourCC("n01D"))
u = BlzCreateUnitWithSkin(p, FourCC("n01F"), 17475.6, 19004.4, 270.000, FourCC("n01F"))
u = BlzCreateUnitWithSkin(p, FourCC("n01L"), 17478.6, 18882.2, 270.000, FourCC("n01L"))
u = BlzCreateUnitWithSkin(p, FourCC("n01N"), 17481.5, 18750.0, 270.000, FourCC("n01N"))
u = BlzCreateUnitWithSkin(p, FourCC("n01P"), 17483.0, 18624.9, 270.000, FourCC("n01P"))
u = BlzCreateUnitWithSkin(p, FourCC("n01E"), 17474.1, 18496.9, 270.000, FourCC("n01E"))
u = BlzCreateUnitWithSkin(p, FourCC("n01S"), 17469.6, 18366.0, 270.000, FourCC("n01S"))
u = BlzCreateUnitWithSkin(p, FourCC("n01Q"), 17341.7, 19135.3, 270.000, FourCC("n01Q"))
u = BlzCreateUnitWithSkin(p, FourCC("n01U"), 17346.2, 19001.5, 270.000, FourCC("n01U"))
u = BlzCreateUnitWithSkin(p, FourCC("n01K"), 17346.3, 18874.1, 270.000, FourCC("n01K"))
u = BlzCreateUnitWithSkin(p, FourCC("n013"), 17343.2, 19261.9, 270.000, FourCC("n013"))
u = BlzCreateUnitWithSkin(p, FourCC("N02K"), -4417.2, 17088.2, 180.000, FourCC("N02K"))
u = BlzCreateUnitWithSkin(p, FourCC("H00O"), 15303.3, 16934.0, 270.000, FourCC("H00O"))
u = BlzCreateUnitWithSkin(p, FourCC("H00N"), 14533.9, 16924.5, 270.000, FourCC("H00N"))
u = BlzCreateUnitWithSkin(p, FourCC("O000"), 14810.3, 17073.3, 270.000, FourCC("O000"))
u = BlzCreateUnitWithSkin(p, FourCC("n00X"), 17468.2, 19263.4, 270.000, FourCC("n00X"))
u = BlzCreateUnitWithSkin(p, FourCC("n01Z"), 17207.8, 18998.6, 270.000, FourCC("n01Z"))
u = BlzCreateUnitWithSkin(p, FourCC("n01C"), 17347.7, 18754.2, 270.000, FourCC("n01C"))
u = BlzCreateUnitWithSkin(p, FourCC("n01W"), 17349.1, 18629.1, 270.000, FourCC("n01W"))
u = BlzCreateUnitWithSkin(p, FourCC("n01V"), 17344.7, 18496.9, 270.000, FourCC("n01V"))
u = BlzCreateUnitWithSkin(p, FourCC("nCOP"), -3648.0, 18560.0, 270.000, FourCC("nCOP"))
u = BlzCreateUnitWithSkin(p, FourCC("nCOP"), -4032.0, 18560.0, 270.000, FourCC("nCOP"))
u = BlzCreateUnitWithSkin(p, FourCC("nCOP"), -4416.0, 18560.0, 270.000, FourCC("nCOP"))
u = BlzCreateUnitWithSkin(p, FourCC("nCOP"), -2496.0, 18560.0, 270.000, FourCC("nCOP"))
u = BlzCreateUnitWithSkin(p, FourCC("nCOP"), -2112.0, 18560.0, 270.000, FourCC("nCOP"))
u = BlzCreateUnitWithSkin(p, FourCC("nCOP"), -1728.0, 18560.0, 270.000, FourCC("nCOP"))
u = BlzCreateUnitWithSkin(p, FourCC("nCOP"), -1920.0, 17856.0, 270.000, FourCC("nCOP"))
u = BlzCreateUnitWithSkin(p, FourCC("nCOP"), -1920.0, 17472.0, 270.000, FourCC("nCOP"))
u = BlzCreateUnitWithSkin(p, FourCC("n01M"), 17217.6, 18874.1, 270.000, FourCC("n01M"))
u = BlzCreateUnitWithSkin(p, FourCC("n01Y"), 17225.7, 18764.6, 270.000, FourCC("n01Y"))
u = BlzCreateUnitWithSkin(p, FourCC("n01T"), 17219.7, 18629.3, 270.000, FourCC("n01T"))
u = BlzCreateUnitWithSkin(p, FourCC("n01B"), 17214.3, 18493.8, 270.000, FourCC("n01B"))
u = BlzCreateUnitWithSkin(p, FourCC("n020"), 17222.7, 18365.8, 270.000, FourCC("n020"))
u = BlzCreateUnitWithSkin(p, FourCC("n01X"), 17333.0, 18358.6, 270.000, FourCC("n01X"))
u = BlzCreateUnitWithSkin(p, FourCC("n01R"), 17092.1, 19249.2, 270.000, FourCC("n01R"))
u = BlzCreateUnitWithSkin(p, FourCC("n029"), 17085.6, 18367.6, 270.000, FourCC("n029"))
u = BlzCreateUnitWithSkin(p, FourCC("n021"), 17101.1, 19131.3, 270.000, FourCC("n021"))
u = BlzCreateUnitWithSkin(p, FourCC("n022"), 17086.7, 19011.6, 270.000, FourCC("n022"))
u = BlzCreateUnitWithSkin(p, FourCC("n023"), 17086.7, 18891.9, 270.000, FourCC("n023"))
u = BlzCreateUnitWithSkin(p, FourCC("n027"), 17077.7, 18754.6, 270.000, FourCC("n027"))
u = BlzCreateUnitWithSkin(p, FourCC("n02C"), 17088.5, 18481.8, 270.000, FourCC("n02C"))
u = BlzCreateUnitWithSkin(p, FourCC("n028"), 17081.3, 18617.3, 270.000, FourCC("n028"))
u = BlzCreateUnitWithSkin(p, FourCC("O001"), 15446.1, 16936.3, 270.000, FourCC("O001"))
u = BlzCreateUnitWithSkin(p, FourCC("N002"), 15284.4, 17054.9, 270.000, FourCC("N002"))
u = BlzCreateUnitWithSkin(p, FourCC("N007"), 14795.5, 16948.2, 270.000, FourCC("N007"))
u = BlzCreateUnitWithSkin(p, FourCC("N008"), 14669.8, 16948.2, 270.000, FourCC("N008"))
u = BlzCreateUnitWithSkin(p, FourCC("N009"), 15553.0, 16957.3, 270.000, FourCC("N009"))
u = BlzCreateUnitWithSkin(p, FourCC("N004"), 15420.1, 17084.5, 270.000, FourCC("N004"))
u = BlzCreateUnitWithSkin(p, FourCC("N00A"), 14533.4, 17066.0, 270.000, FourCC("N00A"))
u = BlzCreateUnitWithSkin(p, FourCC("N001"), 14672.1, 17064.7, 270.000, FourCC("N001"))
u = BlzCreateUnitWithSkin(p, FourCC("nCOP"), -1920.0, 17088.0, 270.000, FourCC("nCOP"))
u = BlzCreateUnitWithSkin(p, FourCC("nCOP"), -4608.0, 17472.0, 270.000, FourCC("nCOP"))
u = BlzCreateUnitWithSkin(p, FourCC("nCOP"), -4608.0, 17856.0, 270.000, FourCC("nCOP"))
u = BlzCreateUnitWithSkin(p, FourCC("nrac"), -11561.7, -7341.4, 213.306, FourCC("nrac"))
u = BlzCreateUnitWithSkin(p, FourCC("nrac"), -12413.1, -8330.2, 140.904, FourCC("nrac"))
u = BlzCreateUnitWithSkin(p, FourCC("nrac"), -11533.0, -9275.9, 282.709, FourCC("nrac"))
u = BlzCreateUnitWithSkin(p, FourCC("nrac"), -10477.6, -8411.1, 32.455, FourCC("nrac"))
u = BlzCreateUnitWithSkin(p, FourCC("nrac"), -10070.8, -9254.2, 268.404, FourCC("nrac"))
u = BlzCreateUnitWithSkin(p, FourCC("nrac"), -10856.7, -6434.9, 217.877, FourCC("nrac"))
u = BlzCreateUnitWithSkin(p, FourCC("nrac"), -8577.0, -6073.6, 261.735, FourCC("nrac"))
u = BlzCreateUnitWithSkin(p, FourCC("nrac"), -8520.7, -7771.3, 226.973, FourCC("nrac"))
u = BlzCreateUnitWithSkin(p, FourCC("nrac"), -5465.6, -6480.4, 170.238, FourCC("nrac"))
u = BlzCreateUnitWithSkin(p, FourCC("nrac"), -3751.2, -7785.7, 71.249, FourCC("nrac"))
u = BlzCreateUnitWithSkin(p, FourCC("nrac"), -10855.7, -3784.9, 225.040, FourCC("nrac"))
u = BlzCreateUnitWithSkin(p, FourCC("nrac"), -9653.7, -2412.5, 348.772, FourCC("nrac"))
u = BlzCreateUnitWithSkin(p, FourCC("nrac"), -7611.5, -282.0, 157.516, FourCC("nrac"))
u = BlzCreateUnitWithSkin(p, FourCC("nrac"), -6956.7, -989.9, 252.924, FourCC("nrac"))
u = BlzCreateUnitWithSkin(p, FourCC("nrac"), -3372.4, -4727.6, 288.213, FourCC("nrac"))
u = BlzCreateUnitWithSkin(p, FourCC("nfro"), 4260.2, -5328.6, 115.657, FourCC("nfro"))
u = BlzCreateUnitWithSkin(p, FourCC("nfro"), 4587.7, -4077.0, 114.107, FourCC("nfro"))
u = BlzCreateUnitWithSkin(p, FourCC("nfro"), 7330.3, -1731.6, 194.123, FourCC("nfro"))
u = BlzCreateUnitWithSkin(p, FourCC("nfro"), 8078.5, -492.4, 146.419, FourCC("nfro"))
u = BlzCreateUnitWithSkin(p, FourCC("nfro"), 12512.6, -7278.3, 301.309, FourCC("nfro"))
u = BlzCreateUnitWithSkin(p, FourCC("nfro"), 10108.2, -8996.7, 128.335, FourCC("nfro"))
u = BlzCreateUnitWithSkin(p, FourCC("nCOP"), -2880.0, 18560.0, 270.000, FourCC("nCOP"))
u = BlzCreateUnitWithSkin(p, FourCC("nCOP"), -4800.0, 18560.0, 270.000, FourCC("nCOP"))
u = BlzCreateUnitWithSkin(p, FourCC("u001"), 15812.5, 18109.6, 270.000, FourCC("u001"))
u = BlzCreateUnitWithSkin(p, FourCC("u002"), 15943.9, 18095.7, 270.000, FourCC("u002"))
u = BlzCreateUnitWithSkin(p, FourCC("N02H"), 15179.0, 16924.5, 270.000, FourCC("N02H"))
SetUnitState(u, UNIT_STATE_MANA, 220)
u = BlzCreateUnitWithSkin(p, FourCC("E000"), 15556.0, 17072.2, 270.000, FourCC("E000"))
u = BlzCreateUnitWithSkin(p, FourCC("H00O"), -1725.2, 18748.4, 270.000, FourCC("H00O"))
u = BlzCreateUnitWithSkin(p, FourCC("N004"), -2501.7, 18753.8, 270.000, FourCC("N004"))
u = BlzCreateUnitWithSkin(p, FourCC("N002"), -2116.3, 17086.2, 0.000, FourCC("N002"))
SetUnitState(u, UNIT_STATE_MANA, 220)
u = BlzCreateUnitWithSkin(p, FourCC("N009"), -2108.5, 17466.8, 0.000, FourCC("N009"))
u = BlzCreateUnitWithSkin(p, FourCC("N02H"), -2879.7, 18754.7, 270.000, FourCC("N02H"))
u = BlzCreateUnitWithSkin(p, FourCC("O001"), -2106.2, 17855.5, 0.000, FourCC("O001"))
u = BlzCreateUnitWithSkin(p, FourCC("N001"), -4824.4, 18744.9, 270.000, FourCC("N001"))
u = BlzCreateUnitWithSkin(p, FourCC("O000"), -4417.5, 17481.9, 180.000, FourCC("O000"))
u = BlzCreateUnitWithSkin(p, FourCC("N008"), -3646.3, 18749.9, 270.000, FourCC("N008"))
u = BlzCreateUnitWithSkin(p, FourCC("N007"), -4047.1, 18757.5, 270.000, FourCC("N007"))
u = BlzCreateUnitWithSkin(p, FourCC("N00A"), -4428.5, 17848.3, 180.000, FourCC("N00A"))
u = BlzCreateUnitWithSkin(p, FourCC("H00N"), -4414.9, 18744.9, 270.000, FourCC("H00N"))
u = BlzCreateUnitWithSkin(p, FourCC("N02J"), -3781.6, 17852.4, 0.000, FourCC("N02J"))
u = BlzCreateUnitWithSkin(p, FourCC("nCOP"), -3584.0, 17856.0, 270.000, FourCC("nCOP"))
u = BlzCreateUnitWithSkin(p, FourCC("N02J"), 14404.7, 17079.6, 270.000, FourCC("N02J"))
u = BlzCreateUnitWithSkin(p, FourCC("nCOP"), -4608.0, 17088.0, 270.000, FourCC("nCOP"))
u = BlzCreateUnitWithSkin(p, FourCC("N02K"), 14396.8, 16942.1, 270.000, FourCC("N02K"))
u = BlzCreateUnitWithSkin(p, FourCC("n00G"), 16706.1, 17902.2, 270.000, FourCC("n00G"))
u = BlzCreateUnitWithSkin(p, FourCC("n00H"), 16945.5, 17919.4, 270.000, FourCC("n00H"))
u = BlzCreateUnitWithSkin(p, FourCC("n00I"), 17213.1, 17919.4, 270.000, FourCC("n00I"))
u = BlzCreateUnitWithSkin(p, FourCC("n00D"), 16720.1, 18111.9, 270.000, FourCC("n00D"))
u = BlzCreateUnitWithSkin(p, FourCC("n00B"), 16940.5, 18102.7, 270.000, FourCC("n00B"))
u = BlzCreateUnitWithSkin(p, FourCC("n00E"), 17187.9, 18098.1, 270.000, FourCC("n00E"))
u = BlzCreateUnitWithSkin(p, FourCC("n018"), 14153.4, 17980.6, 270.000, FourCC("n018"))
u = BlzCreateUnitWithSkin(p, FourCC("n019"), 14275.0, 17956.4, 270.000, FourCC("n019"))
u = BlzCreateUnitWithSkin(p, FourCC("n01A"), 14406.9, 17960.7, 270.000, FourCC("n01A"))
u = BlzCreateUnitWithSkin(p, FourCC("n00M"), 14544.2, 17952.0, 270.000, FourCC("n00M"))
u = BlzCreateUnitWithSkin(p, FourCC("n00L"), 14923.7, 17969.5, 270.000, FourCC("n00L"))
u = BlzCreateUnitWithSkin(p, FourCC("n00Y"), 15308.1, 17976.1, 270.000, FourCC("n00Y"))
u = BlzCreateUnitWithSkin(p, FourCC("n00O"), 14674.4, 17980.6, 270.000, FourCC("n00O"))
u = BlzCreateUnitWithSkin(p, FourCC("n00U"), 15047.0, 17976.1, 270.000, FourCC("n00U"))
u = BlzCreateUnitWithSkin(p, FourCC("n00W"), 15427.2, 17976.1, 270.000, FourCC("n00W"))
u = BlzCreateUnitWithSkin(p, FourCC("n00R"), 14795.5, 17978.3, 270.000, FourCC("n00R"))
u = BlzCreateUnitWithSkin(p, FourCC("n00S"), 15172.8, 17967.3, 270.000, FourCC("n00S"))
u = BlzCreateUnitWithSkin(p, FourCC("n00Z"), 15530.1, 17969.5, 270.000, FourCC("n00Z"))
u = BlzCreateUnitWithSkin(p, FourCC("n010"), 15674.8, 17987.2, 270.000, FourCC("n010"))
u = BlzCreateUnitWithSkin(p, FourCC("n011"), 15809.4, 17969.5, 270.000, FourCC("n011"))
u = BlzCreateUnitWithSkin(p, FourCC("n012"), 15934.5, 17987.2, 270.000, FourCC("n012"))
u = BlzCreateUnitWithSkin(p, FourCC("n016"), 16192.3, 18056.8, 270.000, FourCC("n016"))
u = BlzCreateUnitWithSkin(p, FourCC("n017"), 16330.7, 18061.4, 270.000, FourCC("n017"))
u = BlzCreateUnitWithSkin(p, FourCC("n015"), 16458.2, 18038.7, 270.000, FourCC("n015"))
u = BlzCreateUnitWithSkin(p, FourCC("nCOP"), -2944.0, 17856.0, 270.000, FourCC("nCOP"))
u = BlzCreateUnitWithSkin(p, FourCC("E004"), -2752.2, 17850.3, 180.000, FourCC("E004"))
u = BlzCreateUnitWithSkin(p, FourCC("E004"), 15166.4, 17063.0, 270.000, FourCC("E004"))
u = BlzCreateUnitWithSkin(p, FourCC("O005"), -3772.3, 17468.4, 0.000, FourCC("O005"))
u = BlzCreateUnitWithSkin(p, FourCC("nCOP"), -3584.0, 17472.0, 270.000, FourCC("nCOP"))
u = BlzCreateUnitWithSkin(p, FourCC("N02P"), -2739.9, 17479.3, 180.000, FourCC("N02P"))
u = BlzCreateUnitWithSkin(p, FourCC("nCOP"), -2944.0, 17472.0, 270.000, FourCC("nCOP"))
u = BlzCreateUnitWithSkin(p, FourCC("N02Q"), -3762.0, 17097.4, 0.000, FourCC("N02Q"))
u = BlzCreateUnitWithSkin(p, FourCC("nCOP"), -3584.0, 17088.0, 270.000, FourCC("nCOP"))
u = BlzCreateUnitWithSkin(p, FourCC("N02Q"), 14923.1, 17084.7, 270.000, FourCC("N02Q"))
u = BlzCreateUnitWithSkin(p, FourCC("N02P"), 15682.4, 17082.9, 270.000, FourCC("N02P"))
u = BlzCreateUnitWithSkin(p, FourCC("e008"), 14145.3, 17857.6, 270.000, FourCC("e008"))
u = BlzCreateUnitWithSkin(p, FourCC("e009"), 14269.7, 17849.1, 270.000, FourCC("e009"))
u = BlzCreateUnitWithSkin(p, FourCC("e00A"), 14397.8, 17853.3, 270.000, FourCC("e00A"))
u = BlzCreateUnitWithSkin(p, FourCC("e005"), 14530.8, 17846.9, 270.000, FourCC("e005"))
u = BlzCreateUnitWithSkin(p, FourCC("e006"), 14662.8, 17851.2, 270.000, FourCC("e006"))
u = BlzCreateUnitWithSkin(p, FourCC("e007"), 14785.8, 17853.3, 270.000, FourCC("e007"))
u = BlzCreateUnitWithSkin(p, FourCC("H02Y"), -2752.3, 17099.9, 180.000, FourCC("H02Y"))
u = BlzCreateUnitWithSkin(p, FourCC("nCOP"), -2944.0, 17088.0, 270.000, FourCC("nCOP"))
end

function CreatePlayerBuildings()
CreateBuildingsForPlayer0()
CreateBuildingsForPlayer1()
CreateBuildingsForPlayer2()
CreateBuildingsForPlayer3()
CreateBuildingsForPlayer4()
CreateBuildingsForPlayer5()
CreateBuildingsForPlayer6()
CreateBuildingsForPlayer7()
CreateBuildingsForPlayer8()
CreateBuildingsForPlayer9()
CreateBuildingsForPlayer10()
CreateBuildingsForPlayer11()
CreateBuildingsForPlayer12()
CreateBuildingsForPlayer13()
CreateBuildingsForPlayer14()
CreateBuildingsForPlayer15()
end

function CreatePlayerUnits()
CreateUnitsForPlayer0()
CreateUnitsForPlayer4()
CreateUnitsForPlayer8()
CreateUnitsForPlayer12()
end

function CreateAllUnits()
CreateNeutralHostileBuildings()
CreateNeutralPassiveBuildings()
CreatePlayerBuildings()
CreateNeutralPassive()
CreatePlayerUnits()
end

function CreateRegions()
local we

gg_rct_Center = Rect(-128.0, 2944.0, 128.0, 3200.0)
gg_rct_CenterBottom = Rect(-128.0, -7328.0, 128.0, -7072.0)
gg_rct_CenterBottomComplete = Rect(-384.0, -7552.0, 384.0, -6784.0)
gg_rct_CenterComplete = Rect(-768.0, 2304.0, 768.0, 3840.0)
gg_rct_CenterLeft = Rect(-10304.0, 2944.0, -10048.0, 3200.0)
gg_rct_CenterLeftComplete = Rect(-10560.0, 2688.0, -9792.0, 3456.0)
gg_rct_CenterRight = Rect(10048.0, 2944.0, 10304.0, 3200.0)
gg_rct_CenterRightComplete = Rect(9792.0, 2688.0, 10560.0, 3456.0)
gg_rct_CenterTop = Rect(-128.0, 13120.0, 128.0, 13376.0)
gg_rct_CenterTopComplete = Rect(-384.0, 12864.0, 384.0, 13632.0)
gg_rct_ElfBarracksToCenter = Rect(-9152.0, -6080.0, -9024.0, -5952.0)
gg_rct_ElfBarracksToCenterSpawn = Rect(-8960.0, -5888.0, -8704.0, -5632.0)
gg_rct_ElfBarracksToHuman = Rect(-10304.0, -5696.0, -10176.0, -5568.0)
gg_rct_ElfBarracksToHumanSpawn = Rect(-10496.0, -5504.0, -9984.0, -5248.0)
gg_rct_ElfBarracksToUndead = Rect(-8768.0, -7232.0, -8640.0, -7104.0)
gg_rct_ElfBarracksToUndeadSpawn = Rect(-8576.0, -7424.0, -8320.0, -6912.0)
gg_rct_ElfBase = Rect(-10304.0, -7232.0, -10176.0, -7104.0)
gg_rct_ElfBaseHeroRespawn = Rect(-12032.0, -8832.0, -11904.0, -8704.0)
gg_rct_ElfBaseHeroSpawn = Rect(-11904.0, -8960.0, -11776.0, -8832.0)
gg_rct_ElfBaseToCenterSpawn = Rect(-9984.0, -6912.0, -9728.0, -6656.0)
gg_rct_ElfBaseToHumanSpawn = Rect(-10368.0, -6912.0, -10112.0, -6656.0)
gg_rct_ElfBaseToUndeadSpawn = Rect(-9984.0, -7296.0, -9728.0, -7040.0)
gg_rct_ElfCreepToHumanSpawn = Rect(-8064.0, -1536.0, -7296.0, -768.0)
gg_rct_ElfCreepToHumanSpawnBuilding = Rect(-7808.0, -768.0, -7552.0, -512.0)
gg_rct_ElfCreepToUndeadSpawn = Rect(-4608.0, -5120.0, -3840.0, -4352.0)
gg_rct_ElfCreepToUndeadSpawnBuilding = Rect(-4224.0, -4352.0, -3968.0, -4096.0)
gg_rct_HeroAlchemist = Rect(-4864.0, 18496.0, -4736.0, 18624.0)
gg_rct_HeroArchmage = Rect(-1792.0, 18496.0, -1664.0, 18624.0)
gg_rct_HeroBlademaster = Rect(-4672.0, 17408.0, -4544.0, 17536.0)
gg_rct_HeroBloodMage = Rect(-2944.0, 18496.0, -2816.0, 18624.0)
gg_rct_HeroBrewmaster = Rect(-3712.0, 18496.0, -3584.0, 18624.0)
gg_rct_HeroCryptLord = Rect(-4672.0, 17024.0, -4544.0, 17152.0)
gg_rct_HeroDarkRanger = Rect(-1984.0, 17408.0, -1856.0, 17536.0)
gg_rct_HeroDeathKnight = Rect(-3648.0, 17024.0, -3520.0, 17152.0)
gg_rct_HeroFarSeer = Rect(-3008.0, 17024.0, -2880.0, 17152.0)
gg_rct_HeroFirelord = Rect(-2560.0, 18496.0, -2432.0, 18624.0)
gg_rct_HeroKeeperOfTheGrove = Rect(-2176.0, 18496.0, -2048.0, 18624.0)
gg_rct_HeroLich = Rect(-3008.0, 17792.0, -2880.0, 17920.0)
gg_rct_HeroMountainKing = Rect(-4480.0, 18496.0, -4352.0, 18624.0)
gg_rct_HeroPitLord = Rect(-4672.0, 17792.0, -4544.0, 17920.0)
gg_rct_HeroPriestessOfMoon = Rect(-3008.0, 17408.0, -2880.0, 17536.0)
gg_rct_HeroSeaWitch = Rect(-1984.0, 17024.0, -1856.0, 17152.0)
gg_rct_HeroSelectionTotal = Rect(-5248.0, 16768.0, -1280.0, 19200.0)
gg_rct_HeroSelectorSpawn = Rect(-3328.0, 18176.0, -3200.0, 18304.0)
gg_rct_HeroShadowHunter = Rect(-1984.0, 17792.0, -1856.0, 17920.0)
gg_rct_HeroTaurenChieftain = Rect(-3648.0, 17792.0, -3520.0, 17920.0)
gg_rct_HeroTinker = Rect(-4096.0, 18496.0, -3968.0, 18624.0)
gg_rct_HeroWarden = Rect(-3648.0, 17408.0, -3520.0, 17536.0)
gg_rct_HumanBarracksToCenter = Rect(-9152.0, 12096.0, -9024.0, 12224.0)
gg_rct_HumanBarracksToCenterSpawn = Rect(-8960.0, 11776.0, -8704.0, 12032.0)
gg_rct_HumanBarracksToElf = Rect(-10304.0, 11712.0, -10176.0, 11840.0)
gg_rct_HumanBarracksToElfSpawn = Rect(-10496.0, 11392.0, -9984.0, 11648.0)
gg_rct_HumanBarracksToOrc = Rect(-8768.0, 13248.0, -8640.0, 13376.0)
gg_rct_HumanBarracksToOrcSpawn = Rect(-8576.0, 13056.0, -8320.0, 13568.0)
gg_rct_HumanBase = Rect(-10304.0, 13248.0, -10176.0, 13376.0)
gg_rct_HumanBaseHeroRespawn = Rect(-11904.0, 14976.0, -11776.0, 15104.0)
gg_rct_HumanBaseHeroSpawn = Rect(-12032.0, 14848.0, -11904.0, 14976.0)
gg_rct_HumanBaseToCenterSpawn = Rect(-9984.0, 12800.0, -9728.0, 13056.0)
gg_rct_HumanBaseToElfSpawn = Rect(-10368.0, 12800.0, -10112.0, 13056.0)
gg_rct_HumanBaseToOrcSpawn = Rect(-9984.0, 13184.0, -9728.0, 13440.0)
gg_rct_HumanCreepToElfSpawn = Rect(-8064.0, 6912.0, -7296.0, 7680.0)
gg_rct_HumanCreepToElfSpawnBuilding = Rect(-7808.0, 6656.0, -7552.0, 6912.0)
gg_rct_HumanCreepToOrcSpawn = Rect(-4608.0, 10368.0, -3840.0, 11136.0)
gg_rct_HumanCreepToOrcSpawnBuilding = Rect(-4224.0, 10112.0, -3968.0, 10368.0)
gg_rct_LegionSpawnBottom = Rect(-384.0, -3456.0, 384.0, -2688.0)
gg_rct_LegionSpawnBottom1 = Rect(-448.0, -3136.0, -320.0, -3008.0)
gg_rct_LegionSpawnBottom2 = Rect(320.0, -3136.0, 448.0, -3008.0)
gg_rct_LegionSpawnEast = Rect(5760.0, 2688.0, 6528.0, 3456.0)
gg_rct_LegionSpawnEast1 = Rect(6080.0, 3392.0, 6208.0, 3520.0)
gg_rct_LegionSpawnEast2 = Rect(6080.0, 2624.0, 6208.0, 2752.0)
gg_rct_LegionSpawnTop = Rect(-384.0, 8832.0, 384.0, 9600.0)
gg_rct_LegionSpawnTop1 = Rect(-448.0, 9152.0, -320.0, 9280.0)
gg_rct_LegionSpawnTop2 = Rect(320.0, 9152.0, 448.0, 9280.0)
gg_rct_LegionSpawnWest = Rect(-6528.0, 2688.0, -5760.0, 3456.0)
gg_rct_LegionSpawnWest1 = Rect(-6208.0, 3392.0, -6080.0, 3520.0)
gg_rct_LegionSpawnWest2 = Rect(-6208.0, 2624.0, -6080.0, 2752.0)
gg_rct_OrcBarracksToCenter = Rect(9024.0, 12096.0, 9152.0, 12224.0)
gg_rct_OrcBarracksToCenterSpawn = Rect(8704.0, 11776.0, 8960.0, 12032.0)
gg_rct_OrcBarracksToHuman = Rect(8640.0, 13248.0, 8768.0, 13376.0)
gg_rct_OrcBarracksToHumanSpawn = Rect(8320.0, 13056.0, 8576.0, 13568.0)
gg_rct_OrcBarracksToUndead = Rect(10176.0, 11712.0, 10304.0, 11840.0)
gg_rct_OrcBarracksToUndeadSpawn = Rect(9984.0, 11392.0, 10496.0, 11648.0)
gg_rct_OrcBase = Rect(10176.0, 13248.0, 10304.0, 13376.0)
gg_rct_OrcBaseHeroRespawn = Rect(11776.0, 14976.0, 11904.0, 15104.0)
gg_rct_OrcBaseHeroSpawn = Rect(11904.0, 14848.0, 12032.0, 14976.0)
gg_rct_OrcBaseToCenterSpawn = Rect(9728.0, 12800.0, 9984.0, 13056.0)
gg_rct_OrcBaseToHumanSpawn = Rect(9728.0, 13184.0, 9984.0, 13440.0)
gg_rct_OrcBaseToUndeadSpawn = Rect(10112.0, 12800.0, 10368.0, 13056.0)
gg_rct_OrcCreepToHumanSpawn = Rect(3712.0, 10496.0, 4480.0, 11264.0)
gg_rct_OrcCreepToHumanSpawnBuilding = Rect(3840.0, 10240.0, 4096.0, 10496.0)
gg_rct_OrcCreepToUndeadSpawn = Rect(7424.0, 6912.0, 8192.0, 7680.0)
gg_rct_OrcCreepToUndeadSpawnBuilding = Rect(7552.0, 6656.0, 7808.0, 6912.0)
gg_rct_TestArea = Rect(15296.0, 16320.0, 15424.0, 16448.0)
gg_rct_TestArea2 = Rect(-10304.0, 13632.0, -10176.0, 13760.0)
gg_rct_TestArea3 = Rect(16320.0, 16320.0, 16448.0, 16448.0)
gg_rct_UndeadBarracksToCenter = Rect(9024.0, -6080.0, 9152.0, -5952.0)
gg_rct_UndeadBarracksToCenterSpawn = Rect(8704.0, -5888.0, 8960.0, -5632.0)
gg_rct_UndeadBarracksToElf = Rect(8640.0, -7232.0, 8768.0, -7104.0)
gg_rct_UndeadBarracksToElfSpawn = Rect(8320.0, -7424.0, 8576.0, -6912.0)
gg_rct_UndeadBarracksToOrc = Rect(10176.0, -5696.0, 10304.0, -5568.0)
gg_rct_UndeadBarracksToOrcSpawn = Rect(9984.0, -5504.0, 10496.0, -5248.0)
gg_rct_UndeadBase = Rect(10176.0, -7232.0, 10304.0, -7104.0)
gg_rct_UndeadBaseHeroRespawn = Rect(11776.0, -8960.0, 11904.0, -8832.0)
gg_rct_UndeadBaseHeroSpawn = Rect(11904.0, -8832.0, 12032.0, -8704.0)
gg_rct_UndeadBaseToCenterSpawn = Rect(9728.0, -6912.0, 9984.0, -6656.0)
gg_rct_UndeadBaseToElfSpawn = Rect(9728.0, -7296.0, 9984.0, -7040.0)
gg_rct_UndeadBaseToOrcSpawn = Rect(10112.0, -6912.0, 10368.0, -6656.0)
gg_rct_UndeadCreepToElfSpawn = Rect(3840.0, -5120.0, 4608.0, -4352.0)
gg_rct_UndeadCreepToElfSpawnBuilding = Rect(3968.0, -4352.0, 4224.0, -4096.0)
gg_rct_UndeadCreepToOrcSpawn = Rect(7424.0, -1664.0, 8192.0, -896.0)
gg_rct_UndeadCreepToOrcSpawnBuilding = Rect(7552.0, -896.0, 7808.0, -640.0)
end

function Trig_Untitled_Trigger_001_Actions()
end

function InitTrig_Untitled_Trigger_001()
gg_trg_Untitled_Trigger_001 = CreateTrigger()
TriggerAddAction(gg_trg_Untitled_Trigger_001, Trig_Untitled_Trigger_001_Actions)
end

function InitCustomTriggers()
InitTrig_Untitled_Trigger_001()
end

function InitCustomPlayerSlots()
SetPlayerStartLocation(Player(0), 0)
ForcePlayerStartLocation(Player(0), 0)
SetPlayerColor(Player(0), ConvertPlayerColor(0))
SetPlayerRacePreference(Player(0), RACE_PREF_HUMAN)
SetPlayerRaceSelectable(Player(0), false)
SetPlayerController(Player(0), MAP_CONTROL_COMPUTER)
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
SetPlayerController(Player(3), MAP_CONTROL_USER)
SetPlayerStartLocation(Player(4), 4)
ForcePlayerStartLocation(Player(4), 4)
SetPlayerColor(Player(4), ConvertPlayerColor(4))
SetPlayerRacePreference(Player(4), RACE_PREF_ORC)
SetPlayerRaceSelectable(Player(4), false)
SetPlayerController(Player(4), MAP_CONTROL_COMPUTER)
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
SetPlayerController(Player(7), MAP_CONTROL_USER)
SetPlayerStartLocation(Player(8), 8)
ForcePlayerStartLocation(Player(8), 8)
SetPlayerColor(Player(8), ConvertPlayerColor(8))
SetPlayerRacePreference(Player(8), RACE_PREF_NIGHTELF)
SetPlayerRaceSelectable(Player(8), false)
SetPlayerController(Player(8), MAP_CONTROL_COMPUTER)
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
SetPlayerController(Player(11), MAP_CONTROL_USER)
SetPlayerStartLocation(Player(12), 12)
ForcePlayerStartLocation(Player(12), 12)
SetPlayerColor(Player(12), ConvertPlayerColor(12))
SetPlayerRacePreference(Player(12), RACE_PREF_UNDEAD)
SetPlayerRaceSelectable(Player(12), false)
SetPlayerController(Player(12), MAP_CONTROL_COMPUTER)
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
SetPlayerController(Player(15), MAP_CONTROL_USER)
SetPlayerStartLocation(Player(20), 16)
ForcePlayerStartLocation(Player(20), 16)
SetPlayerColor(Player(20), ConvertPlayerColor(20))
SetPlayerRacePreference(Player(20), RACE_PREF_UNDEAD)
SetPlayerRaceSelectable(Player(20), false)
SetPlayerController(Player(20), MAP_CONTROL_COMPUTER)
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
SetPlayerState(Player(12), PLAYER_STATE_ALLIED_VICTORY, 1)
SetPlayerTeam(Player(13), 3)
SetPlayerState(Player(13), PLAYER_STATE_ALLIED_VICTORY, 1)
SetPlayerTeam(Player(14), 3)
SetPlayerState(Player(14), PLAYER_STATE_ALLIED_VICTORY, 1)
SetPlayerTeam(Player(15), 3)
SetPlayerState(Player(15), PLAYER_STATE_ALLIED_VICTORY, 1)
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
SetPlayerTeam(Player(20), 4)
SetPlayerState(Player(20), PLAYER_STATE_ALLIED_VICTORY, 1)
end

function InitAllyPriorities()
SetStartLocPrioCount(0, 3)
SetStartLocPrio(0, 0, 1, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(0, 1, 2, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(0, 2, 16, MAP_LOC_PRIO_HIGH)
SetEnemyStartLocPrioCount(0, 1)
SetEnemyStartLocPrio(0, 0, 16, MAP_LOC_PRIO_LOW)
SetStartLocPrioCount(1, 11)
SetStartLocPrio(1, 0, 2, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(1, 1, 3, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(1, 2, 5, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(1, 3, 6, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(1, 4, 7, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(1, 5, 9, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(1, 6, 10, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(1, 7, 11, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(1, 8, 13, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(1, 9, 14, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(1, 10, 15, MAP_LOC_PRIO_HIGH)
SetStartLocPrioCount(2, 11)
SetStartLocPrio(2, 0, 1, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(2, 1, 3, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(2, 2, 5, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(2, 3, 6, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(2, 4, 7, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(2, 5, 9, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(2, 6, 10, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(2, 7, 11, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(2, 8, 13, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(2, 9, 14, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(2, 10, 15, MAP_LOC_PRIO_HIGH)
SetStartLocPrioCount(3, 11)
SetStartLocPrio(3, 0, 1, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(3, 1, 2, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(3, 2, 5, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(3, 3, 6, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(3, 4, 7, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(3, 5, 9, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(3, 6, 10, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(3, 7, 11, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(3, 8, 13, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(3, 9, 14, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(3, 10, 15, MAP_LOC_PRIO_HIGH)
SetStartLocPrioCount(4, 2)
SetStartLocPrio(4, 0, 5, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(4, 1, 6, MAP_LOC_PRIO_HIGH)
SetEnemyStartLocPrioCount(4, 1)
SetEnemyStartLocPrio(4, 0, 16, MAP_LOC_PRIO_HIGH)
SetStartLocPrioCount(5, 11)
SetStartLocPrio(5, 0, 1, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(5, 1, 2, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(5, 2, 3, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(5, 3, 6, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(5, 4, 7, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(5, 5, 9, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(5, 6, 10, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(5, 7, 11, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(5, 8, 13, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(5, 9, 14, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(5, 10, 15, MAP_LOC_PRIO_HIGH)
SetStartLocPrioCount(6, 11)
SetStartLocPrio(6, 0, 1, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(6, 1, 2, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(6, 2, 3, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(6, 3, 5, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(6, 4, 7, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(6, 5, 9, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(6, 6, 10, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(6, 7, 11, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(6, 8, 13, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(6, 9, 14, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(6, 10, 15, MAP_LOC_PRIO_HIGH)
SetStartLocPrioCount(7, 11)
SetStartLocPrio(7, 0, 1, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(7, 1, 2, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(7, 2, 3, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(7, 3, 5, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(7, 4, 6, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(7, 5, 9, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(7, 6, 10, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(7, 7, 11, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(7, 8, 13, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(7, 9, 14, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(7, 10, 15, MAP_LOC_PRIO_HIGH)
SetStartLocPrioCount(8, 1)
SetStartLocPrio(8, 0, 9, MAP_LOC_PRIO_HIGH)
SetStartLocPrioCount(9, 11)
SetStartLocPrio(9, 0, 1, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(9, 1, 2, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(9, 2, 3, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(9, 3, 5, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(9, 4, 6, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(9, 5, 7, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(9, 6, 10, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(9, 7, 11, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(9, 8, 13, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(9, 9, 14, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(9, 10, 15, MAP_LOC_PRIO_HIGH)
SetStartLocPrioCount(10, 11)
SetStartLocPrio(10, 0, 1, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(10, 1, 2, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(10, 2, 3, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(10, 3, 5, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(10, 4, 6, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(10, 5, 7, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(10, 6, 9, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(10, 7, 11, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(10, 8, 13, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(10, 9, 14, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(10, 10, 15, MAP_LOC_PRIO_HIGH)
SetStartLocPrioCount(11, 11)
SetStartLocPrio(11, 0, 1, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(11, 1, 2, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(11, 2, 3, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(11, 3, 5, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(11, 4, 6, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(11, 5, 7, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(11, 6, 9, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(11, 7, 10, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(11, 8, 13, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(11, 9, 14, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(11, 10, 15, MAP_LOC_PRIO_HIGH)
SetStartLocPrioCount(12, 2)
SetStartLocPrio(12, 0, 13, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(12, 1, 14, MAP_LOC_PRIO_HIGH)
SetStartLocPrioCount(13, 11)
SetStartLocPrio(13, 0, 1, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(13, 1, 2, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(13, 2, 3, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(13, 3, 5, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(13, 4, 6, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(13, 5, 7, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(13, 6, 9, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(13, 7, 10, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(13, 8, 11, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(13, 9, 14, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(13, 10, 15, MAP_LOC_PRIO_HIGH)
SetStartLocPrioCount(14, 11)
SetStartLocPrio(14, 0, 1, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(14, 1, 2, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(14, 2, 3, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(14, 3, 5, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(14, 4, 6, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(14, 5, 7, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(14, 6, 9, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(14, 7, 10, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(14, 8, 11, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(14, 9, 13, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(14, 10, 15, MAP_LOC_PRIO_HIGH)
SetStartLocPrioCount(15, 11)
SetStartLocPrio(15, 0, 1, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(15, 1, 2, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(15, 2, 3, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(15, 3, 5, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(15, 4, 6, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(15, 5, 7, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(15, 6, 9, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(15, 7, 10, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(15, 8, 11, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(15, 9, 13, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(15, 10, 14, MAP_LOC_PRIO_HIGH)
SetStartLocPrioCount(16, 14)
SetStartLocPrio(16, 0, 1, MAP_LOC_PRIO_LOW)
SetStartLocPrio(16, 1, 2, MAP_LOC_PRIO_LOW)
SetStartLocPrio(16, 2, 3, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(16, 3, 4, MAP_LOC_PRIO_LOW)
SetStartLocPrio(16, 4, 5, MAP_LOC_PRIO_LOW)
SetStartLocPrio(16, 5, 6, MAP_LOC_PRIO_LOW)
SetStartLocPrio(16, 6, 7, MAP_LOC_PRIO_LOW)
SetStartLocPrio(16, 7, 8, MAP_LOC_PRIO_LOW)
SetStartLocPrio(16, 8, 9, MAP_LOC_PRIO_LOW)
SetStartLocPrio(16, 9, 10, MAP_LOC_PRIO_LOW)
SetStartLocPrio(16, 10, 11, MAP_LOC_PRIO_LOW)
SetStartLocPrio(16, 11, 12, MAP_LOC_PRIO_LOW)
SetStartLocPrio(16, 12, 13, MAP_LOC_PRIO_LOW)
SetStartLocPrio(16, 13, 14, MAP_LOC_PRIO_LOW)
SetEnemyStartLocPrioCount(16, 8)
SetEnemyStartLocPrio(16, 0, 0, MAP_LOC_PRIO_HIGH)
SetEnemyStartLocPrio(16, 1, 2, MAP_LOC_PRIO_LOW)
SetEnemyStartLocPrio(16, 2, 3, MAP_LOC_PRIO_LOW)
SetEnemyStartLocPrio(16, 3, 5, MAP_LOC_PRIO_LOW)
SetEnemyStartLocPrio(16, 4, 6, MAP_LOC_PRIO_LOW)
SetEnemyStartLocPrio(16, 5, 7, MAP_LOC_PRIO_LOW)
SetEnemyStartLocPrio(16, 6, 8, MAP_LOC_PRIO_HIGH)
SetEnemyStartLocPrio(16, 7, 9, MAP_LOC_PRIO_HIGH)
end

function main()
local we

SetCameraBounds(-19712.0 + GetCameraMargin(CAMERA_MARGIN_LEFT), -19968.0 + GetCameraMargin(CAMERA_MARGIN_BOTTOM), 19712.0 - GetCameraMargin(CAMERA_MARGIN_RIGHT), 19456.0 - GetCameraMargin(CAMERA_MARGIN_TOP), -19712.0 + GetCameraMargin(CAMERA_MARGIN_LEFT), 19456.0 - GetCameraMargin(CAMERA_MARGIN_TOP), 19712.0 - GetCameraMargin(CAMERA_MARGIN_RIGHT), -19968.0 + GetCameraMargin(CAMERA_MARGIN_BOTTOM))
SetDayNightModels("Environment\\DNC\\DNCLordaeron\\DNCLordaeronTerrain\\DNCLordaeronTerrain.mdl", "Environment\\DNC\\DNCLordaeron\\DNCLordaeronUnit\\DNCLordaeronUnit.mdl")
we = AddWeatherEffect(Rect(-20480.0, -20480.0, 20480.0, 20480.0), FourCC("RLlr"))
EnableWeatherEffect(we, true)
NewSoundEnvironment("Default")
SetAmbientDaySound("LordaeronSummerDay")
SetAmbientNightSound("LordaeronSummerNight")
SetMapMusic("Music", true, 0)
InitSounds()
CreateRegions()
CreateAllUnits()
InitBlizzard()
InitGlobals()
InitCustomTriggers()
end

function config()
SetMapName("TRIGSTR_001")
SetMapDescription("TRIGSTR_003")
SetPlayers(17)
SetTeams(17)
SetGamePlacement(MAP_PLACEMENT_TEAMS_TOGETHER)
DefineStartLocation(0, -10240.0, 13312.0)
DefineStartLocation(1, -3264.0, 18240.0)
DefineStartLocation(2, -3264.0, 18240.0)
DefineStartLocation(3, -3264.0, 18240.0)
DefineStartLocation(4, 10240.0, 13312.0)
DefineStartLocation(5, -3264.0, 18240.0)
DefineStartLocation(6, -3264.0, 18240.0)
DefineStartLocation(7, -3264.0, 18240.0)
DefineStartLocation(8, -10240.0, -7168.0)
DefineStartLocation(9, -3264.0, 18240.0)
DefineStartLocation(10, -3264.0, 18240.0)
DefineStartLocation(11, -3264.0, 18240.0)
DefineStartLocation(12, 10240.0, -7168.0)
DefineStartLocation(13, -3264.0, 18240.0)
DefineStartLocation(14, -3264.0, 18240.0)
DefineStartLocation(15, -3264.0, 18240.0)
DefineStartLocation(16, 0.0, 3072.0)
InitCustomPlayerSlots()
InitCustomTeams()
InitAllyPriorities()
end

