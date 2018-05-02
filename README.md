Simple and small implementation of Immutable Collection build on top of ReadOnlyCollection<T>. 

## ImmutableCollection Example:
```cs
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
```