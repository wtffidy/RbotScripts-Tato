using System;
using RBot;
using System.Collections.Generic;

public class BluuPurpleTemplate
{
//+++++++++++++++ Edit Start +++++++++++++++//
	public int MapNumber = 2142069;
	public string SoloingClass = "StoneCrusher";
	public string FarmingClass = "Vampire Lord";
	public readonly int[] SkillOrder = { 3, 1, 2, 4 };
//+++++++++++++++  Edit End  +++++++++++++++//
/*
		note_VoidHighlord_Roentgenium
		note#0227
		
		https://auqw.tk
		https://discord.io/AQWbots
*/
	public int SaveStateLoops = 0;
	public int TurnInAttempts = 0;
	public string[] RequiredItems = { 
	//Main Itemlist
		"Roentgenium of Nulgath",
		"Hadean Onyx of Nulgath",
		"Voucher of Nulgath (non-mem)",
		"Black Knight Orb",
		"Dwakel Decoder",
		"Nulgath Shaped Chocolate",
		"The Secret 1",
		"Elders' Blood",
		"Aelita's Emerald",
		"Unidentified 13",
		"Elemental Ink",
		"Gem of Nulgath",
		"Bone Dust",
		"Emblem of Nulgath",
		"Essence of Nulgath",
		"Tainted Gem",
		"Nulgath's Approval",
		"Archfiend's Favor",
	//Others
		"Voucher of Nulgath",
		"Blood Gem of the Archfiend",
		"Totem of Nulgath",
		"Mystic Quills",
		"Elemental Ink",
		"Ember Ink",
		"Runic Ink",
		"Mana Energy for Nulgath",
		"Escherion's Helm",
		"Fiend Seal",
		"Gem of Domination",
		"Cubes"
	};
	public string[] EquippedItems = { };
	public int FarmLoop;
	public int SavedState;
	public ScriptInterface bot => ScriptInterface.Instance;
	public void ScriptMain(ScriptInterface bot)
	{
		if (bot.Player.Cell != "Wait") bot.Player.Jump("Wait", "Spawn");

		ConfigureBotOptions();
		ConfigureLiteSettings();

		SkillList(SkillOrder);
		EquipList(EquippedItems);
		UnbankList(RequiredItems);
		CheckSpace(RequiredItems);
		GetDropList(RequiredItems);

		while (!bot.ShouldExit())
		{
			while (!bot.Player.Loaded) { }
			while(!bot.Inventory.Contains("Roentgenium of Nulgath", 15))
			{
				//Requirements for the quest.
				while(!bot.Inventory.Contains("Hadean Onyx of Nulgath"))
				{
					SafeEquip(SoloingClass);
					
					ItemFarm("Hadean Onyx of Nulgath", 1, false, "tercessuinotlim", "m4", "Left");
				}
				
				while(bot.Player.GetFactionRank("Spellcrafting") < 3)
				{
					SafeEquip(FarmingClass);
					
					while(bot.Player.GetFactionRank("Spellcrafting") < 2)
					{
						if(bot.Player.GetFactionRank("Spellcrafting") < 2) bot.Quests.EnsureAccept(2300);
						if(!bot.Quests.CanComplete(2300))
						{
							if(!bot.Inventory.Contains("Mystic Quills", 10)) ItemFarm("Mystic Quills", 10, false, "mobius", "Slugfit", "Down");
							SafePurchase("Ember Ink", 10, "spellcraft", 549);
						}
						if(bot.Quests.IsInProgress(2300) && bot.Quests.CanComplete(2300)) SafeQuestComplete(2300);
						bot.Sleep(500);
					}
					
					if(bot.Player.GetFactionRank("Spellcrafting") < 3) bot.Quests.EnsureAccept(2353);
					if(!bot.Quests.CanComplete(2353))
					{
						if(!bot.Inventory.Contains("Mystic Quills", 10)) ItemFarm("Mystic Quills", 10, false, "mobius", "Slugfit", "Down");
						SafePurchase("Runic Ink", 10, "spellcraft", 549);
					}
					if(bot.Quests.IsInProgress(2353) && bot.Quests.CanComplete(2353)) SafeQuestComplete(2353);
					bot.Sleep(500);
				}
				
				while(!bot.Inventory.Contains("Voucher of Nulgath (non-mem)"))
				{
					SafeEquip(SoloingClass);
					
					if(!bot.Inventory.Contains("Voucher of Nulgath (non-mem)")) bot.Quests.EnsureAccept(2857);
					if(!bot.Quests.CanComplete(2857)) ItemFarm("Escherion's Helm", 1, false, "escherion", "Boss", "Left");
					if(bot.Quests.IsInProgress(2857) && bot.Quests.CanComplete(2857)) SafeQuestComplete(2857);
					if(bot.Inventory.Contains("Voucher of Nulgath")) SafeSell("Voucher of Nulgath", 1);
					bot.Sleep(500);
				}
				
				if(!bot.Inventory.Contains("Roentgenium of Nulgath", 15)) bot.Quests.EnsureAccept(5660);
				if(!bot.Quests.CanComplete(5660))
				{
					//Quest requirements.
					while(!bot.Inventory.Contains("Unidentified 13", 1))
					{
						if(!bot.Inventory.Contains("Unidentified 13", 1)) bot.Quests.EnsureAccept(2566);
						if(!bot.Quests.CanComplete(2566))
						{
							SafeEquip(SoloingClass);
							ItemFarm("Mana Energy for Nulgath", 1, false, "elemental", "r5", "Down");
							
							SafeEquip(FarmingClass);
							ItemFarm("Charged Mana Energy for Nulgath", 5, true, "elemental", "r3", "Down");
						}
						if(bot.Quests.IsInProgress(2566) && bot.Quests.CanComplete(2566)) SafeQuestComplete(2566);
						if(bot.Inventory.Contains("Voucher of Nulgath")) SafeSell("Voucher of Nulgath", 1);
						bot.Sleep(500);
					}
					
					while(!bot.Inventory.Contains("Emblem of Nulgath", 20))
					{
						SafeEquip(FarmingClass);
						
						if(!bot.Inventory.Contains("Emblem of Nulgath", 20)) bot.Quests.EnsureAccept(4748);
						if(!bot.Quests.CanComplete(4748))
						{
							ItemFarm("Gem of Domination", 1, false, "shadowblast", "r13", "Left");
							ItemFarm("Fiend Seal", 25, false, "shadowblast", "r13", "Left");
						}
						if(bot.Quests.IsInProgress(4748) && bot.Quests.CanComplete(4748)) SafeQuestComplete(4748);
						bot.Sleep(500);
					}
					
					while(!bot.Inventory.Contains("Gem of Nulgath", 20))
					{
						SafeEquip(FarmingClass);
						
						if(!bot.Inventory.Contains("Gem of Nulgath", 20)) bot.Quests.EnsureAccept(4778);
						if(!bot.Quests.CanComplete(4778)) ItemFarm("Essence of Nulgath", 60, false, "tercessuinotlim", "m2", "Bottom");
						if(bot.Quests.IsInProgress(4778) && bot.Quests.CanComplete(4778)) SafeQuestComplete(4778, 6136);
						bot.Sleep(500);
					}
					
					while(!bot.Inventory.Contains("Essence of Nulgath", 50))
					{
						SafeEquip(FarmingClass);
						
						ItemFarm("Essence of Nulgath", 50, false, "tercessuinotlim", "m2", "Bottom");
					}
					
					while(!bot.Inventory.Contains("Tainted Gem", 100))
					{
						SafeEquip(FarmingClass);
						
						if(!bot.Inventory.Contains("Tainted Gem", 100)) bot.Quests.EnsureAccept(7817);
						if(!bot.Quests.CanComplete(7817))
						{
							ItemFarm("Cubes", 500, false, "boxes", "Fort2", "Right");
							ItemFarm("Ice Cubes", 6, true, "mountfrost", "War", "Left");
						}
						if(bot.Quests.IsInProgress(7817) && bot.Quests.CanComplete(7817)) SafeQuestComplete(7817);
						bot.Sleep(500);
					}
					
					while(!bot.Inventory.Contains("Black Knight Orb"))
					{
						SafeEquip(SoloingClass);
						
						if(!bot.Inventory.Contains("Black Knight Orb")) bot.Quests.EnsureAccept(318);
						if(!bot.Quests.CanComplete(318))
						{
							ItemFarm("Black Knight Chest Piece", 1, true, "greendragon", "Boss", "Left");
							ItemFarm("Black Knight Shoulder Piece", 1, true, "deathgazer");
							ItemFarm("Black Knight Arm Piece", 1, true, "trunk");
							ItemFarm("Black Knight Leg Piece", 1, true, "well", "Boss", "Center");
						}
						if(bot.Quests.IsInProgress(318) && bot.Quests.CanComplete(318)) SafeQuestComplete(318);
						bot.Sleep(500);
					}
					
					while(!bot.Inventory.Contains("The Secret 1"))
					{
						SafeEquip(FarmingClass);
						
						ItemFarm("The Secret 1", 1, false, "willowcreek", "Yard2", "Right", 623);
					}
					
					while(!bot.Inventory.Contains("Elemental Ink", 10))
					{
						if(!bot.Inventory.Contains("Mystic Quills", 10)) ItemFarm("Mystic Quills", 10, false, "mobius", "Slugfit", "Down");
						SafePurchase("Elemental Ink", 10, "spellcraft", 549);
					}
					
					while(!bot.Inventory.Contains("Dwakel Decoder"))
					{
						SafeMapJoin("crashsite", "Farm2", "Right");
						bot.SendPacket($"%xt%zm%getMapItem%30254%106%");
						bot.Sleep(2000);
					}
					
					while(!bot.Inventory.Contains("Nulgath's Approval", 300) && !bot.Inventory.Contains("Archfiend's Favor", 300))
					{
						SafeEquip(FarmingClass);
						
						ItemFarm("Nulgath's Approval", 300, false, "evilwarnul", "r9", "Left");
						ItemFarm("Archfiend's Favor", 300, false, "evilwarnul", "r9", "Left");
					}
					
					while(!bot.Inventory.Contains("Bone Dust", 20))
					{
						SafeEquip(FarmingClass);
						ItemFarm("Bone Dust", 20, false, "battleunderb");
					}
					
					SafePurchase("Aelita's Emerald", 1, "yulgar", 16);
					
					while(!bot.Inventory.Contains("Nulgath Shaped Chocolate"))
					{
						SafeEquip(FarmingClass);
						
						while(bot.Player.Gold < 2000000)
						{
							if(bot.Player.Gold < 2000000) bot.Quests.EnsureAccept(2957);
							if(!bot.Quests.CanComplete(2857)) ItemFarm("Escherion's Helm", 1, false, "escherion", "Boss", "Left");
							if(bot.Quests.IsInProgress(2857) && bot.Quests.CanComplete(2857)) SafeQuestComplete(2857);
							if(bot.Inventory.Contains("Voucher of Nulgath")) SafeSell("Voucher of Nulgath", 1);
							bot.Sleep(500);
						}
						SafePurchase("Nulgath Shaped Chocolate", 1, "citadel", 44);
					}
					
					while(!bot.Inventory.Contains("Elders' Blood"))
					{
						SafeEquip(FarmingClass);
						
						if(!bot.Quests.IsDailyComplete(802))
						{
							if(!bot.Inventory.Contains("Elders' Blood")) bot.Quests.EnsureAccept(802);
							if(!bot.Quests.CanComplete(802)) ItemFarm("Slain Gorillaphant", 50, true, "arcangrove", "Right", "Right");
							if(bot.Quests.IsInProgress(802) && bot.Quests.CanComplete(802)) SafeQuestComplete(802);
							bot.Sleep(500);
						}
						else StopBot("You have finished farming all of the items except Elders' Blood. Run the bot again tomorrow.");
					}
				}
				if(bot.Quests.IsInProgress(5660) && bot.Quests.CanComplete(5660)) SafeQuestComplete(5660);
				bot.Sleep(10000);
			}
			bot.Log($"[{DateTime.Now:HH:mm:ss}] Bot script farmed the item successfully");
			StopBot("You've obtained 15x Roentgenium of Nulgath.");
		}
	}

