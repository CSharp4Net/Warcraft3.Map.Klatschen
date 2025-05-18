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
gg_rct_ElfToHumanInnerLine = nil
gg_rct_ElfToHumanOuterLine = nil
gg_rct_ElfToOrcInnerLine = nil
gg_rct_ElfToOrcOuterLine = nil
gg_rct_ElfToUndeadInnerLine = nil
gg_rct_ElfToUndeadOuterLine = nil
gg_rct_HeroSelectorSpawn = nil
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
gg_rct_HumanToElfInnerLine = nil
gg_rct_HumanToElfOuterLine = nil
gg_rct_HumanToOrcInnerLine = nil
gg_rct_HumanToOrcOuterLine = nil
gg_rct_HumanToUndeadInnerLine = nil
gg_rct_HumanToUndeadOuterLine = nil
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
gg_rct_OrcToElfInnerLine = nil
gg_rct_OrcToElfOuterLine = nil
gg_rct_OrcToHumanInnerLine = nil
gg_rct_OrcToHumanOuterLine = nil
gg_rct_OrcToUndeadInnerLine = nil
gg_rct_OrcToUndeadOuterLine = nil
gg_rct_TestArea = nil
gg_rct_TestArea2 = nil
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
gg_rct_UndeadToElfInnerLine = nil
gg_rct_UndeadToElfOuterLine = nil
gg_rct_UndeadToHumanInnerLine = nil
gg_rct_UndeadToHumanOuterLine = nil
gg_rct_UndeadToOrcInnerLine = nil
gg_rct_UndeadToOrcOuterLine = nil
gg_snd_HPitLordPissed1 = nil
gg_snd_HPitLordPissed2 = nil
gg_snd_HPitLordPissed3 = nil
gg_snd_HPitLordPissed4 = nil
gg_snd_HPitLordPissed5 = nil
gg_trg_Melee_Initialization = nil
function InitGlobals()
end

function InitSounds()
gg_snd_HPitLordPissed1 = CreateSound("Units/Demon/HeroPitLord/HPitLordPissed1.flac", false, true, true, 0, 0, "HeroAcksEAX")
SetSoundParamsFromLabel(gg_snd_HPitLordPissed1, "HeroPitLordPissed")
SetSoundDuration(gg_snd_HPitLordPissed1, 4127)
SetSoundVolume(gg_snd_HPitLordPissed1, 127)
gg_snd_HPitLordPissed2 = CreateSound("Units/Demon/HeroPitLord/HPitLordPissed2.flac", false, true, true, 0, 0, "HeroAcksEAX")
SetSoundParamsFromLabel(gg_snd_HPitLordPissed2, "HeroPitLordPissed")
SetSoundDuration(gg_snd_HPitLordPissed2, 2690)
SetSoundVolume(gg_snd_HPitLordPissed2, 127)
gg_snd_HPitLordPissed3 = CreateSound("Units/Demon/HeroPitLord/HPitLordPissed3.flac", false, true, true, 0, 0, "HeroAcksEAX")
SetSoundParamsFromLabel(gg_snd_HPitLordPissed3, "HeroPitLordPissed")
SetSoundDuration(gg_snd_HPitLordPissed3, 1906)
SetSoundVolume(gg_snd_HPitLordPissed3, 127)
gg_snd_HPitLordPissed4 = CreateSound("Units/Demon/HeroPitLord/HPitLordPissed4.flac", false, true, true, 0, 0, "HeroAcksEAX")
SetSoundParamsFromLabel(gg_snd_HPitLordPissed4, "HeroPitLordPissed")
SetSoundDuration(gg_snd_HPitLordPissed4, 6269)
SetSoundVolume(gg_snd_HPitLordPissed4, 127)
gg_snd_HPitLordPissed5 = CreateSound("Units/Demon/HeroPitLord/HPitLordPissed5.flac", false, true, true, 0, 0, "HeroAcksEAX")
SetSoundParamsFromLabel(gg_snd_HPitLordPissed5, "HeroPitLordPissed")
SetSoundDuration(gg_snd_HPitLordPissed5, 6321)
SetSoundVolume(gg_snd_HPitLordPissed5, 127)
end

function CreateBuildingsForPlayer0()
local p = Player(0)
local u
local unitID
local t
local life

u = BlzCreateUnitWithSkin(p, FourCC("h005"), -8192.0, 13696.0, 270.000, FourCC("h005"))
u = BlzCreateUnitWithSkin(p, FourCC("h005"), -8192.0, 12928.0, 270.000, FourCC("h005"))
u = BlzCreateUnitWithSkin(p, FourCC("h005"), -6912.0, 13312.0, 270.000, FourCC("h005"))
u = BlzCreateUnitWithSkin(p, FourCC("h004"), -4096.0, 13696.0, 270.000, FourCC("h004"))
u = BlzCreateUnitWithSkin(p, FourCC("h004"), -4096.0, 12928.0, 270.000, FourCC("h004"))
u = BlzCreateUnitWithSkin(p, FourCC("h004"), -2816.0, 13312.0, 270.000, FourCC("h004"))
u = BlzCreateUnitWithSkin(p, FourCC("h005"), -9856.0, 11264.0, 270.000, FourCC("h005"))
u = BlzCreateUnitWithSkin(p, FourCC("h005"), -10624.0, 11264.0, 270.000, FourCC("h005"))
u = BlzCreateUnitWithSkin(p, FourCC("h005"), -10240.0, 9984.0, 270.000, FourCC("h005"))
u = BlzCreateUnitWithSkin(p, FourCC("n005"), -12032.0, 15104.0, 270.000, FourCC("n005"))
u = BlzCreateUnitWithSkin(p, FourCC("h009"), -11264.0, 14848.0, 270.000, FourCC("h009"))
u = BlzCreateUnitWithSkin(p, FourCC("h005"), -10624.0, 12288.0, 270.000, FourCC("h005"))
u = BlzCreateUnitWithSkin(p, FourCC("h005"), -9216.0, 12800.0, 270.000, FourCC("h005"))
u = BlzCreateUnitWithSkin(p, FourCC("h005"), -8960.0, 11520.0, 270.000, FourCC("h005"))
u = BlzCreateUnitWithSkin(p, FourCC("h005"), -8448.0, 12032.0, 270.000, FourCC("h005"))
u = BlzCreateUnitWithSkin(p, FourCC("h005"), -7680.0, 10752.0, 270.000, FourCC("h005"))
u = BlzCreateUnitWithSkin(p, FourCC("h004"), -9920.0, 7168.0, 270.000, FourCC("h004"))
u = BlzCreateUnitWithSkin(p, FourCC("h004"), -10560.0, 7168.0, 270.000, FourCC("h004"))
u = BlzCreateUnitWithSkin(p, FourCC("h004"), -10240.0, 5888.0, 270.000, FourCC("h004"))
u = BlzCreateUnitWithSkin(p, FourCC("h004"), -5376.0, 7936.0, 270.000, FourCC("h004"))
u = BlzCreateUnitWithSkin(p, FourCC("h004"), -4864.0, 8448.0, 270.000, FourCC("h004"))
u = BlzCreateUnitWithSkin(p, FourCC("h004"), -4096.0, 7168.0, 270.000, FourCC("h004"))
u = BlzCreateUnitWithSkin(p, FourCC("h005"), -11264.0, 13824.0, 270.000, FourCC("h005"))
u = BlzCreateUnitWithSkin(p, FourCC("h005"), -10752.0, 14336.0, 270.000, FourCC("h005"))
u = BlzCreateUnitWithSkin(p, FourCC("h005"), -9216.0, 13696.0, 270.000, FourCC("h005"))
u = BlzCreateUnitWithSkin(p, FourCC("h005"), -9728.0, 12288.0, 270.000, FourCC("h005"))
u = BlzCreateUnitWithSkin(p, FourCC("h005"), -12160.0, 14720.0, 270.000, FourCC("h005"))
u = BlzCreateUnitWithSkin(p, FourCC("h005"), -11648.0, 15232.0, 270.000, FourCC("h005"))
u = BlzCreateUnitWithSkin(p, FourCC("h00T"), -11776.0, 14336.0, 270.000, FourCC("h00T"))
end

