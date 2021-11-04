// Converted from VoidHighLordV6(BlackScreenFix)
// Author: Author
// Description: Description

using System;
using System.Collections.Generic;
using RBot;
using RBot.Options;
public class Script
{
    public string OptionsStorage = "Author_VoidHighLordV6(BlackScreenFix)";
    public bool DontPreconfigure = true;


    public void ScriptMain(ScriptInterface bot)
    {
        bot.Options.SafeTimings = true;
        bot.Options.RestPackets = true;
        bot.Options.ExitCombatBeforeQuest = true;
        bot.Options.InfiniteRange = true;
        bot.Options.SkipCutscenes = true;
        if (bot.Inventory.Contains("Voucher of Nulgath (non-mem)", 1)) 

        if (bot.Bank.Contains("Voucher of Nulgath (non-mem)", 1)) 
        {
            bot.Bank.ToInventory("Voucher of Nulgath (non-mem)");
        }

        VoucherNonM_1556594267:
        bot.Quests.EnsureAccept(0);
        bot.Player.Join("gilead-1e9", "r8", "Spawn");
        bot.Player.KillForItem("Mana Elemental", "Charged Mana Energy for Nulgath", 5, true);
        bot.Player.Join("elemental-1e9", "r5", "Spawn");
        bot.Player.KillForItem("Mana Golem", "Mana Energy for Nulgath", 1, true);
        bot.Quests.EnsureComplete(0, -1);
        bot.Sleep(1000);
        if (!bot.Inventory.Contains("Voucher of Nulgath (non-mem)", 1)) 

        VoidHigh_1526408738:
        ; // Unsupported command CmdBotDelay.
        Bone_Dust_1754117326:
        if (bot.Inventory.Contains("Bone Dust", 20)) 

        bot.Player.Join("battleunderb-1e99", "Enter", "Spawn");
        if (bot.Map.Name != "battleunderb") 
        {
            bot.Player.Join("battleunderb-1e9", "Enter", "Spawn");
        }
        bot.Player.KillForItem("Skeleton Warrior", "Bone Dust", 20, false);
        Black_Knight_Orb_1526003711:
        if (bot.Inventory.Contains("Black Knight Orb", 1)) 

        bot.Quests.EnsureAccept(0);
        bot.Player.Join("trunk-1e9", "Enter", "Spawn");
        bot.Player.KillForItem("Greenguard Basilisk", "Black Knight Arm Piece", 1, true);
        bot.Player.Join("deathgazer-1e9", "Enter", "Spawn");
        bot.Player.KillForItem("DeathGazer", "Black Knight Shoulder Piece", 1, true);
        bot.Player.Join("greendragon-1e9", "Enter", "Spawn");
        bot.Player.Jump("Boss", "Left");
        bot.Player.KillForItem("Greenguard Dragon", "Black Knight Chest Piece", 1, true);
        bot.Player.Join("well-1e9", "Enter", "Spawn");
        bot.Player.Jump("Boss", "Center");
        bot.Player.KillForItem("Gell Oh No", "Black Knight Leg Piece", 1, true);
        bot.Quests.EnsureComplete(0, -1);
        Dwakel_Decoder_1300765861:
        if (bot.Inventory.Contains("Dwakel Decoder", 1)) 

        bot.Player.Join("crashsite-1e9", "Enter", "Spawn");
        bot.Player.Jump("Farm2", "Right");
        bot.SendPacket($"%xt%zm%getMapItem%442235%106%");
        Aelitas_Emerald_659985713:
        if (bot.Bank.Contains("Aelita's Emerald", 1)) 

        if (bot.Inventory.Contains("Aelita's Emerald", 1)) 

        bot.Player.Join("yulgar-1e9", "Enter", "Spawn");
        bot.Shops.BuyItem(16, "Aelita's Emerald");
        Elemental_Ink_1944070645:
        if (bot.Inventory.Contains("Elemental Ink", 10)) 
   
        bot.Player.Join("escherion-1", "Enter", "Spawn");
        bot.Player.Jump("Boss", "Left");
        bot.Player.KillForItem("Escherion", "Mystic Quills", 4, false);
        bot.Player.Join("dragonrune-1e9", "Enter", "Spawn");
        bot.Player.Jump("r8", "Left");
        bot.Shops.BuyItem(549, "Elemental Ink");
        bot.Shops.BuyItem(549, "Elemental Ink");
        Elders_Blood_1674674287:
        if (bot.Inventory.Contains("Elders' Blood", 1)) 
  
        bot.Player.Join("arcangrove-1e99", "Enter", "Spawn");
        if (bot.Map.Name != "arcangrove") 
        {
            bot.Player.Join("arcangrove-1e9", "Enter", "Spawn");
        }
        bot.Quests.EnsureAccept(0);
        bot.Player.Jump("Right", "Right");
        bot.Player.KillForItem("Gorillaphant", "Slain Gorillaphant", 50, true);
        bot.Quests.EnsureComplete(0, -1);
        The_Secret_1_2041431963:
        if (bot.Inventory.Contains("The Secret 1", 1)) 
        {
            //goto Nulgath_Shaped_Chocolate_1870568318;
        }
        bot.Player.Join("willowcreek-1e9", "Enter", "Spawn");
        bot.Player.Jump("Yard2", "Right");
        bot.Quests.EnsureAccept(0);
        bot.Player.KillForItem("Hidden Spy", "The Secret 1", 1, false);
        Nulgath_Shaped_Chocolate_1870568318:
        if (bot.Inventory.Contains("Nulgath Shaped Chocolate", 1)) 

        if (bot.Player.Gold < 2000000) 
}
        bot.Player.Join("citadel-1e9", "Enter", "Spawn");
        bot.Shops.BuyItem(44, "Nulgath Shaped Chocolate");
        Nulgaths_Approval_1881672770:
        if (bot.Inventory.Contains("Nulgath's Approval", 300)) 

