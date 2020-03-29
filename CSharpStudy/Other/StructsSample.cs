using System;

namespace CSharpStudy.CSharp1
{
    public struct CoOrds
    {
        public int x, y;

        public CoOrds(int p1, int p2)
        {
            x = p1;
            y = p2;
        }
    }

    public class StructSample
    {
        public static void ExecuteExample()
        {

            //initialize
            CoOrds coords1 = new CoOrds();
            CoOrds coords2 = new CoOrds(10, 5);

            Console.WriteLine($"Coords1 -> X: {coords1.x} - Y: {coords1.y}");
            Console.WriteLine($"Coords2 -> X: {coords2.x} - Y: {coords2.y}");

            coords1 = coords2;
            coords2.x = 200;
            coords2.y = 100;

            Console.WriteLine($"Coords1 -> X: {coords1.x} - Y: {coords1.y}");
            Console.WriteLine($"Coords2 -> X: {coords2.x} - Y: {coords2.y}");

            // Coords1 -> X: 0 - Y: 0
            // Coords2 -> X: 10 - Y: 5
            // Coords1 -> X: 10 - Y: 5
            // Coords2 -> X: 200 - Y: 100

        }
    }

}