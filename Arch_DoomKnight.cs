using System;
using RBot;
using System.Collections.Generic;

public class ArchDoomKnight //by Tato
{
	//-----------EDIT BELOW-------------//
	public int MapNumber = 2142069;
	public readonly int[] SkillOrder = { 3, 1, 2, 4 };
	public int SaveStateLoops = 8700;
	public int TurnInAttempts = 10;
	public string[] RequiredItems = { 
		//gathering power items

		"Undead Energy",
		"Human Souls",
		"Dragon Energy",
		//death's door items

		"Death's Power", 
		"Souls of the Dead",

		//chaotic lords items
		"Escherion's Helm",
		"Legendary Sword of Dragon Control", 
		"Hanzamune Dragon Koi Blade", 
		"Wolfwing Armor",
		"One Eyed Doll Breaker",
		"Ledgermayne",
		"Tibicenas", 
		"Soul of Chaos Armor",
		"Chaos Lionfang Armor",
		"Shorn Chaos King Crown", 
		"Xiang Chaos",
		"Drakath's Sword",
		"Chaorrupted Hourglass",
		"Chaotic Power",

		//a means to an end items
		"Ultimate Darkness Gem",
		"Undead Energy",
		"(Necro) Scroll of Dark Arts",
		"Doom Heart",
		"Dread Knight Cleaver",
		"Reaper's Soul",
		"Desolich's Undead Eye",

		//Quest Rewards
		//-----------

		//Q1
		"Arch DoomKnight Cape",

		//Q2
		"Arch DoomKnight Cape Sword",		
		"Arch DoomKnight Polearm",

		//Q3
		"Arch DoomKnight Sword",
		"Arch DoomKnight's Edge",

		//Q4
		"Arch DoomKnight",
		"Arch DoomKnight Open Helm",
		"Arch DoomKnight Helm"

	};
	public string[] EquippedItems = {  };
	public string[] gatheringpoweritems = { 
		"Undead Energy",
		"Human Souls",
		"Dragon Energy"
	};
	public string[] deathsdooritems = { 
		"Death's Power", 
		"Souls of the Dead" 
	};
	public string[] chaoticlordsitems = { 
		"Escherion's Helm",
		"Legendary Sword of Dragon Control", 
		"Hanzamune Dragon Koi Blade", 
		"Wolfwing Armor",
		"One Eyed Doll Breaker",
		"Ledgermayne",
		"Tibicenas", 
		"Soul of Chaos Armor",
		"Chaos Lionfang Armor",
		"Shorn Chaos King Crown", 
		"Xiang Chaos",
		"Drakath's Sword",
		"Chaorrupted Hourglass",
		"Chaotic Power", 
	};
	public string[] ameanstoanenditems = { 
		"Ultimate Darkness Gem",
		"Undead Energy",
		"(Necro) Scroll of Dark Arts",
		"Doom Heart",
		"Dread Knight Cleaver",
		"Reaper's Soul",
		"Desolich's Undead Eye" 
	};

	public string[] Q1items = { 
		"Arch DoomKnight Cape" 
	};
	public string[] Q2items = { 
		"Arch DoomKnight Cape Sword",		
		"Arch DoomKnight Polearm"		
	};
	public string[] Q3items = { 
		"Arch DoomKnight Sword",
		"Arch DoomKnight's Edge"
	};
	public string[] Q4items = { 
		"Arch DoomKnight",
		"Arch DoomKnight Open Helm",
		"Arch DoomKnight Helm"
	};
	//-----------EDIT ABOVE-------------//



	public int FarmLoop;
	public int SavedState;
	public ScriptInterface bot => ScriptInterface.Instance;
	public void ScriptMain(ScriptInterface bot)
	{
		if (bot.Player.Cell != "Wait") bot.Player.Jump("Wait", "Spawn");

		ConfigureBotOptions();
		ConfigureLiteSettings();

		DeathHandler();

		SkillList(SkillOrder);
		EquipList(EquippedItems);
		UnbankList(RequiredItems);
		CheckSpace(RequiredItems);
		GetDropList(RequiredItems);

		//Requirements for this bot; 
		//R7 Ebil
		//14+ inv slots
		//13 chaos lords sagas
		//complete Treasurehunter z's questline in /shadowfall (reduneded prolly dont need)
		//complete doomwood saga & artix's "a loyal follower" quest

		while (!bot.ShouldExit())
		{
			while (!bot.Player.Loaded) { }			
			
			bot.Log("Item Checks");
			bot.Log("EbilRep Checks");
			if (bot.Player.GetFactionRank("Evil") < 10) 
			{
				EbilRep();
			}
			else
			bot.Log("Q1items Checks");
			if(!CheckInv(Q1items)) 
			{
				gatheringpower();
			}
			else
			bot.Log("Q2items Checks");
			if(!CheckInv(Q2items)) 
			{
				deathsdoor();
			}
			else
			bot.Log("Q3items Checks");
			if(!CheckInv(Q3items)) 
			{
				ChaoticLords();
			}
			else
			bot.Log("Q4items Checks");
			if(!CheckInv(Q4items))
			{
				ameanstoanend();
			}
		}
		bot.Log($"[{DateTime.Now:HH:mm:ss}] Script stopped successfully.");
		StopBot($"we're done here");
	}

