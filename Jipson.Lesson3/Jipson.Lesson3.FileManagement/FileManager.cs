using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jipson.Lesson3.FileManagement
{
    public class FileManager
    {
        private string _fileName;

        public FileManager(string fileName)
        {
            if (!File.Exists(fileName))
                throw new FileNotFoundException("File not found");
            this._fileName = fileName;
        }

        public bool Add(string newInfo)
        {
            try
            {
                var sw = new StreamWriter(_fileName,true);
                sw.WriteLine(newInfo);
                sw.Close();
                return true;
            }
            catch (Exception ex)
            {
                //error logging
                return false;
            }
        }

        public bool Delete(string stringToRemove)
        {
            try
            {
                var contents = GetAllContents();
                contents = contents.Replace(stringToRemove, string.Empty);
                var sw = new StreamWriter(_fileName,false);
                sw.Write(contents);
                sw.Close();
                return true;
            }
            catch (Exception ex)
            {
                //error logging
                return false;
            }
        }

        public StringBuilder GetAllContents()
        {
            var sr = new StreamReader(_fileName);
            var contents = sr.ReadToEnd();
            sr.Close();
            return new StringBuilder(contents);
        }
    }
}
