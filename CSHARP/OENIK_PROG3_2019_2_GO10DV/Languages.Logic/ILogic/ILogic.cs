// <copyright file="ILogic.cs" company="Barta Zoltán Kevin">
// Copyright (c) Barta Zoltán Kevin. All rights reserved.
// </copyright>

namespace Languages.Logic
{
    using System.Collections.Generic;

    /// <summary>
    /// Interface for the business logic.
    /// </summary>
    /// <typeparam name="T">Type of the entry.</typeparam>
    public interface ILogic<T>
        where T : class
    {
        /// <summary>
        /// Getting all the entries.
        /// </summary>
        /// <returns>All the instances.</returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Removes a specific entry from the database.
        /// </summary>
        /// <param name="id">ID of the entry.</param>
        void Remove(int id);

        /// <summary>
        /// Modifies a specific entry of the table.
        /// </summary>
        /// <param name="id">ID of the entry.</param>
        /// <param name="value">New value.</param>
        void Modify(int id, int value);

        /// <summary>
        /// Adding a new entry into a table.
        /// </summary>
        /// <param name="entry">New entry.</param>
        void Insert(T entry);

        /// <summary>
        /// Getting one of the instances based on its id.
        /// </summary>
        /// <param name="id">ID of the instance.</param>
        /// <returns>Specific instance.</returns>
        T GetOne(int id);
    }
}
