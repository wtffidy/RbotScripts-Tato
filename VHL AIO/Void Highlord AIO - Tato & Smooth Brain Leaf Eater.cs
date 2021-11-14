using System;
using RBot;
using System.Collections.Generic;

//Bot by; 🥔 Tato 🥔 & Smooth Brain Leaf Eater

public class VoidHighLordAIOTesting //🥔
{
	//-----------EDIT BELOW-------------//
	public int MapNumber = 2142069;
	public readonly int[] SkillOrder = { 3, 1, 2, 4 };
	//public readonly int[] SkillOrderSoloClass = { 3, 1, 2, 4 };
	//public readonly int[] SkillOrderFarmClass = { 3, 1, 2, 4 };
	public int SaveStateLoops = 8700;
	public int TurnInAttempts = 10;
	public string SoloClass = "Lycan"; //edit to your preference - SafeEquip(SoloClass);
	public string FarmClass = "Vampire Lord";	//edit to your preference - SafeEquip(FarmClass);
	public int[] QuestList1 = { 5660,3743 };
	public string[] RequiredItems = { 
		"Aelita's Emerald",
		"Archfiend's Favor",
		"Berserker Bunny",
		"Black Knight Orb",
		"Blood Gem of the Archfiend",
		"Bone Dust",
		"Cubes",
		"Dark Crystal Shard",
		"Defeated Makai",
		"Diamond of Nulgath",
		"Diamonds Of Time",
		"Dwakel Decoder",
		"Elders' Blood",
		"Elemental Ink",
		"Ember Ink",
		"Emblem of Nulgath",
		"Essence of Nulgath",
		"Fragment of Chaos",
		"Fiend Seal",
		"Gem of Domination",
		"Gem of Nulgath",
		"Hadean Onyx of Nulgath",
		"Mana Energy For Nulgath",
		"Mystic Quills",
		"Nulgath Shaped Chocolate",
		"Nulgath's Approval",
		"Receipt of Swindle",
		"Roentgenium of Nulgath",
		"Runic Ink",
		"StoneCrusher",
		"Tainted Gem",
		"Tendurrr The Assistant",
		"The Secret 1",
		"Totem of Nulgath",
		"Unidentified 10",
		"Unidentified 13",
		"Unidentified 24",
		"Vampire Lord",
		"Voucher of Nulgath (non-mem)",
		"Voucher of Nulgath",
		"Void Crystal A",
		"Void Crystal b",
		"Void Highlord",
	};
	public string[] VHLQuest = { 
		"Aelita's Emerald",
		"Archfiend's Favor",
		"Black Knight Orb",
		"Bone Dust",
		"Dwakel Decoder",
		"Elders' Blood",
		"Elemental Ink",
		"Emblem of Nulgath",
		"Essence of Nulgath",
		"Gem of Nulgath",
		"Hadean Onyx of Nulgath",
		"Nulgath Shaped Chocolate",
		"Nulgath's Approval",
		"Roentgenium of Nulgath",
		"Tainted Gem",
		"The Secret 1",
		"Unidentified 13",
		"Voucher of Nulgath (non-mem)",
		"Dark Crystal Shard",
		"Blood Gem of the Archfiend",
	};
	public string[] FavorMonsters = {
		"DoomBringer",
		"DoomKnight Prime",
		"Draconic DoomKnight",
		"Legion Airstrike",
		"Legion Cannon",
		"Legion Fenrir",
		"Paragon",
		"Shadow Destroyer",
		"Shadowrise Guard"
	};
	public string[] Assistant = {
		"Dark Crystal Shard",
		"Diamond of Nulgath",
		"Gem of Nulgath",
		"Tainted Gem",
		"Unidentified 10",
		"Unidentified 13",
		"Unidentified 24",
		"Voucher of Nulgath (non-mem)"
	};
	public string[] WheelItems = {
		"Dark Crystal Shard",
		"Diamond of Nulgath",
		"Gem of Nulgath",
		"Tainted Gem",
		"Unidentified 10",
		"Unidentified 13",
		"Unidentified 24",
		"Voucher of Nulgath (non-mem)" };
	public string[] VHLQuestAmounts = { 0, 300, 0, 20, 1, 19, 0, 0, 0, 150, 0, 0, 17, 200, 0, 0, 200, 30, 15, 200, 200 };
	public string[] EssenceOfDefeat = { "Defeated Makai", "Escherion's Chain", "O-dokuro's Tooth", "Strand of Vath's Hair", "Aracara's Fang", "Hydra Scale", "Tibicenas' Chain", "Dark Crystal Shard", "Essence of Nulgath" };
	public string[] KissTheVoid = { "Tendurrr The Assistant", "Fragment of Chaos", "Dark Crystal Shard", "Blood Gem of the Archfiend", "Defeated Makai", "EssenceNulgath", "Unidentified 10", "Archfiend's Favor", "Essence of Nulgath"}; // + "Broken Betrayal Blade" x8 Dropped by Legion Fenrir Level 29 - Temp
	public string[] Merge = { "Roentgenium of Nulgath", "Unidentified 10", "Gem of Nulgath", "Dark Crystal Shard", "Tainted Gem", "Diamond of Nulgath", "Blood Gem of the Archfiend", "Totem of Nulgath", "Elders' Blood" };
	public string[] AelitasEmerald = { "Aelita's Emerald" };
	public string[] ShopItems = { "Aelita's Emerald", "Elemental Ink", "Nulgath Shaped Chocolate", "Mystic Quills", };
	public string[] GemOfNulgath = { "Gem of Nulgath", "Essence of Nulgath" };
	public string[] EmblemofNulgath = { "Emblem of Nulgath", "Gem of Domination", "Fiend Seal" };
	public string[] TaintedGem = { "Tainted Gem", "Bone Dust" };	
	public string[] Favor = { "Nulgath's Approval", "Archfiend's Favor" };
	public string[] EldersBlood = { "Elders' Blood" };
	public string[] Unidentified13 = { "Unidentified 13" };
	public string[] ManaGolem = { "Mana Energy For Nulgath" };
	public string[] BD = { "Bone Dust" };
	public string[] VHLTurninRequirements = { "Hadean Onyx of Nulgath",	"Voucher of Nulgath (non-mem)"	};
    public string[] DSSergMons = { "Bronze Draconian", "Purple Draconian", "Venom Draconian" };
    public string[] DSRewardMons = { "Bronze Draconian", "Dark Draconian", "Golden Draconian", "Purple Draconian", "Venom Draconian", "Water Draconian", "Wyvern" };
    public string[] DSRewardItems = { "Dragonslayer Veteran Medal", "Dragonslayer Sergeant Medal", "Dragonslayer Captain's Medal", "Dragonslayer Marshal Medal", "Wisp of Dragonspirit" };
	public string[] EquippedItems = { };
	public string[] VHlbuy = { "Roentgenium of Nulgath", "Void Crystal A", "Void Crystal B", "Unidentified 10", "Gem of Nulgath", "Dark Crystal Shard", "Tainted Gem", "Blood Gem of the Archfiend", "Diamond of Nulgath", "Totem of Nulgath", "Elders' Blood" };
	public string[] VCAList = { "Unidentified 10", "Gem of Nulgath", "Dark Crystal Shard", "Tainted Gem" };
	public string[] VCBList = { "Diamond of Nulgath", "Blood Gem of the Archfiend", "Totem of Nulgath", "Elders' Blood" };
	public string[] BKOrb = { "Black Knight Orb" };

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
		CheckSpace(RequiredItems);
		GetDropList(RequiredItems);
		InvCheck();

