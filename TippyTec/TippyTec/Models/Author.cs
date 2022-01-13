using SQLite;

using SQLiteNetExtensions.Attributes;

using System;
using System.Collections.Generic;
using System.Text;

namespace TippyTec.Models
{
    public class Author
    {
        [PrimaryKey]
        public int Id { get; set; }

        public string Name { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.None)]
        public List<Tip> Tips { get; set; }
    }
}
