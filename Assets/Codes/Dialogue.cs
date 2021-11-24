using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{

	#region IndividualDialogues
	public string[] DialogoPanelMantenimiento = { "Panel de Mantenimiento Refrigeración",
		"Por esta compuerta se puede acceder al ventilador, el cúal se encarga de refigerar el inversor compuesto por transistores IGBT" };
	public string[] DialogoPanelMantenimientoGI = { "Panel de mantenimiento eléctrico",
		"Por este se obtiene acceso al contactor de precarga, asegúrese que los indicadores luminosos se encuentran apagados antes de manipular." };
	public string[] DialogoPanelMantenimientoG = { "Panel de mantenimiento eléctrico",
		"Acceso al módulo de comunicación VEGA" };
	public string[] DialogoPanelElectrico2 = { "Panel Eléctrico 2",
		"Posee las conexiones del Motor 2, puestas a tierra, su inductancia de filtro y la alimentación de la catenaria" };
	public string[] DialogoPanelElectrico1 = { "Panel Eléctrico 1", "Posee las conexiones del Motor 1, puestas a tierra y su inductancia de filtro" };
	public string[] DialogoVentilador = { "Compuerta de refrigeración",
		"Por este elemento circula el aire que refrigera los transistores IGBT de potencia, el ventilador nominalmente mueve un caudal de 1200 m3 /h ± 10% " };
	public string[] DialogoBorneraBat = { "Bornera de comunicación con Tren" };
	public string[] DialogoBorneraAC = { "Bornera de conexión a Corriente alterna" };
	public string[] DialogoPT = { "Puesta a tierra de la caja del cofre" };
	#endregion

	#region PanelAgrupatedDialogues
	public string[] DialogoMantenimientos = { "Presione uno de los Paneles de mantenimiento resaltados para continuar" };
	public string[] DialogoBorneras = { "Presione una de las borneras resaltadas para continuar" };
	public string[] DialogoPTs = { "Presione una de las Puesta a tierra resaltadas para continuar" };
	public string[] DialogoVentiladores = { "Presione una de las compuertas resaltadas para continuar" };
	#endregion

	#region FasesDialogues
	public string[] DialogoInicioAR = { "Dirija la cámara hacia la imagen objetivo" };
	public string[] DialogoNormas = { "El cofre convertirdor cumple las normas de aplicaciones ferroviarias IEC 61287-1 (2014) y EN 61377 (2016) " };
	public string[] DialogoProtecciónIP6X = { "El cofre posee protección IP6X para los envolvente y tapas.", "Esta protección es referente a la nula entrada de polvo" };
	public string[] DialogoProtecciónIP2X = { "El cofre posee protección IP2X para las rejillas, entradas y salidas de aire.", "Esta protección es referente contra el acceso a partes peligrosas de elementos de mínimo 12 mm de diámetro​" };
	public string[] DialogoProtecciónEstanco = { "El cofre en su totalidad posee estanqueidad​" };
	public string[] DialogoAcústica = { "Carácteristicas de potencia acústica y presión sonora ",
		"El elemento nominalmente no excede una potencia acústica (Lwa) de 80 db para el escenario estático y 85 db para el escenario en movimiento",
		"Así como un nivel de presión sonora promedio corregido y ponderada en A (LpAeq,T) menor 69 dBA para el escenario estático y 74 dBA para el escenario en movimiento evaluados a un metro del cofre."};
	public string[] DialogoInicioTouch = { "Presione algún elemento en el panel o en el objeto para obtener más información" };
	#endregion

	#region DescriptionDialogue
	public string[] DialogoDescripcion = { "Cofre de tracción ",
		"El cofre de tracción es un equipo que recibe la energía eléctrica de corriente directa desde la catenaria y la trasforma en corriente alterna para el sistema de tracción de los trenes",
		"Es un equipo de 900 Kg que se ubica bajo bastidor de los coches motores, con dimensiones Largo=2350mm , Alto=712mm y Ancho=2134mm.​" };
	#endregion

	#region Panel1Dialogues
	public string[] DialogoPAT1 = { "PAT1:  Puesta a tierra 1"};
	public string[] DialogoBN1 = { "BN1: Negativo de la conexión con la resistencia de frenado" };
	public string[] DialogoCMC1 = { "CMC1: Retorno de la corriente en nodo común del motor 1 " };
	public string[] DialogoW1 = { "W1: salidad hacia el motor 1 fase W" };
	public string[] DialogoV1 = { "V1: salidad hacia el motor 1 fase V" };
	public string[] DialogoU1 = { "U1: salidad hacia el motor 1 fase U" };
	public string[] DialogoBR1 = { "BR1: Positivo de la conexión con la resistencia de frenado" };
	public string[] DialogoPAT2 = { "PAT2:  Puesta a tierra 2" };
	#endregion

	#region Panel2Dialogues
	public string[] DialogoNVC1 = { "-VC1: Negativo de la alimentación de la catenaria" };
	public string[] DialogoPVC1 = { "+VC1: Positivo de la alimentación de la catenaria" };
	public string[] DialogoLO1 = { "Lo1: Negativo de la conexión con la inductancia de filtro" };
	public string[] DialogoLO2 = { "Lo2: Negativo de la conexión con la inductancia de filtro" };

	public string[] DialogoCMC2 = { "CMC2: Retorno de la corriente en nodo común del motor 2 " };
	public string[] DialogoW2 = { "W2: salidad hacia el motor 2 fase W" };
	public string[] DialogoV2 = { "V2: salidad hacia el motor 2 fase V" };
	public string[] DialogoU2 = { "U2: salidad hacia el motor 2 fase U" };

	public string[] DialogoBR2 = { "BR2: Positivo de la conexión con la resistencia de frenado" };
	public string[] DialogoBN2 = { "BN2: Negativo de la conexión con la resistencia de frenado" };
	public string[] DialogoLI1 = { "Li1: Positivo de la conxeión con la inductancia de filtro" };
	public string[] DialogoLI2 = { "Li2: Positivo de la conxeión con la inductancia de filtro" };
	public string[] DialogoNVC2 = { "-VC2: Negativo de la alimentación de la catenaria" };
	public string[] DialogoPVC2 = { "+VC2: Positivo de la alimentación de la catenaria" };
	#endregion

	#region PanelDialogue
	public string[] DialogoPanel = { "Toque una bornera para obtener información" };
	#endregion

}
