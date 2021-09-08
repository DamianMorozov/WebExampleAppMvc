// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.ComponentModel.DataAnnotations;

namespace WebExampleAppMvc.Models
{
    public class MovieEntity : BaseSerializeEntity<MovieEntity>
    {
        #region Public and private fields and properties

        public int Id { get; set; }
        public string Title { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        [field: NonSerialized]
        public decimal Price { get; set; }

        #endregion

        #region Public and private methods

        public override string ToString()
        {
            return
                $"{nameof(Id)}: {Id}. " +
                $"{nameof(Title)}: {Title}. " +
                $"{nameof(ReleaseDate)}: {ReleaseDate}. " +
                $"{nameof(Genre)}: {Genre}. ";
        }

        #endregion
    }
}
