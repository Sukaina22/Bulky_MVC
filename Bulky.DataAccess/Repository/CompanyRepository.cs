using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Repository
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        private readonly ApplicationDbContext _db;

        public CompanyRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Company obj)
        {
            var company = _db.Companies.FirstOrDefault(c=>c.Id == obj.Id); 
            if(company!=null)
            {
                company.Name = obj.Name;
                company.PhoneNumber = obj.PhoneNumber;
                company.City = obj.City;
                company.StreetAddress = obj.StreetAddress;
                company.PostalCode = obj.PostalCode;
                company.State = obj.State;
                _db.Companies.Update(company);
                _db.SaveChanges();
            }
        }
    }
}
