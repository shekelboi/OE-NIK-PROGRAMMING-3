// <copyright file="Logic.cs" company="Barta Zoltán Kevin">
// Copyright (c) Barta Zoltán Kevin. All rights reserved.
// </copyright>

namespace Languages.Logic
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Languages.Data;
    using Languages.Logic.Logics;
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

        /// <summary>
        /// Gets main databse.
        /// </summary>
        public static DatabaseEntities DB { get => db; }

        /// <summary>
        /// Initialization of the database.
        /// </summary>
        public static void InitDb()
        {
            db.Database.ExecuteSqlCommand(File.ReadAllText(@"..\..\..\Languages.Data\SQL\Table creation.sql")); // Because of some caching problem sometimes it doesn't work, if that's the case just modify anything in the source and rebuild the solution.
            db.SaveChanges();
        }

        /// <summary>
        /// Use custom DB.
        /// </summary>
        /// <param name="db">Database to use.</param>
        public static void SetCustomDb(DatabaseEntities db)
        {
            Logic.db = db;
        }
    }
}
