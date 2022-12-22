using System.ComponentModel.DataAnnotations;

namespace CnpjExt.ViewModel
{
    public class CnpjViewModel
    {
       
        public string Cnpj { get; set; }
        public string Nome { get; set; }
        public string Fantasia { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Municipio { get; set; }
        public string UF { get; set; }
        public string Tipo { get; set; }
        public string Abertura { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Situacao { get; set; }
        public string Cep { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set;}
        public string Status { get; set; }
        public string Message { get; set;}
    }
}