	/*------------------------------------------------------------------------------------------------------------
													 Invokable Functions
	------------------------------------------------------------------------------------------------------------*/

	/*
		*	These functions are used to perform a major action in AQW.
		*	All of them require at least one of the Auxiliary Functions listed below to be present in your script.
		*	Some of the functions require you to pre-declare certain integers under "public class Script"
		*	ItemFarm, MultiQuestFarm and HuntItemFarm will require some Background Functions to be present as well.
		*	All of this information can be found inside the functions. Make sure to read.
		*	ItemFarm("ItemName", ItemQuantity, "MapName", "MapNumber", "CellName", "PadName", Temporary, QuestID, "MonsterName");
		*	MultiQuestFarm("MapName", "CellName", "PadName", QuestList[], "MonsterName");
		*	HuntItemFarm("ItemName", ItemQuantity, "MapName", Temporary, QuestID, "MonsterName");
		*	SafeEquip("ItemName");
		*	SafePurchase("ItemName", ItemQuantityNeeded, "MapName", "MapNumber", ShopID)
		*	SafeSell("ItemName", ItemQuantityNeeded)
		*	SafeQuestComplete(QuestID, ItemID)
		*	StopBot ("Text", "MapName", "MapNumber", "CellName", "PadName", "Caption")
	*/

