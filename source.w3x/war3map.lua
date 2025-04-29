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
gg_rct_OrcToElfInnerLine = nil
gg_rct_OrcToElfOuterLine = nil
gg_rct_OrcToHumanInnerLine = nil
gg_rct_OrcToHumanOuterLine = nil
gg_rct_OrcToUndeadInnerLine = nil
gg_rct_OrcToUndeadOuterLine = nil
gg_rct_TestArea = nil
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
gg_rct_HumanCreepToElf = nil
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

u = BlzCreateUnitWithSkin(p, FourCC("h005"), -8192.0, 13824.0, 270.000, FourCC("h005"))
u = BlzCreateUnitWithSkin(p, FourCC("h005"), -8192.0, 12800.0, 270.000, FourCC("h005"))
u = BlzCreateUnitWithSkin(p, FourCC("h005"), -6912.0, 13312.0, 270.000, FourCC("h005"))
u = BlzCreateUnitWithSkin(p, FourCC("h004"), -4096.0, 13824.0, 270.000, FourCC("h004"))
u = BlzCreateUnitWithSkin(p, FourCC("h004"), -4096.0, 12800.0, 270.000, FourCC("h004"))
u = BlzCreateUnitWithSkin(p, FourCC("h004"), -2816.0, 13312.0, 270.000, FourCC("h004"))
u = BlzCreateUnitWithSkin(p, FourCC("h005"), -9728.0, 11264.0, 270.000, FourCC("h005"))
u = BlzCreateUnitWithSkin(p, FourCC("h005"), -10752.0, 11264.0, 270.000, FourCC("h005"))
u = BlzCreateUnitWithSkin(p, FourCC("h005"), -10240.0, 9920.0, 270.000, FourCC("h005"))
u = BlzCreateUnitWithSkin(p, FourCC("n005"), -12032.0, 15104.0, 270.000, FourCC("n005"))
u = BlzCreateUnitWithSkin(p, FourCC("h009"), -11264.0, 14848.0, 270.000, FourCC("h009"))
u = BlzCreateUnitWithSkin(p, FourCC("h005"), -10240.0, 12288.0, 270.000, FourCC("h005"))
u = BlzCreateUnitWithSkin(p, FourCC("h005"), -9216.0, 13312.0, 270.000, FourCC("h005"))
u = BlzCreateUnitWithSkin(p, FourCC("h005"), -9024.0, 11456.0, 270.000, FourCC("h005"))
u = BlzCreateUnitWithSkin(p, FourCC("h005"), -8384.0, 12096.0, 270.000, FourCC("h005"))
u = BlzCreateUnitWithSkin(p, FourCC("h005"), -7680.0, 10752.0, 270.000, FourCC("h005"))
u = BlzCreateUnitWithSkin(p, FourCC("h004"), -9728.0, 7168.0, 270.000, FourCC("h004"))
u = BlzCreateUnitWithSkin(p, FourCC("h004"), -10752.0, 7168.0, 270.000, FourCC("h004"))
u = BlzCreateUnitWithSkin(p, FourCC("h004"), -10240.0, 5888.0, 270.000, FourCC("h004"))
u = BlzCreateUnitWithSkin(p, FourCC("h004"), -5440.0, 7872.0, 270.000, FourCC("h004"))
u = BlzCreateUnitWithSkin(p, FourCC("h004"), -4800.0, 8512.0, 270.000, FourCC("h004"))
u = BlzCreateUnitWithSkin(p, FourCC("h004"), -4096.0, 7168.0, 270.000, FourCC("h004"))
u = BlzCreateUnitWithSkin(p, FourCC("h005"), -11264.0, 13824.0, 270.000, FourCC("h005"))
u = BlzCreateUnitWithSkin(p, FourCC("h005"), -10752.0, 14336.0, 270.000, FourCC("h005"))
u = BlzCreateUnitWithSkin(p, FourCC("h009"), 17152.0, 17152.0, 270.000, FourCC("h009"))
u = BlzCreateUnitWithSkin(p, FourCC("h005"), -9472.0, 12544.0, 270.000, FourCC("h005"))
u = BlzCreateUnitWithSkin(p, FourCC("h005"), -12288.0, 14848.0, 270.000, FourCC("h005"))
u = BlzCreateUnitWithSkin(p, FourCC("h005"), -11776.0, 15360.0, 270.000, FourCC("h005"))
u = BlzCreateUnitWithSkin(p, FourCC("h00T"), -11776.0, 14336.0, 270.000, FourCC("h00T"))
end

function CreateBuildingsForPlayer1()
local p = Player(1)
local u
local unitID
local t
local life

u = BlzCreateUnitWithSkin(p, FourCC("h00D"), -11232.0, 15392.0, 270.000, FourCC("h00D"))
u = BlzCreateUnitWithSkin(p, FourCC("h00A"), -12288.0, 14336.0, 270.000, FourCC("h00A"))
end

function CreateUnitsForPlayer1()
local p = Player(1)
local u
local unitID
local t
local life

