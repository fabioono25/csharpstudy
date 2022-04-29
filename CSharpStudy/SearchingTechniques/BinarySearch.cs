namespace CSharpStudy.SearchingTechniques
{
    public class BinarySearch
    {
        public static int returnIndex(int[] items, int startIndex, int endIndex, int item)
        {

            if (endIndex < startIndex)
            {
                Console.WriteLine("No solution found...");
                return -1;
            }

            int middleIndex = (startIndex + endIndex) / 2;

            if (endIndex < startIndex)
                returnIndex(items, endIndex, startIndex, item);

            if (item == items[middleIndex])
                return middleIndex;

            if (item < items[middleIndex])
                return returnIndex(items, startIndex, middleIndex - 1, item);

            return returnIndex(items, middleIndex + 1, endIndex, item);

        }
    }
}