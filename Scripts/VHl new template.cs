using System;
using RBot;
using System.Collections.Generic;

public class BluuPurpleTemplate
{
	//-----------EDIT BELOW-------------//
	public int MapNumber = 69696969;
	public readonly int[] SkillOrder = { 3, 1, 2, 4 };
	public int SaveStateLoops = 8700;
	public int TurnInAttempts = 20;
	public string[] RequiredItems = {
		"Roentgenium of Nulgath",//1
		"Hadean Onyx of Nulgath",//2
		"Voucher of Nulgath (non-mem)",//3
		"Voucher of Nulgath",//4
		"Mystic Quills",//5
		"Elemental Ink",//6
		"Ember Ink",//7
		"Runic Ink",//8
		"Emblem of Nulgath",//9
		"Fiend Seal",//1
		"Gem of Domination",//11
		"Unidentified 13",//12
		"Cubes",//13
		"Tainted Gem",//14
		"Receipt of Swindle",//15
		"Gem of Nulgath",//16
		"Essence of Nulgath",//17
		"Dwakel Decoder",//18
		"Black Knight Orb",//19
		"Nulgath Shaped Chocolate",//20
		"The Secret 1",//21
		"Archfiend's Favor",//22
		"Nulgath's Approval",//23
		"Bone Dust",//24
		"Aelita's Emerald",//25
		"Elders' Blood",//26
		"defeated makai",//27
		"Berserker Bunny",//28
		"Nulgath Shaped Chocolate",//29
		"Mana Energy For Nulgath",//2
		"Aelita's Emerald",//30
		"Dark Crystal Shard",//31
		"Blood Gem of the Archfiend",//32
		"Totem of Nulgath",//33
		"Diamond of Nulgath",//34
		"Unidentified 10",//35
        "Gem of Domination",//36
        "Fiend Seal",//37
        "Archfiend's Favor",//38
        "Nulgath's Approval",//39
		"Vampire Lord",
		"StoneCrusher"
	 };
	public string[] RequiredItems2 = { "Gem of Domination", "Fiend Seal", "Archfiend's Favor", "Nulgath's Approval" };
	public string[] MonNames = { "DoomBringer", "Legion Fenrir", "Legion Cannon", "Legion Airstrike", "Paragon", "DoomKnight Prime", "Draconic DoomKnight", "Shadow Destroyer", "Shadowrise Guard" };
	public string[] MonNames2 = { "Legion Fenrir", "Blade Master", "Skull Warrior", "Undead Bruiser", "Undead Infantry", "Undead Legend" };
	public string[] EquippedItems = { };
	public int[] NationReqs = { 1, 25, 1, 1 };
	public int[] Reqs3 = { "Gem of Domination", "Fiend Seal", "Archfiend's Favor", "Nulgath's Approval" };
	public int[] Amounts1 = { 300, 300 };
	//-----------EDIT ABOVE-------------//


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
			while(!bot.Inventory.Contains("RequiredItems[1]", 15)){
				bot.Quests.EnsureAccept(5660);
			
				if(!bot.Inventory.Contains("RequiredItems[20]")){
					//bot.Quests.EnsureAccept(318);
				
					//bot.Player.Join("well");
					//bot.Player.HuntForItem("Gell Oh No", "Black Knight Leg Piece", 1, true);
		*			ItemFarm("Black Knight Leg Piece", 1, true, true, 318, "Gell Oh No", "well");
					
					//bot.Player.Join("greendragon");
					//bot.Player.HuntForItem("Greenguard Dragon", "Black Knight Chest Piece", 1, true);
		*			ItemFarm("ItemName", 1, true, true, 318, "Greenguard Dragon", "greendragon");
					
					//bot.Player.Join("deathgazer");
					//bot.Player.HuntForItem("Deathgazer", "Black Knight Shoulder Piece", 1, true);
		*			ItemFarm("Black Knight Shoulder Piece", 1, true, true, 318, "Deathgazer");
					
					//bot.Player.Join("trunk");
					//bot.Player.KillForItem("Greenguard Basilisk", "Black Knight Arm Piece", 1, true);
		*			ItemFarm("Black Knight Arm Piece", 1, true, true, 318, "Greenguard Basilisk");
					
					//bot.Quests.EnsureComplete(318);
		*			SafeQuestComplete(318);
				}
				
				if(!bot.Inventory.Contains("Dwakel Decoder")){
					SafeMapJoin("crashsite", "Farm2", "Right");
					bot.Map.GetMapItem(106);
					bot.Wait.ForDrop("Dwakel Decoder");
					bot.Player.Pickup("Dwakel Decoder");
				}
				
				if(!bot.Inventory.Contains("RequiredItems[22]")){
				//	bot.Player.Join("willowcreek");
				//	bot.Quests.EnsureAccept(623);
				//	bot.Player.HuntForItem("Hidden Spy", "The Secret 1", 1);
		*			ItemFarm("RequiredItems[22]", 1, false, 1, 623, "Hidden Spy", "willowcreek");
				//	bot.Player.Jump("Enter", "Spawn");
				}
				
				
				if(!bot.Inventory.Contains("RequiredItems[25]", 100)){
					//bot.Player.Join("Battleunderb-1e9");
					//bot.Player.HuntForItem("Skeleton Warrior", "Bone Dust", 100, false);
		*			ItemFarm("RequiredItems[25]", 100, false, false, 1, "Skeleton Warrior", "Battleunderb");
				//	bot.Player.Jump("Tato", "Spawn");				
				
				}
				
				if(!bot.Inventory.Contains("Aelita's Emerald")){
					//bot.Player.Join("yulgar");
					//bot.Shops.Load(16);
					//bot.Sleep(10000);
					//Shops.BuyItem(16, "Aelita's Emerald");
					SafePurchase("RequiredItems[32]", 1, "yulgar", "999999", 16);
				}
				
				while(!bot.Inventory.Contains("Unidentified 13"))
					NulgathLarvaeFarm(bot);
					
				if(!bot.Inventory.Contains("RequiredItems[7]", 10)){
					if(!bot.Inventory.Contains("RequiredItems[6]", 4)){
					//	bot.Player.Join("mobius");
					//	bot.Player.HuntForItem("Slugfit", "Mystic Quills", 4);
				*		ItemFarm("RequiredItems[6]", 4, false, true, 1, "Slugfit", "mobius");
						//bot.Player.Jump("Enter", "Spawn");
					}
					
					SafeMapJoin("spellcraft");
			
					bot.SendPacket("%xt%zm%buyItem%671975%13284%549%1637%");
					bot.Sleep(2500);
					bot.SendPacket("%xt%zm%buyItem%671975%13284%549%1637%");
					bot.Sleep(2500);
				}
				
				while(!bot.Inventory.Contains("RequiredItems[17]", 20)){
					//if(bot.Map.Name != "tercessuinotlim"){
				//		bot.Player.Join("citadel", "m22", "Right");
				//		bot.Player.Join("tercessuinotlim", "Enter", "Spawn");
				//	}
					
				//	bot.Quests.EnsureAccept(4778);
					
					//bot.Player.HuntForItem("Dark Makai", "Essence of Nulgath", 60);
		*			ItemFarm("RequiredItems[18]", 60, false, true, 4778, "Dark Makai", "tercessuinotlim");
					
					//bot.Quests.EnsureComplete(4778);
		*			SafeQuestComplete(4778);
				}
				
				if(!bot.Inventory.Contains("RequiredItems[18]", 50)){
					//if(bot.Map.Name != "tercessuinotlim-999999"){
					//	bot.Player.Join("citadel", "m22", "Right");
						//bot.Player.Join("tercessuinotlim-999999", "Enter", "Spawn");
				//	}
						
					//bot.Player.HuntForItem("Dark Makai", "Essence of Nulgath", 50);
		*			ItemFarm("RequiredItems[18]", 50, false, true, 4778, "Dark Makai", "tercessuinotlim");
				}
				
				while(!bot.Inventory.Contains("RequiredItems[21]", 20)){
				//	if(bot.Map.Name != "shadowblast")
				//		bot.Player.Join("shadowblast");
					
					bot.Quests.EnsureAccept(4748);
					
					//bot.Player.HuntForItems("DoomBringer|Legion Fenrir|Legion Cannon|Legion Airstrike|Paragon|DoomKnight Prime|Draconic DoomKnight|Shadow Destroyer|Shadowrise Guard", new string[] { "Gem of Domination", "Fiend Seal", "Archfiend's Favor", "Nulgath's Approval" }, new int[] { 1, 25, 1, 1 });
		*			//MonNames, RequiredITems2
					ItemFarm("Reqs2", NationReqs, false, true, 4748, "MonNames", "shadowblast");


					//bot.Quests.EnsureComplete(4748);
		*			SafeQuestComplete(4748);
				}
				
				while(!bot.Inventory.Contains("RequiredItems[15]", 100)){
						
					if(!SafeQuestComplete(568));
				}
				
				if(!bot.Inventory.Contains("RequiredItems[41]", 300) || !bot.Inventory.Contains("RequiredItems[40]", 300)){
					SafeMapJoin("evilwarnul");
					
					//bot.Player.HuntForItems("MonNames2", "Reqs3" new int[] { 300, 300 });
		*			ItemFarm("RequiredItems[40]", Amounts1, false, true, 0, "MonNames2", "evilwarnul");
					//MonNames2, RequiredITems3
				}
				
				if(!bot.Inventory.Contains("RequiredItems[27]")){
					while(bot.Quests.IsDailyComplete(802)){
						NulgathLarvaeFarm(bot);
					}
						
				//	bot.Quests.EnsureAccept(802);
					
				//	bot.Player.Join("arcangrove");
				//	bot.Player.HuntForItem("Gorillaphant", "Slain Gorillaphant", 50, true);
		*			ItemFarm("Slain Gorillaphant", 50, true, true, 802, "Gorillaphant", "arcangrove");
					
					//bot.Quests.EnsureComplete(802);
		*			SafeQuestComplete(802);
				}
				
				if(!bot.Inventory.Contains("Nulgath Shaped Chocolate")){
					while(bot.Player.Gold < 2000000){
					//	bot.Quests.EnsureAccept(236);
					//	bot.Player.Join("greenguardwest");
					//	bot.Player.HuntForItem("Big Bad Boar", "Were Egg", 1, true);
		*			ItemFarm("Were Egg", 1, true, true, 236, "Big Bad Boar", "greenguardwest");
					//bot.Quests.EnsureComplete(236);
		*			SafeQuestComplete(236);
					}
					
					//bot.Player.Join("citadel");
					//bot.Shops.Load(44);
					//bot.Sleep(10000);
					//bot.Shops.BuyItem(44, "Nulgath Shaped Chocolate");
					SafePurchase("Nulgath Shaped Chocolate", 1, "citadel", "999999", 44);
				}
				
				//bot.Quests.EnsureComplete(5660);
		*		SafeQuestComplete(5660);
			}
		}
		
		public void NulgathLarvaeFarm(ScriptInterface bot)
		{
		//	bot.Quests.EnsureAccept(2566);	
		//	bot.Player.Join("elemental");	
			
			//bot.Player.HuntForItem("Mana Golem", "Mana Energy For Nulgath", 1, false, true);
		*	ItemFarm("RequiredItems[42]", 1, false, true, 2566, "Mana Golem", "elemental");
			//bot.Player.HuntForItem("Mana Falcon|Mana Imp", "Charged Mana Energy for Nulgath", 5, true, true);
		*	ItemFarm("Charged Mana Energy for Nulgath", 5, true, true, 2566, "Mana Falcon|Mana Imp", "elemental");
			
			//bot.Quests.EnsureComplete(2566); 
		*	SafeQuestComplete(2566);
		}
	
		
		bot.Log($"[{DateTime.Now:HH:mm:ss}] Script stopped successfully.");
		StopBot();
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
		*	//ItemFarm("ItemName", ItemQuantity, Temporary, HuntFor, QuestID, "MonsterName", "MapName", "CellName", "PadName");
		*	MultiQuestFarm("MapName", "CellName", "PadName", QuestList[], "MonsterName");
		*	SafeEquip("ItemName");
		*	SafePurchase("ItemName", ItemQuantityNeeded, "MapName", "MapNumber", ShopID)
		*	SafeSell("ItemName", ItemQuantityNeeded)
		*	//SafeQuestComplete(QuestID, ItemID)
		*	StopBot ("Text", "MapName", "MapNumber", "CellName", "PadName", "Caption")
	*/

	/// <summary>
	/// Farms you the specified quantity of the specified item with the specified quest accepted from specified monsters in the specified location. Saves States every ~5 minutes.
	/// </summary>
	public void ItemFarm(string ItemName, int ItemQuantity, bool Temporary = false, bool HuntFor = false, int QuestID = 0, string MonsterName = "*", string MapName = "Map", string CellName = "Enter", string PadName = "Spawn")
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
			if (HuntFor)
			{
				while (!bot.Inventory.ContainsTempItem(ItemName, ItemQuantity))
				{
					FarmLoop++;
					if (bot.Map.Name != MapName.ToLower()) SafeMapJoin(MapName.ToLower());
					if (QuestID > 0) bot.Quests.EnsureAccept(QuestID);
					bot.Options.AggroMonsters = true;
					AttackType("h", MonsterName);
					if (FarmLoop > SaveStateLoops) goto breakFarmLoop;
				}
			}
			else
			{
				while (!bot.Inventory.ContainsTempItem(ItemName, ItemQuantity))
				{
					FarmLoop++;
					if (bot.Map.Name != MapName.ToLower()) SafeMapJoin(MapName.ToLower(), CellName, PadName);
					if (bot.Player.Cell != CellName) bot.Player.Jump(CellName, PadName);
					if (QuestID > 0) bot.Quests.EnsureAccept(QuestID);
					bot.Options.AggroMonsters = true;
					AttackType("a", MonsterName);
					if (FarmLoop > SaveStateLoops) goto breakFarmLoop;
				}
			}
		}
		else
		{
			if (HuntFor)
			{
				while (!bot.Inventory.Contains(ItemName, ItemQuantity))
				{
					FarmLoop++;
					if (bot.Map.Name != MapName.ToLower()) SafeMapJoin(MapName.ToLower());
					if (QuestID > 0) bot.Quests.EnsureAccept(QuestID);
					bot.Options.AggroMonsters = true;
					AttackType("h", MonsterName);
					if (FarmLoop > SaveStateLoops) goto breakFarmLoop;
				}
			}
			else
			{
				while (!bot.Inventory.Contains(ItemName, ItemQuantity))
				{
					FarmLoop++;
					if (bot.Map.Name != MapName.ToLower()) SafeMapJoin(MapName.ToLower(), CellName, PadName);
					if (bot.Player.Cell != CellName) bot.Player.Jump(CellName, PadName);
					if (QuestID > 0) bot.Quests.EnsureAccept(QuestID);
					bot.Options.AggroMonsters = true;
					AttackType("a", MonsterName);
					if (FarmLoop > SaveStateLoops) goto breakFarmLoop;
				}
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
		if (bot.Map.Name != MapName.ToLower()) SafeMapJoin(MapName.ToLower(), CellName, PadName);
		if (bot.Player.Cell != CellName) bot.Player.Jump(CellName, PadName);
		foreach (var Quest in QuestList)
		{
			if (!bot.Quests.IsInProgress(Quest)) bot.Quests.EnsureAccept(Quest);
			if (bot.Quests.CanComplete(Quest)) SafeQuestComplete(Quest);
		}
		bot.Options.AggroMonsters = true;
		AttackType("a", MonsterName);
		if (FarmLoop > SaveStateLoops) goto breakFarmLoop;
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
	/// Sets attack type to Attack(Attack/A) or Hunt(Hunt/H)
	/// </summary>
	/// <param name="AttackType">Attack/A or Hunt/H</param>
	/// <param name="MonsterName">Name of the monster</param>
	public void AttackType(string AttackType, string MonsterName)
	{
		string attack_ = AttackType.ToLower();

		if (attack_ == "a" || attack_ == "attack")
		{
			bot.Player.Attack(MonsterName);
		}
		else if (attack_ == "h" || attack_ == "hunt")
		{
			bot.Player.Hunt(MonsterName);
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
			if (bot.Map.Name != MapName.ToLower()) SafeMapJoin(MapName.ToLower(), "Wait", "Spawn");
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
	public void StopBot(string Text = "Bot stopped successfully.", string MapName = "yulgar", string CellName = "Enter", string PadName = "Spawn", string Caption = "Stopped", string MessageType = "event")
	{
		//Must have the following functions in your script:
		//SafeMapJoin
		//ExitCombat
		if (bot.Map.Name != MapName.ToLower()) SafeMapJoin(MapName.ToLower(), CellName, PadName);
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
		string mapname = MapName.ToLower();
		while (bot.Map.Name != mapname)
		{
			ExitCombat();
			if (mapname == "tercessuinotlim") bot.Player.Jump("m22", "Center");
			bot.Player.Join($"{mapname}-{MapNumber}", CellName, PadName);
			bot.Wait.ForMapLoad(mapname);
			bot.Sleep(500);
		}
		if (bot.Player.Cell != CellName) bot.Player.Jump(CellName, PadName);
		bot.Log($"[{DateTime.Now:HH:mm:ss}] Joined map {mapname}-{MapNumber}, positioned at the {PadName} side of cell {CellName}.");
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
	public void ConfigureBotOptions(string PlayerName = "Bot By AuQW", string GuildName = "https://auqw.tk/", bool LagKiller = true, bool SafeTimings = true, bool RestPackets = true, bool AutoRelogin = true, bool PrivateRooms = false, bool InfiniteRange = true, bool SkipCutscenes = true, bool ExitCombatBeforeQuest = true)
	{
		SendMSGPacket("Configuring bot.", "AuQW", "moderator");
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
		bot.Events.PlayerDeath += PD => ScriptManager.RestartScript();
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