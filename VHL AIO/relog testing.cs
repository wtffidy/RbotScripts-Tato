
public void ScriptMain(ScriptInterface bot)
{
    bot.Options.AutoRelogin = true;
    bot.Options.LoginServer = RBot.Servers.ServerList.Servers.Find(server => server.Name == "Twilly");
    bot.Log("Start");
    bot.Sleep(2000);
    Relogin();
    bot.Log(bot.Player.ServerIP);
    
    while(!bot.ShouldExit()) {bot.Sleep(2000);bot.Log("A");}
}