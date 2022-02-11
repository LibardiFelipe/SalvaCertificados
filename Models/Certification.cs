using System;
using System.Text;

namespace Certificados.Models
{
    public class Certification
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string IssuingEntity { get; set; }
        public int DurationInHours { get; set; }
        public bool bDeleted { get; set; } = false;
        public string IssuedAt { get; set; }

        public void Delete() => bDeleted = true;

        public override string ToString()
        {
            StringBuilder strBuilder = new();
            strBuilder.Append($"# ID: {Id}\n");
            strBuilder.Append($"[{Title}]\n\n");
            strBuilder.Append($"{Description}\n\n");
            strBuilder.Append($">> Carga horária de {DurationInHours} hora(s) de duração.\n");
            strBuilder.Append($"> Emitido por {IssuingEntity}, no dia {IssuedAt}.\n");
            strBuilder.Append("-------------------------------\n");
            return strBuilder.ToString();
        }
    }
}