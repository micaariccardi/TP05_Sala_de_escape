class Escape 
{
    private static string[] incognitasSalas = new string[4]; 
    private static int estadoJuego = 1;

    private static void InicializarJuego()
    {
        incognitasSalas[0]="6591227";
        incognitasSalas[1]="0";
        incognitasSalas[2]="REGALO";
        incognitasSalas[3]="7666";
    }

    public static int GetEstadoJuego()
    {
        return estadoJuego;
    }
    public static bool ResolverSala(int sala, string incognita)
    {
        bool resuelto = false;
        if (incognitasSalas[0] == null)
        {
            InicializarJuego();
        }
        else
        {
            if (incognitasSalas[sala] == incognita)
            {
                estadoJuego++;
                resuelto = true;
            }
        }
        return resuelto;
    }
}