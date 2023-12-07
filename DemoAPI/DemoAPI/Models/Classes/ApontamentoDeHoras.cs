using System.ComponentModel.DataAnnotations;

namespace DemoAPI.Models.Classes
{
    public class ApontamentoDeHoras
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime Data { get; set; } = DateTime.Now;
        [Required]
        public string Nome { get; set; } = "";
        [Required]
        public string HoraInicioManha { get; set; } = "08:00";
        [Required]
        public string HoraFimManha { get; set; } = "12:00";
        [Required]
        public string HoraInicioTarde { get; set; } = "13:00";
        [Required]
        public string HoraFimTarde { get; set; } = "17:00";
        public string TempoTotal
        {
            get
            {
                string horarioTotal = CalcularHorasTrabalhadas(HoraInicioManha, HoraFimManha, HoraInicioTarde, HoraFimTarde);
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
}
