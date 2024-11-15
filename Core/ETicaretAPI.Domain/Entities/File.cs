using ETicaretAPI.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;


namespace ETicaretAPI.Domain.Entities
{
    // All entities must derive from BaseEntity class to inherit certain properties as default
    public class File : BaseEntity
    {
        // Omits properties that are not wanted to be displayed during table creation
        [NotMapped]
        public override DateTime UpdatedDate { get => base.UpdatedDate; set => base.UpdatedDate = value; }

        //public string Showcase { get; set; }
        public string FileName { get; set; }
        public string Path { get; set; }
        public string Storage { get; set; }
    }
}
