using FileSystem.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem.Core.FileSystem.Models
{
    public  class FolderModel : BaseEntity<int>
    {
        public List<FolderModel> SubFolders { get; set; } = new List<FolderModel>();
        public List<FileModel> Files { get; set; } = new List<FileModel>();
    }
}
