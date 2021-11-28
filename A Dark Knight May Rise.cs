using System;
using RBot;
using System.Collections.Generic;
using RBot.Servers;
using System.Windows.Forms;
public class A_Dark_Knight_May_Rise //by Tato
{
	//-----------EDIT BELOW-------------//
	public int MapNumber = 2142069;
	public readonly int[] SkillOrder = { 3, 1, 2, 4 };
	public int SaveStateLoops = 8700;
	public int TurnInAttempts = 10;
	public string[] RequiredItems = { 
    //Q1Items
    "Shadowworn",
    "Empowered Essence",
    "Shadowscythe Venom Head",
    "Hollow Soul",
    //Q1Rewards
    "Dark Fragment",

    //Q2items
    "Doomatter ",
    "Shadow DoomReaver",
    "Worshipper of Doom",
    //Q2rewards
    "Doom Fragment",
    "Classic Hollowborn Doomknight",
    
    //Q3Items
    "Unidentified 25",
    "(Necro) Scroll of Dark Arts",
    "Royal ShadowScythe Blade",
    "Weapon Imprint",
    "Dark Fragment",
    "Doom Fragment",
    //Q3Rewards
    "Hollowborn Empress' Blade",
    "Hollowborn DoomBlade",

    //Q4Items
    "Dark Energy",
    "(Necro) Scroll of Dark Arts",
    "Bones from the Void Realm",
    "Doom Heart",
    "Weapon Imprint",
    "Desolich's Dark Horn",
    "Dark Fragment",
    "Doom Fragment",
    //Q4Rewards
    "Hollowborn DoomKnight",
    "Hollowborn Sepulchure's Helm",
    "Hollowborn Doom Shade",
    "Hollowborn Sword of Doom",
    //Q4RequiredItems
    "Hollowborn Shadow of Fate",
    "Lae's Hardcore Contract",
    "Necrotic Sword of Doom (Sword)",
    "Sepulchure's DoomKnight Armor",
    "Sepulchure's Original Helm",
    //ContractRequirements
    "Dried Slime",
    "Dragon Scale",
    "Soul Potion",
    "Human Soul",
    "Fallen Soul"
    };
    public string[] Q1Items = { 
    "Lae's Hardcore Contract",
    "Shadowworn",
    "Empowered Essence",
    "Shadowscythe Venom Head",
    "Hollow Soul",
    //Q1Rewards
    "Dark Fragment"
    };
    public string[] Q2Items = { 
    //Q2items
    "Lae's Hardcore Contract",
    "Doomatter ",
    "Shadow DoomReaver",
    "Worshipper of Doom",
    //Q2rewards
    "Doom Fragment",
    "Classic Hollowborn Doomknight"
    };
    public string[] Q3Items = { 
    //Q3Items
    "Lae's Hardcore Contract",
    "Unidentified 25",
    "(Necro) Scroll of Dark Arts",
    "Royal ShadowScythe Blade",
    "Weapon Imprint",
    "Dark Fragment",
    "Doom Fragment",
    //Q3Rewards
    "Hollowborn Empress' Blade",
    "Hollowborn DoomBlade"
    };
    public string[] Q4Items = { 
    //Q4Items
    "Dark Energy",
    "(Necro) Scroll of Dark Arts",
    "Bones from the Void Realm",
    "Doom Heart",
    "Weapon Imprint",
    "Desolich's Dark Horn",
    "Dark Fragment",
    "Doom Fragment",
    //Q4Rewards
    "Hollowborn DoomKnight",
    "Hollowborn Sepulchure's Helm",
    "Hollowborn Doom Shade",
    "Hollowborn Sword of Doom",
    //Q4RequiredItems
    "Hollowborn Shadow of Fate",
    "Lae's Hardcore Contract",
    "Necrotic Sword of Doom (Sword)",
    "Sepulchure's DoomKnight Armor",
    "Sepulchure's Original Helm"
    };
    public string[] ContractRequirements = {
    "Dried Slime",
    "Dragon Scale",
    "Soul Potion",
    "Human Soul",
    "Fallen Soul"
    };
    public string[] Contract = { "Lae's Hardcore Contract"};
    public string[] Q4RequiredItems = { 
    "Hollowborn Shadow of Fate",
    "Lae's Hardcore Contract",
    "Necrotic Sword of Doom (Sword)",
    "Sepulchure's DoomKnight Armor",
    "Sepulchure's Original Helm"
    };

