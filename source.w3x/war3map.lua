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
gg_trg_Melee_Initialization = nil
gg_rct_TestArea = nil
function InitGlobals()
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
u = BlzCreateUnitWithSkin(p, FourCC("h009"), -10240.0, 14080.0, 270.000, FourCC("h009"))
u = BlzCreateUnitWithSkin(p, FourCC("h005"), -10752.0, 12800.0, 270.000, FourCC("h005"))
u = BlzCreateUnitWithSkin(p, FourCC("h005"), -9728.0, 13824.0, 270.000, FourCC("h005"))
u = BlzCreateUnitWithSkin(p, FourCC("h005"), -9024.0, 11456.0, 270.000, FourCC("h005"))
u = BlzCreateUnitWithSkin(p, FourCC("h005"), -8384.0, 12096.0, 270.000, FourCC("h005"))
u = BlzCreateUnitWithSkin(p, FourCC("h005"), -7680.0, 10752.0, 270.000, FourCC("h005"))
u = BlzCreateUnitWithSkin(p, FourCC("h004"), -9728.0, 7168.0, 270.000, FourCC("h004"))
u = BlzCreateUnitWithSkin(p, FourCC("h004"), -10752.0, 7168.0, 270.000, FourCC("h004"))
u = BlzCreateUnitWithSkin(p, FourCC("h004"), -10240.0, 5888.0, 270.000, FourCC("h004"))
u = BlzCreateUnitWithSkin(p, FourCC("h004"), -5440.0, 7872.0, 270.000, FourCC("h004"))
u = BlzCreateUnitWithSkin(p, FourCC("h004"), -4800.0, 8512.0, 270.000, FourCC("h004"))
u = BlzCreateUnitWithSkin(p, FourCC("h004"), -4096.0, 7168.0, 270.000, FourCC("h004"))
u = BlzCreateUnitWithSkin(p, FourCC("h009"), 17408.0, 16768.0, 270.000, FourCC("h009"))
end

function CreateUnitsForPlayer0()
local p = Player(0)
local u
local unitID
local t
local life

u = BlzCreateUnitWithSkin(p, FourCC("h000"), 16826.8, 16836.8, 102.396, FourCC("h000"))
life = GetUnitState(u, UNIT_STATE_LIFE)
SetUnitState(u, UNIT_STATE_LIFE, 0.20 * life)
u = BlzCreateUnitWithSkin(p, FourCC("h000"), 16713.2, 16835.8, 30.884, FourCC("h000"))
life = GetUnitState(u, UNIT_STATE_LIFE)
SetUnitState(u, UNIT_STATE_LIFE, 0.20 * life)
u = BlzCreateUnitWithSkin(p, FourCC("h000"), 16702.1, 16711.4, 218.810, FourCC("h000"))
life = GetUnitState(u, UNIT_STATE_LIFE)
SetUnitState(u, UNIT_STATE_LIFE, 0.20 * life)
u = BlzCreateUnitWithSkin(p, FourCC("h000"), 16824.6, 16704.9, 215.822, FourCC("h000"))
life = GetUnitState(u, UNIT_STATE_LIFE)
SetUnitState(u, UNIT_STATE_LIFE, 0.20 * life)
u = BlzCreateUnitWithSkin(p, FourCC("h000"), 16447.0, 16826.3, 280.643, FourCC("h000"))
life = GetUnitState(u, UNIT_STATE_LIFE)
SetUnitState(u, UNIT_STATE_LIFE, 0.40 * life)
u = BlzCreateUnitWithSkin(p, FourCC("h000"), 16330.0, 16831.8, 350.343, FourCC("h000"))
life = GetUnitState(u, UNIT_STATE_LIFE)
SetUnitState(u, UNIT_STATE_LIFE, 0.40 * life)
u = BlzCreateUnitWithSkin(p, FourCC("h000"), 16325.6, 16705.3, 78.456, FourCC("h000"))
life = GetUnitState(u, UNIT_STATE_LIFE)
SetUnitState(u, UNIT_STATE_LIFE, 0.40 * life)
u = BlzCreateUnitWithSkin(p, FourCC("h000"), 16450.3, 16707.5, 314.471, FourCC("h000"))
life = GetUnitState(u, UNIT_STATE_LIFE)
SetUnitState(u, UNIT_STATE_LIFE, 0.40 * life)
u = BlzCreateUnitWithSkin(p, FourCC("h000"), 16385.7, 16764.2, 142.541, FourCC("h000"))
life = GetUnitState(u, UNIT_STATE_LIFE)
SetUnitState(u, UNIT_STATE_LIFE, 0.40 * life)
u = BlzCreateUnitWithSkin(p, FourCC("h000"), 16765.6, 16770.7, 163.536, FourCC("h000"))
life = GetUnitState(u, UNIT_STATE_LIFE)
SetUnitState(u, UNIT_STATE_LIFE, 0.20 * life)
u = BlzCreateUnitWithSkin(p, FourCC("h000"), 16701.0, 17082.0, 59.361, FourCC("h000"))
life = GetUnitState(u, UNIT_STATE_LIFE)
SetUnitState(u, UNIT_STATE_LIFE, 0.80 * life)
u = BlzCreateUnitWithSkin(p, FourCC("h000"), 16822.6, 17086.4, 279.061, FourCC("h000"))
life = GetUnitState(u, UNIT_STATE_LIFE)
SetUnitState(u, UNIT_STATE_LIFE, 0.80 * life)
u = BlzCreateUnitWithSkin(p, FourCC("h000"), 16815.1, 17214.1, 130.280, FourCC("h000"))
life = GetUnitState(u, UNIT_STATE_LIFE)
SetUnitState(u, UNIT_STATE_LIFE, 0.80 * life)
u = BlzCreateUnitWithSkin(p, FourCC("h000"), 16692.1, 17209.8, 26.621, FourCC("h000"))
life = GetUnitState(u, UNIT_STATE_LIFE)
SetUnitState(u, UNIT_STATE_LIFE, 0.80 * life)
u = BlzCreateUnitWithSkin(p, FourCC("h000"), 16761.8, 17145.9, 213.680, FourCC("h000"))
life = GetUnitState(u, UNIT_STATE_LIFE)
SetUnitState(u, UNIT_STATE_LIFE, 0.80 * life)
u = BlzCreateUnitWithSkin(p, FourCC("h000"), 16449.0, 17086.4, 126.292, FourCC("h000"))
u = BlzCreateUnitWithSkin(p, FourCC("h000"), 16330.4, 17086.4, 24.478, FourCC("h000"))
u = BlzCreateUnitWithSkin(p, FourCC("h000"), 16382.3, 17156.1, 266.602, FourCC("h000"))
u = BlzCreateUnitWithSkin(p, FourCC("h000"), 16318.5, 17219.9, 117.601, FourCC("h000"))
u = BlzCreateUnitWithSkin(p, FourCC("h000"), 16451.9, 17215.6, 271.404, FourCC("h000"))
end

