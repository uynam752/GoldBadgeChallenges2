using System;
using System.Collections.Generic;
using System.Security.Claims;
using _02_Claims;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _02_ClaimsTests
{
    [TestClass]
    public class ClaimsRepositoryTests
    {
        ClaimRepository _claims = new ClaimRepository();
        private void Arrange()
        {
            Claim claim1 = new Claim("123456", ClaimType.Car, "Wreck", 1000m, new DateTime(2020, 1, 1), new DateTime(2020, 1, 7));
            _claims.AddClaimToQueue(claim1);

            Claim claim2 = new Claim("123457", ClaimType.Theft, "Stolen stuff", 2000m, new DateTime(2020, 1, 1), new DateTime(2020, 2, 4));
            _claims.AddClaimToQueue(claim2);

            Claim claim3 = new Claim("123458", ClaimType.Home, "Flooded basement", 5000m, new DateTime(2020, 1, 1), new DateTime(2020, 1, 15));
            _claims.AddClaimToQueue(claim3);

            Claim claim4 = new Claim("123459", ClaimType.Car, "Bad wreck", 6000m, new DateTime(2020, 1, 1), new DateTime(2020, 1, 2));
            _claims.AddClaimToQueue(claim4);
        }
        [TestMethod]
        public void AddClaimToQueue_ShouldReturnCorrectCount()
        {
            //Arrange
            Claim claim2 = new Claim("123457", ClaimType.Theft, "Stolen stuff", 2000m, new DateTime(2020, 1, 1), new DateTime(2020, 2, 4));
            Claim claim3 = new Claim("123458", ClaimType.Home, "Flooded basement", 5000m, new DateTime(2020, 1, 1), new DateTime(2020, 1, 15));
            Claim claim4 = new Claim("123459", ClaimType.Car, "Bad wreck", 6000m, new DateTime(2020, 1, 1), new DateTime(2020, 1, 2));

            //Act
            bool isFalse2 = _claims.AddClaimToQueue(claim2);
            bool isTrue3 = _claims.AddClaimToQueue(claim3);
            bool isTrue4 = _claims.AddClaimToQueue(claim4);

            //Assert
            Assert.AreEqual(2, _claims.GetNumberOfClaims());
            Assert.IsFalse(isFalse2);
            Assert.IsTrue(isTrue3);
            Assert.IsTrue(isTrue4);

        }
        [TestMethod]
        public void GetNextClaim_ShouldReturnCorrectClaim()
        {
            //Arrange
            Arrange();

            //Act
            Claim claim = _claims.GetNextClaim();

            //Assert
            Assert.AreEqual("123456", claim.ID);
            Assert.AreEqual(3, _claims.GetNumberOfClaims());
        }
        [TestMethod]
        public void GetAllClaims_ShouldReturnCorrectList()
        {
            //Arrange
            Arrange();
            //Act
            List<Claim> claims = _claims.GetAllClaims();
            //Assert
            Assert.AreEqual(3, claims.Count);
        }
        [TestMethod]
        public void RemoveNextClaim_ShouldReturnCorrectCount()
        {
            //Arrange
            Arrange();
            //Act
            Claim claim = _claims.RemoveNextClaim();
            //Assert
            Assert.AreEqual(2, _claims.GetNumberOfClaims());
        }
        [TestMethod]
        public void RemoveNextClaim_ShouldReturnCorrectClaim()
        {
            //Arrange
            Arrange();
            //Act
            Claim claim = _claims.RemoveNextClaim();
            //Assert
            Assert.AreEqual(1000m, claim.Amount);
        }
    }
}
