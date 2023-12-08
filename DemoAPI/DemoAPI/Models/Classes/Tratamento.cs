namespace DemoAPI.Models.Classes
{
    public class Tratamento<T> where T : class
    {
        public T? Dados { get; set; }
        public string Mensagem { get; private set; } = string.Empty;
        public bool Sucesso { get; set; } = true;
        public void AdicionarErro()
        {
            Dados = null;
            Sucesso = false;
        }
    }
}
