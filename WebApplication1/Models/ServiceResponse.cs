﻿namespace WebApplication1.Models
{
    public class ServiceResponse<T>
    {
        public T? data { get; set; }
        public string message { get; set; } = string.Empty;
        public bool sucsses { get; set; } = true;
    }
}