function CreateBuildingsForPlayer1()
local p = Player(1)
local u
local unitID
local t
local life

u = BlzCreateUnitWithSkin(p, FourCC("h00D"), -6656.0, 11776.0, 270.000, FourCC("h00D"))
u = BlzCreateUnitWithSkin(p, FourCC("h00A"), -8704.0, 9728.0, 270.000, FourCC("h00A"))
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

u = BlzCreateUnitWithSkin(p, FourCC("h00A"), -8704.0, 9216.0, 270.000, FourCC("h00A"))
u = BlzCreateUnitWithSkin(p, FourCC("h00D"), -6144.0, 11776.0, 270.000, FourCC("h00D"))
end

function CreateBuildingsForPlayer3()
local p = Player(3)
local u
local unitID
local t
local life

u = BlzCreateUnitWithSkin(p, FourCC("h00A"), -8704.0, 8704.0, 270.000, FourCC("h00A"))
u = BlzCreateUnitWithSkin(p, FourCC("h00D"), -5632.0, 11776.0, 270.000, FourCC("h00D"))
end

function CreateBuildingsForPlayer4()
local p = Player(4)
local u
local unitID
local t
local life

u = BlzCreateUnitWithSkin(p, FourCC("h004"), 4096.0, 12800.0, 270.000, FourCC("h004"))
u = BlzCreateUnitWithSkin(p, FourCC("h005"), 8192.0, 13824.0, 270.000, FourCC("h005"))
u = BlzCreateUnitWithSkin(p, FourCC("h005"), 8192.0, 12800.0, 270.000, FourCC("h005"))
u = BlzCreateUnitWithSkin(p, FourCC("h005"), 9728.0, 11264.0, 270.000, FourCC("h005"))
u = BlzCreateUnitWithSkin(p, FourCC("h005"), 10752.0, 11264.0, 270.000, FourCC("h005"))
u = BlzCreateUnitWithSkin(p, FourCC("h005"), 6912.0, 13312.0, 270.000, FourCC("h005"))
u = BlzCreateUnitWithSkin(p, FourCC("h005"), 10240.0, 9984.0, 270.000, FourCC("h005"))
u = BlzCreateUnitWithSkin(p, FourCC("h004"), 4096.0, 13824.0, 270.000, FourCC("h004"))
u = BlzCreateUnitWithSkin(p, FourCC("h004"), 2816.0, 13312.0, 270.000, FourCC("h004"))
u = BlzCreateUnitWithSkin(p, FourCC("h004"), 9728.0, 7168.0, 270.000, FourCC("h004"))
u = BlzCreateUnitWithSkin(p, FourCC("h004"), 10752.0, 7168.0, 270.000, FourCC("h004"))
u = BlzCreateUnitWithSkin(p, FourCC("h004"), 10240.0, 5888.0, 270.000, FourCC("h004"))
u = BlzCreateUnitWithSkin(p, FourCC("h009"), 10752.0, 13312.0, 270.000, FourCC("h009"))
u = BlzCreateUnitWithSkin(p, FourCC("h005"), 9728.0, 13824.0, 270.000, FourCC("h005"))
u = BlzCreateUnitWithSkin(p, FourCC("h005"), 10752.0, 12800.0, 270.000, FourCC("h005"))
u = BlzCreateUnitWithSkin(p, FourCC("h005"), 9024.0, 11456.0, 270.000, FourCC("h005"))
u = BlzCreateUnitWithSkin(p, FourCC("h005"), 8384.0, 12096.0, 270.000, FourCC("h005"))
u = BlzCreateUnitWithSkin(p, FourCC("h005"), 7680.0, 10752.0, 270.000, FourCC("h005"))
u = BlzCreateUnitWithSkin(p, FourCC("h004"), 4800.0, 8512.0, 270.000, FourCC("h004"))
u = BlzCreateUnitWithSkin(p, FourCC("h004"), 5440.0, 7872.0, 270.000, FourCC("h004"))
u = BlzCreateUnitWithSkin(p, FourCC("h004"), 4096.0, 7168.0, 270.000, FourCC("h004"))
end

