using Terraria.ModLoader;

namespace TerrariaDimensions
{
    public class TerrariaDimensions : Mod
    {
        public override void Load()
        {
            Instance = this;

            this.DimensionsManager = new DimensionsManager(new DimensionsRegistry());
        }

        public override void Unload()
        {
            Instance = null;
        }

        public DimensionsManager DimensionsManager { get; private set; }

        public static TerrariaDimensions Instance { get; private set; }
    }
}
