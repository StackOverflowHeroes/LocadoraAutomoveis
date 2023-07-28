namespace LocadoraAutomoveis.Dominio
{
    public interface IContextoPersistencia
    {
        void DesfazerAlteracoes();

        void GravarDados();
    }
}
