	if(!bot.Inventory.Contains("Elders' Blood")){
				while(bot.Quests.IsDailyComplete(802)){
					NulgathLarvaeFarm(bot);
				}
					
				bot.Quests.EnsureAccept(802);
				
				bot.Player.Join("arcangrove");
				bot.Player.HuntForItem("Gorillaphant", "Slain Gorillaphant", 50, true);
				
				bot.Quests.EnsureComplete(802);
				
				bot.Wait.ForDrop("Elder's Blood");
				bot.Player.Pickup("Elder's Blood");
			}
			
			if(!bot.Inventory.Contains("Nulgath Shaped Chocolate")){
				while(bot.Player.Gold < 2000000){
					bot.Quests.EnsureAccept(236);
					bot.Player.Join("greenguardwest");
					bot.Player.HuntForItem("Big Bad Boar", "Were Egg", 1, true);
					bot.Quests.EnsureComplete(236);
					bot.Wait.ForDrop("Berserker Bunny");
					bot.Player.Pickup("Berserker Bunny");
					bot.Shops.SellItem("Berserker Bunny");
				}
				
				bot.Player.Join("citadel");
				bot.Shops.Load(44);
				bot.Sleep(10000);
				bot.Shops.BuyItem(44, "Nulgath Shaped Chocolate");
			}
			
			bot.Quests.EnsureComplete(5660);
			
			bot.Wait.ForPickup("Roentgenium of Nulgath");
			bot.Player.Pickup("Roentgenium of Nulgath");
		}
	}
	
	public void NulgathLarvaeFarm(ScriptInterface bot){
		bot.Quests.EnsureAccept(2566);	
		bot.Player.Join("elemental");	
		
		bot.Player.HuntForItem("Mana Golem", "Mana Energy For Nulgath", 1, false, true);
		bot.Player.HuntForItem("Mana Falcon|Mana Imp", "Charged Mana Energy for Nulgath", 5, true, true);
		
		bot.Quests.EnsureComplete(2566); 
		
		bot.Player.RejectExcept("gem of nulgath, unidentified 13, tainted gem, emblem of nulgath");
		bot.Player.Pickup("gem of nulgath", "unidentified 13", "tainted gem", "emblem of nulgath", "20, 1, 100, 20");
		
	}
}