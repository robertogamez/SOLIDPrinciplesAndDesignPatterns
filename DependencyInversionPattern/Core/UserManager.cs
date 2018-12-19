using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInversionPattern.Core
{
    public class UserManager
    {
        public INotifier Notifier { get; set; }

        public UserManager(INotifier notifier)
        {
            this.Notifier = notifier;
        }

        public void ChangePassword(string username, string oldpwd, string newpwd)
        {
            Notifier.Notify("Password was changed on " + DateTime.Now);
        }
    }
}
