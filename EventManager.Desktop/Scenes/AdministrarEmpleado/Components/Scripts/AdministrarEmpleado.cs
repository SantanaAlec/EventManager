using Godot;
using System;

namespace EventManager.Desktop.Scenes.AdministrarEmpleado.Components.Scripts;
public partial class AdministrarEmpleado : Control
{
	[Export]
	private ListaConsultarEmpleadosContainer _listaConsultarEmpleadosContainer;

	[Export]
	private OptionButtonBuscarEmpleado _optionButtonBuscarEmpleado;

	[Export]
	private ListaEmpleadosContainer _listaEmpleadosContainer;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	public void RefreshContainers()
	{
		_listaConsultarEmpleadosContainer.Refresh();
		_optionButtonBuscarEmpleado.Refresh();
		_listaEmpleadosContainer.Refresh();
	}
}
