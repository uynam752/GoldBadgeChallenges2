using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claims
{
    public enum ClaimType { Car, Home, Theft }
    public class Claim
    {
        public Claim()
        {
            this.ID = Guid.NewGuid().ToString().Remove(6);
        }
        public Claim(string id, ClaimType claimType, string description, decimal amount, DateTime incidentDate, DateTime claimDate)
        {
            this.ID = id;
            this.TypeOfClaim = claimType;
            this.Description = description;
            this.Amount = amount;
            this.DateOfIncident = incidentDate;
            this.DateOfClaim = claimDate;
        }
        public string ID { get; private set; }
        public ClaimType TypeOfClaim { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime DateOfIncident { get; set; } = new DateTime();
        public DateTime DateOfClaim { get; set; } = new DateTime();
        public bool IsValid
        {
            get
            {
                TimeSpan time = this.DateOfClaim - this.DateOfIncident;
                if (time.Days < 30 && time.Days > 0)
                    return true;
                else
                    return false;
            }
        }
    }
}
