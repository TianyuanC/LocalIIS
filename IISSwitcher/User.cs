using System.Security.Principal;
using System;

namespace IISSwitcher
{
    /// <summary>
    /// Class User.
    /// </summary>
    public class User
    {
        /// <summary>
        /// The current
        /// </summary>
        private WindowsIdentity Current;

        /// <summary>
        /// Gets a value indicating whether this instance is admin.
        /// </summary>
        /// <value><c>true</c> if this instance is admin; otherwise, <c>false</c>.</value>
        public bool IsAdmin
        {
            get
            {
                WindowsPrincipal principal = new WindowsPrincipal(Current);
                return principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        public User()
        {
            Current = WindowsIdentity.GetCurrent();
        }

        public void Check()
        {
            if (IsAdmin)
            {
                return;
            }
            Console.WriteLine("Needs admin access. Exiting...");
            Console.ReadLine();
            Environment.Exit(0);
        }
    }
}