u = BlzCreateUnitWithSkin(p, FourCC("h00C"), 19251.9, 18381.5, 270.000, FourCC("h00C"))
u = BlzCreateUnitWithSkin(p, FourCC("h001"), 19392.8, 18368.4, 270.000, FourCC("h001"))
u = BlzCreateUnitWithSkin(p, FourCC("h00B"), 19139.2, 18369.8, 270.000, FourCC("h00B"))
u = BlzCreateUnitWithSkin(p, FourCC("h002"), 19007.2, 18374.0, 270.000, FourCC("h002"))
u = BlzCreateUnitWithSkin(p, FourCC("h00F"), 18885.7, 18358.0, 270.000, FourCC("h00F"))
u = BlzCreateUnitWithSkin(p, FourCC("h00G"), 18753.7, 18375.4, 270.000, FourCC("h00G"))
u = BlzCreateUnitWithSkin(p, FourCC("h008"), 18629.3, 18356.4, 270.000, FourCC("h008"))
u = BlzCreateUnitWithSkin(p, FourCC("h00H"), 18503.3, 18363.6, 270.000, FourCC("h00H"))
u = BlzCreateUnitWithSkin(p, FourCC("h00I"), 18365.5, 18356.4, 270.000, FourCC("h00I"))
u = BlzCreateUnitWithSkin(p, FourCC("h00E"), 17843.1, 18375.7, 270.000, FourCC("h00E"))
u = BlzCreateUnitWithSkin(p, FourCC("h00J"), 18239.4, 18372.5, 270.000, FourCC("h00J"))
u = BlzCreateUnitWithSkin(p, FourCC("h00K"), 18108.9, 18372.5, 270.000, FourCC("h00K"))
u = BlzCreateUnitWithSkin(p, FourCC("h00L"), 17976.9, 18372.5, 270.000, FourCC("h00L"))
end

function CreateBuildingsForPlayer2()
local p = Player(2)
local u
local unitID
local t
local life

u = BlzCreateUnitWithSkin(p, FourCC("h00A"), -12288.0, 13824.0, 270.000, FourCC("h00A"))
u = BlzCreateUnitWithSkin(p, FourCC("h00D"), -10720.0, 15392.0, 270.000, FourCC("h00D"))
end

function CreateBuildingsForPlayer3()
local p = Player(3)
local u
local unitID
local t
local life

u = BlzCreateUnitWithSkin(p, FourCC("h00A"), -12288.0, 13312.0, 270.000, FourCC("h00A"))
u = BlzCreateUnitWithSkin(p, FourCC("h00D"), -10208.0, 15392.0, 270.000, FourCC("h00D"))
end

function CreateBuildingsForPlayer4()
local p = Player(4)
local u
local unitID
local t
local life

u = BlzCreateUnitWithSkin(p, FourCC("h00U"), 4096.0, 7168.0, 270.000, FourCC("h00U"))
u = BlzCreateUnitWithSkin(p, FourCC("h00V"), 7680.0, 10752.0, 270.000, FourCC("h00V"))
u = BlzCreateUnitWithSkin(p, FourCC("h00V"), 8384.0, 12096.0, 270.000, FourCC("h00V"))
u = BlzCreateUnitWithSkin(p, FourCC("h00V"), 9216.0, 13312.0, 270.000, FourCC("h00V"))
u = BlzCreateUnitWithSkin(p, FourCC("h00V"), 10240.0, 12288.0, 270.000, FourCC("h00V"))
u = BlzCreateUnitWithSkin(p, FourCC("h00V"), 6912.0, 13312.0, 270.000, FourCC("h00V"))
u = BlzCreateUnitWithSkin(p, FourCC("h00W"), 11776.0, 14336.0, 270.000, FourCC("h00W"))
u = BlzCreateUnitWithSkin(p, FourCC("h00U"), 2816.0, 13312.0, 270.000, FourCC("h00U"))
u = BlzCreateUnitWithSkin(p, FourCC("h00U"), 4800.0, 8512.0, 270.000, FourCC("h00U"))
u = BlzCreateUnitWithSkin(p, FourCC("h00V"), 8192.0, 13824.0, 270.000, FourCC("h00V"))
u = BlzCreateUnitWithSkin(p, FourCC("h00V"), 8192.0, 12800.0, 270.000, FourCC("h00V"))
u = BlzCreateUnitWithSkin(p, FourCC("h00V"), 9024.0, 11456.0, 270.000, FourCC("h00V"))
u = BlzCreateUnitWithSkin(p, FourCC("h00X"), 11264.0, 14848.0, 270.000, FourCC("h00X"))
u = BlzCreateUnitWithSkin(p, FourCC("NBDB"), 12032.0, 15104.0, 270.000, FourCC("NBDB"))
u = BlzCreateUnitWithSkin(p, FourCC("h00V"), 10240.0, 9984.0, 270.000, FourCC("h00V"))
u = BlzCreateUnitWithSkin(p, FourCC("h00V"), 9728.0, 11264.0, 270.000, FourCC("h00V"))
u = BlzCreateUnitWithSkin(p, FourCC("h00V"), 10752.0, 11264.0, 270.000, FourCC("h00V"))
u = BlzCreateUnitWithSkin(p, FourCC("h00U"), 10240.0, 5888.0, 270.000, FourCC("h00U"))
u = BlzCreateUnitWithSkin(p, FourCC("h00U"), 9728.0, 7168.0, 270.000, FourCC("h00U"))
u = BlzCreateUnitWithSkin(p, FourCC("h00U"), 5440.0, 7872.0, 270.000, FourCC("h00U"))
u = BlzCreateUnitWithSkin(p, FourCC("h00U"), 4096.0, 13824.0, 270.000, FourCC("h00U"))
u = BlzCreateUnitWithSkin(p, FourCC("h00U"), 4096.0, 12800.0, 270.000, FourCC("h00U"))
u = BlzCreateUnitWithSkin(p, FourCC("h00U"), 10752.0, 7168.0, 270.000, FourCC("h00U"))
u = BlzCreateUnitWithSkin(p, FourCC("h00V"), 9472.0, 12544.0, 270.000, FourCC("h00V"))
u = BlzCreateUnitWithSkin(p, FourCC("h00V"), 12288.0, 14848.0, 270.000, FourCC("h00V"))
u = BlzCreateUnitWithSkin(p, FourCC("h00V"), 10752.0, 14336.0, 270.000, FourCC("h00V"))
u = BlzCreateUnitWithSkin(p, FourCC("h00V"), 11264.0, 13824.0, 270.000, FourCC("h00V"))
u = BlzCreateUnitWithSkin(p, FourCC("h00V"), 11776.0, 15360.0, 270.000, FourCC("h00V"))
end

