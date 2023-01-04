using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Diagnostics;
using Microsoft.VisualBasic.FileIO;
using System.Text.RegularExpressions;
using Nocksoft.IO.ConfigFiles;

namespace Frozen_Flame_Server_Launcher
{
    public partial class Window : Form
    {
        public Window()
        {
            InitializeComponent();
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.ServerName = ServerNameInput.Text;
            Properties.Settings.Default.ServerPassword = ServerPasswordInput.Text;
            Properties.Settings.Default.MaxPlayers = MaxPlayerNumber.Text;
            Properties.Settings.Default.GamePort = GamePortNumber.Text;
            Properties.Settings.Default.QueryPort = QueryPortNumber.Text;
            Properties.Settings.Default.RconPort = RconPortNumber.Text;
            Properties.Settings.Default.ServerPasswordCheck = ServerPasswordEnable.Checked;
            Properties.Settings.Default.PVPenabled = PVPenabled.Checked;
            Properties.Settings.Default.BuildingCosts = NoBuildingCost.Checked;
            Properties.Settings.Default.BuildingWoRest = BuildingWithoutRestrictions.Checked;
            Properties.Settings.Default.DisableOverweight = DisableOverweightSystem.Checked;
            Properties.Settings.Default.FlyEverywhere = Flyeverywhere.Checked;
            Properties.Settings.Default.DropEquipped = Dropequippeditemsafterdeath.Checked;
            Properties.Settings.Default.DropEquipable = Dropequipableitemsafterdeath.Checked;
            Properties.Settings.Default.DropFood = Dropfoodondeath.Checked;
            Properties.Settings.Default.LvlDrop = MinimalLevelToDropItemAfterDeathNumber.Text;
            Properties.Settings.Default.DruaDecay = DurabilityMinNumber.Text;
            Properties.Settings.Default.XPMultiplier = XPMultiplierNumber.Text;
            Properties.Settings.Default.DestroyRes = DestroyRes.Text;
            Properties.Settings.Default.RconPwdText = RconPwdInput.Text;
            Properties.Settings.Default.EAC = easyanticheat.Checked;
            Properties.Settings.Default.RestoreHealthOnLvl = RestoreHealthOnLvl.Checked;
            Properties.Settings.Default.FlyOverweight = FlyOverweight.Checked;
            Properties.Settings.Default.TeleportOverweight = TeleportOverweight.Checked;
            Properties.Settings.Default.BuldingPlayerDMG = BuldingPlayerDMG.Checked;
            Properties.Settings.Default.ArmorDeathInput = ArmorDeathInput.Text;
            Properties.Settings.Default.JumpStaminaCostInput = JumpStaminaCostInput.Text;
            Properties.Settings.Default.SprintStaminaCostInput = SprintStaminaCostInput.Text;
            Properties.Settings.Default.DurationOfDayInput = DurationOfDayInput.Text;
            Properties.Settings.Default.HealthAfterDeathInput = HealthAfterDeathInput.Text;
            Properties.Settings.Default.WeaponDurabilityInput = WeaponDurabilityInput.Text;
            Properties.Settings.Default.HalfSlowdownOverweightRatioInput = HalfSlowdownOverweightRatioInput.Text;
            Properties.Settings.Default.FullSlowdownOverweightRatioInput = FullSlowdownOverweightRatioInput.Text;
            Properties.Settings.Default.MonsterHealthMultiplierInput = MonsterHealthMultiplierInput.Text;
            Properties.Settings.Default.MonsterDamageMultiplierInput = MonsterDamageMultiplierInput.Text;
            Properties.Settings.Default.Save();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ServerNameInput.Text = Properties.Settings.Default.ServerName;
            ServerPasswordInput.Text = Properties.Settings.Default.ServerPassword;
            MaxPlayerNumber.Text = Properties.Settings.Default.MaxPlayers;
            GamePortNumber.Text = Properties.Settings.Default.GamePort;
            QueryPortNumber.Text = Properties.Settings.Default.QueryPort;
            RconPortNumber.Text = Properties.Settings.Default.RconPort;
            ServerPasswordEnable.Checked = Properties.Settings.Default.ServerPasswordCheck;
            PVPenabled.Checked = Properties.Settings.Default.PVPenabled;
            NoBuildingCost.Checked = Properties.Settings.Default.BuildingCosts;
            BuildingWithoutRestrictions.Checked = Properties.Settings.Default.BuildingWoRest;
            DisableOverweightSystem.Checked = Properties.Settings.Default.DisableOverweight;
            Flyeverywhere.Checked = Properties.Settings.Default.FlyEverywhere;
            Dropequippeditemsafterdeath.Checked = Properties.Settings.Default.DropEquipped;
            Dropequipableitemsafterdeath.Checked = Properties.Settings.Default.DropEquipable;
            Dropfoodondeath.Checked = Properties.Settings.Default.DropFood;
            MinimalLevelToDropItemAfterDeathNumber.Text = Properties.Settings.Default.LvlDrop;
            DurabilityMinNumber.Text = Properties.Settings.Default.DruaDecay;
            XPMultiplierNumber.Text = Properties.Settings.Default.XPMultiplier;
            DestroyRes.Text = Properties.Settings.Default.DestroyRes;
            RconPwdInput.Text = Properties.Settings.Default.RconPwdText;
            easyanticheat.Checked = Properties.Settings.Default.EAC;
            RestoreHealthOnLvl.Checked = Properties.Settings.Default.RestoreHealthOnLvl;
            FlyOverweight.Checked = Properties.Settings.Default.FlyOverweight;
            TeleportOverweight.Checked = Properties.Settings.Default.TeleportOverweight;
            BuldingPlayerDMG.Checked = Properties.Settings.Default.BuldingPlayerDMG;
            ArmorDeathInput.Text = Properties.Settings.Default.ArmorDeathInput;
            JumpStaminaCostInput.Text = Properties.Settings.Default.JumpStaminaCostInput;
            SprintStaminaCostInput.Text = Properties.Settings.Default.SprintStaminaCostInput;
            DurationOfDayInput.Text = Properties.Settings.Default.DurationOfDayInput;
            HealthAfterDeathInput.Text = Properties.Settings.Default.HealthAfterDeathInput;
            WeaponDurabilityInput.Text = Properties.Settings.Default.WeaponDurabilityInput;
            HalfSlowdownOverweightRatioInput.Text = Properties.Settings.Default.HalfSlowdownOverweightRatioInput;
            FullSlowdownOverweightRatioInput.Text = Properties.Settings.Default.FullSlowdownOverweightRatioInput;
            MonsterHealthMultiplierInput.Text = Properties.Settings.Default.MonsterHealthMultiplierInput;
            MonsterDamageMultiplierInput.Text = Properties.Settings.Default.MonsterDamageMultiplierInput;



            // Create the ToolTip and associate with the Form container.
            ToolTip toolTip1 = new ToolTip();

            // Set up the delays for the ToolTip.
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;
            // Force the ToolTip text to be displayed whether or not the form is active.
            toolTip1.ShowAlways = true;

            // Set up the ToolTip text for the Button and Checkbox.
            //toolTip1.SetToolTip(this.button1, "My button1");
            //toolTip1.SetToolTip(this.checkBox1, "My checkBox1");
            toolTip1.SetToolTip(this.ServerName, "Set your server name here");
            toolTip1.SetToolTip(this.ServerPassword, "Set your server password here.\nSpaces are not allowed.");
            toolTip1.SetToolTip(this.MaxPlayers, "Set maximum players for the server");
            toolTip1.SetToolTip(this.GamePort, "Set the game port here.\nPlayers will need it to connect to the server");
            toolTip1.SetToolTip(this.QueryPort, "Set query port here");
            toolTip1.SetToolTip(this.RconPort, "Set rcon port here.\nRcon is not working right now");
            toolTip1.SetToolTip(this.ServerPasswordEnable, "If this option is checked password protection for your server is activated");
            toolTip1.SetToolTip(this.PVPenabled, "Activates PVP mode");
            toolTip1.SetToolTip(this.NoBuildingCost, "If checked building will be free");
            toolTip1.SetToolTip(this.BuildingWithoutRestrictions, "Bulding physics will be deactivated\nby activating this option");
            toolTip1.SetToolTip(this.DisableOverweightSystem, "Disables overweight.\nyou can carry everything.");
            toolTip1.SetToolTip(this.Flyeverywhere, "No fly areas will no longer force you not to fly");
            toolTip1.SetToolTip(this.Dropequippeditemsafterdeath, "If checked you will drop equipped items after death");
            toolTip1.SetToolTip(this.Dropequipableitemsafterdeath, "If checked you will drop equip able items after death");
            toolTip1.SetToolTip(this.Dropfoodondeath, "If checked you will drop fode items after death");
            toolTip1.SetToolTip(this.MinimalLevelToDropItemAfterDeath, "Drop items after the configured player level");
            toolTip1.SetToolTip(this.DruabilityAfterDecay, "Examples:\nat 0.5 your house and workbenches will stay at 50% durability after decay\nat 1.0 your house and workbenches will stay at 100% durability after decay");
            toolTip1.SetToolTip(this.XPMultiplier, "Config the level up speed here\n1.0 = default level up speed.\n0.5 = level up speed x2.\n0.2 = level up speed x5");
            toolTip1.SetToolTip(this.DestroyResText, "the amount of resources you get back by destroy");
            toolTip1.SetToolTip(this.RconEnabled, "If this option is checked Rcon will be activated");
            toolTip1.SetToolTip(this.RconPwdText, "Set your rcon server password here.\nSpaces are not allowed.");
            toolTip1.SetToolTip(this.easyanticheat, "If checked Easy Anti Cheat\nis activated");
            toolTip1.SetToolTip(this.RestoreHealthOnLvl, "If checked restores health on levelup");
            toolTip1.SetToolTip(this.FlyOverweight, "If checked you can fly while overweight");
            toolTip1.SetToolTip(this.TeleportOverweight, "If checked you can teleport while overweight");
            toolTip1.SetToolTip(this.BuldingPlayerDMG, "If checked players and enemies cant attack buildings");
            toolTip1.SetToolTip(this.ArmorDeathText, "Sets the durability lose in number on armor\ndefault 25");
            toolTip1.SetToolTip(this.JumpStaminaCostText, "Sets the stamina you use while jumping");
            toolTip1.SetToolTip(this.SprintStaminaCostText, "Sets the stamina you use while sprinting");
            toolTip1.SetToolTip(this.DurationOfDayText, "Sets the duration of daytime in seconds");
            toolTip1.SetToolTip(this.HealthAfterDeathText, "Sets a multiplier for players Health after death\n1.0 = 100%\n0.5 = 50%");
            toolTip1.SetToolTip(this.WeaponDurabilityText, "Sets a multiplier for weapon durability use\ndefault 0.5 (default)");
            toolTip1.SetToolTip(this.HalfSlowdownOverweightRatioText, "Overweight - disable sprint for player after that % (200/100% by deualt)");
            toolTip1.SetToolTip(this.FullSlowdownOverweightRatioText, "Overweight - disable even run and getting new items after that % (300/150% by default)");
            toolTip1.SetToolTip(this.MonsterHealthMultiplierText, "Enemy health multiplier");
            toolTip1.SetToolTip(this.MonsterDamageMultiplierText, "Enemy damage multiplier");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("./SteamCMD/steamcmd.exe", "+login anonymous +app_update 1348640 validate +quit");
            }
            catch
            {
                MessageBox.Show("Please install SteamCMD first");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }


