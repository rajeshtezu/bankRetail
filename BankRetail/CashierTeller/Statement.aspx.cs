using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BO;
using DAL;

using System.IO;
using System.Configuration;
using System.Windows;

using iTextSharp.text.pdf;
using iTextSharp.text;

namespace BankRetail
{
    public partial class WebForm14 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void Button1_Click(object sender, EventArgs e)
        {
            int account_id = Convert.ToInt32(TextBox1.Text);
            int n_trn = Convert.ToInt16(DropDownList1.SelectedValue);

            cashier_transactions tran_obj = new cashier_transactions(account_id, n_trn);
            Operation op = new Operation();
            GridView1.DataSource = op.cashier_trn_statement(tran_obj);
            GridView1.DataBind();

        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            PdfPTable pdftable = new PdfPTable(GridView1.HeaderRow.Cells.Count);

            foreach (TableCell headercell in GridView1.HeaderRow.Cells)
            {



                PdfPCell pdfcell = new PdfPCell(new Phrase(headercell.Text));

                pdftable.AddCell(pdfcell);

            }

            foreach (GridViewRow gridviewrow in GridView1.Rows)
            {

                foreach (TableCell tablecell in gridviewrow.Cells)
                {

                    if (tablecell == gridviewrow.Cells[0])
                    {
                        Label lb1 = (Label)gridviewrow.FindControl("Label3");
                        PdfPCell pdfcell = new PdfPCell(new Phrase(lb1.Text));
                        pdftable.AddCell(pdfcell);
                    }
                    else if (tablecell == gridviewrow.Cells[1])
                    {
                        Label lb1 = (Label)gridviewrow.FindControl("Label4");
                        PdfPCell pdfcell = new PdfPCell(new Phrase(lb1.Text));
                        pdftable.AddCell(pdfcell);
                    }
                    else if (tablecell == gridviewrow.Cells[2])
                    {
                        Label lb1 = (Label)gridviewrow.FindControl("Label5");
                        PdfPCell pdfcell = new PdfPCell(new Phrase(lb1.Text));
                        pdftable.AddCell(pdfcell);
                    }
                    else
                    {
                        Label lb1 = (Label)gridviewrow.FindControl("Label6");
                        PdfPCell pdfcell = new PdfPCell(new Phrase(lb1.Text));
                        pdftable.AddCell(pdfcell);
                    }
                }
            }

            //foreach (GridViewRow gridviewrow in GridView1.Rows)
            //{
            //    foreach (TableCell tablecell in gridviewrow.Cells)
            //    {
            //        Font font = new Font();
            //        font.Color = BaseColor.BLACK;

            //        PdfPCell pdfcell = new PdfPCell(new Phrase(tablecell.Text));
            //        pdfcell.BackgroundColor = new BaseColor(GridView1.RowStyle.BackColor);

            //        pdftable.AddCell(pdfcell);

            //    }
            //}
            Document pdfdocument = new Document(PageSize.A4, 10f, 10f, 10f, 10f);
            PdfWriter.GetInstance(pdfdocument, Response.OutputStream);
            pdfdocument.Open();
            pdfdocument.Add(pdftable);
            pdfdocument.Close();

            Response.ContentType = "application/pdf";
            Response.AppendHeader("content-disposition", "attachment;filename=Statement.pdf");
            Response.Write(pdfdocument);
            Response.Flush();
            Response.End();

        }



    }
}
