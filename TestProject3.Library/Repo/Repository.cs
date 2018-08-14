using System;
using System.Collections.Generic;
using System.Linq;

namespace TestProject3.Repo.Repository
{
    public class Repository
    {
        private readonly PizzaPalacedbContext _db;

        public Repository(PizzaPalacedbContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public IEnumerable<Users> GetUsertable()
        {
            List<Users> user = _db.Users.ToList();
            return user;
        }

        public IEnumerable<Users> GetError()
        {
            List<Users> user = _db.Users.Where(x => x.Name == "Raul").ToList();
            return user;
        }

        public IEnumerable<Room> GetRoomtable()
        {
            List<Room> room = _db.Room.ToList();
            return room;
        }
    }
}