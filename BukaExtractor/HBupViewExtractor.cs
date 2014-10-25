using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BukaExtractor
{
    class HBupViewExtractor : Extractor
    {
        public override void extract()
        {
            foreach (string s in directoriesInDirectory)
            {
                int cnt = 0;
                string[] filesInSubdirectory = Directory.GetFiles(s, "*view");
                foreach (string ss in filesInSubdirectory)
                {
                    byte[] temp = File.ReadAllBytes(ss);

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
                            using (FileStream output = File.Create(s + @"\" + cnt++.ToString() + ".webp"))
                            using (BinaryWriter writer = new BinaryWriter(output))
                            {
                                for (int k = i; k < temp.Length; k++)
                                    writer.Write(temp[k]);
                            }
                            break;
                        }
                    }
                }
            }
        }
    }
}