function CreateBuildingsForPlayer5()
local p = Player(5)
local u
local unitID
local t
local life

u = BlzCreateUnitWithSkin(p, FourCC("h017"), 12288.0, 14336.0, 270.000, FourCC("h017"))
u = BlzCreateUnitWithSkin(p, FourCC("h01G"), 10272.0, 15392.0, 270.000, FourCC("h01G"))
end

function CreateBuildingsForPlayer6()
local p = Player(6)
local u
local unitID
local t
local life

u = BlzCreateUnitWithSkin(p, FourCC("h017"), 12288.0, 13824.0, 270.000, FourCC("h017"))
u = BlzCreateUnitWithSkin(p, FourCC("h01G"), 10784.0, 15392.0, 270.000, FourCC("h01G"))
end

function CreateBuildingsForPlayer7()
local p = Player(7)
local u
local unitID
local t
local life

u = BlzCreateUnitWithSkin(p, FourCC("h017"), 12288.0, 13312.0, 270.000, FourCC("h017"))
u = BlzCreateUnitWithSkin(p, FourCC("h01G"), 11296.0, 15392.0, 270.000, FourCC("h01G"))
end

function CreateBuildingsForPlayer8()
local p = Player(8)
local u
local unitID
local t
local life

u = BlzCreateUnitWithSkin(p, FourCC("h010"), -10240.0, 256.0, 270.000, FourCC("h010"))
u = BlzCreateUnitWithSkin(p, FourCC("h010"), -10752.0, -1024.0, 270.000, FourCC("h010"))
u = BlzCreateUnitWithSkin(p, FourCC("h011"), -8384.0, -5952.0, 270.000, FourCC("h011"))
u = BlzCreateUnitWithSkin(p, FourCC("h011"), -9024.0, -5312.0, 270.000, FourCC("h011"))
u = BlzCreateUnitWithSkin(p, FourCC("h011"), -9216.0, -7168.0, 270.000, FourCC("h011"))
u = BlzCreateUnitWithSkin(p, FourCC("h011"), -10240.0, -6144.0, 270.000, FourCC("h011"))
u = BlzCreateUnitWithSkin(p, FourCC("h011"), -8192.0, -6656.0, 270.000, FourCC("h011"))
u = BlzCreateUnitWithSkin(p, FourCC("h010"), -4096.0, -1024.0, 270.000, FourCC("h010"))
u = BlzCreateUnitWithSkin(p, FourCC("h010"), -4800.0, -2368.0, 270.000, FourCC("h010"))
u = BlzCreateUnitWithSkin(p, FourCC("h010"), -9728.0, -1024.0, 270.000, FourCC("h010"))
u = BlzCreateUnitWithSkin(p, FourCC("h010"), -2816.0, -7168.0, 270.000, FourCC("h010"))
u = BlzCreateUnitWithSkin(p, FourCC("h010"), -4096.0, -7680.0, 270.000, FourCC("h010"))
u = BlzCreateUnitWithSkin(p, FourCC("h010"), -4096.0, -6656.0, 270.000, FourCC("h010"))
u = BlzCreateUnitWithSkin(p, FourCC("h011"), -6912.0, -7168.0, 270.000, FourCC("h011"))
u = BlzCreateUnitWithSkin(p, FourCC("h011"), -8192.0, -7680.0, 270.000, FourCC("h011"))
u = BlzCreateUnitWithSkin(p, FourCC("h010"), -5440.0, -1728.0, 270.000, FourCC("h010"))
u = BlzCreateUnitWithSkin(p, FourCC("h013"), -11264.0, -8704.0, 270.000, FourCC("h013"))
u = BlzCreateUnitWithSkin(p, FourCC("h011"), -11264.0, -7680.0, 270.000, FourCC("h011"))
u = BlzCreateUnitWithSkin(p, FourCC("h012"), -11776.0, -8192.0, 270.000, FourCC("h012"))
u = BlzCreateUnitWithSkin(p, FourCC("h011"), -10752.0, -8192.0, 270.000, FourCC("h011"))
u = BlzCreateUnitWithSkin(p, FourCC("h011"), -7680.0, -4608.0, 270.000, FourCC("h011"))
u = BlzCreateUnitWithSkin(p, FourCC("h011"), -10240.0, -3840.0, 270.000, FourCC("h011"))
u = BlzCreateUnitWithSkin(p, FourCC("h011"), -10752.0, -5120.0, 270.000, FourCC("h011"))
u = BlzCreateUnitWithSkin(p, FourCC("h011"), -9728.0, -5120.0, 270.000, FourCC("h011"))
u = BlzCreateUnitWithSkin(p, FourCC("h011"), -9472.0, -6400.0, 270.000, FourCC("h011"))
u = BlzCreateUnitWithSkin(p, FourCC("h011"), -12288.0, -8704.0, 270.000, FourCC("h011"))
u = BlzCreateUnitWithSkin(p, FourCC("h011"), -11776.0, -9216.0, 270.000, FourCC("h011"))
end