		while (!bot.ShouldExit())
		{
		while (!bot.Player.Loaded) { }
		if (bot.Player.DropExists( " new strin = { RequiredItems } " )) bot.Player.Pickup(" new strin = { RequiredItems } " ); 
		if (!bot.Quests.IsAvailable(570)) DragonSlayerRewardQuests(); //dragonslayer Reward Quest Check, have you done them? no? then well do it for you :D
		bot.Sleep(2500);
		UnbankList(VHLQuest);

		bot.Quests.EnsureAccept(5660);
		bot.Log("You Level 51+?");
		if (bot.Player.Level < 51) Leveling(); //10 for dragonslayer reward, 50 for vhl Challenge, ++ to kill stuff
		bot.Log("Checking if you Did The Dragonslayer Stuff");
		if (!bot.Quests.IsAvailable(570)) DragonSlayerRewardQuests(); //dragonslayer Reward Quest Check, have you done them? no? then well do it for you :D
		bot.Log("Your Experienced But Can You Complete It?");
		bot.Log($"[{DateTime.Now:HH:mm:ss}] You Got The Stuff?");
		bot.Log("Hadeon");
		while (!bot.Inventory.Contains("Hadean Onyx of Nulgath", 1) && !bot.Bank.Contains("Hadean Onyx of Nulgath", 1)) HadeanOnyxofNulgath();
		bot.Log("VoucherNonMem");
		while (!bot.Inventory.Contains("Voucher of Nulgath (non-mem)", 1) && !bot.Bank.Contains("Voucher of Nulgath (non-mem)", 1)) LarvaeFarm();
		bot.Log("TurnIn");
		while (bot.Inventory.Contains(" new string = { VHLQuest } ", " new string = { VHLQuestAmounts } " ) && bot.Bank.Contains(" new string = { VHLQuest } " , " new string = { VHLQuestAmounts } ")) Roentgenium();
		bot.Log("Elder");
		while (!bot.Inventory.Contains("Elders' Blood", 1) && !bot.Bank.Contains("Elders' Blood", 1)) GorillaBlood();
		bot.Log("BKOrb");
		while (!bot.Inventory.Contains("Black Knight Orb", 1) && !bot.Bank.Contains("Black Knight Orb", 1)) BlackKnightOrb();
		bot.Log("Emerald");
		while (!bot.Inventory.Contains("Aelita's Emerald", 1) && !bot.Bank.Contains("Aelita's Emerald", 1)) Emerald();
		bot.Log("Spellcrafting");
		while (bot.Player.GetFactionRank("SpellCrafting") < 3) Spellcrafting();
		bot.Log("Elemental Ink");
		while (!bot.Inventory.Contains("Elemental Ink", 10) && !bot.Bank.Contains("Elemental Ink", 10)) ElementalInk();
		bot.Log("GemNulgath");
		while (!bot.Inventory.Contains("Gem of Nulgath", 20) && !bot.Bank.Contains("Gem of Nulgath", 20)) GemofNulgath();
		bot.Log("EssenceNulgath");
		while (!bot.Inventory.Contains("Essence of Nulgath", 50) && !bot.Bank.Contains("Essence of Nulgath", 50)) EssenceofNulgathVHLQuest();
		bot.Log("EmblemNulgath");
		while (!bot.Inventory.Contains("Emblem of Nulgath", 20) && !bot.Bank.Contains("Emblem of Nulgath", 20)) NationsRecruitSealYourFate();
		bot.Log("Tainted");
		while (!bot.Inventory.Contains("Tainted Gem") && !bot.Bank.Contains("Tainted Gem", 300)) SpinTheWheel();
		bot.Log("BoneDust");
		while (!bot.Inventory.Contains("Bone Dust") && !bot.Bank.Contains("Bone Dust", 20)) BoneDust();
		bot.Log("NulApproval");
		while (!bot.Inventory.Contains("Nulgath's Approval", 300) && !bot.Bank.Contains("Nulgath's Approval", 300)) ApprovalNulgath();
		bot.Log("ArchFavor");
		while (!bot.Inventory.Contains("Archfiend's Favor", 300) && !bot.Bank.Contains("Archfiend's Favor", 300)) ApprovalArchfiend();
		bot.Log("Choco");
		while (!bot.Inventory.Contains("Nulgath Shaped Chocolate", 1) && !bot.Bank.Contains("Nulgath Shaped Chocolate", 1)) Chocolate();
		bot.Log("Uni 13");
		while (!bot.Inventory.Contains("Unidentified 13", 1) && !bot.Bank.Contains("Unidentified 13", 1)) Uni13(); //Must have completed the 'Dragonslayer Reward' quest.
		bot.Log("Dwakel");
		while (!bot.Inventory.Contains("Dwakel Decoder", 1) && !bot.Bank.Contains("Dwakel Decoder", 1)) DwakelDecoder();	
		bot.Log("Secret");
		while (!bot.Inventory.Contains("The Secret 1", 1) && !bot.Bank.Contains("The Secret 1", 1)) TheSecret1();	
		bot.Log("DarkCrystalShard");
		while (!bot.Inventory.Contains("Dark Crystal Shard", 200) && !bot.Bank.Contains("Dark Crystal Shard", 200)) EssenceOfDefeatQuest();
		bot.Log("Blood Gem of the Archfiend");
		while (!bot.Inventory.Contains("Blood Gem of the Archfiend", 30) && !bot.Bank.Contains("Blood Gem of the Archfiend", 30)) KissTheVoidQuest();
		bot.Log("RoentgeniumCheck");
		while (!bot.Inventory.Contains("Roentgenium of Nulgath", 17) && !bot.Bank.Contains("Roentgenium of Nulgath", 17)) Roentgenium();
		bot.Log("BuyVHL");
		while (bot.Inventory.Contains("Roentgenium of Nulgath", 17) && bot.Bank.Contains("Roentgenium of Nulgath", 17)) BuyVHL();
	

				

		
		}
		
	}
	//                              ▓▓▓▓████████████████▓▓▓▓▒▒              
 //                         ▓▓▓▓████░░░░░░░░░░░░░░░░██████▓▓            
  //                      ▓▓████░░░░░░░░░░░░░░░░░░░░░░░░░░████          
   //                   ▓▓██░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░██        
    //                ▓▓██░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░██      
    //              ▓▓██░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░██      
   //             ▓▓██░░░░░░▓▓██░░  ░░░░░░░░░░░░░░░░░░░░▓▓██░░  ░░██    
   //           ▓▓██░░░░░░░░██████░░░░░░░░░░░░░░░░░░░░░░██████░░░░░░██  
    //          ▓▓██░░░░░░░░██████▓▓░░░░░░██░░░░██░░░░░░██████▓▓░░░░██  
   //         ▓▓██▒▒░░░░░░░░▓▓████▓▓░░░░░░████████░░░░░░▓▓████▓▓░░░░░░██
   //       ▓▓██░░░░░░░░░░░░░░░░░░░░░░░░░░██░░░░██░░░░░░░░░░░░░░░░░░░░██
   //      ▓▓██░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░██
   //       ▓▓██░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░██
   //     ░░▓▓▒▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░██
   //     ▓▓██░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░██
  //      ▓▓██░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░██
   //     ▓▓██░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░██
  //    ▓▓██░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░██
   //  ▓▓██░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░██
   //   ▓▓██░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░██  
  //    ▓▓██░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░██  
  //  ▓▓██░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░██  
 //   ▓▓██░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░██  
  //  ▓▓██░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░██  
  //  ▓▓██░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░██  
