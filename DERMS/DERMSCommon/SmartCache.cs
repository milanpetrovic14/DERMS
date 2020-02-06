﻿using DERMSCommon.SCADACommon;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace DERMSCommon
{
    public class SmartCache
    {
        private string path;

        public SmartCache() 
        {
            path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName, @"SmartCash\Smart_Cash.dat");
        }
        public void WriteToFile(List<DataPoint> listOfScadaData)
        {
            Dictionary<long, List<DataPoint>> dictionaryDataPoints = new Dictionary<long, List<DataPoint>>();
            List<DataPoint> temp = new List<DataPoint>();

            foreach (DataPoint d in listOfScadaData)
            {
                if (!dictionaryDataPoints.ContainsKey(d.Gid))
                {
                    foreach (var d1 in listOfScadaData)
                    {
                        if (d1.Gid == d.Gid)
                        {
                            temp.Add(d1);
                        }
                    }
                }

                dictionaryDataPoints.Add(d.Gid, temp);
                temp.Clear();
            }
            using (var fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                using (var w = new StreamWriter(fs))
                {
                    var bw = new BinaryFormatter();
                    bw.Serialize(fs, dictionaryDataPoints);
                    w.Write(dictionaryDataPoints);
                }
            }
        }

        public Dictionary<long, List<DataPoint>> ReadFromFile()
        {
            using (var fs = new FileStream(path, FileMode.Open))
            {
                var bw = new BinaryFormatter();
                return (Dictionary<long, List<DataPoint>>)bw.Deserialize(fs);
            }
        }

    }
}
