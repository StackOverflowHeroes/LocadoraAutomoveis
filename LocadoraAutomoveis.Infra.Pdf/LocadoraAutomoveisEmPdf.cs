
using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using LocadoraAutomoveis.Dominio.ModuloAluguel;

namespace LocadoraAutomoveis.Infra.Pdf
{
    public class LocadoraAutomoveisEmPdf : IGeradorArquivo
    {
        public void GerarPDF(Aluguel aluguel, string diretorio)
        {
            string caminhoArquivo = Path.Combine(diretorio, $"{aluguel}.pdf");

            Document document = CriarDocumentoPdf(caminhoArquivo);

            ConfigurarCabecalho(document, aluguel);

            EscreverConteudo(document, aluguel);

            document.Close();
        }
        private Document CriarDocumentoPdf(string caminhoArquivo)
        {
            PdfWriter writer = new PdfWriter(caminhoArquivo);

            PdfDocument pdf = new PdfDocument(writer);

            Document document = new Document(pdf);

            return document;
        }
        private void ConfigurarCabecalho(Document document, Aluguel aluguel)
        {
            PdfFont fontCabecalho = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);

            document.Add(new Paragraph($"Aluguel: {aluguel.Id}").SetFont(fontCabecalho));

            string clienteAluguel = aluguel.Cliente == null ? aluguel.Cliente.Nome : aluguel.Cliente.Nome;

            document.Add(new Paragraph($"Cliente: {aluguel.Cliente.Nome}").SetFont(fontCabecalho));

            document.Add(new Paragraph($"Veículo: {aluguel.Automovel.Modelo}").SetFont(fontCabecalho));
            document.Add(new Paragraph($"Data de locação: {aluguel.DataLocacao}").SetFont(fontCabecalho));

            document.Add(new Paragraph("\n\n"));
        }
        private void EscreverConteudo(Document document, Aluguel aluguel)
        {
            PdfFont fontConteudo = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
            document.Add(new Paragraph($"O senhor(a), {aluguel.Cliente.Nome}, documento: {aluguel.Cliente.Documento}, registrou o aluguel do Veículo: {aluguel.Automovel.Modelo}, na cor {aluguel.Automovel.Cor}, ano {aluguel.Automovel.Ano}\n" +
                $"Data de locação: {aluguel.DataLocacao}\n Data prevista para devolução: {aluguel.DataPrevisaoRetorno}\n" +
                $"Valor estimado do aluguel: {aluguel.ValorTotal}"));

            //for (int i = 0; i < aluguel..Count; i++)
            //{
            //    Alternativa alternativaCorreta = gabarito.AlternativasCorretas[i];

            //    Questao questao = alternativaCorreta.Questao;

            //    document.Add(new Paragraph($"Pergunta {i + 1}: {questao.Enunciado} \n").SetFont(fontConteudo));

            //    document.Add(new Paragraph($"{alternativaCorreta}").SetFont(fontConteudo));

            //    if (i + 1 != gabarito.AlternativasCorretas.Count)
            //    {
            //        document.Add(new Paragraph($"--------------------------------------------------------------------------------------"));
            //    }
            //}
        }
    }
}
