using System;
using System.IO;
using Microsoft.Data.Sqlite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace App31
{
	public partial class App : Application
	{
		public App() {
			InitializeComponent();

			var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "..", "Library");
			
			var sqLiteDbConnection = new SqliteConnection($"FileName={Path.Combine(path, "test.db")}");
			
			sqLiteDbConnection.Open();
            
			var commandPragma = sqLiteDbConnection.CreateCommand();
			commandPragma.CommandText = "PRAGMA key = 'testKey';";
			commandPragma.ExecuteNonQuery();
			
			var commandMigrate = sqLiteDbConnection.CreateCommand();
			commandMigrate.CommandText = "PRAGMA cipher_migrate;";
			var migrateResult = commandMigrate.ExecuteNonQuery();
			
			var commandInsert = sqLiteDbConnection.CreateCommand();
			commandInsert.CommandText = "INSERT INTO testTable(id) VALUES (1);";
			commandInsert.ExecuteNonQuery();
			
			var commandQuery = sqLiteDbConnection.CreateCommand();
			commandQuery.CommandText = "SELECT * FROM testTable;";
			var queryResult = commandQuery.ExecuteScalar();
			
			MainPage = new MainPage();
		}

		protected override void OnStart() {
			// Handle when your app starts
		}

		protected override void OnSleep() {
			// Handle when your app sleeps
		}

		protected override void OnResume() {
			// Handle when your app resumes
		}
	}
}