﻿// Copyright (c) Aura development team - Licensed under GNU GPL
// For more information, see licence.txt in the main folder

using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Xml;
using Common.Database;
using Common.Events;
using Common.Network;
using Common.Tools;
using World.Scripting;
using World.Tools;
using World.World;
using Common.Data;

namespace World.Network
{
	public partial class WorldServer : Server<WorldClient>
	{
		public static readonly WorldServer Instance = new WorldServer();
		static WorldServer() { }
		private WorldServer() : base() { }

		private Timer _worldTimer, _creatureUpdateTimer;

		public override void Run(string[] args)
		{
			this.WriteHeader("World Server", ConsoleColor.DarkGreen);

			// Logger
			// --------------------------------------------------------------
			if (!Directory.Exists("../../logs/"))
				Directory.CreateDirectory("../../logs/");
			Logger.FileLog = "../../logs/world.txt";

			Logger.Info("Initializing server @ " + DateTime.Now);
			Logger.Info("Packet version: " + Op.Version);

			// Configuration
			// --------------------------------------------------------------
			Logger.Info("Reading configuration...");
			try
			{
				WorldConf.Load(args);
			}
			catch (FileNotFoundException)
			{
				Logger.Warning("Sorry, I couldn't find 'conf/world.conf'.");
			}
			catch (Exception ex)
			{
				Logger.Warning("There has been a problem while reading 'conf/world.conf'.");
				Logger.Exception(ex);
			}

			// Logger display filter
			// --------------------------------------------------------------
			Logger.Hide = WorldConf.ConsoleFilter;

			// Database
			// --------------------------------------------------------------
			Logger.Info("Connecting to database...");
			try
			{
				MabiDb.Instance.Init(WorldConf.DatabaseHost, WorldConf.DatabaseUser, WorldConf.DatabasePass, WorldConf.DatabaseDb);
				MabiDb.Instance.TestConnection();
			}
			catch (Exception ex)
			{
				Logger.Error("Unable to connect to database. (" + ex.Message + ")");
				this.Exit(1);
			}

			//Logger.Info("Clearing database cache...");
			//MabiDb.Instance.ClearDatabaseCache();

			// CS-S
			// --------------------------------------------------------------
			//var tmpPath = Path.Combine(Path.GetTempPath(), "CSSCRIPT");
			//if (Directory.Exists(tmpPath))
			//{
			//    Logger.Info("Clearing CSScript cache...");
			//    Directory.Delete(tmpPath, true);
			//}

			// Data
			// --------------------------------------------------------------
			Logger.Info("Loading data files...");
			this.LoadData(WorldConf.DataPath);

			// Commands
			// --------------------------------------------------------------
			Logger.Info("Loading commands...");
			CommandHandler.Instance.Load();

			// NPCs
			// --------------------------------------------------------------
			NPCManager.Instance.LoadNPCs();

			// Monsters
			// --------------------------------------------------------------
			Logger.Info("Spawning monsters...");
			NPCManager.Instance.LoadSpawns();

			// Timers
			// --------------------------------------------------------------
			_worldTimer = new Timer(WorldManager.Instance.Heartbeat, null, 1500 - ((DateTime.Now.Ticks) % 1500), 1500);
			_creatureUpdateTimer = new Timer(WorldManager.Instance.CreatureUpdates, null, 5000, 250);

			// Run the channel register method once, and then subscribe to the event that's run once per minute.
			this.OncePerMinute(null, null);
			ServerEvents.Instance.RealTimeTick += this.OncePerMinute;

			// Starto
			// --------------------------------------------------------------
			try
			{
				this.StartListening(new IPEndPoint(IPAddress.Any, WorldConf.ChannelPort));

				Logger.Status("World Server ready, listening on " + _serverSocket.LocalEndPoint.ToString());
			}
			catch (Exception ex)
			{
				Logger.Exception(ex, "Unable to set up socket; perhaps you're already running a server?");
				this.Exit(1);
			}

			Logger.Info("Type 'help' for a list of console commands.");
			this.ReadCommands();
		}

		private Timer _shutdownTimer1, _shutdownTimer2;
		protected override void ParseCommand(string[] args, string command)
		{
			switch (args[0])
			{
				case "help":
					{
						Logger.Info("Commands:");
						Logger.Info("  status       Shows some status information about the channel");
						Logger.Info("  shutdown     Announces and executes server shutdown");
						Logger.Info("  help         Shows this");
					}
					break;

				case "status":
					{
						Logger.Info("Creatures: " + WorldManager.Instance.GetCreatureCount());
						Logger.Info("Items: " + WorldManager.Instance.GetItemCount());
						Logger.Info("Online time: " + (DateTime.Now - _startTime).ToString(@"hh\:mm\:ss"));
					}
					break;

				case "shutdown":
					{
						int exitSeconds = 60;
						if (args.Length > 1)
							int.TryParse(args[1], out exitSeconds);

						int dcSeconds = 0;
						if (exitSeconds > 60)
							dcSeconds = dcSeconds = exitSeconds - 60;

						int dcTimerSeconds = exitSeconds - (exitSeconds - dcSeconds);

						// Broadcast a notice.
						var notice = PacketCreator.Notice("The server will shutdown in " + exitSeconds + " seconds, please log out before that time, for your own safety.", NoticeType.TOP_RED);
						WorldManager.Instance.Broadcast(notice, SendTargets.All, null);

						// Set a timer when to dc all remaining players.
						_shutdownTimer1 = new Timer((state) =>
						{
							var dc = new MabiPacket(Op.RequestClientDisconnect, 0x1000000000000001).PutSInt(dcSeconds * 1000);
							WorldManager.Instance.Broadcast(dc, SendTargets.All, null);
						}, null, dcTimerSeconds * 1000, Timeout.Infinite);

						// Set a timer when to exit this server.
						_shutdownTimer2 = new Timer((state) => { this.Exit(0, false); }, null, exitSeconds * 1000, Timeout.Infinite);

						Logger.Info("Shutting down in " + exitSeconds + " seconds.");
					}
					break;

				case "":
					break;

				default:
					Logger.Info("Unkown command.");
					goto case "help";
			}
		}

		private void OncePerMinute(object sender, EventArgs args)
		{
			uint stress = WorldManager.Instance.GetCharactersCount();

			// Let's asume 20 users would be a lot for now.
			// TODO: Option for max users.
			stress = (uint)Math.Min(75, Math.Ceiling(75 / 20.0f * stress));

			MabiDb.Instance.RegisterChannel(WorldConf.ServerName, WorldConf.ChannelName, WorldConf.ChannelHost, WorldConf.ChannelPort, stress);
		}
	}
}
