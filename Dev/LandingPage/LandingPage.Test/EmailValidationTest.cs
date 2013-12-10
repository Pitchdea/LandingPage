using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace LandingPage.Test
{
    [TestFixture]
    class EmailValidationTest
    {
        [Test]
        public void _01_ShouldBeValidEmail()
        {
            var email = "test@foo.com";
            var result = EmailValidator.Validate(email);
            Assert.True(result, "Email should be valid but return value was false.");
        }

        [Test]
        public void _02_ShouldNotBeValidEmail_AtIsMissing()
        {
            var email = "test.foo.com";
            var result = EmailValidator.Validate(email);
            Assert.False(result, "Shouldn't be valid.");
        }

        [Test]
        public void _03_ShouldNotBeValidEmail_InvalidDomain()
        {
            var email = "test@foo";
            var result = EmailValidator.Validate(email);
            Assert.False(result, "Shouldn't be valid.");
        }

        [Test]
        public void _04_ShouldNotBeValidEmail_NameMissing()
        {
            var email = "@foo.com";
            var result = EmailValidator.Validate(email);
            Assert.False(result, "Shouldn't be valid.");
        }

        [Test]
        public void _05_ShouldNotBeValidEmail_IsEmpty()
        {
            var email = "";
            var result = EmailValidator.Validate(email);
            Assert.False(result, "Shouldn't be valid.");
        }

        [Test]
        public void _06_ShouldNotBeValidEmail_AddressTooLong() //SQL-limit set to 150 now
        {
            var begin = "";
            for (int i = 0; i < 139; i++) { begin += "a"; }

            var email = begin + "@foobar.com";
            var result = EmailValidator.Validate(email);
            Assert.True(result, "Should not be too long and thus should be valid.");

            begin += "a";
            var email2 = begin + "@foobar.com";
            var result2 = EmailValidator.Validate(email2);
            Assert.False(result2, "Shouldn't be valid.");
        }
    }
}
