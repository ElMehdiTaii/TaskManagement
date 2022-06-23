using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Notifier.Interface;

namespace TaskManagement.Notifier.Repository
{
    public class InformHub : Hub<IHubClient>
    {
    }
}
