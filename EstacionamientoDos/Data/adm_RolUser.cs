//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EstacionamientoDos.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class adm_RolUser
    {
        public int idRolUser { get; set; }
        public int idRol { get; set; }
        public int idUser { get; set; }
        public Nullable<bool> active { get; set; }
        public Nullable<System.DateTime> create_date { get; set; }
        public Nullable<System.DateTime> update_date { get; set; }
    
        public virtual adm_Rol adm_Rol { get; set; }
        public virtual adm_User adm_User { get; set; }
    }
}
