using System;
using System.Collections.Generic;

namespace MUSICA_TRFINAL.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string NombreUsuario { get; set; } = null!;

    public string Contraseña { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int? Likes { get; set; }

    public int? Vistos { get; set; }
}
