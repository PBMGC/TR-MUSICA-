using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MUSICA_TRFINAL.Models;
public partial class Canciones
{
    public int CancionID { get; set; } 

    public string Link { get; set; } = null!; 

    public string NombreCancion { get; set; } = null!;

    public string Cantante { get; set; } = null!;

    public string Genero { get; set; } = null!;

    public int Likes { get; set; } = 0; 

    public int Vistos { get; set; } = 0;

    [NotMapped]
    public IFormFile Imagen {  get; set; }
}

