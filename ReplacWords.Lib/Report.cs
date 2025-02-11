﻿using System.IO;
using System.Threading.Tasks;

namespace ReplacWords.Lib
{
    public class Report
    {
        public async Task WriteInfoToFile()
        {
            using (StreamWriter sw = new StreamWriter(Path.GetFullPath("file_info.txt"), true))
            {
                await sw.WriteLineAsync($"Найдено {Search.ArrBannedWordFile.Length} файла(ов) с запрещёнными словами!");
                
                for (int i = 0; i < Search.ArrBannedWordFile.Length; i++)
                {
                    await sw.WriteLineAsync($"Размер файла №{i + 1}: {new FileInfo(Search.ArrBannedWordFile[i]).Length}");
                    await sw.WriteLineAsync($"Путь файла №{i + 1}: {Path.GetFullPath(Search.ArrBannedWordFile[i])}");
                }

                await sw.WriteLineAsync($"Общее колличество найденных файлов: {Replace.NumberOfSubstitutions}");
            }
        }
    }
}