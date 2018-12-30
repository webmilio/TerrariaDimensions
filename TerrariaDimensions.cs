using Terraria.ModLoader;

namespace TerrariaDimensions
{
    public class TerrariaDimensions : Mod
    {
        public override void Load()
        {
            Instance = this;

            this.DimensionsRegistry = new DimensionsRegistry();
        }

        public override void Unload()
        {
            Instance = null;
        }

        public DimensionsRegistry DimensionsRegistry { get; private set; }

        public static TerrariaDimensions Instance { get; private set; }
    }
}
