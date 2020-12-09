using System;

namespace ProAgil.API.Model
{
    public class Evento
    {
        public int EventoId { get; set; }
        public int QtdPessoas { get; set; }
        public string Local { get; set; }
        public DateTime DataEvento { get; set; }
        public string Lote { get; set; }
    }
}