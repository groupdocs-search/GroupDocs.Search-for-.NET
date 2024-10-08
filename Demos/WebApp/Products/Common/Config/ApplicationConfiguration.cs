﻿using GroupDocs.Search.WebForms.Products.Common.Util.Parser;
using GroupDocs.Search.WebForms.Products.Search.Util.Directory;
using System;
using System.Diagnostics;
using System.IO;

namespace GroupDocs.Search.WebForms.Products.Common.Config
{
    /// <summary>
    /// Application configuration
    /// </summary>
    public class ApplicationConfiguration
    {
        public string LicensePath { get; set; } = "Licenses";

        /// <summary>
        /// Get license path from the application configuration section of the web.config
        /// </summary>
        public ApplicationConfiguration()
        {
            YamlParser parser = new YamlParser();
            dynamic configuration = parser.GetConfiguration("application");
            ConfigurationValuesGetter valuesGetter = new ConfigurationValuesGetter(configuration);
            string license = valuesGetter.GetStringPropertyValue("licensePath");
            if (String.IsNullOrEmpty(license))
            {
                LicensePath = @"C:/Licenses/GroupDocs.Search.lic";
            }
            else
            {
                if (!DirectoryUtils.IsFullPath(license))
                {
                    license = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, license);
                    if (!Directory.Exists(Path.GetDirectoryName(license)))
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(license));
                    }
                }
                LicensePath = license;
                if (!File.Exists(LicensePath))
                {                    
                    Debug.WriteLine("License file path is incorrect, launched in trial mode");
                    LicensePath = "";
                }
            }
        }
    }
}