﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Business.Interfaces
{
    public interface ITaskManagementService
    {
        Task DeleteAllDataTask(int table);
        Task AddRandomDataTask(int table);
    }
}
