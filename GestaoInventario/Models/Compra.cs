﻿using System;

namespace GestaoInventario.Models
{
    public class Compra
    {
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
        public DateTime Data { get; set; }
    }
}
