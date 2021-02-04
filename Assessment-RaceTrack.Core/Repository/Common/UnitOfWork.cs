using Microsoft.EntityFrameworkCore;
using MyHomeDoor.Core.Data;
using MyHomeDoor.Core.Data.Models;

namespace MyHomeDoor.Core.Repository.Common
{
    public class UnitOfWork : IUnitOfWork
    {
        //public readonly DbContextOptions dbContext;
        public UnitOfWork(MyDoorStepDBContext _dbContext)
        {
            this.DBContext = _dbContext;
        }

        public MyDoorStepDBContext DBContext { get; }

        public void Commit()
        {
            throw new System.NotImplementedException();
        }
    }

       

        //public void Commit()
        //{
        //    throw new System.NotImplementedException();
        //}

        //public UnitOfWork(MyDoorStepDBContext dbContext)
        //{
        //    this.dbContext = dbContext;
        //}

        //private BaseRepository<Users> _users;
        //public IRepository<Users> Users => _users ?? (_users = new BaseRepository<Users>(this.dbContext));


        //public void Commit()
        //{
        //    dbContext.SaveChanges();
        //}
    }
