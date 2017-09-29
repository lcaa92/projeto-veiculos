using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectVeiculos.Models
{
    [MetadataType(typeof(veiculosMetadado))]
    public partial class veiculos
    {
    }

    public class veiculosMetadado
    {
        [Required(ErrorMessage="Obrigatório informar a placa")]
        [StringLength(7, ErrorMessage="A placa deve possuir 7 caracteres")]
        public string placa { get; set; }

        [Required(ErrorMessage="Obrigatório informar o proprietario")]
        [StringLength(30, ErrorMessage="O proprietario deve possuir no máximo 30 caracteres")]
        public string proprietario { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o tipo de veiculo")]
        public int id_tipo_veiculo { get; set; }
    }
}