	/// <summary>
	/// Farms you the specified quantity of the specified item with the specified quest accepted from specified monsters in the specified location. Saves States every ~5 minutes.
	/// </summary>
	public void ItemFarm(string ItemName, int ItemQuantity, bool Temporary = false, string MapName = " ", string CellName = "Enter", string PadName = "Spawn", int QuestID = 0, string MonsterName = "*")
	{
	/*
		*   Must have the following functions in your script:
		*   SafeMapJoin
		*   SmartSaveState
		*   SkillList
		*   ExitCombat
		*   GetDropList OR ItemWhitelist
		*
		*   Must have the following commands under public class Script:
		*   int FarmLoop = 0;
		*   int SavedState = 0;
	*/

	startFarmLoop:
		if (FarmLoop > 0) goto maintainFarmLoop;
		SavedState++;
		bot.Log($"[{DateTime.Now:HH:mm:ss}] Started Farming Loop {SavedState}.");
		goto maintainFarmLoop;

	breakFarmLoop:
		SmartSaveState();
		bot.Log($"[{DateTime.Now:HH:mm:ss}] Completed Farming Loop {SavedState}.");
		FarmLoop = 0;
		goto startFarmLoop;

	maintainFarmLoop:
		if (Temporary)
		{
			while (!bot.Inventory.ContainsTempItem(ItemName, ItemQuantity))
			{
				FarmLoop++;
				if (bot.Map.Name != MapName) SafeMapJoin(MapName, CellName, PadName);
				if (bot.Player.Cell != CellName) bot.Player.Jump(CellName, PadName);
				if (QuestID > 0) bot.Quests.EnsureAccept(QuestID);
				bot.Options.AggroMonsters = true;
				bot.Player.Attack(MonsterName);
				if (FarmLoop > SaveStateLoops) goto breakFarmLoop;
			}
		}
		else
		{
			while (!bot.Inventory.Contains(ItemName, ItemQuantity))
			{
				FarmLoop++;
				if (bot.Map.Name != MapName) SafeMapJoin(MapName, CellName, PadName);
				if (bot.Player.Cell != CellName) bot.Player.Jump(CellName, PadName);
				if (QuestID > 0) bot.Quests.EnsureAccept(QuestID);
				bot.Options.AggroMonsters = true;
				bot.Player.Attack(MonsterName);
				if (FarmLoop > SaveStateLoops) goto breakFarmLoop;
			}
		}
	}