function CreateBuildingsForPlayer1()
local p = Player(1)
local u
local unitID
local t
local life

u = BlzCreateUnitWithSkin(p, FourCC("h00D"), -11296.0, 15264.0, 270.000, FourCC("h00D"))
u = BlzCreateUnitWithSkin(p, FourCC("h00A"), -12160.0, 14336.0, 270.000, FourCC("h00A"))
end

function CreateBuildingsForPlayer2()
local p = Player(2)
local u
local unitID
local t
local life

u = BlzCreateUnitWithSkin(p, FourCC("h00A"), -12160.0, 13952.0, 270.000, FourCC("h00A"))
u = BlzCreateUnitWithSkin(p, FourCC("h00D"), -10912.0, 15264.0, 270.000, FourCC("h00D"))
end

function CreateBuildingsForPlayer3()
local p = Player(3)
local u
local unitID
local t
local life

u = BlzCreateUnitWithSkin(p, FourCC("h00A"), -12160.0, 13568.0, 270.000, FourCC("h00A"))
u = BlzCreateUnitWithSkin(p, FourCC("h00D"), -10528.0, 15264.0, 270.000, FourCC("h00D"))
end

function CreateBuildingsForPlayer4()
local p = Player(4)
local u
local unitID
local t
local life

u = BlzCreateUnitWithSkin(p, FourCC("h00U"), 4096.0, 7168.0, 270.000, FourCC("h00U"))
u = BlzCreateUnitWithSkin(p, FourCC("h00V"), 7680.0, 10752.0, 270.000, FourCC("h00V"))
u = BlzCreateUnitWithSkin(p, FourCC("h00V"), 8448.0, 12032.0, 270.000, FourCC("h00V"))
u = BlzCreateUnitWithSkin(p, FourCC("h00V"), 9216.0, 13696.0, 270.000, FourCC("h00V"))
u = BlzCreateUnitWithSkin(p, FourCC("h00V"), 10624.0, 12288.0, 270.000, FourCC("h00V"))
u = BlzCreateUnitWithSkin(p, FourCC("h00V"), 6912.0, 13312.0, 270.000, FourCC("h00V"))
u = BlzCreateUnitWithSkin(p, FourCC("h00W"), 11776.0, 14336.0, 270.000, FourCC("h00W"))
u = BlzCreateUnitWithSkin(p, FourCC("h00U"), 2816.0, 13312.0, 270.000, FourCC("h00U"))
u = BlzCreateUnitWithSkin(p, FourCC("h00U"), 4864.0, 8448.0, 270.000, FourCC("h00U"))
u = BlzCreateUnitWithSkin(p, FourCC("h00V"), 8192.0, 13696.0, 270.000, FourCC("h00V"))
u = BlzCreateUnitWithSkin(p, FourCC("h00V"), 8192.0, 12928.0, 270.000, FourCC("h00V"))
u = BlzCreateUnitWithSkin(p, FourCC("h00V"), 8960.0, 11520.0, 270.000, FourCC("h00V"))
u = BlzCreateUnitWithSkin(p, FourCC("h00X"), 11264.0, 14848.0, 270.000, FourCC("h00X"))
u = BlzCreateUnitWithSkin(p, FourCC("NBDB"), 12032.0, 15104.0, 270.000, FourCC("NBDB"))
u = BlzCreateUnitWithSkin(p, FourCC("h00V"), 10240.0, 9984.0, 270.000, FourCC("h00V"))
u = BlzCreateUnitWithSkin(p, FourCC("h00V"), 9856.0, 11264.0, 270.000, FourCC("h00V"))
u = BlzCreateUnitWithSkin(p, FourCC("h00V"), 10624.0, 11264.0, 270.000, FourCC("h00V"))
u = BlzCreateUnitWithSkin(p, FourCC("h00U"), 10240.0, 5888.0, 270.000, FourCC("h00U"))
u = BlzCreateUnitWithSkin(p, FourCC("h00U"), 9856.0, 7168.0, 270.000, FourCC("h00U"))
u = BlzCreateUnitWithSkin(p, FourCC("h00U"), 5376.0, 7936.0, 270.000, FourCC("h00U"))
u = BlzCreateUnitWithSkin(p, FourCC("h00U"), 4096.0, 13696.0, 270.000, FourCC("h00U"))
u = BlzCreateUnitWithSkin(p, FourCC("h00U"), 4096.0, 12928.0, 270.000, FourCC("h00U"))
u = BlzCreateUnitWithSkin(p, FourCC("h00U"), 10624.0, 7168.0, 270.000, FourCC("h00U"))
u = BlzCreateUnitWithSkin(p, FourCC("h00V"), 9728.0, 12288.0, 270.000, FourCC("h00V"))
u = BlzCreateUnitWithSkin(p, FourCC("h00V"), 12160.0, 14720.0, 270.000, FourCC("h00V"))
u = BlzCreateUnitWithSkin(p, FourCC("h00V"), 10752.0, 14336.0, 270.000, FourCC("h00V"))
u = BlzCreateUnitWithSkin(p, FourCC("h00V"), 11264.0, 13824.0, 270.000, FourCC("h00V"))
u = BlzCreateUnitWithSkin(p, FourCC("h00V"), 9216.0, 12800.0, 270.000, FourCC("h00V"))
u = BlzCreateUnitWithSkin(p, FourCC("h00V"), 11648.0, 15232.0, 270.000, FourCC("h00V"))
end

