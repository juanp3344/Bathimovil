using BibliotecaServicios.Interfaces;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace BibliotecaServicios.Implementaciones
{
    public class PdfServicios: IPdfServicios
    {
        public byte[] GenerarPdf<T>(List<T> datos, string titulo)
        {
            QuestPDF.Settings.License = LicenseType.Community;

            return Document.Create(container =>
            {
            container.Page(page =>
            {
                page.Margin(30);

                page.Header()
                    .Text(titulo)
                    .FontSize(20)
                    .Bold();

                page.Content().Table(tabla =>
                {
                    var propiedades = typeof(T).GetProperties();

                    tabla.ColumnsDefinition(columns =>
                    {
                        foreach (var prop in propiedades)
                        {
                            columns.RelativeColumn();
                        }
                    });

                    tabla.Header(header =>
                    {
                        foreach (var prop in propiedades)
                        {
                            header.Cell()
                                .Background(Colors.Grey.Lighten2)
                                .Padding(5)
                                .Text(prop.Name)
                                .Bold();
                        }
                    });

                    foreach (var item in datos)
                    {
                        foreach (var prop in propiedades)
                        {
                            var valor = prop.GetValue(item)?.ToString() ?? "";

                            tabla.Cell()
                                .Border(1)
                                .Padding(5)
                                .Text(valor);
                        }
                    }
                });
            });
            }).GeneratePdf();
        }
    }
}
