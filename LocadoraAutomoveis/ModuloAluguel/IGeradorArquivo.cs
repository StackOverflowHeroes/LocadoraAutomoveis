
namespace LocadoraAutomoveis.Dominio.ModuloAluguel
{
    public interface IGeradorArquivo
    {
        void GerarPDF(Aluguel aluguel, string diretorio);
    }
}