        bot.Player.Join("evilwarnul-1e99", "Enter", "Spawn");
        if (bot.Map.Name != "evilwarnul") 
        {
            bot.Player.Join("evilwarnul-1e9", "Enter", "Spawn");
        }
        ApprovalRe_812706385:
        bot.Player.Jump("r2", "Up");
        bot.Player.Kill("*");
        bot.Player.Jump("r3", "Right");
        bot.Player.Kill("*");
        bot.Player.Jump("r4", "Right");
        bot.Player.Kill("*");
        if (!bot.Inventory.Contains("Nulgath's Approval", 300)) 

        Archfiends_Favor_1453261026:
        if (bot.Inventory.Contains("Archfiend's Favor", 300)) 

        bot.Player.Join("evilwarnul-1e99", "Enter", "Spawn");
        if (bot.Map.Name != "evilwarnul") 
        {
            bot.Player.Join("evilwarnul-1e9", "Enter", "Spawn");
        }
        FavorRe2_1397226033:
        bot.Player.Jump("r2", "Up");
        bot.Player.Kill("*");
        bot.Player.Jump("r3", "Right");
        bot.Player.Kill("*");
        bot.Player.Jump("r4", "Right");
        bot.Player.Kill("*");
        if (!bot.Inventory.Contains("Archfiend's Favor", 300)) 

        Tainted_Gem_938285779:
        if (bot.Inventory.Contains("Tainted Gem", 100)) 


        bot.Player.Join("boxes-1e99", "Enter", "Spawn");
        if (bot.Map.Name != "boxes") 

        bot.Player.Jump("Fort2", "Right");
        bot.Quests.EnsureAccept(0);
        bot.Player.KillForItem("*", "Cubes", 150, false);
        bot.Player.Jump("War", "Left");
        Mountfrost_1165132876:
        bot.Quests.EnsureAccept(0);
        bot.Player.Join("mountfrost-1e9", "Enter", "Spawn");
        bot.Player.Jump("War", "Left");
        bot.Player.KillForItem("*", "Ice Cubes", 6, true);
        bot.Player.Jump("Enter", "Right");
        bot.Quests.EnsureComplete(0, -1);
        bot.Quests.EnsureAccept(0);
        bot.Quests.EnsureComplete(0, -1);
        bot.Quests.EnsureAccept(0);
        bot.Quests.EnsureComplete(0, -1);
        bot.Quests.EnsureAccept(0);
        bot.Quests.EnsureComplete(0, -1);
        bot.Quests.EnsureAccept(0);
        bot.Quests.EnsureComplete(0, -1);
        bot.Quests.EnsureAccept(0);
        bot.Quests.EnsureComplete(0, -1);
        if (!bot.Inventory.Contains("Tainted Gem", 100)) 
mblem_of_Nulgath_1119960823:
        if (bot.Inventory.Contains("Emblem of Nulgath", 20)) 

        bot.Player.Join("shadowblast-1e99", "Enter", "Spawn");
        if (bot.Map.Name != "shadowblast") 

        bot.Player.Jump("r13", "Left");
        bot.Quests.EnsureAccept(0);
        bot.Player.KillForItem("*", "Gem of Domination", 1, false);
        bot.Player.KillForItem("*", "Fiend Seal", 25, false);
        bot.Quests.EnsureComplete(0, -1);
        if (!bot.Inventory.Contains("Emblem of Nulgath", 20)) 

        Gem_of_Nulgath_586960933:
        if (bot.Inventory.Contains("Gem of Nulgath", 20)) 

        if (bot.Map.Name == "citadel") 

        if (bot.Map.Name == "tercessuinotlim") 

