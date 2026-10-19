using System.Runtime.CompilerServices;

Console.WriteLine("¿Cómo te llamas?");
string nombre = Console.ReadLine(); // Guarda lo que el usuario escriba
Console.WriteLine("Hola, " + nombre);
Console.WriteLine("=== Reporte de Atención Veterinaria ===");

string especieMascota = "perro";   // "perro", "gato", "conejo", "reptil"
int edadMascota = 3;               // edad en años
double peso = 7;                // peso en kilogramos
bool tieneVacunasAlDia = false;
bool esSocio = true;
string motivoConsulta = "revision"; // "vacuna", "revision", "cirugia", "urgencia"

// Parte 1 — Clasificación por etapa de vida
String etapavida = edadMascota switch
{
  < 1 => "Cachorro",
  >= 1 and <= 3 => "Joven",
  >= 4 and <= 8 => "Adulto",
  _ => "Senior"
};

//Parte 2 — Alerta de vacunación
string alertaVacuna;

if (( especieMascota is "perro" or "gato") && !tieneVacunasAlDia )
{
    alertaVacuna = "ALERTA: vacunación urgente requerida";
}
else if ((especieMascota is "perro" or "gato") && tieneVacunasAlDia)
{
    alertaVacuna = "Vacunacion al dia";
}
else
{
    alertaVacuna = "Esquema de vacunación no aplica";
}

// Parte 3 — Costo base de la consulta
decimal costoBase;

switch (motivoConsulta)
{
    case "vacuna":
    costoBase = 35000;
    break;
    case "revision":
    costoBase = 50000;
    break;
    case "cirugia":
    costoBase = 280000;
    break;
    case "urgencia":
    costoBase = 150000;
    break;
    default:
    costoBase = 0;
    break;
}

//Parte 4 — Descuento por membresía y peso
double porcentajeDescuento = esSocio && peso > 25 ? 15.0 : esSocio ? 10.0 : 0.0;

decimal descuento = costoBase * (decimal)(porcentajeDescuento / 100);
decimal costoFinal = costoBase - descuento;

// Parte 5 — Recomendación post-consulta

string recomendacion;

if (motivoConsulta == "cirugia")
{
    if (etapavida == "Senior")
    {
        recomendacion = "Reposo absoluto por 10 días, control post-operatorio obligatorio";
    }
    else
    {
        recomendacion = "Reposo por 5 días, evitar ejercicio intenso";
    }
}
else if (motivoConsulta == "urgencia")
{
    if (!tieneVacunasAlDia)
    {
        recomendacion = "Atender urgencia y programar vacunación inmediata";
    }
    else
    {
        recomendacion = "Seguimiento en 48 horas";
    }
}
else
{
    recomendacion = "Seguimiento en próxima consulta de rutina";
}


Console.WriteLine($"Mascota: {especieMascota} | Edad: {edadMascota} | Etapa: {etapavida}");
Console.WriteLine($"Estado de Vacunacion: {alertaVacuna}");
Console.WriteLine($"Motivo: {motivoConsulta} | Costo Base: ${costoBase}");
Console.WriteLine($"Descuento: {porcentajeDescuento}% Costo Final: ${costoFinal}");
Console.WriteLine($"Recomendacion:  {recomendacion}");
