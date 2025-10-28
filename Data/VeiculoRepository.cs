using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using VeiculosApp.Models;

namespace VeiculosApp.Data
{
    public class VeiculoRepository
    {
        private readonly string _baseDir;
        private readonly string _dataFile;
        private readonly string _imagesDir;
        private readonly JsonSerializerOptions _jsonOptions = new()
        {
            WriteIndented = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };

        public VeiculoRepository()
        {
            _baseDir = AppDomain.CurrentDomain.BaseDirectory;

            var dataDir = Path.Combine(_baseDir, "Data");
            _imagesDir = Path.Combine(_baseDir, "Images");

            Directory.CreateDirectory(dataDir);
            Directory.CreateDirectory(_imagesDir);

            _dataFile = Path.Combine(dataDir, "veiculos.json");
        }

        public List<Veiculo> CarregarTodos()
        {
            if (!File.Exists(_dataFile)) return new List<Veiculo>();
            var json = File.ReadAllText(_dataFile);
            var lista = JsonSerializer.Deserialize<List<Veiculo>>(json) ?? new List<Veiculo>();
            // Migração: se veio só CaminhoImagem, empurra para Imagens
            foreach (var v in lista)
            {
                if ((v.Imagens == null || v.Imagens.Count == 0) && !string.IsNullOrWhiteSpace(v.CaminhoImagem))
                {
                    v.Imagens = new List<string> { v.CaminhoImagem };
                }
            }
            return lista;
        }

        public void SalvarTodos(List<Veiculo> lista)
        {
            var json = JsonSerializer.Serialize(lista, _jsonOptions);
            var tmp = _dataFile + ".tmp";
            File.WriteAllText(tmp, json);
            if (File.Exists(_dataFile)) File.Delete(_dataFile);
            File.Move(tmp, _dataFile);
        }

        public string CopiarImagemParaRepositorio(string arquivoOrigem)
        {
            if (string.IsNullOrWhiteSpace(arquivoOrigem) || !File.Exists(arquivoOrigem))
                return string.Empty;

            var nome = Guid.NewGuid().ToString("N") + Path.GetExtension(arquivoOrigem);
            var destino = Path.Combine(_imagesDir, nome);
            File.Copy(arquivoOrigem, destino, overwrite: true);
            return Path.Combine("Images", nome); // caminho relativo
        }

        public List<string> CopiarImagensParaRepositorio(IEnumerable<string> arquivos)
        {
            var lista = new List<string>();
            foreach (var a in arquivos)
            {
                var rel = CopiarImagemParaRepositorio(a);
                if (!string.IsNullOrWhiteSpace(rel)) lista.Add(rel);
            }
            return lista;
        }

public string CaminhoAbsolutoDaImagem(string? caminhoRelativo)
        {
            if (string.IsNullOrWhiteSpace(caminhoRelativo)) return string.Empty;
            return Path.Combine(_baseDir, caminhoRelativo);
        }
    }
}