        citad_860666781:
        bot.SendPacket($"%xt%zm%cmd%35246%tfer%ryan15900%citadel-1e99%m22%Left%");
        bot.SendPacket($"%xt%zm%moveToCell%70107%m22%Left%");
        bot.SendPacket($"%xt%zm%cmd%70107%tfer%ryan15900%tercessuinotlim--1e99%Enter%Spawn%");
        bot.SendPacket($"%xt%zm%moveToCell%413%Enter%Spawn%");
        GemR_925361006:
        bot.Player.Jump("m2", "Left");
        bot.Quests.EnsureAccept(0);
        bot.Player.KillForItem("Dark Makai", "Essence of Nulgath", 60, false);
        if (bot.Player.InCombat) 
        {
            bot.Player.Jump("Wait", "Up");
        }
        bot.Bank.ToInventory("Gem of Nulgath");
        bot.Quests.EnsureComplete(0, -1);
        if (!bot.Inventory.Contains("Gem of Nulgath", 20)) 

        Essence_of_Nulgath_340808380:
        if (bot.Inventory.Contains("Essence of Nulgath", 50)) 

        if (bot.Map.Name == "citadel") 

        if (bot.Map.Name == "tercessuinotlim") 

        citad2_859749277:
        bot.SendPacket($"%xt%zm%cmd%35246%tfer%ryan15900%citadel--1e99%m22%Left%");
        bot.SendPacket($"%xt%zm%moveToCell%70107%m22%Left%");
        bot.SendPacket($"%xt%zm%cmd%70107%tfer%ryan15900%tercessuinotlim--1e99%Enter%Spawn%");
        bot.SendPacket($"%xt%zm%moveToCell%413%Enter%Spawn%");
        intercess_320274260:
        bot.Player.Jump("m2", "Left");
        bot.Player.KillForItem("Dark Makai", "Essence of Nulgath", 50, false);
        //goto Essence_of_Nulgath_340808380;
        Turnin_889758371:
        bot.Player.Jump("Wait", "Up");
        bot.Shops.SellItem("Gem of Domination");
        bot.Shops.SellItem("Mystic Quills");
        bot.Shops.SellItem("Fiend Seal");
        bot.Quests.EnsureAccept(0);
        bot.Bank.ToInventory("Aelita's Emerald");
        bot.Bank.ToInventory("Gem of Nulgath");
        bot.Bank.ToInventory("Roentgenium of Nulgath");
        bot.Bank.ToInventory("Unidentified 13");
        bot.Sleep(1000);
        bot.Quests.EnsureComplete(0, -1);
        bot.Inventory.ToBank("Aelita's Emerald");
        if (bot.Inventory.Contains("Elders' Blood", 1)) 

        ScriptManager.RestartScript();
        Gold_327374857:
        if (bot.Player.Gold > 2000000) 

        bot.Player.Join("battlegrounde-1e9", "r2", "Center");
        bot.Quests.EnsureAccept(0);
        bot.Quests.EnsureAccept(0);
        bot.Bank.ToInventory("GOLD Boost! (20 min)");
        bot.Bank.ToInventory("XP Boost! (20 min)");
        bot.Player.KillForItem("*", "Battleground E Opponent Defeated", 10, true);
        if (bot.Quests.CanComplete(3992)) 
        {
            bot.Quests.EnsureComplete(0, -1);
        }
        if (bot.Quests.CanComplete(3991)) 
        {
            bot.Quests.EnsureComplete(0, -1);
        }
        bot.Inventory.ToBank("GOLD Boost! (20 min)");
        bot.Inventory.ToBank("XP Boost! (20 min)");
        if (bot.Player.Gold < 2000000) 
        {
            //goto Gold_327374857;
        }
        Uni_13_306514015:
        if (bot.Inventory.Contains("Unidentified 13", 1)) 
        {
            //goto Turnin_889758371;
        }
        if (bot.Bank.Contains("Unidentified 13", 1)) 
        {
            //goto Turnin_889758371;
        }
        bot.Player.Join("elemental-1", "r5", "Down");
        bot.Quests.EnsureAccept(0);
        bot.Player.KillForItem("MANA GOLEM", "Mana Energy for Nulgath", 1, true);
        bot.Player.Join("gilead-1", "r8", "Bottom");
        bot.Player.KillForItem("MANA ELEMENTAL", "Charged Mana Energy for Nulgath", 5, true);
        bot.Bank.ToInventory("Unidentified 13");
        bot.Quests.EnsureComplete(0, -1);
        bot.Player.Pickup("Unidentified 13");
        bot.Inventory.ToBank("Unidentified 13");
        if (!bot.Player.DropExists("Unidentified 13")) 
        {
            //goto Uni_13_306514015;
        }
    }
}