        private void SteamCMD_Click(object sender, EventArgs e)
        {
            String targetFolder = @"./SteamCMD/";
            String dlZipFile = @"./SteamCMD/steamcmd.zip";

            FileSystem.CreateDirectory("./SteamCMD/");

            if (File.Exists(dlZipFile))
            {
                File.Delete("./SteamCMD/steamcmd.zip");
            }

            using (WebClient Client = new WebClient())
            {
                //network.DownloadFile("https://steamcdn-a.akamaihd.net/client/installer/steamcmd.zip", "./SteamCMD/steamcmd.zip");
                Client.DownloadFile(new System.Uri("https://steamcdn-a.akamaihd.net/client/installer/steamcmd.zip"), "./SteamCMD/steamcmd.zip");
            }
            if (File.Exists("./SteamCMD/steamcmd.exe"))
            {
                File.Delete("./SteamCMD/steamcmd.exe");
            }
            ZipFile.ExtractToDirectory(dlZipFile, targetFolder);

            FileSystem.CreateDirectory("./SteamCMD/steamapps/common/Frozen Flame - Dedicated Server/FrozenFlame/Saved/Config/WindowsServer/");

            string GameINI = @"./SteamCMD/steamapps/common/Frozen Flame - Dedicated Server/FrozenFlame/Saved/Config/WindowsServer/Game.ini";
            if (File.Exists(GameINI))
                ;

            else
                File.Copy("./Default/inis/Game.ini", "./SteamCMD/steamapps/common/Frozen Flame - Dedicated Server/FrozenFlame/Saved/Config/WindowsServer/Game.ini");

            string EngineINI = @"./SteamCMD/steamapps/common/Frozen Flame - Dedicated Server/FrozenFlame/Saved/Config/WindowsServer/Engine.ini";
            if (File.Exists(EngineINI))
                ;

            else
                File.Copy("./Default/inis/Engine.ini", "./SteamCMD/steamapps/common/Frozen Flame - Dedicated Server/FrozenFlame/Saved/Config/WindowsServer/Engine.ini");

            MessageBox.Show("SteamCMD installed");
        }

