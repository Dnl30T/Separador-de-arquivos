namespace Separador{
    class Program
    {
        static void Main(String[] args){
            /* string originPath = "C:/Users/Rosário 7/Desktop/Separador de foto/Separador de foto/Fundamental";
            string targetPath = "C:/Users/Rosário 7/Desktop/Separador de foto/Separador de foto/Target";
            string namesFolder = "C:/Users/Rosário 7/Desktop/Separador de foto/Separador de foto/Names.txt"; */
            Console.WriteLine("Insira os caminhos dos arquivos");
            Console.WriteLine("Arquivo com as fotos:");
            string? originPath = Console.ReadLine();
            Console.WriteLine("Arquivo de destino:");
            string? targetPath = Console.ReadLine();
            Console.WriteLine("Arquivo com os nomes:");
            string? namesFolder = Console.ReadLine();
            
            Separar separador = new Separar(Path:originPath, TargetPath:targetPath, NamesPath:namesFolder);
            separador.Run();
        }
    }
}