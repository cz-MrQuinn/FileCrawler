using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;
using System.Data;

namespace FileCrawler.classes
{


    public class exportCSV<T> where T : class
    {
        public List<T> Objects;

        public exportCSV(List<T> objects)
        {
            Objects = objects;
        }

        public string Export()
        {
            return Export(true);
        }

        public string Export(bool includeHeaderLine)
        {
            if (Objects is List<DataRow>)
            {
                return ExportDataFromDataRows(includeHeaderLine);
            }


            StringBuilder sb = new StringBuilder();
            //Get properties using reflection.
            IList<PropertyInfo> propertyInfos = typeof(T).GetProperties();

            if (includeHeaderLine)
            {
                //add header line.
                foreach (PropertyInfo propertyInfo in propertyInfos)
                {
                    sb.Append(propertyInfo.Name).Append("\t");
                }
                sb.Remove(sb.Length - 1, 1).AppendLine();
            }

            //add value for each property.
            foreach (T obj in Objects)
            {
                foreach (PropertyInfo propertyInfo in propertyInfos)
                {
                    sb.Append(MakeValueCsvFriendly(propertyInfo.GetValue(obj, null))).Append("\t");
                }
                sb.Remove(sb.Length - 1, 1).AppendLine();
            }

            return sb.ToString();
        }



        //export to a file.
        public void ExportToFile(string path)
        {
            File.WriteAllText(path, Export());
        }

        // export to html
        public string ExportToHtmlTable()
        {

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\"" + "\"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">");
            sb.AppendLine(" <head>");

            sb.AppendLine("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\" />");
            sb.AppendLine("<title>Demystifying Email Design</title>");
            sb.AppendLine("<meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\"/>");
            sb.AppendLine("</head>");
            sb.AppendLine("<body style=\"margin: 0; padding: 0;\">");
            sb.AppendLine("<table border=\"1\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\">");
            sb.AppendLine("<thead>");

            IList<PropertyInfo> propertyInfos = typeof(T).GetProperties();

            //add header line.
            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                sb.Append(String.Format("<th>{0}</th>", propertyInfo.Name));
            }

            //<th>cenik_id</th>
            //<th>název</th>
            //<th>stav na konci 2015</th>
            //<th>stav na počátku 2016</th>

            sb.AppendLine("</thead>");

            //add value for each property.
            foreach (T obj in Objects)
            {
                sb.AppendLine("<tr>");
                foreach (PropertyInfo propertyInfo in propertyInfos)
                {
                    //sb.Append().Append("\t");
                    sb.AppendLine(String.Format("<td>{0}</td>", MakeValueCsvFriendly(propertyInfo.GetValue(obj, null))));
                }
                sb.AppendLine("</tr>");
            }

            sb.AppendLine("</table>");
            sb.AppendLine("</body>");
            sb.AppendLine("</html>");

            return sb.ToString();

            //  <tr>   
            //      <td align=\"center\">65356</td>
            //      <td>Přefakturace dopravy</td>
            //      <td align=\"center\">24</td>
            //      <td align=\"center\">1000</td>
            //  </tr>
            // 
            //</body>
            //</html>
        }

        //export as binary data.
        public byte[] ExportToBytes()
        {
            return Encoding.UTF8.GetBytes(Export());
        }

        //get the csv value for field.
        private string MakeValueCsvFriendly(object value)
        {
            if (value == null) return "";
            if (value is Nullable && ((System.Data.SqlTypes.INullable)value).IsNull) return "";

            if (value is DateTime)
            {
                if (((DateTime)value).TimeOfDay.TotalSeconds == 0)
                    return ((DateTime)value).ToString("dd.MM.yyyy");
                return ((DateTime)value).ToString("dd.MM.yyyy HH:mm:ss");
            }
            string output = value.ToString();

            //if (output.Contains(",") || output.Contains("\""))
            if (output.Contains("\""))
                output = '"' + output.Replace("\"", "\"\"") + '"';

            return output;

        }


        private string ExportDataFromDataRows(bool includeHeader)
        {
            StringBuilder sb = new StringBuilder();

            //List<DataRow> drs = (List<DataRow>)Objects;

            List<string> colNames = new List<string>();

            if (Objects.Count > 0)
            {
                //object o = Objects[0];
                DataRow dr = (DataRow)(object)Objects[0]; // dvojité rozbalení zapouzdřeného objektu (přímé přetypování z T na DataRow neprojde)


                foreach (DataColumn dc in dr.Table.Columns)
                {
                    colNames.Add(dc.ColumnName);

                    if (includeHeader)
                        sb.Append(dc.ColumnName).Append("\t");
                }

                if (includeHeader)
                    sb.Remove(sb.Length - 1, 1).AppendLine();

            }


            foreach (object v in Objects)
            {
                DataRow dr = (DataRow)v;
                foreach (string colname in colNames)
                {
                    sb.Append(MakeValueCsvFriendly(dr[colname])).Append("\t");
                }
                sb.Remove(sb.Length - 1, 1).AppendLine();
            }

            //IList<PropertyInfo> propertyInfos = typeof(T).GetProperties();


            //{
            //    if (v is DataRow)
            //    {
            //        foreach (var c in ((DataRow)v).Table.Columns)
            //        {
            //            sb.Append(propertyInfo.Name).Append("\t");

            //        }
            //    }

            return sb.ToString();
        }


    }
}
