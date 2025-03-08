namespace Spawn
{
    public class PoolInitializer
    {
        private IPool[] pools;

        public PoolInitializer(IPool[] pools)
        {
            this.pools = pools;

            InitializePools();
        }

        public void InitializePools()
        {
            foreach (var pool in pools)
            {
                pool.InitializePool();
            }
        }
    }
}