	/// <summary>
	/// Farms all the quests in a given string, must all be farmable in the same room and cell.
	/// </summary>
	public void MultiQuestFarm(string MapName, string CellName, string PadName, int[] QuestList, string MonsterName = "*")
	{
	/*
		*   Must have the following functions in your script:
		*   SafeMapJoin
		*   SmartSaveState
		*   SkillList
		*   ExitCombat
		*   GetDropList OR ItemWhitelist
		*
		*   Must have the following commands under public class Script:
		*   int FarmLoop = 0;
		*   int SavedState = 0;
	*/

	startFarmLoop:
		if (FarmLoop > 0) goto maintainFarmLoop;
		SavedState++;
		bot.Log($"[{DateTime.Now:HH:mm:ss}] Started Farming Loop {SavedState}.");
		goto maintainFarmLoop;

	breakFarmLoop:
		SmartSaveState();
		bot.Log($"[{DateTime.Now:HH:mm:ss}] Completed Farming Loop {SavedState}.");
		FarmLoop = 0;
		goto startFarmLoop;

	maintainFarmLoop:
		FarmLoop++;
		if (bot.Map.Name != MapName) SafeMapJoin(MapName, CellName, PadName);
		if (bot.Player.Cell != CellName) bot.Player.Jump(CellName, PadName);
		foreach (var Quest in QuestList)
		{
			if (!bot.Quests.IsInProgress(Quest)) bot.Quests.EnsureAccept(Quest);
			if (bot.Quests.CanComplete(Quest)) SafeQuestComplete(Quest);
		}
		bot.Options.AggroMonsters = true;
		bot.Player.Attack(MonsterName);
		if (FarmLoop > SaveStateLoops) goto breakFarmLoop;
	}

