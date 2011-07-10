//using System;
//using System.Data.Entity;
//using System.ComponentModel.DataAnnotations;
//namespace MvcMovie.Models
//{
    
//    public class Gasto
//    {
//        [Key()]
//        public int IdGasto { get; set; }
//        public int IdPCTipoGasto { get; set; }
//        public string Descripcion { get; set; }       
//        public DateTime Fecha { get; set; }
//        public DateTime FechaCreacion { get; set; }
//        public Decimal Monto { get; set; }
//    }

    
//    public class MvcMovieDBContext : DbContext
//    {
//        public MvcMovieDBContext(string cnnStringNAme) : base(cnnStringNAme) { }
//        public DbSet<Gasto> Gastos { get; set; }
//    }
//}