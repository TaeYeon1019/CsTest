using System;

namespace ReadonlyReferenceTest
{
    class Program
    {
        public sealed class AType
        {
            public static readonly char[] InvalidChars = new char[] {'A', 'B', 'C'};
        }
        
        static void Main(string[] args)
        {
            // 下面三行代码是合法的，可通过编译
            // 可成功修改 InValidChars 数组中的字符
            AType.InvalidChars[0] = 'X';
            AType.InvalidChars[1] = 'Y';
            AType.InvalidChars[2] = 'Z';
            
            // 下一行代码是非法的，无法通过编译
            // 因为不能让 InvalidChars 引用别的什么东西
            // AType.InvalidChars = new char['X', 'Y', 'Z'];
        }
    }
}