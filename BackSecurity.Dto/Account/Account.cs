using System.Collections.Generic;

namespace BackSecurity.Dto.Account
{
    public class Account
    {

        public long UserId { get; set; }

        public long Rut { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName1 { get; set; }

        public string LastName2 { get; set; }

        public string Username { get; set; }

        public List<long> CompanyIds { get; set; }

        public List<Branch> Branches { get; set; }

        public class Branch
        {
            public string BranchCode { get; set; }
            public string BranchOfficeCode { get; set; }
            public long BranchOfficeCompanyId { get; set; }

            public Branch() { }
        }
    }
}