using MikValSor.Immutable;
using NUnit.Framework;
using System.Collections.ObjectModel;
using System.Linq;

namespace MikValSor.ImmutableCollection.Test
{
	[TestFixture]
	public class ImmutableCollectionTest
	{
		[Test]
		public void ReadOnlyCollection_NotUsableAssumption()
		{
			//Arrange
			var source = new char[] { 'A' };
			var readonlyCollection = new ReadOnlyCollection<char>(source);

			//Act
			source[0] = 'B';

			//Assert
			Assert.AreNotEqual('A', readonlyCollection[0]);
		}

		[Test]
		public void ReadOnlyCollection_UsableIfClonedAssumption()
		{
			//Arrange
			var source = new char[] { 'A' };
			var readonlyCollection = new ReadOnlyCollection<char>(Enumerable.ToList(source));

			//Act
			source[0] = 'B';

			//Assert
			Assert.AreEqual('A', readonlyCollection[0]);
		}

		[Test]
		public void ImmutableCollection_Safe()
		{
			//Arrange
			var source = new char[] { 'A' };
			var immutableCollection = new ImmutableCollection<char>(source);

			//Act
			source[0] = 'B';

			//Assert
			Assert.AreEqual('A', immutableCollection[0]);
		}

		[Test]
		public void ImmutableCollection_Immutable_object_char()
		{
			//Arrange
			var validator = new MikValSor.Immutable.ImmutableValidator();
			object target = new ImmutableCollection<char>(new char[0]);

			//Act
			validator.EnsureImmutable(target);
			var actual = validator.IsImmutable(target);

			//Assert
			Assert.IsTrue(actual);
		}

		[Test]
		public void ImmutableCollection_Immutable_object_charArray()
		{
			//Arrange
			var validator = new MikValSor.Immutable.ImmutableValidator();
			object target = new ImmutableCollection<char[]>(new char[0][]);

			//Act
			var actual = validator.IsImmutable(target);

			//Assert
			Assert.IsFalse(actual);
		}

		[Test]
		public void ImmutableCollection_Immutable_Type_char()
		{
			//Arrange
			var validator = new MikValSor.Immutable.ImmutableValidator();
			System.Type target = typeof(ImmutableCollection<byte>);

			//Act
			validator.EnsureImmutable(target);
			var actual = validator.IsImmutable(target);

			//Assert
			Assert.IsTrue(actual);
		}

		[Test]
		public void ImmutableCollection_Immutable_Type_charArray()
		{
			//Arrange
			var validator = new MikValSor.Immutable.ImmutableValidator();
			System.Type target = typeof(ImmutableCollection<char[]>);

			//Act
			var actual = validator.IsImmutable(target);

			//Assert
			Assert.IsFalse(actual);
		}
	}
}
