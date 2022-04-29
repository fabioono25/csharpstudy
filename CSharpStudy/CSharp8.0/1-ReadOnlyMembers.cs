using System.Threading.Tasks;

namespace CSharpStudy.CSharp7123
{
    public class ReadOnlyMembers
    {
        public async Task ExecuteExample()
        {
        }
    }

    public struct Item
    {
        private int Id { get; set; }

        public readonly override string ToString()
        {
            //Id += 1; //Error: cannot assign to Id because it's readonly
            return Id.ToString();
        }
    }
}