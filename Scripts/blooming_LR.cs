using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using RBot;
using RBot.Options;
using RBot.Skills.UseRules;

// DO NOT EDIT ANYTHING. JUST RUN THE BOT. YOU'LL EDIT THE SETTINGS IN THE UI
// DO NOT EDIT ANYTHING. JUST RUN THE BOT. YOU'LL EDIT THE SETTINGS IN THE UI
// DO NOT EDIT ANYTHING. JUST RUN THE BOT. YOU'LL EDIT THE SETTINGS IN THE UI
// DO NOT EDIT ANYTHING. JUST RUN THE BOT. YOU'LL EDIT THE SETTINGS IN THE UI
// DO NOT EDIT ANYTHING. JUST RUN THE BOT. YOU'LL EDIT THE SETTINGS IN THE UI

/// <summary>
/// The Data structure for a skill. MUST HAVE
/// </summary>
public class DataSkill {
   public string Type;
   public int Index;
   public int sValue;

   public DataSkill(string Type, int Index=0, int sValue=0) {
      this.Type = Type;
      this.Index = Index-1;
      this.sValue = sValue;
   }
}

public class DataRun {

	public string RunType;
	public string ClassType;
	public string Map;
	public string Cell;
	public string Pad;
	public int QuestID;
	public string Item;
	public int Qty;
	public bool isTemp=false;
	public bool UseBoss=false;
	public string Monster="*";

	/// <summary>Data structure for QuestBolt </summary>
	/// <param name="ClassType"> The ClassType to use </param>
	/// <param name="Map"> The Map to use </param>
	/// <param name="Cell"> The Cell to use </param>
	/// <param name="Pad"> The pad to use </param>
	/// <param name="QuestID"> 0 by default </param>
	/// <param name="Item"> Empty by default </param>
	/// <param name="Qty"> 1 by default </param>
	/// <param name="isTemp"> false by default </param>
	/// <param name="UseBoss"> 1 by default. Refers whether to use boss map number </param>
	/// <param name="Monster"> * by default </param>
	public DataRun(string ClassType, string Map, string Cell, string Pad, int QuestID=0, string Item="", int Qty=1, bool isTemp=false, bool UseBoss=false, string Monster="*") {
		this.ClassType = ClassType;
		this.Map = Map;
		this.Cell = Cell;
		this.Pad = Pad;
		this.QuestID = QuestID;
		this.Item = Item;
		this.Qty = Qty;
		this.isTemp = isTemp;
		this.UseBoss = UseBoss;
		this.Monster = Monster;

		if (QuestID == 0) {
			this.RunType = "item";
		} else {
			this.RunType = "quest";
		}
	}
}

// DataRun(RunType:"", ClassType:"", Map:"", Cell:"", Pad:"", QuestID:"", Item:"", Qty:"",  isTemp:"", UseBoss:"", Monster:"",)

public class Engine {

   /// ================================================ ///
   ///            Essential Variable Section 
   /// ================================================ ///

	public ScriptInterface bot => ScriptInterface.Instance;
	public bool DebugMode = false;
	public string ServerName;


   // Setup Variables
   public int MapNumber;
   public int MapNumberBoss;

   // Skill Variables
   public bool EnableSkillRun = true;
   public int SkillWait = 0;

   // Army Settings
   public bool ArmySync;
   public int ArmyCount;
   public int ArmyWait;

   /// ================================================ ///
   ///                  Function Section 
   /// ================================================ ///

   /// <summary>Equips an item.</summary>
   public void SafeEquip(string ItemName) {
      while (InvHas(ItemName) && !bot.Inventory.IsEquipped(ItemName)) {
         ExitCombat();
         bot.Player.EquipItem(ItemName);
      }
   }



   /// <summary>Converts Skill string input into an int List</summary>
   public void SkillConvert(IDictionary<string, List<DataSkill>> Skillset) {
      List<int> result = new List<int>();
      foreach(KeyValuePair<string, List<DataSkill>> kvp in Skillset) {
         // bot.Log(kvp.Value);
         foreach(string a in bot.Config.Get<string>(kvp.Key).Split(',')) {
            string raw = a.Trim();
            if (string.IsNullOrEmpty(raw)) continue;
            if (raw.Contains("w")) {
               kvp.Value.Add(new DataSkill("w", sValue:GetNumbers(raw)) );
               continue;
            }
            if (raw.Contains("h") && raw.Contains(">")) {
               result = SplitInt(raw, '>');
               bot.Log($"{kvp.Key}");
               kvp.Value.Add(new DataSkill("h>", Index:result[1], sValue:result[0]) );
               continue;
            }
            if (raw.Contains("h") && raw.Contains("<")) {
               result = SplitInt(raw, '<');
               kvp.Value.Add(new DataSkill("h<", Index:result[1], sValue:result[0]) );
               continue;
            }
            if (raw.Contains("m") && raw.Contains(">")) {
               result = SplitInt(raw, '>');
               kvp.Value.Add(new DataSkill("m>", Index:result[1], sValue:result[0]) );
               continue;
            }
            if (raw.Contains("m") && raw.Contains("<")) {
               result = SplitInt(raw,'<');
               kvp.Value.Add(new DataSkill("m<", Index:result[1], sValue:result[0]) );
               continue;
            }
            try {
               kvp.Value.Add(new DataSkill("s", Index:int.Parse(raw)));
            } catch { }
            continue;
         }
      }
      


   }

