//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjectVeiculos.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class veiculos
    {
        public veiculos()
        {
            this.fotos_veiculo = new HashSet<fotos_veiculo>();
        }
    
        public long id_veiculo { get; set; }
        public string placa { get; set; }
        public string proprietario { get; set; }
        public long id_tipo_veiculo { get; set; }
    
        public virtual ICollection<fotos_veiculo> fotos_veiculo { get; set; }
        public virtual tipos_veiculo tipos_veiculo { get; set; }
    }
}
