﻿namespace Server.Models
{
    using Server.Models.Usuario.Server.Models.Usuario;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Diagnostics.CodeAnalysis;

    public class Promociones
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
        public decimal Descuento { get; set; }
        public int Estado { get; set; }
        public int Productos { get; set; }
        public int BadgePromoId { get; set; }
        public int LimiteCanje { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
        [AllowNull]
        public string DeletedAt { get; set; } = null;
    }
}
