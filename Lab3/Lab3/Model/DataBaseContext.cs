using Npgsql;
using Microsoft.EntityFrameworkCore;

namespace DBLab2.Models
{
    /// <summary>
    /// Основний клас для роботи з БД(створення/підключення/робота з данними).
    /// </summary>
    internal class DataBaseContext : DbContext
    {
        private string? ConnectionString;

        public NpgsqlDataSource? DataSource { get; set; }

        public DataBaseContext(string? connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentException("Connection string is invalid!");
            
            ConnectionString = connectionString;
            ConnectToDBAsync();
        }

        public DataBaseContext(string? connectionString, int x)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!string.IsNullOrWhiteSpace(ConnectionString))
                optionsBuilder.UseNpgsql(ConnectionString);
            else
                throw new ArgumentException("Connection string is invalid!");
        }


        /// <summary>
        /// Підключення до бази даних.
        /// </summary>
        private void ConnectToDBAsync() => DataSource = NpgsqlDataSource.Create(ConnectionString);
    }
}