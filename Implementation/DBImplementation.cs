using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Db4objects.Db4o;

namespace Implementation
{
    public class DBImplementation
    {
        public static string pathODB = Path.GetDirectoryName(Directory.GetCurrentDirectory()) + @"\ODBPerson.db4o";
        public static IObjectContainer db;

        public static void CreateDataBase()
        {
            try
            {
                Open();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                db.Close();
            }
        }
        /// <summary>
        /// Es necesario cerrar la conexion del objeto db
        /// </summary>
        public static void Open()
        {
            try
            {
                db = Db4oFactory.OpenFile(pathODB);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Inserta cualquier objeto en la BDD
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        public static void Insert<T>(T t)
        {
            try
            {
                Open();
                db.Store(t);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                db.Close();
            }
        }
        /// <summary>
        /// Select All para cualquier tipo de objeto
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<T> Select<T>()
        {
            List<T> t = new List<T>();
            try
            {
                Open();
                IObjectSet result = db.QueryByExample(typeof(T));
                foreach (T item in result)
                {
                    t.Add(item);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                db.Close();
            }
            return t;
        }
        /// <summary>
        /// Busca y selecciona un objeto filtrado
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static T SelectObject<T>(T t)
        {            
            try
            {
                Open();
                IObjectSet result = db.QueryByExample(t);
                foreach (T item in result)
                {
                    return item;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                db.Close();
            }
            return default;
        }        
        /// <summary>
        /// Elimina un objeto
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        public static void DeleteObject<T>(T t)
        {
            try
            {
                Open();
                IObjectSet result = db.QueryByExample(t);
                T found = (T)result.Next();
                db.Delete(found);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                db.Close();
            }
        }
    }
}
