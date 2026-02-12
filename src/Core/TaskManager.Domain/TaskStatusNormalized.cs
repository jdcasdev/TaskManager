namespace TaskManager.Domain
{
    // Consulta a Copilot para no usar un Enum, ya que no es tan flexible para el caso de uso de este proyecto.
    public static class TaskStatusNormalized
    {
        public const string Pendiente = "Pendiente";
        public const string EnProgreso = "En progreso";
        public const string Completada = "Completada";

        public static bool TryNormalize(string? status, out string normalized)
        {
            normalized = string.Empty;
            if (string.IsNullOrWhiteSpace(status))
            {
                return false;
            }

            var value = status.Trim();
            if (value.Equals(Pendiente, StringComparison.OrdinalIgnoreCase))
            {
                normalized = Pendiente;
                return true;
            }

            if (value.Equals(EnProgreso, StringComparison.OrdinalIgnoreCase))
            {
                normalized = EnProgreso;
                return true;
            }

            if (value.Equals(Completada, StringComparison.OrdinalIgnoreCase))
            {
                normalized = Completada;
                return true;
            }

            return false;
        }
    }
}
