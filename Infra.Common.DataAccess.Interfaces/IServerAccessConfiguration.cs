namespace Infra.Common.DataAccess.Interfaces
{
    public interface IServerAccessConfiguration
    {
        string Url { get; }
        string Login { get; }
        string Password { get; }

        string Options { get; init; }

        string GetConnectionString();
    }
}