function CreateBuildingsForPlayer5()
local p = Player(5)
local u
local unitID
local t
local life

u = BlzCreateUnitWithSkin(p, FourCC("h00D"), 5632.0, 11776.0, 270.000, FourCC("h00D"))
u = BlzCreateUnitWithSkin(p, FourCC("h00A"), 8704.0, 9728.0, 270.000, FourCC("h00A"))
end

function CreateBuildingsForPlayer6()
local p = Player(6)
local u
local unitID
local t
local life

u = BlzCreateUnitWithSkin(p, FourCC("h00D"), 6144.0, 11776.0, 270.000, FourCC("h00D"))
u = BlzCreateUnitWithSkin(p, FourCC("h00A"), 8704.0, 9216.0, 270.000, FourCC("h00A"))
end

function CreateBuildingsForPlayer7()
local p = Player(7)
local u
local unitID
local t
local life

u = BlzCreateUnitWithSkin(p, FourCC("h00D"), 6656.0, 11776.0, 270.000, FourCC("h00D"))
u = BlzCreateUnitWithSkin(p, FourCC("h00A"), 8704.0, 8704.0, 270.000, FourCC("h00A"))
end

function CreateBuildingsForPlayer8()
local p = Player(8)
local u
local unitID
local t
local life

u = BlzCreateUnitWithSkin(p, FourCC("h005"), -9728.0, -7680.0, 270.000, FourCC("h005"))
u = BlzCreateUnitWithSkin(p, FourCC("h005"), -10752.0, -6656.0, 270.000, FourCC("h005"))
u = BlzCreateUnitWithSkin(p, FourCC("h005"), -8192.0, -6656.0, 270.000, FourCC("h005"))
u = BlzCreateUnitWithSkin(p, FourCC("h005"), -8192.0, -7680.0, 270.000, FourCC("h005"))
u = BlzCreateUnitWithSkin(p, FourCC("h005"), -9024.0, -5312.0, 270.000, FourCC("h005"))
u = BlzCreateUnitWithSkin(p, FourCC("h005"), -8384.0, -5952.0, 270.000, FourCC("h005"))
u = BlzCreateUnitWithSkin(p, FourCC("h005"), -10752.0, -5120.0, 270.000, FourCC("h005"))
u = BlzCreateUnitWithSkin(p, FourCC("h005"), -9728.0, -5120.0, 270.000, FourCC("h005"))
u = BlzCreateUnitWithSkin(p, FourCC("h005"), -10240.0, -3840.0, 270.000, FourCC("h005"))
u = BlzCreateUnitWithSkin(p, FourCC("h005"), -6912.0, -7168.0, 270.000, FourCC("h005"))
u = BlzCreateUnitWithSkin(p, FourCC("h005"), -7680.0, -4608.0, 270.000, FourCC("h005"))
u = BlzCreateUnitWithSkin(p, FourCC("h004"), -10752.0, -1024.0, 270.000, FourCC("h004"))
u = BlzCreateUnitWithSkin(p, FourCC("h004"), -9728.0, -1024.0, 270.000, FourCC("h004"))
u = BlzCreateUnitWithSkin(p, FourCC("h004"), -10240.0, 256.0, 270.000, FourCC("h004"))
u = BlzCreateUnitWithSkin(p, FourCC("h004"), -4096.0, -6656.0, 270.000, FourCC("h004"))
u = BlzCreateUnitWithSkin(p, FourCC("h004"), -4096.0, -7680.0, 270.000, FourCC("h004"))
u = BlzCreateUnitWithSkin(p, FourCC("h004"), -2816.0, -7168.0, 270.000, FourCC("h004"))
u = BlzCreateUnitWithSkin(p, FourCC("h004"), -4800.0, -2368.0, 270.000, FourCC("h004"))
u = BlzCreateUnitWithSkin(p, FourCC("h004"), -5440.0, -1728.0, 270.000, FourCC("h004"))
u = BlzCreateUnitWithSkin(p, FourCC("h004"), -4096.0, -1024.0, 270.000, FourCC("h004"))
u = BlzCreateUnitWithSkin(p, FourCC("h009"), -11008.0, -7168.0, 270.000, FourCC("h009"))
end