function CreateBuildingsForPlayer9()
local p = Player(9)
local u
local unitID
local t
local life

u = BlzCreateUnitWithSkin(p, FourCC("h016"), -12288.0, -8192.0, 270.000, FourCC("h016"))
u = BlzCreateUnitWithSkin(p, FourCC("h01H"), -11232.0, -9184.0, 270.000, FourCC("h01H"))
end

function CreateBuildingsForPlayer10()
local p = Player(10)
local u
local unitID
local t
local life

u = BlzCreateUnitWithSkin(p, FourCC("h016"), -12288.0, -7680.0, 270.000, FourCC("h016"))
u = BlzCreateUnitWithSkin(p, FourCC("h01H"), -10720.0, -9184.0, 270.000, FourCC("h01H"))
end

function CreateBuildingsForPlayer11()
local p = Player(11)
local u
local unitID
local t
local life

u = BlzCreateUnitWithSkin(p, FourCC("h016"), -12288.0, -7168.0, 270.000, FourCC("h016"))
u = BlzCreateUnitWithSkin(p, FourCC("h01H"), -10208.0, -9184.0, 270.000, FourCC("h01H"))
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
u = BlzCreateUnitWithSkin(p, FourCC("h018"), 4096.0, -6656.0, 270.000, FourCC("h018"))
u = BlzCreateUnitWithSkin(p, FourCC("h019"), 10240.0, -3840.0, 270.000, FourCC("h019"))
u = BlzCreateUnitWithSkin(p, FourCC("h019"), 10752.0, -5120.0, 270.000, FourCC("h019"))
u = BlzCreateUnitWithSkin(p, FourCC("h018"), 10240.0, 256.0, 270.000, FourCC("h018"))
u = BlzCreateUnitWithSkin(p, FourCC("h018"), 10752.0, -1024.0, 270.000, FourCC("h018"))
u = BlzCreateUnitWithSkin(p, FourCC("h019"), 6912.0, -7168.0, 270.000, FourCC("h019"))
u = BlzCreateUnitWithSkin(p, FourCC("h019"), 9728.0, -5120.0, 270.000, FourCC("h019"))
u = BlzCreateUnitWithSkin(p, FourCC("h019"), 9216.0, -7168.0, 270.000, FourCC("h019"))
u = BlzCreateUnitWithSkin(p, FourCC("h019"), 10240.0, -6144.0, 270.000, FourCC("h019"))
u = BlzCreateUnitWithSkin(p, FourCC("h01D"), 11776.0, -8192.0, 270.000, FourCC("h01D"))
u = BlzCreateUnitWithSkin(p, FourCC("h019"), 8192.0, -6656.0, 270.000, FourCC("h019"))
u = BlzCreateUnitWithSkin(p, FourCC("h019"), 8192.0, -7680.0, 270.000, FourCC("h019"))
u = BlzCreateUnitWithSkin(p, FourCC("h018"), 4096.0, -7680.0, 270.000, FourCC("h018"))
u = BlzCreateUnitWithSkin(p, FourCC("h018"), 9728.0, -1024.0, 270.000, FourCC("h018"))
u = BlzCreateUnitWithSkin(p, FourCC("h019"), 9024.0, -5312.0, 270.000, FourCC("h019"))
u = BlzCreateUnitWithSkin(p, FourCC("h019"), 8384.0, -5952.0, 270.000, FourCC("h019"))
u = BlzCreateUnitWithSkin(p, FourCC("h019"), 7680.0, -4608.0, 270.000, FourCC("h019"))
u = BlzCreateUnitWithSkin(p, FourCC("h018"), 4096.0, -1024.0, 270.000, FourCC("h018"))
u = BlzCreateUnitWithSkin(p, FourCC("h018"), 4800.0, -2368.0, 270.000, FourCC("h018"))
u = BlzCreateUnitWithSkin(p, FourCC("h018"), 5440.0, -1728.0, 270.000, FourCC("h018"))
u = BlzCreateUnitWithSkin(p, FourCC("h019"), 9472.0, -6400.0, 270.000, FourCC("h019"))
u = BlzCreateUnitWithSkin(p, FourCC("h019"), 10752.0, -8192.0, 270.000, FourCC("h019"))
u = BlzCreateUnitWithSkin(p, FourCC("h019"), 11264.0, -7680.0, 270.000, FourCC("h019"))
u = BlzCreateUnitWithSkin(p, FourCC("h019"), 12288.0, -8704.0, 270.000, FourCC("h019"))
u = BlzCreateUnitWithSkin(p, FourCC("h019"), 11776.0, -9216.0, 270.000, FourCC("h019"))
end