	/// <summary>
	/// Farms you the specified quantity of the specified item with the specified quest accepted from specified monsters in the specified location. Saves States every ~5 minutes.
	/// </summary>
	public void HuntItemFarm(string ItemName, int ItemQuantity, bool Temporary = false, string MapName = " ", int QuestID = 0, string MonsterName = "*")
	{
	/*
		*   Must have the following functions in your script:
		*   SafeMapJoin
		*   SmartSaveState
		*   SkillList
		*   ExitCombat
		*   GetDropList OR ItemWhitelist
		*
		*   Must have the following commands under public class Script:
		*   int FarmLoop = 0;
		*   int SavedState = 0;
	*/

	startFarmLoop:
		if (FarmLoop > 0) goto maintainFarmLoop;
		SavedState++;
		bot.Log($"[{DateTime.Now:HH:mm:ss}] Started Farming Loop {SavedState}.");
		goto maintainFarmLoop;

	breakFarmLoop:
		SmartSaveState();
		bot.Log($"[{DateTime.Now:HH:mm:ss}] Completed Farming Loop {SavedState}.");
		FarmLoop = 0;
		goto startFarmLoop;

	maintainFarmLoop:
		if (Temporary)
		{
			while (!bot.Inventory.ContainsTempItem(ItemName, ItemQuantity))
			{
				FarmLoop++;
				if (bot.Map.Name != MapName) SafeMapJoin(MapName);
				if (QuestID > 0) bot.Quests.EnsureAccept(QuestID);
				bot.Options.AggroMonsters = true;
				bot.Player.Hunt(MonsterName);
				if (FarmLoop > SaveStateLoops) goto breakFarmLoop;
			}
		}
		else
		{
			while (!bot.Inventory.Contains(ItemName, ItemQuantity))
			{
				FarmLoop++;
				if (bot.Map.Name != MapName) SafeMapJoin(MapName);
				if (QuestID > 0) bot.Quests.EnsureAccept(QuestID);
				bot.Options.AggroMonsters = true;
				bot.Player.Hunt(MonsterName);
				if (FarmLoop > SaveStateLoops) goto breakFarmLoop;
			}
		}
	}

	/// <summary>
	/// Equips an item.
	/// </summary>
	public void SafeEquip(string ItemName)
	{
		//Must have the following functions in your script:
		//ExitCombat

		while (bot.Inventory.Contains(ItemName) && !bot.Inventory.IsEquipped(ItemName))
		{
			ExitCombat();
			bot.Player.EquipItem(ItemName);
		}
	}

	/// <summary>
	/// Purchases the specified quantity of the specified item from the specified shop in the specified map.
	/// </summary>
	public void SafePurchase(string ItemName, int ItemQuantityNeeded, string MapName, int ShopID)
	{
		//Must have the following functions in your script:
		//SafeMapJoin
		//ExitCombat

		while (!bot.Inventory.Contains(ItemName, ItemQuantityNeeded))
		{
			if (bot.Map.Name != MapName) SafeMapJoin(MapName, "Wait", "Spawn");
			ExitCombat();
			if (!bot.Shops.IsShopLoaded)
			{
				bot.Shops.Load(ShopID);
				bot.Log($"[{DateTime.Now:HH:mm:ss}] Loaded Shop {ShopID}.");
			}
			bot.Shops.BuyItem(ItemName);
			bot.Log($"[{DateTime.Now:HH:mm:ss}] Purchased {ItemName} from Shop {ShopID}.");
		}
	}

