using PM02E16533.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PM02E16533.Controllers
{
    public class DBSitios
    {
        readonly SQLiteAsyncConnection dbase;

        public DBSitios(string dbpath)
        {
            dbase = new SQLiteAsyncConnection(dbpath);

            /*Se crean las tablas*/
            dbase.CreateTableAsync<Tabla>();

        }

        public Task<int> SitioSave(Tabla sitio)
        {
            if (sitio.id != 0)//update del registro
            {
                return dbase.UpdateAsync(sitio);
            }
            else
            {
                return dbase.InsertAsync(sitio);//inserter nuevo registro
            }
        }

        public Task<List<Tabla>> getListSitio()
        {
            return dbase.Table<Tabla>().ToListAsync();//se convierte el resultado a una lista.
        }

        public async Task<Tabla> getSitio(int pid)
        {
            return await dbase.Table<Tabla>()//se usa explesion lamba
                .Where(i => i.id == pid)
                .FirstOrDefaultAsync();
        }

        public async Task<int> DeleteSitio(Tabla sitio)
        {
            return await dbase.DeleteAsync(sitio);
        }
    }
}
