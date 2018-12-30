using System.Reflection;
using Terraria;
using Terraria.World.Generation;

namespace TerrariaDimensions
{
    public static class ReflectionMethods
    {
        public static FieldInfo seedFieldInfo = typeof(WorldGenerator).GetField("_seed", BindingFlags.NonPublic | BindingFlags.Instance);
        public static FieldInfo worldGeneratorFieldInfo = typeof(WorldGen).GetField("_generator", BindingFlags.NonPublic | BindingFlags.Static);

        static ReflectionMethods()
        {

        }

        public static int GetSeed(this WorldGenerator worldGenerator) => (int)seedFieldInfo.GetValue(worldGenerator);

        public static WorldGenerator GetWorldGenerator() => (WorldGenerator)worldGeneratorFieldInfo.GetValue(null);


    }
}
