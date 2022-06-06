using System;
using System.Data.Linq.Mapping;

namespace OrderApp
{
    [Table(Name = "Users")]
    public class UserEntity
    {
        [Column(IsPrimaryKey = true, Name = "Pin")]
        public string Id { get; set; }

        [Column(Name = "Pin")]
        public string Pin { get; set; }

        [Column(Name = "Name")]
        public string Name { get; set; }

        [Column(Name = "Second_Name")]
        public string Second_Name { get; set; } 

        [Column(Name = "Role_id")] 
        public int Role_id { get; set; }

        [Column(Name = "Pesel")]
        public string Pesel { get; set; }

        [Column(Name = "Phone_number")]
        public string Phone_number { get; set; }
    }
}
