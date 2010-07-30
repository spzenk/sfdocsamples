using System;
namespace Symetric_EntLibs_5._0
{
    interface ISymetriCypher
    {
        string CreateKeyFile();
        string CreateKeyFile(string keyFileName);
        string Dencrypt(string val);
        string Encrypt(string val);
    }
}