   /// <summary>Starts attacking the target</summary>
   /// <param name="SkillSet">The skillset int list</param>
   public void SkillActivate(List<DataSkill> SkillSet, string MonsterTarget="*") {
      if (!EnableSkillRun) return;
      EnableSkillRun = false;

      if (bot.Monsters.Exists(MonsterTarget)) {
         bot.Player.Attack(MonsterTarget);
      } else {
         bot.Player.Attack("*");
      }

      foreach (DataSkill data in SkillSet) {
         bot.Log($"Type: {data.Type}  |  Index {data.Index}  |  sValue  {data.sValue}");
         switch(data.Type) {
            case "s":
               bot.Player.UseSkill(data.Index); 
               if (SkillWait  != 0) bot.Sleep(SkillWait); 
               continue;
            case "w":
               bot.Sleep(data.sValue);
               continue;
            case "h>":
               if (bot.Player.Health > data.sValue) {
                  bot.Player.UseSkill(data.Index); 
                  if (SkillWait  != 0) bot.Sleep(SkillWait); 
               }
               continue;
            case "h<":
               if (bot.Player.Health < data.sValue) {
                  bot.Player.UseSkill(data.Index); 
                  if (SkillWait  != 0) bot.Sleep(SkillWait); 
               }
               continue;
            case "m>":
               if (bot.Player.Mana > data.sValue) {
                  bot.Player.UseSkill(data.Index); 
                  if (SkillWait  != 0) bot.Sleep(SkillWait); 
               }
               continue;
            case "m<":
               if (bot.Player.Mana < data.sValue) {
                  bot.Player.UseSkill(data.Index); 
                  if (SkillWait  != 0) bot.Sleep(SkillWait); 
               }
               continue;
         }

      }
      EnableSkillRun = true;
   }

   public virtual void SkillUse(string skill, string MonsterTarget="*") {}

   public void SafeMapJoin(string MapName, string Cell="Enter", string Pad="Spawn", bool UseBoss=false, int CustomMap=0, bool EnableArmyHere=false) {
      //Must have the following functions in your script:
      //ExitCombat
      string mapname = MapName.ToLower();
      int number = 1;
      if (CustomMap == 0) {
         switch(UseBoss) {
            case true: number = MapNumberBoss; break;
            case false: number = MapNumber; break;
         }
      } else { number = CustomMap; }
         
      while (bot.Map.Name != mapname) {
         ExitCombat();
         if (mapname == "tercessuinotlim") bot.Player.Jump("m22", "Center");
         bot.Player.Join($"{mapname}-{number}", Cell, Pad);
         bot.Wait.ForMapLoad(mapname);
         bot.Sleep(500);
      }


      if (ArmySync && EnableArmyHere) {
      	ExitCombat();
      	int time_left = 0;
      	while (time_left < ArmyWait) {
      		if (bot.Map.PlayerCount >= ArmyCount) break;
      		time_left += 1;
      		Message($"Waiting for army. {time_left}s/{ArmyWait}s");
      		bot.Sleep(1000);
      	}
      }
      

      if (bot.Player.Cell != Cell) bot.Player.Jump(Cell, Pad);
      bot.Log($"[{DateTime.Now:HH:mm:ss}] Joined map {mapname}-{number}, positioned at the {Pad} side of cell {Cell}.");

   }


   /// <summary> Also Banks useless AC Items.</summary>
   public void AddToDrops(params string[] Items) {
      
      ExitCombat();

      // Declares AC items to bank
      string[] Whitelisted = {"Note", "Item", "Resource", "QuestItem", "ServerUse"};
      
      // Banks unneeded items that are included in the whitelisted
      foreach(var item in bot.Inventory.Items) {
         if (!Whitelisted.Contains(item.Category.ToString())) continue;
         if (item.Name != "Treasure Potion" && item.Coins && !Array.Exists(Items, x => x == item.Name)) bot.Inventory.ToBank(item.Name);
      }
      // Adds to drops
      foreach (string item in Items) bot.Drops.Add(item);
   }

   /// <summary> Pure Unbank</summary>
   public void Unbank(params string[] Items) {
      ExitCombat();

      bot.Player.LoadBank();
      bot.Sleep(500);

      // Unbanks the required items
      foreach (string item in Items) {
         if (bot.Bank.Contains(item)) {
            bot.Bank.ToInventory(item);
            Message($"Unbanked: {item}");
         } 
      }

   }

   /// <summary> Banks items </summary>
   public void Bank(params string[] Items) {
      // Safe Loading
      ExitCombat();
      bot.Player.LoadBank();

      // Unbanks the required items
      foreach (string item in Items) {
         if (InvHas(item)) bot.Inventory.ToBank(item);
      }

   }


   /// <summary> Leaves Combat</summary>
   public void ExitCombat() {
      bot.Options.AggroMonsters = false;
      bot.Player.Jump("Wait", "Spawn");
      while (bot.Player.State == 2) { }
      bot.Sleep(500);
   }

   /// <summary> Sends moderator message form</summary>
   public void Message(string message) {
      bot.SendClientPacket($"%xt%chatm%69061%moderator~{message}%Bloom%25810%69061%0%", "str");

   }



   public void QuestRun(string ClassType, string Map, string Cell, string Pad, int QuestID,  bool UseBoss=false, string Monster="*", bool EnableArmyHere=false) {

   	if (bot.Map.Name != Map) SafeMapJoin(Map, Cell, Pad, EnableArmyHere:EnableArmyHere);
      
      bot.Quests.EnsureAccept(QuestID);
      
      while (!bot.Quests.CanComplete(QuestID)) {
            if (bot.Player.Cell != Cell) bot.Player.Jump(Cell, Pad);
            SkillUse(ClassType, Monster);
         }

      ExitCombat();
      while (bot.Quests.CanComplete(QuestID)) bot.Quests.Complete(QuestID);
   }



