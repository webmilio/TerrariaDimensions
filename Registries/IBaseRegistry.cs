namespace TerrariaDimensions.Registries
{
    public interface IBaseRegistry
    {
        void RequestClear();

        int Count { get; }
    }
}
