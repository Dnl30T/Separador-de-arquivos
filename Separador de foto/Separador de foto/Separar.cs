using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;
using System.Text;
using System.Globalization;

namespace Separador
{
    public class Separar
    {
        private static string? _path;
        private static string? _targetPath;
        private static string? _namesPath;

        public Separar(string Path, string TargetPath, string NamesPath)
        {
            _path = Path;
            _targetPath = TargetPath;
            _namesPath = NamesPath;
        }

        public void Run(){
            if (_path == null || _targetPath == null || _namesPath == null)
            {
                Console.WriteLine("Preencha todos os campos");
            }else{
                SepararFotos();
            }
        }
        private void SepararFotos(){
            
            string [] getNames = Directory.GetFiles(_path);
            if (File.Exists(_namesPath))
            {
                using (StreamReader leitor = new StreamReader(_namesPath))
                {
                    string linha;
                    while ((linha = leitor.ReadLine()) != null)
                    {
                        foreach (var item in getNames)
                        {
                            if (NormalizeString(Clean(linha)) == NormalizeString(Clean(item)))
                            {
                                Console.WriteLine("Match");
                                File.Move(item,_targetPath+Clean(item,false));
                            }
                        }
                    }
                }
            }else{
                Console.WriteLine("O arquivo não existe.");
            }
        }
        public static string Clean(string input, bool cleanAll = true){
            if(cleanAll){
                input = ReplaceWhitespace(input,"").Replace(ReplaceWhitespace(_path+$@"\",""),"");
                return input.Replace(".jpg", "");
            }
            else
                return input.Replace(_path,"");
        }

        private static readonly Regex sWhitespace = new Regex(@"\s+");
        public static string ReplaceWhitespace(string input, string replacement) 
        {
            return sWhitespace.Replace(input, replacement);
        }

        public static string NormalizeString(string input){
            StringBuilder sbReturn = new StringBuilder();
            var arrayText = input.Normalize(NormalizationForm.FormD).ToCharArray();
            foreach (char letter in arrayText)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(letter) != UnicodeCategory.NonSpacingMark)
                {
                    sbReturn.Append(letter);
                }
            }
            return sbReturn.ToString();
        }
    }
}