   public void QuestBolt(int QuestID, string Item, int Qty, List<DataRun> QuestRuns, bool isTemp=false, bool EnableArmyHere=false) {
   	ExitCombat();

   	while (!InvHas(Item, Qty, isTemp)) {

	   	bot.Quests.EnsureAccept(QuestID);

	      foreach(DataRun data in QuestRuns) {
	      	switch(data.RunType) {
	      		case "item":
	      			if (!InvHas(data.Item, data.Qty, data.isTemp)) {
	      				ItemRun(data.ClassType, data.Map, data.Cell, data.Pad, data.Item, data.Qty, data.isTemp, data.UseBoss, data.Monster, EnableArmyHere);
	      			}
	      			break;
	   			case "quest":
	   				if (data.Item != "") {
	   					while(!InvHas(data.Item, data.Qty, data.isTemp)) {
	   						QuestRun(data.ClassType, data.Map, data.Cell, data.Pad, data.QuestID,  data.UseBoss, data.Monster, EnableArmyHere);
	   					}
	   					return;
	   				} else {
	   					QuestRun(data.ClassType, data.Map, data.Cell, data.Pad, data.QuestID,  data.UseBoss, data.Monster, EnableArmyHere);
	   					return;
	   				}


	      	}
	      }

	      ExitCombat();

	      bot.Quests.Complete(QuestID);
   	}
   }


   public void ItemRun(string ClassType, string Map, string Cell, string Pad, string Item, int Qty, bool isTemp=false, bool UseBoss=false, string Monster="*", bool EnableArmyHere=false) {

      if (bot.Map.Name != Map) SafeMapJoin(Map, Cell, Pad, UseBoss, EnableArmyHere:EnableArmyHere);

      while (!InvHas(Item, Qty, isTemp)) {
         if (bot.Player.Cell != Cell) bot.Player.Jump(Cell, Pad);
         SkillUse(ClassType, Monster);
      }

      ExitCombat();
   }


   public void BuyRun(string Item, int Qty, int Shop, string Map, string Cell, string Pad, int Gold){
      ExitCombat();
      Unbank(Item);
      if (InvHas(Item)) return;
      if (bot.Player.Gold < Gold) GetGold(Gold);

      SafeMapJoin(Map, Cell, Pad, false, 99999);
      bot.Sleep(2500);
      bot.Shops.Load(Shop);
      bot.Sleep(3000);
      bot.Shops.BuyItem(Item);
      bot.Sleep(2500);
   }

   public void GetGold(int Qty, string Cell="", string Pad="") {
      SafeMapJoin("icestormarena", "Enter", "Spawn", false, 1);
      // Under level
      if (bot.Player.Level < 50) {
         Cell = "r4";
         Pad = "Bottom";
      }
      // Mid level
      if (bot.Player.Level >= 50 && bot.Player.Level < 75) {
         Cell = "r3b";
         Pad = "Top";
      }
      // High level
      if (bot.Player.Level >= 75) {
         Cell = "r3c";
         Pad = "Top";
      }
      while (bot.Player.Gold < Qty) {
         if (bot.Player.Cell != Cell) bot.Player.Jump(Cell, Pad);
         if (Cell == "r4") bot.SendPacket("%xt%zm%aggroMon%134123%70%71%72%73%74%75%");
         SkillUse("farm");
      }
      return;

   }


   /// ================================================ ///
   ///                  Shortened Section 
   /// ================================================ ///
   public bool InvHas(string item, int Qty=1, bool IsTemp=false) {
      if (!IsTemp) {
         return bot.Inventory.Contains(item, Qty);
      } else {
         return bot.Inventory.ContainsTempItem(item, Qty);
      }
      
   }

   public bool BankHas(string item, int Qty=1) {
      return bot.Bank.Contains(item, Qty);
   }


   /// ================================================ ///
   ///                  Utility Section 
   /// ================================================ ///

   /// <summary>
   /// Cleans a string of non-numerics and returns an integer
   /// </summary>
   /// <param name="delim">string to extract ints from</param>
   public int GetNumbers(string input) {
      return int.Parse(Regex.Replace(input, @"[^\d]+", "\n").Trim());
   }

   /// <summary>
   /// Extracts only the integers in a string
   /// </summary>
   /// <param name="input">string to split and extract ints from</param>
   /// <param name="delim">the delimeter char</param>
   public List<int> SplitInt(string input, char delim) {
      List<int> result = new List<int>();
      foreach(string health_item in input.Split(delim)) {
         result.Add(GetNumbers(health_item));
      }
      if (result.Count != 2) {
         result.Add(0);
      }
      return result;
   }

}



public class Script: Engine {

   // Default variables
   public bool PrefarmMode;
   public bool UsePotions;
   public bool DefaultFB;
   public bool DefaultDOT;

   // Class & Skill variables
   public string ClassFarm;
   public string ClassSolo;
   public string ClassTethered;
   public string ClassFrostval = "Frostval Barbarian";
   public string ClassDragonOfTime = "Dragon of Time";
   public List<DataSkill> SkillFarm = new List<DataSkill>();
   public List<DataSkill> SkillSolo = new List<DataSkill>();
   public List<DataSkill> SkillTethered = new List<DataSkill>();
   public List<DataSkill> SkillDragonOfTime = new List<DataSkill>();
   public List<DataSkill> SkillFrostval = new List<DataSkill>();

   // Booster variables
   public string BoostUndead;
   public string BoostMonster;