        private void WindowsFirewall_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", @"c:\windows\system32\wf.msc");
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            FileSystem.CreateDirectory("./SteamCMD/steamapps/common/Frozen Flame - Dedicated Server/FrozenFlame/Saved/Config/WindowsServer/");

            Process.Start("explorer.exe", @".\SteamCMD\steamapps\common\Frozen Flame - Dedicated Server\FrozenFlame\Saved\Config\WindowsServer");
        }

        private void SaveFolder_Click(object sender, EventArgs e)
        {
            FileSystem.CreateDirectory("./SteamCMD/steamapps/common/Frozen Flame - Dedicated Server/FrozenFlame/Saved/SaveGames/");

            Process.Start("explorer.exe", @".\SteamCMD\steamapps\common\Frozen Flame - Dedicated Server\FrozenFlame\Saved\SaveGames");
        }

        private void SavedLogs_Click(object sender, EventArgs e)
        {
            FileSystem.CreateDirectory("./SteamCMD/steamapps/common/Frozen Flame - Dedicated Server/FrozenFlame/Saved/Logs/");

            Process.Start("explorer.exe", @".\SteamCMD\steamapps\common\Frozen Flame - Dedicated Server\FrozenFlame\Saved\Logs");
        }

        private void SaveServerSettings_Click(object sender, EventArgs e)
        {
            FileSystem.CreateDirectory("./SteamCMD/steamapps/common/Frozen Flame - Dedicated Server/FrozenFlame/Saved/Config/WindowsServer/");
            
            string GameINI = @"./SteamCMD/steamapps/common/Frozen Flame - Dedicated Server/FrozenFlame/Saved/Config/WindowsServer/Game.ini";
            if (File.Exists(GameINI))
                ;

            else
                File.Copy("./Default/inis/Game.ini", "./SteamCMD/steamapps/common/Frozen Flame - Dedicated Server/FrozenFlame/Saved/Config/WindowsServer/Game.ini");
            
            string EngineINI = @"./SteamCMD/steamapps/common/Frozen Flame - Dedicated Server/FrozenFlame/Saved/Config/WindowsServer/Engine.ini";
            if (File.Exists(EngineINI))
                ;

            else
                File.Copy("./Default/inis/Engine.ini", "./SteamCMD/steamapps/common/Frozen Flame - Dedicated Server/FrozenFlame/Saved/Config/WindowsServer/Engine.ini");

            INIFile iniFile3 = new INIFile("./Settings/Settings.ini");
            
            string value5 = ServerNameInput.Text.ToString();
            iniFile3.SetValue("", "MetaGameServerName", value5);

            string value6 = RconPortNumber.Value.ToString();
            iniFile3.SetValue("", "RconPort", value6);

            string value2 = ServerPasswordInput.Text.ToString();
            iniFile3.SetValue("", "ServerPassword", value2);

            string value7 = RconPwdInput.Text.ToString();
            iniFile3.SetValue("", "RconPassword", value7);


            INIFile iniFile = new INIFile("./SteamCMD/steamapps/common/Frozen Flame - Dedicated Server/FrozenFlame/Saved/Config/WindowsServer/Game.ini");

            string value = MaxPlayerNumber.Value.ToString();
            iniFile.SetValue("/Script/Engine.GameSession", "MaxPlayers", value);


            INIFile iniFile2 = new INIFile("./SteamCMD/steamapps/common/Frozen Flame - Dedicated Server/FrozenFlame/Saved/Config/WindowsServer/Engine.ini");

            string value3 = GamePortNumber.Value.ToString();
            iniFile2.SetValue("URL", "Port", value3);

            string value4 = QueryPortNumber.Value.ToString();
            iniFile2.SetValue("OnlineSubsystemSteam", "GamerServerQueryPort", value4);


            MessageBox.Show("Settings Saved");

        }

