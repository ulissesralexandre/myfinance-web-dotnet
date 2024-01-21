using myfinance_web_dotnet_service.Interfaces;
using myfinance_web_dotnet_domain.Entities;
using myfinance_web_dotnet_infra;
using System.Data.Common;


namespace myfinance_web_dotnet_service
{
    public class TransacaoService : ITransacaoService
    {
        private readonly MyFinanceDbContext _dbContext;
        public TransacaoService(MyFinanceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Cadastrar(Transacao Entidade)
        {
            var dbSet = _dbContext.Transacao;

            if (Entidade.Id == null)
            {
                dbSet.Add(Entidade);
            }
            else{
                dbSet.Attach(Entidade);
                _dbContext.Entry(Entidade).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            _dbContext.SaveChanges();
        }

        public void Excluir(int id)
        {
            var Transacao = new Transacao() {Id = id};

            _dbContext.Attach(Transacao);
            _dbContext.Remove(Transacao);
            _dbContext.SaveChanges();
        }

        public List<Transacao> ListarRegistros()
        {
            var dbSet = _dbContext.Transacao;
            return dbSet.ToList();
        }

        public Transacao RetornarRegistro(int Id)
        {
            
            return _dbContext.Transacao.Where(x => x.Id == Id).First();
        }
    }
}