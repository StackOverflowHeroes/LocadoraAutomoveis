namespace LocadoraAutomoveis.WinApp.Compartilhado
{

    public delegate Result GravarRegistroDelegate<TEntidade>(TEntidade Parceiro)
        where TEntidade : EntidadeBase<TEntidade>;    
    
}
