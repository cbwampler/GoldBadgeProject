using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KomodoIns_Repo;

namespace KomodoIns_Tests
{
    [TestClass]
    public class UnitTest1
    {
        KomodoInsRepo claimDetails = new KomodoInsRepo();
        ClaimInfo claim1 = new ClaimInfo(1, ClaimType.Car, "Car slid on ice into guard rail", 10000m, Convert.ToDateTime("9/27/2020"), Convert.ToDateTime("9/30/2020"), true);
        ClaimInfo claim2 = new ClaimInfo(2, ClaimType.Theft, "Diamond ring stolen", 5000m, Convert.ToDateTime("9/27/2020"), Convert.ToDateTime("9/30/2020"), true);
        ClaimInfo claim3 = new ClaimInfo(3, ClaimType.Home, "basement flooded", 25000m, Convert.ToDateTime("9/1/2020"), Convert.ToDateTime("9/25/2020"), true);

        [TestMethod]
        public void AddClaimToList()
        {
            claimDetails.AddClaimToList(claim1);
            claimDetails.AddClaimToList(claim2);
            claimDetails.AddClaimToList(claim3);
        }

        [TestMethod]
        public void ViewAllClaims()
        {
            claimDetails.AddClaimToList(claim1);
            claimDetails.AddClaimToList(claim2);
            claimDetails.AddClaimToList(claim3);
            claimDetails.ViewAllClaims();
        }

        [TestMethod]
        public void DeleteClaimfromQueue()
        {
            claimDetails.AddClaimToList(claim1);
            claimDetails.AddClaimToList(claim2);
            claimDetails.AddClaimToList(claim3);
            claimDetails.DeleteClaimfromQueue();
        }

        [TestMethod]
        public void GetNextClaim()
        {
            claimDetails.AddClaimToList(claim1);
            claimDetails.AddClaimToList(claim2);
            claimDetails.AddClaimToList(claim3);
            claimDetails.GetNextClaim();
        }
    }
}
