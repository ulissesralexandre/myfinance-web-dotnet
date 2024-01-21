using myfinance_web_dotnet_domain.Entities;

namespace myfinance_web_dotnet_service.Interfaces
{
    public class ITransacaoService
    {
        void Cadastrar(PlanoConta Entidade);

        void Excluir(int Id);

        List<PlanoConta> ListarRegistro();

        PlanoConta RetornarRegistro(int Id);
    }
}