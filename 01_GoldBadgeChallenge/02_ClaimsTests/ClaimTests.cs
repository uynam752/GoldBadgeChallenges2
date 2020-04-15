using System;
using _02_Claims;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _02_ClaimsTests
{
    [TestClass]
    public class ClaimTests
    {
        [TestMethod]
        public void IsValidGetter_ShouldReturnCorrectBool()
        {
            
            Claim claim = new Claim();
            claim.DateOfIncident = new DateTime(2020, 1, 1);
            claim.DateOfClaim = new DateTime(2020, 1, 8);

            Claim anotherClaim = new Claim();
            anotherClaim.DateOfIncident = new DateTime(2020, 1, 1);
            anotherClaim.DateOfClaim = new DateTime(2020, 2, 2);

            
            bool actual = claim.IsValid;
            bool anotherActual = anotherClaim.IsValid;

            
            Assert.IsTrue(actual);
            Assert.IsFalse(anotherActual);
        }
        [TestMethod]
        public void ConstructorTest_ShouldReturnRandomID()
        {
            
            Claim claim1 = new Claim();
            Claim claim2 = new Claim();
            Claim claim3 = new Claim();

            
            Console.WriteLine(claim1.ID);
            Console.WriteLine(claim2.ID);
            Console.WriteLine(claim3.ID);
        }
        [TestMethod]
        public void OverloadedConstructor_ShouldSetValues()
        {
            
            Claim claim = new Claim("321654", ClaimType.Car, "Wreck on I65", 5000.43m, new DateTime(2020, 2, 2), new DateTime(2020, 2, 4));

            
            Assert.AreEqual("321654", claim.ID);
            Assert.AreEqual(5000.43m, claim.Amount);
            Assert.AreEqual(ClaimType.Car, claim.TypeOfClaim);
        }
    }
}
