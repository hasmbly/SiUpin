﻿namespace SiUpin.Shared
{
    public class SiUpinOptions
    {
        public const string RootSection = "SiUpin";

        public string UploadsRootFolderPath { get; set; }
        public int UploadsLimit { get; set; }
        public int FileSizeLimit { get; set; }
    }
}