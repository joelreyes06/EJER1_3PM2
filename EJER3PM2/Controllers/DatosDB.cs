using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace EJER3PM2.Controllers
{
    public class DatosDB
    {
        readonly SQLiteAsyncConnection _connection;

        //Constructor vacio
        public DatosDB()
        { }


        public DatosDB(String dbpath)
        {
            _connection = new SQLiteAsyncConnection(dbpath);
            //Creacion de objetos de base de datos
            _connection.CreateTableAsync<Models.Datos>().Wait();

        }

        //CRUD 
        public Task<int> StoreDatos(Models.Datos datos)
        {
            if (datos.Id == 0)
            {
                return _connection.InsertAsync(datos);
            }
            else
            {
                return _connection.UpdateAsync(datos);
            }
        }

        //read list
        public Task<List<Models.Datos>> ListaDatos()
        {
            return _connection.Table<Models.Datos>().ToListAsync();
        }


        //get
        public Task<Models.Datos> GetListaDatos(int pid)
        {
            return _connection.Table<Models.Datos>().Where(i => i.Id == pid).FirstOrDefaultAsync();
        }


        //delete
        public Task<int> DeleteDatos(Models.Datos datos)
        {
            return _connection.DeleteAsync(datos);
        }

    }
}
