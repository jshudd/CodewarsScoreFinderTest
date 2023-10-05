using System;
namespace CodewarsScoreFinderTest.Tests
{
    public class UserTests
    {
        //ParseJSON() tests
        [Fact]
        public void ParseJSON_SUCCESS()
        {
            var user = new User()
            {
                Name = "",
                Honor = 0,
                JSON = @"{
    ""id"": ""5e81fb377cc6a20010e3254b"",
    ""username"": ""jshudd"",
    ""name"": ""Jeremy Huddleston"",
    ""honor"": 721,
    ""clan"": ""TrueCoders"",
    ""leaderboardPosition"": 54001,
    ""skills"": [],
    ""ranks"": {
        ""overall"": {
            ""rank"": -5,
            ""name"": ""5 kyu"",
            ""color"": ""yellow"",
            ""score"": 545
        },
        ""languages"": {
            ""csharp"": {
                ""rank"": -5,
                ""name"": ""5 kyu"",
                ""color"": ""yellow"",
                ""score"": 511
            },
            ""sql"": {
                ""rank"": -7,
                ""name"": ""7 kyu"",
                ""color"": ""white"",
                ""score"": 32
            },
            ""javascript"": {
                ""rank"": -8,
                ""name"": ""8 kyu"",
                ""color"": ""white"",
                ""score"": 2
            },
            ""swift"": {
                ""rank"": -8,
                ""name"": ""8 kyu"",
                ""color"": ""white"",
                ""score"": 10
            }
        }
    },
    ""codeChallenges"": {
        ""totalAuthored"": 0,
        ""totalCompleted"": 161
    }
}"
            };

            user.ParseJSON();

            Assert.Equal("Jeremy Huddleston", user.Name);
            Assert.Equal(721, user.Honor);
        }

        [Fact]
        public void ParseJSON_FAILED()
        {
            var user = new User() { JSON = "" };

            Assert.Throws<Newtonsoft.Json.JsonException>(() => user.ParseJSON());
            Assert.Null(user.Name);
            Assert.Null(user.Honor);
        }

        //PopulateList() tests
        [Fact]
        public void UserListPopulated_SUCCESS()
        {
            User.UsersList.Clear();

            var user1 = new User()
            {
                UserName = "jshudd"
            };
            var user2 = new User()
            {
                UserName = "mvdoyle"
            };
            var user3 = new User()
            {
                UserName = "CruzSanchez"
            };

            User.UsersList.Add(user1);
            User.UsersList.Add(user2);
            User.UsersList.Add(user3);

            User.PopulateList();

            Assert.Equal("Jeremy Huddleston", User.UsersList[0].Name);
            Assert.Equal("Michael Doyle", User.UsersList[1].Name);
            Assert.Equal("Cruz Sanchez", User.UsersList[2].Name);

            Assert.Equal(721, User.UsersList[0].Honor);
            Assert.Equal(1274, User.UsersList[1].Honor);
            Assert.Equal(941, User.UsersList[2].Honor);
        }

        [Fact]
        public void UserListPopulated_FAILED()
        {
            User.UsersList.Clear();

            User.PopulateList();

            var testList = new List<User>();

            Assert.Equal(testList, User.UsersList);
        }
    }
}