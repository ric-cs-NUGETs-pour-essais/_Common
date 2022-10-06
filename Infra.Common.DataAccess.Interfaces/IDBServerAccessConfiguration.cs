namespace Infra.Common.DataAccess.Interfaces
{
    public interface IDBServerAccessConfiguration: IServerAccessConfiguration
    {
        string DatabaseName { get; init; }
    }
}