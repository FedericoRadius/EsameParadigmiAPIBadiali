﻿namespace EsameParadigmiAPIBadiali.Applicazione.Astrazioni.Options
{
    public class JwtAuthenticationOption
    {
        public string Key { get; set; } = string.Empty;
        public string Issuer { get; set; } = string.Empty;
    }
}
