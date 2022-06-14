﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Services.Contract.Services
{
    public interface IRepositoryWrapper
    {
        public IStudentsRepository Student { get; }
        public ITasksRepository Task { get; }
        public ITeachersRepository Teacher { get; }
    }
}
