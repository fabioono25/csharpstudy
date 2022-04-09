namespace CSharpStudy.CSharp10;

public class ExtendedPropertyPatterns
{
    public static void ExecuteExample()
    {
        var pet = new Pet
        {
            Name = "Jimmy",
            Age = 10,
            Owner = new PetOwner
            {
                Name = "James",
                Age = 22
            }
        };

        object obj = pet;
        // old way: if (obj is Pet { Owner: { Name: "James" } })
        // now, in a simplified way:
        if (obj is Pet { Owner.Name: "James" })
            WriteLine("Jame's pet");

        // same idea, now in a switch clause
        var isOwnerOliverOrJames = pet switch
        {
            { Owner.Name: "Oliver" }
              or { Owner.Name: "James" } => true,
            _ => false
        };
    }
}

internal class Pet
{
    public string Name { get; set; }
    public int Age { get; set; }
    public PetOwner Owner { get; set; }
}

internal class PetOwner
{
    public string Name { get; set; }
    public int Age { get; set; }
}