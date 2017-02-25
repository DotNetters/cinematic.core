using Cinematic.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;

namespace Cinematic.DAL
{
    public class CinematicEFDataContext : DbContext, IDataContext
    {
        #region Query expansion

        private class DbIncluder : QueryableExtensions.IIncluder
        {
            public IQueryable<T> Include<T, TProperty>(IQueryable<T> source, Expression<Func<T, TProperty>> path)
                where T : class
            {
                return EntityFrameworkQueryableExtensions.Include(source, path);
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Static constructor. Buildup the DbIncluder in the QueryableExtensions class
        /// </summary>
        static CinematicEFDataContext()
        {
            QueryableExtensions.Includer = new DbIncluder();
        }

        /// <summary>
        /// Constructs a new context instance using the given string as the name 
        /// or connection string for the database to which a connection will be made.
        /// </summary>
        /// <param name="nameOrConnectionString">Either the database name or a connection string.</param>
        public CinematicEFDataContext(DbContextOptions options) : base(options) { } 

        #endregion

        #region Unit of Work pattern operations

        void IDataContext.SaveChanges()
        {
            base.SaveChanges();
        }

        #endregion

        #region Repository pattern operations

        /// <summary>
        /// <see cref="IDataContext.Get"/>
        /// </summary>
        /// <typeparam name="T"><see cref="IDataContext.Get"/></typeparam>
        /// <param name="ids"><see cref="IDataContext.Get"/></param>
        /// <returns><see cref="IDataContext.Get"/></returns>
        public T[] Get<T>(object[] ids) where T : class, IBusinessEntity
        {

            T[] retVal = new T[ids.Count()];

            int i = 0;
            foreach (var id in ids)
            {
                retVal[i] = Find<T>(id);
                i++;
            }
            return retVal;
        }

        /// <summary>
        /// <see cref="IDataContext.Add"/>
        /// </summary>
        /// <typeparam name="T"><see cref="IDataContext.Add"/></typeparam>
        /// <param name="entity"><see cref="IDataContext.Add"/></param>
        public new void Add<T>(T entity) where T : class, IBusinessEntity
        {
            base.Add(entity);
        }

        /// <summary>
        /// <see cref="IDataContext.Remove{T}(Guid)"/>
        /// </summary>
        /// <typeparam name="T"><see cref="IDataContext.Remove{T}(Guid)"/></typeparam>
        /// <param name="id"><see cref="IDataContext.Remove{T}(Guid)"/></param>
        void IDataContext.Remove<T>(object id)
        {
            var entity = Find<T>(id);

            if (entity != null)
            {
                base.Remove(entity);
            }
            else
            {
                throw new Exception("No entity has been found with the specified identifier");
            }
        }

        /// <summary>
        /// <see cref="IDataContext.Remove{T}(T)"/>
        /// </summary>
        /// <typeparam name="T"><see cref="IDataContext.Remove{T}(T)"/></typeparam>
        /// <param name="entity"><see cref="IDataContext.Remove{T}(T)"/></param>
        void IDataContext.Remove<T>(T entity)
        {
            var foundEntity = Find<T>(entity.Id);
            if (foundEntity != null)
            {
                base.Remove(foundEntity);
            }
            else
            {
                throw new Exception("Entity has not been found");
            }
        }

        /// <summary>
        /// Actualiza los datos de una entidad en el contexto
        /// </summary>
        /// <typeparam name="T">Tipo de la entidad</typeparam>
        /// <param name="entity">Instancia de la entidad</param>
        void IDataContext.Update<T>(T entity)
        {
            Entry(entity).State = EntityState.Modified;
        }

        /// <summary>
        /// <see cref="IDataContext.Find{T}"/>
        /// </summary>
        /// <typeparam name="T"><see cref="IDataContext.Find{T}"/></typeparam>
        /// <param name="id"><see cref="IDataContext.Find{T}"/></param>
        /// <returns><see cref="IDataContext.Find{T}"/></returns>
        public T Find<T>(object id) where T : class, IBusinessEntity
        {
            return base.Find<T>(id);
        } 

        #endregion

        public DbSet<Seat> Seats { get; set; }

        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<Session> Sessions { get; set; }

        IEnumerable<Seat> IDataContext.Seats
        {
            get { return Seats; }
        }

        IEnumerable<Ticket> IDataContext.Tickets
        {
            get { return Tickets; }
        }

        IEnumerable<Session> IDataContext.Sessions
        {
            get { return Sessions; }
        }
    }
}
