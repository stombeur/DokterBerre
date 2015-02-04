using System;
using ServiceStack.DataAnnotations;

namespace DokterBerre.Library.Db
{
    public class Dokter
    {
        public Dokter() { }
        [AutoIncrement]
        [Alias("DokterID")]
        public Int32 Id { get; set; }
        [Index(Unique = true)]
        //[StringLength(40)]
        public string Naam { get; set; }
        public string Printer { get; set; }
    }
}