using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace BancoHoras.Models;

public class Category
{
    [Key]
    public int Id { get; set; }
    [Required(ErrorMessage = "Campo Obrigatório")]
    [MaxLength(100, ErrorMessage = "O máximo é 100 caracteres")]
    [MinLength(3, ErrorMessage = "O máximo é 3 caracteres")]
    public string Nome { get; set; } = string.Empty;
    public string InicioManha { get; set; } = string.Empty;
    public string FimManha { get; set; } = string.Empty;
    public string InicioTarde { get; set; } = string.Empty;
    public string FimTarde { get; set; } = string.Empty;
    public string Observacoes { get; set; } = string.Empty;
    public string TempoTotal
    {
        get
        {
            string horarioTotal = CalcularHorasTrabalhadas(InicioManha, FimManha, InicioTarde, FimTarde);
            return horarioTotal;
        }
    }
    public static string CalcularHorasTrabalhadas(string inicioManha, string fimManha, string inicioTarde, string fimTarde)
    {
        int horasManha, minutosManha;
        CalcularHorasMinutos(inicioManha, fimManha, out horasManha, out minutosManha);

        int horasTarde, minutosTarde;
        CalcularHorasMinutos(inicioTarde, fimTarde, out horasTarde, out minutosTarde);

        int horasTotal = horasManha + horasTarde;
        int minutosTotal = minutosManha + minutosTarde;

        horasTotal += minutosTotal / 60;
        minutosTotal %= 60;

        return $"{horasTotal:D2}:{minutosTotal:D2}";
    }
    static void CalcularHorasMinutos(string inicio, string fim, out int horas, out int minutos)
    {
        int inicioHoras = int.Parse(inicio.Substring(0, 2));
        int inicioMinutos = int.Parse(inicio.Substring(3, 2));

        int fimHoras = int.Parse(fim.Substring(0, 2));
        int fimMinutos = int.Parse(fim.Substring(3, 2));

        horas = fimHoras - inicioHoras;
        minutos = fimMinutos - inicioMinutos;

        if (minutos < 0)
        {
            horas--;
            minutos += 60;
        }
    }
}