	public void EbilRep()
	{
		bot.Log("Ebil Rep Start");
		while (bot.Player.GetFactionRank("Evil") < 7)
            {
				bot.Log("EbilRep Start");
                ItemFarm("Youthanize", 1, true, true, 364, "slime", "swordhavenbridge");
				SafeQuestComplete(364);
				// ItemFarm("ItemName", Amount, temp, hunt, 6798, "monster", "mapname");
			}
               
	}

	public void gatheringpower() //gathering power 6795
	{
		bot.Log("gatheringpower start");
		bot.Log("gatheringpower1");
		ItemFarm("Undead Energy", 1800, false, false, 6795, "*", "battleunderb", "Enter", "Spawn");
		bot.Log("gatheringpower2");
		ItemFarm("Human Souls", 500, false, true, 6795, "Lightguard Caster|Lightguard Paladin", "noxustower");
		bot.Log("gatheringpower3");
		ItemFarm("Dragon Energy", 600, false, true, 6795, "Water Draconian", "lair");
		bot.Log("gatheringpowerturnin");
		SafeQuestComplete(6795);

	}

	
	public void deathsdoor() //death's door 6796
	{
		bot.Log("deathsdoor start");
		bot.Log("deathsdoor1");
		ItemFarm("Death's Power", 1, false, true, 6796, "Death", "shadowattack");
		bot.Log("deathsdoor2");
		ItemFarm("Souls of the Dead", 400, false, true, 6796, "Death", "shadowattack");
		bot.Log("deathsdoorturnin");
		SafeQuestComplete(6796);

	}

	
	public void ChaoticLords() //Chaotic Lords 6797
	{
		bot.Log("ChaoticLords start");
		bot.Log("ChaoticLords1");
		ItemFarm("Escherion's Helm", 1, false, true, 6797, "Escherion", "Escherion");
		bot.Log("ChaoticLords2");
		ItemFarm("Legendary Sword of Dragon Control", 1, false, true, 6797, "Vath", "Stalagbite");
		bot.Log("ChaoticLords3");
		ItemFarm("Hanzamune Dragon Koi Blade", 1, false, true, 6797, "Kitsune", "kitsune");
		bot.Log("ChaoticLords4");
		ItemFarm("Wolfwing Armor", 1, false, true, 6797, "wolfwing", "wolfwing");
		bot.Log("ChaoticLords5");
		ItemFarm("One Eyed Doll Breaker", 1, false, true, 6797, "Kimberly", "palooza");
		bot.Log("ChaoticLords6");
		ItemFarm("Ledgermayne", 1, false, true, 6797, "Ledgermayne", "Ledgermayne");
		bot.Log("ChaoticLords7");
		ItemFarm("Tibicenas", 1, false, true, 6797, "Tibicenas", "djinn");
		bot.Log("ChaoticLords8");
		ItemFarm("Soul of Chaos Armor", 1, false, true, 6797, "Khasaanda", "dreamnexus");
		bot.Log("ChaoticLords9");
		ItemFarm("Chaos Lionfang Armor", 1, false, true, 6797, "Chaos Lord Lionfang", "stormtemple");
		bot.Log("ChaoticLords10");
		ItemFarm("Shorn Chaos King Crown", 1, false, true, 6797, "Chaos Lord Alteon", "swordhavenfalls");
		bot.Log("ChaoticLords11");
		ItemFarm("Xiang Chaos", 1, false, true, 6797, "Chaos Lord Xiang", "mirrorportal");
		bot.Log("ChaoticLords12");
		ItemFarm("Drakath's Sword", 1, false, true, 6797, "Champion of Chaos", "Ultra Drakath"); //1% drop
		bot.Log("ChaoticLords13");
		ItemFarm("Chaorrupted Hourglass", 1, false, true, 6797, "Chaos Lord Iadoa", "timespace");
		bot.Log("ChaoticLords14");
		ItemFarm("Chaotic Power", 13, false, true, 6797, "Escherion", "Escherion");
		bot.Log("ChaoticLords15");
		SafeQuestComplete(6797);
		

	}

	
	public void ameanstoanend()//a means to an end 6798
	{
		bot.Log("ameanstoanend start");
		bot.Log("ameanstoanend1");
		ItemFarm("Ultimate Darkness Gem", 50, false, true, 6798, "Bonemuncher|Ghoul", "shadowfallwar");
		bot.Log("ameanstoanend2");
		ItemFarm("Undead Energy", 2800, false, false, 6795, "*", "battleunderb", "Enter", "Spawn");
		bot.Log("ameanstoanend3");
		ItemFarm("(Necro) Scroll of Dark Arts", 2, false, true, 6798, "Ultra Vordred", "epicvordred");
		bot.Log("ameanstoanend4");
		ItemFarm("Doom Heart", 1, false, true, 6798, "Ultra Sepulchure", "sepulchurebattle");
		bot.Log("ameanstoanend5");
		ItemFarm("Dread Knight Cleaver", 1, false, true, 6798, "Dark Sepulchure", "sepulchure");
		bot.Log("ameanstoanend6");
		ItemFarm("Reaper's Soul", 1, false, true, 6798, "Reaper", "thevoid");
		bot.Log("ameanstoanend7");
		ItemFarm("Desolich's Undead Eye", 2, false, true, 6798, "Desolich", "Desolich");
		bot.Log("ameanstoanendturnin");
		SafeQuestComplete(6798);
		

	}

