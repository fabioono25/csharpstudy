using System;
using System.Threading.Tasks;

namespace CSharpStudy.CSharp7123
{
    public static class RefConditional
    {
        public static void ExecuteExample()
        {
            var array1 = new int[] { 1, 3, 5, 7, 9 };
            var array2 = new int[] { 1, 3, 5, 7, 9 };

            ref var ret = ref (array1 != null ? ref array1[0] : ref array2[0]);
        }
    }
}