function CreateBuildingsForPlayer9()
local p = Player(9)
local u
local unitID
local t
local life

u = BlzCreateUnitWithSkin(p, FourCC("h00A"), -8704.0, -2560.0, 270.000, FourCC("h00A"))
u = BlzCreateUnitWithSkin(p, FourCC("h00D"), -6592.0, -5568.0, 270.000, FourCC("h00D"))
end

function CreateBuildingsForPlayer10()
local p = Player(10)
local u
local unitID
local t
local life

u = BlzCreateUnitWithSkin(p, FourCC("h00A"), -8704.0, -3072.0, 270.000, FourCC("h00A"))
u = BlzCreateUnitWithSkin(p, FourCC("h00D"), -6080.0, -5568.0, 270.000, FourCC("h00D"))
end

function CreateBuildingsForPlayer11()
local p = Player(11)
local u
local unitID
local t
local life

u = BlzCreateUnitWithSkin(p, FourCC("h00A"), -8704.0, -3584.0, 270.000, FourCC("h00A"))
u = BlzCreateUnitWithSkin(p, FourCC("h00D"), -5568.0, -5568.0, 270.000, FourCC("h00D"))
end

function CreateBuildingsForPlayer12()
local p = Player(12)
local u
local unitID
local t
local life

u = BlzCreateUnitWithSkin(p, FourCC("h005"), 8192.0, -7680.0, 270.000, FourCC("h005"))
u = BlzCreateUnitWithSkin(p, FourCC("h005"), 9728.0, -7680.0, 270.000, FourCC("h005"))
u = BlzCreateUnitWithSkin(p, FourCC("h005"), 8192.0, -6656.0, 270.000, FourCC("h005"))
u = BlzCreateUnitWithSkin(p, FourCC("h005"), 8384.0, -5952.0, 270.000, FourCC("h005"))
u = BlzCreateUnitWithSkin(p, FourCC("h005"), 9024.0, -5312.0, 270.000, FourCC("h005"))
u = BlzCreateUnitWithSkin(p, FourCC("h005"), 9728.0, -5120.0, 270.000, FourCC("h005"))
u = BlzCreateUnitWithSkin(p, FourCC("h005"), 10752.0, -5120.0, 270.000, FourCC("h005"))
u = BlzCreateUnitWithSkin(p, FourCC("h005"), 6912.0, -7168.0, 270.000, FourCC("h005"))
u = BlzCreateUnitWithSkin(p, FourCC("h005"), 7680.0, -4608.0, 270.000, FourCC("h005"))
u = BlzCreateUnitWithSkin(p, FourCC("h004"), 4096.0, -6656.0, 270.000, FourCC("h004"))
u = BlzCreateUnitWithSkin(p, FourCC("h004"), 4096.0, -7680.0, 270.000, FourCC("h004"))
u = BlzCreateUnitWithSkin(p, FourCC("h004"), 2816.0, -7168.0, 270.000, FourCC("h004"))
u = BlzCreateUnitWithSkin(p, FourCC("h004"), 9728.0, -1024.0, 270.000, FourCC("h004"))
u = BlzCreateUnitWithSkin(p, FourCC("h004"), 10752.0, -1024.0, 270.000, FourCC("h004"))
u = BlzCreateUnitWithSkin(p, FourCC("h004"), 10240.0, 256.0, 270.000, FourCC("h004"))
u = BlzCreateUnitWithSkin(p, FourCC("h005"), 10240.0, -3840.0, 270.000, FourCC("h005"))
u = BlzCreateUnitWithSkin(p, FourCC("h004"), 5440.0, -1728.0, 270.000, FourCC("h004"))
u = BlzCreateUnitWithSkin(p, FourCC("h004"), 4800.0, -2368.0, 270.000, FourCC("h004"))
u = BlzCreateUnitWithSkin(p, FourCC("h004"), 4096.0, -1024.0, 270.000, FourCC("h004"))
u = BlzCreateUnitWithSkin(p, FourCC("h009"), 10240.0, -7680.0, 270.000, FourCC("h009"))
u = BlzCreateUnitWithSkin(p, FourCC("h005"), 10752.0, -6656.0, 270.000, FourCC("h005"))
end

function CreateBuildingsForPlayer13()
local p = Player(13)
local u
local unitID
local t
local life

u = BlzCreateUnitWithSkin(p, FourCC("h00A"), 8704.0, -2560.0, 270.000, FourCC("h00A"))
u = BlzCreateUnitWithSkin(p, FourCC("h00D"), 5568.0, -5632.0, 270.000, FourCC("h00D"))
end

