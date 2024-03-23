global using global::System;
global using global::System.Collections.Generic;
global using global::System.IO;
global using global::System.Linq;
global using global::System.Net.Http;
global using global::System.Threading;
global using global::System.Threading.Tasks;

global using static Zustandf.Consts;

namespace Zustandf;

public static class Consts
{
    public const string DATA_MODELS_EVEN_EXCEPTION = "Data instance supports this interaction method only for even-counted parameters instances.";
}
