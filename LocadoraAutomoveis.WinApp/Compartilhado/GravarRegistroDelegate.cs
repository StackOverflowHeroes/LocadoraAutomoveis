namespace LocadoraAutomoveis.WinApp.Compartilhado
{

    public delegate Result GravarRegistroDelegate<TEntidade>(TEntidade Automovel)
        where TEntidade : EntidadeBase<TEntidade>;    
    
}
