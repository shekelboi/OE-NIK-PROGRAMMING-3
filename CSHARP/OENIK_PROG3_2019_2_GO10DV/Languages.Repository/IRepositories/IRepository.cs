// <copyright file="IRepository.cs" company="Barta Zoltán Kevin">
// Copyright (c) Barta Zoltán Kevin. All rights reserved.
// </copyright>

namespace Languages.Repository
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Languages.Data;

    /// <summary>
    /// Interface for repositories.
    /// </summary>
    /// <typeparam name="T">Entity.</typeparam>
    public interface IRepository<T>
        where T : class
    {
        /// <summary>
        /// Removes a specific entry from the database.
        /// </summary>
        /// <param name="id">ID of the entry..</param>
        void Remove(int id);

        /// <summary>
        /// Modifying a value inside a table.
        /// </summary>
        /// <param name="id">ID of the entry.</param>
        /// <param name="value">New value.</param>
        void Modify(int id, int value);

        /// <summary>
        /// Adding a new entry into a table.
        /// </summary>
        /// <param name="entry">Entry.</param>
        void Insert(T entry);

        /// <summary>
        /// Getting an entity based on its ID.
        /// </summary>
        /// <param name="id">ID of the element.</param>
        /// <returns>An entity.</returns>
        T GetOne(int id);

        /// <summary>
        /// Listing all the entries.
        /// </summary>
        /// <returns>Returns result.</returns>
        IQueryable<T> GetAll();
    }
}