	public void Unbank(params string[] Unbank)
		{
		if (bot.Player.Cell != "Wait") bot.Player.Jump("Wait", "Spawn");
		while (bot.Player.State == 2) { }
		bot.Player.LoadBank();
		List<string> Whitelisted = new List<string>() { "Note", "Item", "Resource", "QuestItem", "ServerUse" };
		foreach (var item in Unbank)
			{
				if (bot.Bank.Contains(item)) bot.Bank.ToInventory(item);
			}
		}

		
	public bool CheckInv(params string[] items)
		{
		foreach (string item in items)
		{
			if (bot.Inventory.Contains(item) || bot.Bank.Contains(item))
				continue;
			else
				return false;
		}
		return true;
		}

	public void ChaosLords()
	{
		StopBot($"setup & run breno's 13 chaos lords; https://github.com/BrenoHenrike/Rbot-Scripts");
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
		*	ItemFarm("ItemName", ItemQuantity, Temporary, HuntFor, QuestID, "MonsterName", "MapName", "CellName", "PadName");
		*	MultiQuestFarm("MapName", "CellName", "PadName", QuestList[], "MonsterName");
		*	SafeEquip("ItemName");
		*	SafePurchase("ItemName", ItemQuantityNeeded, "MapName", "MapNumber", ShopID)
		*	SafeSell("ItemName", ItemQuantityNeeded)
		*	SafeQuestComplete(QuestID, ItemID)
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
	public void ConfigureBotOptions(string PlayerName = "Bot By AuQW", string GuildName = "https://auqw.tk/", bool LagKiller = true, bool SafeTimings = true, bool RestPackets = true, bool AutoRelogin = true, bool PrivateRooms = false, bool InfiniteRange = true, bool SkipCutscenes = true, bool ExitCombatBeforeQuest = true, bool HideMonster=true)
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
		// bot.Events.PlayerDeath += PD => ScriptManager.RestartScript();
		// bot.Events.PlayerAFK += PA => ScriptManager.RestartScript();
		HideMonsters(HideMonster);
	}

	/// <summary>
	/// Hides the monsters for performance
	/// </summary>
	/// <param name="Value"> true -> hides monsters. false -> reveals them </param>
	public void HideMonsters(bool Value) {
	  switch(Value) {
	     case true:
	        if (!bot.GetGameObject<bool>("ui.monsterIcon.redX.visible")) {
	           bot.CallGameFunction("world.toggleMonsters");
	        }
	        return;
	     case false:
	        if (bot.GetGameObject<bool>("ui.monsterIcon.redX.visible")) {
	           bot.CallGameFunction("world.toggleMonsters");
	        }
	        return;
	  }
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
	public void ConfigureLiteSettings(bool UntargetSelf = true, bool UntargetDead = true, bool CustomDrops = false, bool ReacceptQuest = false, bool SmoothBackground = true, bool Debugger = false)
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


	public void DeathHandler() {
      bot.RegisterHandler(2, b => {
         if (bot.Player.State==0) {
            bot.Player.SetSpawnPoint();
            ExitCombat();
            bot.Sleep(12000);
         }
      });
	}



}