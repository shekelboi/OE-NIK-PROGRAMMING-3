namespace Languages.Logic
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Languages.Data;
    using Languages.Repository;

    /// <summary>
    /// Accessible query methods for the user.
    /// </summary>
    public class Logic
    {
        /// <summary>
        /// The database.
        /// </summary>
        private static DatabaseEntities db = new DatabaseEntities();

        public static DatabaseEntities DB { get => db; }

        public static void InitDb()
        {
            db.Database.ExecuteSqlCommand(File.ReadAllText(@"..\..\..\Languages.Data\SQL\Table creation.sql")); // Because of some caching problem sometimes it doesn't work, if that's the case just modify anything in the source and rebuild the solution.
            db.SaveChanges();
        }
    }
}
