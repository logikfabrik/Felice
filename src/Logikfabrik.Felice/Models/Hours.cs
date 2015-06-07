//----------------------------------------------------------------------------------
// <copyright file="Hours.cs" company="Logikfabrik">
//     Copyright (c) 2015 anton(at)logikfabrik.se
// </copyright>
//----------------------------------------------------------------------------------

namespace Logikfabrik.Felice.Models
{
    using System;

    public class Hours
    {
        private readonly string name;
        private readonly DateTime date;
        private readonly TimeSpan from;
        private readonly TimeSpan to;

        public Hours(string name, DateTime date, TimeSpan from, TimeSpan to)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be null or white space.", "name");
            }

            this.name = name;
            this.date = date;
            this.from = from;
            this.to = to;
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name 
        {
            get
            {
                return this.name;
            } 
        }

        /// <summary>
        /// Gets the date.
        /// </summary>
        public DateTime Date
        {
            get
            {
                return this.date;
            }
        }

        /// <summary>
        /// Gets the hours from.
        /// </summary>
        public TimeSpan From
        {
            get
            {
                return this.from;
            }
        }

        /// <summary>
        /// Gets the hours to.
        /// </summary>
        public TimeSpan To
        {
            get
            {
                return this.to;
            }
        }
    }
}