
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

            //document.Add(new Paragraph($"Título: {testeSelecionado.Titulo}").SetFont(fontCabecalho));

            //string nomeDisciplina = testeSelecionado.Disciplina == null ? testeSelecionado.Materia.Disciplina.Nome : testeSelecionado.Disciplina.Nome;

            //document.Add(new Paragraph($"Disciplina: {nomeDisciplina}").SetFont(fontCabecalho));

            //document.Add(new Paragraph($"Matéria: {testeSelecionado.Materia.Nome}").SetFont(fontCabecalho));

            document.Add(new Paragraph("\n\n"));
        }
        private void EscreverConteudo(Document document, Aluguel aluguel)
        {
            PdfFont fontConteudo = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

            //for (int i = 0; i < gabarito.AlternativasCorretas.Count; i++)
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
