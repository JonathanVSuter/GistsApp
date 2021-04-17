using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace GistApp.DBModels
{
    [Table("File")]
    public class File : IBaseDBModel
    {
        [PrimaryKey, AutoIncrement, Column("Id")]
        public int Id { get; set; }
    }
}