	/// <summary>
	/// Sells the specified item until you have the specified quantity.
	/// </summary>
	public void SafeSell(string ItemName, int ItemQuantityNeeded)
	{
		//Must have the following functions in your script:
		//ExitCombat

		int sellingPoint = ItemQuantityNeeded + 1;
		while (bot.Inventory.Contains(ItemName, sellingPoint))
		{
			ExitCombat();
			bot.Shops.SellItem(ItemName);
		}
	}

	/// <summary>
	/// Attempts to complete the quest with the set amount of {TurnInAttempts}. If it fails to complete, logs out. If it successfully completes, re-accepts the quest and checks if it can be completed again.
	/// </summary>
	public void SafeQuestComplete(int QuestID, int ItemID = -1)
	{
		//Must have the following functions in your script:
		//ExitCombat

		ExitCombat();
		bot.Quests.EnsureAccept(QuestID);
		bot.Quests.EnsureComplete(QuestID, ItemID, tries: TurnInAttempts);
		if (bot.Quests.IsInProgress(QuestID))
		{
			bot.Log($"[{DateTime.Now:HH:mm:ss}] Failed to turn in Quest {QuestID}. Logging out.");
			bot.Player.Logout();
		}
		bot.Log($"[{DateTime.Now:HH:mm:ss}] Turned In Quest {QuestID} successfully.");
		while (!bot.Quests.IsInProgress(QuestID)) bot.Quests.EnsureAccept(QuestID);
	}

	/// <summary>
	/// Stops the bot at yulgar if no parameters are set, or your specified map if the parameters are set.
	/// </summary>
	public void StopBot(string Text = "Bot stopped successfully.", string Caption = "Stopped", string MessageType = "zone", string MapName = "theater", string CellName = "Enter", string PadName = "Spawn")
	{
		//Must have the following functions in your script:
		//SafeMapJoin
		//ExitCombat
		if (bot.Map.Name != MapName) SafeMapJoin(MapName, CellName, PadName);
		if (bot.Player.Cell != CellName) bot.Player.Jump(CellName, PadName);
		bot.Drops.RejectElse = false;
		bot.Options.LagKiller = false;
		bot.Options.AggroMonsters = false;
		bot.Log($"[{DateTime.Now:HH:mm:ss}] Bot stopped successfully.");
		Console.WriteLine(Text);
		SendMSGPacket(Text, Caption, MessageType);
		ScriptManager.StopScript();
	}

	/*------------------------------------------------------------------------------------------------------------
													Auxiliary Functions
	------------------------------------------------------------------------------------------------------------*/

	/*
		*   These functions are used to perform small actions in AQW.
		*   They are usually called upon by the Invokable Functions, but can be used separately as well.
		*   Make sure to have them loaded if your Invokable Function states that they are required.
		*   ExitCombat()
		*   SmartSaveState()
		*   SafeMapJoin("MapName", "CellName", "PadName")
	*/

	/// <summary>
	/// Exits Combat by jumping cells.
	/// </summary>
	public void ExitCombat()
	{
		bot.Options.AggroMonsters = false;
		bot.Player.Jump("Wait", "Spawn");
		while (bot.Player.State == 2) { }
	}

	/// <summary>
	/// Creates a quick Save State by messaging yourself.
	/// </summary>
	public void SmartSaveState()
	{
		bot.SendPacket("%xt%zm%whisper%1%creating save state%" + bot.Player.Username + "%");
		bot.Log($"[{DateTime.Now:HH:mm:ss}] Successfully Saved State.");
	}

