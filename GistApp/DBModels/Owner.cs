using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace GistApp.DBModels
{
    [Table("Owner")]
    public class Owner : IBaseDBModel
    {
        [PrimaryKey, AutoIncrement, Column("Id")]
        public int Id { get; set; }
        [Column("Name")]
        public string Name { get; set; }
        [Column("PhotoUrl")]
        public string PhotoUrl { get; set; }
         
    }
}