function CreateBuildingsForPlayer5()
local p = Player(5)
local u
local unitID
local t
local life

u = BlzCreateUnitWithSkin(p, FourCC("h017"), 12160.0, 14336.0, 270.000, FourCC("h017"))
u = BlzCreateUnitWithSkin(p, FourCC("h01G"), 10528.0, 15264.0, 270.000, FourCC("h01G"))
end

function CreateBuildingsForPlayer6()
local p = Player(6)
local u
local unitID
local t
local life

u = BlzCreateUnitWithSkin(p, FourCC("h017"), 12160.0, 13952.0, 270.000, FourCC("h017"))
u = BlzCreateUnitWithSkin(p, FourCC("h01G"), 10912.0, 15264.0, 270.000, FourCC("h01G"))
end

function CreateBuildingsForPlayer7()
local p = Player(7)
local u
local unitID
local t
local life

u = BlzCreateUnitWithSkin(p, FourCC("h017"), 12160.0, 13568.0, 270.000, FourCC("h017"))
u = BlzCreateUnitWithSkin(p, FourCC("h01G"), 11296.0, 15264.0, 270.000, FourCC("h01G"))
end

function CreateBuildingsForPlayer8()
local p = Player(8)
local u
local unitID
local t
local life

u = BlzCreateUnitWithSkin(p, FourCC("h010"), -10240.0, 256.0, 270.000, FourCC("h010"))
IssueImmediateOrder(u, "root")
u = BlzCreateUnitWithSkin(p, FourCC("h010"), -10624.0, -1024.0, 270.000, FourCC("h010"))
u = BlzCreateUnitWithSkin(p, FourCC("h011"), -8448.0, -5888.0, 270.000, FourCC("h011"))
u = BlzCreateUnitWithSkin(p, FourCC("h011"), -8960.0, -5376.0, 270.000, FourCC("h011"))
u = BlzCreateUnitWithSkin(p, FourCC("h011"), -9216.0, -7552.0, 270.000, FourCC("h011"))
u = BlzCreateUnitWithSkin(p, FourCC("h011"), -10624.0, -6144.0, 270.000, FourCC("h011"))
u = BlzCreateUnitWithSkin(p, FourCC("h011"), -8192.0, -6784.0, 270.000, FourCC("h011"))
u = BlzCreateUnitWithSkin(p, FourCC("h010"), -4096.0, -1024.0, 270.000, FourCC("h010"))
u = BlzCreateUnitWithSkin(p, FourCC("h010"), -4864.0, -2304.0, 270.000, FourCC("h010"))
u = BlzCreateUnitWithSkin(p, FourCC("h010"), -9856.0, -1024.0, 270.000, FourCC("h010"))
u = BlzCreateUnitWithSkin(p, FourCC("h010"), -2816.0, -7168.0, 270.000, FourCC("h010"))
u = BlzCreateUnitWithSkin(p, FourCC("h010"), -4096.0, -7552.0, 270.000, FourCC("h010"))
u = BlzCreateUnitWithSkin(p, FourCC("h010"), -4096.0, -6784.0, 270.000, FourCC("h010"))
u = BlzCreateUnitWithSkin(p, FourCC("h011"), -6912.0, -7168.0, 270.000, FourCC("h011"))
u = BlzCreateUnitWithSkin(p, FourCC("h011"), -8192.0, -7552.0, 270.000, FourCC("h011"))
u = BlzCreateUnitWithSkin(p, FourCC("h010"), -5376.0, -1792.0, 270.000, FourCC("h010"))
u = BlzCreateUnitWithSkin(p, FourCC("h013"), -11264.0, -8704.0, 270.000, FourCC("h013"))
u = BlzCreateUnitWithSkin(p, FourCC("h011"), -11264.0, -7680.0, 270.000, FourCC("h011"))
u = BlzCreateUnitWithSkin(p, FourCC("h012"), -11776.0, -8192.0, 270.000, FourCC("h012"))
u = BlzCreateUnitWithSkin(p, FourCC("h011"), -10752.0, -8192.0, 270.000, FourCC("h011"))
u = BlzCreateUnitWithSkin(p, FourCC("h011"), -7680.0, -4608.0, 270.000, FourCC("h011"))
u = BlzCreateUnitWithSkin(p, FourCC("h011"), -10240.0, -3840.0, 270.000, FourCC("h011"))
u = BlzCreateUnitWithSkin(p, FourCC("h011"), -10624.0, -5120.0, 270.000, FourCC("h011"))
u = BlzCreateUnitWithSkin(p, FourCC("h011"), -9856.0, -5120.0, 270.000, FourCC("h011"))
u = BlzCreateUnitWithSkin(p, FourCC("h011"), -12160.0, -8576.0, 270.000, FourCC("h011"))
u = BlzCreateUnitWithSkin(p, FourCC("h011"), -11648.0, -9088.0, 270.000, FourCC("h011"))
u = BlzCreateUnitWithSkin(p, FourCC("h011"), -9216.0, -6656.0, 270.000, FourCC("h011"))
u = BlzCreateUnitWithSkin(p, FourCC("h011"), -9728.0, -6144.0, 270.000, FourCC("h011"))
end

