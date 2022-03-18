using Microsoft.EntityFrameworkCore;

namespace FileSystem.EF.DbModels
{
    public partial class FolderDbModel
    {
        public int Id { get; set; }
        public HierarchyId Node { get; set; } = null!;

        public short Level { get; set; }
        public string Name { get; set; } = null!;
        public bool IsDeleted { get; set; } = false;

        public FolderDbModel()
        {

        }

        public FolderDbModel(string name)
        {
            Name = name;
        }

        public FolderDbModel(string name, HierarchyId node)
            : this(name)
        {
            Node = node;
        }

    }
}
