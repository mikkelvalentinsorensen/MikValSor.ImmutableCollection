namespace Examples
{
class Program
{
static void Main(string[] args)
{
	var program = new Program();
	program.ImmutablCollectionExample();
}

void ImmutablCollectionExample()
{
	var source = new char[] { 'A' };
	var immutableCollection = new MikValSor.Immutable.ImmutablCollection<char>(source);

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
