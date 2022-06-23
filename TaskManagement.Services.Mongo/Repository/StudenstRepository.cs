using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Entities.Models;
using TaskManagement.Services.Contract.Interface;
using TaskManagement.Services.Mongo.Interfaces;

namespace TaskManagement.Services.Mongo.Repository
{
    public class StudenstRepository : RepositoryBase<Students>, IStudentsRepository
    {
        public StudenstRepository(IMongoContext context) : base(context)
        {
        }
    }
}
