using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace ExceptionHandling
{
    public class PathNotFoundException: ApplicationException{
        public override string Message => "Path doesn't exists! "+base.Message;
    }


    class FileIO
    {

        public string DirectoryPath { get; set; }
        public string FileName { get; set; }

        

        public void readFile() {
            StreamReader reader=null;
            try
            {
                if (System.IO.Directory.Exists(DirectoryPath))
                {
                }
                else
                {
                    throw new PathNotFoundException();
                }
                reader = new StreamReader(@DirectoryPath + '\\' + FileName);
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
            catch (PathNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (FileNotFoundException e) {
                Console.WriteLine(e.Message);
            }
            catch (Exception)
            {

                Console.WriteLine("Something bad happened!");
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
            Console.WriteLine("Normal termination of Reading");
        }
    }
}
