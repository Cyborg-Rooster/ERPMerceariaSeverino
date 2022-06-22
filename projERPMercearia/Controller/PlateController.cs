using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Xobject;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using projERPMercearia.Model;
using System;
using System.Collections.Generic;
using System.IO;

namespace projERPMercearia.Controller
{
    class PlateController
    {
        static string uri = @$"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\PDFs\";
        public static void CreateList(string[,] values, int y)
        {
            bool dark = true;
            Color DarkerBlue = new DeviceRgb(97, 137, 201);
            Color SemiBlue = new DeviceRgb(151, 177, 219);
            Color LighterBlue = new DeviceRgb(204, 217, 237);

            Directory.CreateDirectory(uri + "Listas");
            
            PdfWriter Writer = new PdfWriter
            (
                uri +
                $@"\Listas\lista-{DateFormatter.DateFormat(DateTime.Now.ToString(), true)}.pdf"
            );
            PdfDocument Pdf = new PdfDocument(Writer);
            PageSize.A4.SetWidth(2480);
            PageSize.A4.SetHeight(3508);
            Document Document = new Document(Pdf, PageSize.A4);

            PdfFont font = PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.TIMES_BOLD);
            Document.SetFont(font);

            Table table = new Table(UnitValue.CreatePercentArray(3)).UseAllAvailableWidth();
            Cell ean = new Cell();
            ean.Add(new Paragraph("EAN").SetFontSize(24));
            ean.SetHeight(60);

            Cell name = new Cell();
            name.Add(new Paragraph("NOME").SetFontSize(24));
            name.SetHeight(60);

            Cell quantity = new Cell();
            quantity.Add(new Paragraph("QUANTIDADE ATUAL").SetFontSize(24));
            quantity.SetHeight(60);

            table.AddCell(ean);
            table.AddCell(name);
            table.AddCell(quantity);

            for (int i = 0; i < y; i++)
            {
                Cell c1 = new Cell();
                c1.Add(new Paragraph(values[i, 0]).SetFontSize(24));
                c1.SetHeight(60);

                Cell c2 = new Cell();
                c2.Add(new Paragraph(values[i, 1]).SetFontSize(24));
                c2.SetHeight(60);

                Cell c3 = new Cell();
                c3.Add(new Paragraph(values[i, 2]).SetFontSize(24));
                c3.SetHeight(60);

                if (dark)
                {
                    c1.SetBackgroundColor(DarkerBlue);
                    c2.SetBackgroundColor(SemiBlue);
                    c3.SetBackgroundColor(DarkerBlue);
                }
                else
                {
                    c1.SetBackgroundColor(SemiBlue);
                    c2.SetBackgroundColor(LighterBlue);
                    c3.SetBackgroundColor(SemiBlue);
                }

                table.AddCell(c1);
                table.AddCell(c2);
                table.AddCell(c3);
                dark = !dark;
            }
            Document.Add(table);
            Document.Close();
        }


        public static void CreatePlate(List<Product> products)
        {
            Directory.CreateDirectory(uri + "Placas");
            PdfWriter Writer = new PdfWriter
            (
                uri + 
                $@"\Placas\placa-{DateFormatter.DateFormat(DateTime.Now.ToString(), true)}.pdf"
            );
            PdfDocument Pdf = new PdfDocument(Writer);
            PageSize.A4.SetWidth(2480);
            PageSize.A4.SetHeight(3508);
            Document Document = new Document(Pdf, PageSize.A4);

            PdfFont font = PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.TIMES_BOLD);
            Document.SetFont(font);

            var label = @$"{AppDomain.CurrentDomain.BaseDirectory}\Images\label.png";


            while (products.Count > 0)
            {
                Table table = new Table(UnitValue.CreatePercentArray(2)).UseAllAvailableWidth();
                for (int i = 0; i < 10; i++)
                {
                    if (products.Count == 0) break;

                    string name = "";

                    for (int j = 0; j < products[0].Name.Length; j++)
                    {
                        if (j == 20) break;
                        name += products[0].Name[j];
                    }

                    Image img = GetWatermarkedImage
                    (
                        Pdf,
                        new Image(iText.IO.Image.ImageDataFactory.Create(label)),
                        name,
                        DeviceGray.WHITE,
                        Plate.TitlePosX,
                        Plate.TitlePosY,
                        100
                    );

                    img = GetWatermarkedImage
                    (
                        Pdf,
                        img,
                        $"R${DoubleFormatter.ConvertDoubleToString(products[0].Price)}",
                        DeviceGray.BLACK,
                        Plate.PricePosX,
                        Plate.PricePosY,
                        150
                    );

                    img = GetWatermarkedImage
                    (
                        Pdf,
                        img,
                        products[0].Unity ? "UNI" : "KG",
                        DeviceGray.BLACK,
                        Plate.UnityPosX,
                        Plate.UnityPosY,
                        70
                    );
                    table.AddCell(img.SetAutoScale(true));
                    products.Remove(products[0]);
                }
                Document.Add(table);
                if (products.Count > 0) Document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));
            }
            Document.Close();
        }

        private static Image GetWatermarkedImage(PdfDocument pdfDoc, Image img, string str, DeviceGray color, float x, float y, int size)
        {
            float width = img.GetImageScaledWidth();
            float height = img.GetImageScaledHeight();
            PdfFormXObject template = new PdfFormXObject(new Rectangle(width, height));
            new Canvas(template, pdfDoc)
                .Add(img)
                .SetFontColor(color)
                .SetFontSize(size)
                .SetBold()
                .ShowTextAligned(str, x, height - y, TextAlignment.LEFT)
                .Close();
            return new Image(template);
        }
    }
}
