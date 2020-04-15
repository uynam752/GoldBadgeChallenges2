using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claims
{
    public class ClaimRepository
    {
        Queue<Claim> _claims = new Queue<Claim>();
        public bool IsQueueEmpty
        {
            get
            {
                if (_claims.Count == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public bool AddClaimToQueue(Claim claim)
        {
            int initialCount = _claims.Count;
            if (claim != null && claim.IsValid)
            {
                _claims.Enqueue(claim);
                return initialCount == _claims.Count - 1;
            }
            else
            {
                return false;
            }
        }
        public Claim GetNextClaim()
        {
            if (_claims.Count > 0 && _claims.Peek().IsValid)
                return _claims.Peek();
            else
                return null;
        }
        public List<Claim> GetAllClaims()
        {
            return new List<Claim>(_claims);
        }
        public Claim RemoveNextClaim()
        {
            if (_claims.Count > 0)
                return _claims.Dequeue();
            else
                return null;
        }
        public int GetNumberOfClaims()
        {
            return _claims.Count;
        }
    }
}
