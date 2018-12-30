using Terraria;
using Terraria.ModLoader;

namespace TerrariaDimensions
{
    public class TerrariaDimensionsWorld : ModWorld
    {
        private static bool _firstTime = true;

        public override void PostWorldGen()
        {
            TerrariaDimensions.Instance.DimensionsRegistry.Register(new Dimension("Origin", this, ReflectionMethods.GetCurrentWorldGenerator(), false));
        }

        public override void PostUpdate()
        {
            if (!_firstTime) return;

            _firstTime = false;
        }
    }
}