function CreateBuildingsForPlayer9()
local p = Player(9)
local u
local unitID
local t
local life

u = BlzCreateUnitWithSkin(p, FourCC("h016"), -12160.0, -8192.0, 270.000, FourCC("h016"))
u = BlzCreateUnitWithSkin(p, FourCC("h01H"), -11232.0, -9120.0, 270.000, FourCC("h01H"))
end

function CreateBuildingsForPlayer10()
local p = Player(10)
local u
local unitID
local t
local life

u = BlzCreateUnitWithSkin(p, FourCC("h016"), -12160.0, -7808.0, 270.000, FourCC("h016"))
u = BlzCreateUnitWithSkin(p, FourCC("h01H"), -10848.0, -9120.0, 270.000, FourCC("h01H"))
end

function CreateBuildingsForPlayer11()
local p = Player(11)
local u
local unitID
local t
local life

u = BlzCreateUnitWithSkin(p, FourCC("h016"), -12160.0, -7424.0, 270.000, FourCC("h016"))
u = BlzCreateUnitWithSkin(p, FourCC("h01H"), -10464.0, -9120.0, 270.000, FourCC("h01H"))
end

function CreateBuildingsForPlayer12()
local p = Player(12)
local u
local unitID
local t
local life

u = BlzCreateUnitWithSkin(p, FourCC("NEBL"), 12032.0, -8960.0, 270.000, FourCC("NEBL"))
u = BlzCreateUnitWithSkin(p, FourCC("h018"), 2816.0, -7168.0, 270.000, FourCC("h018"))
u = BlzCreateUnitWithSkin(p, FourCC("h01C"), 11264.0, -8704.0, 270.000, FourCC("h01C"))
u = BlzCreateUnitWithSkin(p, FourCC("h018"), 4096.0, -6784.0, 270.000, FourCC("h018"))
u = BlzCreateUnitWithSkin(p, FourCC("h019"), 10240.0, -3840.0, 270.000, FourCC("h019"))
u = BlzCreateUnitWithSkin(p, FourCC("h019"), 10624.0, -5120.0, 270.000, FourCC("h019"))
u = BlzCreateUnitWithSkin(p, FourCC("h018"), 10240.0, 256.0, 270.000, FourCC("h018"))
u = BlzCreateUnitWithSkin(p, FourCC("h018"), 10624.0, -1024.0, 270.000, FourCC("h018"))
u = BlzCreateUnitWithSkin(p, FourCC("h019"), 6912.0, -7168.0, 270.000, FourCC("h019"))
u = BlzCreateUnitWithSkin(p, FourCC("h019"), 9856.0, -5120.0, 270.000, FourCC("h019"))
u = BlzCreateUnitWithSkin(p, FourCC("h019"), 9216.0, -7552.0, 270.000, FourCC("h019"))
u = BlzCreateUnitWithSkin(p, FourCC("h019"), 10624.0, -6144.0, 270.000, FourCC("h019"))
u = BlzCreateUnitWithSkin(p, FourCC("h01D"), 11776.0, -8192.0, 270.000, FourCC("h01D"))
u = BlzCreateUnitWithSkin(p, FourCC("h019"), 8192.0, -6784.0, 270.000, FourCC("h019"))
u = BlzCreateUnitWithSkin(p, FourCC("h019"), 8192.0, -7552.0, 270.000, FourCC("h019"))
u = BlzCreateUnitWithSkin(p, FourCC("h018"), 4096.0, -7552.0, 270.000, FourCC("h018"))
u = BlzCreateUnitWithSkin(p, FourCC("h018"), 9856.0, -1024.0, 270.000, FourCC("h018"))
u = BlzCreateUnitWithSkin(p, FourCC("h019"), 8960.0, -5376.0, 270.000, FourCC("h019"))
u = BlzCreateUnitWithSkin(p, FourCC("h019"), 8448.0, -5888.0, 270.000, FourCC("h019"))
u = BlzCreateUnitWithSkin(p, FourCC("h019"), 7680.0, -4608.0, 270.000, FourCC("h019"))
u = BlzCreateUnitWithSkin(p, FourCC("h018"), 4096.0, -1024.0, 270.000, FourCC("h018"))
u = BlzCreateUnitWithSkin(p, FourCC("h018"), 4864.0, -2304.0, 270.000, FourCC("h018"))
u = BlzCreateUnitWithSkin(p, FourCC("h018"), 5376.0, -1792.0, 270.000, FourCC("h018"))
u = BlzCreateUnitWithSkin(p, FourCC("h019"), 9216.0, -6656.0, 270.000, FourCC("h019"))
u = BlzCreateUnitWithSkin(p, FourCC("h019"), 10752.0, -8192.0, 270.000, FourCC("h019"))
u = BlzCreateUnitWithSkin(p, FourCC("h019"), 11264.0, -7680.0, 270.000, FourCC("h019"))
u = BlzCreateUnitWithSkin(p, FourCC("h019"), 12160.0, -8576.0, 270.000, FourCC("h019"))
u = BlzCreateUnitWithSkin(p, FourCC("h019"), 11648.0, -9088.0, 270.000, FourCC("h019"))
u = BlzCreateUnitWithSkin(p, FourCC("h019"), 9728.0, -6144.0, 270.000, FourCC("h019"))
end

function CreateBuildingsForPlayer13()
local p = Player(13)
local u
local unitID
local t
local life

u = BlzCreateUnitWithSkin(p, FourCC("h01B"), 12192.0, -7392.0, 270.000, FourCC("h01B"))
u = BlzCreateUnitWithSkin(p, FourCC("h01F"), 10880.0, -9088.0, 270.000, FourCC("h01F"))
end

function CreateBuildingsForPlayer14()
local p = Player(14)
local u
local unitID
local t
local life

u = BlzCreateUnitWithSkin(p, FourCC("h01B"), 12192.0, -8160.0, 270.000, FourCC("h01B"))
u = BlzCreateUnitWithSkin(p, FourCC("h01F"), 10496.0, -9088.0, 270.000, FourCC("h01F"))
end

function CreateBuildingsForPlayer15()
local p = Player(15)
local u
local unitID
local t
local life

u = BlzCreateUnitWithSkin(p, FourCC("h01B"), 12192.0, -7776.0, 270.000, FourCC("h01B"))
u = BlzCreateUnitWithSkin(p, FourCC("h01F"), 11264.0, -9088.0, 270.000, FourCC("h01F"))
end

