using System;
using System.IO;
using DevExpress.Pdf;
using DevExpress.Office;
using DevExpress.XtraRichEdit;

namespace pdfLocked
{
    public static class Snippet
    {
	public static System.String ConvToPdf(System.String p_arquivoConverter, ref System.String r_arquivoGerado, ref System.String r_codigoErro, System.String senha)
	{ 	
		FileInfo file = new FileInfo(p_arquivoConverter);
		if(file.Exists)
		{
			try
        	{
                    r_codigoErro = " ";
                    string v_fileExtension = Path.GetExtension(p_arquivoConverter).ToUpper();
            	if (v_fileExtension == ".DOC" || v_fileExtension == ".DOCX" || v_fileExtension == ".RTF")
            	{
					RichEditDocumentServer server;
            		server = new RichEditDocumentServer();
            		server.LoadDocument(p_arquivoConverter);
            		string outFileName = Path.ChangeExtension(p_arquivoConverter, "PDF");
            		FileStream fsOut = File.Open(outFileName, FileMode.Create);
                    server.ExportToPdf(fsOut, new DevExpress.XtraPrinting.PdfExportOptions() { NeverEmbeddedFonts = "" });
                    fsOut.Close();

                        if (!string.IsNullOrEmpty(senha))
                        {
                            CriptografarPdf(outFileName, senha, ref r_codigoErro);
                            if(r_codigoErro != " ")
                            {
                                r_arquivoGerado = " ";
                                return "Erro ao criptografar o PDF: " + r_codigoErro;
                            }
                        }

                        r_arquivoGerado = outFileName;
             		return " ";
				}
				else
				{
					r_arquivoGerado = " ";
					r_codigoErro = "CONV_TO_PDF";
					return "Extensão do arquivo incompativel (.doc/.docx/.rtf).";
				}
			}
			catch (Exception e)
			{
				r_arquivoGerado = " ";
				r_codigoErro = "CONV_TO_PDF: " + e.HResult;
				return "Erro: " + e.Message;
			}
		}
		else
		{
			r_arquivoGerado = " ";
			r_codigoErro = "CONV_TO_PDF";
			return "Erro: Arquivo não existe.";
		}
	
    }
        private static void CriptografarPdf(string pdfFilePath, string senha, ref string r_codigoErro)
        {
            try
            {
                using (PdfDocumentProcessor documentProcessor = new PdfDocumentProcessor())
                {
                    documentProcessor.LoadDocument(pdfFilePath);

                    // Define as opções de criptografia
                    PdfEncryptionOptions encryptionOptions = new PdfEncryptionOptions
                    {
                        UserPasswordString = senha,
                        PrintingPermissions = PdfDocumentPrintingPermissions.NotAllowed,
                        DataExtractionPermissions = PdfDocumentDataExtractionPermissions.NotAllowed
                    };

                    // Aplica as opções de criptografia e sobrescreve o arquivo
                    documentProcessor.SaveDocument(pdfFilePath, new PdfSaveOptions()
                    {
                        EncryptionOptions = encryptionOptions
                    });
                }
            }
            catch (Exception e)
            {
                r_codigoErro = "CRIPTOGRAFAR_PDF: " + e.HResult;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Caminho do arquivo PDF de entrada
            string inputFilePath = @"C:\\pasta\\Desktop\\aa\\License.rtf";
            // Caminho do arquivo PDF de saída (criptografado)
            string outputFilePath = @"C:\\Users\\Desktop\\aa\\TreinamentoEmissaoNFSE - Copia.pdf";
            // Senha para criptografar o PDF
            string senha = "0000";
            string r_codigoErro = "";
            // Chama o método para criptografar o PDF
            Snippet.ConvToPdf(inputFilePath,ref outputFilePath,ref r_codigoErro, senha);


            Console.WriteLine("PDF criptografado com sucesso!"+outputFilePath  + r_codigoErro);
        }
    }
}