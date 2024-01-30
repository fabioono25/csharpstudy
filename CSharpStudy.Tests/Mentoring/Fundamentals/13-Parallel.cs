using System.Threading.Tasks;

public class Parallel
{
  [Fact]
  public void ParallelTest()
  {
    // Calculate prime numbers using a simple (unoptimized) algorithm.

    IEnumerable<int> numbers = Enumerable.Range(3, 100000 - 3);

    var parallelQuery =
      from n in numbers.AsParallel()
      where Enumerable.Range(2, (int)Math.Sqrt(n)).All(i => n % i > 0)
      select n;

    int[] primes = parallelQuery.ToArray();
  }

  [Fact]
  public void ForAllTest()
  {
    // ForAll: Perform an action on each element of a parallel sequence.
    "abcdef".AsParallel().Select(c => char.ToUpper(c)).ForAll(Console.Write);
  }

  // AsParallel: Convert a sequence to a parallel sequence.
  // AsOrdered: Preserve the order of the elements in the original sequence.

  [Fact]
  public void AggregateTest()
  {
    // Aggregate: Perform a parallel aggregation on a sequence.
    int[] numbers = [1, 2, 3, 4, 5, 6, 7, 8, 9];
    var result = numbers.AsParallel().Aggregate(
      () => 0,                                      // seedFactory
        (localTotal, n) => localTotal + n,           // updateAccumulatorFunc
        (mainTot, localTot) => mainTot + localTot,   // combineAccumulatorFunc
        finalResult => finalResult);                  // resultSelector
  }

  [Fact]
  public void TaskWhenAllTest()
  {
    TaskCreationOptions atp = TaskCreationOptions.AttachedToParent;
    Task.Factory.StartNew(() =>
    {
      Task.Factory.StartNew(() => { throw null; }, atp);
      Task.Factory.StartNew(() => { throw null; }, atp);
      Task.Factory.StartNew(() => { throw null; }, atp);
    })
    .ContinueWith(p => Console.WriteLine(p.Exception),
                        TaskContinuationOptions.OnlyOnFaulted);
  }
}