function CreateNeutralHostileBuildings()
local p = Player(PLAYER_NEUTRAL_AGGRESSIVE)
local u
local unitID
local t
local life

u = BlzCreateUnitWithSkin(p, FourCC("n02F"), 17696.0, 17568.0, 270.000, FourCC("n02F"))
u = BlzCreateUnitWithSkin(p, FourCC("n02B"), 18048.0, 18560.0, 270.000, FourCC("n02B"))
u = BlzCreateUnitWithSkin(p, FourCC("n02B"), 18304.0, 18560.0, 270.000, FourCC("n02B"))
u = BlzCreateUnitWithSkin(p, FourCC("n02G"), 18080.0, 17568.0, 270.000, FourCC("n02G"))
u = BlzCreateUnitWithSkin(p, FourCC("n02G"), 18272.0, 17568.0, 270.000, FourCC("n02G"))
u = BlzCreateUnitWithSkin(p, FourCC("n00V"), 17760.0, 19296.0, 270.000, FourCC("n00V"))
u = BlzCreateUnitWithSkin(p, FourCC("n01G"), 18272.0, 19296.0, 270.000, FourCC("n01G"))
u = BlzCreateUnitWithSkin(p, FourCC("n01H"), 17760.0, 19040.0, 270.000, FourCC("n01H"))
u = BlzCreateUnitWithSkin(p, FourCC("n01I"), 18080.0, 19040.0, 270.000, FourCC("n01I"))
u = BlzCreateUnitWithSkin(p, FourCC("n01I"), 18272.0, 19040.0, 270.000, FourCC("n01I"))
u = BlzCreateUnitWithSkin(p, FourCC("n01J"), 17760.0, 18784.0, 270.000, FourCC("n01J"))
u = BlzCreateUnitWithSkin(p, FourCC("n02E"), 18080.0, 18784.0, 270.000, FourCC("n02E"))
u = BlzCreateUnitWithSkin(p, FourCC("n02E"), 18336.0, 18784.0, 270.000, FourCC("n02E"))
u = BlzCreateUnitWithSkin(p, FourCC("n02D"), 17728.0, 18560.0, 270.000, FourCC("n02D"))
u = BlzCreateUnitWithSkin(p, FourCC("n026"), 17696.0, 18336.0, 270.000, FourCC("n026"))
u = BlzCreateUnitWithSkin(p, FourCC("n02A"), 18080.0, 18336.0, 270.000, FourCC("n02A"))
u = BlzCreateUnitWithSkin(p, FourCC("n02A"), 18272.0, 18336.0, 270.000, FourCC("n02A"))
u = BlzCreateUnitWithSkin(p, FourCC("n00K"), 18048.0, 18112.0, 270.000, FourCC("n00K"))
u = BlzCreateUnitWithSkin(p, FourCC("n00P"), 17728.0, 18112.0, 270.000, FourCC("n00P"))
u = BlzCreateUnitWithSkin(p, FourCC("n00K"), 18304.0, 18112.0, 270.000, FourCC("n00K"))
u = BlzCreateUnitWithSkin(p, FourCC("n024"), 17760.0, 17824.0, 270.000, FourCC("n024"))
u = BlzCreateUnitWithSkin(p, FourCC("n025"), 18080.0, 17824.0, 270.000, FourCC("n025"))
u = BlzCreateUnitWithSkin(p, FourCC("n025"), 18272.0, 17824.0, 270.000, FourCC("n025"))
end

function CreateNeutralHostile()
local p = Player(PLAYER_NEUTRAL_AGGRESSIVE)
local u
local unitID
local t
local life

u = BlzCreateUnitWithSkin(p, FourCC("N006"), 16066.9, 17967.3, 270.000, FourCC("N006"))
u = BlzCreateUnitWithSkin(p, FourCC("n00T"), 15792.4, 17981.3, 270.000, FourCC("n00T"))
u = BlzCreateUnitWithSkin(p, FourCC("n00J"), 15155.2, 17991.3, 270.000, FourCC("n00J"))
u = BlzCreateUnitWithSkin(p, FourCC("n00C"), 15007.8, 17982.3, 270.000, FourCC("n00C"))
u = BlzCreateUnitWithSkin(p, FourCC("n00N"), 15545.3, 17974.9, 270.000, FourCC("n00N"))
u = BlzCreateUnitWithSkin(p, FourCC("n00F"), 15369.1, 17991.3, 270.000, FourCC("n00F"))
u = BlzCreateUnitWithSkin(p, FourCC("n00Q"), 15672.7, 17979.3, 270.000, FourCC("n00Q"))
u = BlzCreateUnitWithSkin(p, FourCC("n01D"), 16962.0, 19134.5, 266.438, FourCC("n01D"))
u = BlzCreateUnitWithSkin(p, FourCC("n01F"), 16951.7, 19003.1, 31.444, FourCC("n01F"))
u = BlzCreateUnitWithSkin(p, FourCC("n01L"), 16970.1, 18886.3, 230.731, FourCC("n01L"))
u = BlzCreateUnitWithSkin(p, FourCC("n01N"), 16958.1, 18753.5, 36.432, FourCC("n01N"))
u = BlzCreateUnitWithSkin(p, FourCC("n01P"), 16959.1, 18626.1, 239.894, FourCC("n01P"))
u = BlzCreateUnitWithSkin(p, FourCC("n01E"), 16969.2, 18518.2, 52.648, FourCC("n01E"))
u = BlzCreateUnitWithSkin(p, FourCC("n01S"), 16968.3, 18369.3, 259.802, FourCC("n01S"))
u = BlzCreateUnitWithSkin(p, FourCC("n01Q"), 17105.0, 19118.7, 143.936, FourCC("n01Q"))
u = BlzCreateUnitWithSkin(p, FourCC("n01U"), 17083.8, 19011.3, 24.478, FourCC("n01U"))
u = BlzCreateUnitWithSkin(p, FourCC("n01K"), 17099.5, 18877.6, 15.931, FourCC("n01K"))
u = BlzCreateUnitWithSkin(p, FourCC("n013"), 17087.9, 19255.6, 270.000, FourCC("n013"))
u = BlzCreateUnitWithSkin(p, FourCC("n00X"), 16961.8, 19260.6, 270.000, FourCC("n00X"))
u = BlzCreateUnitWithSkin(p, FourCC("n014"), 17212.6, 19253.9, 270.000, FourCC("n014"))
u = BlzCreateUnitWithSkin(p, FourCC("n01C"), 17098.5, 18752.9, 250.891, FourCC("n01C"))
u = BlzCreateUnitWithSkin(p, FourCC("n01W"), 17087.5, 18617.2, 185.598, FourCC("n01W"))
u = BlzCreateUnitWithSkin(p, FourCC("n01V"), 17099.5, 18484.9, 301.979, FourCC("n01V"))
end

