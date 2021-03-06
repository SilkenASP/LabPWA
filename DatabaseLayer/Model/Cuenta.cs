namespace DatabaseLayer.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cuenta")]
    public partial class Cuenta
    {
        [Key]
        public int id_Cuenta { get; set; }

        [StringLength(50)]
        public string NumeroCuenta { get; set; }

        public float? Saldo { get; set; }

        public float? Interes { get; set; }

        public int? id_Usuario { get; set; }

        public int? Activo { get; set; }
        [StringLength(50)]
        public string Tipo { get; set; }
        [StringLength(50)]
        public string TiempoVigencia { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
