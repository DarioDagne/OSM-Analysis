using System.IO;
using System.Threading.Tasks;
using OsmSharp.Streams;
using System;

namespace src
{
    /// <summary>
    /// Class zum Laden der zu analysierende Daten
    /// </summary>
     class LoadData
    {
        private string fileName;
        private FileStream fileStream;
        private OsmStreamSource source;
    
        public LoadData(string fileName)
        {
            this.fileName = fileName;
        }


        protected  OsmStreamSource  Source()
        {
            // Überprüfen ob datei vorhanden ist 
            if (File.Exists(fileName))
            {
               
                this.fileStream = File.OpenRead(fileName);

                // Überprufen ob der Datei die in der OsmStreamSource vorhandenen 
                // Extension unterstützt!

                if(Path.GetExtension(fileName)==".xml")
                {
                    return  source = new XmlOsmStreamSource(fileStream);
                }

                else if(Path.GetExtension(fileName)==".osm.pbf") 
                {
                    return  source = new PBFOsmStreamSource(fileStream);
                }

                else
                {
                    throw new InvalidDataException();
                }
            }
            else
            {
                
                throw new FileNotFoundException();
            }
         
        }
        


    }
}