   // Option variables
   public string OptionsStorage = "Legion Revenant";
   public bool DontPreconfigure = true;
   public List<IOption> Options = new List<IOption>() {
      new Option<string>("‎space0", "『 Metadata 』", "Bot info.\n(This is just a section header).", ""),
      new Option<string>("author", "Author", "The creator of this bot is bloom.", "Bloom", true),
      new Option<string>("version", "Version", "The bot version.", "v.1.0.0", true),
      new Option<string>("findus", "Find Us", "Join us on discord if you have any question. You can find more bots in the portal link.", "https://auqw.tk/", true),
      new Option<string>("‎space1", " ", "", ""),

      new Option<string>("‎space2", "『 Setting 』", "The Setting Section.\n(This is just a section header).", ""),
      new Option<bool>("preFarm", "Prefarm Mode", "Prefarm every possible item you can get without being part of Legion", false),
      new Option<int>("map", "Map", "Map number to join into.", 9999),
      new Option<int>("mapBoss", "Boss Map", "The Boss Map number to join into.", 1),
      new Option<bool>("usePotions", "Use Potions", "Whether to buy and use potions.\nTrue -> Will use. False -> Will not use.", true),
      new Option<bool>("defaultFB", "Use FB by default", "If you have Frostval barbarian, will use it by default.\nTrue -> Will use. | False -> Will not use.", true),
      new Option<bool>("defaultDOT", "Use DoT by default", "If you have Dragon of Time, will use it by default.\nTrue -> Will use. | False -> Will not use.", false),
      new Option<GoldFarmEnum>("goldFarm", "Gold Farm Area", "Set to private or public.", GoldFarmEnum.Public),
      new Option<string>("‎space3", " ", "", ""),

      new Option<string>("‎space4", "『 Boosters 』", "The Item Booster Section.\n(This is just a section header).", ""),
      new Option<string>("‎boostUndead", "Undead Boosters", "List of items to boost undead damage. Separate by comma.\nExample -> Blinding Light of Destiny, Sepulchure's Armor, etc...", "Blinding Light of Destiny"),
      new Option<string>("‎boostMonster", "Monster Boosters", "List of items to boost all monster damage. Separate by comma.\nExample -> Necrotic Sword of Doom, Sepulchure's Armor, etc...", "Necrotic Sword of Doom"),
      new Option<string>("‎space5", " ", "", ""),

      new Option<string>("‎space6", "『 Classes 』", "The Class Section.\n(This is just a section header).", ""),
      new Option<int>("skillWait", "Skill Wait", "Inherent wait between skills in ms. Example -> 500", 0), 
      new Option<string>("classFarm", "Farming Class", "Class for Farming.\nExample -> Legion Revenant", "Legion Revenant"),
      new Option<string>("skillFarming", "Farming Skills", "Farming Skillset. Use -> [1, 2, 3, 4, 5, 6] just like the aqw UI skill keys. Add wNumber to delay before executing a skill. Time is in ms, minimum of 10ms. Example -> 5,4,w800,1", "1,2,3,4,5"),
      new Option<string>("classSolo", "Soloing Class", "Class for Soloing.\nExample -> Vindicator of Gay", "Legion Revenant"),
      new Option<string>("skillSoloing", "Soloing Skills", "Soloing Skillset. Use -> [1, 2, 3, 4, 5, 6] just like the aqw UI skill keys. Add wNumber to delay before executing a skill. Time is in ms, minimum of 10ms. Example -> 5,4,w800,1", "1,2,3,4,5"),
      new Option<string>("classTethered", "Tethered Class", "Class for Tethered Souls Farming.\nExample -> Vindicator of Gay", "Legion Revenant"),
      new Option<string>("skillTethered", "Tethered Skills", "Tethered Skillset. Use -> [1, 2, 3, 4, 5, 6] just like the aqw UI skill keys. Add wNumber to delay before executing a skill. Time is in ms, minimum of 10ms. Example -> 5,4,w800,1", "1,2,3,4,5"),
      new Option<string>("‎space7", " ", "", ""),

      new Option<string>("‎space8", "『 Default Classes 』", "The Default Class Section. This will be used if you have it.\n(This is just a section header).", ""),
      new Option<string>("skillFrosval", "Frostval Barbarian Skills", "FB Skillset. Use -> [1, 2, 3, 4, 5, 6] just like the aqw UI skill keys. Add wNumber to delay before executing a skill. Time is in ms, minimum of 10ms. Example -> 5,4,w800,1", "1,5"),
      new Option<string>("skillDragonOfTime", "Dragon of Time Skills", "Dragon of Time Skillset. Use -> [1, 2, 3, 4, 5, 6] just like the aqw UI skill keys. Add wNumber to delay before executing a skill. Time is in ms, minimum of 10ms. Example -> 5,4,w800,1", "1,2,3,4,5"),
      new Option<string>("‎space9", " ", "", ""),

      new Option<string>("‎space10", "『 Army 』", "The Army Section.\n(This is just a section header).", ""),
      new Option<bool>("armySync", "Army Sync", "The Army Sychronizer. Will wait a certain amount of time after each map join.\n True -> enable | False -> disable", false),
      new Option<int>("armyCount", "Army Count", "The amount of character (including the main player) to wait before the bot proceeds. If these amount are not met after n amount of time, bot will proceed.", 3),
      new Option<int>("armyWait", "Army Wait", "Amount of time to wait for the characters to gather. If after this amount of time (in secs) passed by and the characters haven't gathered, bot will move on.", 30),
   };
 

