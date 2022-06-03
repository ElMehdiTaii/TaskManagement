using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Notifier.Services;

namespace TaskManagement.Notifier.Models
{
    public class NotificationHub : Hub<IHubClient>
    {}
}
