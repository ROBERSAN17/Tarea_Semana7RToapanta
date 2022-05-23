using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sema7RToapanta
{
    public interface DataBase
    {
        SQLiteAsyncConnection GetConnection();  //Implementado en cada proyecto android, IOS

    }
}
