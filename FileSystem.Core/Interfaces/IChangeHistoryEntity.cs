using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem.Core.Interfaces;

public interface IChangeHistoryEntity
{
    DateTime DateCreated { get; set; }
    DateTime DateModified { get; set; }
}