   /// <summary> Main body of the bot </summary>
   public void ScriptMain(ScriptInterface bot) {
      bot.Config.Configure();
      AutoRelog();
   	while (!bot.Player.Loaded) {}

   	// Initial
      Message("Starting bot");
      ExitCombat();

		// Setups bot
      Configurations();
      LoadReqs();
      LoadVars();
      LoadDrops();

      bot.Events.PlayerDeath += b => {
          Manager();
      };

      /// <remark> Main Unbank </remark>
      Message("Unbanking main Items");
      Unbank(ClassFarm, ClassSolo, ClassTethered, ClassFrostval, ClassDragonOfTime);
      Unbank("Revenant's Spellscroll", "Conquest Wreath", "Exalted Crown");

      /// <remark> Main Check </remark>
      Manager();
   }

   public void Manager() {
      
      Message("Checking your progress");
      UpdateProgress();
      // QuestLegionFealty2(20);

      if (bot.Player.GetFactionRank("Evil") < 10) GetReputationEvil();
      if (!InvHas("Revenant's Spellscroll", 10)) QuestLegionFealty1(10);
      if (!InvHas("Conquest Wreath", 20)) QuestLegionFealty2(20);
      if (!InvHas("Exalted Crown", 6)) QuestLegionFealty3(6);

      /// <remark> Complete </remark>
      SafeMapJoin("revenant", "Enter", "Spawn", false, 99999);
      bot.Sleep(1500);
      Bank(AllLegionItems);
      bot.Sleep(1500);
      bot.Quests.EnsureComplete(6900);
      bot.Sleep(2000);
      SafeEquip("Legion Revenant");
      SafeMapJoin("freakitiki", "Enter", "Spawn", false, 99999);
      return;
   }

   /// <summary>Bot Options</summary>
   public void Configurations() {
   	if (bot.Map.Name == "battleon") SafeMapJoin("yulgar", "Enter", "Spawn", false, 9999);

      bot.Options.CustomName = "Groomed By Bloom";
      bot.Options.CustomGuild = "<AutisticQuest Worlds>";
      bot.Options.SafeTimings = true;
      bot.Options.RestPackets = true;
      bot.Options.PrivateRooms = true;
      bot.Options.InfiniteRange = true;
      bot.Options.PrivateRooms = false;
      bot.Options.SkipCutscenes = true;
      bot.Options.DisableFX = true;
      bot.Options.AggroMonsters = false;
      bot.Options.AutoRelogin = true;
      bot.Options.LagKiller = true;
      bot.Lite.DisableSkillAnimations = true;
      bot.Lite.CustomDropsUI = false;

   }

   /// <summary>Loads Banks and quests</summary>
   public void LoadReqs() {
      // Loads Quests
      bot.Quests.Load(6897, 6898, 6899, 6900, 4743, 4742, 364);
      bot.Sleep(1500);
   }

   /// <summary>Gets variables and assigns them</summary>
   public void LoadVars() {
      // System Setups
      ServerName = bot.Player.ServerIP.Split('.')[0];

      // Var setups
      MapNumber = bot.Config.Get<int>("map");
      MapNumberBoss = bot.Config.Get<int>("mapBoss");

      PrefarmMode = bot.Config.Get<bool>("preFarm");
      UsePotions  = bot.Config.Get<bool>("usePotions");
      DefaultFB  = bot.Config.Get<bool>("defaultFB");
      DefaultDOT  = bot.Config.Get<bool>("defaultDOT");

      // Army Settings
      ArmySync = bot.Config.Get<bool>("armySync");
      ArmyCount = bot.Config.Get<int>("armyCount");
      ArmyWait = bot.Config.Get<int>("armyWait");

      // Class setups
      ClassFarm = bot.Config.Get<string>("classFarm");
      ClassSolo = bot.Config.Get<string>("classSolo");
      ClassTethered = bot.Config.Get<string>("classTethered");

      /// Class Checks Defaults
      if (DefaultFB) {
         if (!InvHas(ClassFrostval)) DefaultFB = false;
      }
      if (DefaultDOT) {
         if (!InvHas(ClassDragonOfTime)) DefaultDOT = false;
      }

      // Skill setups
		SkillConvert(new Dictionary<string, List<DataSkill>>(){
         {"skillFarming", SkillFarm},
         {"skillSoloing", SkillSolo},
         {"skillTethered", SkillTethered},
         {"skillFrosval", SkillFrostval},
         {"skillDragonOfTime", SkillDragonOfTime},
      });
      SkillWait = bot.Config.Get<int>("skillWait");

      // Booster setups
      BoostMonster = bot.Config.Get<string>("‎boostMonster");
      BoostUndead = bot.Config.Get<string>("‎boostUndead");
   }


   public void LoadDrops() {

   	Message("Adding all needed items to drop list and banking unncessary AC items.");
      // Unbank Drop list
      AddToDrops(AllLegionItems);
      
      bot.Lite.CustomDropsUI = false;
      bot.Drops.RejectElse = true;
      bot.Drops.Start();

   }

   /// <summary>Chooses which skill to use</summary>
   /// <param name="skill">The skill name</param>
   public override void SkillUse(string skill, string MonsterTarget="*") {

      if (skill == "farm-fb" && DefaultFB) {
         SafeEquip(ClassFrostval);
         SkillActivate(SkillFrostval);
         return;
      } else if (skill == "solo-dot" && DefaultDOT){
         SafeEquip(ClassDragonOfTime);
         SkillActivate(SkillDragonOfTime);
         return;
      } 

      if (EnableSkillRun == false) return;
      switch(skill) {
         case "farm":
         case "farm-fb":
            SafeEquip(ClassFarm);
            SkillActivate(SkillFarm);
            return;
         case "solo":
         case "solo-dot":
            SafeEquip(ClassSolo);
            SkillActivate(SkillSolo);
            return;
         case "tethered":
            SafeEquip(ClassTethered);
            SkillActivate(SkillTethered);
            return;
         case "frostval":
            SafeEquip(ClassFrostval);
            SkillActivate(SkillFrostval);
            return;
         case "dragonoftime":
            SafeEquip(ClassDragonOfTime);
            SkillActivate(SkillDragonOfTime);
            return;
      }
   }


