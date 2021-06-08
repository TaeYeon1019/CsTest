using System;
using System.Collections.Generic;

namespace StrategyModel
{
    class Program
    {
        private interface IStrategy
        {
            void StrategyInterface();
        }
        
        private class ConcreteStrategyA :IStrategy
        {
            public void StrategyInterface()
            {
                Console.WriteLine("[StrategyModel]--Func: ConcreteStrategyA");
            }
        }
        
        private class ConcreteStrategyB :IStrategy
        {
            public void StrategyInterface()
            {
                Console.WriteLine("[StrategyModel]--Func: ConcreteStrategyB");
            }
        }
        
        private static class ContextFactory
        {
            private static Dictionary<int, IStrategy> _strategies = new Dictionary<int, IStrategy>(2);
            
            public static void BuildStrategies(int key, IStrategy strategy)
            {
                if (_strategies.ContainsKey(key))
                {
                    Console.WriteLine("[Error.StrategyModel]--(添加失败，已存在对应key) key: {0}", key);
                }
                else
                {
                    _strategies.Add(key, strategy);
                }
            }

            public static IStrategy GetStrategyByKey(int key)
            {
                _strategies.TryGetValue(key, out var strategy);
                return strategy;
            }
        }

        private static void Main(string[] args)
        {
            ContextFactory.BuildStrategies(0, new ConcreteStrategyA());
            ContextFactory.BuildStrategies(1, new ConcreteStrategyB());
            
            ContextFactory.GetStrategyByKey(0)?.StrategyInterface();
            ContextFactory.GetStrategyByKey(1)?.StrategyInterface();
            ContextFactory.GetStrategyByKey(2)?.StrategyInterface();
            
        }
    }
}