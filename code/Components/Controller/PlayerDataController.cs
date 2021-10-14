using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sandbox;
using timeless.Components.Data;
/*using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore.Extensions;
using MySql.Data;*/
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace timeless.Components.Controller
{
	public static class PlayerDataController
	{

		public static void InsertData( BasePlayer player )
		{
			HttpWebRequest request =( HttpWebRequest)WebRequest
				.Create("localhost:8000/v1/player/data");
			request.Method = "POST";
			request.ContentType = "application/json";
			/*
			PlayerDataContext context = new();
			context.Database.EnsureCreated();

			context.Add( player.Level );
			context.Add( player.Currency );
			context.SaveChanges();*/
		}

		public static void PrintData()
		{
			/*
			PlayerDataContext context = new();
			var levels = context.Levels.Include( p => p.Player.steamId );
			foreach ( var level in levels )
			{
				var data = new StringBuilder();
				data.AppendLine( $"SteamID: {level.Player.steamId}" );
				data.AppendLine( $"Experience: {level.Experience}" );
				data.AppendLine( $"LevelAmount: {level.LevelAmount}" );
				Log.Info( data.ToString() );
			}*/
		}
	}
}
