using System.Collections.Generic;

namespace TerrariaDimensions.Registries
{
    public abstract class Registry<T> : IBaseRegistry where T : ICanBeRegistered
    {
        protected int clearRequestsAmount = 0;
        protected readonly List<T> items = new List<T>();
        protected readonly Dictionary<string, T> byName = new Dictionary<string, T>();

        protected Registry()
        {

        }

        public T Get(int index) => this.items[index];
        public T Get(string name) => this.byName.ContainsKey(name) ? this.byName[name] : default(T);

        public int GetIndex(T item) => this.items.IndexOf(item);
        public int GetIndex(string name) => this.GetIndex(byName[name]);

        public void RequestClear() => this.clearRequestsAmount++;

        internal bool ProcessClear()
        {
            if (this.clearRequestsAmount != 1) return false;

            this.SafeRemoveAll();
            return (this.ClearedAtRuntime = true);
        }

        internal void Clear()
        {
            items.Clear();
            byName.Clear();
        }

        public bool Register(T item)
        {
            if (byName.ContainsKey(item.Name))
                return false;

            lock (items)
            {
                items.Add(item);
                byName.Add(item.Name, item);
            }

            return true;
        }

        private bool Remove(T item)
        {
            if (!this.AllowsRemoval) return false;

            this.items.Remove(item);
            this.byName.Remove(item.Name);

            return true;
        }

        public bool SafeRemove(T item)
        {
            if (item.CanBeRemoved)
                return this.Remove(item);

            return false;
        }

        public void SafeRemoveAll()
        {
            for (int i = 0; i < this.items.Count; i++)
                SafeRemove(this.items[i]);
        }

        public int Count => this.items.Count;

        public bool Initialized { get; protected set; }
        public bool ClearedAtRuntime { get; private set; }
        public bool AllowsRemoval { get; private set; } = true;
    }
}