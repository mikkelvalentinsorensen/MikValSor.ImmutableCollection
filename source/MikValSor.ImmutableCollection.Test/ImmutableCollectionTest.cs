using MikValSor.Immutable;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
		public void ImmutableCollection_SafeTest()
		{
			//Arrange
			var source = new char[] { 'A' };
			var immutableCollection = new ImmutablCollection<char>(source);

			//Act
			source[0] = 'B';

			//Assert
			Assert.AreEqual('A', immutableCollection[0]);
		}
	}
}
