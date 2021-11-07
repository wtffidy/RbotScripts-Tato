// Converted from VoidCrystalA
// Author: Author
// Description: Description

using System;
using System.Collections.Generic;
using RBot;
using RBot.Options;
public class Script
{
    public string OptionsStorage = "Author_VoidCrystalA";
    public bool DontPreconfigure = true;


    public void ScriptMain(ScriptInterface bot)
    {
        bot.Options.SafeTimings = true;
        bot.Options.RestPackets = true;
        bot.Options.ExitCombatBeforeQuest = true;
        bot.Options.InfiniteRange = true;
        bot.Options.SkipCutscenes = true;
        goto Unbank_Stuffs_1531120935;
        RESTART_1462174912:
        if (bot.Inventory.Contains("Unidentified 10", 200)) 
        {
            goto 2nd_1028830076;
        }
        bot.Quests.EnsureAccept(0);
        bot.Player.Join("Elemental-1e9", "r5", "Down");
        bot.Player.KillForItem("Mana Golem", "Mana Energy for Nulgath", 1, true);
        bot.Player.Join("Gilead-1e9", "r8", "Bottom");
        bot.Player.KillForItem("Mana Elemental", "Charged Mana Energy for Nulgath", 5, true);
        bot.Quests.EnsureComplete(0, -1);
        goto RESTART_1462174912;
        2nd_1028830076:
        citad_860666781:
        if (bot.Inventory.Contains("Gem of Nulgath", 150)) 
        {
            goto 3rd_1028043645;
        }
        bot.Player.Join("citadel-1e9", "Enter", "Spawn");
        bot.Player.Jump("m22", "Up");
        bot.Player.Join("tercessuinotlim-1e99", "Enter", "Spawn");
        GemR_925361006:
        bot.Player.Jump("m2", "Left");
        bot.Quests.EnsureAccept(0);
        bot.Player.KillForItem("Dark Makai", "Essence of Nulgath", 60, false);
        if (bot.Player.InCombat) 
        {
            bot.Player.Jump("Wait", "Up");
        }
        bot.Quests.EnsureComplete(0, -1);
        if (!bot.Inventory.Contains("Gem of Nulgath", 150)) 
        {
            goto Gemr_1547181202;
        }
        3rd_1028043645:
        if (bot.Inventory.Contains("Dark Crystal Shard", 200)) 
        {
            goto 4th_584963390;
        }
        bot.Quests.EnsureAccept(0);
        if (bot.Inventory.Contains("Defeated Makai", 50)) 
        {
            goto BOSS_1910506711;
        }
        bot.Player.Join("citadel-1e9", "m22", "Left");
        MAKAI_1062576763:
        if (bot.Inventory.Contains("Defeated Makai", 50)) 
        {
            goto BOSS_1910506711;
        }
        bot.Player.Join("tercessuinotlim-1e99", "m2", "Bottom");
        bot.Player.Jump("m1", "Left");
        bot.Player.Kill("Dark Makai");
        bot.Player.Kill("Dark Makai");
        bot.Player.Pickup("Defeated Makai");
        bot.Player.Jump("m2", "Bottom");
        bot.Player.Kill("Dark Makai");
        bot.Player.Kill("Dark Makai");
        bot.Player.Pickup("Defeated Makai");
        bot.Player.Jump("Enter", "Spawn");
        goto MAKAI_1062576763;
        BOSS_1910506711:
        bot.Player.Jump("Enter", "Spawn");
        if (bot.Inventory.Contains("Escherion's Chain", 1)) 
        {
            goto yokai_1524961415;
        }
        bot.Player.Join("escherion-1e9", "Boss", "Left");
        bot.Player.KillForItem("Escherion", "Escherion's Chain", 1, false);
        yokai_1524961415:
        if (bot.Inventory.Contains("O-dokuro's Tooth", 1)) 
        {
            goto stalagbite_1493487165;
        }
        bot.Player.Join("yokaiwar-1e9", "Boss", "Left");
        Toothh_1135723529:
        if (bot.Player.Cell != "Boss") 
        {
            bot.Player.Jump("r5", "Left");
        }
        bot.Player.Kill("O-dokuro's Head");
        if (!bot.Inventory.Contains("O-dokuro's Tooth", 1)) 
        {
            goto Toothh_1135723529;
        }
        stalagbite_1493487165:
        if (bot.Inventory.Contains("Strand of Vath's Hair", 1)) 
        {
            goto Aracara_47358830;
        }
        bot.Player.Join("stalagbite-1e9", "r2", "Left");
        bot.Player.KillForItem("Vath", "Strand of Vath's Hair", 1, false);
        Aracara_47358830:
        if (bot.Inventory.Contains("Aracara's Fang", 1)) 
        {
            goto Hydra_1967191405;
        }
        bot.Player.Join("faerie-1e9", "TopRock", "Bottom");
        bot.Player.KillForItem("Aracara", "Aracara's Fang", 1, false);
        Hydra_1967191405:
        if (bot.Inventory.Contains("Hydra Scale", 1)) 
        {
            goto Tibicenas_1264401133;
        }
        bot.Player.Join("hydra-1e9", "Boss", "Left");
        bot.Player.KillForItem("Hydra", "Hydra Scale", 1, false);
        Tibicenas_1264401133:
        if (bot.Inventory.ContainsTempItem("Tibicenas' Chain", 1)) 
        {
            goto POOOP_1649684773;
        }
        bot.Player.Join("djinn-1e9", "r5", "Left");
        TiChain_1861861036:
        if (bot.Player.Cell != "r5") 
        {
            bot.Player.Jump("r5", "Left");
        }
        bot.Player.KillForItem("tibicenas", "tibicenas' chain", 1, true);
        POOOP_1649684773:
        bot.Quests.EnsureComplete(0, -1);
        goto 3rd_1028043645;
        4th_584963390:
        bot.Quests.EnsureAccept(0);
        Cubes_345694238:
        if (bot.Inventory.Contains("Cubes", 150)) 
        {
            goto Ice_1699725688;
        }
        Loop2_1903018843:
        bot.Player.Join("boxes-1e9", "Enter", "Spawn");
        if (bot.Map.Name != "Boxes") 
        {
            bot.Player.Join("boxes-1e9", "Enter", "Spawn");
        }
        bot.Player.Jump("Fort2", "Right");
        bot.Player.Kill("*");
        bot.Player.Kill("*");
        bot.Player.Kill("*");
        goto Cubes_345694238;
        Golem_439247826:
        if (bot.Inventory.ContainsTempItem("Ice Cubes", 6)) 
        {
            goto QUEST_1136202462;
        }
        Ice_1699725688:
        bot.Player.Join("mountfrost-1e9", "Enter", "Spawn");
        bot.Sleep(500);
        bot.Player.Jump("War", "Left");
        bot.Player.Kill("*");
        bot.Player.Kill("*");
        bot.Player.Kill("*");
        bot.Player.Kill("*");
        goto Golem_439247826;
        QUEST_1136202462:
        bot.Sleep(500);
        bot.Quests.EnsureComplete(0, -1);
        if (bot.Inventory.Contains("Tainted Gem", 200)) 
        {
            goto QWERTY_1203825954;
        }
        goto 4th_584963390;
        QWERTY_1203825954:
        bot.Player.Join("citadel-1e9", "m22", "Up");
        bot.Player.Join("tercessuinotlim-1e99", "Taro", "Spawn");
        bot.Shops.BuyItem(1355, "Void Crystal A");
        bot.Inventory.ToBank("Void Crystal A");
        bot.Player.Join("battleon-1e9", "Enter", "Spawn");
        ScriptManager.StopScript();
        Unbank_Stuffs_1531120935:
        if (bot.Bank.Contains("Voucher of Nulgath", 1)) 
        {
            bot.Bank.ToInventory("Voucher of Nulgath");
        }
        if (bot.Bank.Contains("Voucher of Nulgath (non-mem)", 1)) 
        {
            bot.Bank.ToInventory("Voucher of Nulgath (non-mem)");
        }
        if (bot.Bank.Contains("Unidentified 13", 1)) 
        {
            bot.Bank.ToInventory("Unidentified 13");
        }
        if (bot.Bank.Contains("Unidentified 10", 1)) 
        {
            bot.Bank.ToInventory("Unidentified 10");
        }
        if (bot.Bank.Contains("Diamond of Nulgath", 1)) 
        {
            bot.Bank.ToInventory("Diamond of Nulgath");
        }
        if (bot.Bank.Contains("Dark Crystal Shard", 1)) 
        {
            bot.Bank.ToInventory("Dark Crystal Shard");
        }
        if (bot.Bank.Contains("Totem of Nulgath", 1)) 
        {
            bot.Bank.ToInventory("Totem of Nulgath");
        }
        if (bot.Bank.Contains("Gem of Nulgath", 1)) 
        {
            bot.Bank.ToInventory("Gem of Nulgath");
        }
        if (bot.Bank.Contains("Essence of Nulgath", 1)) 
        {
            bot.Bank.ToInventory("Essence of Nulgath");
        }
        if (bot.Bank.Contains("Defeated Makai", 1)) 
        {
            bot.Bank.ToInventory("Defeated Makai");
        }
        if (bot.Bank.Contains("Escherion's Chain", 1)) 
        {
            bot.Bank.ToInventory("Escherion's Chain");
        }
        if (bot.Bank.Contains("O-dokuro's Tooth", 1)) 
        {
            bot.Bank.ToInventory("O-dokuro's Tooth");
        }
        if (bot.Bank.Contains("Cubes", 1)) 
        {
            bot.Bank.ToInventory("Cubes");
        }
        if (bot.Bank.Contains("Strand of Vath's Hair", 1)) 
        {
            bot.Bank.ToInventory("Strand of Vath's Hair");
        }
        if (bot.Bank.Contains("Aracara's Fang", 1)) 
        {
            bot.Bank.ToInventory("Aracara's Fang");
        }
        if (bot.Bank.Contains("Hydra Scale", 1)) 
        {
            bot.Bank.ToInventory("Hydra Scale");
        }
        if (bot.Bank.Contains("Tainted Gem", 1)) 
        {
            bot.Bank.ToInventory("Tainted Gem");
        }
        goto RESTART_1462174912;
    }
}
