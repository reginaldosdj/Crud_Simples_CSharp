﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArquivosWeb.Models
{
    public class UploadFileResult
    {
        public int IDArquivo { get; set; }
        public string Nome { get; set; }
        public int Tamanho { get; set; }
        public string Tipo { get; set; }
        public string Caminho { get; set; }
    }
}

