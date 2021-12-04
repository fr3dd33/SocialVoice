namespace Application.Common.Configurations
{
    public class PostgresDbConnectionSettings
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Database { get; set; }

        public override string ToString()
        {
            return $"host={Host};port={Port};database={Database};user id={Username};password={Password}";
        }

        public static implicit operator string(PostgresDbConnectionSettings settings)
        {
            return settings.ToString();
        }
    }
}
