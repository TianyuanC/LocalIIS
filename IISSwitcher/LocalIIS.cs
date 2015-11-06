using Microsoft.Web.Administration;
using System;
using IISSwitcher.Extensions;
using IISSwitcher.Extractions;

namespace IISSwitcher
{
    /// <summary>
    /// Class Local Env Variables
    /// </summary>
    public class LocalIIS
    {
        private readonly ServerManager serverManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="LocalIIS"/> class.
        /// </summary>
        public LocalIIS()
        {
            serverManager = new ServerManager();
            if (At == null || Ah == null || AtAppPool==null || AhAppPool==null)
            {
                Console.WriteLine("WebSite doesn't exist! Terminate...");
                Console.ReadLine();
                Environment.Exit(0);
            }
        }
        /// <summary>
        /// Gets at.
        /// </summary>
        /// <value>At.</value>
        public Site At
        {
            get
            {
                return serverManager.Sites[Settings.LocalAt];
            }
        }

        /// <summary>
        /// Gets the ah.
        /// </summary>
        /// <value>The ah.</value>
        public Site Ah
        {
            get
            {
                return serverManager.Sites[Settings.LocalAh];
            }
        }

        /// <summary>
        /// Gets at application pool.
        /// </summary>
        /// <value>At application pool.</value>
        public ApplicationPool AtAppPool
        {
            get
            {
                return serverManager.ApplicationPools[Settings.LocalAt];
            }
        }

        /// <summary>
        /// Gets the ah application pool.
        /// </summary>
        /// <value>The ah application pool.</value>
        public ApplicationPool AhAppPool
        {
            get
            {
                return serverManager.ApplicationPools[Settings.LocalAh];
            }
        }

        /// <summary>
        /// Runs the task.
        /// </summary>
        public void RunTask()
        {
            Status();
            SwitchRepo();
            Save();
            Restart();
            Status();
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        public void Save()
        {
            serverManager.CommitChanges();
        }

        /// <summary>
        /// Restarts this instance.
        /// </summary>
        public void Restart()
        {
            Console.WriteLine("Recycle starting...");
            AtAppPool.Recycle();
            AhAppPool.Recycle();
            Console.WriteLine("Recycle complete");
        }

        /// <summary>
        /// Updates at ah physical path.
        /// </summary>
        /// <param name="path">The path.</param>
        private void UpdateAtAhPhysicalPath(string path)
        {
            At.UpdatePhysicalPath(path);
            Ah.UpdatePhysicalPath(path);
        }

        /// <summary>
        /// Switches the repo.
        /// </summary>
        public void SwitchRepo()
        {
            UpdateAtAhPhysicalPath(this.At.IsGit() ? Settings.TfsPath : Settings.GitPath);
        }

        /// <summary>
        /// Statuses this instance.
        /// </summary>
        public void Status()
        {
            Console.WriteLine("AT: {0}", At.PhysicalPath());
            Console.WriteLine("AH: {0}", Ah.PhysicalPath());
        }
    }
}
