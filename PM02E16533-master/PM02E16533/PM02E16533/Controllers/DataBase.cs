using PM02E16533.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PM02E16533.Controllers
{
    public class DataBase
    {
        readonly SQLiteAsyncConnection dbase;

        public DataBase(string dbpath)
        {
            dbase = new SQLiteAsyncConnection(dbpath);

            /*Se crean las tablas*/
            dbase.CreateTableAsync<sitios>();

        }

        public Task<int> SitioSave(sitios sitio)
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

        public Task<List<sitios>> getListSitio()
        {
            return dbase.Table<sitios>().ToListAsync();//se convierte el resultado a una lista.
        }

        public async Task<sitios> getSitio(int pid)
        {
            return await dbase.Table<sitios>()//se usa explesion lamba
                .Where(i => i.id == pid)
                .FirstOrDefaultAsync();
        }

        public async Task<int> DeleteSitio(sitios sitio)
        {
            return await dbase.DeleteAsync(sitio);
        }
    }
}
