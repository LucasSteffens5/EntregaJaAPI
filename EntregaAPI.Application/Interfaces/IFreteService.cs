namespace EntregaAPI.Application.Interfaces
{
    public interface IFreteService
    {
        decimal CalcularFrete(string cep);

        void ValidarCep(string cep);

        bool EhRioDeJaneiroCapital(string cep);

        bool EhRioDeJaneiroRegiaoMetropolitana(string cep);

        bool EhRioDeJaneiroInterior(string cep);

        string RetornarApenasDigitos(string cep);
    }
}
