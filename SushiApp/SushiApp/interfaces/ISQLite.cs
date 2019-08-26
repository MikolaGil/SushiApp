using System;
using System.Collections.Generic;
using System.Text;

namespace SushiApp.interfaces
{
    public interface ISQLite
    {
        string GetDatabasePath(string filename);
    }
}