	public string[] EquippedItems = { };
    
	//-----------EDIT ABOVE-------------//

    //info i need for script;
    //map; hollowdeep
    //quest ids; 
    //1. A Dark Knight - 8413
    //ADarkKnight();
    
    //2. A Dark Knight Rises - 8414
    // ADarkKnightRises();

    //3. A Dark Knight Falls - 8415
    //ADarkKnightFalls();

    //4. A Dark Knight ReTurns - 8416
    //ADarkKnightReTurns();

    //1. Now We're Talking! - 7556
    //nowweretalking();

    //4.1 Must be Level 100.
    //Must have the following items in your inventory:
    //Hollowborn Shadow of Fate
    //Lae's Hardcore Contract
    //Necrotic Sword of Doom (Sword)
    //Sepulchure's DoomKnight Armor
    //Sepulchure's Original Helm
    //Lae's Hardcore Contract

    //faction ank check
    //while (bot.Player.GetFactionRank("Evil") < 10)
    //if (bot.Player.Level < 100)



    


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

		while (!bot.ShouldExit())
		{
			while (!bot.Player.Loaded) { }
			
            Main();
		}
	}


    public void Main()
    {
        {
            CheckInv(ContractRequirements);
            {
            if(!bot.Inventory.Contains(" Lae's Hardcore Contract", 1)) nowweretalking();
            }

            if (bot.Player.GetFactionRank("Evil") < 10) EbilRep();

            if(bot.Player.Gold < 100000) Gold();
            if(!bot.Inventory.Contains("Dark Fragment", 300)) ADarkKnight();             
            if(!bot.Inventory.Contains("Doom Fragment", 300)) ADarkKnightRises();

           // CheckInv(Q4RequiredItems);
            //{
            //    if (bot.Player.Level < 100)
             //   {
            //        bot.Log($"[{DateTime.Now:HH:mm:ss}] Leveling to 100");			
            //        ItemFarm("Fire Dragon Scale", 5, true, true, 6294, "Fire Drakel", "firewar");
            //        ExitCombat();
            //        SafeQuestComplete(6294);					
           //     
           //     }
           // }
            
        }
        bot.Log($"[{DateTime.Now:HH:mm:ss}] Finished Farming The First 2 Quests");
		StopBot();
    }
    public void nowweretalking()
    {
        if (bot.Quests.IsAvailable(7556))
        {
            if (bot.Player.Level < 65)
                {
                    bot.Log($"[{DateTime.Now:HH:mm:ss}] Leveling to 100");			
                    ItemFarm("Fire Dragon Scale", 5, true, true, 6294, "Fire Drakel", "firewar");
                    ExitCombat();
                    SafeQuestComplete(6294);					
                
                }
            else
            if(!bot.Inventory.Contains("Soul Potion", 1))                
                {
                StopBot($"please do this manualy scripting this is a pain... thanks");
                }
            else
            if(bot.Inventory.Contains("Soul Potion", 1))
            { 
            ItemFarm("Human Soul", 50, false, true, 7556, "Lightguard Caster", "noxustower");
            ItemFarm("Fallen Soul", 13, false, true, 7556, "Undead Paladin", "doomwood");
            }
            SafeQuestComplete(8413);
            }

        }
    
    public void ADarkKnight()
    {
        while(!bot.Inventory.Contains("Dark Fragment", 300))
        {
        UnbankList(Q1Items);
        ItemFarm("Shadowworn", 1, false, true, 8413, "Shadow Lord", "shadowrealmpast");
        ItemFarm("Empowered Essence", 10, false, true, 8413, "Shadow Guardian|Shadow Warrior|Pure Shadowscythe", "shadowrealmpast");
		SafePurchase("Shadowscythe Venom Head", 1, "shadowfall", 89);
        ItemFarm("Hollow Soul", 10, false, true, 8413, "Hollowborn Sentinel", "shadowrealm");
        SafeQuestComplete(8413);
        }
        Main();
    }
    
    public void ADarkKnightRises()
    {
        while(!bot.Inventory.Contains("Doom Fragment", 300))
            {
            UnbankList(Q2Items);
            while(!bot.Inventory.Contains("Dark Fragment", 5)) ADarkKnight();
            ItemFarm("Doomatter", 10, false, true, 8414, "Enraged Vordred", "vordredboss");
            ItemFarm("Shadow DoomReaver", 1, false, true, 8414, "Shadow Lord", "shadowrealmpast");
            ItemFarm("Worshipper of Doom", 1, false, true, 8414, "Corrupted Luma", "lumafortress");
            if (bot.Player.IsMember)
            {
            ItemFarm("Ingredients?", 10, false, true, 8414, "Ultra Kathool", "ultravoid");
            }
            else
            if (!bot.Player.IsMember)
            {
            ItemFarm("Ingredients?", 10, false, true, 8414, "Binky", "doomvault");
            }
        SafeQuestComplete(8414);
        }
        Main();

    }
    
    public void ADarkKnightFalls()
    {
        UnbankList(Q3Items);
        // ItemFarm("thingname3", amnt, tempy1, true, 8415, "mobster", "placename");
        // ItemFarm("thingname3", amnt, tempy1, true, 8415, "mobster", "placename");
        // ItemFarm("thingname3", amnt, tempy1, true, 8415, "mobster", "placename");
        // ItemFarm("thingname3", amnt, tempy1, true, 8415, "mobster", "placename");
        // ItemFarm("thingname3", amnt, tempy1, true, 8415, "mobster", "placename");
        // ItemFarm("thingname3", amnt, tempy1, true, 8415, "mobster", "placename");
        SafeQuestComplete(8415);

    }
    
    public void ADarkKnightReTurns()
    {
        UnbankList(Q4Items);
        // ItemFarm("thingname4", amnt, tempy2, true, 8416, "mobster", "placename");
        // ItemFarm("thingname4", amnt, tempy2, true, 8416, "mobster", "placename");
        // ItemFarm("thingname4", amnt, tempy2, true, 8416, "mobster", "placename");
        // ItemFarm("thingname4", amnt, tempy2, true, 8416, "mobster", "placename");
        // ItemFarm("thingname4", amnt, tempy2, true, 8416, "mobster", "placename");
        // ItemFarm("thingname4", amnt, tempy2, true, 8416, "mobster", "placename");
        // ItemFarm("thingname4", amnt, tempy2, true, 8416, "mobster", "placename");
        // ItemFarm("thingname4", amnt, tempy2, true, 8416, "mobster", "placename");
        SafeQuestComplete(8416);

    }

    public void EbilRep()
	{
		bot.Log("Ebil Rep Start");
		while (bot.Player.GetFactionRank("Evil") < 10)
            {
				bot.Log("EbilRep Start");
                ItemFarm("Youthanize", 1, true, true, 364, "slime", "swordhavenbridge");
				SafeQuestComplete(364);
				// ItemFarm("ItemName", Amount, temp, hunt, Questbit, "monster", "mapname");
			}
            Main();
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

    public void Gold()
    {
    while(bot.Player.Gold < 100000) //20 turn ins
        {
        bot.Log("GoldFarm");
        ItemFarm("Were Egg", 1, true, true, 236, "Big Bad Boar", "greenguardwest");
        bot.Log("GoldTurnIn");
        SafeQuestComplete(236);
        bot.Sleep(1000);
        bot.Log("GoldSell");					
        SafeSell("Berserker Bunny", 0);
        }
    }

	public void Relogin()
			{
				bot.Options.AutoRelogin = false;
				bot.Sleep(10000);
				bot.Player.Logout();
				bot.Sleep(10000);
       			bot.Player.Login(bot.Player.Username, bot.Player.Password);
        		RBot.Servers.Server server = bot.Options.AutoReloginAny ? RBot.Servers.ServerList.Servers.Find(x => x.IP != RBot.Servers.ServerList.LastServerIP) : bot.Options.LoginServer ?? RBot.Servers.ServerList.Servers[0];
        		bot.Player.Connect(server);
        		while (!bot.Player.LoggedIn) { bot.Sleep(2500); }
				bot.Sleep(10000);
				bot.Options.AutoRelogin = true;
				bot.Sleep(10000);
				Main();
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
					bot.Options.AggroMonsters = false;
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
					bot.Options.AggroMonsters = false;
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
					bot.Options.AggroMonsters = false;
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
					bot.Options.AggroMonsters = false;
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
		bot.Options.AggroMonsters = false;
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