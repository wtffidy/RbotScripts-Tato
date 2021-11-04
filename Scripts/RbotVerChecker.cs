//made by purp i think?


using RBot;
using System.Windows.Forms;

public class Testingclass
{
    public ScriptInterface bot => ScriptInterface.Instance;

    public void ScriptMain(ScriptInterface bot)
    {

        VersionCheck("3.6.0.0"); //change this to current ver. #
        if (bot.Player.Cell != "Wait") bot.Player.Jump("Wait", "Spawn");


        while (!bot.ShouldExit())
        {
            while (!bot.Player.Loaded) { }
        }
    }

    /// <summary>
    /// Checks RBot version
    /// </summary>
    /// <param name="version"></param>
    public void VersionCheck(string version)
    {
        if (!Forms.Main.Text.StartsWith($"RBot {version}"))
        {
            MessageBox.Show($"Sorry, this script only works with RBot {version}+", "Load failed!");
            ScriptManager.StopScript();
        }
    }
}