﻿using System.Reflection;

namespace PhotographyWorkshop.Dto
{
    public class CameraDto
    {
        public string Type { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public bool IsFullFrame { get; set; }

        public int? MinIso { get; set; }

        public int MaxIso { get; set; }

        public string MaxVideoResolution { get; set; }

        public int MaxFrameRate { get; set; }

        public int MaxShutterSpeed { get; set; }

    }
}
