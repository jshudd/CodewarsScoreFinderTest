using System;
namespace CodewarsScoreFinderTest.Tests
{
	public class APITests
	{
		[Theory]
		[InlineData("jshudd")]
        [InlineData("chipelmer")]
        [InlineData("Bryantellius")]
        [InlineData("TheMrChaptastic")]
        [InlineData("mvdoyle")]
        [InlineData("amoriss")]
        [InlineData("CruzSanchez")]
        [InlineData("whitstroup")]
        public void APICallDoesReturnData_Success(string userName)
		{
			var result = API.CallAPI(userName);

			Assert.NotNull(result);
		}

		[Theory]
        [InlineData("jshuddabcdefg")]
        public void APICallDoesNOTReturnData(string userName)
		{
            Assert.Throws<AggregateException>(() => API.CallAPI(userName));
        }
	}
}

