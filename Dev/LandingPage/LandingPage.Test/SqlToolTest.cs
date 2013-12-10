using System;
using MySql.Data.MySqlClient;
using NUnit.Framework;

namespace LandingPage.Test
{
    [TestFixture]
    class SqlToolTest
    {
        private MySqlConnection _sqlConnection;
        private SqlTool _tool;

        private void ClearDataBase()
        {
            _sqlConnection.Open();
            var command = new MySqlCommand("delete from subsc_emails;", _sqlConnection);
            command.ExecuteNonQuery();
            _sqlConnection.Close();
        }

        [SetUp]
        public void SetUp()
        {
            string connectionString = @"Server=localhost; Database=pitchdealanding;Uid=root;Pwd=S@Uvdnk9u97Z>3@Q";
            _sqlConnection = new MySqlConnection(connectionString);
            _tool = new SqlTool();
            ClearDataBase();
        }

        [Test]
        public void _01_ShouldAddNewEmail()
        {
            string email = "test@foo.com";
            var result = _tool.SaveIfNotExists(email);
            Assert.True(result);

            _sqlConnection.Open();
            var command = new MySqlCommand(string.Format(@"select address from subsc_emails where address = '{0}';", email), _sqlConnection);
            var result2 = command.ExecuteScalar();
            _sqlConnection.Close();
            Assert.NotNull(result2, "Email not found in database.");
            Console.WriteLine("Passed.");
        }

        [Test]
        public void _02_ShouldNotAddSameEmailTwice()
        {
            string email = "test@foo.com";
            var result = _tool.SaveIfNotExists(email);
            Assert.True(result, "Method return value implies that the email was not added.");

            var result2 = _tool.SaveIfNotExists(email);
            Assert.False(result2, "Method return value implies that the email was added when a copy of it alrady existed.");
        }
    }
}
