using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BukaExtractor
{
    class BukaExtractor : Extractor
    {
        public override void extract()
        {
            foreach (string s in filesInDirectory)
            {
                List<int> start_pos = new List<int>();
                byte[] temp = File.ReadAllBytes(s);
                string[] newDirectory = s.Split('.');
                Directory.CreateDirectory(newDirectory[0]);

                for (int i = 0; i < temp.Length - riff.Length; i++)
                {
                    bool is_riff = true;
                    for (int j = 0; j < riff.Length; j++)
                    {
                        if (temp[i + j] != riff[j])
                        {
                            is_riff = false;
                            break;
                        }
                    }
                    if (is_riff)
                    {
                        start_pos.Add(i);
                    }
                }
                for (int i = 0; i < start_pos.Count; i++)
                {
                    if (start_pos[i] != start_pos.Last<int>())
                    {
                        using (FileStream output = File.Create(newDirectory[0] + @"\" + i.ToString() + ".webp"))
                        using (BinaryWriter writer = new BinaryWriter(output))
                        {
                            for (int j = start_pos[i]; j < start_pos[i + 1]; j++)
                                writer.Write(temp[j]);
                        }
                    }
                    else
                    {
                        using (FileStream output = File.Create(newDirectory[0] + @"\" + i.ToString() + ".webp"))
                        using (BinaryWriter writer = new BinaryWriter(output))
                        {
                            for (int j = start_pos[i]; j < temp.Length; j++)
                                writer.Write(temp[j]);
                        }
                    }
                }
            }
        }
    }
}
