﻿using System.ComponentModel.DataAnnotations;

namespace gitPrueba.Models
{
    public class Autor
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Nacionalidad { get; set; }

    }
}
