namespace CSharpStudy.SearchingTechniques
{
    public class LinearSearch
    {
        public static int returnIndex(int[] items, int item){

            for (int i = 0; i < items.Length; i++)
            {
                if (item == items[i])
                    return i;
            }

            return -1;
        }
    }
}    