function CreateBuildingsForPlayer13()
local p = Player(13)
local u
local unitID
local t
local life

u = BlzCreateUnitWithSkin(p, FourCC("h01B"), 12320.0, -7136.0, 270.000, FourCC("h01B"))
u = BlzCreateUnitWithSkin(p, FourCC("h01F"), 10752.0, -9216.0, 270.000, FourCC("h01F"))
end

function CreateBuildingsForPlayer14()
local p = Player(14)
local u
local unitID
local t
local life

u = BlzCreateUnitWithSkin(p, FourCC("h01B"), 12320.0, -8160.0, 270.000, FourCC("h01B"))
u = BlzCreateUnitWithSkin(p, FourCC("h01F"), 10240.0, -9216.0, 270.000, FourCC("h01F"))
end

function CreateBuildingsForPlayer15()
local p = Player(15)
local u
local unitID
local t
local life

u = BlzCreateUnitWithSkin(p, FourCC("h01B"), 12320.0, -7648.0, 270.000, FourCC("h01B"))
u = BlzCreateUnitWithSkin(p, FourCC("h01F"), 11264.0, -9216.0, 270.000, FourCC("h01F"))
end

function CreateNeutralPassiveBuildings()
local p = Player(PLAYER_NEUTRAL_PASSIVE)
local u
local unitID
local t
local life

u = BlzCreateUnitWithSkin(p, FourCC("n003"), -18432.0, 18944.0, 270.000, FourCC("n003"))
SetUnitColor(u, ConvertPlayerColor(0))
u = BlzCreateUnitWithSkin(p, FourCC("h003"), 16768.0, 18688.0, 270.000, FourCC("h003"))
u = BlzCreateUnitWithSkin(p, FourCC("h007"), 16320.0, 18688.0, 270.000, FourCC("h007"))
u = BlzCreateUnitWithSkin(p, FourCC("h004"), 15616.0, 18816.0, 270.000, FourCC("h004"))
u = BlzCreateUnitWithSkin(p, FourCC("h005"), 15872.0, 18816.0, 270.000, FourCC("h005"))
u = BlzCreateUnitWithSkin(p, FourCC("h009"), 15104.0, 18688.0, 270.000, FourCC("h009"))
u = BlzCreateUnitWithSkin(p, FourCC("NBDL"), -12032.0, -8960.0, 270.000, FourCC("NBDL"))
u = BlzCreateUnitWithSkin(p, FourCC("h00D"), 14624.0, 18720.0, 270.000, FourCC("h00D"))
u = BlzCreateUnitWithSkin(p, FourCC("h00A"), 14080.0, 18688.0, 270.000, FourCC("h00A"))
u = BlzCreateUnitWithSkin(p, FourCC("h004"), 15616.0, 18560.0, 270.000, FourCC("h004"))
u = BlzCreateUnitWithSkin(p, FourCC("h005"), 15872.0, 18560.0, 270.000, FourCC("h005"))
end

function CreateNeutralPassive()
local p = Player(PLAYER_NEUTRAL_PASSIVE)
local u
local unitID
local t
local life

