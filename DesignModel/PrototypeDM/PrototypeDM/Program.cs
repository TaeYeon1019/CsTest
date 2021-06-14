using System;
using System.Collections.Generic;

namespace PrototypeDM
{

    public interface IPrototype
    {
        IPrototype Clone();
        string GetName();
        void SetName(string name);
    }

    public class ConcretePrototype1 : IPrototype
    {
        private string _name;
        public IPrototype Clone()
        {
            ConcretePrototype1 prototype = new ConcretePrototype1();
            prototype.SetName(this._name);
            return prototype;
        }

        public string GetName()
        {
            return _name;
        }

        public void SetName(string name)
        {
            this._name = name;
        }

        public override string ToString()
        {
            return string.Format("Now in Prototype1, name = {0}", this._name);
        }
    }

    public class ConcretePrototype2 : IPrototype
    {
        private string _name;
        public IPrototype Clone()
        {
            ConcretePrototype2 prototype = new ConcretePrototype2();
            prototype.SetName(this._name);
            return prototype;
        }

        public string GetName()
        {
            return _name;
        }

        public void SetName(string name)
        {
            this._name = name;
        }

        public override string ToString()
        {
            return $"Now in Prototype2, name = {this._name}";
        }
    }

    public class PrototypeManager
    {
        /// <summary> 记录原型的编号和原型实例的对应关系</summary>
        private static Dictionary<string, IPrototype> _prototypeDict = new Dictionary<string, IPrototype>();

        /// <summary> 私有化构造方法，避免外部创建实例 </summary>
        private PrototypeManager()
        {
            
        }

        public static void SetPrototype(string prototypeId, IPrototype prototype)
        {
            _prototypeDict.Add(prototypeId, prototype);
        }

        public static void RemovePrototype(string prototypeId)
        {
            _prototypeDict.Remove(prototypeId);
        }
        
        public static IPrototype GetPrototype(string prototypeId)
        {
            _prototypeDict.TryGetValue(prototypeId, out var prototype);
            if (prototype == null)
            {
                Console.WriteLine("您希望获取的原型还没有注册或已被销毁");
            }
            return prototype;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IPrototype p1 = new ConcretePrototype1();
            PrototypeManager.SetPrototype("p1", p1);
            // 获取原型来创建对象
            IPrototype p3 = PrototypeManager.GetPrototype("p1").Clone();
            p3.SetName("张三");
            Console.WriteLine("第一个实例： {0}", p3);
            // 动态切换了实现
            IPrototype p2 = new ConcretePrototype2();
            PrototypeManager.SetPrototype("p1", p2);
            // 重新获取原型来创建对象
            IPrototype p4 = PrototypeManager.GetPrototype("p1").Clone();
            p3.SetName("李四");
            Console.WriteLine("第二个实例： {0}", p4);
            // 有人注销了这个原型
            PrototypeManager.RemovePrototype("p1");
            // 再次获取原型来创建对象
            IPrototype p5 = PrototypeManager.GetPrototype("p1").Clone();
            p5.SetName("王五");
            Console.WriteLine("第三个实例： {0}", p5);
            
        }
    }
}