// Copyright (c) Miguel Angel De La Rosa Martínez, Alec Demian Santana Celaya, Jaime Valdez Tanori, Martin Ricardo Yocupicio Ramos. Licensed under the MIT Licence.
// See the LICENSE file in the repository root for full license text.

using static EventManager.Core.Models.Agregable;

namespace EventManager.CLI.DTO
{
    public partial class AgregableDTO
    {
        public int Id { get; set; }

        public TipoAgregable Tipo { get; set; }

        public string Nombre { get; set; }

        public int Total { get; set; }
    }
}
