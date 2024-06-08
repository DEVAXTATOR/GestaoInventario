using System.Collections.Generic;

namespace GestaoInventario.Models
{
    public class RelatorioViewModel
    {
        public string Titulo { get; set; }
        public List<string> Cabecalhos { get; set; }
        public List<List<string>> Linhas { get; set; }
    }
}