function CreateNeutralPassiveBuildings()
local p = Player(PLAYER_NEUTRAL_PASSIVE)
local u
local unitID
local t
local life

u = BlzCreateUnitWithSkin(p, FourCC("n003"), -18432.0, 18944.0, 270.000, FourCC("n003"))
SetUnitColor(u, ConvertPlayerColor(0))
u = BlzCreateUnitWithSkin(p, FourCC("h004"), 16320.0, 19264.0, 270.000, FourCC("h004"))
u = BlzCreateUnitWithSkin(p, FourCC("h005"), 16576.0, 19264.0, 270.000, FourCC("h005"))
u = BlzCreateUnitWithSkin(p, FourCC("h00V"), 16576.0, 19008.0, 270.000, FourCC("h00V"))
u = BlzCreateUnitWithSkin(p, FourCC("h00U"), 16320.0, 19008.0, 270.000, FourCC("h00U"))
u = BlzCreateUnitWithSkin(p, FourCC("h011"), 16576.0, 18752.0, 270.000, FourCC("h011"))
u = BlzCreateUnitWithSkin(p, FourCC("h010"), 16320.0, 18752.0, 270.000, FourCC("h010"))
u = BlzCreateUnitWithSkin(p, FourCC("h018"), 16320.0, 18496.0, 270.000, FourCC("h018"))
u = BlzCreateUnitWithSkin(p, FourCC("h019"), 16576.0, 18496.0, 270.000, FourCC("h019"))
u = BlzCreateUnitWithSkin(p, FourCC("n01G"), -7200.0, 7648.0, 270.000, FourCC("n01G"))
u = BlzCreateUnitWithSkin(p, FourCC("n01G"), -7008.0, 7264.0, 270.000, FourCC("n01G"))
u = BlzCreateUnitWithSkin(p, FourCC("n01G"), -8352.0, 6880.0, 270.000, FourCC("n01G"))
u = BlzCreateUnitWithSkin(p, FourCC("NBDL"), -12032.0, -8960.0, 270.000, FourCC("NBDL"))
u = BlzCreateUnitWithSkin(p, FourCC("n01G"), -7968.0, 6496.0, 270.000, FourCC("n01G"))
u = BlzCreateUnitWithSkin(p, FourCC("n00K"), -7936.0, -384.0, 270.000, FourCC("n00K"))
u = BlzCreateUnitWithSkin(p, FourCC("n00K"), -7360.0, -384.0, 270.000, FourCC("n00K"))
u = BlzCreateUnitWithSkin(p, FourCC("n00K"), -7168.0, -640.0, 270.000, FourCC("n00K"))
u = BlzCreateUnitWithSkin(p, FourCC("n00K"), -7040.0, -1280.0, 270.000, FourCC("n00K"))
u = BlzCreateUnitWithSkin(p, FourCC("n01G"), -7008.0, 6880.0, 270.000, FourCC("n01G"))
u = BlzCreateUnitWithSkin(p, FourCC("n00K"), -7232.0, -1536.0, 270.000, FourCC("n00K"))
end

function CreateNeutralPassive()
local p = Player(PLAYER_NEUTRAL_PASSIVE)
local u
local unitID
local t
local life

u = BlzCreateUnitWithSkin(p, FourCC("h001"), 14141.2, 19257.5, 270.000, FourCC("h001"))
u = BlzCreateUnitWithSkin(p, FourCC("h00C"), 14266.6, 19272.0, 270.000, FourCC("h00C"))
u = BlzCreateUnitWithSkin(p, FourCC("h00B"), 14396.9, 19263.5, 270.000, FourCC("h00B"))
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
u = BlzCreateUnitWithSkin(p, FourCC("npig"), -9861.3, 12591.0, 290.707, FourCC("npig"))
u = BlzCreateUnitWithSkin(p, FourCC("nshe"), -9950.5, 12557.9, 337.994, FourCC("nshe"))
u = BlzCreateUnitWithSkin(p, FourCC("nech"), -9501.4, 12963.4, 190.124, FourCC("nech"))
u = BlzCreateUnitWithSkin(p, FourCC("necr"), -9538.0, 12905.5, 179.984, FourCC("necr"))
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
end

