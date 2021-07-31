using System;

namespace ValidadorCPF.Dominio
{
    public interface ITimeStampedModel
    {
        DateTime CreatedAt { get; set; }
        DateTime LastModified { get; set; }
    }
    public class CPF : ITimeStampedModel
    {
        public int Id { get; set; }
        public string Cpf { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastModified { get; set; }
    }
}