function CreateBuildingsForPlayer14()
local p = Player(14)
local u
local unitID
local t
local life

u = BlzCreateUnitWithSkin(p, FourCC("h00A"), 8704.0, -3072.0, 270.000, FourCC("h00A"))
u = BlzCreateUnitWithSkin(p, FourCC("h00D"), 6080.0, -5632.0, 270.000, FourCC("h00D"))
end

function CreateBuildingsForPlayer15()
local p = Player(15)
local u
local unitID
local t
local life

u = BlzCreateUnitWithSkin(p, FourCC("h00A"), 8704.0, -3584.0, 270.000, FourCC("h00A"))
u = BlzCreateUnitWithSkin(p, FourCC("h00D"), 6592.0, -5632.0, 270.000, FourCC("h00D"))
end

function CreateNeutralPassiveBuildings()
local p = Player(PLAYER_NEUTRAL_PASSIVE)
local u
local unitID
local t
local life

u = BlzCreateUnitWithSkin(p, FourCC("n003"), -18432.0, 18560.0, 270.000, FourCC("n003"))
SetUnitColor(u, ConvertPlayerColor(0))
u = BlzCreateUnitWithSkin(p, FourCC("n005"), -11264.0, 14336.0, 270.000, FourCC("n005"))
u = BlzCreateUnitWithSkin(p, FourCC("h003"), 17152.0, 18688.0, 270.000, FourCC("h003"))
u = BlzCreateUnitWithSkin(p, FourCC("h007"), 16576.0, 18688.0, 270.000, FourCC("h007"))
u = BlzCreateUnitWithSkin(p, FourCC("h004"), 15616.0, 18688.0, 270.000, FourCC("h004"))
u = BlzCreateUnitWithSkin(p, FourCC("h005"), 16128.0, 18688.0, 270.000, FourCC("h005"))
u = BlzCreateUnitWithSkin(p, FourCC("h009"), 15104.0, 18688.0, 270.000, FourCC("h009"))
u = BlzCreateUnitWithSkin(p, FourCC("n005"), 11264.0, 14336.0, 270.000, FourCC("n005"))
u = BlzCreateUnitWithSkin(p, FourCC("n005"), -11264.0, -8192.0, 270.000, FourCC("n005"))
u = BlzCreateUnitWithSkin(p, FourCC("n005"), 11264.0, -8192.0, 270.000, FourCC("n005"))
u = BlzCreateUnitWithSkin(p, FourCC("h00D"), 14592.0, 18688.0, 270.000, FourCC("h00D"))
u = BlzCreateUnitWithSkin(p, FourCC("h00A"), 14080.0, 18688.0, 270.000, FourCC("h00A"))
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
u = BlzCreateUnitWithSkin(p, FourCC("N007"), 17718.8, 17736.7, 270.000, FourCC("N007"))
u = BlzCreateUnitWithSkin(p, FourCC("N006"), 17862.6, 17595.9, 270.000, FourCC("N006"))
u = BlzCreateUnitWithSkin(p, FourCC("N008"), 17715.8, 17597.4, 270.000, FourCC("N008"))
u = BlzCreateUnitWithSkin(p, FourCC("N004"), 17717.3, 17353.5, 270.000, FourCC("N004"))
u = BlzCreateUnitWithSkin(p, FourCC("N00A"), 17591.3, 17616.2, 270.000, FourCC("N00A"))
u = BlzCreateUnitWithSkin(p, FourCC("N009"), 17850.7, 17224.3, 270.000, FourCC("N009"))
u = BlzCreateUnitWithSkin(p, FourCC("H00M"), 17723.1, 18366.2, 270.000, FourCC("H00M"))
u = BlzCreateUnitWithSkin(p, FourCC("h000"), 17214.0, 17603.3, 102.396, FourCC("h000"))
life = GetUnitState(u, UNIT_STATE_LIFE)
SetUnitState(u, UNIT_STATE_LIFE, 0.20 * life)
u = BlzCreateUnitWithSkin(p, FourCC("h000"), 17100.4, 17602.2, 30.884, FourCC("h000"))
life = GetUnitState(u, UNIT_STATE_LIFE)
SetUnitState(u, UNIT_STATE_LIFE, 0.20 * life)
u = BlzCreateUnitWithSkin(p, FourCC("h000"), 17089.2, 17477.9, 218.810, FourCC("h000"))
life = GetUnitState(u, UNIT_STATE_LIFE)
SetUnitState(u, UNIT_STATE_LIFE, 0.20 * life)
u = BlzCreateUnitWithSkin(p, FourCC("h000"), 17211.7, 17471.4, 215.822, FourCC("h000"))
life = GetUnitState(u, UNIT_STATE_LIFE)
SetUnitState(u, UNIT_STATE_LIFE, 0.20 * life)
u = BlzCreateUnitWithSkin(p, FourCC("h000"), 16834.1, 17592.8, 280.643, FourCC("h000"))
life = GetUnitState(u, UNIT_STATE_LIFE)
SetUnitState(u, UNIT_STATE_LIFE, 0.40 * life)
u = BlzCreateUnitWithSkin(p, FourCC("h000"), 16717.2, 17598.3, 350.343, FourCC("h000"))
life = GetUnitState(u, UNIT_STATE_LIFE)
SetUnitState(u, UNIT_STATE_LIFE, 0.40 * life)
u = BlzCreateUnitWithSkin(p, FourCC("h000"), 16712.7, 17471.8, 78.456, FourCC("h000"))
life = GetUnitState(u, UNIT_STATE_LIFE)
SetUnitState(u, UNIT_STATE_LIFE, 0.40 * life)
u = BlzCreateUnitWithSkin(p, FourCC("h000"), 16837.5, 17474.0, 314.471, FourCC("h000"))
life = GetUnitState(u, UNIT_STATE_LIFE)
SetUnitState(u, UNIT_STATE_LIFE, 0.40 * life)
u = BlzCreateUnitWithSkin(p, FourCC("h000"), 16772.9, 17530.7, 142.541, FourCC("h000"))
life = GetUnitState(u, UNIT_STATE_LIFE)
SetUnitState(u, UNIT_STATE_LIFE, 0.40 * life)
u = BlzCreateUnitWithSkin(p, FourCC("h000"), 17152.7, 17537.2, 163.536, FourCC("h000"))
life = GetUnitState(u, UNIT_STATE_LIFE)
SetUnitState(u, UNIT_STATE_LIFE, 0.20 * life)
u = BlzCreateUnitWithSkin(p, FourCC("h000"), 17088.1, 17848.5, 59.361, FourCC("h000"))
life = GetUnitState(u, UNIT_STATE_LIFE)
SetUnitState(u, UNIT_STATE_LIFE, 0.80 * life)
u = BlzCreateUnitWithSkin(p, FourCC("h000"), 17209.7, 17852.9, 279.061, FourCC("h000"))
life = GetUnitState(u, UNIT_STATE_LIFE)
SetUnitState(u, UNIT_STATE_LIFE, 0.80 * life)
u = BlzCreateUnitWithSkin(p, FourCC("h000"), 17202.3, 17980.6, 130.280, FourCC("h000"))
life = GetUnitState(u, UNIT_STATE_LIFE)
SetUnitState(u, UNIT_STATE_LIFE, 0.80 * life)
u = BlzCreateUnitWithSkin(p, FourCC("h000"), 17079.2, 17976.3, 26.621, FourCC("h000"))
life = GetUnitState(u, UNIT_STATE_LIFE)
SetUnitState(u, UNIT_STATE_LIFE, 0.80 * life)
u = BlzCreateUnitWithSkin(p, FourCC("h000"), 17148.9, 17912.4, 213.680, FourCC("h000"))
life = GetUnitState(u, UNIT_STATE_LIFE)
SetUnitState(u, UNIT_STATE_LIFE, 0.80 * life)
u = BlzCreateUnitWithSkin(p, FourCC("h000"), 16836.1, 17852.9, 126.292, FourCC("h000"))
u = BlzCreateUnitWithSkin(p, FourCC("h000"), 16717.5, 17852.9, 24.478, FourCC("h000"))
u = BlzCreateUnitWithSkin(p, FourCC("h000"), 16769.4, 17922.5, 266.602, FourCC("h000"))
u = BlzCreateUnitWithSkin(p, FourCC("h000"), 16705.7, 17986.4, 117.601, FourCC("h000"))
u = BlzCreateUnitWithSkin(p, FourCC("h000"), 16839.1, 17982.1, 271.404, FourCC("h000"))
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
gg_rct_ElfBarracksToCenter = Rect(-6208.0, -3136.0, -6080.0, -3008.0)
gg_rct_ElfBarracksToCenterSpawn = Rect(-6016.0, -3584.0, -5760.0, -2560.0)
gg_rct_ElfBarracksToHuman = Rect(-10304.0, -1984.0, -10176.0, -1856.0)
gg_rct_ElfBarracksToHumanSpawn = Rect(-10752.0, -1792.0, -9728.0, -1536.0)
gg_rct_ElfBarracksToUndead = Rect(-5056.0, -7232.0, -4928.0, -7104.0)
gg_rct_ElfBarracksToUndeadSpawn = Rect(-4864.0, -7680.0, -4608.0, -6656.0)
gg_rct_ElfBase = Rect(-10304.0, -7232.0, -10176.0, -7104.0)
gg_rct_ElfBaseHeroRespawn = Rect(-11136.0, -8064.0, -11008.0, -7936.0)
gg_rct_ElfBaseHeroSpawn = Rect(-10816.0, -7744.0, -10688.0, -7616.0)
gg_rct_ElfBaseToCenterSpawn = Rect(-9984.0, -6912.0, -9728.0, -6656.0)
gg_rct_ElfBaseToHumanSpawn = Rect(-10368.0, -6912.0, -10112.0, -6656.0)
gg_rct_ElfBaseToUndeadSpawn = Rect(-9984.0, -7296.0, -9728.0, -7040.0)
gg_rct_ElfToHumanInnerLine = Rect(-10304.0, -5184.0, -10176.0, -5056.0)
gg_rct_ElfToHumanOuterLine = Rect(-10304.0, -1088.0, -10176.0, -960.0)
gg_rct_ElfToOrcInnerLine = Rect(-8768.0, -5696.0, -8640.0, -5568.0)
gg_rct_ElfToOrcOuterLine = Rect(-5184.0, -2112.0, -5056.0, -1984.0)
gg_rct_ElfToUndeadInnerLine = Rect(-8256.0, -7232.0, -8128.0, -7104.0)
gg_rct_ElfToUndeadOuterLine = Rect(-4160.0, -7232.0, -4032.0, -7104.0)
gg_rct_HeroSelectorSpawn = Rect(-18496.0, 18112.0, -18368.0, 18240.0)
gg_rct_HumanBarracksToCenter = Rect(-6208.0, 9152.0, -6080.0, 9280.0)
gg_rct_HumanBarracksToCenterSpawn = Rect(-6016.0, 8704.0, -5760.0, 9728.0)
gg_rct_HumanBarracksToElf = Rect(-10304.0, 8000.0, -10176.0, 8128.0)
gg_rct_HumanBarracksToElfSpawn = Rect(-10752.0, 7680.0, -9728.0, 7936.0)
gg_rct_HumanBarracksToOrc = Rect(-5056.0, 13248.0, -4928.0, 13376.0)
gg_rct_HumanBarracksToOrcSpawn = Rect(-4864.0, 12800.0, -4608.0, 13824.0)
gg_rct_HumanBase = Rect(-10304.0, 13248.0, -10176.0, 13376.0)
gg_rct_HumanBaseHeroRespawn = Rect(-11136.0, 14080.0, -11008.0, 14208.0)
gg_rct_HumanBaseHeroSpawn = Rect(-10816.0, 13760.0, -10688.0, 13888.0)
gg_rct_HumanBaseToCenterSpawn = Rect(-9984.0, 12800.0, -9728.0, 13056.0)
gg_rct_HumanBaseToElfSpawn = Rect(-10368.0, 12800.0, -10112.0, 13056.0)
gg_rct_HumanBaseToOrcSpawn = Rect(-9984.0, 13184.0, -9728.0, 13440.0)
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
gg_rct_OrcBaseHeroRespawn = Rect(11008.0, 14080.0, 11136.0, 14208.0)
gg_rct_OrcBaseHeroSpawn = Rect(10688.0, 13760.0, 10816.0, 13888.0)
gg_rct_OrcBaseToCenterSpawn = Rect(9728.0, 12800.0, 9984.0, 13056.0)
gg_rct_OrcBaseToHumanSpawn = Rect(9728.0, 13184.0, 9984.0, 13440.0)
gg_rct_OrcBaseToUndeadSpawn = Rect(10112.0, 12800.0, 10368.0, 13056.0)
gg_rct_OrcToElfInnerLine = Rect(8640.0, 11712.0, 8768.0, 11840.0)
gg_rct_OrcToElfOuterLine = Rect(5056.0, 8128.0, 5184.0, 8256.0)
gg_rct_OrcToHumanInnerLine = Rect(8128.0, 13248.0, 8256.0, 13376.0)
gg_rct_OrcToHumanOuterLine = Rect(4032.0, 13248.0, 4160.0, 13376.0)
gg_rct_OrcToUndeadInnerLine = Rect(10176.0, 11200.0, 10304.0, 11328.0)
gg_rct_OrcToUndeadOuterLine = Rect(10176.0, 7104.0, 10304.0, 7232.0)
gg_rct_UndeadBarracksToCenter = Rect(6080.0, -3136.0, 6208.0, -3008.0)
gg_rct_UndeadBarracksToCenterSpawn = Rect(5760.0, -3584.0, 6016.0, -2560.0)
gg_rct_UndeadBarracksToElf = Rect(4928.0, -7232.0, 5056.0, -7104.0)
gg_rct_UndeadBarracksToElfSpawn = Rect(4608.0, -7680.0, 4864.0, -6656.0)
gg_rct_UndeadBarracksToOrc = Rect(10176.0, -1984.0, 10304.0, -1856.0)
gg_rct_UndeadBarracksToOrcSpawn = Rect(9728.0, -1792.0, 10752.0, -1536.0)
gg_rct_UndeadBase = Rect(10176.0, -7232.0, 10304.0, -7104.0)
gg_rct_UndeadBaseHeroRespawn = Rect(11008.0, -8064.0, 11136.0, -7936.0)
gg_rct_UndeadBaseHeroSpawn = Rect(10688.0, -7744.0, 10816.0, -7616.0)
gg_rct_UndeadBaseToCenterSpawn = Rect(9728.0, -6912.0, 9984.0, -6656.0)
gg_rct_UndeadBaseToElfSpawn = Rect(9728.0, -7296.0, 9984.0, -7040.0)
gg_rct_UndeadBaseToOrcSpawn = Rect(10112.0, -6912.0, 10368.0, -6656.0)
gg_rct_UndeadToElfInnerLine = Rect(8128.0, -7232.0, 8256.0, -7104.0)
gg_rct_UndeadToElfOuterLine = Rect(4032.0, -7232.0, 4160.0, -7104.0)
gg_rct_UndeadToHumanInnerLine = Rect(8640.0, -5696.0, 8768.0, -5568.0)
gg_rct_UndeadToHumanOuterLine = Rect(5056.0, -2112.0, 5184.0, -1984.0)
gg_rct_UndeadToOrcInnerLine = Rect(10176.0, -5184.0, 10304.0, -5056.0)
gg_rct_UndeadToOrcOuterLine = Rect(10176.0, -1088.0, 10304.0, -960.0)
gg_rct_TestArea = Rect(17152.0, 17152.0, 17280.0, 17280.0)
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
SetStartLocPrioCount(1, 2)
SetStartLocPrio(1, 0, 2, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(1, 1, 3, MAP_LOC_PRIO_HIGH)
SetStartLocPrioCount(2, 2)
SetStartLocPrio(2, 0, 1, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(2, 1, 3, MAP_LOC_PRIO_HIGH)
SetStartLocPrioCount(3, 2)
SetStartLocPrio(3, 0, 1, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(3, 1, 2, MAP_LOC_PRIO_HIGH)
SetStartLocPrioCount(4, 2)
SetStartLocPrio(4, 0, 5, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(4, 1, 6, MAP_LOC_PRIO_HIGH)
SetStartLocPrioCount(5, 2)
SetStartLocPrio(5, 0, 6, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(5, 1, 7, MAP_LOC_PRIO_HIGH)
SetStartLocPrioCount(6, 2)
SetStartLocPrio(6, 0, 5, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(6, 1, 7, MAP_LOC_PRIO_HIGH)
SetStartLocPrioCount(7, 2)
SetStartLocPrio(7, 0, 5, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(7, 1, 6, MAP_LOC_PRIO_HIGH)
SetStartLocPrioCount(8, 1)
SetStartLocPrio(8, 0, 9, MAP_LOC_PRIO_HIGH)
SetStartLocPrioCount(9, 2)
SetStartLocPrio(9, 0, 10, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(9, 1, 11, MAP_LOC_PRIO_HIGH)
SetStartLocPrioCount(10, 2)
SetStartLocPrio(10, 0, 9, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(10, 1, 11, MAP_LOC_PRIO_HIGH)
SetStartLocPrioCount(11, 2)
SetStartLocPrio(11, 0, 9, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(11, 1, 10, MAP_LOC_PRIO_HIGH)
SetStartLocPrioCount(12, 2)
SetStartLocPrio(12, 0, 13, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(12, 1, 14, MAP_LOC_PRIO_HIGH)
SetStartLocPrioCount(13, 2)
SetStartLocPrio(13, 0, 14, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(13, 1, 15, MAP_LOC_PRIO_HIGH)
SetStartLocPrioCount(14, 2)
SetStartLocPrio(14, 0, 13, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(14, 1, 15, MAP_LOC_PRIO_HIGH)
SetStartLocPrioCount(15, 2)
SetStartLocPrio(15, 0, 13, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(15, 1, 14, MAP_LOC_PRIO_HIGH)
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
end

function config()
SetMapName("TRIGSTR_001")
SetMapDescription("TRIGSTR_003")
SetPlayers(16)
SetTeams(16)
SetGamePlacement(MAP_PLACEMENT_TEAMS_TOGETHER)
DefineStartLocation(0, -10240.0, 13312.0)
DefineStartLocation(1, -10752.0, 13824.0)
DefineStartLocation(2, -10752.0, 13824.0)
DefineStartLocation(3, -10752.0, 13824.0)
DefineStartLocation(4, 10240.0, 13312.0)
DefineStartLocation(5, 10752.0, 13824.0)
DefineStartLocation(6, 10752.0, 13824.0)
DefineStartLocation(7, 10752.0, 13824.0)
DefineStartLocation(8, -10240.0, -7168.0)
DefineStartLocation(9, -10752.0, -7680.0)
DefineStartLocation(10, -10752.0, -7680.0)
DefineStartLocation(11, -10752.0, -7680.0)
DefineStartLocation(12, 10240.0, -7168.0)
DefineStartLocation(13, 10752.0, -7680.0)
DefineStartLocation(14, 10752.0, -7680.0)
DefineStartLocation(15, 10752.0, -7680.0)
InitCustomPlayerSlots()
InitCustomTeams()
InitAllyPriorities()
end

