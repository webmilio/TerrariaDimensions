namespace TerrariaDimensions
{
    public sealed class DimensionsManager
    {
        public DimensionsManager(DimensionsRegistry dimensionsRegistry)
        {
            this.DimensionsRegistry = dimensionsRegistry;
        }

        public bool RegisterDimension(Dimension dimension)
        {
            return this.DimensionsRegistry.Register(dimension);
        }

        public Dimension GetDimension(string name) => this.DimensionsRegistry.Get(name);

        internal DimensionsRegistry DimensionsRegistry { get; }
    }
}
