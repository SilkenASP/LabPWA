namespace DatabaseLayer.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Transaccion")]
    public partial class Transaccion
    {
        [Key]
        public int id_Transaccion { get; set; }

        [StringLength(50)]
        public string Accion { get; set; }

        public float? Monto { get; set; }

        public DateTime? Fecha { get; set; }

        public float? NuevoSaldo { get; set; }

        [StringLength(150)]
        public string NumeroCuenta { get; set; }

        public int? id_Usuario { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
