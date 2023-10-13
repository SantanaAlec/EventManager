// Copyright (c) Miguel Angel De La Rosa Martínez, Alec Demian Santana Celaya, Jaime Valdez Tanori, Martin Ricardo Yocupicio Ramos. Licensed under the MIT Licence.
// See the LICENSE file in the repository root for full license text.

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventManager.Database.Models
{
    [Table("empleado")]
    public class Empleado
    {
        [Key][Column("id")] public int Id { get; set; }
        [Required][Column("nombre")] public string Nombre { get; set; }
        public List<EventoEmpleado> EventoEmpleados { get; set; }
    }
}