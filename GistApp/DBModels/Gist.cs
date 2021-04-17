using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace GistApp.DBModels
{
    [Table("Gist")]
    public class Gist : IBaseDBModel
    {
        [PrimaryKey, AutoIncrement, Column("Id")]
        public int Id { get ; set; }
        public Owner Owner { get; set; }
        public List<File> Files { get; set; } 
    }
}
