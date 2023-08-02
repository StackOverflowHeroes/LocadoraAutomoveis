namespace LocadoraAutomoveis.Aplicacao.Compartilhado
{
     public interface IServico<T> where T : EntidadeBase<T>
     {
          Result Inserir(T registro);
          Result Editar(T registro);
          Result Excluir(T registro);          
     }
}
