using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Pokedex.Models
{
    public enum FileIoMessage
    {
        None,
        Complete,
        FileAccessError,
        RecordNotFound,
        NoRecordsFound
    }
}
