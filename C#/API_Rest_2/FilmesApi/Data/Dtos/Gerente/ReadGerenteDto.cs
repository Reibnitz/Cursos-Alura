﻿using FilmesAPI.Models;
using System.Collections.Generic;

namespace FilmesApi.Data.Dtos.Gerente
{
    public class ReadGerenteDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        // Modificado de 'List<Cinema>' para 'object' para permitir as configurações de mapper em GerenteProfile
        public object Cinemas { get; set; }
    }
}
