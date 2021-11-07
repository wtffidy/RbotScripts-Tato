using RBot;
public class Script {
bot.Skills.StartSkills("Skills/CardiBisCardioBronchitis.xml"); 
// this should then be  ↑---------------------------------↑
// what you named the file ("Skills/groomedbyblewm.xml");
//you saved in step 1-----------
public void ScriptMain(ScriptInterface bot){
        bot.Player.Join("icestormarena");
        while(!bot.ShouldExit()){
        bot.Player.Hunt("Icy Wind");
        bot.SendPacket("%xt%zm%aggroMon%134123%70%71%72%73%74%75%");
        bot.Player.RejectAll();
    }
}
}