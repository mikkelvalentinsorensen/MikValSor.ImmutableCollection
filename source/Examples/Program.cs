namespace Examples
{
class Program
{
static void Main(string[] args)
{
	var program = new Program();
	program.ImmutableCollectionExample();
}

void ImmutableCollectionExample()
{
	var source = new char[] { 'A' };
	var immutableCollection = new MikValSor.Immutable.ImmutableCollection<char>(source);

	//Change the source
	source[0] = 'B';

	//ImmutableCollection is the same
	System.Console.WriteLine($"immutableCollection[0]: {immutableCollection[0]}");
}
/**
	Output:
	immutableCollection[0]: A
**/


}
}
