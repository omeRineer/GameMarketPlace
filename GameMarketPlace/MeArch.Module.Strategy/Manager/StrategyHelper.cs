using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeArch.Module.Strategy.Manager
{
    public static class StrategyHelper
    {
        private static List<IStrategy> Strategies = new List<IStrategy>();

        public static TBaseStrategy GetStrategy<TBaseStrategy, TStrategy>()
            where TStrategy : class, TBaseStrategy, new()
            where TBaseStrategy : class, IStrategy
        {
            var instance = Strategies.Single(X => X.GetType() == typeof(TStrategy)) as TBaseStrategy;

            return instance;
        }


        public static void SetStrategy<TStrategy>()
            where TStrategy : class, IStrategy
        {
            var assembly = typeof(TStrategy).Assembly;

            foreach (var type in assembly.GetTypes())
            {
                if (type.IsSubclassOf(typeof(TStrategy)))
                {
                    var strategy = Activator.CreateInstance(type) as TStrategy;

                    Strategies.Add(strategy);
                }
            }
        }
    }
}
