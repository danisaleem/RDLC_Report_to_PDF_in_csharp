public Boolean ExportReportViewerPDF(ReportViewer ReportViewer1, String exportType, String reportsTitle) 
    {
        RefreshAll();
        try
        {
            string extension;
            string FileName = "MyFile_" + DateTime.Now.ToString("ddMMyyyyhhmmss") + ".pdf";
            string encoding;
            string mimeType;
            string[] streams;
            Warning[] warnings;
             
            string path = Server.MapPath("~/Reports/") + FileName;

            Byte[] mybytes = ReportViewer1.LocalReport.Render("PDF", null,
                            out extension, out encoding,
                            out mimeType, out streams, out warnings); //for exporting to PDF  

            // // For saving file to specific location at runtime
            using (FileStream fs = File.Create(path))
            {
                fs.Write(mybytes, 0, mybytes.Length);
            }
             
            // // For sending file to client i.e. open file save option prompt
			
            //Response.ContentType = "application/pdf";
            //Response.AddHeader("Content-Disposition", "attachment; filename=" + FileName);
            //Response.WriteFile(path);
            //Response.Flush();   
        }
        catch (Exception ex)
        {
            lbl_Error.Text = ex.Message;
        }
        return true;
    }
