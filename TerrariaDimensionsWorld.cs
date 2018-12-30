using Terraria;
using Terraria.ModLoader;

namespace TerrariaDimensions
{
    public class TerrariaDimensionsWorld : ModWorld
    {
        private static bool _firstTime = true;

        public override void PostWorldGen()
        {
            TerrariaDimensions.Instance.DimensionsManager.RegisterDimension(new Dimension("Origin", this, ReflectionMethods.GetWorldGenerator(), false));
        }

        public override void PostUpdate()
        {
            if (!_firstTime) return;

            _firstTime = false;
        }
    }
}
