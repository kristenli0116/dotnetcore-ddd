namespace Turakas.Domain.SharedKernel;

public abstract class Enumeration:IComparable
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CompareTo(object? obj)
    {
      return Id.CompareTo(((Enumeration)obj!).Id);
    }
}