//   ▓▓██░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░██    
//  ▓▓██░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░██    
//  ▓▓██░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░██    
//  ▓▓██░░░░░░░░░░░░░░░░░░░░░Feed Me THe Items Father░░░░░░░░░░░░░██    
//  ▓▓██░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░██    
//  ▓▓██░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░██  
//  ▓▓██░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░██  
//  ▓▓██░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░██  
//    ▓▓██░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░██  
//    ▓▓██░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░██  
//    ▓▓██░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░██  
 //   ░░▓▓▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░██  
  //    ▓▓██░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░██░░  
   //     ▓▓██░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░██    
    //      ▓▓██░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░██      
      //    ▓▓██░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░██        
      //      ▓▓████░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░██          
      //        ▓▓▓▓████████░░░░░░░░░░░░░░░░░░░░░░░░████████░░          
      //        ░░░░▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓░░░░░░░░            
		
			
			public void AIORequirements()
			{

			}


			public void BlackKnightOrb()
				{
					UnbankList(BKOrb);
					SafeEquip(SoloClass);
						if(!bot.Inventory.Contains("Black Knight Orb"))
							{								
							bot.Log($"[{DateTime.Now:HH:mm:ss}] fixme3.1");
							bot.Sleep(2500);
									
							ItemFarm("Black Knight Leg Piece", 1, true, true, 318, "Gell Oh No", "well");
							bot.Log($"[{DateTime.Now:HH:mm:ss}] fixme3.6");		
							ItemFarm("Black Knight Chest Piece", 1, true, true, 318, "Greenguard Dragon", "greendragon");
							bot.Log($"[{DateTime.Now:HH:mm:ss}] fixme3.7");		
							ItemFarm("Black Knight Shoulder Piece", 1, true, true, 318, "Deathgazer", "deathgazer");
							bot.Log($"[{DateTime.Now:HH:mm:ss}] fixme3.8");		
							ItemFarm("Black Knight Arm Piece", 1, true, true, 318, "Greenguard Basilisk", "trunk");	
							bot.Log($"[{DateTime.Now:HH:mm:ss}] fixme3.9");		
							bot.Quests.EnsureComplete(318);
							bot.Log($"[{DateTime.Now:HH:mm:ss}] fixme3.10");		
							bot.Log("Black Knight Orb Farmed."); 
							}					
				}	

			public void Emerald()
				{
					bot.Log($"[{DateTime.Now:HH:mm:ss}] Emerald1");
				UnbankList(ShopItems);
					bot.Log($"[{DateTime.Now:HH:mm:ss}] Emerald2");
				bot.Sleep(2500);
					bot.Log($"[{DateTime.Now:HH:mm:ss}] Emerald3");
				SafePurchase("Aelita's Emerald", 1, "yulgar", 16);
					bot.Log($"[{DateTime.Now:HH:mm:ss}] Emerald4");
				}
						
			public void ElementalInk()
				{
					while(!bot.Inventory.Contains("Mystic Quills", 4))
							bot.Log($"[{DateTime.Now:HH:mm:ss}] ElementalInk1");
						{
						UnbankList(ShopItems);
							bot.Log($"[{DateTime.Now:HH:mm:ss}] ElementalInk2");
						bot.Sleep(2500);
							bot.Log($"[{DateTime.Now:HH:mm:ss}] ElementalInk3");
							bot.Log($"[{DateTime.Now:HH:mm:ss}] ElementalInk4");
						ItemFarm("Mystic Quills", 4, false, true, 0, "Slugfit", "mobius");
							bot.Log($"[{DateTime.Now:HH:mm:ss}] ElementalInk5");
						SafeMapJoin("spellcraft");
							bot.Log($"[{DateTime.Now:HH:mm:ss}] ElementalInk6");
						bot.Sleep(500);
						SafePurchase("Elemental Ink", 10, "spellcraft", 549);
						bot.Sleep(500);
							bot.Log($"[{DateTime.Now:HH:mm:ss}] ElementalInk7");
						}
							bot.Log($"[{DateTime.Now:HH:mm:ss}] ElementalInk8");
				}	

			public void GemofNulgath()
				{
					SafeEquip(FarmClass);
					bot.Log($"[{DateTime.Now:HH:mm:ss}] GemofNulgath");
						UnbankList(GemOfNulgath);
					bot.Log($"[{DateTime.Now:HH:mm:ss}] GemofNulgath");
						bot.Sleep(2500);
					bot.Log($"[{DateTime.Now:HH:mm:ss}] GemofNulgath");

					while(!bot.Inventory.Contains("Gem of Nulgath", 20))
						{
					bot.Log($"[{DateTime.Now:HH:mm:ss}] GemofNulgath");
							SafeMapJoin("tercessuinotlim");
					bot.Log($"[{DateTime.Now:HH:mm:ss}] GemofNulgath");
							ItemFarm("Essence of Nulgath", 60, false, false, 4778, "Dark Makai", "tercessuinotlim", "m2", "Center"); 
					bot.Log($"[{DateTime.Now:HH:mm:ss}] GemofNulgath");          
							SafeQuestComplete(4778);
					bot.Log($"[{DateTime.Now:HH:mm:ss}] GemofNulgath");
						bot.Log("Gem of Nulgathfarmed");
					}
				}
			
			public void EssenceofNulgathVHLQuest()
				{	
					
					if(!bot.Inventory.Contains("Essence of Nulgath", 50))
						{	
						SafeEquip(FarmClass);
						bot.Log($"[{DateTime.Now:HH:mm:ss}] EssenceofNulgathVHLQuest1");
							UnbankList(VHLQuest);
						bot.Log($"[{DateTime.Now:HH:mm:ss}] EssenceofNulgathVHLQuest2");
							bot.Sleep(2500);
						bot.Log($"[{DateTime.Now:HH:mm:ss}] EssenceofNulgathVHLQuest5");
								SafeMapJoin("tercessuinotlim");
						//bot.Log($"[{DateTime.Now:HH:mm:ss}] EssenceofNulgathVHLQuestSingleFarm");
							ItemFarm("Essence of Nulgath", 50, false, false, 5660, "Dark Makai", "tercessuinotlim", "m2", "Center"); 
							ItemFarm("Tendurrr The Assistant", 1, false, false, 4734, "Dark Makai", "tercessuinotlim", "m2", "Center"); 
								bot.Log("Essence of Nulgath x50 Farmed.");
						}
				}
			public void EssenceOfDefeatQuest()//Dark Crystal Shard
			{
				UnbankList(EssenceOfDefeat);
				//570
				//items; 
				while(!bot.Inventory.Contains("Dark Crystal Shard", 200))
				{

				ItemFarm("Defeated Makai", 50, false, false, 570, "Dark Makai", "tercessuinotlim", "m2", "Left"); 
				ItemFarm("Escherion's Chain", 1, false, true, 570, "Escherion", "map"); 
				ItemFarm("O-dokuro's Tooth", 1, false, true, 570, "O-Dokuro's Head", "yokaiwar"); 
				ItemFarm("Strand of Vath's Hair", 1, false, true, 570, "Vath", "stalagbite"); 
				ItemFarm("Aracara's Fang", 1, false, true, 570, "Aracara", "faerie"); 
				ItemFarm("Hydra Scale", 1, false, true, 570, " Hydra Head", "hydra"); 
				ItemFarm("Tibicenas' Chain", 1, false, true, 570, "Tibicenas", "djinn"); 
				SafeQuestComplete(570);
				}

			}						

			public void NationsRecruitSealYourFate()
				{
					SafeEquip(FarmClass);
				bot.Log($"[{DateTime.Now:HH:mm:ss}] NationsRecruitSealYourFate1");
					UnbankList(EmblemofNulgath);
				bot.Log($"[{DateTime.Now:HH:mm:ss}] NationsRecruitSealYourFate2");
					bot.Sleep(2500);
				bot.Log($"[{DateTime.Now:HH:mm:ss}] NationsRecruitSealYourFate3");

					if(!bot.Inventory.Contains("Emblem of Nulgath", 20))
					{
				bot.Log($"[{DateTime.Now:HH:mm:ss}] NationsRecruitSealYourFate4");
						SafeEquip(FarmClass);
				bot.Log($"[{DateTime.Now:HH:mm:ss}] NationsRecruitSealYourFate5");
						ItemFarm("Gem of Domination", 1, false, true, 4748, "DoomBringer|Legion Fenrir|Legion Cannon|Legion Airstrike|Paragon|DoomKnight Prime|Draconic DoomKnight|Shadow Destroyer|Shadowrise Guard", "shadowblast");
				bot.Log($"[{DateTime.Now:HH:mm:ss}] NationsRecruitSealYourFate6");
						bot.Log("Gem of Domination Farmed");
				bot.Log($"[{DateTime.Now:HH:mm:ss}] NationsRecruitSealYourFate7");
						ItemFarm("Fiend Seal", 25, false, true, 4748, "DoomBringer|Legion Fenrir|Legion Cannon|Legion Airstrike|Paragon|DoomKnight Prime|Draconic DoomKnight|Shadow Destroyer|Shadowrise Guard", "shadowblast");
				bot.Log($"[{DateTime.Now:HH:mm:ss}] NationsRecruitSealYourFate8");
						bot.Log("Fiend Seal x25 Farmed");
						SafeQuestComplete(4748);
				bot.Log($"[{DateTime.Now:HH:mm:ss}] NationsRecruitSealYourFate9");
						bot.Log("Nations Recruit Complete.");
						
					}
				bot.Log($"[{DateTime.Now:HH:mm:ss}] NationsRecruitSealYourFate10");
				}
			
			public void TaintedGems()
				{
					SafeEquip(FarmClass);
				bot.Log($"[{DateTime.Now:HH:mm:ss}] TaintedGems1");
					UnbankList(VHLQuest);
				bot.Log($"[{DateTime.Now:HH:mm:ss}] TaintedGems2");
					bot.Sleep(250);
				bot.Log($"[{DateTime.Now:HH:mm:ss}] TaintedGems3");
					

					if(!bot.Inventory.Contains("Tainted Gem", 100))
					{
				bot.Log($"[{DateTime.Now:HH:mm:ss}] TaintedGems4");
						if(!bot.Inventory.Contains("Bone Dust", 50))
						{
				bot.Log($"[{DateTime.Now:HH:mm:ss}] TaintedGems5");
							ItemFarm("Bone Dust", 50, false, false, 568, "*", "battleunderb");
				bot.Log($"[{DateTime.Now:HH:mm:ss}] TaintedGems6");
							bot.Log("Bone Dust Get");
						}
				bot.Log($"[{DateTime.Now:HH:mm:ss}] TaintedGems7");
						SafeQuestComplete(568);
				bot.Log($"[{DateTime.Now:HH:mm:ss}] TaintedGems8");
						bot.Log("Tainted Gem Get");
					}
				bot.Log($"[{DateTime.Now:HH:mm:ss}] TaintedGems9");
				}

			public void ApprovalArchfiend()
				{	
					SafeEquip(FarmClass);				
						bot.Log($"[{DateTime.Now:HH:mm:ss}] ApprovalArchfiend1");
					UnbankList(VHLQuest);
						bot.Log($"[{DateTime.Now:HH:mm:ss}] ApprovalArchfiend2");
					bot.Sleep(2500);
						bot.Log($"[{DateTime.Now:HH:mm:ss}] ApprovalArchfiend3");
						bot.Log($"[{DateTime.Now:HH:mm:ss}] ApprovalArchfiend4");
					ItemFarm("Archfiend's Favor", 300, false, true, 5660, "Legion Fenrir|Blade Master|Skull Warrior|Undead Bruiser|Undead Infantry|Undead Legend", "evilwarnul");
						bot.Log($"[{DateTime.Now:HH:mm:ss}] ApprovalArchfiend5");
						bot.Log("Archfiend's Favor x 300 Farmed");
					ItemFarm("Nulgath's Approval", 300, false, true, 5660, "Legion Fenrir|Blade Master|Skull Warrior|Undead Bruiser|Undead Infantry|Undead Legend", "evilwarnul");
						bot.Log("Nulgath's Approval x 300 Farmed");
						bot.Log($"[{DateTime.Now:HH:mm:ss}] ApprovalArchfiend6");	
				}	

			public void ApprovalNulgath()
				{		
					SafeEquip(FarmClass);			
						bot.Log($"[{DateTime.Now:HH:mm:ss}] ApprovalNulgath1");
					UnbankList(VHLQuest);
						bot.Log($"[{DateTime.Now:HH:mm:ss}] ApprovalNulgath2");
					bot.Sleep(2500);
						bot.Log($"[{DateTime.Now:HH:mm:ss}] ApprovalNulgath3");
					SafeEquip(FarmClass);
						bot.Log($"[{DateTime.Now:HH:mm:ss}] ApprovalNulgath4");					
					ItemFarm("Nulgath's Approval", 300, false, true, 5660, "Legion Fenrir|Blade Master|Skull Warrior|Undead Bruiser|Undead Infantry|Undead Legend", "evilwarnul");
						bot.Log("Nulgath's Approval x 300 Farmed");	
				}

			public void GorillaBlood()
				{
					SafeEquip(FarmClass);
				bot.Log($"[{DateTime.Now:HH:mm:ss}] GorillaBlood1");
					UnbankList(EldersBlood);
				bot.Log($"[{DateTime.Now:HH:mm:ss}] GorillaBlood2");
					bot.Sleep(250);
				bot.Log($"[{DateTime.Now:HH:mm:ss}] GorillaBlood3");

					if(!bot.Inventory.Contains("Elders' Blood"))					
							{
				bot.Log($"[{DateTime.Now:HH:mm:ss}] GorillaBlood4");
							SafeEquip(FarmClass);
				bot.Log($"[{DateTime.Now:HH:mm:ss}] GorillaBlood5");
							ItemFarm("Slain Gorillaphant", 50, true, true, 802, "Gorillaphant", "arcangrove");
				bot.Log($"[{DateTime.Now:HH:mm:ss}] GorillaBlood6");
							SafeQuestComplete(802);
				bot.Log($"[{DateTime.Now:HH:mm:ss}] GorillaBlood7");
							bot.Log("Elders' Blood Done");
							}
				bot.Log($"[{DateTime.Now:HH:mm:ss}] GorillaBlood8");
				}	

			public void Chocolate()
				{
					SafeEquip(SoloClass);
					bot.Log($"[{DateTime.Now:HH:mm:ss}] Chocolate1");
					UnbankList(ShopItems);
					bot.Log($"[{DateTime.Now:HH:mm:ss}] Chocolate2");
					bot.Sleep(250);
					bot.Log($"[{DateTime.Now:HH:mm:ss}] Chocolate3");
					
					if(!bot.Inventory.Contains("Nulgath Shaped Chocolate", 1))
						{		
					bot.Log($"[{DateTime.Now:HH:mm:ss}] Chocolate4");	
							while(bot.Player.Gold < 2000000)
								{
										bot.Log($"[{DateTime.Now:HH:mm:ss}] Chocolate5");
										bot.Log("Making some money");
										bot.Log($"[{DateTime.Now:HH:mm:ss}] Chocolate6");
									SafeEquip(SoloClass);
										bot.Log($"[{DateTime.Now:HH:mm:ss}] Chocolate7");
									ItemFarm("Were Egg", 1, true, true, 236, "Big Bad Boar", "greenguardwest");									
										bot.Log($"[{DateTime.Now:HH:mm:ss}] Chocolate8");
									SafeQuestComplete(236);								
										bot.Log($"[{DateTime.Now:HH:mm:ss}] Chocolate9");
									SafeSell("Berserker Bunny", 0);
										bot.Log($"[{DateTime.Now:HH:mm:ss}] Chocolate10");
								}
							bot.Log("We got money, buying some chocolate for you");
							SafePurchase("Nulgath Shaped Chocolate", 1, "citadel", 44);
										bot.Log($"[{DateTime.Now:HH:mm:ss}] Chocolate11");
						}
										bot.Log($"[{DateTime.Now:HH:mm:ss}] Chocolate12");
				}
			public void Uni13() //869 diamond exchange
			{
				if(!bot.Inventory.Contains("Unidentified 13", 1))
				{		
					while(!bot.Inventory.Contains("Diamond of Nulgath", 15)) SpinTheWheel();
				ItemFarm("Essence of Nulgath", 100, false, true, 869, "Dark Makai", "tercessuinotlim");
				ItemFarm("Lesser Tainted Core", 1, true, true, 869, "Tainted Elemental", "tercessuinotlim");
				bot.Quests.EnsureComplete(869);
				}
			}

			public void LarvaeFarm()
					{
					bot.Log($"[{DateTime.Now:HH:mm:ss}] LarvaeFarm1");
					bot.Sleep(250);
					bot.Log($"[{DateTime.Now:HH:mm:ss}] LarvaeFarm2");
					UnbankList(VHLQuest);
					bot.Log($"[{DateTime.Now:HH:mm:ss}] LarvaeFarm3");
					if(!bot.Inventory.Contains("Unidentified 13", 1))
					bot.Log($"[{DateTime.Now:HH:mm:ss}] LarvaeFarm4");
					
					SafeEquip(SoloClass);
					bot.Log($"[{DateTime.Now:HH:mm:ss}] LarvaeFarm");
					ItemFarm("Mana Energy for Nulgath", 1, false, true, 2566, "Mana Golem", "elemental");
					bot.Log("LarvaeFarm5");
					SafeEquip(FarmClass);
					bot.Log("LarvaeFarm6");
					ItemFarm("Charged Mana Energy for Nulgath", 5, true, true, 2566, "Mana Falcon|Mana Imp", "elemental");
					bot.Log("LarvaeFarm7");
					SafeQuestComplete(2566); 
					bot.Log("LarvaeFarm8");
					}

			public void BoneDust()
				{	
					SafeEquip(FarmClass);		
					UnbankList(VHLQuest);
					bot.Log($"[{DateTime.Now:HH:mm:ss}] BoneDust2");
					SafeEquip(FarmClass);
					ItemFarm("Bone Dust", 20, false, false, 5660, "Skeleton Warrior", "battleunderb", "Enter", "Spawn");					
					bot.Log($"[{DateTime.Now:HH:mm:ss}] BoneDust3");
						
				}

			public void InvCheck()
				{
				bot.Log($"[{DateTime.Now:HH:mm:ss}] InvCheck1");
					int FreeInvSpace = bot.GetGameObject<int>("world.myAvatar.objData.iBagSlots") - bot.GetGameObject<int>("world.myAvatar.items.length"); //>.> good idea 
			
					if(FreeInvSpace <= 18)
							
					StopBot("Bot Requires 18 Inv Slots, Please Fix And Try again");
				}



			public void HadeanOnyxofNulgath()
			{	
				if(!bot.Inventory.Contains("Hadean Onyx of Nulgath", 1))
				{
				SafeEquip(SoloClass);
				bot.Log($"[{DateTime.Now:HH:mm:ss}] HadeanOnyxofNulgath1");
				SafeMapJoin("tercessuinotlim");
					bot.Log($"[{DateTime.Now:HH:mm:ss}] HadeanOnyxofNulgath2");
				SafeEquip(SoloClass);
					bot.Log($"[{DateTime.Now:HH:mm:ss}] HadeanOnyxofNulgath3");
				ItemFarm("Hadean Onyx of Nulgath", 1, false, true, 5660, "Shadow of Nulgath", "tercessuinotlim");
					bot.Log($"[{DateTime.Now:HH:mm:ss}] HadeanOnyxofNulgath4");
				}
			}

			public void DwakelDecoder()
			{
				 if(!bot.Inventory.Contains("Dwakel Decoder", 1))
				 {
        			SafeMapJoin("crashsite", "Farm2", "Right");
					bot.Sleep(1000);
       				bot.SendPacket($"%xt%zm%getMapItem%442235%106%");
					bot.Sleep(1000);
				 }
			}

			public void TheSecret1()
			{
				SafeEquip(SoloClass);
				if(!bot.Inventory.Contains("The Secret 1", 1))
				{
				ItemFarm("The Secret 1", 1, false, true, 623, "Hidden Spy", "willowcreek");	
				}
			}

			public void Roentgenium()
				{
				if(bot.Inventory.Contains(" new string = { VHLQuest } ", 1))
					bot.Log($"[{DateTime.Now:HH:mm:ss}] Roentgenium1");
				SafeMapJoin("party");
				UnbankList(VHLQuest);
				if (!bot.Quests.IsInProgress(5660)) bot.Quests.EnsureAccept(5660);
				if (bot.Quests.CanComplete(5660)) SafeQuestComplete(5660);							
					bot.Log("Roentgenium Farmed, Gathering Mats for Tomarrow.");				
					bot.Log($"[{DateTime.Now:HH:mm:ss}] Throw It Back now Ya'all");
				}

			public void Spellcrafting()
				{
				bot.Log($"[{DateTime.Now:HH:mm:ss}] Spellcrafting1");
					{
					if (bot.Player.GetFactionRank("SpellCrafting") < 2)
						{
				bot.Log($"[{DateTime.Now:HH:mm:ss}] Spellcrafting2");
							bot.Log("Welcome");
							bot.Quests.EnsureAccept(3052);
							SafeMapJoin("dragonrune");
							bot.SendPacket("%xt%zm%getMapItem%101795%1921%");
							bot.Sleep(500);
							bot.SendPacket("%xt%zm%getMapItem%101795%1922%");
							bot.Sleep(500);
							bot.SendPacket("%xt%zm%getMapItem%101795%1923%");
								bot.Sleep(500);
							bot.SendPacket("%xt%zm%getMapItem%101795%1924%");
							bot.Sleep(500);
							bot.Quests.EnsureComplete(3052);
						}

					if (bot.Player.GetFactionRank("SpellCrafting") < 2)
						{
							SafeEquip(FarmClass);
							bot.Log($"[{DateTime.Now:HH:mm:ss}] SpellCrafting3");
							bot.Log("Spellbook");
							bot.Quests.EnsureAccept(2260);
							ItemFarm("Arcane Parchment", 13, true, true, 0, "Skeletal Warrior|Big Jack Sprat", "graveyard");
							SafeMapJoin("dragonrune");
							bot.Sleep(500);
							bot.SendPacket("%xt%zm%getMapItem%101928%1920%");
							bot.Quests.EnsureComplete(2260);
						}	
					
					else while (bot.Player.GetFactionRank("SpellCrafting") >= 2)
						{
							SafeEquip(FarmClass);
								bot.Log($"[{DateTime.Now:HH:mm:ss}] SpellCrafting4");
							if(!bot.Inventory.Contains("Mystic Quills", 10))
							{
								bot.Log($"[{DateTime.Now:HH:mm:ss}] SpellCrafting5");
								ItemFarm("Mystic Quills", 10, false, true, 2353, "Mana Imp|Mana Falcon", "elemental");
							}
								bot.Log($"[{DateTime.Now:HH:mm:ss}] SpellCrafting6");
								SafeMapJoin("spellcraft");
								SafePurchase("Runic Ink", 1, "spellcraft", 549);
								bot.Quests.EnsureAccept(2353);
								bot.Log($"[{DateTime.Now:HH:mm:ss}] SpellCrafting7");
								SafeQuestComplete(2353);
						}
					}
				}

			public void BuyVHL()
				{
					SafeMapJoin("tercessuinotlim");
					UnbankList(VHlbuy);
								bot.Log($"[{DateTime.Now:HH:mm:ss}] vhlbuy-bank");
						if(bot.Inventory.Contains("Roentgenium of Nulgath", 17))					
						{
							Roentgenium();
								bot.Log($"[{DateTime.Now:HH:mm:ss}] reont check");
								if(bot.Inventory.Contains(" new string = { VCAList } ", 1))
									{
								bot.Log($"[{DateTime.Now:HH:mm:ss}] vhlbuy-vcAlist");
										SafeMapJoin("tercessuinotlim");
										SafePurchase("Void Crystal B", 1, "tercessuinotlim", 1335);
									}
								
						if(bot.Inventory.Contains(" new string = { VCBList } ", 1))
							{
								bot.Log($"[{DateTime.Now:HH:mm:ss}] vhlbuy-vcBlist");
								SafeMapJoin("tercessuinotlim");
								SafePurchase("Void Crystal A", 1, "tercessuinotlim", 1335);
							}

						if(!bot.Inventory.Contains("Void Highlord", 1))
							{
							bot.Log($"[{DateTime.Now:HH:mm:ss}] vhlbuy-vhlcheckandbuy");
							SafeMapJoin("tercessuinotlim");
							SafePurchase("Void Highlord", 1, "tercessuinotlim", 1355) ;
							}
						}
				}
				


			public void DarkCrystalShard()
				{
				//'The Assistant'

				}
				
				public void Unidentified10()
				{

				}
				
				public void TotemofNulgath()
				{
					LarvaeFarm();
				}
				
				public void DrudgentheSalesman() //blood gems of the archfiend
				{		
					UnbankList(VHLQuest);	
					
					bot.Log("unbank DrudgentheSalesman");	
					while(!bot.Inventory.Contains("Blood Gem of the Archfiend", 30))
					{
					bot.Log("u got teh gems?");
					if(!bot.Inventory.Contains("Unidentified 13", 1)) Uni13();
					ItemFarm("Tainted Rune of Evil", 1, true, true, 605, "Tainted Elemental", "tercessuinotlim");
					bot.Log("Tainted Rune");
					ItemFarm("Diamonds Of Time", 1, false, true, 605, "Acornent|Karasu", "cloister");
					bot.Log("diamond of time");
					//Diamonds Of Time
					bot.Quests.EnsureComplete(605, 22332);
					bot.Log("DrudgentheSalesman turnin");
					}
				}
				public void KissTheVoidQuest()
				{
					bot.Log("KissTheVoidBank");
					UnbankList(KissTheVoid);
					while(!bot.Inventory.Contains("Blood Gem of the Archfiend", 30))
					{
						bot.Log("KissTheVoidFarm");						
						ItemFarm("Tendurrr The Assistant", 1, false, false, 3743, "Dark Makai", "tercessuinotlim", "m2", "Left");//1% may take a minute						
						ItemFarm("Fragment of Chaos", 80, false, true, 3743, "Water Draconian", "lair");
						ItemFarm("Broken Betrayal Blade", 8, true, true, 3743, "Legion Fenrir", "evilwarnul");
						bot.Quests.EnsureComplete(3743);
					}
				}

				public void WarTornMemorabilia()
				{					
					Unbank(Assistant);
					bot.Sleep(1000);
					while(bot.Player.Gold < 100000)
					{
						ItemFarm("Were Egg", 1, true, true, 236, "Big Bad Boar", "greenguardwest");
						SafeQuestComplete(236);
						bot.Sleep(1000);
						bot.Log("SellBunny");
						SafeSell("Berserker Bunny", 0);
					}
					SafePurchase("War-Torn Memorabilia", 1, "evilwarnul", 456);
					SafeQuestComplete(2859);
				}
				
				public void SpinTheWheel()
				{
					UnbankList(WheelItems);
				ItemFarm("Escherion's Helm", 1, false, true, 2857, "Escherion", "escherion");
				SafeQuestComplete(2857);
				//ItemFarm("ItemName", ItemQuantity, Temporary, HuntFor, QuestID, "MonsterName", "MapName", "CellName", "PadName");
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

				public void DragonSlayerRewardQuests()
				{   					
					bot.Log($"[{DateTime.Now:HH:mm:ss}] DSRewards1");
				DragonSlayerRewardAIO:
				if (bot.Quests.IsAvailable(169))
					{	goto DragonSlayerReward;
						if (bot.Quests.IsAvailable(168))
							{	goto DragonSlayerMarsh;
							 if (bot.Quests.IsAvailable(167))
									{	goto DragonSlayerCapt;									
									 if (bot.Quests.IsAvailable(166))
											{	goto DragonSlayerSerg;											
											 if (bot.Quests.IsAvailable(165))
													{	goto DragonSlayerVet;
													}}}}}
					DragonSlayerVet:
						SafeEquip(FarmClass);
						ItemFarm("Dragonslayer Veteran Medal", 8, true, true, 165, "Wyvern", "lair");
								bot.Log($"[{DateTime.Now:HH:mm:ss}] DSRewards2");
						ExitCombat();
						bot.Quests.EnsureComplete(165);
					
								bot.Log($"[{DateTime.Now:HH:mm:ss}] DSRewards3");
						goto DragonSlayerSerg;

					DragonSlayerSerg:
						SafeEquip(FarmClass);
						ItemFarm("Dragonslayer Sergeant Medal", 8, true, true, 166, "Bronze Draconian|Purple Draconian|Venom Draconian", "lair");
								bot.Log($"[{DateTime.Now:HH:mm:ss}] DSRewards4");
						ExitCombat();
						bot.Quests.EnsureComplete(166);
								bot.Log($"[{DateTime.Now:HH:mm:ss}] DSRewards5");
												
						goto DragonSlayerCapt;

					DragonSlayerCapt:
						SafeEquip(FarmClass);
						ItemFarm("Dragonslayer Captain Medal", 8, true, true, 167, "Dark Draconian|Golden Draconian", "lair");
								bot.Log($"[{DateTime.Now:HH:mm:ss}] DSRewards6");
						ExitCombat();
						bot.Quests.EnsureComplete(167);	
								bot.Log($"[{DateTime.Now:HH:mm:ss}] DSRewards7");
						goto DragonSlayerMarsh;	

					DragonSlayerMarsh:
						SafeEquip(SoloClass);
						ItemFarm("Dragonslayer Marshal Medal", 8, true, true, 168, "Red Dragon", "lair");
								bot.Log($"[{DateTime.Now:HH:mm:ss}] DSRewards8");
						ExitCombat();
						bot.Quests.EnsureComplete(168);
						
								bot.Log($"[{DateTime.Now:HH:mm:ss}] DSRewards9");
						goto DragonSlayerReward;

					DragonSlayerReward:
						SafeEquip(FarmClass);
						ItemFarm("Wisp of Dragonspirit", 12, true, true, 169, "Wyvern", "lair");
								bot.Log($"[{DateTime.Now:HH:mm:ss}] DSRewards10");
						ExitCombat();
						bot.Quests.EnsureComplete(169);					
								bot.Log($"[{DateTime.Now:HH:mm:ss}] DSRewards11");		
				}	
				public void Leveling()
				{
					
					bot.Player.Join($"{"icestormarena"}-{1}", "r4", "Bottom");
						while (bot.Player.Level < 51)	
						{
						bot.SendPacket("%xt%zm%aggroMon%32640%70%71%72%73%74%75%");
						
							AttackType("a", "*");
							bot.Sleep(2500);
						}						
							bot.SendPacket("%xt%zm%enhanceItemShop%33392%15651%19606%768%");					
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
			bot.Sleep(1000);
			bot.Player.EquipItem(ItemName);
			bot.Sleep(1000);
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
		bot.Options.AutoRelogin = false;
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
	public void ConfigureBotOptions(string PlayerName = "Tato", string GuildName = "https://auqw.tk/", bool LagKiller = true, bool SafeTimings = true, bool RestPackets = true, bool AutoRelogin = true, bool PrivateRooms = false, bool InfiniteRange = true, bool SkipCutscenes = true, bool ExitCombatBeforeQuest = true, bool HideMonster=true)
	{
		SendMSGPacket("Drink Water.", "You Look Thirsty :(", "moderator");
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
		//bot.Events.PlayerDeath += PD => ScriptManager.RestartScript();
		//bot.Events.PlayerAFK += PA => ScriptManager.RestartScript();
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
				bot.Sleep(200);
				SafeEquip(Item);
				bot.Sleep(200);
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
