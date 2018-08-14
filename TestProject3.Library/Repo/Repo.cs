using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestProject3.Repo
{
    public class Repo
    {
        private readonly PizzaPalacedbContext _db;

        public Repo(PizzaPalacedbContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public IEnumerable<Users> GetUsertable()
        {
            List<Users> user = _db.Users.ToList();
            return user;

        }
    }
}