function CreateAllUnits()
CreateNeutralHostileBuildings()
CreateNeutralPassiveBuildings()
CreatePlayerBuildings()
CreateNeutralHostile()
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
gg_rct_ElfBarracksToCenter = Rect(-6208.0, -3136.0, -6080.0, -3008.0)
gg_rct_ElfBarracksToCenterSpawn = Rect(-6016.0, -3584.0, -5760.0, -2560.0)
gg_rct_ElfBarracksToHuman = Rect(-10304.0, -1984.0, -10176.0, -1856.0)
gg_rct_ElfBarracksToHumanSpawn = Rect(-10752.0, -1792.0, -9728.0, -1536.0)
gg_rct_ElfBarracksToUndead = Rect(-5056.0, -7232.0, -4928.0, -7104.0)
gg_rct_ElfBarracksToUndeadSpawn = Rect(-4864.0, -7680.0, -4608.0, -6656.0)
gg_rct_ElfBase = Rect(-10304.0, -7232.0, -10176.0, -7104.0)
gg_rct_ElfBaseHeroRespawn = Rect(-12032.0, -8832.0, -11904.0, -8704.0)
gg_rct_ElfBaseHeroSpawn = Rect(-11904.0, -8960.0, -11776.0, -8832.0)
gg_rct_ElfBaseToCenterSpawn = Rect(-9984.0, -6912.0, -9728.0, -6656.0)
gg_rct_ElfBaseToHumanSpawn = Rect(-10368.0, -6912.0, -10112.0, -6656.0)
gg_rct_ElfBaseToUndeadSpawn = Rect(-9984.0, -7296.0, -9728.0, -7040.0)
gg_rct_ElfCreepToHumanSpawn = Rect(-8192.0, -1536.0, -7424.0, -768.0)
gg_rct_ElfCreepToHumanSpawnBuilding = Rect(-7808.0, -768.0, -7552.0, -512.0)
gg_rct_ElfCreepToUndeadSpawn = Rect(-4608.0, -5120.0, -3840.0, -4352.0)
gg_rct_ElfCreepToUndeadSpawnBuilding = Rect(-4224.0, -4352.0, -3968.0, -4096.0)
gg_rct_ElfToHumanInnerLine = Rect(-10304.0, -5184.0, -10176.0, -5056.0)
gg_rct_ElfToHumanOuterLine = Rect(-10304.0, -1088.0, -10176.0, -960.0)
gg_rct_ElfToOrcInnerLine = Rect(-8768.0, -5696.0, -8640.0, -5568.0)
gg_rct_ElfToOrcOuterLine = Rect(-5184.0, -2112.0, -5056.0, -1984.0)
gg_rct_ElfToUndeadInnerLine = Rect(-8256.0, -7232.0, -8128.0, -7104.0)
gg_rct_ElfToUndeadOuterLine = Rect(-4160.0, -7232.0, -4032.0, -7104.0)
gg_rct_HeroSelectorSpawn = Rect(-18496.0, 18368.0, -18368.0, 18496.0)
gg_rct_HumanBarracksToCenter = Rect(-6208.0, 9152.0, -6080.0, 9280.0)
gg_rct_HumanBarracksToCenterSpawn = Rect(-6016.0, 8704.0, -5760.0, 9728.0)
gg_rct_HumanBarracksToElf = Rect(-10304.0, 8000.0, -10176.0, 8128.0)
gg_rct_HumanBarracksToElfSpawn = Rect(-10752.0, 7680.0, -9728.0, 7936.0)
gg_rct_HumanBarracksToOrc = Rect(-5056.0, 13248.0, -4928.0, 13376.0)
gg_rct_HumanBarracksToOrcSpawn = Rect(-4864.0, 12800.0, -4608.0, 13824.0)
gg_rct_HumanBase = Rect(-10304.0, 13248.0, -10176.0, 13376.0)
gg_rct_HumanBaseHeroRespawn = Rect(-11904.0, 14976.0, -11776.0, 15104.0)
gg_rct_HumanBaseHeroSpawn = Rect(-12032.0, 14848.0, -11904.0, 14976.0)
gg_rct_HumanBaseToCenterSpawn = Rect(-9984.0, 12800.0, -9728.0, 13056.0)
gg_rct_HumanBaseToElfSpawn = Rect(-10368.0, 12800.0, -10112.0, 13056.0)
gg_rct_HumanBaseToOrcSpawn = Rect(-9984.0, 13184.0, -9728.0, 13440.0)
gg_rct_HumanCreepToElfSpawn = Rect(-8192.0, 6912.0, -7424.0, 7680.0)
gg_rct_HumanCreepToElfSpawnBuilding = Rect(-7808.0, 6656.0, -7552.0, 6912.0)
gg_rct_HumanCreepToOrcSpawn = Rect(-4608.0, 10496.0, -3840.0, 11264.0)
gg_rct_HumanCreepToOrcSpawnBuilding = Rect(-4224.0, 10240.0, -3968.0, 10496.0)
gg_rct_HumanToElfInnerLine = Rect(-10304.0, 11200.0, -10176.0, 11328.0)
gg_rct_HumanToElfOuterLine = Rect(-10304.0, 7104.0, -10176.0, 7232.0)
gg_rct_HumanToOrcInnerLine = Rect(-8256.0, 13248.0, -8128.0, 13376.0)
gg_rct_HumanToOrcOuterLine = Rect(-4160.0, 13248.0, -4032.0, 13376.0)
gg_rct_HumanToUndeadInnerLine = Rect(-8768.0, 11712.0, -8640.0, 11840.0)
gg_rct_HumanToUndeadOuterLine = Rect(-5184.0, 8128.0, -5056.0, 8256.0)
gg_rct_OrcBarracksToCenter = Rect(6080.0, 9152.0, 6208.0, 9280.0)
gg_rct_OrcBarracksToCenterSpawn = Rect(5760.0, 8704.0, 6016.0, 9728.0)
gg_rct_OrcBarracksToHuman = Rect(4928.0, 13248.0, 5056.0, 13376.0)
gg_rct_OrcBarracksToHumanSpawn = Rect(4608.0, 12800.0, 4864.0, 13824.0)
gg_rct_OrcBarracksToUndead = Rect(10176.0, 8000.0, 10304.0, 8128.0)
gg_rct_OrcBarracksToUndeadSpawn = Rect(9728.0, 7680.0, 10752.0, 7936.0)
gg_rct_OrcBase = Rect(10176.0, 13248.0, 10304.0, 13376.0)
gg_rct_OrcBaseHeroRespawn = Rect(11776.0, 14976.0, 11904.0, 15104.0)
gg_rct_OrcBaseHeroSpawn = Rect(11904.0, 14848.0, 12032.0, 14976.0)
gg_rct_OrcBaseToCenterSpawn = Rect(9728.0, 12800.0, 9984.0, 13056.0)
gg_rct_OrcBaseToHumanSpawn = Rect(9728.0, 13184.0, 9984.0, 13440.0)
gg_rct_OrcBaseToUndeadSpawn = Rect(10112.0, 12800.0, 10368.0, 13056.0)
gg_rct_OrcCreepToHumanSpawn = Rect(3840.0, 10496.0, 4608.0, 11264.0)
gg_rct_OrcCreepToHumanSpawnBuilding = Rect(3968.0, 10240.0, 4224.0, 10496.0)
gg_rct_OrcCreepToUndeadSpawn = Rect(7296.0, 6784.0, 8064.0, 7552.0)
gg_rct_OrcCreepToUndeadSpawnBuilding = Rect(7552.0, 6528.0, 7808.0, 6784.0)
gg_rct_OrcToElfInnerLine = Rect(8640.0, 11712.0, 8768.0, 11840.0)
gg_rct_OrcToElfOuterLine = Rect(5056.0, 8128.0, 5184.0, 8256.0)
gg_rct_OrcToHumanInnerLine = Rect(8128.0, 13248.0, 8256.0, 13376.0)
gg_rct_OrcToHumanOuterLine = Rect(4032.0, 13248.0, 4160.0, 13376.0)
gg_rct_OrcToUndeadInnerLine = Rect(10176.0, 11200.0, 10304.0, 11328.0)
gg_rct_OrcToUndeadOuterLine = Rect(10176.0, 7104.0, 10304.0, 7232.0)
gg_rct_TestArea = Rect(17280.0, 17280.0, 17408.0, 17408.0)
gg_rct_TestArea2 = Rect(-8640.0, 7616.0, -8512.0, 7744.0)
gg_rct_UndeadBarracksToCenter = Rect(6080.0, -3136.0, 6208.0, -3008.0)
gg_rct_UndeadBarracksToCenterSpawn = Rect(5760.0, -3584.0, 6016.0, -2560.0)
gg_rct_UndeadBarracksToElf = Rect(4928.0, -7232.0, 5056.0, -7104.0)
gg_rct_UndeadBarracksToElfSpawn = Rect(4608.0, -7680.0, 4864.0, -6656.0)
gg_rct_UndeadBarracksToOrc = Rect(10176.0, -1984.0, 10304.0, -1856.0)
gg_rct_UndeadBarracksToOrcSpawn = Rect(9728.0, -1792.0, 10752.0, -1536.0)
gg_rct_UndeadBase = Rect(10176.0, -7232.0, 10304.0, -7104.0)
gg_rct_UndeadBaseHeroRespawn = Rect(11776.0, -8960.0, 11904.0, -8832.0)
gg_rct_UndeadBaseHeroSpawn = Rect(11904.0, -8832.0, 12032.0, -8704.0)
gg_rct_UndeadBaseToCenterSpawn = Rect(9728.0, -6912.0, 9984.0, -6656.0)
gg_rct_UndeadBaseToElfSpawn = Rect(9728.0, -7296.0, 9984.0, -7040.0)
gg_rct_UndeadBaseToOrcSpawn = Rect(10112.0, -6912.0, 10368.0, -6656.0)
gg_rct_UndeadCreepToElfSpawn = Rect(3840.0, -5120.0, 4608.0, -4352.0)
gg_rct_UndeadCreepToElfSpawnBuilding = Rect(3968.0, -4352.0, 4224.0, -4096.0)
gg_rct_UndeadCreepToOrcSpawn = Rect(7424.0, -1536.0, 8192.0, -768.0)
gg_rct_UndeadCreepToOrcSpawnBuilding = Rect(7552.0, -768.0, 7808.0, -512.0)
gg_rct_UndeadToElfInnerLine = Rect(8128.0, -7232.0, 8256.0, -7104.0)
gg_rct_UndeadToElfOuterLine = Rect(4032.0, -7232.0, 4160.0, -7104.0)
gg_rct_UndeadToHumanInnerLine = Rect(8640.0, -5696.0, 8768.0, -5568.0)
gg_rct_UndeadToHumanOuterLine = Rect(5056.0, -2112.0, 5184.0, -1984.0)
gg_rct_UndeadToOrcInnerLine = Rect(10176.0, -5184.0, 10304.0, -5056.0)
gg_rct_UndeadToOrcOuterLine = Rect(10176.0, -1088.0, 10304.0, -960.0)
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
end

