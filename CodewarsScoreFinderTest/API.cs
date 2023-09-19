﻿using System;
namespace CodewarsScoreFinderTest
{
	public static class API
	{
		public static string CallAPI(string userName)
		{
			var cwURL = $"https://www.codewars.com/api/v1/users/{userName}";

			var client = new HttpClient();

			return client.GetStringAsync(cwURL).Result;
        }
	}
}