   public void UpdateProgress() {
   	int rev = bot.Inventory.GetQuantity("Revenant's Spellscroll");
   	int con = bot.Inventory.GetQuantity("Conquest Wreath");
   	int exa = bot.Inventory.GetQuantity("Exalted Crown");
   	double percent = ((rev+con+exa)/36.0)*100;
   	Message($"Your current Revenant progress: {percent:.##}%");
   }



   /// ================================================ ///
   ///                  Prereqs Section 
   /// ================================================ ///
   public class Prereqs {}

   public void GetReputationEvil() {
      while ((bot.Player.GetFactionRank("Evil") < 10)) {
         QuestRun("farm", "newbie", "r2", "Left", 364);
      }

   }
   public void StoryWorldSoul() {}

   public void StoryNecrodungeon() {}

   public void StoryCruxShip() {}

   /// ================================================ ///
   ///                  Quests Section 
   /// ================================================ ///
   public class Quests {}


   public void QuestLegionFealty1(int Qty) {
      Message("[Quest] 1/3 - Starting Legion Fealty 1");
      // Safespace
      ExitCombat();

      // Unbanks
      Unbank(UnbankLegionFeality1);

      // Banks
      Bank(BankLegionFealty1);

      // Accepts
      bot.Quests.EnsureAccept(6897);

      /// Main Checks
      while(!InvHas("Revenant's Spellscroll", Qty)) {
         if (!InvHas("Aeacus Empowered", 50)) {
            SafeEquip(BoostUndead);
            ItemRun("solo-dot", "judgement", "r10a", "Left", "Aeacus Empowered", 50, false, true, EnableArmyHere:true);
         }
         if ((!InvHas("Tethered Soul", 300)) && !PrefarmMode) {
            SafeEquip(BoostMonster);
            GetDarkCasterClass();
            ItemRun("tethered", "revenant", "r2", "Left", "Tethered Soul", 300, false, true, EnableArmyHere:true);
         }
         if (!InvHas("Darkened Essence", 500)) {
            SafeEquip(BoostMonster);
            ItemRun("farm", "shadowrealmpast", "Enter", "Spawn", "Darkened Essence", 500, false, true, EnableArmyHere:true);
         }
         if (!InvHas("Dracolich Contract", 1000)) {
            SafeEquip(BoostUndead);
            ItemRun("farm", "necrodungeon", "r22", "Down", "Dracolich Contract", 1000, false, true, EnableArmyHere:true);
         }

         // Complete
         ExitCombat();
         if (DebugMode) return;
         bot.Sleep(2000);
         bot.Quests.EnsureComplete(6897);
         bot.Sleep(2000);
         UpdateProgress();
      }


   }

   public void QuestLegionFealty2(int Qty) {
   	Message("[Quest] 2/3 - Starting Legion Fealty 2");

      // Safespace
      ExitCombat();

      // Banks
      Bank(BankLegionFealty2);

      // Unbanks
      Unbank(UnbankLegionFeality2);
      
      SafeEquip(BoostUndead);

      // Accepts
      bot.Quests.EnsureAccept(6898);


      // Main Check
      while(!InvHas("Conquest Wreath", Qty)) {
         if (!InvHas("Grim Cohort Conquered", 500)) {
            ItemRun("farm-fb", "doomvault", "r1", "Left", "Grim Cohort Conquered", 500, false, false, EnableArmyHere:true);
         }
         if (!InvHas("Ancient Cohort Conquered", 500)) {
            ItemRun("farm", "mummies", "Enter", "Spawn", "Ancient Cohort Conquered", 500, false, false, EnableArmyHere:true);
         }
         if (!InvHas("Pirate Cohort Conquered", 500)) {
            ItemRun("farm", "wrath", "r4", "Left", "Pirate Cohort Conquered", 500, false, false, EnableArmyHere:true);
         }
         if (!InvHas("Battleon Cohort Conquered", 500)) {
            ItemRun("farm", "doomwar", "r11", "Left", "Battleon Cohort Conquered", 500, false, false, EnableArmyHere:true);
         }
         if (!InvHas("Mirror Cohort Conquered", 500)) {
            ItemRun("farm-fb", "overworld", "r2", "Down", "Mirror Cohort Conquered", 500, false, false, EnableArmyHere:true);
         }
         if (!InvHas("Darkblood Cohort Conquered", 500)) {
            ItemRun("farm-fb", "deathpits", "r1", "Left", "Darkblood Cohort Conquered", 500, false, false, EnableArmyHere:true);
         }
         if (!InvHas("Vampire Cohort Conquered", 500)) {
            ItemRun("farm", "maxius", "r2", "Left", "Vampire Cohort Conquered", 500, false, false, EnableArmyHere:true);
         }
         if (!InvHas("Spirit Cohort Conquered", 500)) {
            ItemRun("farm", "curseshore", "Enter", "Spawn", "Spirit Cohort Conquered", 500, false, false, EnableArmyHere:true);
         }
         if (!InvHas("Dragon Cohort Conquered", 500)) {
            ItemRun("farm-fb", "dragonbone", "Enter", "CenterA", "Dragon Cohort Conquered", 500, false, false, EnableArmyHere:true);
         }
         if (!InvHas("Doomwood Cohort Conquered", 500)) {
            ItemRun("farm-fb", "doomwood", "r6", "Right", "Doomwood Cohort Conquered", 500, false, false, EnableArmyHere:true);
         }
         // Complete
         ExitCombat();
         if (DebugMode) return;
         bot.Sleep(2000);
         bot.Quests.EnsureComplete(6898);
         bot.Sleep(2000);
         UpdateProgress();
      }

   }