function InitAllyPriorities()
SetStartLocPrioCount(0, 2)
SetStartLocPrio(0, 0, 1, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(0, 1, 2, MAP_LOC_PRIO_HIGH)
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
end

function main()
SetCameraBounds(-19712.0 + GetCameraMargin(CAMERA_MARGIN_LEFT), -19968.0 + GetCameraMargin(CAMERA_MARGIN_BOTTOM), 19712.0 - GetCameraMargin(CAMERA_MARGIN_RIGHT), 19456.0 - GetCameraMargin(CAMERA_MARGIN_TOP), -19712.0 + GetCameraMargin(CAMERA_MARGIN_LEFT), 19456.0 - GetCameraMargin(CAMERA_MARGIN_TOP), 19712.0 - GetCameraMargin(CAMERA_MARGIN_RIGHT), -19968.0 + GetCameraMargin(CAMERA_MARGIN_BOTTOM))
SetDayNightModels("Environment\\DNC\\DNCLordaeron\\DNCLordaeronTerrain\\DNCLordaeronTerrain.mdl", "Environment\\DNC\\DNCLordaeron\\DNCLordaeronUnit\\DNCLordaeronUnit.mdl")
NewSoundEnvironment("Default")
SetAmbientDaySound("LordaeronSummerDay")
SetAmbientNightSound("LordaeronSummerNight")
SetMapMusic("Music", true, 0)
InitSounds()
CreateRegions()
CreateAllUnits()
InitBlizzard()
InitGlobals()
end

function config()
SetMapName("TRIGSTR_001")
SetMapDescription("TRIGSTR_003")
SetPlayers(16)
SetTeams(16)
SetGamePlacement(MAP_PLACEMENT_TEAMS_TOGETHER)
DefineStartLocation(0, -10240.0, 13312.0)
DefineStartLocation(1, -18432.0, 18432.0)
DefineStartLocation(2, -18432.0, 18432.0)
DefineStartLocation(3, -18432.0, 18432.0)
DefineStartLocation(4, 10240.0, 13312.0)
DefineStartLocation(5, -18432.0, 18432.0)
DefineStartLocation(6, -18432.0, 18432.0)
DefineStartLocation(7, -18432.0, 18432.0)
DefineStartLocation(8, -10240.0, -7168.0)
DefineStartLocation(9, -18432.0, 18432.0)
DefineStartLocation(10, -18432.0, 18432.0)
DefineStartLocation(11, -18432.0, 18432.0)
DefineStartLocation(12, 10240.0, -7168.0)
DefineStartLocation(13, -18432.0, 18432.0)
DefineStartLocation(14, -18432.0, 18432.0)
DefineStartLocation(15, -18432.0, 18432.0)
InitCustomPlayerSlots()
InitCustomTeams()
InitAllyPriorities()
end