u = BlzCreateUnitWithSkin(p, FourCC("h001"), 19374.8, 18106.5, 270.000, FourCC("h001"))
u = BlzCreateUnitWithSkin(p, FourCC("h001"), 19275.0, 18102.3, 270.000, FourCC("h001"))
u = BlzCreateUnitWithSkin(p, FourCC("h001"), 19257.6, 17970.5, 270.000, FourCC("h001"))
u = BlzCreateUnitWithSkin(p, FourCC("h001"), 19383.5, 17976.9, 270.000, FourCC("h001"))
u = BlzCreateUnitWithSkin(p, FourCC("h00C"), 19255.4, 17730.3, 270.000, FourCC("h00C"))
u = BlzCreateUnitWithSkin(p, FourCC("h00C"), 19394.4, 17715.4, 270.000, FourCC("h00C"))
u = BlzCreateUnitWithSkin(p, FourCC("h00C"), 19259.8, 17592.2, 270.000, FourCC("h00C"))
u = BlzCreateUnitWithSkin(p, FourCC("h00C"), 19381.3, 17585.8, 270.000, FourCC("h00C"))
u = BlzCreateUnitWithSkin(p, FourCC("h00B"), 19257.6, 17366.9, 270.000, FourCC("h00B"))
u = BlzCreateUnitWithSkin(p, FourCC("h00B"), 19398.7, 17345.6, 270.000, FourCC("h00B"))
u = BlzCreateUnitWithSkin(p, FourCC("h00B"), 19246.8, 17207.5, 270.000, FourCC("h00B"))
u = BlzCreateUnitWithSkin(p, FourCC("h00B"), 19394.4, 17216.0, 270.000, FourCC("h00B"))
u = BlzCreateUnitWithSkin(p, FourCC("h002"), 19001.5, 18115.0, 270.000, FourCC("h002"))
u = BlzCreateUnitWithSkin(p, FourCC("h002"), 18877.8, 18102.3, 270.000, FourCC("h002"))
u = BlzCreateUnitWithSkin(p, FourCC("h002"), 18871.3, 17993.9, 270.000, FourCC("h002"))
u = BlzCreateUnitWithSkin(p, FourCC("h002"), 18999.3, 17987.5, 270.000, FourCC("h002"))
u = BlzCreateUnitWithSkin(p, FourCC("h00F"), 18860.4, 17723.9, 270.000, FourCC("h00F"))
u = BlzCreateUnitWithSkin(p, FourCC("h00F"), 18992.8, 17723.9, 270.000, FourCC("h00F"))
u = BlzCreateUnitWithSkin(p, FourCC("h00F"), 18864.7, 17609.2, 270.000, FourCC("h00F"))
u = BlzCreateUnitWithSkin(p, FourCC("h00F"), 19010.2, 17611.3, 270.000, FourCC("h00F"))
u = BlzCreateUnitWithSkin(p, FourCC("h00G"), 18882.1, 17341.4, 270.000, FourCC("h00G"))
u = BlzCreateUnitWithSkin(p, FourCC("h00G"), 18997.2, 17330.7, 270.000, FourCC("h00G"))
u = BlzCreateUnitWithSkin(p, FourCC("h00G"), 18864.7, 17224.5, 270.000, FourCC("h00G"))
u = BlzCreateUnitWithSkin(p, FourCC("h00G"), 19010.2, 17222.3, 270.000, FourCC("h00G"))
u = BlzCreateUnitWithSkin(p, FourCC("h00J"), 18628.2, 18085.3, 270.000, FourCC("h00J"))
u = BlzCreateUnitWithSkin(p, FourCC("h00J"), 18513.1, 18081.0, 270.000, FourCC("h00J"))
u = BlzCreateUnitWithSkin(p, FourCC("h00J"), 18521.8, 17970.5, 270.000, FourCC("h00J"))
u = BlzCreateUnitWithSkin(p, FourCC("h00J"), 18636.8, 17972.6, 270.000, FourCC("h00J"))
u = BlzCreateUnitWithSkin(p, FourCC("h00K"), 18510.9, 17717.6, 270.000, FourCC("h00K"))
u = BlzCreateUnitWithSkin(p, FourCC("h00K"), 18628.2, 17730.3, 270.000, FourCC("h00K"))
u = BlzCreateUnitWithSkin(p, FourCC("h00K"), 18524.0, 17598.5, 270.000, FourCC("h00K"))
u = BlzCreateUnitWithSkin(p, FourCC("h00K"), 18641.2, 17604.9, 270.000, FourCC("h00K"))
u = BlzCreateUnitWithSkin(p, FourCC("h00L"), 18517.5, 17361.4, 270.000, FourCC("h00L"))
u = BlzCreateUnitWithSkin(p, FourCC("h00L"), 18641.2, 17357.1, 270.000, FourCC("h00L"))
u = BlzCreateUnitWithSkin(p, FourCC("h00L"), 18508.8, 17246.6, 270.000, FourCC("h00L"))
u = BlzCreateUnitWithSkin(p, FourCC("h00L"), 18639.0, 17242.4, 270.000, FourCC("h00L"))
u = BlzCreateUnitWithSkin(p, FourCC("h008"), 18230.9, 18107.4, 270.000, FourCC("h008"))
u = BlzCreateUnitWithSkin(p, FourCC("h008"), 18135.4, 18092.5, 270.000, FourCC("h008"))
u = BlzCreateUnitWithSkin(p, FourCC("h008"), 18115.9, 17969.3, 270.000, FourCC("h008"))
u = BlzCreateUnitWithSkin(p, FourCC("h008"), 18246.1, 17977.8, 270.000, FourCC("h008"))
u = BlzCreateUnitWithSkin(p, FourCC("h00H"), 18118.1, 17733.3, 270.000, FourCC("h00H"))
u = BlzCreateUnitWithSkin(p, FourCC("h00H"), 18244.0, 17735.5, 270.000, FourCC("h00H"))
u = BlzCreateUnitWithSkin(p, FourCC("h00H"), 18246.1, 17593.1, 270.000, FourCC("h00H"))
u = BlzCreateUnitWithSkin(p, FourCC("h00H"), 18122.4, 17586.7, 270.000, FourCC("h00H"))
u = BlzCreateUnitWithSkin(p, FourCC("h00I"), 18241.8, 17342.3, 270.000, FourCC("h00I"))
u = BlzCreateUnitWithSkin(p, FourCC("h00I"), 18109.4, 17338.0, 270.000, FourCC("h00I"))
u = BlzCreateUnitWithSkin(p, FourCC("h00I"), 18118.1, 17227.5, 270.000, FourCC("h00I"))
u = BlzCreateUnitWithSkin(p, FourCC("h00I"), 18259.2, 17221.1, 270.000, FourCC("h00I"))
u = BlzCreateUnitWithSkin(p, FourCC("h00E"), 17864.1, 18115.9, 270.000, FourCC("h00E"))
u = BlzCreateUnitWithSkin(p, FourCC("h00E"), 17738.2, 18109.6, 270.000, FourCC("h00E"))
u = BlzCreateUnitWithSkin(p, FourCC("h00E"), 17727.4, 17994.8, 270.000, FourCC("h00E"))
u = BlzCreateUnitWithSkin(p, FourCC("h00E"), 17857.6, 17986.3, 270.000, FourCC("h00E"))
u = BlzCreateUnitWithSkin(p, FourCC("N001"), 17856.7, 17728.0, 270.000, FourCC("N001"))
u = BlzCreateUnitWithSkin(p, FourCC("N002"), 17847.8, 17339.0, 270.000, FourCC("N002"))
u = BlzCreateUnitWithSkin(p, FourCC("N007"), 17722.9, 17603.8, 270.000, FourCC("N007"))
u = BlzCreateUnitWithSkin(p, FourCC("O000"), 17876.1, 17588.8, 270.000, FourCC("O000"))
u = BlzCreateUnitWithSkin(p, FourCC("N008"), 17732.5, 17734.3, 270.000, FourCC("N008"))
u = BlzCreateUnitWithSkin(p, FourCC("N004"), 17717.3, 17353.5, 270.000, FourCC("N004"))
u = BlzCreateUnitWithSkin(p, FourCC("N00A"), 17602.3, 17743.4, 270.000, FourCC("N00A"))
u = BlzCreateUnitWithSkin(p, FourCC("N009"), 17850.7, 17224.3, 270.000, FourCC("N009"))
u = BlzCreateUnitWithSkin(p, FourCC("H00M"), 17466.4, 18368.6, 270.000, FourCC("H00M"))
u = BlzCreateUnitWithSkin(p, FourCC("n016"), 16250.7, 17726.4, 270.000, FourCC("n016"))
u = BlzCreateUnitWithSkin(p, FourCC("n017"), 16245.9, 18006.9, 270.000, FourCC("n017"))
u = BlzCreateUnitWithSkin(p, FourCC("n015"), 16251.4, 17864.4, 270.000, FourCC("n015"))
u = BlzCreateUnitWithSkin(p, FourCC("h00P"), 16702.6, 17714.8, 270.000, FourCC("h00P"))
u = BlzCreateUnitWithSkin(p, FourCC("h00Q"), 16701.4, 17844.4, 270.000, FourCC("h00Q"))
u = BlzCreateUnitWithSkin(p, FourCC("h00R"), 16698.9, 17996.9, 270.000, FourCC("h00R"))
u = BlzCreateUnitWithSkin(p, FourCC("n018"), 16899.5, 17723.8, 270.000, FourCC("n018"))
u = BlzCreateUnitWithSkin(p, FourCC("n019"), 16898.7, 17861.0, 270.000, FourCC("n019"))
u = BlzCreateUnitWithSkin(p, FourCC("h000"), 17088.1, 17848.5, 270.000, FourCC("h000"))
life = GetUnitState(u, UNIT_STATE_LIFE)
SetUnitState(u, UNIT_STATE_LIFE, 0.80 * life)
u = BlzCreateUnitWithSkin(p, FourCC("h000"), 17209.7, 17852.9, 270.000, FourCC("h000"))
life = GetUnitState(u, UNIT_STATE_LIFE)
SetUnitState(u, UNIT_STATE_LIFE, 0.80 * life)
u = BlzCreateUnitWithSkin(p, FourCC("h000"), 17202.3, 17980.6, 270.000, FourCC("h000"))
life = GetUnitState(u, UNIT_STATE_LIFE)
SetUnitState(u, UNIT_STATE_LIFE, 0.80 * life)
u = BlzCreateUnitWithSkin(p, FourCC("h000"), 17079.2, 17976.3, 270.000, FourCC("h000"))
life = GetUnitState(u, UNIT_STATE_LIFE)
SetUnitState(u, UNIT_STATE_LIFE, 0.80 * life)
u = BlzCreateUnitWithSkin(p, FourCC("h000"), 17148.9, 17912.4, 270.000, FourCC("h000"))
life = GetUnitState(u, UNIT_STATE_LIFE)
SetUnitState(u, UNIT_STATE_LIFE, 0.80 * life)
u = BlzCreateUnitWithSkin(p, FourCC("n00F"), 16642.6, 17165.8, 270.000, FourCC("n00F"))
u = BlzCreateUnitWithSkin(p, FourCC("n00C"), 16382.9, 17155.2, 270.000, FourCC("n00C"))
u = BlzCreateUnitWithSkin(p, FourCC("n00J"), 16125.1, 17148.9, 270.000, FourCC("n00J"))
u = BlzCreateUnitWithSkin(p, FourCC("n00N"), 15870.9, 17153.1, 270.000, FourCC("n00N"))
u = BlzCreateUnitWithSkin(p, FourCC("n00Q"), 15621.3, 17153.1, 270.000, FourCC("n00Q"))
u = BlzCreateUnitWithSkin(p, FourCC("n00T"), 15369.7, 17148.9, 270.000, FourCC("n00T"))
u = BlzCreateUnitWithSkin(p, FourCC("n01A"), 16887.6, 17975.1, 270.000, FourCC("n01A"))
u = BlzCreateUnitWithSkin(p, FourCC("H00N"), 17596.7, 17603.8, 270.000, FourCC("H00N"))
u = BlzCreateUnitWithSkin(p, FourCC("H00O"), 17730.4, 17208.9, 270.000, FourCC("H00O"))
u = BlzCreateUnitWithSkin(p, FourCC("O001"), 17607.6, 17208.9, 270.000, FourCC("O001"))
u = BlzCreateUnitWithSkin(p, FourCC("E000"), 17597.5, 17332.8, 270.000, FourCC("E000"))
u = BlzCreateUnitWithSkin(p, FourCC("e001"), 16066.9, 17728.7, 270.000, FourCC("e001"))
u = BlzCreateUnitWithSkin(p, FourCC("e003"), 16064.8, 17978.9, 270.000, FourCC("e003"))
u = BlzCreateUnitWithSkin(p, FourCC("e002"), 16062.9, 17849.8, 270.000, FourCC("e002"))
u = BlzCreateUnitWithSkin(p, FourCC("h00S"), 17729.8, 18374.5, 270.000, FourCC("h00S"))
u = BlzCreateUnitWithSkin(p, FourCC("n010"), 16432.9, 17731.0, 270.000, FourCC("n010"))
u = BlzCreateUnitWithSkin(p, FourCC("n011"), 16436.9, 17849.8, 270.000, FourCC("n011"))
u = BlzCreateUnitWithSkin(p, FourCC("n012"), 16428.9, 17973.8, 270.000, FourCC("n012"))
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
CreateUnitsForPlayer1()
end