	/// <summary>
	/// Joins the specified map.
	/// </summary>
	public void SafeMapJoin(string MapName, string CellName = "Enter", string PadName = "Spawn")
	{
		//Must have the following functions in your script:
		//ExitCombat

		while (bot.Map.Name != MapName)
		{
			ExitCombat();
			if (MapName == "tercessuinotlim")
			{
				while (bot.Map.Name != "citadel")
				{
					bot.Player.Join($"citadel-{MapNumber}", "m22", "Left");
					bot.Wait.ForMapLoad("citadel");
					bot.Sleep(500);
				}
				if (bot.Player.Cell != "m22") bot.Player.Jump("m22", "Left");
			}
			bot.Player.Join($"{MapName}-{MapNumber}", CellName, PadName);
			bot.Wait.ForMapLoad(MapName);
			bot.Sleep(500);
		}
		if (bot.Player.Cell != CellName) bot.Player.Jump(CellName, PadName);
		bot.Log($"[{DateTime.Now:HH:mm:ss}] Joined map {MapName}-{MapNumber}, positioned at the {PadName} side of cell {CellName}.");
	}

	/*------------------------------------------------------------------------------------------------------------
													Background Functions
	------------------------------------------------------------------------------------------------------------*/

	/*
		*   These functions help you to either configure certain settings or run event handlers in the background.
		*   It is highly recommended to have all these functions present in your script as they are very useful.
		*   Some Invokable Functions may call or require the assistance of some Background Functions as well.
		*   These functions are to be run at the very beginning of the bot under public class Script.
		*   ConfigureBotOptions("PlayerName", "GuildName", LagKiller, SafeTimings, RestPackets, AutoRelogin, PrivateRooms, InfiniteRange, SkipCutscenes, ExitCombatBeforeQuest)
		*   ConfigureLiteSettings(UntargetSelf, UntargetDead, CustomDrops, ReacceptQuest, SmoothBackground, Debugger)
		*   SkillList(int[])
		*   GetDropList(string[])
		*   ItemWhiteList(string[])
		*   EquipList(string[])
		*   UnbankList(string[])
		*   CheckSpace(string[])
		*   SendMSGPacket("Message", "Name", "MessageType")
	*/

	/// <summary>
	/// Change the player's name and guild for your bots specifications.
	/// Recommended Default Bot Configurations.
	/// </summary>
	public void ConfigureBotOptions(string PlayerName = "Bot By note", string GuildName = "https://auqw.tk/", bool LagKiller = true, bool SafeTimings = true, bool RestPackets = true, bool AutoRelogin = true, bool PrivateRooms = true, bool InfiniteRange = true, bool SkipCutscenes = true, bool ExitCombatBeforeQuest = true)
	{
		bot.SendClientPacket("%xt%moderator%-1%RBot: Configuring bot.%");
		bot.Options.CustomName = PlayerName;
		bot.Options.CustomGuild = GuildName;
		bot.Options.LagKiller = LagKiller;
		bot.Options.SafeTimings = SafeTimings;
		bot.Options.RestPackets = RestPackets;
		bot.Options.AutoRelogin = AutoRelogin;
		bot.Options.PrivateRooms = PrivateRooms;
		bot.Options.InfiniteRange = InfiniteRange;
		bot.Options.SkipCutscenes = SkipCutscenes;
		bot.Options.ExitCombatBeforeQuest = ExitCombatBeforeQuest;
		bot.Events.PlayerAFK += PA => ScriptManager.RestartScript();
	}

	/// <summary>
	/// Gets AQLite Functions
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="optionName"></param>
	/// <returns></returns>
	public T GetLite<T>(string optionName)
	{
		return bot.GetGameObject<T>($"litePreference.data.{optionName}");
	}

	/// <summary>
	/// Sets AQLite Functions
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="optionName"></param>
	/// <param name="value"></param>
	public void SetLite<T>(string optionName, T value)
	{
		bot.SetGameObject($"litePreference.data.{optionName}", value);
	}

	/// <summary>
	/// Allows you to turn on and off AQLite functions.
	/// Recommended Default Bot Configurations.
	/// </summary>
	public void ConfigureLiteSettings(bool UntargetSelf = true, bool UntargetDead = true, bool CustomDrops = true, bool ReacceptQuest = false, bool SmoothBackground = true, bool Debugger = false)
	{
		SetLite("bUntargetSelf", UntargetSelf);
		SetLite("bUntargetDead", UntargetDead);
		SetLite("bCustomDrops", CustomDrops);
		SetLite("bReaccept", ReacceptQuest);
		SetLite("bSmoothBG", SmoothBackground);
		SetLite("bDebugger", Debugger);
	}

