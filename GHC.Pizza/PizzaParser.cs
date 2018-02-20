using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GHC.Pizza
{
    class PizzaParser
    {
        public int[,] array;
        public int rowCount;
        public int columnCount;
        public int quantities;
        public int maxSliceSize;

        public String filename;

        public void Parse()
        {
            String text = ReadAllFile(this.filename);
            this.Parsetext(text);


        }
        public void Parsetext(String text)
        {
            String[] lines = text.Split(new String[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
            this.ParseDefinitionLine(lines[0]);
            this.array = new int[this.rowCount, this.columnCount];

            for (int lineNumber = 0; lineNumber < this.rowCount; lineNumber++)
            {
                this.ParseRow(lineNumber, lines[lineNumber + 1]);
            }

        }
        public void ParseDefinitionLine(String line)
        {
            String[] parts = line.Split(new String[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            this.rowCount = int.Parse(parts[0]);
            this.columnCount = int.Parse(parts[1]);
            this.quantities = int.Parse(parts[2]);
            this.maxSliceSize = int.Parse(parts[3]);
        }
        public void ParseRow(int rowIndex, string line)
        {
            for (int columnIndex = 0; columnIndex < this.columnCount; columnIndex++)
            {
                this.array[rowIndex, columnIndex] = line[columnIndex] == PizzaParser.Tatmato ? 1 : 0;
            }
        }
        public static String ReadAllFile(String filename)
        {
            String text = String.Empty;

            StreamReader streamReader = new StreamReader(filename);
            text = streamReader.ReadToEnd();
            streamReader.Close();

            return text;
        }
        public String PrintPizza()
        {
            string output = string.Empty;
            for (int row = 0; row < this.rowCount; row++)
            {
                for (int column = 0; column < this.columnCount; column++)
                {
                    output += array[row, column] == 1 ? PizzaParser.Tatmato : PizzaParser.Mushroom;
                }
                output += Environment.NewLine;
            }
            return output;

        }

        public static char Mushroom = 'M';
        public static char Tatmato = 'T';
    }
}