function CreateAllUnits()
CreateNeutralPassiveBuildings()
CreatePlayerBuildings()
CreateNeutralPassive()
CreatePlayerUnits()
end

function CreateRegions()
local we

gg_rct_Center = Rect(-128.0, 2944.0, 128.0, 3200.0)
gg_rct_CenterBottom = Rect(-128.0, -7232.0, 128.0, -6976.0)
gg_rct_CenterBottomComplete = Rect(-384.0, -7488.0, 384.0, -6720.0)
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
gg_rct_HumanCreepToElf = Rect(-7104.0, 5952.0, -6976.0, 6080.0)
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
gg_rct_OrcToElfInnerLine = Rect(8640.0, 11712.0, 8768.0, 11840.0)
gg_rct_OrcToElfOuterLine = Rect(5056.0, 8128.0, 5184.0, 8256.0)
gg_rct_OrcToHumanInnerLine = Rect(8128.0, 13248.0, 8256.0, 13376.0)
gg_rct_OrcToHumanOuterLine = Rect(4032.0, 13248.0, 4160.0, 13376.0)
gg_rct_OrcToUndeadInnerLine = Rect(10176.0, 11200.0, 10304.0, 11328.0)
gg_rct_OrcToUndeadOuterLine = Rect(10176.0, 7104.0, 10304.0, 7232.0)
gg_rct_TestArea = Rect(17280.0, 17280.0, 17408.0, 17408.0)
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
SetWaterBaseColor(255, 0, 0, 255)
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

