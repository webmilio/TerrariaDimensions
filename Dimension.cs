using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.World.Generation;

namespace TerrariaDimensions
{
    public class Dimension : ICanBeRegistered
    {
        protected readonly List<Entity> _entitiesInDimension = new List<Entity>();
            
        public Dimension(string name, ModWorld modWorld, WorldGenerator worldGenerator) : this(name, modWorld, true)
        {
        }

        public Dimension(string name, ModWorld modWorld, WorldGenerator worldGenerator, bool canBeRemoved)
        {
            this.Name = name;
            this.ModWorld = modWorld;
            this.CanBeRemoved = canBeRemoved;
        }

        public bool AddEntity(Entity entity)
        {
            if (_entitiesInDimension.Contains(entity)) return false;

            this._entitiesInDimension.Add(entity);
            return true;
        }

        public ModWorld ModWorld { get; }
        public WorldGenerator WorldGenerator { get; }

        public string Name { get; }
        public bool CanBeRemoved { get; }
    }
}
