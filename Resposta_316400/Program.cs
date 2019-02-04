﻿using Spire.Xls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resposta_316400
{
    class Program
    {
        static void Main(string[] args)
        {
            //Pegar a pasta do projeto
            string workingDirectory = Environment.CurrentDirectory;
            string CaminhoArquivoExcel = Directory.GetParent(workingDirectory).Parent.FullName + "\\Sample.xls";
            string caminhoConversaoPDF = Directory.GetParent(workingDirectory).Parent.FullName + "\\MinhasConversoes";
            string resultadoPDF;

            if(ConverterExcelParaPDF(CaminhoArquivoExcel, caminhoConversaoPDF, out resultadoPDF))
            {
                Console.WriteLine(String.Format("Arquivo excel convertido com sucesso. Caminho do arquivo: {0}", resultadoPDF));
            }
            else
            {
                Console.WriteLine("Ocorreu um erro ao converter o arquivo.");
            }
            Console.ReadLine();
        }

        public static bool ConverterExcelParaPDF(string caminhoArquivoExcel, string caminhoParaSalvarResultadoPDF, out string nomeArquivoPDF)
        {
            nomeArquivoPDF = String.Empty;

            //Se o arquivo não existir, retornar falso
            if (!File.Exists(caminhoArquivoExcel))
            {
                return false;
            }

            //Gera um guid para usar no nome do arquivo e concateca com o caminho onde o arquivo será armazenado:
            string caminhoCompletoPDF = caminhoParaSalvarResultadoPDF + "\\" + Guid.NewGuid() + ".pdf";

            using (Workbook workbook = new Workbook())
            {
                workbook.LoadFromFile(caminhoArquivoExcel);
                //Para fazer o conteúdo do excel se ajustar ao tamanho do PDF:
                workbook.ConverterSetting.SheetFitToPage = true;
                workbook.SaveToFile(caminhoCompletoPDF, FileFormat.PDF);
            }

            if (!File.Exists(caminhoCompletoPDF))
            {
                return false;
            }
            else
            {
                nomeArquivoPDF = caminhoCompletoPDF;
            }
            return true;
        }
    }
}