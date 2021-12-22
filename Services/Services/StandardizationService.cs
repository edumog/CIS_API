using CIS.Interfaces;
using CIS.DTOs;
using CIS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace CIS.Services
{
    public class StandardizationService : StandardizationContract
    {
        public IList<Client> GetClients(StandardizationParameters options)
        {
            string stringFile = ReadFile(options.File);
            IList<string> rows = GetRows(stringFile, options.ColumnDelimiter);
            IList<string> headers = GetHeaders(rows[0], options.RowDelimiter);
            rows.RemoveAt(0);
            return GetClients(rows, headers, options.NameComposition, options.LastNameComposition, options.AddressDelimiter, options.Addresses, options.PhoneDelimiter, options.PhoneNumbers);
        }
        private string ReadFile(IFormFile file)
        {
            string stringFile;
            using (StreamReader readFile = new StreamReader(file.OpenReadStream()))
            {
                stringFile = readFile.ReadLine() ?? "";
            }
            return stringFile;
        }
        private IList<string> GetRows(string readFile, string columnDelimiter)
        {
            if (readFile == "") throw new Exception("Archivo vacio");
            IList<string> rows = readFile.Split(new char[] { columnDelimiter.FirstOrDefault() }).ToList<string>();
            rows.Remove("");
            return rows;
        }
        private IList<string> GetHeaders(string row, string rowDelimiter)
        {
            return row.Split(new char[] { rowDelimiter.FirstOrDefault() }).ToList<string>();
        }
        private IList<Client> GetClients(IList<string> rows, IList<string> headers, string[] nameComposition, string[] lastNameComposition, string addressDelimiter, string[] addresses, string phoneDelimiter, string[] phoneNumbers)
        {
            IList<Client> clientes = new List<Client>();
            foreach (string row in rows)
            {
                IList<string> rowValues = row.Split(new char[] { ',' }).ToList<string>();
                Client client = new Client
                {
                    Name = ComposeProperty(nameComposition, headers, rowValues),
                    LastName = ComposeProperty(lastNameComposition, headers, rowValues),
                    PhoneNumber = ComposeArrayProperty(phoneDelimiter, phoneNumbers, rowValues, headers),
                    Addresses = ComposeArrayProperty(addressDelimiter, addresses, rowValues, headers)
                };
                clientes.Add(client);
            }
            return clientes;
        }
        private string ComposeProperty(string[] compositionElements, IList<string> headers, IList<string> rowValues)
        {
            string property = "";
            foreach (string compositionElement in compositionElements)
            {
                if (!headers.Contains(compositionElement)) throw new Exception("Error por favor revise las opciones");
                int propertyIndex = headers.IndexOf(compositionElement);
                property = property + $" { rowValues[propertyIndex] ?? "" } ";
            }
            return property;
        }
        private IList<string> ComposeArrayProperty(string delimiter, string[] compositionElements, IList<string> rowValues, IList<string> headers)
        {
            return (delimiter == null || delimiter == "") ? ComposeArrayProperty(compositionElements, rowValues, headers) : ComposeArrayProperty(delimiter, compositionElements[0], rowValues, headers);
        }
        private IList<string> ComposeArrayProperty(string[] compositionElements, IList<string> rowValues, IList<string> headers)
        {
            IList<string> result = new List<string>();
            foreach (string element in compositionElements)
            {
                if (!headers.Contains(element)) throw new Exception("Error por favor revise las opciones");
                int propertyIndex = headers.IndexOf(element);
                result.Add(rowValues[propertyIndex] ?? "");
            }
            return result;
        }
        private IList<string> ComposeArrayProperty(string delimiter, string compositionElements, IList<string> rowValues, IList<string> headers)
        {
            IList<string> result = new List<string>();
            if (!headers.Contains(compositionElements)) throw new Exception("Error por favor revise las opciones");
            int propertyIndex = headers.IndexOf(compositionElements);
            string[] elements = rowValues[propertyIndex].Split(delimiter);
            foreach (var element in elements)
            {
                result.Add(element);
            }
            return result;
        }
    }
}