        private void SaveServerGameOptions_Click(object sender, EventArgs e)
        {
            FileSystem.CreateDirectory("./SteamCMD/steamapps/common/Frozen Flame - Dedicated Server/FrozenFlame/Saved/Config/WindowsServer/");
            
            string GameINI = @".\SteamCMD\steamapps\common\Frozen Flame - Dedicated Server\FrozenFlame\Saved\Config\WindowsServer\Game.ini";
            if (File.Exists(GameINI))
                ;

            else
                File.Copy(@"./Default/inis/Game.ini", @"./SteamCMD/steamapps/common/Frozen Flame - Dedicated Server/FrozenFlame/Saved/Config/WindowsServer/Game.ini");

            INIFile iniFile = new INIFile("./SteamCMD/steamapps/common/Frozen Flame - Dedicated Server/FrozenFlame/Saved/Config/WindowsServer/Game.ini");

            string value = PVPenabled.Checked.ToString();
            iniFile.SetValue("/Script/FrozenFlame.GameBalance", "bFreePVP", value);
            
            string value2 = XPMultiplierNumber.Text.ToString();
            iniFile.SetValue("/Script/FrozenFlame.GameBalance", "LevelUpFlameRate", value2);
            
            string value3 = MinimalLevelToDropItemAfterDeathNumber.Value.ToString();
            iniFile.SetValue("/Script/FrozenFlame.GameBalance", "MinimalLevelToDropItemAfterDeath", value3);

            string value4 = Dropequippeditemsafterdeath.Checked.ToString();
            iniFile.SetValue("/Script/FrozenFlame.GameBalance", "bDropEquippedItems", value4);

            string value5 = Dropequipableitemsafterdeath.Checked.ToString();
            iniFile.SetValue("/Script/FrozenFlame.GameBalance", "bDropEquipableItems", value5);

            string value6 = Dropfoodondeath.Checked.ToString();
            iniFile.SetValue("/Script/FrozenFlame.GameBalance", "bDropFoodItems", value6);

            string value7 = DurabilityMinNumber.Text.ToString();
            iniFile.SetValue("/Script/FrozenFlame.DecaySubsystemSettings", "MinDurability", value7);
            
            string value8 = NoBuildingCost.Checked.ToString();
            iniFile.SetValue("/Script/FrozenFlame.GameBalance", "bNoModuleCost", value8);

            string value9 = BuildingWithoutRestrictions.Checked.ToString();
            iniFile.SetValue("/Script/FrozenFlame.GameBalance", "bLimitlessSupport", value9);

            string value10 = DisableOverweightSystem.Checked.ToString();
            iniFile.SetValue("/Script/FrozenFlame.DefaultsOverTimeEffect", "bDisableOverweight", value10);

            string value13 = DestroyRes.Text.ToString();
            iniFile.SetValue("/Script/FrozenFlame.GameBalance", "bDemolishResourceDropMultiplier", value13);

            string value14 = ArmorDeathInput.Text.ToString();
            iniFile.SetValue("/Script/FrozenFlame.GameBalance", "ArmorDurabilityReducementAfterDeath", value14);

            string value15 = JumpStaminaCostInput.Text.ToString();
            iniFile.SetValue("/Script/FrozenFlame.GameBalance", "JumpStaminaCost", value15);

            string value16 = SprintStaminaCostInput.Text.ToString();
            iniFile.SetValue("/Script/FrozenFlame.GameBalance", "SprintStaminaCost", value16);

            string value17 = DurationOfDayInput.Text.ToString();
            iniFile.SetValue("/Script/FrozenFlame.GameBalance", "DurationOfDay", value17);

            string value18 = HealthAfterDeathInput.Text.ToString();
            iniFile.SetValue("/Script/FrozenFlame.GameBalance", "HealthRateAfterRespawn", value18);

            string value19 = WeaponDurabilityInput.Text.ToString();
            iniFile.SetValue("/Script/FrozenFlame.GameBalance", "DefaultWeaponDurabilityCost", value19);

            string value20 = HalfSlowdownOverweightRatioInput.Text.ToString();
            iniFile.SetValue("/Script/FrozenFlame.GameBalance", "HalfSlowdownOverweightRatio", value20);

            string value21 = FullSlowdownOverweightRatioInput.Text.ToString();
            iniFile.SetValue("/Script/FrozenFlame.GameBalance", "FullSlowdownOverweightRatio", value21);

            string value22 = MonsterHealthMultiplierInput.Text.ToString();
            iniFile.SetValue("/Script/FrozenFlame.GameBalance", "MonstersHealthMultiplier", value22);

            string value23 = MonsterDamageMultiplierInput.Text.ToString();
            iniFile.SetValue("/Script/FrozenFlame.GameBalance", "MonstersDamageMultiplier", value23);

            string value24 = RestoreHealthOnLvl.Checked.ToString();
            iniFile.SetValue("/Script/FrozenFlame.GameBalance", "bRestoreHealthOnLevelUp", value24);

            string value25 = FlyOverweight.Checked.ToString();
            iniFile.SetValue("/Script/FrozenFlame.GameBalance", "bIsAllowedToGlideWithOverweight", value25);

            string value26 = TeleportOverweight.Checked.ToString();
            iniFile.SetValue("/Script/FrozenFlame.GameBalance", "bIsAllowedToTeleportWithOverweight", value26);

            string value27 = BuldingPlayerDMG.Checked.ToString();
            iniFile.SetValue("/Script/FrozenFlame.GameBalance", "bInvulnerableModules", value27);

            string value11 = Flyeverywhere.Checked.ToString();
            string value12 = "True";
            if (value11 == value12)
                iniFile.SetValue("/Game/FrozenFlame/DataTables/Variables/BP_GameBalance_Base.BP_GameBalance_Base_C", "bApplyRestrictionsInsideEnergyBarriers", "0");
            else
                iniFile.SetValue("/Game/FrozenFlame/DataTables/Variables/BP_GameBalance_Base.BP_GameBalance_Base_C", "bApplyRestrictionsInsideEnergyBarriers", "1");

            MessageBox.Show("Game Options Saved");
        }

