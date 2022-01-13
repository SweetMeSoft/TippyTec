using SQLite;

using SQLiteNetExtensions.Extensions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

using TippyTec.Models;

namespace TippyTec.Handlers
{
    public class DBHandler
    {
        private static SQLiteConnection Database;

        private static DBHandler instance;

        public static DBHandler Instance => instance ?? (instance = new DBHandler());

        public DBHandler()
        {
            Database = new SQLiteConnection(Constants.DatabasePath, Constants.Flags);
        }

        public void DeleteDatabase()
        {
            Database.DropTable<Tip>();
            Database.DropTable<Author>();
        }

        public void UpdateTable<T>()
        {
            Database.CreateTable<T>();
        }

        public List<T> Select<T>(bool recursive = false) where T : new()
        {
            
            return Database.GetAllWithChildren<T>(null, recursive);
        }

        public T Select<T>(int id, bool recursive = false) where T : new()
        {
            
            return Database.GetWithChildren<T>(id, recursive);
        }

        public T Select<T>(string id, bool recursive = false) where T : new()
        {
            
            return Database.GetWithChildren<T>(id, recursive);
        }

        public List<T> Select<T>(Expression<Func<T, bool>> where, bool recursive = false) where T : new()
        {
            
            return Database.GetAllWithChildren(where, recursive);
        }

        public List<T> Select<T>(Expression<Func<T, string>> orderBy, bool recursive = false,
            params Expression<Func<T, object>>[] thenBy) where T : new()
        {
            
            var task = Database.GetAllWithChildren<T>(null, recursive);
            IOrderedQueryable<T> query = task.AsQueryable().OrderBy(orderBy);

            foreach (Expression<Func<T, object>> then in thenBy)
            {
                query = query.ThenBy(then);
            }

            return query.ToList();
        }

        public List<T> Select<T>(Expression<Func<T, bool>> where, Expression<Func<T, string>> orderBy,
            bool recursive = false, params Expression<Func<T, object>>[] thenBy)
            where T : new()
        {
            
            var list = Database.GetAllWithChildren(where, recursive);
            IOrderedQueryable<T> query = list.AsQueryable().OrderBy(orderBy);

            foreach (Expression<Func<T, object>> then in thenBy)
            {
                query = query.ThenBy(then);
            }

            return query.ToList();
        }

        public List<T> Select<T>(Expression<Func<T, bool>> where, IComparer<T> comparer, bool recursive = false)
            where T : new()
        {
            
            List<T> response = Database.GetAllWithChildren(where, recursive);
            response.Sort(comparer);
            return response;
        }

        public List<T> Select<T>(IComparer<T> comparer, bool recursive = false) where T : new()
        {
            
            List<T> response = Database.GetAllWithChildren<T>(null, recursive);
            response.Sort(comparer);
            return response;
        }

        public T Insert<T>(T obj) where T : new()
        {
            
            if (Database.Insert(obj) > 0)
            {
                return obj;
            }

            return new T();
        }

        public int Insert<T>(List<T> list)
        {
            
            return Database.InsertAll(list);
        }

        public int Insert<T>(IList<T> list)
        {
            
            return Database.InsertAll(list);
        }

        public int Insert<T>(ICollection<T> collection)
        {
            
            return Database.InsertAll(collection);
        }

        public bool Update<T>(T obj)
        {
            
            try
            {
                return Database.Update(obj) > 0;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Delete<T>(T obj)
        {
            
            return Database.Delete(obj) > 0;
        }

        public bool Delete<T>(int id)
        {
            
            return Database.Delete<T>(id) > 0;
        }

        public bool Delete<T>(Expression<Func<T, bool>> where) where T : new()
        {
            
            var clear = false;
            var toDelete = Select(where);
            foreach (var item in toDelete)
            {
                if (Database.Delete(item) > 0)
                {
                    clear = true;
                }
                else
                {
                    clear = false;
                    break;
                }
            }

            return clear;
        }
    }
}
