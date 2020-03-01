using System;

namespace PA.Covariance
{
    public class Persona
    {
        public string Name { get; set; }
    }

    public class Empleado : Persona
    {
        public int Id { get; set; }
    }

    public class Jefe : Empleado
    {
    }

    public class Becario : Empleado
    {
    }
}
