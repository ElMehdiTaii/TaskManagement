using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Notifier.Interface
{
    public interface IHubClient
    {
        Task InformMessage(string message);
    }
}
