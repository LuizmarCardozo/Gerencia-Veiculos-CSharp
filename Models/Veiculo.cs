using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace VeiculosApp.Models
{
    public class Veiculo
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Marca { get; set; } = string.Empty;
        public string Modelo { get; set; } = string.Empty;
        public int Ano { get; set; }
        public decimal Preco { get; set; }

        // Caminhos relativos "Images/arquivo.jpg"
        [Browsable(false)]
        public List<string> Imagens { get; set; } = new();

        // Legado (mantém compatibilidade, mas não aparece na grid nem no JSON)
        [Obsolete("Use Imagens")]
        [Browsable(false)]
        [JsonIgnore]
        public string? CaminhoImagem { get; set; }

        // Colunas amigáveis para a grid
        public string? PrimeiraImagem => (Imagens != null && Imagens.Count > 0) ? Imagens[0] : null;
        public int Fotos => Imagens?.Count ?? 0;
    }
}
