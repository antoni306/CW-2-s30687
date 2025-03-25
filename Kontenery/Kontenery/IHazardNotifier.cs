using System.Runtime.InteropServices;

namespace Kontenery
{
    internal interface IHazardNotifier
    {
         void DangerousSituation(string message);
    }
}