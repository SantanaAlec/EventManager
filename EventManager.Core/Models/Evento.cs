// Copyright (c) Miguel Angel De La Rosa Martínez, Alec Demian Santana Celaya, Jaime Valdez Tanori, Martin Ricardo Yocupicio Ramos. Licensed under the MIT Licence.
// See the LICENSE file in the repository root for full license text.

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Lombok.NET;

namespace EventManager.Core.Models
{
    [Table("evento")]
    public partial class Evento
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("nombre")]
        public string Nombre { get; set; }

        [Required]
        [Column("descripcion")]
        public string Descripcion { get; set; }

        [Required]
        [Column("fecha_inicio")]
        public DateTime FechaInicio { get; set; }

        [Required]
        [Column("fecha_termino")]
        public DateTime FechaTermino { get; set; }

        [Required]
        [Column("usuario_id")]
        public int UsuarioId { get; set; }

        public Usuario Usuario { get; set; }

        public List<Cliente> Clientes { get; set; } = new List<Cliente>();

        public List<Sala> Salas { get; set; } = new List<Sala>();

        public List<EventoEmpleado> EventoEmpleados { get; set; } = new List<EventoEmpleado>();

        public List<EventoAgregable> EventoAgregables { get; set; } = new List<EventoAgregable>();
    }
}