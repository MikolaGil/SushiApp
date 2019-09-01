using System;
using System.Collections.Generic;
using System.Text;

namespace SushiApp.interfaces
{
    interface ISushi
    {
        int Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        double Price { get; set; }

    }
}