        private void start_Click(object sender, EventArgs e)
        {
            try
            {
                INIFile iniFile = new INIFile("./Settings/Settings.ini");
                string value = iniFile.GetValue("", "MetaGameServerName");
                string value2 = iniFile.GetValue("", "RconPort");
                string value3 = " -MetaGameServerName=\"" + value + "\"" + " -RconPort" + value2;
                string value4 = "";
                string value5 = ServerPasswordEnable.Checked.ToString();
                string value6 = "True";
                string value7 = "";
                string value8 = RconEnabled.Checked.ToString();
                string value9 = "";
                string value10 = "";
                string value11 = easyanticheat.Checked.ToString();
                string value12 = " -NoEAC";
                if (value5 == value6)
                    { 
                    value7 = iniFile.GetValue("", "ServerPassword");
                    value4 = " -ServerPassword=" + value7;
                    }
                if (value8 == value6)
                    {
                    value9 = iniFile.GetValue("", "RconPassword");
                    value10 = " -RconPassword=" + value9;
                    }
                if (value11 == value6)
                    value12 = "";

                Process.Start("./SteamCMD/steamapps/common/Frozen Flame - Dedicated Server/FrozenFlameServer.exe", "-log -LOCALLOGTIMES" + value3 + value4 + value10 + value12);
            }
            catch
            {
                MessageBox.Show("Please install SteamCMD and after it install Server");
            }
        }

