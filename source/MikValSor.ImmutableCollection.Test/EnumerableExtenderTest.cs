using MikValSor.Immutable;
using NUnit.Framework;
using System.Collections.Generic;

namespace MikValSor.ImmutableCollection.Test
{
	[TestFixture]
	public class EnumerableExtenderTest
	{
		[Test]
		public void ToImmutable_Array()
		{
			//Arrange
			var source = new char[] { 'A' };
			var immutableCollection = EnumerableExtender.ToImmutable(source);

			//Act
			source[0] = 'B';

			//Assert
			Assert.AreEqual('A', immutableCollection[0]);
		}
		[Test]
		public void ToImmutable_List()
		{
			//Arrange
			var source = new List<char> { 'A' };
			var immutableCollection = EnumerableExtender.ToImmutable(source);

			//Act
			source[0] = 'B';

			//Assert
			Assert.AreEqual('A', immutableCollection[0]);
		}
		[Test]
		public void ToImmutable_ImmutableCollection()
		{
			//Arrange
			var source = new ImmutableCollection<char>(new char[] { 'A' });

			//Act
			var immutableCollection = EnumerableExtender.ToImmutable(source);

			//Assert
			Assert.AreEqual('A', immutableCollection[0]);
		}
	}
}
