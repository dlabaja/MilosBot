using Discord;

namespace MilošBot
{
    /// <summary>
    /// Discord Channel ID
    /// </summary>
    internal static class DChannelId
    {
        //Hello There
        public const ulong Overeni = 738307611673362502;

        // Informační koutek
        public const ulong Vitej = 728885647745744976;

        // Drbací koutek
        public const ulong Reklama = 773135268650680340;

        public const ulong Spoluprace = 811273659611217930;

        // Minihry
        public const ulong Counting = 788821557588787200;

        public const ulong Fotbal = 833612380649947146;
        public const ulong Kurz = 816642007497310208;

        // Něco strytého
        public const ulong MilosOsobnosti = 795684253953163274;

        public const ulong MilosLog = 794640586447257610;
        public const ulong ConsoleLog = 762374933493448716;
        public const ulong Suggest = 790524584625569821;
        public const ulong ekonomikalog = 814954423972266024;

        public const ulong PoliticiIn = 835111233677426719;
        public const ulong PoliticiOut = 831408879350448168;

        public const ulong Ekonomika = 768928360608563240;
        public const ulong RPG = 772745036189663283;
        public const ulong Akinator = 778324579172352011;
        public const ulong Kapitalisti = 837953692987949096;
        public const ulong Hudba = 728890066033967126;
        public const ulong Statistiky = 735885844694564917;
        public const ulong Panikavajrus = 791398574771666974;
        public const ulong Bump = 831408879350448168;
    }

    internal class Role
    {
        public const ulong Volic = 733247540241367092;
        public const ulong Starosta = 759362028384288818;
        public const ulong Politik = 803893381863571497;

        public static void Od()
        {
            var OdVolice = new ulong[] { Role.Politik, Role.Starosta, Role.Volic };
        }
    }
}