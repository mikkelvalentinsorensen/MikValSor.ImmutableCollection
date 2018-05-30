Simple and small implementation of Immutable Collection.

Nuget package: [https://www.nuget.org/packages/MikValSor.ImmutableCollection](https://www.nuget.org/packages/MikValSor.ImmutableCollection)

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