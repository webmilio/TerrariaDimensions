namespace TerrariaDimensions
{
    public interface ICanBeRegistered
    {
        string Name { get; }

        bool CanBeRemoved { get; }
    }
}