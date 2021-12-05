using Application.Common.Interfaces;
using Domain.Entites;
using Microsoft.Extensions.Logging;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Files
{
    public class XlsxReader : IXslsReader<(ICollection<Organization>, ICollection<Region>)>
    {
        private readonly ILogger<XlsxReader> _logger;

        public XlsxReader(ILogger<XlsxReader> logger)
        {
            _logger = logger;
        }

        public async Task<(ICollection<Organization>, ICollection<Region>)> ReadAsync(string fileName)
        {
            var organizations = new List<Organization>();
            var regions = new List<Region>();

            using (var excel = new ExcelPackage(new FileInfo(fileName)))
            {
                foreach (var worksheet in excel.Workbook.Worksheets)
                {
                    if (worksheet.Cells.Value != null)
                    {
                        for (int i = 1; i <= (worksheet.Cells.Value as object[,]).GetLength(0); i++)
                        {
                            try
                            {
                                var inn = worksheet.Cells[i, 2].GetValue<int>();
                                var name = worksheet.Cells[i, 3].GetValue<string>();
                                var address = worksheet.Cells[i, 6].GetValue<string>();
                                var street = worksheet.Cells[i, 7].GetValue<string>();
                                var phone = worksheet.Cells[i, 8].GetValue<string>();

                                var addresses = address.Split(",");

                                var regionName = addresses[0].Replace('`', '\'');
                                var region = regions.FirstOrDefault(x => x.Name.Contains(regionName));
                                if (region == null)
                                {
                                    region = new Region
                                    {
                                        Name = addresses[0]
                                    };

                                    regions.Add(region);
                                }

                                var city = region.Cities.FirstOrDefault(x => x.Name.Contains(addresses[1]));
                                if (city == null)
                                {
                                    city = new City
                                    {
                                        Name = addresses[1],
                                        Region = region
                                    };

                                    region.Cities.Add(city);
                                }

                                District district = null;
                                if (addresses.Length == 3)
                                {
                                    district = city.Districts.FirstOrDefault(x => x.Name.Contains(addresses[2]));
                                    if (district == null)
                                    {
                                        district = new District
                                        {
                                            City = city,
                                            Region = region,
                                            Name = addresses[2]
                                        };
                                        city.Districts.Add(district);
                                        //region.Districts.Add(district);
                                    }
                                }

                                var organization = new Organization
                                {
                                    Brand = "",
                                    INN = inn,
                                    Phone = phone,
                                    Name = name,
                                    Street = street,
                                    Region = region,
                                    City = city,
                                    District = district
                                };

                                organizations.Add(organization);
                            }
                            catch (FormatException) { }
                            catch (Exception ex)
                            {
                                _logger.LogError(ex, $"An error occured while parsing '{fileName}'");
                                //throw new BadRequestException("An error occured while parsing the file");
                            }
                        }
                    }
                }
            }

            return await Task.FromResult((organizations, regions));
        }
    }
}
