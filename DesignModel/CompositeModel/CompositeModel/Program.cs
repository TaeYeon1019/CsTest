using System;
using System.Collections.Generic;

namespace CompositeModel
{
    class Program
    {
        private interface IStrategy
        {
            void StrategyInterface();
        }
        
        private class ConcreteStrategyA : IStrategy
        {
            public void StrategyInterface()
            {
                Console.WriteLine("[StrategyModel]---Func: ConcreteStrategyA");
            }
        }

        private class ConcreteStrategyB : IStrategy
        {
            public void StrategyInterface()
            {
                Console.WriteLine("[StrategyModel]---Func: ConcreteStrategyB");
            }
        }

        private static class ContextFactory
        {
            private static Dictionary<int, IStrategy> StrategyMap = new Dictionary<int, IStrategy>();

            public static void BuildContextFactory(int key, IStrategy strategy)
            {
                if (StrategyMap.ContainsKey(key))
                {
                    Console.WriteLine("[Error.Strategy]---Map中已经包含key： {0}", key);
                }
                else
                {
                    StrategyMap.Add(key, strategy);
                }
            }
            
            public static IStrategy GetContextFactory(int key)
            {
                StrategyMap.TryGetValue(key, out var Strategy);
                return Strategy;
            }
        }

        private static void Main(string[] args)
        {
            ContextFactory.BuildContextFactory(0, new ConcreteStrategyA());
            ContextFactory.BuildContextFactory(1, new ConcreteStrategyB());

            ContextFactory.GetContextFactory(0).StrategyInterface();
            ContextFactory.GetContextFactory(1).StrategyInterface();
            ContextFactory.GetContextFactory(2).StrategyInterface();
        }
    }
}