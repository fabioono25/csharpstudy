using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CSharpStudy.CSharp7
{
    public class PatternMatching2
    {
        public static void ExecuteExample(){
            
            List<object> list = new List<object>();
            list.Add(1);
            list.Add(4);
            list.Add(5);
            list.Add(new List<object>{10,20,30});

            Console.WriteLine($"Simple Sum: {DiceSum(list)}");
            Console.WriteLine($"Sum with Case: {DiceSumWithCase(list)}");
        }

        //with this strategy, we create a new return variable
        public static int DiceSum(IEnumerable<object> values){
            var sum = 0;
            foreach (var item in values)
            {
                if (item is int val)
                    sum += val;
                else if (item is IEnumerable<object> subList)
                    sum += DiceSum(subList);
            }

            return sum;
        }

        //matching with case
        public static int DiceSumWithCase(IEnumerable<object> values){
            var sum = 0;
            foreach (var item in values)
            {
                switch (item){
                    case 0:
                        break;
                    case int val:
                        sum += val;
                        break;
                    case PercentileDice dice:
                        sum += dice.TensDigit + dice.OnesDigit;
                        break;
                    case IEnumerable<object> subList when subList.Any():
                        sum += DiceSumWithCase(subList);
                        break;
                    case IEnumerable<object> subList:
                        break;
                    case null:
                        break;
                    default:
                        throw new InvalidOperationException("Unknown item type");
                }
            }

            return sum;
        }
    }

    public struct PercentileDice
    {
        public int OnesDigit { get; }
        public int TensDigit { get; }

        public PercentileDice(int tensDigit, int onesDigit)
        {
            this.OnesDigit = onesDigit;
            this.TensDigit = tensDigit;
        }
    }

}