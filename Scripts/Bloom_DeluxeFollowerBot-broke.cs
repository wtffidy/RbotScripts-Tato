// Bot By Bloom
// Deluxe Follower Bot
// Instructions: Just run the bot and choose the options in the pop-up

using System;
using RBot;
using RBot.Options;
using System.Collections.Generic;
using System.Windows.Forms;


public class Script {
	public ScriptInterface Bot;
	public List<int> SkillArray = new List<int>();
	public string OptionsStorage = "DeluxeFollowerConfig";

    public List<IOption> Options = new List<IOption>() {
        new Option<string>("TargetPlayer", "Target Player", "The Target Player Name", "Artix"),
        new Option<bool>("UseLockZone", "Use LockZone", "Lock zones that the bot will search to follow player.", false),
        new Option<string>("LockZones", "LockZone List", "List of lock zones separated by a comma. \nExample -> shadowrealm-9934, battlegrounda,tercessuinotlim", ""),
        new Option<string>("skillOrder", "Skill Order", "The order of skill execution. Use -> [1, 2, 3, 4, 5, 6] just like the aqw UI skill keys. Add wNumber to delay before executing a skill. Time is in ms, minimum of 10ms. Example -> 5,4,w800,1", "3,w200,4,w500,2,1")

    
    };

	public void ScriptMain(ScriptInterface bot){

		bot.Options.SafeTimings = true;
		bot.Options.RestPackets = true;
		bot.Options.PrivateRooms = true;
		bot.Options.InfiniteRange = true;
		bot.Options.PrivateRooms = false;
		bot.Options.SkipCutscenes = true;
		bot.Options.DisableFX = true;
		bot.Options.AggroMonsters = false;

		// Setup Skills
		string skillOrder = bot.Config.Get<string>("skillOrder");

		foreach (var i in skillOrder.Split(',')) {
			try {
				int a = int.Parse(i.Replace(" ", "").Replace("w", ""));
				if (a >= 1) {
					SkillArray.Add(a-1);
					bot.Log(a.ToString());
				}
			} catch {
				continue;
			}

			
		}


		// Setup Follower Variables
		string TargetPlayer = bot.Config.Get<string>("TargetPlayer");
		bool UseLockZone = bot.Config.Get<bool>("UseLockZone");
		string Cell, Pad;
		int GotoTries = 0;

		List<string> LockZones = new List<string>();
		string _lockzone = bot.Config.Get<string>("LockZones").Replace(" ", "");
		if (!string.IsNullOrEmpty(_lockzone)) {
			foreach (var zone in _lockzone.Split(',')) {
				LockZones.Add(zone.ToLower());
			}
		}
// %xt%warning%-1%Cannot goto to player in a Locked Zone.%



		foreach(var item in bot.GameProxy.Interceptors) {
			bot.Log(item.Priority.ToString());
		}

		// Following
		while (!bot.ShouldExit()) {

			// Checks map
			if (!bot.Map.PlayerExists(TargetPlayer)) {
				GotoTries += 1;
				if (bot.Player.State == 2) {
					bot.Player.Jump("Wait", "Spawn");
					while (bot.Player.State == 2) {}
				}
				bot.Log("Sus");
				bot.SendPacket($"%xt%zm%cmd%1%goto%{TargetPlayer}%");
				bot.Log("it ended wtf");
				bot.Sleep(2500);
				if (GotoTries == 3 && UseLockZone == true) {
					foreach(var zone in LockZones) {
						if (zone == "tercessuinotlim") {
							bot.Player.Jump("m22", "Center");
							bot.Sleep(500);
						}
						bot.Player.Join(zone, "Enter", "Spawn");
						bot.Wait.ForMapLoad(zone);
						if (bot.Map.PlayerExists(TargetPlayer)) {
							GotoTries = 0;
							break;
						}
					}
					GotoTries = 0;
				}
				continue;
			} else {
				GotoTries = 0;
			}



			// Checks Player Cell
			Cell = bot.Map.GetPlayer(TargetPlayer).Cell;
			if (Cell != bot.Player.Cell) {
				Pad = bot.Map.GetPlayer(TargetPlayer).Pad;
				bot.Player.Jump(Cell, Pad);
			}

			// Kills monsters 
			if (!(bot.Monsters.CurrentMonsters.Count == 0)) {
				SkillAttack(bot);
			}

			bot.Sleep(2500);
		}



	}

	public void SkillAttack(ScriptInterface bot, string Target="*") {
		bot.Player.Attack(Target);
		foreach(var skill in SkillArray) {			
			if (skill > 6) {
				bot.Sleep(skill);
			} else {
				bot.Player.UseSkill(skill);	
			}
		}
	}


}

