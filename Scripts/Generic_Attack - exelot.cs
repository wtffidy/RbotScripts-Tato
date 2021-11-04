using RBot;

public class Script {
	
	int[] SkillOrder = { 1, 2, 3, 4 };

	public ScriptInterface bot => ScriptInterface.Instance;
	public void ScriptMain(ScriptInterface bot){
		bot.Options.SafeTimings = true;
		bot.Options.RestPackets = true;
		bot.Options.InfiniteRange = true;
		
		SkillList(SkillOrder);
		
		bot.Player.SetSpawnPoint()
		while(!bot.ShouldExit()){		
			bot.Player.Attack("*");
		}
	}
	
	/// <summary>
	/// Spams Skills when in combat. You can get in combat by going to a cell with monsters in it with bot.Options.AggroMonsters enabled or using an attack command against one.
	/// </summary>
	public void SkillList(params int[] Skillset)
	{
		bot.RegisterHandler(1, b =>
		{
			if (bot.Player.InCombat)
			{
				foreach (var Skill in Skillset)
				{
					bot.Player.UseSkill(Skill);
				}
			}
		});
	}
}