	/// <summary>
	/// Spams Skills when in combat. You can get in combat by going to a cell with monsters in it with bot.Options.AggroMonsters enabled or using an attack command against one.
	/// </summary>
	public void SkillList(params int[] Skillset)
	{
		bot.RegisterHandler(1, b => {
			if (bot.Player.InCombat)
			{
				foreach (var Skill in Skillset)
				{
					bot.Player.UseSkill(Skill);
				}
			}
		});
	}

	/// <summary>
	/// Checks if items in an array have dropped every second and picks them up if so. GetDropList is recommended.
	/// </summary>
	public void GetDropList(params string[] GetDropList)
	{
		bot.RegisterHandler(4, b => {
			foreach (string Item in GetDropList)
			{
				if (bot.Player.DropExists(Item)) bot.Player.Pickup(Item);
			}
			bot.Player.RejectExcept(GetDropList);
		});
	}

	/// <summary>
	/// Pick up items in an array when they dropped. May fail to pick up items that drop immediately after the same item is picked up. GetDropList is preferable instead.
	/// </summary>
	public void ItemWhiteList(params string[] WhiteList)
	{
		foreach (var Item in WhiteList)
		{
			bot.Drops.Add(Item);
		}
		bot.Drops.RejectElse = true;
		bot.Drops.Start();
	}

	/// <summary>
	/// Equips all items in an array.
	/// </summary>
	/// <param name="EquipList"></param>
	public void EquipList(params string[] EquipList)
	{
		foreach (var Item in EquipList)
		{
			if (bot.Inventory.Contains(Item))
			{
				SafeEquip(Item);
			}
		}
	}

	/// <summary>
	/// Unbanks all items in an array after banking every other AC-tagged Misc item in the inventory.
	/// </summary>
	/// <param name="UnbankList"></param>
	public void UnbankList(params string[] UnbankList)
	{
		if (bot.Player.Cell != "Wait") bot.Player.Jump("Wait", "Spawn");
		while (bot.Player.State == 2) { }
		bot.Player.LoadBank();
		List<string> Whitelisted = new List<string>() { "Note", "Item", "Resource", "QuestItem", "ServerUse" };
		foreach (var item in bot.Inventory.Items)
		{
			if (!Whitelisted.Contains(item.Category.ToString())) continue;
			if (item.Name != "Treasure Potion" && item.Coins && !Array.Exists(UnbankList, x => x == item.Name)) bot.Inventory.ToBank(item.Name);
		}
		foreach (var item in UnbankList)
		{
			if (bot.Bank.Contains(item)) bot.Bank.ToInventory(item);
		}
	}

	/// <summary>
	/// Checks the amount of space you need from an array's length/set amount.
	/// </summary>
	/// <param name="ItemList"></param>
	public void CheckSpace(params string[] ItemList)
	{
		int MaxSpace = bot.GetGameObject<int>("world.myAvatar.objData.iBagSlots");
		int FilledSpace = bot.GetGameObject<int>("world.myAvatar.items.length");
		int EmptySpace = MaxSpace - FilledSpace;
		int SpaceNeeded = 0;

		foreach (var Item in ItemList)
		{
			if (!bot.Inventory.Contains(Item)) SpaceNeeded++;
		}

		if (EmptySpace < SpaceNeeded)
		{
			StopBot($"Need {SpaceNeeded} empty inventory slots, please make room for the quest.", bot.Map.Name, bot.Player.Cell, bot.Player.Pad, "Error", "moderator");
		}
	}

	/// <summary>
	/// Sends a message packet to client in chat.
	/// </summary>
	/// <param name="Message"></param>
	/// <param name="Name"></param>
	/// <param name="MessageType">moderator, warning, server, event, guild, zone, whisper</param>
	public void SendMSGPacket(string Message = " ", string Name = "SERVER", string MessageType = "zone")
	{
		// bot.SendClientPacket($"%xt%{MessageType}%-1%{Name}: {Message}%");
		bot.SendClientPacket($"%xt%chatm%0%{MessageType}~{Message}%{Name}%");
	}
}