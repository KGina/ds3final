using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Text;
using AbantwanaWebMaster.BusinessLogic;
using System.Net.Mail;
using AbantwanaWebMaster.Model;

namespace AbantwanaWebMaster.MVC5.Controllers
{
    public class PDFController : Controller
    {
        OrderBusiness OrderBusiness = new OrderBusiness();
        //CartBusiness Cart = new CartBusiness();
        OrderBusiness Order = new OrderBusiness();
        public FileResult CreatePdf(Supplier supplier)
        {
            OrderBusiness.approveOrder(supplier.orderID);
            MemoryStream workStream = new MemoryStream();
            StringBuilder status = new StringBuilder("");
            DateTime dTime = DateTime.Now;
            //file name to be created 
            string strPDFFileName = string.Format("InvoicePdf.pdf");
            iTextSharp.text.Document doc = new iTextSharp.text.Document();
            doc.SetMargins(0f, 0f, 0f, 0f);
            //Create PDF Table with 5 columns
            PdfPTable tableLayout = new PdfPTable(6);
            doc.SetMargins(0f, 0f, 0f, 0f);
            //Create PDF Table
            //System.Environment.GetFolderPath(Document);
            //file will created in this path
            //string strAttachment = AppDomain.CurrentDomain.BaseDirectory + "/" + strPDFFileName;
            //string strAttachment = Server.MapPath(Url.Content("~/Content/" + strPDFFileName));
            string strAttachment = Server.MapPath("~/Downloads/" + strPDFFileName);
            PdfWriter.GetInstance(doc, workStream).CloseStream = false;
            doc.Open();
            string imagepath =Server.MapPath(Url.Content("~/Content/Images/logo_type.jpg"));
            doc.Add(new Paragraph(""));

            Image gif = Image.GetInstance(imagepath);

            doc.Add(gif);
            Chunk c1 = new Chunk("Order Num : " +supplier.orderID );
            DateTime dt = DateTime.Now;
            Chunk chunk = new Chunk("                                          Date Ordered : "+dt.ToString(), FontFactory.GetFont("dax-black"));
            doc.Add(new Paragraph("Contact Details"));
            chunk.SetUnderline(0.5f, -1.5f);
            
            doc.Add(c1);
            doc.Add(chunk);
            
            doc.Add(Add_Content_To_PDF(tableLayout,supplier.orderID));

            // Closing the document
            doc.Close();

            byte[] byteInfo = workStream.ToArray();
            workStream.Write(byteInfo, 0, byteInfo.Length);
            workStream.Position = 0;
            MemoryStream workStream2 = new MemoryStream();
            workStream2 = workStream;
            MailMessage msg = new MailMessage();


            //string fileName = Path.GetFileName(fileUploader.FileName);

            msg.Attachments.Add(new Attachment(workStream,strPDFFileName));

            //}
            msg.From = new MailAddress("abantwanaweb@gmail.com");
            msg.To.Add(new MailAddress(Order.getsupplierEmail(supplier.supplierID)));
            msg.Subject = "New Order";
            msg.Body = "Please Find Attached Invoice";
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", Convert.ToInt32(587));
            System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("abantwanaweb@gmail.com", "#Account{2019}");
            smtpClient.Credentials = credentials;
            smtpClient.EnableSsl = true;
            smtpClient.Send(msg);

            return File(workStream2, "application/pdf", strPDFFileName);

        }



        protected PdfPTable Add_Content_To_PDF(PdfPTable tableLayout,int id)
        {

            float[] headers = { 35, 35, 35, 35, 35, 35 };  //Header Widths
            tableLayout.SetWidths(headers);        //Set the pdf headers
            tableLayout.WidthPercentage = 100;       //Set the PDF File witdh percentage
            tableLayout.HeaderRows = 1;
            //Chunk c1 = new Chunk("A chunk represents an isolated string. ");

            tableLayout.AddCell(new PdfPCell(new Phrase("Invoice", new Font(Font.FontFamily.HELVETICA, 8, 1, new iTextSharp.text.BaseColor(0, 0, 0)))) { Colspan = 12, Border = 0, PaddingBottom = 5, HorizontalAlignment = Element.ALIGN_CENTER });


            ////Add header
            AddCellToHeader(tableLayout, "Item Code");
            AddCellToHeader(tableLayout, "Item Name");
            AddCellToHeader(tableLayout, "Item description");
            AddCellToHeader(tableLayout, "Quantity");
            AddCellToHeader(tableLayout, "Unit Price");
            AddCellToHeader(tableLayout, "Subtotal");
           
            ////Add body

            //Employee em = new Employee();
            //Student Studentz = new Student();
            // List<Employee> el = new List<Employee>();

            foreach (var item in Order.GetAllOrderItems(id))
            {

                //decimal subtotal = item.Quantity * item.Price;
                AddCellToBody(tableLayout, item.ItemId.ToString());
                AddCellToBody(tableLayout, item.itemname);
                AddCellToBody(tableLayout, item.description);
                AddCellToBody(tableLayout, item.Quantity.ToString());
                AddCellToBody(tableLayout, item.Price.ToString());
                AddCellToBody(tableLayout, item.subTotal.ToString());
               

            }


            tableLayout.AddCell(new PdfPCell(new Phrase("Total : "+Order.getorderTotal(id), new Font(Font.FontFamily.HELVETICA, 8, 1, new iTextSharp.text.BaseColor(0, 0, 0)))) { Colspan = 12, Border = 0, PaddingBottom = 5, HorizontalAlignment = Element.ALIGN_CENTER});

            return tableLayout;
        }

        // Method to add single cell to the Header
        private static void AddCellToHeader(PdfPTable tableLayout, string cellText)
        {

            tableLayout.AddCell(new PdfPCell(new Phrase(cellText, new Font(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.YELLOW))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 5, BackgroundColor = new iTextSharp.text.BaseColor(128, 0, 0) });
        }

        // Method to add single cell to the body
        private static void AddCellToBody(PdfPTable tableLayout, string cellText)
        {
            tableLayout.AddCell(new PdfPCell(new Phrase(cellText, new Font(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 5, BackgroundColor = new iTextSharp.text.BaseColor(255, 255, 255) });
        }
    }
}