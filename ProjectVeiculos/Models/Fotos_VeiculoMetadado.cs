using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectVeiculos.Models
{
    [MetadataType(typeof(fotos_veiculoMetadado))]
    public partial class fotos_veiculo
    {
    }

    public class fotos_veiculoMetadado
    {
        [Required(ErrorMessage = "Obrigatório informar um nome para a foto.")]
        [StringLength(40, ErrorMessage = "O nome deve possui no máximo 40 caracteres")]
        public string nome { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o arquivo")]
        public string arquivo { get; set; }
    }
}