        private void SaveBackup_Click(object sender, EventArgs e)
        {
            string sourcefolder = @"./SteamCMD/steamapps/common/Frozen Flame - Dedicated Server/FrozenFlame/Saved/SaveGames/";
            string sourcezipfolder = @"./Backups/";
            string datetime;
            DateTime date = DateTime.Now;
            datetime = date.ToString().Replace(":", "-") ;
            FileSystem.CreateDirectory(@"./Backups");
            FileSystem.CreateDirectory(@"./SteamCMD/steamapps/common/Frozen Flame - Dedicated Server/FrozenFlame/Saved/SaveGames/");
            ZipFile.CreateFromDirectory(sourcefolder,sourcezipfolder + "Backup " + datetime + ".zip");
            MessageBox.Show("Backup saved! Name: " + "Backup " + datetime + ".zip");
        }

        private void BackupFolder_Click(object sender, EventArgs e)
        {
            FileSystem.CreateDirectory(@"./Backups");
            FileSystem.CreateDirectory(@"./SteamCMD/steamapps/common/Frozen Flame - Dedicated Server/FrozenFlame/Saved/SaveGames/");
            Process.Start("explorer.exe", @".\Backups");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           Process.Start("explorer.exe", "http://github.com/ISpaikI/FFSL");
        }
    }
}