   public void QuestLegionFealty3(int Qty) {
   	Message("(Quest) 3/3 - Starting Legion Fealty 3");

      // Safespace
      ExitCombat();
  
      // Unbanks
      Unbank(UnbankLegionFeality3);

      // Banks
      Bank(BankLegionFealty3);

      // Accepts
      bot.Quests.EnsureAccept(6899);

      SafeEquip(BoostMonster);

      while(!InvHas("Exalted Crown", Qty)) {

         if (!InvHas("Hooded Legion Cowl", 1)) {
            BuyRun("Hooded Legion Cowl", 1, 216, "underworld", "s1", "Left", 500000);
         }
         if (!InvHas("Legion Token", 4000)) {
            GetLegionToken(4000);
         }  
         if (!InvHas("Dage's Favor", 300)) {
            ItemRun("farm", "evilwardage", "r8", "Left", "Dage's Favor", 303, false, false);
         }
         while (!InvHas("Emblem of Dage", 1)) {
            QuestRun("farm", "shadowblast", "r10", "Left", 4742,  false);
         }
         if (!InvHas("Diamond Token of Dage", 30)) {
		      QuestBolt(QuestID:4743, Item:"Diamond Token of Dage", Qty:30, EnableArmyHere:true, QuestRuns: new List<DataRun>(){
					new DataRun("farm-fb", "tercessuinotlim", "m2", "Spawn", Item:"Defeated Makai", Qty:25),
					new DataRun("solo", "aqlesson", "Frame9", "Right", Item:"Carnax Eye", isTemp:true, UseBoss:true),
					new DataRun("solo", "deepchaos", "Frame4", "Left", Item:"Kathool Tentacle", isTemp:true, UseBoss:true),
					new DataRun("solo", "lair", "End", "Right", Item:"Red Dragon's Fang", isTemp:true, UseBoss:true),
					new DataRun("solo", "dflesson", "r12", "Right", Item:"Fluffy's Bones", isTemp:true, UseBoss:true),
					new DataRun("solo", "bloodtitan", "Enter", "Spawn", Item:"Blood Titan's Blade", isTemp:true, UseBoss:true),
		      });
         }
         while (!InvHas("Dark Token", 100)) {
            QuestRun("farm", "seraphicwardage", "Enter", "Spawn", 6248, false, EnableArmyHere:true);
         }

         ExitCombat();
         if (DebugMode) return;
         bot.Sleep(2000);
         bot.Quests.EnsureComplete(6899);
         bot.Sleep(2000);
         UpdateProgress();
      }

   }

   /// ================================================ ///
   ///                  Farm Section 
   /// ================================================ ///
   public class Farms {}
   public void GetLegionToken(int Qty) {

      if (!InvHas("Legion Token")) Unbank("Legion Token");
      if (InvHas("Legion Token", Qty)) return;
      if (bot.Bank.Contains("Shogun Paragon Pet")) Unbank("Shogun Paragon Pet");

      // Pet Firsts
      if (InvHas("Shogun Paragon Pet")) {
         while (!InvHas("Legion Token", Qty)) QuestRun("farm", "fotia", "r5", "Left", 5755,  false);
         return;
      } 

      if (bot.Bank.Contains("Shogun Dage Pet")) {
         Unbank("Shogun Dage Pet");
         while (!InvHas("Legion Token", Qty)) QuestRun("farm", "fotia", "r5", "Left", 5756,  false);
         return;
      }
      
      // Do dreadrock
      GetUndeadChampion();
      while (!InvHas("Legion Token", Qty)) QuestRun("farm-fb", "dreadrock", "r4", "Right", 4849, false);
      return;
   }




   /// ================================================ ///
   ///                  Items Section 
   /// ================================================ ///
   public class Items {}
   public void GetPotion(string PotionName, int Qty, int Buy=30) {
      ExitCombat();
      SafeMapJoin("alchemyacademy", "Enter", "Spawn", false, 99999);
      bot.Sleep(1500);
      bot.Shops.Load(2036);
      bot.Sleep(2000);

      if (bot.Player.Gold < 225000) Buy = bot.Player.Gold/7500;

      foreach (int value in Enumerable.Range(1, Buy)) {
         bot.Shops.BuyItem("Gold Voucher 7.5k");
         bot.Sleep(500);
         bot.Shops.BuyItem(PotionName);
         bot.Sleep(500);
      }

   }


   public void GetUndeadChampion() {
      Unbank("Undead Champion");
      if (InvHas("Undead Champion")) return;
      if (bot.Player.Gold < 50000) GetGold(50000);

      SafeMapJoin("underworld", "s1", "Left", false, 99999);
      bot.Sleep(2500);
      bot.Shops.Load(216);
      bot.Sleep(3000);
      bot.Shops.BuyItem("Undead Champion");
      bot.Sleep(2500);
      return;
   }

