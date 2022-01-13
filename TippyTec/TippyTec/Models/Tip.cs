using SQLite;

using SQLiteNetExtensions.Attributes;

using System;
using System.Collections.Generic;
using System.Text;

namespace TippyTec.Models
{
    public class Tip
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        [ForeignKey(typeof(Author))]
        public int AuthorId { get; set; }

        [ManyToOne("AuthorId", CascadeOperations = CascadeOperation.All)]
        public Author Author { get; set; }

    }
}