   public void GetDarkCasterClass() {
      string[] DarkCasters = {
         "Infinite Legion Dark Caster",
         "Dark Caster", 
         "Immortal Dark Caster",
         "Arcane Dark Caster",
         "Mystical Dark Caster",
         "Timeless Dark Caster",
         "Evolved Dark Caster",
         "Infinite Dark Caster",
         "Legion Evolved Dark Caster",
      };

      ExitCombat();

         
      foreach (string darkclass in DarkCasters) {
         if (InvHas(darkclass)) {
            return;
         }
         if (bot.Bank.Contains(darkclass)) {
            bot.Bank.ToInventory(darkclass);
            return;
         }
      }
      GetLegionToken(2000);

      SafeMapJoin("underworld", "s1", "Left", false, 99999);
      bot.Sleep(2500);
      bot.Shops.Load(238);
      bot.Sleep(3000);
      bot.Shops.BuyItem("Infinite Legion Dark Caster");
      bot.Sleep(2500);
      return;


   }


   /// ================================================ ///
   ///                  Items Section 
   /// ================================================ ///
   public class Constants {}
   public string[] AllLegionItems = {
		"Legion Revenant",

      "Undead Champion",
      "Felicitous Philtre",
      "Endurance Draught",
      "Potion of Evasion",
      "Infinite Legion Dark Caster",

      "Revenant's Spellscroll",
      "Aeacus Empowered",
      "Tethered Soul",
      "Darkened Essence",
      "Dracolich Contract",

      "Conquest Wreath",
      "Grim Cohort Conquered",
      "Ancient Cohort Conquered",
      "Pirate Cohort Conquered",
      "Battleon Cohort Conquered",
      "Mirror Cohort Conquered",
      "Darkblood Cohort Conquered",
      "Vampire Cohort Conquered",
      "Spirit Cohort Conquered",
      "Dragon Cohort Conquered",
      "Doomwood Cohort Conquered",

      "Exalted Crown",
      "Hooded Legion Cowl",
      "Legion Token",
      "Dage's Favor",
      "Emblem of Dage",
      "Diamond Token of Dage",
      "Dark Token",
      "Defeated Makai",
      "Legion Seal",
      "Gem of Mastery"
   };

   public string[] BankLegionFealty1 = {
      "Grim Cohort Conquered",
      "Ancient Cohort Conquered",
      "Pirate Cohort Conquered",
      "Battleon Cohort Conquered",
      "Mirror Cohort Conquered",
      "Darkblood Cohort Conquered",
      "Vampire Cohort Conquered",
      "Spirit Cohort Conquered",
      "Dragon Cohort Conquered",
      "Doomwood Cohort Conquered",

      "Hooded Legion Cowl",
      "Legion Token",
      "Dage's Favor",
      "Emblem of Dage",
      "Diamond Token of Dage",
      "Dark Token",
      "Defeated Makai",
      "Legion Seal",
      "Gem of Mastery",

   };

   public string[] BankLegionFealty2 = {
      // "Revenant's Spellscroll",
      "Aeacus Empowered",
      "Tethered Soul",
      "Darkened Essence",
      "Dracolich Contract",

      "Hooded Legion Cowl",
      "Legion Token",
      "Dage's Favor",
      "Emblem of Dage",
      "Diamond Token of Dage",
      "Dark Token",
      "Defeated Makai",
      "Legion Seal",
      "Gem of Mastery",
   };

   public string[] BankLegionFealty3 = {
      "Grim Cohort Conquered",
      "Ancient Cohort Conquered",
      "Pirate Cohort Conquered",
      "Battleon Cohort Conquered",
      "Mirror Cohort Conquered",
      "Darkblood Cohort Conquered",
      "Vampire Cohort Conquered",
      "Spirit Cohort Conquered",
      "Dragon Cohort Conquered",
      "Doomwood Cohort Conquered",

      // "Revenant's Spellscroll",
      "Aeacus Empowered",
      "Tethered Soul",
      "Darkened Essence",
      "Dracolich Contract",
   };

   // Unbank lists
   public string[] UnbankLegionFeality1 = {
      "Revenant's Spellscroll",
      "Aeacus Empowered",
      "Tethered Soul",
      "Darkened Essence",
      "Dracolich Contract",
   };

   public string[] UnbankLegionFeality2 = {
      "Grim Cohort Conquered",
      "Ancient Cohort Conquered",
      "Pirate Cohort Conquered",
      "Battleon Cohort Conquered",
      "Mirror Cohort Conquered",
      "Darkblood Cohort Conquered",
      "Vampire Cohort Conquered",
      "Spirit Cohort Conquered",
      "Dragon Cohort Conquered",
      "Doomwood Cohort Conquered",
   };

   public string[] UnbankLegionFeality3 = {
      "Exalted Crown",
      "Hooded Legion Cowl",
      "Legion Token",
      "Dage's Favor",
      "Emblem of Dage",
      "Diamond Token of Dage",
      "Dark Token",
      "Defeated Makai",
      "Legion Seal",
      "Gem of Mastery",
   };

   public enum GoldFarmEnum {
      Public,
      Private
   }

   public void AutoRelog() {

     	bot.RegisterHandler(1, b => {

     	// bot.Player.Reconnect("twig");

      if (bot.Player.Kicked) {
         bot.Log("Got kicked");
         bot.Sleep(30000);
         bot.Player.Reconnect(ServerName);
         bot.Sleep(5000);
         ScriptManager.RestartScript();
      }

     	if (!bot.Player.LoggedIn) {
     		bot.Player.Reconnect(ServerName);
         bot.Sleep(5000);
         ScriptManager.RestartScript();
     	}


     });
   }



}